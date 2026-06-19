using Unity.Entities;
using Unity.Mathematics;

[InternalBufferCapacity(1)]
public struct DealDamageToEntityBuffer : IBufferElementData
{
	public enum AttackType
	{
		RayCast = 0,
		Melee = 1,
		CatchCritters = 2,
		CritterDamage = 3,
		Shovel = 4,
		Vehicle = 5,
		ReverseDirectDamage = 6
	}

	public AttackType attackType;

	public Entity entity;

	public Entity hitEntityPart;

	public float3 hitPosition;

	public float3 optionalFromPosition;

	public float3 wasHitWhenAtPosition;

	public int damage;

	public bool isRanged;

	public bool isMagic;

	public bool isThorns;

	public bool shoudShowHitFeedbackOnHitEntityPart;

	public float3 critterDamageSize;

	public bool critterDamageCanDamageFlying;

	public bool critterDamageKillEvenIfSquashBugsIsOff;
}
