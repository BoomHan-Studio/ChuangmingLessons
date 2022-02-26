using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class PersonDisplay
{
	public Sprite img;

	public string name;

	public Color textColor;

	public PersonDisplay(Sprite s, string n, Color c)
	{
		img = s;
		name = n;
		textColor = c;
	}
}

[Serializable]
public enum Person
{
	Feng = 0,
	Wang = 1,
	Xie = 2,
}

[Serializable]
public struct Dialoge
{
	public Person personName;

	public string words;

	public Dialoge(Person p, string w)
	{
		personName = p;
		words = w;
	}
}