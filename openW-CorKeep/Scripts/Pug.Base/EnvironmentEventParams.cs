using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public struct EnvironmentEventParams
{
	public EnvironmentEventType eventType;

	public List<Biome> biomes;

	public float minDistanceFromCore;

	public int maxAmountOfNearbyObjects;

	public int minTotalTilesFulfillingRequirements;

	public List<EnvironmentEventTilesRequirement> tileRequirements;

	public bool ignoreGlobalEventCooldown;

	public bool overrideEventSpecificCooldown;

	[ShowIf("overrideEventSpecificCooldown")]
	public Vector2 minMaxEventSpecificCooldownSeconds;

	public bool allowSpawningNearBosses;
}
