using System.Collections.Generic;
using UnityEngine;

public class Helicopter : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => (l != 0) ? 2 : 5, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseResearchAttribute CanDumpRightAttribute = new BaseResearchAttribute("CanDumpRight", () => 350, () => true);

		public BaseResearchAttribute CanOutputLessButMediumAttribute = new BaseResearchAttribute("CanOutputLessButMedium", () => 500, () => true);

		public BaseMoneyAttribute CanMoreHelicopterAttribute = new BaseMoneyAttribute("CanMoreHelicopter", () => 7500, () => true);

		public BaseShardBLevelAttribute CanTransitionAttribute = new BaseShardBLevelAttribute("CanTransition", 1, (int l) => 1, () => true);

		public BaseShardYLevelAttribute CanTransition2Attribute = new BaseShardYLevelAttribute("CanTransition2", 1, (int l) => 4, () => true);

		public BaseResearchAttribute CanTransition3Attribute = new BaseResearchAttribute("CanTransition3", () => 500, () => true);

		public BaseMoneyAttribute CanIncreaseSizeOfGarbageAttribute = new BaseMoneyAttribute("CanIncreaseSizeOfGarbage", () => 99999, () => true);

		public BaseMoneyAttribute CanOutputMoreAttribute = new BaseMoneyAttribute("CanOutputMore", () => 15000, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute>
			{
				LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanDumpRightAttribute, CanOutputLessButMediumAttribute, CanMoreHelicopterAttribute, CanTransitionAttribute, CanTransition2Attribute, CanTransition3Attribute, CanIncreaseSizeOfGarbageAttribute,
				CanOutputMoreAttribute
			};
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

		public int GetHelicopterDropAmount()
		{
			if (CanOutputLessButMediumAttribute.IsEnabled)
			{
				return 5;
			}
			return 20;
		}

		public int GetDefaultOutputPerCycle()
		{
			return 1;
		}

		public int GetDefaultGarbageSize()
		{
			return 1;
		}

		public int GetDefaultHelicopterGarbageSize()
		{
			if (CanOutputLessButMediumAttribute.IsEnabled)
			{
				return GetDefaultGarbageSize() * 5;
			}
			return GetDefaultGarbageSize();
		}
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public List<Helicopter_Entity> HelicopterObjects;

	public Helicopter_MiniGame MiniGame;

	public GarbageCounter GarbageCounter;

	private LevelHelper _levelHelper = new LevelHelper();

	public GameObject MoveRightClose;

	public GameObject MoveRightOpen;

	public List<GameObject> SquareOutputs;

	private bool _cachedIsMoveRight;

	private int _cachedOutput;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyLevelAttribute HasDropNextColumnAttribute = new BaseMoneyLevelAttribute("HasDropNextColumn", 5, (int l) => GameController.Instance.AddPrestigeCountTax(200 * (l + 1)), () => GlobalInfo.CanDumpRightAttribute.IsEnabled);

	public BaseMoneyLevelAttribute HasMoreGarbageAttribute = new BaseMoneyLevelAttribute("HasMoreGarbage", 10, (int l) => GameController.Instance.AddPrestigeCountTax(500 * (l + 1)), () => true);

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Helicopter;

	public override int GetLevel()
	{
		return Level;
	}

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		HelicopterObjects[0].Parent = this;
		HelicopterObjects[1].Parent = this;
		MiniGame.Parent = this;
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
		MoveRightClose.SetActive(value: true);
		MoveRightOpen.SetActive(value: false);
		foreach (GameObject squareOutput in SquareOutputs)
		{
			squareOutput.SetActive(value: false);
		}
	}

	private void Update()
	{
		MiniGame.AutoDevice = HasAutoDeviceAttribute.IsEnabled;
		_levelHelper.SetIsThrowing(HasThrowOutputAttribute.IsEnabled);
		_levelHelper.SetCanClose(Research.GlobalInfo.CanCloseOutputAttribute.IsEnabled);
		_levelHelper.SetFloorVisibility();
		if (!_cachedIsMoveRight && HasDropNextColumnAttribute.Level > 0)
		{
			_cachedIsMoveRight = true;
			MoveRightClose.SetActive(value: false);
			MoveRightOpen.SetActive(value: true);
		}
		if (_cachedOutput == HasMoreGarbageAttribute.Level)
		{
			return;
		}
		_cachedOutput = HasMoreGarbageAttribute.Level;
		for (int i = 0; i < SquareOutputs.Count; i++)
		{
			if (i < _cachedOutput)
			{
				SquareOutputs[i].SetActive(value: true);
			}
			else
			{
				SquareOutputs[i].SetActive(value: false);
			}
		}
	}

	public void MiniGameCompleted()
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
			num2 = _levelHelper.OutputGarbage(num, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Helicopter, MiniGame.IsSuccess);
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
			num3 = num3;
			Stability += num3;
			ExecutionCount++;
			GlobalInfo.TotalExecutionCount++;
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
		SetHelicopter();
		if (Working.Count == 1)
		{
			MiniGame.ChangeStage(Helicopter_MiniGame.StageEnum.Part1);
		}
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		DisplayPeon();
		SetHelicopter();
		if (Working.Count == 0)
		{
			MiniGame.ChangeStage(Helicopter_MiniGame.StageEnum.None);
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

	private void SetHelicopter()
	{
		if (Working.Count >= 1)
		{
			HelicopterObjects[0].SetActive();
		}
		else
		{
			HelicopterObjects[0].SetInactive();
		}
		if (Working.Count >= 3)
		{
			HelicopterObjects[1].SetActive();
		}
		else
		{
			HelicopterObjects[1].SetInactive();
		}
	}

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute> { HasDropNextColumnAttribute, HasMoreGarbageAttribute, HasThrowOutputAttribute, HasAutoDeviceAttribute };
	}

	public int GetGarbageSize()
	{
		int weight = Level * GlobalInfo.GetDefaultGarbageSize();
		return AddPowerOutputWeight(weight);
	}

	public int GetHelicopterGarbageSize()
	{
		int weight = Level * GlobalInfo.GetDefaultHelicopterGarbageSize();
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
		if (Level >= 4 && !GlobalInfo.CanMoreHelicopterAttribute.IsEnabled)
		{
			return false;
		}
		return base.CanIncreaseLevel();
	}

	public int GetHelicopterDropAmount()
	{
		int num = GlobalInfo.GetHelicopterDropAmount() * Working.Count;
		num += 5 * GlobalInfo.StabilityLevel;
		if (HasMoreGarbageAttribute.IsEnabled)
		{
			num += (int)((float)num * (0.5f * (float)HasMoreGarbageAttribute.Level));
		}
		return num;
	}
}
