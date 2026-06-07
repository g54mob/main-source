using System.Collections.Generic;
using UnityEngine;

public class Training : BaseBuildingWorker
{
	public enum TrainingEnum
	{
		None = 0,
		Carry = 1,
		Speed = 2,
		Mining = 3,
		ReduceCost = 4
	}

	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => (l != 0) ? 2 : 3, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseResearchAttribute CanFasterPeonAttribute = new BaseResearchAttribute("CanFasterPeon", () => 250, () => true);

		public BaseShardBLevelAttribute CanNoDeathAttribute = new BaseShardBLevelAttribute("CanNoDeath", 1, (int l) => 2, () => true);

		public BaseMoneyLevelAttribute CanMoreTPAttribute = new BaseMoneyLevelAttribute("CanMoreTP", 5, (int l) => 1000 + 4000 * l, () => true);

		public BaseMoneyAttribute CanContentIsHappyAttribute = new BaseMoneyAttribute("CanContentIsHappy", () => 30000, () => true);

		public BaseTrainingAttribute SpeedAttribute = new BaseTrainingAttribute("Speed", 10, (int l) => 50 + GlobalInfo.SpeedAttribute.Level * 50, () => true);

		public BaseTrainingAttribute CarryAttribute = new BaseTrainingAttribute("Carry", 10, (int l) => 150 + GlobalInfo.CarryAttribute.Level * 100, () => true);

		public BaseTrainingAttribute MiningAttribute = new BaseTrainingAttribute("Mining", 10, (int l) => 250 + GlobalInfo.MiningAttribute.Level * 150, () => true);

		public BaseTrainingAttribute ReduceCostAttribute = new BaseTrainingAttribute("ReduceCost", 10, (int l) => 500 + GlobalInfo.MiningAttribute.Level * 200, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute>
			{
				LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanFasterPeonAttribute, CanNoDeathAttribute, CanMoreTPAttribute, CarryAttribute, SpeedAttribute, MiningAttribute, ReduceCostAttribute,
				CanContentIsHappyAttribute
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

		public int GetDefaultOutputPerCycle()
		{
			return 1;
		}

		public int GetDefaultGarbageSize()
		{
			return 1;
		}

		public int GetTPPerWorker()
		{
			return 1 + GlobalInfo.CanMoreTPAttribute.Level;
		}
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public List<GameObject> TopProgress;

	public List<GameObject> BottomProgress;

	public Training_MiniGame MiniGame;

	private float _timeLeft = 5f;

	private TrainingEnum _currentTraining;

	private LevelHelper _levelHelper = new LevelHelper();

	public GarbageCounter GarbageCounter;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Training;

	public TrainingEnum CurrentTraining => _currentTraining;

	public void ChangeCurrentTraining(TrainingEnum newTraining)
	{
		_currentTraining = newTraining;
	}

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		SetBarVisibility();
		MiniGame.SetParent(this);
		BuildingInfos[0].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[0].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
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
		for (int i = 0; i < BottomProgress.Count; i++)
		{
			BottomProgress[i].GetComponent<SpriteRenderer>().color = GameController.EvilColor;
		}
		MiniGame.ChangeStage(Training_MiniGame.StageEnum.None);
	}

	private void Update()
	{
		MiniGame.AutoDevice = HasAutoDeviceAttribute.IsEnabled;
		_levelHelper.SetIsThrowing(HasThrowOutputAttribute.IsEnabled);
		_levelHelper.SetCanClose(Research.GlobalInfo.CanCloseOutputAttribute.IsEnabled);
		_levelHelper.SetFloorVisibility();
		if (Working.Count > 0)
		{
			_timeLeft -= Time.deltaTime;
			if (_timeLeft < 0f)
			{
				MiniGame.ChangeStage(Training_MiniGame.StageEnum.Ending);
				int num = GetTPGained();
				_timeLeft = 5f;
				if (MiniGame.IsSuccess)
				{
					num *= MINIGAME_AMOUNT_MUL;
				}
				if (!GameController.Instance.IsHoleFilled())
				{
					OutputGarbage();
					if (!IsMaxTraining(_currentTraining))
					{
						if (_currentTraining == TrainingEnum.Carry)
						{
							GlobalInfo.CarryAttribute.Amount += num;
							GlobalInfo.CarryAttribute.TryLevelUp();
						}
						else if (_currentTraining == TrainingEnum.Speed)
						{
							GlobalInfo.SpeedAttribute.Amount += num;
							GlobalInfo.SpeedAttribute.TryLevelUp();
						}
						else if (_currentTraining == TrainingEnum.Mining)
						{
							GlobalInfo.MiningAttribute.Amount += num;
							GlobalInfo.MiningAttribute.TryLevelUp();
						}
						else if (_currentTraining == TrainingEnum.ReduceCost)
						{
							GlobalInfo.ReduceCostAttribute.Amount += num;
							GlobalInfo.ReduceCostAttribute.TryLevelUp();
						}
					}
				}
				MiniGame.ChangeStage(Training_MiniGame.StageEnum.None);
				MiniGame.ChangeStage(Training_MiniGame.StageEnum.Part1);
			}
		}
		SetBarVisibility();
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
			num3 = _levelHelper.OutputGarbage(num, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Training, MiniGame.IsSuccess);
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
			num2 = num2;
			Stability += num2;
		}
	}

