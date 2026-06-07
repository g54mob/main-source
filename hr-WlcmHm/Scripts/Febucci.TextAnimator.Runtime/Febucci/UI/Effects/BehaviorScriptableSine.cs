using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI.Effects
{
	public abstract class BehaviorScriptableSine : BehaviorScriptableBase
	{
		public float baseAmplitude = 1f;

		public float baseFrequency = 1f;

		[Range(0f, 1f)]
		public float baseWaveSize = 0.2f;

		protected float amplitude;

		protected float frequency;

		protected float waveSize;

		public override void ResetContext(TAnimCore animator)
		{
			amplitude = baseAmplitude;
			frequency = baseFrequency;
			waveSize = baseWaveSize;
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			switch (modifier.name)
			{
			case "a":
				amplitude = baseAmplitude * modifier.value;
				break;
			case "f":
				frequency = baseFrequency * modifier.value;
				break;
			case "w":
				waveSize = baseWaveSize * modifier.value;
				break;
			}
		}
	}
}
