using System;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Parts.Fuselage
{
	[Serializable]
	public struct SectionParams
	{
		public bool AbsoluteThickness;

		public float4 CornerRadii;

		public int4 CornerSamples;

		public float4 CornersStretch;

		public float4 EdgeCurvature;

		public int4 EdgeSamples;

		public float2 Size;

		public float Thickness;

		public float Inset;

		public float Trapezium;

		public readonly float2 HalfSize => Size * 0.5f;

		public readonly SectionParams Inner
		{
			get
			{
				SectionParams result = this;
				if (AbsoluteThickness)
				{
					float inset = math.cmin(Size) * 0.5f * math.clamp(Thickness, 0.01f, 1f);
					result.Inset = inset;
					result.Thickness = 0f;
				}
				else
				{
					result.Size *= 1f - math.clamp(result.Thickness, 0f, 0.99f);
					result.Thickness = 0f;
				}
				return result;
			}
		}

		public readonly bool IsAllSharpCorners => math.all(CornerRadii == 0f);

		public static SectionParams Lerp(in SectionParams a, in SectionParams b, float t)
		{
			t = math.saturate(t);
			return new SectionParams
			{
				Size = math.lerp(a.Size, b.Size, t),
				CornerRadii = math.lerp(a.CornerRadii, b.CornerRadii, t),
				CornersStretch = math.lerp(a.CornersStretch, b.CornersStretch, t),
				CornerSamples = (int4)math.lerp(a.CornerSamples, b.CornerSamples, t),
				EdgeCurvature = math.lerp(a.EdgeCurvature, b.EdgeCurvature, t),
				EdgeSamples = (int4)math.lerp(a.EdgeSamples, b.EdgeSamples, t),
				Thickness = math.lerp(a.Thickness, b.Thickness, t),
				Trapezium = math.lerp(a.Trapezium, b.Trapezium, t),
				AbsoluteThickness = (a.AbsoluteThickness || b.AbsoluteThickness)
			};
		}

		public static SectionParams Bezier(in SectionParams a, in SectionParams b, in SectionParams c, float t)
		{
			return Lerp(Lerp(in a, in b, t), Lerp(in b, in c, t), t);
		}

		public readonly void GetOutline(Span<float2> outPoints)
		{
			float trapezium = Trapezium;
			outPoints[0] = HalfSize * ApplyTrapezium(math.float2(1f, 1f));
			outPoints[1] = HalfSize * ApplyTrapezium(math.float2(1f, -1f));
			outPoints[2] = HalfSize * ApplyTrapezium(math.float2(-1f, -1f));
			outPoints[3] = HalfSize * ApplyTrapezium(math.float2(-1f, 1f));
			float2 ApplyTrapezium(float2 p)
			{
				p.x *= 1f + p.y * trapezium;
				return p;
			}
		}

		public void Mirror()
		{
			CornerRadii = CornerRadii.yxwz;
			CornersStretch = CornersStretch.yxwz;
			CornerSamples = CornerSamples.yxwz;
			EdgeCurvature = EdgeCurvature.xwzy;
			EdgeSamples = EdgeSamples.xwzy;
		}
	}
}
