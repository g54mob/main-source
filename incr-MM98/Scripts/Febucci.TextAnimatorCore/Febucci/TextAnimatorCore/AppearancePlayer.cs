using System;
using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore
{
	public class AppearancePlayer : ManagedEffectPlayerBase
	{
		private readonly bool isBackwards;

		public AppearancePlayer(string tagId, IEffectManaged preset, bool isBackwards, RegionParameters parameters)
			: base(tagId, preset, isBackwards ? preset.Disappearance : preset.Appearance, parameters)
		{
			this.isBackwards = isBackwards;
		}

		public override void Animate(ref CharacterData characterData, in AnimationContext animationContext)
		{
			if (!isValidEffect || duration <= 0f)
			{
				return;
			}
			float num = (isBackwards ? characterData.disappearTime : characterData.appearTime);
			if (num <= 0f || (isBackwards && num >= characterData.info.disappearancesMaxDuration))
			{
				return;
			}
			float speedFor = phase.GetSpeedFor(characterData.index, characterData.wordIndex);
			float num2 = num * speedFor;
			if (num2 >= duration)
			{
				return;
			}
			playback.CalculateIntensity01(num2, out var intensity, out var _);
			intensity = Tween.EaseOut(intensity);
			if (!(intensity <= 0f))
			{
				float offsetFor = phase.GetOffsetFor(characterData.index, characterData.wordIndex);
				float num3 = stateCurve.Evaluate01(1f - intensity);
				if (!(num3 <= 0f))
				{
					ManagedEffectContext context = new ManagedEffectContext(MathF.Cos(offsetFor * 2f * MathF.PI), offsetFor % 1f, num3, isUpPositive, isInsideBehavior: false, animationContext.timeSinceStart);
					transformState.Apply(ref characterData, in context);
				}
			}
		}
	}
}
