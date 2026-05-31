using System.Collections.Generic;
using UnityEngine;

public class HotAirStation : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => (l != 0) ? 2 : 5, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseResearchAttribute CanMoveLeftAttribute = new BaseResearchAttribute("CanMoveLeft", () => 350, () => true);

		public BaseMoneyAttribute CanMoreBaloonAttribute = new BaseMoneyAttribute("CanMoreBaloon", () => 9000, () => true);

		public BaseResearchAttribute CanBaloonMakeCloudAttribute = new BaseResearchAttribute("CanBaloonMakeCloud", () => 450, () => true);

		public BaseMoneyAttribute CanStrongerFanAttribute = new BaseMoneyAttribute("CanStrongerFan", () => 25000, () => true);

		public BaseMoneyAttribute CanStrongerFan2Attribute = new BaseMoneyAttribute("CanStrongerFan2", () => 50000, () => true);

		public BaseResearchLevelAttribute CanBothSideAttribute = new BaseResearchLevelAttribute("CanBothSide", 1, (int l) => 1200, () => true);

		public BaseShardYLevelAttribute CanCompressAttribute = new BaseShardYLevelAttribute("CanCompress", 3, (int l) => 4, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanMoveLeftAttribute, CanMoreBaloonAttribute, CanBaloonMakeCloudAttribute, CanStrongerFanAttribute, CanBothSideAttribute, CanCompressAttribute, CanStrongerFan2Attribute };
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

	public HotAirStation_MiniGame MiniGame;

	public List<HotAirStation_Entity> HotAirBaloons;

	private LevelHelper _levelHelper = new LevelHelper();

	private float _cycleTimer;

	public GarbageCounter GarbageCounter;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyLevelAttribute HasMoveLeftAttribute = new BaseMoneyLevelAttribute("HasMoveLeft", 5, (int l) => GameController.Instance.AddPrestigeCountTax(500 * (l + 1)), () => GlobalInfo.CanMoveLeftAttribute.IsEnabled);

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.HotAirBaloon;

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		HotAirBaloons[0].Parent = this;
		HotAirBaloons[1].Parent = this;
		HotAirBaloons[0].gameObject.SetActive(value: false);
		HotAirBaloons[1].gameObject.SetActive(value: false);
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
	}

	private void Update()
	{
		MiniGame.AutoDevice = HasAutoDeviceAttribute.IsEnabled;
		_levelHelper.SetIsThrowing(HasThrowOutputAttribute.IsEnabled);
		_levelHelper.SetCanClose(Research.GlobalInfo.CanCloseOutputAttribute.IsEnabled);
		_levelHelper.SetFloorVisibility();
		if (Working.Count <= 0)
		{
			return;
		}
		_cycleTimer -= Time.deltaTime;
		if (_cycleTimer <= 0f)
		{
			if (MiniGame.CurStage == HotAirStation_MiniGame.StageEnum.Part1)
			{
				_cycleTimer += 3f;
				MiniGame.ChangeStage(HotAirStation_MiniGame.StageEnum.Part2);
			}
			else if (MiniGame.CurStage == HotAirStation_MiniGame.StageEnum.Part2)
			{
				_cycleTimer += 1f;
				MiniGame.ChangeStage(HotAirStation_MiniGame.StageEnum.Part3);
			}
			else if (MiniGame.CurStage == HotAirStation_MiniGame.StageEnum.Part3)
			{
				_cycleTimer += 1f;
				MiniGame.ChangeStage(HotAirStation_MiniGame.StageEnum.Ending);
				OutputGarbage();
				MiniGame.ChangeStage(HotAirStation_MiniGame.StageEnum.Part1);
			}
		}
	}

	private void OutputGarbage()
	{
		if (!GameController.Instance.IsHoleFilled() && !GarbageCounter.IsOverLimit)
		{
			ExecutionCount++;
			GlobalInfo.TotalExecutionCount++;
			int num = GetGarbageOutputCount();
			int num2 = Working.Count;
			int num3 = 0;
			int garbageSize = GetGarbageSize();
			if (MiniGame.IsSuccess)
			{
				num *= MINIGAME_AMOUNT_MUL;
				num2 *= MINIGAME_STABILITY_MUL;
			}
			num = AddPowerOutputAmount(num);
			num3 = _levelHelper.OutputGarbage(num, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Balloon, MiniGame.IsSuccess);
			TotalGarbageOut += num3;
			GlobalInfo.TotalGarbageOut += num3;
			if (num3 == 0)
			{
				IncreaseBlockedOutput(1);
				_levelHelper.ShakeWithDust(MiniGame.IsSuccess, GetCloudChance() * (float)BLOCKED_CLOUD_MUL);
				num2 *= BLOCKED_STABILITY_MUL;
			}
			else
			{
				ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.ba_garbage_output, base.transform.position.x);
			}
			num2 = AddPowerStability(num2);
			Stability += num2;
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
		if (Working.Count == 1)
		{
			MiniGame.ChangeStage(HotAirStation_MiniGame.StageEnum.Part1);
			_cycleTimer = 1f;
		}
		SetBaloon();
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		DisplayPeon();
		if (Working.Count == 0)
		{
			MiniGame.ChangeStage(HotAirStation_MiniGame.StageEnum.None);
			_cycleTimer = 0f;
		}
		SetBaloon();
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

	public override void DirectDestroyBuilding()
	{
		HotAirBaloons[0].EmptyStorage();
		HotAirBaloons[1].EmptyStorage();
		base.DirectDestroyBuilding();
	}

	private void SetBaloon()
	{
		if (Working.Count >= 1)
		{
			HotAirBaloons[0].SetActive();
			HotAirBaloons[0].gameObject.SetActive(value: true);
		}
		else
		{
			HotAirBaloons[0].SetInactive();
			HotAirBaloons[0].EmptyStorage();
			HotAirBaloons[0].gameObject.SetActive(value: false);
		}
		if (Working.Count >= 4)
		{
			HotAirBaloons[1].SetActive();
			HotAirBaloons[1].gameObject.SetActive(value: true);
		}
		else
		{
			HotAirBaloons[1].SetInactive();
			HotAirBaloons[1].EmptyStorage();
			HotAirBaloons[1].gameObject.SetActive(value: false);
		}
	}

	public List<GarbageInfo> GetAllStored()
	{
		List<GarbageInfo> list = new List<GarbageInfo>();
		list.AddRange(HotAirBaloons[0]._storedGarbage);
		list.AddRange(HotAirBaloons[1]._storedGarbage);
		return list;
	}

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute> { HasMoveLeftAttribute, HasThrowOutputAttribute, HasAutoDeviceAttribute };
	}

	public int GetGarbageSize()
	{
		int weight = GlobalInfo.GetDefaultGarbageSize() * Level;
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

	public override bool CanIncreaseLevel()
	{
		if (Level >= 6 && !GlobalInfo.CanMoreBaloonAttribute.IsEnabled)
		{
			return false;
		}
		return base.CanIncreaseLevel();
	}
}
