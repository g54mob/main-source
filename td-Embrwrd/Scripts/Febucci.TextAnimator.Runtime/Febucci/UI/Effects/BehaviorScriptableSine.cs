using Febucci.UI.Core;
using UnityEngine;

namespace Febucci.UI.Effects
{
	public abstract class BehaviorScriptableSine : BehaviorScriptableBase
	{
		public float baseAmplitude;

		public float baseFrequency;

		[Range(0f, 1f)]
		public float baseWaveSize;

		protected float amplitude;

		protected float frequency;

		protected float waveSize;

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}
	}
}
