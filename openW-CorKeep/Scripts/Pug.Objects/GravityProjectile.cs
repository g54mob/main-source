using UnityEngine;

public class GravityProjectile : Projectile
{
	public ParticleSystem projectile;

	public ParticleSystem fireballSmoke;

	public ParticleSystem fireballFireTrail;

	public ParticleSystem hit;

	public ManagedLight fireLight;

	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			ProjectileCD componentData = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world);
			Vector3 vector2 = componentData.GetDirection3() * 0.3f;
			_ = vector + directionTransform.localPosition + vector2;
			Manager.effects.PlayPuff(PuffID.SmallEnergyExplosion, vector + directionTransform.localPosition + vector2);
			directionTransform.LookAt(directionTransform.position + (Vector3)componentData.GetDirection3(), Vector3.up);
			projectile.Play(withChildren: true);
			if ((bool)fireballSmoke)
			{
				fireballSmoke.Play(withChildren: true);
			}
			if ((bool)fireballFireTrail)
			{
				fireballFireTrail.Play(withChildren: true);
			}
			fireLight.gameObject.SetActive(value: true);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		if ((bool)projectile && (bool)hit)
		{
			projectile.Stop(withChildren: true, ParticleSystemStopBehavior.StopEmittingAndClear);
			if ((bool)fireballSmoke)
			{
				fireballSmoke.Stop();
			}
			if ((bool)fireballFireTrail)
			{
				fireballFireTrail.Stop();
			}
			hit.Play();
		}
		fireLight.gameObject.SetActive(value: false);
		SpawnFadeOutLight(fireLight.lightToOptimize);
	}
}
