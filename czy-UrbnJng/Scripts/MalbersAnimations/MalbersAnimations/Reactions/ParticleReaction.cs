using System;
using UnityEngine;

namespace MalbersAnimations.Reactions
{
	[Serializable]
	[AddTypeMenu("Unity/Particle System", 0)]
	public class ParticleReaction : Reaction
	{
		public Color color = Color.white;

		public override Type ReactionType => typeof(ParticleSystem);

		protected override bool _TryReact(Component component)
		{
			ParticleSystem.MainModule main = (component as ParticleSystem).main;
			main.startColor = new ParticleSystem.MinMaxGradient(color);
			return true;
		}
	}
}
