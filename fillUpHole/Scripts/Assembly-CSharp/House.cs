using System.Collections.Generic;
using UnityEngine;

public class House : BaseBuildingOnDemand
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => 2, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseResearchLevelAttribute CanHaveMorePeopleAttribute = new BaseResearchLevelAttribute("CanHaveMorePeople", 3, (int l) => 250 * (l + 1), () => true);

		public BaseResearchLevelAttribute CanProduceOnButtonAttribute = new BaseResearchLevelAttribute("CanProduceOnButton", 4, (int l) => 50 + l * 250, () => true);

		public BaseMoneyLevelAttribute CanHappyLongerAttribute = new BaseMoneyLevelAttribute("CanHappyLonger", 5, (int l) => 200 * (l + 1), () => true);

		public BaseMoneyLevelAttribute CanNormalLongerAttribute = new BaseMoneyLevelAttribute("CanNormalLonger", 5, (int l) => 150 * (l + 1), () => true);

		public BaseMoneyLevelAttribute CanInitialMaxPeonAttribute = new BaseMoneyLevelAttribute("CanInitialMaxPeon", 5, (int l) => 2000 * (l + 1), () => true);

		public BaseShardYLevelAttribute CanHalfPeonCostAttribute = new BaseShardYLevelAttribute("CanHalfPeonCost", 5, (int l) => 2, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanHaveMorePeopleAttribute, CanProduceOnButtonAttribute, CanHappyLongerAttribute, CanNormalLongerAttribute, CanInitialMaxPeonAttribute, CanHalfPeonCostAttribute };
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

		public int GetDefaultMaxPeonPerFloor()
		{
			if (CanHaveMorePeopleAttribute.IsEnabled)
			{
				return 3 + CanHaveMorePeopleAttribute.Level;
			}
			return 3;
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

	public House_MiniGame MiniGame;

	private float _timeUntilFire;

	private int _cycleCount;

	private List<int> _exitCycle = new List<int>();

	private int _buttonOpening;

	private LevelHelper _levelHelper = new LevelHelper();

	public GameObject HouseObject1;

	public GameObject HouseObject2;

	public GameObject HouseObject3;

	public GameObject HouseObject4;

	public GameObject HouseObject5;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.House;

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		MiniGame.SetParent(this);
		BuildingInfos[0].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[0].Peon.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		BuildingInfos[0].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[1].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[1].Peon.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
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
		HouseObject1.SetActive(value: false);
		HouseObject2.SetActive(value: false);
		HouseObject3.SetActive(value: false);
		HouseObject4.SetActive(value: false);
		HouseObject5.SetActive(value: false);
	}

	private void Update()
	{
		MiniGame.AutoDevice = HasAutoDeviceAttribute.IsEnabled;
		_levelHelper.SetIsThrowing(HasThrowOutputAttribute.IsEnabled);
		_levelHelper.SetCanClose(Research.GlobalInfo.CanCloseOutputAttribute.IsEnabled);
		_levelHelper.SetFloorVisibility();
		MiniGame.SetMainColor(Color.white);
		if (Working.Count > 0)
		{
			_timeUntilFire += Time.deltaTime;
			if (_timeUntilFire >= 1f && _buttonOpening == 0)
			{
				_buttonOpening = 1;
				MiniGame.ChangeStage(House_MiniGame.StageEnum.Part1);
				if (CanOutputOnButton(_buttonOpening))
				{
					OutputGarbage();
				}
			}
			else if (_timeUntilFire >= 2f && _buttonOpening == 1)
			{
				_buttonOpening = 2;
				MiniGame.ChangeStage(House_MiniGame.StageEnum.Part2);
				if (CanOutputOnButton(_buttonOpening))
				{
					OutputGarbage();
				}
			}
			else if (_timeUntilFire >= 3f && _buttonOpening == 2)
			{
				_buttonOpening = 3;
				MiniGame.ChangeStage(House_MiniGame.StageEnum.Part3);
				if (CanOutputOnButton(_buttonOpening))
				{
					OutputGarbage();
				}
			}
			else if (_timeUntilFire >= 4f && _buttonOpening == 3)
			{
				_buttonOpening = 4;
				MiniGame.ChangeStage(House_MiniGame.StageEnum.Part4);
				if (CanOutputOnButton(_buttonOpening))
				{
					OutputGarbage();
				}
			}
			else if (_timeUntilFire >= 5f)
			{
				MiniGame.ChangeStage(House_MiniGame.StageEnum.Ending);
				OutputGarbage();
				MiniGame.ChangeStage(House_MiniGame.StageEnum.None);
				_cycleCount++;
				_timeUntilFire = 0f;
				_buttonOpening = 0;
				if (_exitCycle[0] <= _cycleCount)
				{
					ExitBuilding(Working[0]);
				}
			}
		}
		if (!HouseObject2.activeSelf && GlobalInfo.CanNormalLongerAttribute.Level > 0)
		{
			HouseObject2.SetActive(value: true);
		}
		if (!HouseObject3.activeSelf && GlobalInfo.CanInitialMaxPeonAttribute.Level > 0)
		{
			HouseObject3.SetActive(value: true);
		}
		if (!HouseObject4.activeSelf && GlobalInfo.CanHappyLongerAttribute.Level > 0)
		{
			HouseObject4.SetActive(value: true);
		}
	}

	public override int GetMaximumWorker()
	{
		return UpgradeLevelToBuildingLevel() + 1;
	}

	private void OutputGarbage()
	{
		if (!GameController.Instance.IsHoleFilled())
		{
			ExecutionCount++;
			GlobalInfo.TotalExecutionCount++;
			int num = 0;
			int num2 = GetGarbageOutputCount();
			int garbageSize = GetGarbageSize();
			int num3 = Working.Count;
			if (MiniGame.IsSuccess)
			{
				num2 *= MINIGAME_AMOUNT_MUL;
				num3 *= MINIGAME_STABILITY_MUL;
			}
			num2 = AddPowerOutputAmount(num2);
			num = _levelHelper.OutputGarbage(num2, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.House, MiniGame.IsSuccess);
			IncreaseTotalOutput(num);
			if (num == 0)
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

	public override Vector3 GetEnterLocation()
	{
		return DoorLocation.transform.position;
	}

	public override void EnterBuilding(CharV2 c)
	{
		base.EnterBuilding(c);
		DisplayPeon();
		if (_exitCycle.Count == 0)
		{
			_timeUntilFire = 0f;
			_cycleCount = 0;
		}
		int num = 3;
		_exitCycle.Add(_cycleCount + num);
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		c.SetMaxHapiness();
		DisplayPeon();
		if (Working.Count < _exitCycle.Count)
		{
			_exitCycle.RemoveAt(0);
		}
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

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute> { HasThrowOutputAttribute, HasAutoDeviceAttribute };
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

	public bool CanOutputOnButton(int buttonId)
	{
		return buttonId switch
		{
			1 => GlobalInfo.CanProduceOnButtonAttribute.Level >= 1, 
			2 => GlobalInfo.CanProduceOnButtonAttribute.Level >= 2, 
			3 => GlobalInfo.CanProduceOnButtonAttribute.Level >= 3, 
			4 => GlobalInfo.CanProduceOnButtonAttribute.Level >= 4, 
			_ => false, 
		};
	}
}
