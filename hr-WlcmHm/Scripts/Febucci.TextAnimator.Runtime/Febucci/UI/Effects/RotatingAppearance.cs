using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Rotating Appearance", menuName = "Text Animator/Animations/Appearances/Rotating")]
	[EffectInfo("rot", EffectCategory.Appearances)]
	[DefaultValue("baseDuration", 0.7f)]
	public sealed class RotatingAppearance : AppearanceScriptableBase
	{
		public float baseTargetAngle = 50f;

		private float targetAngle;

		public override void ResetContext(TAnimCore animator)
		{
			base.ResetContext(animator);
			targetAngle = baseTargetAngle;
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			character.current.positions.RotateChar(Mathf.Lerp(targetAngle, 0f, Tween.EaseInOut(character.passedTime / duration)));
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			if (modifier.name == "a")
			{
				targetAngle = baseTargetAngle * modifier.value;
			}
			else
			{
				base.SetModifier(modifier);
			}
		}
	}
}
