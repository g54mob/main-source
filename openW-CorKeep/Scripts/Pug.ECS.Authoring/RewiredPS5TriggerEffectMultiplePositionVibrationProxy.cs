using System;
using UnityEngine;

[Serializable]
public class RewiredPS5TriggerEffectMultiplePositionVibrationProxy
{
	[field: SerializeField]
	public byte Frequency { get; private set; }

	[field: SerializeField]
	public RewiredPS5TriggerEffectPositionValueSetProxy Amplitude { get; private set; }
}
