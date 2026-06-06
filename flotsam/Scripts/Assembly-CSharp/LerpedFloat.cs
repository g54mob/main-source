using System;
using UnityEngine;

[Serializable]
public struct LerpedFloat
{
	public float From;

	public float To;

	public float Lerp(float value)
	{
		return Mathf.Lerp(From, To, value);
	}
}
