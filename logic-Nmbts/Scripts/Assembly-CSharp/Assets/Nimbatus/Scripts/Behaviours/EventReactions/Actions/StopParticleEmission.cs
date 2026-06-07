using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class StopParticleEmission : NimbatusAction
	{
		public ParticleSystem ParticleSystem;

		public override void Execute()
		{
			ParticleSystem.EmissionModule emission = ParticleSystem.emission;
			emission.enabled = false;
		}
	}
}
