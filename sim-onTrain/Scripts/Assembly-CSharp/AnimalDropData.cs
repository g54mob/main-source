using System;
using UnityEngine;

[Serializable]
public class AnimalDropData
{
	public CollectableItemData itemData;

	public int itemCount = 1;

	[Range(1f, 100f)]
	public float dropChance = 50f;
}
