using NBT.Tags;
using UnityEngine;

public class ERNInterface : UnitManager
{
	public const int UPGRADE_ENERGY_PRODUCTION = 0;

	public const int UPGRADE_MINE_PRODUCTION = 1;

	public const int UPGRADE_BUILD_SPEED = 2;

	public const int UPGRADE_MOVE_SPEED = 3;

	public const int UPGRADE_FIRE_RANGE = 4;

	public const int UPGRADE_FIRE_RATE = 5;

	public const int UPGRADE_COUNT = 6;

	public static int EFFICIENCY_TIME;

	private ERN[] upgradeSlots;

	private int[] dockedTimes;

	public override string officialName => null;

	public override void Awake()
	{
	}

	public override void Start()
	{
	}

	public void CreateMVerseUnit()
	{
	}

	public override void Update()
	{
	}

	public override void GameUpdate()
	{
	}

	public override Vector3 GetERNDockLocation(ERN ern)
	{
		return default(Vector3);
	}

	public override void ERNDocked(ERN ern)
	{
	}

	public void Reset()
	{
	}

	public void AssignERN(int upgradeItem)
	{
	}

	public void ReleaseERN(int upgradeItem)
	{
	}

	private int GetERNSlot(ERN ern)
	{
		return 0;
	}

	public bool IsUpgradeAvailable(int upgradeItem)
	{
		return false;
	}

	public bool IsUpgradeEnroute(int upgradeItem)
	{
		return false;
	}

	public float GetEff(int tech)
	{
		return 0f;
	}

	public static float GetEfficiency(int tech)
	{
		return 0f;
	}

	public override void BuildComplete()
	{
	}

	public override void DestroyUnit(bool suppressEffects)
	{
	}

	public override void ReadData(Tag data)
	{
	}

	public override void ReadDataLate()
	{
	}

	public override TagCompound WriteData()
	{
		return null;
	}
}
