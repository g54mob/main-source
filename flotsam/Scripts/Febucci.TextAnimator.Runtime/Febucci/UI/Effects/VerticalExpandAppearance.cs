using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Vertical Expand Appearance", menuName = "Text Animator/Animations/Appearances/Vertical Expand")]
	[EffectInfo("vertexp", EffectCategory.Appearances)]
	public sealed class VerticalExpandAppearance : AppearanceScriptableBase
	{
		public bool startsFromBottom = true;

		private int startA;

		private int targetA;

		private int startB;

		private int targetB;

		private float pct;

		public override void ResetContext(TAnimCore animator)
		{
			base.ResetContext(animator);
			SetOrientation(startsFromBottom);
		}

		private void SetOrientation(bool fromBottom)
		{
			if (fromBottom)
			{
				startA = 0;
				targetA = 1;
				startB = 3;
				targetB = 2;
			}
			else
			{
				startA = 1;
				targetA = 0;
				startB = 2;
				targetB = 3;
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			pct = Tween.EaseInOut(character.passedTime / duration);
			character.current.positions[targetA] = Vector3.LerpUnclamped(character.current.positions[startA], character.current.positions[targetA], pct);
			character.current.positions[targetB] = Vector3.LerpUnclamped(character.current.positions[startB], character.current.positions[targetB], pct);
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			if (modifier.name == "bot")
			{
				SetOrientation((int)modifier.value == 1);
			}
			else
			{
				base.SetModifier(modifier);
			}
		}
	}
}
