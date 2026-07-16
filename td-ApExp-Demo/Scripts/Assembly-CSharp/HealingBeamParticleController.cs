public class HealingBeamParticleController : BeamParticleController
{
	public override void UpdateParticles()
	{
		base.UpdateParticles();
		if (targetTf == null)
		{
			StopBeam();
			KillAllParticles();
		}
		else
		{
			MoveToTargetWithNoise(noiseFactor);
		}
	}
}
