using Febucci.Numbers;
using Febucci.Parsing;
using Febucci.TextAnimatorCore.Text;

namespace Febucci.TextAnimatorCore
{
	internal class BehaviorsPlayer : ManagedEffectPlayerBase
	{
		public BehaviorsPlayer(string tagId, IEffectManaged preset, RegionParameters parameters)
			: base(tagId, preset, preset.Persistent, parameters)
		{
		}

		public override void Animate(ref CharacterData characterData, in AnimationContext animationContext)
		{
			if (!isValidEffect || characterData.visibleTime <= 0f)
			{
				return;
			}
			playback.CalculateIntensity01(animationContext.timeSinceStart, out var intensity, out var _);
			intensity = Tween.EaseInOut(intensity);
			if (!(intensity <= 0f))
			{
				float offsetFor = phase.GetOffsetFor(characterData.index, characterData.wordIndex);
				float speedFor = phase.GetSpeedFor(characterData.index, characterData.wordIndex);
				float max = characterData.appearTime * speedFor + offsetFor;
				float time = animationContext.timeSinceStart * speedFor + offsetFor;
				float time2 = ManagedEffectPlayerBase.NormalizeTimeForCurve(time);
				float progressionRange = stateCurve.EvaluateRange(time2);
				float progression = stateCurve.Evaluate01(time2);
				float num = 1f;
				float visibleTime = characterData.visibleTime;
				if (effectSettings.delayBeforePersistant > 0f && visibleTime <= effectSettings.delayBeforePersistant)
				{
					num = 0f;
				}
				else if (effectSettings.timeToSyncPersistant > 0f && visibleTime - effectSettings.delayBeforePersistant <= effectSettings.timeToSyncPersistant)
				{
					num = Tween.EaseIn((visibleTime - effectSettings.delayBeforePersistant) / effectSettings.timeToSyncPersistant);
				}
				if (num < 1f)
				{
					max = Mathf.LerpUnclamped(characterData.appearTime, max, num);
					float time3 = ManagedEffectPlayerBase.NormalizeTimeForCurve(max);
					float progressionRange2 = stateCurve.EvaluateRange(time3);
					float progression2 = stateCurve.Evaluate01(time3);
					ManagedEffectContext context = new ManagedEffectContext(progressionRange2, progression2, intensity * num, isUpPositive, isInsideBehavior: true, animationContext.timeSinceStart);
					ManagedEffectContext target = new ManagedEffectContext(progressionRange, progression, intensity, isUpPositive, isInsideBehavior: true, animationContext.timeSinceStart);
					context.LerpUnclampedTo(target, num);
					transformState.Apply(ref characterData, in context);
				}
				else
				{
					ManagedEffectContext context2 = new ManagedEffectContext(progressionRange, progression, intensity, isUpPositive, isInsideBehavior: true, animationContext.timeSinceStart);
					transformState.Apply(ref characterData, in context2);
				}
			}
		}
	}
}
