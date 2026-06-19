using Unity.Mathematics;
using Unity.Physics.Authoring;
using UnityEngine;

public class BeamWeaponAuthoring : MonoBehaviour
{
	[Header("General")]
	public float attackDistance;

	public PhysicsCategoryTags collideFilterPVPOn;

	public PhysicsCategoryTags attackFilterPVPOn;

	public bool isStickyBeam;

	public bool onlyDamageAtEndOfBeam;

	public bool expandWhenHeld;

	public float expandTimeSeconds;

	public float expandMinDistance;

	public ConditionID manaCostCondition;

	public ConditionID damageIncreaseCondition;

	[Header("Visual")]
	public string overrideAnimation;

	public string secondaryOverrideAnimation;

	public bool useRangedLoopAnimation;

	public bool beamVisualFromCenter;

	[Header("Secondary")]
	public ObjectID secondaryProjectileVariationID;

	public int extraProjectiles;

	public int spreadAngle;

	public float3 spawnOffsetDistance;
}
