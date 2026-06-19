using Unity.Entities;
using Unity.Mathematics;

public struct CritterDamageFromPlacingCD : IComponentData, IQueryTypeParameter
{
	public bool triggered;

	public float3 pos;

	public float3 size;

	public bool canDamageFlyingCritter;

	public bool killEvenIfSquashBugsIsOff;
}
