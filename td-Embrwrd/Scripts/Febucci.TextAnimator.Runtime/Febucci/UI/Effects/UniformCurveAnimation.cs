using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Uniform Curve Animation", menuName = "Text Animator/Animations/Special/Uniform Curve")]
	[EffectInfo(null, EffectCategory.All)]
	public sealed class UniformCurveAnimation : AnimationScriptableBase
	{
		public TimeMode timeMode;

		[EmissionCurveProperty]
		public EmissionCurve emissionCurve;

		public AnimationData animationData;

		private float weightMult;

		private float timeSpeed;

		private bool hasTransformEffects;

		private float timePassed;

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}

		public override float GetMaxDuration()
		{
			return 0f;
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return false;
		}
	}
}
