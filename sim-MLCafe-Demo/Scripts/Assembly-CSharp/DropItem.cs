using System;
using UnityEngine;

[Serializable]
public class DropItem
{
	public int itemId;

	public int minAmount;

	public int maxAmount;

	[Range(0f, 100f)]
	public float dropChance;
}
