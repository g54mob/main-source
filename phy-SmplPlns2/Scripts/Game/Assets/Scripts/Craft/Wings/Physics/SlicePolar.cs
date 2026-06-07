using System;
using System.Text;
using Unity.Burst;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Physics
{
	public struct SlicePolar
	{
		public float alphaZero;

		public DragCurve dragCurve;

		public float liftGradient;

		public float stalledNormalForceMax;

		public StallCurve stallNegative;

		public StallCurve stallPositive;

		public float zeroLiftMoment;

		public float aerodynamicCentre;

		public float additionalMoment;

		public static SlicePolar Lerp(SlicePolar a, SlicePolar b, float t)
		{
			return new SlicePolar
			{
				alphaZero = math.lerp(a.alphaZero, b.alphaZero, t),
				liftGradient = math.lerp(a.liftGradient, b.liftGradient, t),
				stallPositive = StallCurve.Lerp(a.stallPositive, b.stallPositive, t),
				stallNegative = StallCurve.Lerp(a.stallNegative, b.stallNegative, t),
				dragCurve = DragCurve.Lerp(a.dragCurve, b.dragCurve, t),
				stalledNormalForceMax = math.lerp(a.stalledNormalForceMax, b.stalledNormalForceMax, t),
				aerodynamicCentre = math.lerp(a.aerodynamicCentre, b.aerodynamicCentre, t),
				zeroLiftMoment = math.lerp(a.zeroLiftMoment, b.zeroLiftMoment, t),
				additionalMoment = math.lerp(a.additionalMoment, b.additionalMoment, t)
			};
		}

		public readonly void Sample(float alpha, float mach, out float2 cL, out float2 cD, out float2 cM)
		{
			alpha -= alphaZero;
			alpha = (math.isnan(alpha) ? 0f : alpha);
			float num = math.rsqrt(math.max(0.51f, math.abs(1f - mach * mach)));
			float num2 = math.sign(alpha);
			cL = ((num2 >= 0f) ? stallPositive : stallNegative).Sample(math.abs(alpha), liftGradient) * num;
			cL.x *= num2;
			float num3 = stalledNormalForceMax * num;
			math.sincos(alpha, out var s, out var c);
			float num4 = s * num3;
			float num5 = c * num3;
			float2 float5 = default(float2);
			float5.x = num4 * c;
			float5.y = num5 * c - num4 * s;
			float2 float6 = default(float2);
			float6.x = num4 * s + dragCurve.zeroLiftDrag;
			float6.y = num5 * s + num4 * c;
			if (!math.all(math.isfinite(cL)) || math.abs(alpha) > MathF.PI / 2f || float5.x * num2 > cL.x * num2)
			{
				cL = float5;
				cD = float6;
			}
			else
			{
				cD = dragCurve.Sample(alpha, cL.x, cL.y);
			}
			cM.x = zeroLiftMoment + (aerodynamicCentre - 0.25f) * cL.x + additionalMoment;
			cM.y = (aerodynamicCentre - 0.25f) * cL.y;
		}

		public void ApplyLiftIncrement(float increment)
		{
			alphaZero -= increment / liftGradient;
		}

		public void ApplyCLMaxIncrement(float increment)
		{
			stallPositive.liftMax += increment;
			stallNegative.liftMax -= increment;
		}

		public void ApplyFlapMoment(float liftIncrement, float liftLocation, float chordExtensionRatio = 1f)
		{
			float num = liftIncrement * (aerodynamicCentre - liftLocation * chordExtensionRatio);
			additionalMoment += num;
		}

		[BurstDiscard]
		private readonly string DebugOutputCSV(float a0, float a1, float da, float mach)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendLine("alpha,cl,cd,cm,dcl,dcd,dcm");
			for (float num = a0; num <= a1; num += da)
			{
				Sample(num, mach, out var cL, out var cD, out var cM);
				stringBuilder.AppendLine($"{num:F20},{cL.x:F20},{cD.x:F20},{cM.x:F20},{cL.y:F20},{cD.y:F20},{cM.y:F20}");
			}
			return stringBuilder.ToString();
		}
	}
}
