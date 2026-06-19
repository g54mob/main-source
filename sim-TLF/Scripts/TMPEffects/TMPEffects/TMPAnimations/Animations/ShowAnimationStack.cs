using System;
using TMPEffects.CharacterData;

namespace TMPEffects.TMPAnimations.Animations
{
	[Serializable]
	internal class ShowAnimationStack : AnimationStack<TMPShowAnimation>
	{
		public override void Animate(CharData cData, IAnimationContext context)
		{
			Data data = context.CustomData as Data;
			PopulateContextCache(data, context);
			foreach (AnimPrefixTuple animation in animations)
			{
				(data.ContextCache[animation.animation] as AnimContext).ResetFinished(cData);
			}
			foreach (AnimPrefixTuple animation2 in animations)
			{
				if (!(animation2.animation == null))
				{
					animation2.animation.Animate(cData, data.ContextCache[animation2.animation]);
				}
			}
			bool flag = true;
			foreach (AnimPrefixTuple animation3 in animations)
			{
				if (!data.ContextCache[animation3.animation].Finished(cData))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				context.FinishAnimation(cData);
			}
		}
	}
}
