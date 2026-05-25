using System.Collections.Generic;
using UnityEngine;

public class Drone : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => (l != 0) ? 2 : 5, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseResearchLevelAttribute CanClickPowerIncreaseAttribute = new BaseResearchLevelAttribute("CanClickPowerIncrease", 5, (int l) => 50 * (l + 1), () => true);

		public BaseResearchLevelAttribute CanCloudOutputMoreAttribute = new BaseResearchLevelAttribute("CanCloudOutputMore", 10, (int l) => 200 + 100 * l, () => true);

		public BaseMoneyLevelAttribute CanMoreDroneAttribute = new BaseMoneyLevelAttribute("CanMoreDrone", 2, (int l) => 7500 * (l + 1), () => true);

		public BaseResearchLevelAttribute CanBothSideAttribute = new BaseResearchLevelAttribute("CanBothSide", 1, (int l) => 1200, () => true);

		public BaseShardYLevelAttribute CanCloudOutputBiggerAttribute = new BaseShardYLevelAttribute("CanCloudOutputBigger", 1, (int l) => 3, () => true);

		public BaseResearchLevelAttribute CanStrongerParticleAttribute = new BaseResearchLevelAttribute("CanStrongerParticle", 1, (int l) => 350, () => true);

		public BaseResearchLevelAttribute CanMoreParticleAttribute = new BaseResearchLevelAttribute("CanMoreParticle", 5, (int l) => 500 + l * 100, () => true);

		public BaseResearchLevelAttribute CanCloudMakeRPAttribute = new BaseResearchLevelAttribute("CanCloudMakeRP", 5, (int l) => 500 + 100 * l, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute>
			{
				LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanClickPowerIncreaseAttribute, CanCloudOutputMoreAttribute, CanMoreDroneAttribute, CanBothSideAttribute, CanCloudOutputBiggerAttribute, CanStrongerParticleAttribute, CanCloudMakeRPAttribute,
				CanMoreParticleAttribute
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

		public int GetParticlesStrength()
		{
			int num = 1;
			if (CanStrongerParticleAttribute.IsEnabled)
			{
				num++;
			}
			return num;
		}

		public int GetParticlesCount()
		{
			int num = 1;
			if (CanMoreParticleAttribute.IsEnabled)
			{
				num += CanMoreParticleAttribute.Level;
			}
			return num;
		}
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public List<Drone_Entity> Drones;

	public GameObject DroneObject;

	public Drone_MiniGame MiniGame;

	private LevelHelper _levelHelper = new LevelHelper();

	private float _cycleTime;

	public List<GameObject> HorizontalClickPower;

	public List<GameObject> HorizontalCloudOutput;

	private int _cachedClickPower;

	private int _cachedCloudOutput;

	public GarbageCounter GarbageCounter;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Drone;

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		Drones[0].Parent = this;
		Drones[1].Parent = this;
		Drones[2].Parent = this;
		Drones[0].gameObject.SetActive(value: false);
		Drones[1].gameObject.SetActive(value: false);
		Drones[2].gameObject.SetActive(value: false);
		MiniGame.SetParent(this);
		MiniGame.ChangeStage(Drone_MiniGame.StageEnum.None);
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
		foreach (GameObject item in HorizontalClickPower)
		{
			item.SetActive(value: false);
		}
		foreach (GameObject item2 in HorizontalCloudOutput)
		{
			item2.SetActive(value: false);
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
				MiniGame.ChangeStage(Drone_MiniGame.StageEnum.Ending);
				OutputGarbage();
				MiniGame.ChangeStage(Drone_MiniGame.StageEnum.Part1);
				ExecutionCount++;
				GlobalInfo.TotalExecutionCount++;
			}
		}
		if (_cachedClickPower != GlobalInfo.CanClickPowerIncreaseAttribute.Level)
		{
			_cachedClickPower = GlobalInfo.CanClickPowerIncreaseAttribute.Level;
			for (int i = 0; i < HorizontalClickPower.Count; i++)
			{
				if (i < _cachedClickPower)
				{
					HorizontalClickPower[i].SetActive(value: true);
				}
				else
				{
					HorizontalClickPower[i].SetActive(value: false);
				}
			}
		}
		if (_cachedCloudOutput == GlobalInfo.CanCloudOutputMoreAttribute.Level)
		{
			return;
		}
		_cachedCloudOutput = GlobalInfo.CanCloudOutputMoreAttribute.Level;
		for (int j = 0; j < HorizontalCloudOutput.Count; j++)
		{
			if (j < _cachedCloudOutput)
			{
				HorizontalCloudOutput[j].SetActive(value: true);
			}
			else
			{
				HorizontalCloudOutput[j].SetActive(value: false);
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
			num3 = _levelHelper.OutputGarbage(num, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Drone, MiniGame.IsSuccess);
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
			_cycleTime = 0f;
			MiniGame.ChangeStage(Drone_MiniGame.StageEnum.Part1);
		}
		SetDrone();
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		DisplayPeon();
		if (Working.Count == 0)
		{
			_cycleTime = 0f;
			MiniGame.ChangeStage(Drone_MiniGame.StageEnum.None);
		}
		SetDrone();
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

	private void SetDrone()
	{
		if (Working.Count >= 1)
		{
			Drones[0].SetActive();
			Drones[0].gameObject.SetActive(value: true);
		}
		else
		{
			Drones[0].SetInactive();
			Drones[0].gameObject.SetActive(value: false);
		}
		if (Working.Count >= 3)
		{
			Drones[1].SetActive();
			Drones[1].gameObject.SetActive(value: true);
		}
		else
		{
			Drones[1].SetInactive();
			Drones[1].gameObject.SetActive(value: false);
		}
		if (Working.Count >= 5)
		{
			Drones[2].SetActive();
			Drones[2].gameObject.SetActive(value: true);
		}
		else
		{
			Drones[2].SetInactive();
			Drones[2].gameObject.SetActive(value: false);
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
		return GlobalInfo.GetDefaultOutputPerCycle() * Workers.Count;
	}

	public float GetCloudChance()
	{
		return AddPowerMoreCloud(GameController.Instance.GetCloudChance() * (float)Workers.Count);
	}

	public override bool CanIncreaseLevel()
	{
		if (Level >= 4 && GlobalInfo.CanMoreDroneAttribute.Level < 1)
		{
			return false;
		}
		if (Level >= 8 && GlobalInfo.CanMoreDroneAttribute.Level < 2)
		{
			return false;
		}
		return base.CanIncreaseLevel();
	}
}
