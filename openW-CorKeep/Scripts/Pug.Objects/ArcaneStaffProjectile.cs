using Unity.Mathematics;
using UnityEngine;

public class ArcaneStaffProjectile : Projectile
{
	public ParticleSystem projectile;

	public GameObject indirectLightObject;

	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			float3 direction = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3();
			Vector3 vector = direction * 0.5f;
			Manager.effects.PlayPuff(PuffID.ImpactArcaneStaffProjectile, particleOptions.particleSpawnLocations[0].position + vector);
			directionTransform.LookAt(directionTransform.position + (Vector3)direction, Vector3.up);
			projectile.Play(withChildren: true);
			if ((bool)indirectLightObject)
			{
				indirectLightObject.gameObject.SetActive(value: true);
			}
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		if ((bool)projectile)
		{
			projectile.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
		if ((bool)indirectLightObject)
		{
			indirectLightObject.gameObject.SetActive(value: false);
		}
	}
}
