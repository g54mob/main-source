using UnityEngine;

public class HydraBossLavaMortarProjectile : EntityMonoBehaviour
{
	public ParticleSystem launch;

	public ParticleSystem trail;

	public ManagedLight pointLight;

	public GameObject mortarLandingEffect;

	public Transform srPivot;

	public override void OnOccupied()
	{
		base.OnOccupied();
		mortarLandingEffect.SetActive(lastAnim == -225098472 || lastAnim == 584621764);
		if (currentHealth > 0)
		{
			launch.Play();
			if ((bool)trail)
			{
				trail.Play(withChildren: true);
			}
			pointLight.gameObject.SetActive(value: true);
		}
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		_ = base.entityExist;
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		if (animID == 1416834189)
		{
			Explode();
		}
		if (animID == -225098472 || animID == 584621764)
		{
			mortarLandingEffect.SetActive(value: true);
		}
		base.HandleAnimationTrigger(animID);
	}

	protected void Explode()
	{
		base.OnDeath();
		if ((bool)trail)
		{
			trail.Stop();
		}
		Manager.effects.PlayPuff(PuffID.LavaMortarImpact, base.transform.position);
		pointLight.gameObject.SetActive(value: false);
		mortarLandingEffect.SetActive(value: false);
		SpawnFadeOutLight(pointLight.lightToOptimize);
	}

	protected override void OnDeath()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
	}
}
