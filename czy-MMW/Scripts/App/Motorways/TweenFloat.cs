using Easing;
using UnityEngine;

namespace Motorways
{
	public class TweenFloat : Tween<float>
	{
		public void Start(float start, float rangeBegin, float rangeEnd, float rangeDuration)
		{
			if (!Mathf.Approximately(rangeBegin, 0f))
			{
				float num = (start - rangeBegin) / (rangeEnd - rangeBegin);
				rangeDuration *= 1f - num;
			}
			Start(start, rangeEnd, rangeDuration, Easings.Functions.Linear);
		}

		protected override float LerpValue(float startValue, float endValue, float alpha)
		{
			return startValue + (endValue - startValue) * alpha;
		}
	}
}
