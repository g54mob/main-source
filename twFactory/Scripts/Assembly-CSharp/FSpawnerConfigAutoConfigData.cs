using System;
using UnityEngine;

[Serializable]
public class FSpawnerConfigAutoConfigData
{
	[SerializeField]
	private float targetLpS;

	[SerializeField]
	private RandomizableFloat autoConfigMinSpawnTime;

	[SerializeField]
	private RandomizableFloat autoConfigMaxSpawnTime;

	[SerializeField]
	private RandomizableFloat autoConfigSpawnTimeDeviation;

	[SerializeField]
	private int autoConfigMaxOpSDeviation;

	public float TargetLpS => targetLpS;

	public RandomizableFloat AutoConfigMinSpawnTime => autoConfigMinSpawnTime;

	public RandomizableFloat AutoConfigMaxSpawnTime => autoConfigMaxSpawnTime;

	public RandomizableFloat AutoConfigSpawnTimeDeviation => autoConfigSpawnTimeDeviation;

	public int AutoConfigMaxOpSDeviation => autoConfigMaxOpSDeviation;
}
