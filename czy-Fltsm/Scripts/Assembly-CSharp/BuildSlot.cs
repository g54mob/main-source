using System;
using UnityEngine;

[Serializable]
public class BuildSlot
{
	[Range(0f, 1f)]
	public float Threshold;

	public TransformData TransformData;

	public BuildSlot(float threshhold, TransformData data)
	{
		Threshold = threshhold;
		TransformData = data;
	}
}
