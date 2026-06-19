using System;
using UnityEngine;

[Serializable]
public class RewiredPS5TriggerEffectWeaponProxy
{
	[field: SerializeField]
	public byte StartPosition { get; private set; }

	[field: SerializeField]
	public byte EndPosition { get; private set; }

	[field: SerializeField]
	public byte Strength { get; private set; }
}
