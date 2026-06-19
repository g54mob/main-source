using System;
using UnityEngine;

[Serializable]
public class ColorChoice
{
	public string name = "";

	public Color color = Color.white;

	public ColorChoice(string name, Color color)
	{
		this.name = name;
		this.color = color;
	}
}
