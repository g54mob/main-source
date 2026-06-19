using Unity.Entities;
using Unity.Mathematics;

public struct BeamWeaponCD : IComponentData, IQueryTypeParameter
{
	public float attackDistance;

	public uint collideFilterPvPOn;

	public uint collideFilterPvPOff;

	public uint attackFilterPvPOn;

	public uint attackFilterPvPOff;

	public bool isStickyBeam;

	public bool onlyDamageAtEndOfBeam;

	public bool expandWhenHeld;

	public float expandTimeSeconds;

	public float expandMinDistance;

	public int overrideAnimation;

	public int secondaryOverrideAnimation;

	public bool useRangedLoopAnimation;

	public ObjectID windupProjectileID;

	public int spreadAngle;

	public float3 spawnOffsetDistance;

	public int extraProjectiles;

	public bool beamVisualFromCenter;
}
