using System.Collections.Generic;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.ControlSurfaces
{
	public class WingSurfaceClaims
	{
		public List<Claim> Claims { get; } = new List<Claim>();

		public List<InputWingSlice> Slices { get; set; }

		public float2 WingSpanRange
		{
			get
			{
				float position = Slices[0].Position;
				List<InputWingSlice> slices = Slices;
				return math.float2(position, slices[slices.Count - 1].Position);
			}
		}

		public WingSurfaceClaims(List<InputWingSlice> slices)
		{
			Slices = slices;
		}

		public static bool InRange(float x, float2 range)
		{
			if (x >= range.x)
			{
				return x <= range.y;
			}
			return false;
		}

		public void Clear()
		{
			Claims.Clear();
		}

		public float2? GetFreeEdgeSpanRange(float spanPos, bool isLeadingEdge = false, bool searchToRoot = false, Claim ignore = null)
		{
			if (!InRange(spanPos, WingSpanRange))
			{
				return null;
			}
			(int Root, int Tip) unbentIndexRange = GetUnbentIndexRange(spanPos, searchToRoot);
			int item = unbentIndexRange.Root;
			int item2 = unbentIndexRange.Tip;
			float2 value = math.float2(Slices[item].Position, Slices[item2].Position);
			foreach (Claim claim in Claims)
			{
				if (claim != ignore && !(isLeadingEdge ? claim.IsTrailingEdge : claim.IsLeadingEdge))
				{
					float2 spanRange = claim.SpanRange;
					switch (Claim.PointInRange(spanRange, spanPos, 6E-45f))
					{
					case 0:
						return null;
					case 1:
						value.x = math.max(value.x, spanRange.y);
						break;
					case -1:
						value.y = math.min(value.y, spanRange.x);
						break;
					}
				}
			}
			if (value.x < value.y)
			{
				return value;
			}
			return null;
		}

		public (InputWingSlice Root, InputWingSlice Tip, float T) GetSectionAtSpanPos(float spanPos)
		{
			var (index, index2, item) = GetSectionIndexAtSpanPos(spanPos);
			return (Root: Slices[index], Tip: Slices[index2], T: item);
		}

		public (int Root, int Tip, float T) GetSectionIndexAtSpanPos(float spanPos)
		{
			List<InputWingSlice> slices = Slices;
			int num = 0;
			int num2 = slices.Count - 1;
			while (num2 - num > 1)
			{
				int num3 = (num + num2) / 2;
				InputWingSlice inputWingSlice = slices[num3];
				if (inputWingSlice.ApproximatelyEqualPosition(spanPos))
				{
					return (Root: num3, Tip: num3, T: 0f);
				}
				if (inputWingSlice.Position < spanPos)
				{
					num = num3;
				}
				else
				{
					num2 = num3;
				}
			}
			return (Root: num, Tip: num2, T: math.unlerp(slices[num].Position, slices[num2].Position, spanPos));
		}

		public (int Root, int Tip) GetUnbentIndexRange(float spanPos, bool searchToRoot = false)
		{
			(int Root, int Tip, float T) sectionIndexAtSpanPos = GetSectionIndexAtSpanPos(spanPos);
			int num = sectionIndexAtSpanPos.Root;
			int i = sectionIndexAtSpanPos.Tip;
			List<InputWingSlice> slices = Slices;
			if (num == i)
			{
				if (searchToRoot)
				{
					num--;
				}
				else
				{
					i++;
				}
			}
			while (num > 0 && slices[num].Bend == 0f)
			{
				num--;
			}
			for (; i < slices.Count - 1 && slices[i].Bend == 0f; i++)
			{
			}
			return (Root: num, Tip: i);
		}

		public float2? TryEnforceChordSizeRange(Claim claim, float2 startPos, float2 minMaxSize, float tipWeight = 0.5f, bool isLeadingEdge = false)
		{
			InterpolateInputs();
			float2 spanRange = claim.SpanRange;
			(int Root, int Tip, float T) sectionIndexAtSpanPos = GetSectionIndexAtSpanPos(claim.SpanRange.x);
			int item = sectionIndexAtSpanPos.Root;
			int item2 = sectionIndexAtSpanPos.Tip;
			float item3 = sectionIndexAtSpanPos.T;
			(int Root, int Tip, float T) sectionIndexAtSpanPos2 = GetSectionIndexAtSpanPos(claim.SpanRange.y);
			int item4 = sectionIndexAtSpanPos2.Root;
			int item5 = sectionIndexAtSpanPos2.Tip;
			float item6 = sectionIndexAtSpanPos2.T;
			List<InputWingSlice> slices = Slices;
			float2 zRangeFromSliceIndices = GetZRangeFromSliceIndices(item, item2, item3, minMaxSize, isLeadingEdge);
			float2 zRangeFromSliceIndices2 = GetZRangeFromSliceIndices(item4, item5, item6, minMaxSize, isLeadingEdge);
			float4 zRanges = math.float4(zRangeFromSliceIndices, zRangeFromSliceIndices2);
			startPos = math.clamp(startPos, zRanges.xz, zRanges.yw);
			List<float3> boundaries = new List<float3>
			{
				new float3(0f, 1f, 0f),
				new float3(1f, 0f, 0f),
				new float3(0f, -1f, -1f),
				new float3(-1f, 0f, -1f)
			};
			for (int i = 0; i < slices.Count; i++)
			{
				InputWingSlice inputWingSlice = slices[i];
				float num = math.unlerp(spanRange.x, spanRange.y, inputWingSlice.Position);
				if (!(num < 0f))
				{
					if (num > 1f)
					{
						break;
					}
					float2 float5 = math.lerp(zRangeFromSliceIndices, zRangeFromSliceIndices2, num);
					float2 zRangeFromSlice = GetZRangeFromSlice(inputWingSlice, minMaxSize, isLeadingEdge);
					zRangeFromSlice = math.unlerp(float5.xx, float5.yy, zRangeFromSlice);
					if (zRangeFromSlice.x > 0f)
					{
						boundaries.Add(BoundaryForPoint(num, zRangeFromSlice.x));
					}
					if (zRangeFromSlice.y < 1f)
					{
						boundaries.Add(-BoundaryForPoint(num, zRangeFromSlice.y));
					}
				}
			}
			float2 float6 = math.unlerp(zRanges.xz, zRanges.yw, startPos);
			bool flag = true;
			foreach (float3 item7 in boundaries)
			{
				if (math.dot(item7.xy, float6) < item7.z)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return startPos;
			}
			float2 lineDir = math.float2(tipWeight, 1f - tipWeight);
			float2? float7 = TrySolveAlongLine(float6, lineDir);
			if (float7.HasValue)
			{
				return float7.Value;
			}
			float6 = math.float2(0.25f, 0.25f);
			float7 = TrySolveAlongLine(float6, math.float2(1f, 1f));
			if (float7.HasValue)
			{
				return float7.Value;
			}
			return null;
			float2 ABToStartPos(float2 uv)
			{
				return math.lerp(zRanges.xz, zRanges.yw, uv);
			}
			static float3 BoundaryForPoint(float u, float v)
			{
				return math.float3(1f - u, u, v);
			}
			float2? TrySolveAlongLine(float2 origin, float2 float9)
			{
				float2 float8 = math.float2(float.NegativeInfinity, float.PositiveInfinity);
				foreach (float3 item8 in boundaries)
				{
					float num2 = math.dot(item8.xy, float9);
					float num3 = math.dot(item8.xy, origin);
					if (math.abs(num2) < 1.1920929E-07f)
					{
						if (!(num3 >= item8.z))
						{
							float8 = math.float2(1f, 0f);
							break;
						}
					}
					else
					{
						float y = (item8.z - num3) / num2;
						if (num2 > 0f)
						{
							float8.x = math.max(float8.x, y);
						}
						else
						{
							float8.y = math.min(float8.y, y);
						}
					}
				}
				if (float8.x < float8.y)
				{
					float num4 = ((!(math.abs(float8.x) < math.abs(float8.y))) ? float8.y : float8.x);
					return ABToStartPos(origin + float9 * num4);
				}
				return null;
			}
		}

		private static bool ClipEdge(Claim claim, List<Claim> otherClaims)
		{
			float2 spanRange = claim.SpanRange;
			foreach (Claim otherClaim in otherClaims)
			{
				if (otherClaim == claim)
				{
					continue;
				}
				if (spanRange.x > spanRange.y)
				{
					return false;
				}
				float2 spanRange2 = otherClaim.SpanRange;
				int num = Claim.PointInRange(spanRange2, spanRange.x);
				int num2 = Claim.PointInRange(spanRange2, spanRange.y);
				if (num == num2)
				{
					if (num == 0)
					{
						return false;
					}
					continue;
				}
				if (num * num2 == 0)
				{
					if (num == 0)
					{
						spanRange.x = spanRange2.y;
					}
					else
					{
						spanRange.y = spanRange2.x;
					}
					continue;
				}
				float num3 = 0.5f * (spanRange.x + spanRange.y);
				float num4 = 0.5f * (spanRange2.x + spanRange2.y);
				if (num3 > num4)
				{
					spanRange.x = spanRange2.y;
				}
				else
				{
					spanRange.y = spanRange2.x;
				}
			}
			claim.SpanRange = spanRange;
			return true;
		}

		private static float2 GetZRangeFromSlice(InputWingSlice slice, float2 minMaxSize, bool isLeadingEdge)
		{
			return GetZRangeFromSliceParams(slice.Offset, slice.Scale, minMaxSize, isLeadingEdge);
		}

		private static float2 GetZRangeFromSliceParams(float sliceOffset, float sliceScale, float2 minMaxSize, bool isLeadingEdge)
		{
			return sliceOffset + sliceScale * (isLeadingEdge ? (0.5f - minMaxSize.yx) : (-0.5f + minMaxSize));
		}

		private float2 GetZRangeFromSliceIndices(int a, int b, float t, float2 minMaxSize, bool isLeadingEdge)
		{
			if (a == b)
			{
				InputWingSlice inputWingSlice = Slices[a];
				return GetZRangeFromSliceParams(inputWingSlice.Offset, inputWingSlice.Scale, minMaxSize, isLeadingEdge);
			}
			InputWingSlice inputWingSlice2 = Slices[a];
			InputWingSlice inputWingSlice3 = Slices[b];
			return GetZRangeFromSliceParams(math.lerp(inputWingSlice2.Offset, inputWingSlice3.Offset, t), math.lerp(inputWingSlice2.Scale, inputWingSlice3.Scale, t), minMaxSize, isLeadingEdge);
		}

		private void InterpolateInputs()
		{
			WingBuilder.InterpolateAllOffsetScale(Slices);
		}
	}
}
