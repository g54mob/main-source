using UnityEngine;

public class FallingRockMortarProjectile : EntityMonoBehaviour
{
	public ParticleSystem trailParticles;

	protected override bool hideDirectlyOnDeath => false;

	public override void OnOccupied()
	{
		base.OnOccupied();
		if (currentHealth > 0 && (bool)trailParticles)
		{
			trailParticles.Play(withChildren: true);
		}
	}

	protected override void HandleAnimationTrigger(int animID)
	{
		base.HandleAnimationTrigger(animID);
		if (animID == 1416834189)
		{
			Explode();
		}
	}

	protected virtual void Explode()
	{
		base.OnDeath();
		if ((bool)trailParticles)
		{
			trailParticles.Stop();
		}
		Manager.effects.PlayPuff(PuffID.DirtImpact, base.transform.position);
	}

	public void AE_PlayParticles()
	{
		trailParticles.Play(withChildren: true);
	}

	public void AE_StopParticles()
	{
		trailParticles.Stop(withChildren: true);
	}
}
