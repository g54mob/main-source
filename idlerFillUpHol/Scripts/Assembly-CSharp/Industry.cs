using System.Collections.Generic;
using UnityEngine;

public class Industry : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => 2, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseMoneyLevelAttribute CanBulldozerCloudAttribute = new BaseMoneyLevelAttribute("CanBulldozerCloud", 1, (int l) => 1500, () => true);

		public BaseResearchLevelAttribute CanLastCycleMoreOutputAttribute = new BaseResearchLevelAttribute("CanLastCycleMoreOutput", 5, (int l) => 200 + 100 * l, () => true);

		public BaseMoneyLevelAttribute CanAllMoreOutputAttribute = new BaseMoneyLevelAttribute("CanAllMoreOutput", 5, (int l) => 5000 * (l + 1), () => true);

		public BaseResearchLevelAttribute CanAllCanGenerateMediumAttribute = new BaseResearchLevelAttribute("CanAllCanGenerateMedium", 1, (int l) => 2000, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanBulldozerCloudAttribute, CanLastCycleMoreOutputAttribute, CanAllMoreOutputAttribute, CanAllCanGenerateMediumAttribute };
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
			return 1 + StabilityLevel + CanAllMoreOutputAttribute.Level;
		}

		public int GetDefaultOutputPer10Cycle()
		{
			return 10 + StabilityLevel + 5 * CanLastCycleMoreOutputAttribute.Level;
		}

		public int GetDefaultGarbageSize()
		{
			return 1;
		}
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public Industry_MiniGame MiniGame;

	public Industry_Vertical VerticalBars;

	public GameObject ProgressBar;

	public GarbageCounter GarbageCounter;

	private float _timeUntilFire;

	private int _generationCount;

	private LevelHelper _levelHelper = new LevelHelper();

	private float _oneBarTime = 3f;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Industry;

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		VerticalBars.SetBarVisibility(0);
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
		if (MiniGame.IsSuccess)
		{
			VerticalBars.SetBarColor(GameController.EvilColor);
		}
		else
		{
			VerticalBars.SetBarColor(Color.white);
		}
		if (Working.Count <= 0 || GameController.Instance.IsHoleFilled() || GarbageCounter.IsOverLimit)
		{
			return;
		}
		_timeUntilFire += Time.deltaTime;
		float num = _timeUntilFire / _oneBarTime;
		if (num < 0f)
		{
			num = 0f;
		}
		if (num > 1f)
		{
			num = 1f;
		}
		ProgressBar.transform.localScale = new Vector3(num, 1f, 1f);
		if (_timeUntilFire >= _oneBarTime)
		{
			int num2 = 0;
			int num3 = Working.Count;
			if (_generationCount == 10)
			{
				_generationCount = 0;
				num2 = GlobalInfo.GetDefaultOutputPer10Cycle();
			}
			else
			{
				num2 = GetGarbageOutputCount();
			}
			MiniGame.ChangeStage(Industry_MiniGame.StageEnum.Ending);
			if (MiniGame.IsSuccess)
			{
				num2 *= MINIGAME_AMOUNT_MUL;
				num3 *= MINIGAME_STABILITY_MUL;
			}
			int num4 = 0;
			int garbageSize = GetGarbageSize();
			num2 = AddPowerOutputAmount(num2);
			num4 = _levelHelper.OutputGarbage(num2, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Industry, MiniGame.IsSuccess);
			TotalGarbageOut += num4;
			GlobalInfo.TotalGarbageOut += num4;
			if (num4 == 0)
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
			MiniGame.ChangeStage(Industry_MiniGame.StageEnum.None);
			MiniGame.ChangeStage(Industry_MiniGame.StageEnum.Part1);
			Stability += num3;
			ExecutionCount++;
			GlobalInfo.TotalExecutionCount++;
			_timeUntilFire = 0f;
			_generationCount++;
			VerticalBars.SetBarVisibility(_generationCount);
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
		if (Working.Count == 0)
		{
			ParentColumn.LocalSfx2Controller.PlayLoopFromDistance(SoundManager.SoundTypeEnum.bs_factory_working, base.transform.position.x);
		}
		base.EnterBuilding(c);
		DisplayPeon();
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		DisplayPeon();
		if (Working.Count == 0)
		{
			ParentColumn.LocalSfx2Controller.StopLoop();
			MiniGame.ChangeStage(Industry_MiniGame.StageEnum.None);
			VerticalBars.SetBarVisibility(0);
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
}
