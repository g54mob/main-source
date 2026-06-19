using UnityEngine;

public class RazorFlakeShardProjectile : Projectile
{
	public ParticleSystem projectileTrail;

	public override void OnOccupied()
	{
		base.OnOccupied();
		EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
		ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
		_ = (Vector3)(componentData.GetDirection3() * 0.5f);
		projectileTrail.Play(withChildren: true);
		projectileTrail.transform.LookAt(projectileTrail.transform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		Vector3 position = base.transform.position;
		Manager.effects.WithTileColliders(position);
		if ((bool)projectileTrail)
		{
			projectileTrail.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
		}
	}
}
