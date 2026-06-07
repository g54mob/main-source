using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct StallCurve
	{
		public float liftMax;

		public float stallSmoothness;

		public static StallCurve Lerp(StallCurve a, StallCurve b, float t)
		{
			return new StallCurve
			{
				liftMax = math.lerp(a.liftMax, b.liftMax, t),
				stallSmoothness = math.lerp(a.stallSmoothness, b.stallSmoothness, t)
			};
		}

		public readonly float CalculateCriticalAngle(float alphaZero, float liftGradient)
		{
			float num = stallSmoothness * liftGradient * 0.5f;
			return (liftMax - num) / liftGradient + alphaZero + stallSmoothness;
		}

		public readonly float2 Sample(float alphaMinusAlphaZero, float liftGradient)
		{
			float num = stallSmoothness * liftGradient * 0.5f;
			float num2 = (liftMax - num) / liftGradient + stallSmoothness;
			float num3 = num2 + stallSmoothness;
			if (alphaMinusAlphaZero < num2)
			{
				return math.float2(alphaMinusAlphaZero * liftGradient, liftGradient);
			}
			float num4 = (0f - liftGradient) / (2f * stallSmoothness);
			float num5 = -2f * num4 * num3;
			return math.float2(num2 * (liftGradient - (num5 + num2 * num4)) + alphaMinusAlphaZero * (num5 + num4 * alphaMinusAlphaZero), num5 + 2f * num4 * alphaMinusAlphaZero);
		}
	}
}
