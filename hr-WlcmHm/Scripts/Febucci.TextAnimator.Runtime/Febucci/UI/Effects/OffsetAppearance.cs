using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Offset Appearance", menuName = "Text Animator/Animations/Appearances/Offset")]
	[EffectInfo("offset", EffectCategory.Appearances)]
	public sealed class OffsetAppearance : AppearanceScriptableBase
	{
		public float baseAmount = 10f;

		private float amount;

		public Vector2 baseDirection = Vector2.one;

		public override void ResetContext(TAnimCore animator)
		{
			base.ResetContext(animator);
			amount = baseAmount;
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			character.current.positions.MoveChar(baseDirection * amount * character.uniformIntensity * Tween.EaseIn(1f - character.passedTime / duration));
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			if (modifier.name == "a")
			{
				amount = baseAmount * modifier.value;
			}
			else
			{
				base.SetModifier(modifier);
			}
		}
	}
}