	public void ToggleTraining(TrainingEnum newTraining)
	{
		if (_currentTraining == newTraining)
		{
			_currentTraining = TrainingEnum.None;
		}
		else
		{
			_currentTraining = newTraining;
		}
	}

	private void SetBarVisibility()
	{
		int num = (int)(10f - _timeLeft / 5f * 10f);
		if (num < 0)
		{
			num = 0;
		}
		if (num >= 9)
		{
			num = 9;
		}
		if (_timeLeft == 5f)
		{
			num = -1;
		}
		for (int i = 0; i < TopProgress.Count; i++)
		{
			if (i <= num)
			{
				TopProgress[i].gameObject.SetActive(value: true);
			}
			else
			{
				TopProgress[i].gameObject.SetActive(value: false);
			}
		}
		num = (int)(MiniGame.ProgressPercentage() * 10f);
		for (int j = 0; j < BottomProgress.Count; j++)
		{
			if (j < num)
			{
				BottomProgress[j].gameObject.SetActive(value: true);
			}
			else
			{
				BottomProgress[j].gameObject.SetActive(value: false);
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
		if (Working.Count == 1)
		{
			MiniGame.ChangeStage(Training_MiniGame.StageEnum.Part1);
		}
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		DisplayPeon();
		if (Working.Count == 0)
		{
			MiniGame.ChangeStage(Training_MiniGame.StageEnum.None);
			_timeLeft = 5f;
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

	public bool IsMaxTraining(TrainingEnum training)
	{
		int num = 0;
		switch (training)
		{
		case TrainingEnum.Carry:
			num = GlobalInfo.CarryAttribute.Level;
			break;
		case TrainingEnum.Speed:
			num = GlobalInfo.SpeedAttribute.Level;
			break;
		case TrainingEnum.Mining:
			num = GlobalInfo.MiningAttribute.Level;
			break;
		case TrainingEnum.ReduceCost:
			num = GlobalInfo.ReduceCostAttribute.Level;
			break;
		}
		if (num >= GetMaxTrainingLevel())
		{
			return true;
		}
		return false;
	}

	public int GetMaxTrainingLevel()
	{
		return GetLevel();
	}

	public override void SetData(Dictionary<string, int> data)
	{
		base.SetData(data);
		if (data.ContainsKey("CurrentTraining"))
		{
			_currentTraining = (TrainingEnum)data["CurrentTraining"];
		}
	}

	public override Dictionary<string, int> GetData()
	{
		Dictionary<string, int> data = base.GetData();
		data.Add("CurrentTraining", (int)_currentTraining);
		return data;
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

	public int GetTPGained()
	{
		int num = Working.Count * GlobalInfo.GetTPPerWorker();
		num += GlobalInfo.StabilityLevel;
		return AddMoreTP_RP(num);
	}
}
