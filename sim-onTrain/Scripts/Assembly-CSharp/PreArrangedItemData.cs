using System;
using UnityEngine;

[Serializable]
public struct PreArrangedItemData
{
	public CollectableItemData item;

	public int count;

	[Tooltip("Hangi slota yerlestirilecek (1-based)")]
	public int slotID;
}
