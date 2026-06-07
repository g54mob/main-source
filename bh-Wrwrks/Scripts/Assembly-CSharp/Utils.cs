using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class Utils
{
	public static Color GetColor(string hex)
	{
		if (hex.StartsWith("#"))
		{
			hex = hex.Substring(1);
		}
		if (hex.Length != 6)
		{
			return Color.white;
		}
		float r = (float)int.Parse(hex.Substring(0, 2), NumberStyles.HexNumber) / 255f;
		float g = (float)int.Parse(hex.Substring(2, 2), NumberStyles.HexNumber) / 255f;
		float b = (float)int.Parse(hex.Substring(4, 2), NumberStyles.HexNumber) / 255f;
		return new Color(r, g, b);
	}

	public static int RandSign()
	{
		if (!RNG(50f))
		{
			return -1;
		}
		return 1;
	}

	public static float RandSign(float x)
	{
		return (float)(RNG(50f) ? 1 : (-1)) * x;
	}

	public static bool RNG(float percent)
	{
		if (percent == 0f)
		{
			return false;
		}
		percent *= 100f;
		return (float)UnityEngine.Random.Range(0, 10000) <= percent;
	}

	public static T Rand<T>(T a, T b, float chance = 50f)
	{
		if (!RNG(chance))
		{
			return b;
		}
		return a;
	}

	public static T RandElem<T>(List<T> L)
	{
		return L[UnityEngine.Random.Range(0, L.Count)];
	}

	public static KeyValuePair<T, Q> RandElem<T, Q>(Dictionary<T, Q> L)
	{
		T key = RandElem(new List<T>(L.Keys));
		Q value = L[key];
		return new KeyValuePair<T, Q>(key, value);
	}

	public static T RandElem<T>(T[] L)
	{
		return L[UnityEngine.Random.Range(0, L.Length)];
	}

	public static List<T> Shuffle<T>(List<T> l)
	{
		return l.OrderBy((T x) => UnityEngine.Random.value).ToList();
	}

	public static T[] Shuffle<T>(T[] l)
	{
		return l.OrderBy((T x) => UnityEngine.Random.value).ToArray();
	}

	public static Vector3 RandDir()
	{
		float f = UnityEngine.Random.Range(0f, MathF.PI * 2f);
		return new Vector3(Mathf.Cos(f), Mathf.Sin(f));
	}

	public static Vector3 Dir(float radianAng)
	{
		return new Vector3(Mathf.Cos(radianAng), Mathf.Sin(radianAng));
	}

	public static Vector3 DirEuler(float eulerAng)
	{
		return Dir(eulerAng * MathF.PI / 180f);
	}
}
