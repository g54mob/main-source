using UnityEngine;

public class ShockWaveProjectile : Projectile
{
	public ParticleSystem SmokeTrail1;

	public ParticleSystem SmokeTrail2;

	public ParticleSystem hit;

	public ParticleSystem trail;

	public ManagedLight fireLight;

	public GameObject fireball;

	public override void OnOccupied()
	{
		base.OnOccupied();
		bool flag = currentHealth <= 0;
		directionTransform.gameObject.SetActive(!flag);
		if (!flag)
		{
			Vector3 vector = EntityMonoBehaviour.ToRenderFromWorld(spawnWorldPosition);
			Vector3 vector2 = EntityUtility.GetComponentData<ProjectileCD>(base.entity, base.world).GetDirection3() * 0.5f;
			Vector3 position = vector + directionTransform.localPosition + vector2;
			Manager.effects.PlayPuff(PuffID.SmallAncientEnergy, position, 8);
			if ((bool)SmokeTrail1)
			{
				SmokeTrail1.Play(withChildren: true);
			}
			if ((bool)SmokeTrail2)
			{
				SmokeTrail2.Play(withChildren: true);
			}
			if ((bool)trail)
			{
				trail.Play(withChildren: true);
			}
			fireLight.gameObject.SetActive(value: true);
			fireball.SetActive(value: true);
		}
	}

	protected override void OnDeath()
	{
		base.OnDeath();
		if ((bool)hit)
		{
			if ((bool)SmokeTrail1)
			{
				SmokeTrail1.Stop();
			}
			if ((bool)SmokeTrail2)
			{
				SmokeTrail2.Stop();
			}
			if ((bool)trail)
			{
				trail.Stop();
			}
			hit.Play();
		}
		fireball.SetActive(value: false);
		fireLight.gameObject.SetActive(value: false);
		SpawnFadeOutLight(fireLight.lightToOptimize);
	}
}
