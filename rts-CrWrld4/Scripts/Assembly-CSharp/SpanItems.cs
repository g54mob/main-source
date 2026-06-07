using System.Collections.Generic;
using NBT.Tags;

public class SpanItems
{
	public class SpanItem
	{
		public int x;

		public int y;

		public int page;

		public bool hasSave;

		public SpanItem()
		{
		}

		public SpanItem(int x, int y, int page)
		{
		}

		public bool IsUncovered()
		{
			return false;
		}

		public void ReadData(Tag tag)
		{
		}

		public TagCompound WriteData()
		{
			return null;
		}
	}

	public static bool initialized;

	private static Dictionary<int, SpanItem> spanItems;

	public static int GetUncoveredSpanItemCount(out int[] pageCounts)
	{
		pageCounts = null;
		return 0;
	}

	public static SpanItem GetSpanItemCell(int x, int y, int page)
	{
		return null;
	}

	public static bool AddSpanItem(int x, int y, int page)
	{
		return false;
	}

	public static void SetSpanItemHasSave(int x, int y, int page, bool val, bool deferSave = false)
	{
	}

	public static void ReadData(Tag tag)
	{
	}

	public static TagCompound WriteData()
	{
		return null;
	}
}
