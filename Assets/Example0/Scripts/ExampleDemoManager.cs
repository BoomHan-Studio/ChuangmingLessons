using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ExampleDemoManager : MonoBehaviour
{

	public TMP_Text TimeText;

	public DateTime TimeLeft;

	public AudioClip[] AudioClips;

	public AudioSource Source;

	int TotalDuration;
	Transform cameraTrans;

	// Start is called before the first frame update
	void Start()
	{
		cameraTrans = GameObject.Find("FirstPersonCharacter").GetComponentInChildren<Transform>();

		float duration = .0f;
		foreach (var clip in AudioClips)
		{
			duration += clip.length;
		}
		TotalDuration = (int)duration;

		ResetTime();

		StartCoroutine(Tick());
		StartCoroutine(PlayAudios());
	}

	float tick = .0f;
	const float dPi = (float)Math.PI * 2;
	void Update()
	{
		tick += Time.deltaTime;
		if (tick >= dPi)
		{
			tick -= dPi;
		}
		Vector3 euler = transform.rotation.eulerAngles;
		float offset = 0.3f * (float)Math.Sin(tick);
		cameraTrans.rotation = Quaternion.Euler(euler.x, euler.y + offset, offset);

		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}
	}

	IEnumerator Tick()
	{
		while (TimeLeft != DateTime.MinValue)
		{
			yield return new WaitForSeconds(1);
			TotalDuration--;
			ResetTime();
			//Debug.Log("Tick");
		}
		TimeText.SetText("PLEASE WAIT...");
	}

	IEnumerator PlayAudios()
	{
		for (int i = 0; i < AudioClips.Length; i++)
		{
			Source.clip = AudioClips[i];
			Source.Play();
			yield return new WaitForSeconds(Source.clip.length);
		}
	}

	void ConvertToHMS(out int hour, out int minute, out int second)
	{
		hour = TotalDuration / 3600;
		minute = (TotalDuration % 3600) / 60;
		second = TotalDuration % 60;
	}

	void ResetTime()
	{
		ConvertToHMS(out int hour, out int minute, out int second);
		TimeLeft = new DateTime(0001, 1, 1, hour, minute, second);
		TimeText.SetText(string.Format("{0:T}", TimeLeft));
	}
}
