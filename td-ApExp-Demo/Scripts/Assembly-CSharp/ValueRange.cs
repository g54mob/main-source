using System;
using UnityEngine;

[Serializable]
public struct ValueRange
{
	public float MinValue;

	public float MaxValue;

	public float GetValue()
	{
		return Mathf.Round(UnityEngine.Random.Range(MinValue, MaxValue) * 100f) / 100f;
	}
}
