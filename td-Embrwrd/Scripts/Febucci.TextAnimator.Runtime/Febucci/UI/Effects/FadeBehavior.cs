using Febucci.UI.Core;
using UnityEngine;
using UnityEngine.Scripting;

namespace Febucci.UI.Effects
{
	[EffectInfo("fade", EffectCategory.Behaviors)]
	[Preserve]
	[CreateAssetMenu(fileName = "Fade Behavior", menuName = "Text Animator/Animations/Behaviors/Fade")]
	public sealed class FadeBehavior : BehaviorScriptableBase
	{
		private Color32 temp;

		public float baseSpeed;

		public float baseDelay;

		private float delay;

		private float timeToShow;

		public override void ResetContext(TAnimCore animator)
		{
		}

		private void SetTimeToShow(float speed)
		{
		}

		public override void SetModifier(ModifierInfo modifier)
		{
		}

		public override void ApplyEffectTo(ref CharacterData character, TAnimCore animator)
		{
		}
	}
}
