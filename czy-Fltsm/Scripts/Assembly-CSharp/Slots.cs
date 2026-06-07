using System;
using UnityEngine;

[Serializable]
public abstract class Slots
{
	public Transform Parent;

	public TransformData[] TransformData;

	public int Count => TransformData.Length;
}
