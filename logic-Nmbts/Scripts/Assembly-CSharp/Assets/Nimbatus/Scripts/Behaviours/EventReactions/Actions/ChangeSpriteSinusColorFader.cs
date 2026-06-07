using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Animations;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ChangeSpriteSinusColorFader : NimbatusAction
	{
		public List<SpriteSinusColorFader> ColorFader = new List<SpriteSinusColorFader>();

		public Color ColorA = Color.white;

		public Color ColorB = Color.white;

		public float Frequency;

		public override void Execute()
		{
			foreach (SpriteSinusColorFader item in ColorFader)
			{
				item.colorA = ColorA;
				item.colorB = ColorB;
				item.frequency = Frequency;
			}
		}
	}
}
