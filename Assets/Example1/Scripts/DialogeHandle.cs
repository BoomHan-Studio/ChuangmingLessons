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
            new Dialoge(Person.Feng, "哎这，这菜都齐了怎么还不吃呀？"),
            new Dialoge(Person.Wang, "老冯啊，大伙儿都不敢吃。有人说，说是有人在菜里下了毒！"),
            new Dialoge(Person.Feng, "害羞羞，王大队长，你这人就喜欢开玩笑。快趁热吃吧，我不打扰，我走了哈！"),
            new Dialoge(Person.Xie, "你不能走。"),
            new Dialoge(Person.Feng, "啊哈哈哈，屑司令，你不会相信王大队长，胡说八道吧？"),
            new Dialoge(Person.Xie, "我信。我非常相信！"),
            new Dialoge(Person.Feng, "哈，司令，怎么，怎么你也喜欢开玩笑啊？呵呵呵呵~！"),
            new Dialoge(Person.Xie, "你要是没放毒，"),
            new Dialoge(Person.Xie, "就把这碗鸡汤喝了。"),
            new Dialoge(Person.Feng, "司令，这鸡汤啊，逝分的斟贵，应该让 同志们先喝。我这一个催逝员，怎么能喝这鸡汤呢！嘿咻！"),
            new Dialoge(Person.Xie, "你看你忙里忙外的，多辛苦，喝碗鸡汤算什么呀？你要是真不喝，说明你真下毒了。"),
            new Dialoge(Person.Feng, "这，这不对吧？这今天谁，谁要，陷害我？王大队长，你要陷害我是吧！呵，行，我喝，喝！我喝，我喝！"),
            new Dialoge(Person.Feng, "哎呀，这喝汤，多是一件霉逝儿~！"),
            new Dialoge(Person.Feng, "(咂吧)不咸不淡，味道 真是好极了。司令，看看 没事吧？"),
            new Dialoge(Person.Feng, "喝吧，趁热喝呀！"),
            new Dialoge(Person.Feng, "司令，妮嘚逮个头儿，你要是不带头喝，塔，塔们怎么能，能敢喝呢，嘿咻？"),
            new Dialoge(Person.Feng, "都，都看我干什么？喝，喝呀！快趁热喝，趁热喝呀！"),
            new Dialoge(Person.Feng, "哎他奶奶的，为什么不喝！喝！喝！"),
            new Dialoge(Person.Feng, "不喝，不喝是吧，不喝，不喝我就炸死你！"),
            new Dialoge(Person.Feng, "都不敢喝，都pass是吧！我告诉你，不喝，不喝也百想活着！"),
            new Dialoge(Person.Feng, "既然大家都知道了，这戏我就不演了！我就是大名鼎鼎的，重庆军统，和大日本双料高级特工！代号："),
            new Dialoge(Person.Feng, "穿 山 甲！"),
            new Dialoge(Person.Feng, "杜孝先，是我放的。这鸡汤里面的毒，我也放了！不过这鸡汤我喝了，我肯定得死；你们不喝，也百想活着！！！"),
            new Dialoge(Person.Feng, "龟野先生，天皇陛 下！我，我滴任务 完成辣！！"),
            new Dialoge(Person.Feng, "啊哈哈哈哈哈哈，啊哈哈哈哈哈！"),
            new Dialoge(Person.Feng, "......"),
            new Dialoge(Person.Feng, "奶奶滴，给我玩阴滴是吧！直接来吧！！"),
            new Dialoge(Person.Feng, "......"),
            new Dialoge(Person.Feng, "噗..."),
        };
	}
    [SerializeField]
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        feng = new PersonDisplay(Resources.Load<Sprite>("Feng"), "老冯", Color.green);
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
        if (Input.GetKeyUp(KeyCode.Space))
		{
            index++;
            
		}
        if (index >= dialoges.Length) return;
        icon.sprite = toRef[dialoges[index].personName].img;
        speakerText.text = toRef[dialoges[index].personName].name + ":";
        speakerText.color = toRef[dialoges[index].personName].textColor;
        wordsText.text = dialoges[index].words;
        wordsText.color = toRef[dialoges[index].personName].textColor;
    }
}
