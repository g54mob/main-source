using UnityEngine;

public class BasicStaffProjectile : Projectile
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
			ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
			Vector3 vector = componentData.GetDirection3() * 0.3f;
			Manager.effects.PlayPuff(PuffID.SmallEnergyExplosion, particleOptions.particleSpawnLocations[0].position + vector);
			directionTransform.LookAt(directionTransform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
			if ((bool)projectile)
			{
				projectile.Play(withChildren: true);
			}
			if ((bool)indirectLightObject)
			{
				indirectLightObject.gameObject.SetActive(value: true);
			}
		}
	}
}
