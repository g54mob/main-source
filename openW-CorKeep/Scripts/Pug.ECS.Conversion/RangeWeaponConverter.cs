using Pug.Conversion;
using Unity.Collections;
using UnityEngine;

public class RangeWeaponConverter : SingleAuthoringComponentConverter<RangeWeaponAuthoring>
{
	protected override void Convert(RangeWeaponAuthoring authoring)
	{
		FixedList64Bytes<ObjectID> randomProjectiles = default(FixedList64Bytes<ObjectID>);
		foreach (ObjectID randomProjectile in authoring.randomProjectiles)
		{
			randomProjectiles.Add(randomProjectile);
		}
		if (authoring.explosionSize > 0 && authoring.secondaryProjectileVariationID == ObjectID.None)
		{
			Debug.LogError("Explosion size is set for " + authoring.name + " but no explosive projectile variation ID is set.", authoring);
		}
		AddComponentData(new RangeWeaponCD
		{
			projectileID = authoring.projectileID,
			windupProjectileID = authoring.secondaryProjectileVariationID,
			spawnRandomProjectile = authoring.spawnRandomProjectile,
			randomProjectiles = randomProjectiles,
			spawnOffsetDistance = authoring.spawnOffsetDistance,
			extraProjectiles = authoring.extraProjectiles,
			spreadAngle = authoring.spreadAngle,
			explosionSize = authoring.explosionSize,
			recoilForce = authoring.recoilForce,
			pierceAtMaxWindup = authoring.pierceAtMaxWindup,
			bounceAtMaxWindup = authoring.bounceAtMaxWindup,
			rotateFreely = authoring.rotateFreely,
			mortarRaycastToTarget = authoring.mortarRaycastToTarget,
			mortarTargetRange = authoring.mortarTargetRange,
			minMaxRandomSpreadDistance = authoring.minMaxRandomSpreadDistance,
			overrideAnimation = ((!string.IsNullOrEmpty(authoring.overrideAnimation)) ? Animator.StringToHash(authoring.overrideAnimation) : 0),
			scaleMortarTimeWithDistance = authoring.scaleMortarAirTimeWithDistance,
			secondaryScaleMortarTimeWithDistance = authoring.secondaryScaleMortarAirTimeWithDistance,
			minMortarAirTimePercentage = authoring.minMortarAirTimePercentage,
			explosionUseWeaponDamage = authoring.explosionUseWeaponDamage,
			secondaryMinMaxRandomSpreadDistance = authoring.secondaryMinMaxRandomSpreadDistance,
			secondaryDistanceBetweenHits = authoring.secondaryDistanceBetweenHits
		});
	}
}
