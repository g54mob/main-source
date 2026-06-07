using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(fileName = "Diagonal Expand Appearance", menuName = "Text Animator/Animations/Appearances/Diagonal Expand")]
	[EffectInfo("diagexp", EffectCategory.Appearances)]
	public sealed class DiagonalExpandAppearance : AppearanceScriptableBase
	{
		public bool diagonalFromBttmLeft;

		private int targetA;

		private int targetB;

		private Vector3 middlePos;

		private float pct;

		public override void ResetContext(TAnimCore animator)
		{
			base.ResetContext(animator);
			diagonalFromBttmLeft = true;
			UpdateOrientation();
		}

		private void UpdateOrientation()
		{
			if (diagonalFromBttmLeft)
			{
				targetA = 0;
				targetB = 2;
			}
			else
			{
				targetA = 1;
				targetB = 3;
			}
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			middlePos = character.current.positions.GetMiddlePos();
			pct = Tween.EaseInOut(character.passedTime / duration);
			character.current.positions[targetA] = Vector3.LerpUnclamped(middlePos, character.current.positions[targetA], pct);
			character.current.positions[targetB] = Vector3.LerpUnclamped(middlePos, character.current.positions[targetB], pct);
		}

		public override void SetModifier(ModifierInfo modifier)
		{
			if (modifier.name == "bot")
			{
				diagonalFromBttmLeft = (int)modifier.value == 1;
				UpdateOrientation();
			}
			else
			{
				base.SetModifier(modifier);
			}
		}
	}
}
