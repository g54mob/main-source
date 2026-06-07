using System;
using I2.Loc;

namespace PajamaLlama.Flotsam.Morale
{
	[Serializable]
	public struct MoraleEffectModifierThreshold
	{
		public float Threshold;

		public int Modifier;

		public LocalizedString Description;
	}
}
