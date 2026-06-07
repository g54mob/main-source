using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Size", fileName = "Size Behavior")]
	[EffectInfo("incr", EffectCategory.Behaviors)]
	public sealed class SizeBehavior : BehaviorScriptableBase
	{
		public float baseAmplitude;

		public float baseFrequency;

		public float baseWaveSize;

		private float amplitude;

		private float frequency;

		private float waveSize;

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
