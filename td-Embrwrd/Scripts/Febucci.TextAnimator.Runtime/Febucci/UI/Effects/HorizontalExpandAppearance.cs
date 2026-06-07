using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[EffectInfo("horiexp", EffectCategory.Appearances)]
	[CreateAssetMenu(fileName = "Horizontal Expand Appearance", menuName = "Text Animator/Animations/Appearances/Horizontal Expand")]
	[Preserve]
	public sealed class HorizontalExpandAppearance : AppearanceScriptableBase
	{
		public enum ExpType
		{
			Left = 0,
			Middle = 1,
			Right = 2
		}

		public ExpType type;

		private Vector2 startTop;

		private Vector2 startBot;

		private float pct;

		public override void ResetContext(TAnimCore animator)
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
