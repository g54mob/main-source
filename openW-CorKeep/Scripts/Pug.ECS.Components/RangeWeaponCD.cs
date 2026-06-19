using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

public struct RangeWeaponCD : IComponentData, IQueryTypeParameter
{
	public ObjectID projectileID;

	public ObjectID windupProjectileID;

	public bool spawnRandomProjectile;

	public FixedList64Bytes<ObjectID> randomProjectiles;

	public bool rotateFreely;

	public float spawnOffsetDistance;

	public int extraProjectiles;

	public float spreadAngle;

	public int explosionSize;

	public float recoilForce;

	public bool pierceAtMaxWindup;

	public bool bounceAtMaxWindup;

	public bool mortarRaycastToTarget;

	public float mortarTargetRange;

	public float2 minMaxRandomSpreadDistance;

	public int overrideAnimation;

	public bool scaleMortarTimeWithDistance;

	public float minMortarAirTimePercentage;

	public bool explosionUseWeaponDamage;

	public float2 secondaryMinMaxRandomSpreadDistance;

	public float secondaryDistanceBetweenHits;

	public bool secondaryScaleMortarTimeWithDistance;
}
