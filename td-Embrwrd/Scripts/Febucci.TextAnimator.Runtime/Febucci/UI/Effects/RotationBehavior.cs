using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[EffectInfo("rot", EffectCategory.Behaviors)]
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Rotation", fileName = "Rotation Behavior")]
	public sealed class RotationBehavior : BehaviorScriptableBase
	{
		public float baseRotSpeed;

		public float baseDiffBetweenChars;

		private float angleSpeed;

		private float angleDiffBetweenChars;

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override void ResetContext(TAnimCore animator)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
