using System.Collections.Generic;
using UnityEngine;

public class Power : BaseBuildingWorker
{
	public enum PowerIncreaseType
	{
		OutputWeight = 0,
		OutputAmount = 1,
		StabilityDown = 2,
		StabilityStop = 3,
		FasterPeon = 4,
		MoreCloud = 5,
		MoreRP_TP = 6
	}

	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => (l != 0) ? 2 : 4, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseResearchLevelAttribute CanPrestigeRemoveStabilityAttribute = new BaseResearchLevelAttribute("CanPrestigeRemoveStability", 5, (int l) => 500 + 100 * l, () => true);

		public BaseMoneyLevelAttribute CanMoreManualDestroyAttribute = new BaseMoneyLevelAttribute("CanMoreManualDestroy", 5, (int l) => 200 + 200 * l, () => true);

		public BaseMoneyLevelAttribute CanMoreStabilityDestroyAttribute = new BaseMoneyLevelAttribute("CanMoreStabilityDestroy", 5, (int l) => 1000 + 2000 * l, () => true);

		public BaseShardBLevelAttribute CanLightningGarbageAttribute = new BaseShardBLevelAttribute("CanLightningGarbage", 1, (int l) => 1, () => true);

		public BaseMoneyLevelAttribute CanMorePrestigeAttribute = new BaseMoneyLevelAttribute("CanMorePrestige", 5, (int l) => 500 + 1500 * l, () => true);

		public BaseShardYLevelAttribute CanBuildingLessCostAttribute = new BaseShardYLevelAttribute("CanBuildingLessCost", 1, (int l) => 2, () => true);

