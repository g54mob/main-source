using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Easing
{
	public enum BlendShape
	{
		Linear = 0,
		Smoothstep = 1,
		EaseIn = 2,
		EaseOut = 3,
		EaseInOut = 4
	}

	public BlendShape blend;

	public void PrepareMaterial(Material mat, string key, List<string> keywords)
	{
		switch (blend)
		{
		case BlendShape.Smoothstep:
			keywords.Add(key + "SMOOTHSTEP");
			break;
		case BlendShape.EaseIn:
			keywords.Add(key + "EASEIN");
			break;
		case BlendShape.EaseOut:
			keywords.Add(key + "EASEOUT");
			break;
		case BlendShape.EaseInOut:
			keywords.Add(key + "EASEINOUT");
			break;
		}
	}
}
