using System.Collections.Generic;

public class WaresManager
{
	public class WareDef
	{
		public string name;

		public int wareNum;

		public Dictionary<int, int> requiredWares;

		public WareDef(string name, int wareNum, Dictionary<int, int> requiredWares)
		{
		}
	}

	public const int WAREDEF_MAX_COUNT = 50;

	public const int WAREDEF_START_WARES = 28;

	private WareDef[] wareDefs;

	private Dictionary<int, int> wareNeeds;

	public const int WARE_BLUITE = 0;

	public const int WARE_REDON = 1;

	public const int WARE_GREENAR = 2;

	public const int WARE_ANTICREEPER = 28;

	public const int WARE_ARG = 29;

	public const int WARE_LIFTIC = 30;

	public const int WARE_RESISTIUM = 31;

	public const int WARE_FLUXYGEN = 32;

	public const int WARE_TUFFIUM = 33;

	public static int GetRPLTranslatedWareType(int wareNum)
	{
		return 0;
	}

	public void SetWareDef(int num, string name, Dictionary<int, int> requiredWares)
	{
	}

	public WareDef GetWareDef(int num)
	{
		return null;
	}

	public int GetWareNumFromName(string wareName)
	{
		return 0;
	}

	public List<WareDef> GetWaresForResource(int resource)
	{
		return null;
	}

	public List<WareDef> GetWares(bool includeResources)
	{
		return null;
	}
}
