using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[Preserve]
	[CreateAssetMenu(menuName = "Text Animator/Animations/Behaviors/Rotation", fileName = "Rotation Behavior")]
	[EffectInfo("rot", EffectCategory.Behaviors)]
	public sealed class RotationBehavior : BehaviorScriptableBase
	{
		public float baseRotSpeed = 180f;

		public float baseDiffBetweenChars = 10f;

		private float angleSpeed;

		private float angleDiffBetweenChars;

		public override void SetModifier(ModifierInfo modifier)
		{
			string text = modifier.name;
			if (!(text == "f"))
			{
				if (text == "w")
				{
					angleDiffBetweenChars = baseDiffBetweenChars * modifier.value;
				}
			}
			else
			{
				angleSpeed = baseRotSpeed * modifier.value;
			}
		}

		public override void ResetContext(TAnimCore animator)
		{
			angleSpeed = baseRotSpeed;
			angleDiffBetweenChars = baseDiffBetweenChars;
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
			character.current.positions.RotateChar((0f - animator.time.timeSinceStart) * angleSpeed + angleDiffBetweenChars * (float)character.index);
		}
	}
}
