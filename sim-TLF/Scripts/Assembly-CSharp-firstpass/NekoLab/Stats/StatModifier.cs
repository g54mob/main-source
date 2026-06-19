using System;

namespace NekoLab.Stats
{
	[Serializable]
	public class StatModifier
	{
		public float Value;

		public StatModifierEffect Effect;

		public StatModifier(float value, StatModifierEffect effect)
		{
			Value = value;
			Effect = effect;
		}
	}
}
