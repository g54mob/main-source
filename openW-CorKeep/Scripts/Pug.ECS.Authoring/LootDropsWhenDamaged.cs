using System;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
public struct LootDropsWhenDamaged
{
	[MinValue(0f)]
	[MaxValue(1f)]
	public float healthPercentageDamageToDeal;

	[MinValue(0f)]
	[MaxValue(1f)]
	public float minHealthPercentageToDropLoot;

	[ReadOnly]
	public int damageToDealToDropLoot;

	[ReadOnly]
	public int minHealthToDropLoot;

	public ObjectID dropsLoot;

	public bool instantiateEntity;

	public float2 minSpawnOffset;

	public float2 maxSpawnOffset;

	[Header("The max limit to drop in the nearby area is dependent\non nearby entities tracker being able to track them. 0 Means no limit.")]
	public int maxLimitToDropInNearbyArea;
}
