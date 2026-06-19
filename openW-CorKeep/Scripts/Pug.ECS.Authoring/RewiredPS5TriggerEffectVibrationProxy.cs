using System;
using UnityEngine;

[Serializable]
public class RewiredPS5TriggerEffectVibrationProxy
{
	[field: SerializeField]
	public byte Position { get; private set; }

	[field: SerializeField]
	public byte Amplitude { get; private set; }

	[field: SerializeField]
	public byte Frequency { get; private set; }
}
