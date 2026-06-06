using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Uniform Curve Animation", menuName = "Text Animator/Animations/Special/Uniform Curve")]
	[EffectInfo("", EffectCategory.All)]
	public sealed class UniformCurveAnimation : AnimationScriptableBase
	{
		public TimeMode timeMode = new TimeMode(useUniformTime: true);

		[EmissionCurveProperty]
		public EmissionCurve emissionCurve = new EmissionCurve();

		public AnimationData animationData = new AnimationData();

		private float weightMult;

		private float timeSpeed;

		private bool hasTransformEffects;

		private float timePassed;

		public override void ResetContext(TAnimCore animator)
		{
			weightMult = 1f;
			timeSpeed = 1f;
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			string text = modifier.name;
			if (!(text == "f"))
			{
				if (text == "a")
				{
					weightMult = modifier.value;
				}
			}
			else
			{
				timeSpeed = modifier.value;
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			timePassed = timeMode.GetTime(animator.time.timeSinceStart * timeSpeed, character.passedTime * timeSpeed, character.index);
			if (timePassed < 0f)
			{
				return;
			}
			float num = weightMult * emissionCurve.Evaluate(timePassed);
			if (animationData.TryCalculatingMatrix(character, timePassed, num, out var matrix, out var offset))
			{
				for (byte b = 0; b < 4; b++)
				{
					character.current.positions[b] = matrix.MultiplyPoint3x4(character.current.positions[b] - offset) + offset;
				}
			}
			if (animationData.TryCalculatingColor(character, timePassed, num, out var color))
			{
				character.current.colors.LerpUnclamped(color, Mathf.Clamp01(num));
			}
		}

		public override float GetMaxDuration()
		{
			return emissionCurve.GetMaxDuration();
		}

		public override bool CanApplyEffectTo(CharacterData character, TAnimCore animator)
		{
			return true;
		}
	}
}
