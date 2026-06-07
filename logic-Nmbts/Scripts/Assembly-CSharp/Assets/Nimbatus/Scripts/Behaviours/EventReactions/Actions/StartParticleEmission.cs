using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class StartParticleEmission : NimbatusAction
	{
		public ParticleSystem ParticleSystem;

		public override void Execute()
		{
			ParticleSystem.EmissionModule emission = ParticleSystem.emission;
			emission.enabled = true;
		}
	}
}
