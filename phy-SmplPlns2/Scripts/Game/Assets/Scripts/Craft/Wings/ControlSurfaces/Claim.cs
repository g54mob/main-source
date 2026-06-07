using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.ControlSurfaces
{
	public sealed class Claim
	{
		public float2 ChordRangeRoot { get; set; }

		public float2 ChordRangeTip { get; set; }

		public bool CoversBottomSurface { get; set; }

		public bool CoversTopSurface { get; set; }

		public bool IsLeadingEdge
		{
			get
			{
				if (ChordRangeRoot.y != float.PositiveInfinity)
				{
					return ChordRangeTip.y == float.PositiveInfinity;
				}
				return true;
			}
		}

		public bool IsTrailingEdge
		{
			get
			{
				if (ChordRangeRoot.x != float.NegativeInfinity)
				{
					return ChordRangeTip.x == float.NegativeInfinity;
				}
				return true;
			}
		}

		public float2 SpanRange { get; set; }

		public static float2 ClipRange(float2 insertingRange, float2 constraintRange)
		{
			if (insertingRange.y - insertingRange.x >= constraintRange.y - constraintRange.x)
			{
				return constraintRange;
			}
			if (constraintRange.x > insertingRange.x)
			{
				return math.float2(constraintRange.x, insertingRange.y + (constraintRange.x - insertingRange.x));
			}
			if (constraintRange.y < insertingRange.y)
			{
				return math.float2(insertingRange.x + (constraintRange.y - insertingRange.y), constraintRange.y);
			}
			return insertingRange;
		}

		public static float2 PlaceInRange(float insertingWidth, float pos, float2 constraintRange)
		{
			return ClipRange(pos + math.float2(-0.5f, 0.5f) * insertingWidth, constraintRange);
		}

		public static int PointInRange(float2 range, float point, float leeway = 0f)
		{
			if (point - leeway <= range.x)
			{
				return -1;
			}
			if (point + leeway < range.y)
			{
				return 0;
			}
			return 1;
		}

		public void SetLeadingEdge(float2 range, float2 zPos)
		{
			SpanRange = range;
			ChordRangeRoot = math.float2(zPos.x, float.PositiveInfinity);
			ChordRangeTip = math.float2(zPos.y, float.PositiveInfinity);
			CoversBottomSurface = true;
			CoversTopSurface = true;
		}

		public void SetTrailingEdge(float2 range, float2 zPos)
		{
			SpanRange = range;
			ChordRangeRoot = math.float2(float.NegativeInfinity, zPos.x);
			ChordRangeTip = math.float2(float.NegativeInfinity, zPos.y);
			CoversBottomSurface = true;
			CoversTopSurface = true;
		}
	}
}
