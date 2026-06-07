using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class PlayParticleSystem : NimbatusAction
	{
		public ParticleSystem ParticleSystem;

		public override void Execute()
		{
			ParticleSystem.Play();
		}
	}
}
