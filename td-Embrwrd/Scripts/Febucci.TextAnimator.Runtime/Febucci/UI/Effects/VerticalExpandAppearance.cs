using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[EffectInfo("vertexp", EffectCategory.Appearances)]
	[Preserve]
	[CreateAssetMenu(fileName = "Vertical Expand Appearance", menuName = "Text Animator/Animations/Appearances/Vertical Expand")]
	public sealed class VerticalExpandAppearance : AppearanceScriptableBase
	{
		public bool startsFromBottom;

		private int startA;

		private int targetA;

		private int startB;

		private int targetB;

		private float pct;

		public override void ResetContext(TAnimCore animator)
		{
		}

		private void SetOrientation(bool fromBottom)
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
