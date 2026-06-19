using System;
using TMPEffects.CharacterData;

namespace TMPEffects.TMPAnimations.Animations
{
	[Serializable]
	internal class HideAnimationStack : AnimationStack<TMPHideAnimation>
	{
		public override void Animate(CharData cData, IAnimationContext context)
		{
		}
	}
}
