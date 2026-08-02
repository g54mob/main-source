using System;
using UnityEngine;

[Serializable]
public class TrainFuelData
{
	public CollectableItemData item;

	[Range(0.01f, 0.2f)]
	public float efficiency = 0.1f;
}
