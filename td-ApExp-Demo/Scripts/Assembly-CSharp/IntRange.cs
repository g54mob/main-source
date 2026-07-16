using System;
using UnityEngine;

[Serializable]
public struct IntRange
{
	public int MinValue;

	public int MaxValue;

	public int GetValue()
	{
		return UnityEngine.Random.Range(MinValue, MaxValue + 1);
	}
}
