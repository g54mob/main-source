using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct DragCurve
	{
		public float criticalAlphaNegative;

		public float criticalAlphaPositive;

		public float viscousDragDueToLift;

		public float zeroLiftDrag;

		public static DragCurve Lerp(DragCurve a, DragCurve b, float t)
		{
			return new DragCurve
			{
				zeroLiftDrag = math.lerp(a.zeroLiftDrag, b.zeroLiftDrag, t),
				viscousDragDueToLift = math.lerp(a.viscousDragDueToLift, b.viscousDragDueToLift, t),
				criticalAlphaPositive = math.lerp(a.criticalAlphaPositive, b.criticalAlphaPositive, t),
				criticalAlphaNegative = math.lerp(a.criticalAlphaNegative, b.criticalAlphaNegative, t)
			};
		}

		public readonly float2 Sample(float alpha, float cL, float d_cL)
		{
			return math.float2(zeroLiftDrag + viscousDragDueToLift * cL * cL, 2f * cL * d_cL);
		}
	}
}
