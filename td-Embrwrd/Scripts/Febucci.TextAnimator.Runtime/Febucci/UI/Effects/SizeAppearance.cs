using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[EffectInfo("size", EffectCategory.Appearances)]
	[CreateAssetMenu(fileName = "Size Appearance", menuName = "Text Animator/Animations/Appearances/Size")]
	[Preserve]
	public sealed class SizeAppearance : AppearanceScriptableBase
	{
		private float amplitude;

		public float baseAmplitude;

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
