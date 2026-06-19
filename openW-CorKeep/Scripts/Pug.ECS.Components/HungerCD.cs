using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HungerCD : IComponentData, IQueryTypeParameter
{
	public const int MAX_HUNGER = 100;

	public const int START_HUNGER_AFTER_DEATH = 70;

	public const int DISTANCE_TO_MOVE_BETWEEN_HUNGER_TICKS = 20;

	public const int DISTANCE_TO_MOVE_BETWEEN_HUNGER_TICKS_CASUAL_CHARACTER = 40;

	public const int HUNGER_CONSUMED_PER_TICK = 1;

	[GhostField]
	public int hunger;

	[GhostField]
	public float3 previousPosition;

	[GhostField]
	public float accumulatedMovement;

	[GhostField]
	public bool canConsumeHunger;

	[GhostField]
	public float standingStillTimer;

	[GhostField]
	public float consistentRunningTimer;

	[GhostField]
	public float loseConsistentRunningTimer;

	[GhostField]
	public float damageFromRunningTimer;

	[GhostField]
	public float loseDamageFromRunningStreakTimer;
}
