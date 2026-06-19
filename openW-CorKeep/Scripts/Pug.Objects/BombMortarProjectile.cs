using UnityEngine;

public class BombMortarProjectile : FallingRockMortarProjectile
{
	private int paramID = Animator.StringToHash("objectID");

	protected override void Explode()
	{
		base.OnDeath();
		if ((bool)trailParticles)
		{
			trailParticles.Stop();
		}
	}

	public void AE_Impact()
	{
		if ((bool)trailParticles)
		{
			trailParticles.Stop();
		}
		Manager.effects.PlayPuff(PuffID.DirtImpactSmall, base.transform.position);
		AudioManager.Sfx(SfxTableID.fallingRockImpact, base.RenderPosition, 0.5f);
	}
}
