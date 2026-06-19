using UnityEngine;

public class BlunderBombExplosion : Explosion
{
	public ParticleSystem explodeParticles;

	protected override void PlayEffectForExplosion(PuffID puffID)
	{
		explodeParticles.Play(withChildren: true);
	}
}
