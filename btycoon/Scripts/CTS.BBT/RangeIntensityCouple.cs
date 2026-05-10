using System;
using UnityEngine;

[Serializable]
public struct RangeIntensityCouple
{
	[field: SerializeField]
	public string Name { get; private set; }

	[field: SerializeField]
	[field: Range(0f, 25f)]
	public float Range { get; private set; }

	[field: SerializeField]
	[field: Range(0f, 25f)]
	public float Intensity { get; private set; }
}
