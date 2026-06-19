using System;
using UnityEngine;

[Serializable]
public class RewiredPS5TriggerEffectSlopeFeedbackProxy
{
	[field: SerializeField]
	public byte StartPosition { get; private set; }

	[field: SerializeField]
	public byte EndPosition { get; private set; }

	[field: SerializeField]
	public byte StartStrength { get; private set; }

	[field: SerializeField]
	public byte EndStrength { get; private set; }
}
