using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Size Appearance", menuName = "Text Animator/Animations/Appearances/Size")]
	[EffectInfo("size", EffectCategory.Appearances)]
	public sealed class SizeAppearance : AppearanceScriptableBase
	{
		private float amplitude;

		public float baseAmplitude = 2f;

		public override void ResetContext(TAnimCore animator)
		{
			base.ResetContext(animator);
			amplitude = baseAmplitude * -1f + 1f;
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			character.current.positions.LerpUnclamped(character.current.positions.GetMiddlePos(), Tween.EaseIn(1f - character.passedTime / duration) * amplitude);
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			if (modifier.name == "a")
			{
				amplitude = baseAmplitude * modifier.value;
			}
			else
			{
				base.SetModifier(modifier);
			}
		}
	}
}
