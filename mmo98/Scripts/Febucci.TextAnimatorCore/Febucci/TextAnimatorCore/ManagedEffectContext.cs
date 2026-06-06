using Febucci.Numbers;

namespace Febucci.TextAnimatorCore
{
	public struct ManagedEffectContext
	{
		public float progressionRange;

		public float progression01;

		public float intensity;

		public float animatorTime;

		public readonly bool isUpPositive;

		public readonly bool isInsideBehavior;

		public ManagedEffectContext(float progressionRange, float progression01, float intensity, bool isUpPositive, bool isInsideBehavior, float animatorTime)
		{
			this.progression01 = progression01;
			this.progressionRange = progressionRange;
			this.intensity = intensity;
			this.isUpPositive = isUpPositive;
			this.isInsideBehavior = isInsideBehavior;
			this.animatorTime = animatorTime;
		}

		internal void LerpUnclampedTo(ManagedEffectContext target, float pct01)
		{
			progression01 = Mathf.LerpUnclamped(progression01, target.progression01, pct01);
			progressionRange = Mathf.LerpUnclamped(progressionRange, target.progressionRange, pct01);
			intensity = Mathf.LerpUnclamped(intensity, target.intensity, pct01);
		}
	}
}
