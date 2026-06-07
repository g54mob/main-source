using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Shake", fileName = "Shake Behavior")]
	[EffectInfo("shake", EffectCategory.Behaviors)]
	[DefaultValue("baseAmplitude", 1.13f)]
	[DefaultValue("baseDelay", 0.1f)]
	[DefaultValue("baseWaveSize", 0.45f)]
	[Preserve]
	public sealed class ShakeBehavior : BehaviorScriptableBase
	{
		public float baseAmplitude;

		public float baseDelay;

		public float baseWaveSize;

		private float amplitude;

		private float delay;

		private float waveSize;

		private int randIndex;

		private float timePassed;

		private void ClampValues()
		{
		}

		protected override void OnInitialize()
		{
		}

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}

		private void OnValidate()
		{
		}
	}
}
