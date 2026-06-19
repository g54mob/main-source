using System.Collections.Generic;
using TMPEffects.CharacterData;

namespace TMPEffects.Components.Animator
{
	public interface ITMPSegmentData
	{
		int StartIndex { get; }

		int Length { get; }

		int EndIndex { get; }

		IEnumerable<CharData.Info> CharInfo { get; }

		CharData.Info GetCharInfo(int segmentIndex);

		int IndexToSegmentIndex(int index);

		int SegmentIndexOf(CharData cData);
	}
}
