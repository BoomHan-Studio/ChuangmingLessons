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
            new Dialoge(Person.Feng, "����˾���ô����ô��Ҳϲ������Ц�����ǺǺǺ�~��"),
            new Dialoge(Person.Xie, "��Ҫ��û�Ŷ���"),
            new Dialoge(Person.Xie, "�Ͱ����뼦�����ˡ�"),
            new Dialoge(Person.Feng, "˾��⼦�������ŷֵ����Ӧ���� ͬ־���Ⱥȡ�����һ������Ա����ô�ܺ��⼦���أ����ݣ�"),
            new Dialoge(Person.Xie, "�㿴��æ��æ��ģ������࣬���뼦����ʲôѽ����Ҫ���治�ȣ�˵�������¶��ˡ�"),
            new Dialoge(Person.Feng, "�⣬�ⲻ�԰ɣ������˭��˭Ҫ���ݺ��ң�����ӳ�����Ҫ�ݺ����ǰɣ��ǣ��У��Һȣ��ȣ��Һȣ��Һȣ�"),
            new Dialoge(Person.Feng, "��ѽ�������������һ��ù�Ŷ�~��"),
            new Dialoge(Person.Feng, "(�ư�)���̲�����ζ�� ���Ǻü��ˡ�˾����� û�°ɣ�"),
            new Dialoge(Person.Feng, "�Ȱɣ����Ⱥ�ѽ��"),
            new Dialoge(Person.Feng, "˾��݇N����ͷ������Ҫ�ǲ���ͷ�ȣ�����������ô�ܣ��ܸҺ��أ����ݣ�"),
            new Dialoge(Person.Feng, "���������Ҹ�ʲô���ȣ���ѽ������Ⱥȣ����Ⱥ�ѽ��"),
            new Dialoge(Person.Feng, "�������̵ģ�Ϊʲô���ȣ��ȣ��ȣ�"),
            new Dialoge(Person.Feng, "���ȣ������ǰɣ����ȣ������Ҿ�ը���㣡"),
            new Dialoge(Person.Feng, "�����Һȣ���pass�ǰɣ��Ҹ����㣬���ȣ�����Ҳ������ţ�"),
            new Dialoge(Person.Feng, "��Ȼ��Ҷ�֪���ˣ���Ϸ�ҾͲ����ˣ��Ҿ��Ǵ��������ģ������ͳ���ʹ��ձ�˫�ϸ߼��ع������ţ�"),
            new Dialoge(Person.Feng, "�� ɽ �ף�"),
            new Dialoge(Person.Feng, "��Т�ȣ����ҷŵġ��⼦������Ķ�����Ҳ���ˣ������⼦���Һ��ˣ��ҿ϶����������ǲ��ȣ�Ҳ������ţ�����"),
            new Dialoge(Person.Feng, "��Ұ��������ʱ� �£��ң��ҵ����� ���������"),
            new Dialoge(Person.Feng, "������������������������������"),
            new Dialoge(Person.Feng, "......"),
            new Dialoge(Person.Feng, "���̵Σ������������ǰɣ�ֱ�����ɣ���"),
            new Dialoge(Person.Feng, "......"),
            new Dialoge(Person.Feng, "��..."),
        };
	}
    [SerializeField]
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        feng = new PersonDisplay(Resources.Load<Sprite>("Feng"), "�Ϸ�", Color.green);
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
