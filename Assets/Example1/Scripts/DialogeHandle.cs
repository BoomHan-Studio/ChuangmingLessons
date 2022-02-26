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
            new Dialoge(Person.Feng, "啊哈，啊哈哈哈哈哈哈，鸡汤来咯！"),
            new Dialoge(Person.Feng, "诶这，这菜都齐了怎么还不吃呀？"),
            new Dialoge(Person.Wang, "老冯啊，大伙儿都不敢吃。有人说，说是有人在菜里下了毒！"),
            new Dialoge(Person.Feng, "害羞羞，王大队长，你这人就喜欢开玩笑。快趁热吃吧，我不打扰，我走了哈！"),
            new Dialoge(Person.Xie, "你不能走。"),
            new Dialoge(Person.Feng, "啊哈哈哈，屑司令，你不会相信王大队长，胡说八道吧？"),
            new Dialoge(Person.Xie, "我信。我非常相信！"),
        };
	}
    [SerializeField]
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        feng = new PersonDisplay(Resources.Load<Sprite>("Feng"), "穿山甲", Color.green);
        wang = new PersonDisplay(Resources.Load<Sprite>("Wang"), "王大队长", Color.blue);
        xie = new PersonDisplay(Resources.Load<Sprite>("Xie"), "屑司令", Color.red);
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
