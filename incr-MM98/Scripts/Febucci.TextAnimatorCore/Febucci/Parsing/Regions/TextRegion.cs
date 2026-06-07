using System;
using System.Text;
using Febucci.Numbers;

namespace Febucci.Parsing.Regions
{
	public class TextRegion<T>
	{
		public readonly string tagId;

		public TagRange[] ranges;

		public readonly T data;

		public TextRegion(string tagId)
		{
			this.tagId = tagId;
			ranges = Array.Empty<TagRange>();
		}

		public TextRegion(string tagId, T data, params TagRange[] ranges)
		{
			this.tagId = tagId;
			this.data = data;
			this.ranges = ranges;
		}

		public TextRegion(string tagId, T data)
		{
			this.tagId = tagId;
			this.data = data;
			ranges = Array.Empty<TagRange>();
		}

		public TextRegion(string tagId, params TagRange[] ranges)
		{
			this.tagId = tagId;
			this.ranges = ranges;
		}

		public TextRegion(string tagId, params Vector2Int[] ranges)
		{
			this.tagId = tagId;
			int num = tagId.Length + 2;
			this.ranges = new TagRange[ranges.Length];
			for (int i = 0; i < this.ranges.Length; i++)
			{
				this.ranges[i] = new TagRange(ranges[i], new RegionParameters());
			}
		}

		public void OpenNewRange(int startIndex)
		{
			OpenNewRange(startIndex, Array.Empty<string>());
		}

		public void OpenNewRange(int startIndex, RegionParameters parameters)
		{
			int num = ranges.Length;
			if (num > 0)
			{
				TagRange tagRange = ranges[num - 1];
				if (tagRange.indexes.Y == int.MaxValue && parameters.Equals(tagRange.parameters))
				{
					return;
				}
			}
			Array.Resize(ref ranges, num + 1);
			TagRange tagRange2 = new TagRange(new Vector2Int(startIndex, int.MaxValue), parameters);
			ranges[ranges.Length - 1] = tagRange2;
		}

		public void OpenNewRange(int startIndex, string[] tagWords)
		{
			OpenNewRange(startIndex, new RegionParameters(tagWords));
		}

		public bool TryClosingRange(int endIndex)
		{
			if (ranges.Length == 0)
			{
				return false;
			}
			for (int num = ranges.Length - 1; num >= 0; num--)
			{
				if (ranges[num].indexes.Y == int.MaxValue)
				{
					TagRange tagRange = ranges[num];
					tagRange.indexes.Y = endIndex;
					ranges[num] = tagRange;
					return true;
				}
			}
			return false;
		}

		public void CloseAllOpenedRanges(int endIndex)
		{
			if (ranges.Length == 0)
			{
				return;
			}
			for (int num = ranges.Length - 1; num >= 0; num--)
			{
				if (ranges[num].indexes.Y == int.MaxValue)
				{
					TagRange tagRange = ranges[num];
					tagRange.indexes.Y = endIndex;
					ranges[num] = tagRange;
				}
			}
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("tag: ");
			stringBuilder.Append(tagId);
			if (ranges.Length == 0)
			{
				stringBuilder.Append("\nNo ranges");
			}
			else
			{
				for (int i = 0; i < ranges.Length; i++)
				{
					stringBuilder.Append('\n');
					stringBuilder.Append(ranges[i]);
				}
			}
			return stringBuilder.ToString();
		}
	}
}
