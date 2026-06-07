using System.Collections.Generic;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public struct WingSliceChange
	{
		public float2 ChordRangeAfter;

		public float2 ChordRangeBefore;

		public float? RootwardsSpanPos;

		public float2? RootwardsChordRange;

		public float? TipwardsSpanPos;

		public float2? TipwardsChordRange;

		public float SliceSpanPos;

		public void LoadBefore(IList<InputWingSlice> allSlices, int idx)
		{
			ChordRangeBefore = GetChordRange(allSlices[idx], allSlices, idx);
			SliceSpanPos = allSlices[idx].Position;
			if (idx != 0)
			{
				RootwardsSpanPos = allSlices[idx - 1].Position;
				RootwardsChordRange = GetChordRange(allSlices[idx - 1], allSlices, idx - 1);
			}
			else
			{
				RootwardsSpanPos = null;
				RootwardsChordRange = null;
			}
			if (idx != allSlices.Count - 1)
			{
				TipwardsSpanPos = allSlices[idx + 1].Position;
				TipwardsChordRange = GetChordRange(allSlices[idx + 1], allSlices, idx + 1);
			}
			else
			{
				TipwardsSpanPos = null;
				TipwardsChordRange = null;
			}
		}

		public void LoadAfter(IList<InputWingSlice> allSlices, int idx)
		{
			ChordRangeAfter = GetChordRange(allSlices[idx], allSlices, idx);
		}

		public float RemapChord(float spanPos, float chordPos)
		{
			if (RootwardsSpanPos.HasValue && (spanPos < RootwardsSpanPos.Value || WingSectionChange.Approx(spanPos, RootwardsSpanPos.Value)))
			{
				return chordPos;
			}
			if (WingSectionChange.Approx(SliceSpanPos, spanPos))
			{
				return Remap(ChordRangeBefore, ChordRangeAfter);
			}
			if (spanPos < SliceSpanPos)
			{
				if (RootwardsSpanPos.HasValue)
				{
					float t = math.unlerp(RootwardsSpanPos.Value, SliceSpanPos, spanPos);
					return Remap(math.lerp(RootwardsChordRange.Value, ChordRangeBefore, t), math.lerp(RootwardsChordRange.Value, ChordRangeAfter, t));
				}
				return Remap(ChordRangeBefore, ChordRangeAfter);
			}
			if (TipwardsSpanPos.HasValue && spanPos < TipwardsSpanPos.Value && !WingSectionChange.Approx(spanPos, TipwardsSpanPos.Value))
			{
				float t2 = math.unlerp(SliceSpanPos, TipwardsSpanPos.Value, spanPos);
				return Remap(math.lerp(ChordRangeBefore, TipwardsChordRange.Value, t2), math.lerp(ChordRangeAfter, TipwardsChordRange.Value, t2));
			}
			return chordPos;
			float Remap(float2 beforeChord, float2 afterChord)
			{
				return math.remap(beforeChord.x, beforeChord.y, afterChord.x, afterChord.y, chordPos);
			}
		}

		internal static float2 GetChordRange(InputWingSlice slice, IList<InputWingSlice> allSlices, int idx)
		{
			if (!slice.UseScale)
			{
				WingBuilder.InterpolateScale(idx, allSlices);
			}
			if (!slice.UseOffset)
			{
				WingBuilder.InterpolateOffset(idx, allSlices);
			}
			float num = slice.Scale * 0.5f;
			return math.float2(slice.Offset - num, slice.Offset + num);
		}
	}
}
