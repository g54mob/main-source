using System;
using UnityEngine;

[Serializable]
public class RewiredPS5TriggerEffectFeedbackProxy
{
	[field: SerializeField]
	public byte Position { get; private set; }

	[field: SerializeField]
	public byte Strength { get; private set; }
}