		public BaseShardYLevelAttribute CanHaveMoreRangeAttribute = new BaseShardYLevelAttribute("CanHaveMoreRange", 1, (int l) => 2, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanPrestigeRemoveStabilityAttribute, CanMoreManualDestroyAttribute, CanMoreStabilityDestroyAttribute, CanLightningGarbageAttribute, CanMorePrestigeAttribute, CanBuildingLessCostAttribute, CanHaveMoreRangeAttribute };
		}

		public override bool CanBuild()
		{
			return LevelUpAttribute.IsEnabled;
		}

		public override int MaxBuilding()
		{
			return LevelUpAttribute.Level;
		}

		public override bool CanLowerCost()
		{
			return CanLowerCostAttribute.IsEnabled;
		}

		public int GetDefaultOutputPerCycle()
		{
			return 1 + StabilityLevel;
		}

		public int GetDefaultGarbageSize()
		{
			return 1;
		}
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public List<GameObject> Pipes;

	public GameObject InputLocation;

	public Power_MiniGame MiniGame;

	public TestExplosion TestCircle;

	public Circle2 Circle2;

	private LevelHelper _levelHelper = new LevelHelper();

	private float _cycleTime;

	public List<GameObject> LightningStart;

	public GameObject LigntningTemplate;

	public List<GameObject> Lightning;

	private int _cahcedLightningCount;

	public GarbageCounter GarbageCounter;

	private List<PowerIncreaseType> _powerSelected = new List<PowerIncreaseType>();

	public const float BONUS_OUTPUTWEIGHT = 0.5f;

	public const float BONUS_OUTPUTAMOUNT = 1f;

	public const float BONUS_STABILITYDOWN = 0.5f;

	public const float BONUS_STABILITYSTOP = 1f;

	public const float BONUS_FASTERPEON = 0.5f;

	public const float BONUS_MORECLOUD = 0.25f;

	public const float BONUS_MORERPTP = 1f;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyAttribute HasIncreaseRangeAttribute = new BaseMoneyAttribute("HasIncreaseRange", () => GameController.Instance.AddPrestigeCountTax(1500), () => true);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Power;

	public override int GetLevel()
	{
		return Level;
	}

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		MiniGame.SetParent(this);
		BuildingInfos[0].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[0].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[0].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[1].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[1].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[1].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[2].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[2].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[2].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[3].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[3].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[3].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[4].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[4].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[4].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		foreach (GameObject item in Lightning)
		{
			item.SetActive(value: false);
		}
	}

	private void Update()
	{
		MiniGame.AutoDevice = HasAutoDeviceAttribute.IsEnabled;
		_levelHelper.SetIsThrowing(HasThrowOutputAttribute.IsEnabled);
		_levelHelper.SetCanClose(Research.GlobalInfo.CanCloseOutputAttribute.IsEnabled);
		_levelHelper.SetFloorVisibility();
		if (Working.Count > 0)
		{
			_cycleTime += Time.deltaTime;
			if (_cycleTime >= 5f)
			{
				_cycleTime -= 5f;
				if (!GameController.Instance.IsHoleFilled())
				{
					MiniGame.ChangeStage(Power_MiniGame.StageEnum.Ending);
					ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_power_pulse, base.transform.position.x);
					Circle2.RunExplosion();
					OutputGarbage();
					if (GlobalInfo.CanLightningGarbageAttribute.IsEnabled)
					{
						LaunchLigntning();
					}
					MiniGame.ChangeStage(Power_MiniGame.StageEnum.Part1);
					ExecutionCount++;
					GlobalInfo.TotalExecutionCount++;
				}
			}
		}
		if (!GlobalInfo.CanLightningGarbageAttribute.IsEnabled || _cahcedLightningCount == Working.Count)
		{
			return;
		}
		_cahcedLightningCount = Working.Count;
		for (int i = 0; i < Lightning.Count; i++)
		{
			if (i < _cahcedLightningCount)
			{
				Lightning[i].SetActive(value: true);
			}
			else
			{
				Lightning[i].SetActive(value: false);
			}
		}
	}

	private void OutputGarbage()
	{
		if (!GameController.Instance.IsHoleFilled() && !GarbageCounter.IsOverLimit)
		{
			int num = GetGarbageOutputCount();
			int garbageSize = GetGarbageSize();
			int num2 = 0;
			int num3 = Working.Count;
			if (MiniGame.IsSuccess)
			{
				num *= MINIGAME_AMOUNT_MUL;
				num3 *= MINIGAME_STABILITY_MUL;
			}
			num = AddPowerOutputAmount(num);
			num2 = _levelHelper.OutputGarbage(num, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Power, MiniGame.IsSuccess);
			TotalGarbageOut += num2;
			GlobalInfo.TotalGarbageOut += num2;
			if (num2 == 0)
			{
				IncreaseBlockedOutput(1);
				_levelHelper.ShakeWithDust(MiniGame.IsSuccess, GetCloudChance() * (float)BLOCKED_CLOUD_MUL);
				num3 *= BLOCKED_STABILITY_MUL;
			}
			else
			{
				ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.ba_garbage_output, base.transform.position.x);
			}
			num3 = AddPowerStability(num3);
			Stability += num3;
		}
	}

	private void LaunchLigntning()
	{
		List<Garbage> list = GameController.Instance.GarbageController.FindRandomInRangeNotZap(base.gameObject.transform.position.x - 7f, base.gameObject.transform.position.x + 7f, Working.Count);
		if (list.Count > 0)
		{
			ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_zap, base.transform.position.x);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].SetAsZap();
				GameObject obj = Object.Instantiate(LigntningTemplate, base.transform.parent);
				obj.GetComponent<Lightning>().SetPosition(LightningStart[i].transform.position, list[i].transform.position);
				obj.GetComponent<Lightning>().StartLigning();
			}
		}
	}

	public override int GetMaximumWorker()
	{
		return UpgradeLevelToBuildingLevel() + 1;
	}

	public override Vector3 GetEnterLocation()
	{
		return DoorLocation.transform.position;
	}

	public override void EnterBuilding(CharV2 c)
	{
		base.EnterBuilding(c);
		DisplayPeon();
		if (Working.Count > 0)
		{
			MiniGame.ChangeStage(Power_MiniGame.StageEnum.Part1);
		}
		GameController.Instance.ColumnsController.UpdateColumnUpdatedByPower();
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		DisplayPeon();
		if (Working.Count == 0)
		{
			_cycleTime = 0f;
			MiniGame.ChangeStage(Power_MiniGame.StageEnum.None);
		}
		while (_powerSelected.Count > Working.Count)
		{
			_powerSelected.RemoveAt(_powerSelected.Count - 1);
		}
		GameController.Instance.ColumnsController.UpdateColumnUpdatedByPower();
	}

	public void DisplayPeon()
	{
		int count = Working.Count;
		for (int i = 0; i < 5; i++)
		{
			if (i < count)
			{
				BuildingInfos[i].PeonEnter();
			}
			else
			{
				BuildingInfos[i].PeonExit();
			}
		}
	}

	public bool AddPowerWorker(PowerIncreaseType type)
	{
		if (_powerSelected.Count < Working.Count)
		{
			_powerSelected.Add(type);
			return true;
		}
		return false;
	}

	public bool RemovePowerWorker(PowerIncreaseType type)
	{
		if (_powerSelected.Contains(type))
		{
			_powerSelected.Remove(type);
			return true;
		}
		return false;
	}

	public int GetPowerLevel(PowerIncreaseType type)
	{
		int num = 0;
		for (int i = 0; i < _powerSelected.Count; i++)
		{
			if (_powerSelected[i] == type)
			{
				num++;
			}
		}
		return num;
	}

	public float GetPowerAmountValue(PowerIncreaseType type)
	{
		float num = 0f;
		for (int i = 0; i < _powerSelected.Count; i++)
		{
			if (_powerSelected[i] == type)
			{
				switch (type)
				{
				case PowerIncreaseType.OutputWeight:
					num += 0.5f;
					break;
				case PowerIncreaseType.OutputAmount:
					num += 1f;
					break;
				case PowerIncreaseType.StabilityDown:
					num += 0.5f;
					break;
				case PowerIncreaseType.StabilityStop:
					num += 1f;
					break;
				case PowerIncreaseType.FasterPeon:
					num += 0.5f;
					break;
				case PowerIncreaseType.MoreCloud:
					num += 0.25f;
					break;
				case PowerIncreaseType.MoreRP_TP:
					num += 1f;
					break;
				}
			}
		}
		return num;
	}

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute> { HasThrowOutputAttribute, HasIncreaseRangeAttribute, HasAutoDeviceAttribute };
	}

	public int GetGarbageSize()
	{
		int weight = Level * GlobalInfo.GetDefaultGarbageSize();
		return AddPowerOutputWeight(weight);
	}

	public int GetGarbageOutputCount()
	{
		return GlobalInfo.GetDefaultOutputPerCycle();
	}

	public float GetCloudChance()
	{
		return AddPowerMoreCloud(GameController.Instance.GetCloudChance() * (float)Workers.Count);
	}

	public List<BaseMoneyAttribute> GetAttributes()
	{
		return new List<BaseMoneyAttribute>();
	}
}
