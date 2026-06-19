using UnityEngine;

public class EnergyProjectile : Projectile
{
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
		}
	}
}
