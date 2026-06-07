using NBT.Tags;

public class UpgradeManager
{
	public const int UPGRADE_ENERGY_PRODUCTION = 1;

	public const int UPGRADE_BLUE_PRODUCTION = 2;

	public const int UPGRADE_RED_PRODUCTION = 3;

	public const int UPGRADE_YELLOW_PRODUCTION = 4;

	public const int UPGRADE_BUILD_SPEED = 5;

	public const int UPGRADE_MOVE_SPEED = 6;

	public const int UPGRADE_FIRE_RANGE = 7;

	public const int UPGRADE_FIRE_RATE = 8;

	public const int UPGRADE_COUNT = 8;

	private int[] purchasedTimes;

	private int[] levels;

	public static int EFFICIENCY_TIME;

	public static UpgradeManager instance;

	public int GetLevel(int tech)
	{
		return 0;
	}

	public int GetPurchasedTime(int tech)
	{
		return 0;
	}

	public int GetPurchasedTimeDelta(int tech)
	{
		return 0;
	}

	public float GetEfficiency(int tech)
	{
		return 0f;
	}

	public bool CanPurchase(int tech)
	{
		return false;
	}

	public bool Purchase(int tech)
	{
		return false;
	}

	public bool ReturnPurchase(int tech)
	{
		return false;
	}

	public void ReadData(Tag baseTag)
	{
	}

	public void WriteData(TagCompound baseTag)
	{
	}
}
