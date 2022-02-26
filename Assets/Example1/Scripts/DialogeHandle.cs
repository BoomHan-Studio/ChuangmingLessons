using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogeHandle : MonoBehaviour
{
    PersonDisplay feng;
    PersonDisplay wang;
    PersonDisplay xie;
    Dialoge[] dialoges;

    Dictionary<Person, PersonDisplay> toRef;

    Image icon;
    TMP_Text speakerText;
    TMP_Text wordsText;

    public DialogeHandle()
	{
        
        dialoges = new[]
        {
            new Dialoge(Person.Feng, "��������������������������������"),
            new Dialoge(Person.Feng, "���⣬��˶�������ô������ѽ��"),
            new Dialoge(Person.Wang, "�Ϸ밡�����������ҳԡ�����˵��˵�������ڲ������˶���"),
            new Dialoge(Person.Feng, "�����ߣ�����ӳ��������˾�ϲ������Ц������ȳ԰ɣ��Ҳ����ţ������˹���"),
            new Dialoge(Person.Xie, "�㲻���ߡ�"),
            new Dialoge(Person.Feng, "����������м˾��㲻����������ӳ�����˵�˵��ɣ�"),
            new Dialoge(Person.Xie, "���š��ҷǳ����ţ�"),
        };
	}
    [SerializeField]
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        feng = new PersonDisplay(Resources.Load<Sprite>("Feng"), "��ɽ��", Color.green);
        wang = new PersonDisplay(Resources.Load<Sprite>("Wang"), "����ӳ�", Color.blue);
        xie = new PersonDisplay(Resources.Load<Sprite>("Xie"), "м˾��", Color.red);
        toRef = new Dictionary<Person, PersonDisplay>()
        {
            {Person.Feng, feng},
            {Person.Wang, wang},
            {Person.Xie, xie},
        };

        icon = GameObject.Find("Icon").GetComponent<Image>();
        speakerText = GameObject.Find("Speaker").GetComponent<TMP_Text>();
        wordsText = GameObject.Find("Words").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (index == dialoges.Length) return;
        if (Input.GetKeyUp(KeyCode.Space))
		{
            index++;
            
		}
        icon.sprite = toRef[dialoges[index].personName].img;
        speakerText.text = toRef[dialoges[index].personName].name + ":";
        speakerText.color = toRef[dialoges[index].personName].textColor;
        wordsText.text = dialoges[index].words;
        wordsText.color = toRef[dialoges[index].personName].textColor;
    }
}
