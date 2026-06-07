using System;
using UnityEngine;

[Serializable]
public class Resource3
{
	public long capRes3;

	public long curRes3;

	public long idleRes3;

	public float res3BarSpeed;

	public long res3PerBar;

	public long res3Gained;

	public float res3Power;

	public float res3BarProgress;

	public string res3Name;

	public float res3R;

	public float res3G;

	public float res3B;

	public bool res3On;

	public Resource3()
	{
		capRes3 = 0L;
		curRes3 = 0L;
		idleRes3 = 0L;
		res3BarSpeed = 0f;
		res3PerBar = 0L;
		res3Gained = 0L;
		res3Power = 1f;
		res3BarProgress = 0f;
		res3Name = "Butts";
		res3R = 0.8f;
		res3G = 0.25f;
		res3B = 0f;
		res3On = false;
	}

	public void reset()
	{
		idleRes3 = 0L;
		curRes3 = 0L;
		res3BarProgress = 0f;
	}

	public void updateRes3()
	{
	}

	public string colourHexString()
	{
		Color32 color = new Color(res3R, res3G, res3B);
		string text = color.r.ToString("X2");
		string text2 = color.g.ToString("X2");
		string text3 = color.b.ToString("X2");
		return text + text2 + text3;
	}

	public string colourHexStringAlpha()
	{
		return colourHexString() + "FF";
	}

	public string colourHexStringTest()
	{
		Color32 color = new Color(0.8f, 0.25f, 0f);
		string text = color.r.ToString("X2");
		string text2 = color.g.ToString("X2");
		string text3 = color.b.ToString("X2");
		Debug.Log(text + text2 + text3 + "FF");
		return text + text2 + text3 + "FF";
	}
}
