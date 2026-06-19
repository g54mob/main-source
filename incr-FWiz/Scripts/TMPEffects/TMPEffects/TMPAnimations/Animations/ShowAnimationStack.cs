using System;
using TMPEffects.CharacterData;

namespace TMPEffects.TMPAnimations.Animations
{
	[Serializable]
	internal class ShowAnimationStack : AnimationStack<TMPShowAnimation>
	{
		public override void Animate(CharData cData, IAnimationContext context)
		{
		}
	}
}
