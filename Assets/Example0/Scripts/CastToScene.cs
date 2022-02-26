using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CastToScene : MonoBehaviour
{
    public Button skip;

	public string demoSceneName;

	void Start()
	{
		//skip = GameObject.Find("Skip").GetComponent<Button>();
	}

	public void Cast()
	{
		SceneManager.LoadScene(demoSceneName, LoadSceneMode.Single);
	}
}
