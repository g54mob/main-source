using UnityEngine;

public class PoisonSlimeBossMortarProjectile : EntityMonoBehaviour
{
	public ParticleSystem smokeTrail;

	public ParticleSystem slimeTrail;

	public ParticleSystem hit;

	public ManagedLight pointLight;

	public GameObject mortarLandingEffect;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		mortarLandingEffect.SetActive(lastAnim == -225098472 || lastAnim == 584621764);
		if (currentHealth > 0)
		{
			if ((bool)smokeTrail)
			{
				smokeTrail.Play(withChildren: true);
			}
			if ((bool)slimeTrail)
			{
				slimeTrail.Play(withChildren: true);
			}
			pointLight.gameObject.SetActive(value: true);
		}
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
		if ((bool)hit)
		{
			if ((bool)smokeTrail)
			{
				smokeTrail.Stop();
			}
			if ((bool)slimeTrail)
			{
				slimeTrail.Stop();
			}
			hit.Play();
		}
		pointLight.gameObject.SetActive(value: false);
		mortarLandingEffect.SetActive(value: false);
		SpawnFadeOutLight(pointLight.lightToOptimize);
		Manager.effects.PlayTempSprite(SpriteTempEffectID.PoisonSplat, base.transform.position + new Vector3(0f, 0.3125f, -0.3125f));
		Manager.effects.PlayPuff(PuffID.PoisonSlimeExplosion, base.transform.position + new Vector3(0f, 1f, -1f), 20);
	}

	public void AE_PlayParticles()
	{
		pointLight.gameObject.SetActive(value: true);
		smokeTrail.Play(withChildren: true);
		slimeTrail.Play(withChildren: true);
	}

	public void AE_StopParticles()
	{
		pointLight.gameObject.SetActive(value: false);
		smokeTrail.Stop(withChildren: true);
		slimeTrail.Stop(withChildren: true);
	}

	protected override void OnDeath()
	{
		AudioManager.SfxFollowTransform(soundOptions.deathSfx.value, base.transform);
	}
}
