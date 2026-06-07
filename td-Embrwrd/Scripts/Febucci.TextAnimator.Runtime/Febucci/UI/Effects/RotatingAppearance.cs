using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[DefaultValue("baseDuration", 0.7f)]
	[EffectInfo("rot", EffectCategory.Appearances)]
	[CreateAssetMenu(fileName = "Rotating Appearance", menuName = "Text Animator/Animations/Appearances/Rotating")]
	[Preserve]
	public sealed class RotatingAppearance : AppearanceScriptableBase
	{
		public float baseTargetAngle;

		private float targetAngle;

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
