using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[EffectInfo("offset", EffectCategory.Appearances)]
	[CreateAssetMenu(fileName = "Offset Appearance", menuName = "Text Animator/Animations/Appearances/Offset")]
	public sealed class OffsetAppearance : AppearanceScriptableBase
	{
		public float baseAmount;

		private float amount;

		public Vector2 baseDirection;

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
