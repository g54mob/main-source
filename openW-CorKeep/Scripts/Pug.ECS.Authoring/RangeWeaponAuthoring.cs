using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

[DisallowMultipleComponent]
public class RangeWeaponAuthoring : MonoBehaviour
{
	[Header("General")]
	public ObjectID projectileID;

	public bool rotateFreely;

	public float recoilForce;

	public string overrideAnimation;

	[Header("Projectile")]
	public ObjectID secondaryProjectileVariationID;

	public bool explosionUseWeaponDamage;

	public bool spawnRandomProjectile;

	public List<ObjectID> randomProjectiles;

	public float spawnOffsetDistance;

	public int extraProjectiles;

	[Tooltip("Only relevant if extraProjectiles > 0")]
	public float spreadAngle;

	[FormerlySerializedAs("explosionVariation")]
	[Tooltip("0=none, '1'=small, '2'=big, DO NOT TYPE >2!")]
	public int explosionSize;

	[Tooltip("Only relevant if entity also has WindupCD component")]
	public bool pierceAtMaxWindup;

	[Tooltip("Only relevant if entity also has WindupCD component")]
	public bool bounceAtMaxWindup;

	[Header("Mortar")]
	public bool mortarRaycastToTarget;

	public float mortarTargetRange;

	public float2 minMaxRandomSpreadDistance;

	public float2 secondaryMinMaxRandomSpreadDistance;

	public bool scaleMortarAirTimeWithDistance;

	public bool secondaryScaleMortarAirTimeWithDistance;

	public float minMortarAirTimePercentage;

	public float secondaryDistanceBetweenHits;
}
