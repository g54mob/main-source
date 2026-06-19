using UnityEngine;

public class OrbitalTurretProjectile : Projectile
{
	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
			directionTransform.LookAt(directionTransform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Manager.effects.PlayPuff(PuffID.EnergyProjectileImpact, base.transform.position);
	}
}
