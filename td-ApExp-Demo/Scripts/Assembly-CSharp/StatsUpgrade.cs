using System;
using UnityEngine;

[Serializable]
public class StatsUpgrade
{
	[SerializeField]
	public Stats StatsObjectToUpgrade;

	[SerializeField]
	[NonReorderable]
	public StatUpgrade StatUpgrade;

	[field: SerializeField]
	public string Description { get; private set; }
}
