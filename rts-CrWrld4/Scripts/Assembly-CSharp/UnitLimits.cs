using System.Collections.Generic;

public class UnitLimits
{
	public struct UnitLimitData
	{
		public int limit;

		public int count;

		public UnitLimitData(int limit, int count)
		{
			this.limit = 0;
			this.count = 0;
		}
	}

	private static Dictionary<string, UnitLimitData> uld;

	public static void IncrementUnitCount(string unitName)
	{
	}

	public static void DecrementUnitCount(string unitName)
	{
	}

	public static int GetUnitCount(string unitName)
	{
		return 0;
	}

	public static int GetUnitLimit(string unitName)
	{
		return 0;
	}

	public static void SetUnitCount(string unitName, int limit)
	{
	}

	public static int GetRemainingCount(string unitName)
	{
		return 0;
	}
}
