using System.Collections.Generic;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public struct WingSectionChange
	{
		public struct Params
		{
			public float2 RootChordRange;

			public float2 SpanRange;

			public float2 TipChordRange;

			public void Load(IList<InputWingSlice> slices, int rootSliceIndex)
			{
				InputWingSlice inputWingSlice = slices[rootSliceIndex];
				InputWingSlice inputWingSlice2 = slices[rootSliceIndex + 1];
				SpanRange.x = inputWingSlice.Position;
				SpanRange.y = inputWingSlice2.Position;
				RootChordRange = WingSliceChange.GetChordRange(inputWingSlice, slices, rootSliceIndex);
				TipChordRange = WingSliceChange.GetChordRange(inputWingSlice2, slices, rootSliceIndex + 1);
			}
		}

		public Params After;

		public Params Before;

		public float TipwardsOffsetDiff;

		public float TipwardsPositionDiff;

		public readonly (float Span, float Chord) RemapChordPosition(float spanPos, float chordPos)
		{
			if (Approx(spanPos, Before.SpanRange.x))
			{
				return (Span: After.SpanRange.x, Chord: MapChord(Before.RootChordRange, After.RootChordRange));
			}
			if (spanPos < Before.SpanRange.x)
			{
				return (Span: spanPos, Chord: chordPos);
			}
			if (Approx(spanPos, Before.SpanRange.y))
			{
				return (Span: After.SpanRange.y, Chord: MapChord(Before.TipChordRange, After.TipChordRange));
			}
			if (spanPos < Before.SpanRange.y)
			{
				float t = math.unlerp(Before.SpanRange.x, Before.SpanRange.y, spanPos);
				return (Span: math.lerp(After.SpanRange.x, After.SpanRange.y, t), Chord: MapChord(math.lerp(Before.RootChordRange, Before.TipChordRange, t), math.lerp(After.RootChordRange, After.TipChordRange, t)));
			}
			return (Span: spanPos + TipwardsPositionDiff, Chord: chordPos + TipwardsOffsetDiff);
			float MapChord(float2 rangeBefore, float2 rangeAfter)
			{
				return math.remap(rangeBefore.x, rangeBefore.y, rangeAfter.x, rangeAfter.y, chordPos);
			}
		}

		public readonly float RemapSpanPosition(float original)
		{
			if (Approx(original, Before.SpanRange.x))
			{
				return After.SpanRange.x;
			}
			if (original < Before.SpanRange.x)
			{
				return original;
			}
			if (Approx(original, Before.SpanRange.y))
			{
				return After.SpanRange.y;
			}
			if (original < After.SpanRange.y)
			{
				return math.remap(Before.SpanRange.x, Before.SpanRange.y, After.SpanRange.x, After.SpanRange.y, original);
			}
			float num = Before.SpanRange.y - Before.SpanRange.x;
			float num2 = After.SpanRange.y - After.SpanRange.x;
			return original + (num2 - num);
		}

		internal static bool Approx(float a, float b)
		{
			return math.abs(a - b) <= 0.0001f;
		}
	}
}
