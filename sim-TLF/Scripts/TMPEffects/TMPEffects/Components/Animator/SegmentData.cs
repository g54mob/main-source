using System;
using System.Collections.Generic;
using TMPEffects.CharacterData;
using TMPEffects.Tags;
using UnityEngine;

namespace TMPEffects.Components.Animator
{
	public readonly struct SegmentData : ITMPSegmentData
	{
		public readonly int effectiveLength;

		public readonly int firstVisibleIndex;

		public readonly int lastVisibleIndex;

		public readonly int firstAnimationIndex;

		public readonly int lastAnimationIndex;

		private readonly IList<CharData> charDatas;

		public int StartIndex { get; }

		public int Length { get; }

		public int EndIndex { get; }

		public IEnumerable<CharData.Info> CharInfo
		{
			get
			{
				for (int i = StartIndex; i < EndIndex; i++)
				{
					yield return charDatas[i].info;
				}
			}
		}

		public CharData.Info GetCharInfo(int segmentIndex)
		{
			if (segmentIndex > Length)
			{
				throw new ArgumentOutOfRangeException("segmentIndex");
			}
			return charDatas[segmentIndex + StartIndex].info;
		}

		public int IndexToSegmentIndex(int index)
		{
			index -= StartIndex;
			if (index < 0 || index >= Length)
			{
				return -1;
			}
			return index;
		}

		public int SegmentIndexOf(CharData cData)
		{
			return IndexToSegmentIndex(cData.info.index);
		}

		public SegmentData(TMPEffectTagIndices indices, IList<CharData> cData, Predicate<char> animates)
		{
			StartIndex = indices.StartIndex;
			Length = indices.Length;
			EndIndex = indices.EndIndex;
			firstVisibleIndex = -1;
			lastVisibleIndex = -1;
			firstAnimationIndex = -1;
			lastAnimationIndex = -1;
			int num = Mathf.Min(cData.Count, StartIndex + Length);
			for (int i = StartIndex; i < num; i++)
			{
				if (cData[i].info.isVisible)
				{
					if (firstVisibleIndex == -1)
					{
						firstVisibleIndex = i;
					}
					if (animates(cData[i].info.character))
					{
						firstAnimationIndex = i;
						break;
					}
				}
			}
			for (int num2 = num - 1; num2 >= StartIndex; num2--)
			{
				if (cData[num2].info.isVisible)
				{
					if (lastVisibleIndex == -1)
					{
						lastVisibleIndex = num2;
					}
					if (animates(cData[num2].info.character))
					{
						lastAnimationIndex = num2;
						break;
					}
				}
			}
			effectiveLength = lastAnimationIndex - firstAnimationIndex + 1;
			charDatas = cData;
		}
	}
}
