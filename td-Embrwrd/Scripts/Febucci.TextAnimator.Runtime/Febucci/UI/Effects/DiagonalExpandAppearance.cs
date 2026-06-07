using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[EffectInfo("diagexp", EffectCategory.Appearances)]
	[CreateAssetMenu(fileName = "Diagonal Expand Appearance", menuName = "Text Animator/Animations/Appearances/Diagonal Expand")]
	public sealed class DiagonalExpandAppearance : AppearanceScriptableBase
	{
		public bool diagonalFromBttmLeft;

		private int targetA;

		private int targetB;

		private Vector3 middlePos;

		private float pct;

		public override void ResetContext(TAnimCore animator)
		{
		}

		private void UpdateOrientation()
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}
	}
}
