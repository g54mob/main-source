using System;
using UnityEngine;

namespace Gh
{
	public class SpecialScreenEffectVisual : MonoBehaviour
	{
		[Serializable]
		public enum SpecialEffects
		{
			Confetti = 0,
			Fireworks = 1,
			ThumbsUp = 2,
			FireworksHalfling = 3,
			RocketFuel = 4,
			RocketTrail = 5
		}

		public SpecialEffects type;
	}
}
