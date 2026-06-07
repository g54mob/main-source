using System;
using System.Collections.Generic;
using UnityEngine;

public class Catapult : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => (l != 0) ? 2 : 5, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseResearchAttribute CanThrowMoreAttribute = new BaseResearchAttribute("CanThrowMore", () => 250, () => true);

		public BaseMoneyAttribute CanCannonAttribute = new BaseMoneyAttribute("CanCannon", () => 1000, () => GlobalInfo.LevelUpAttribute.IsEnabled);

		public BaseMoneyAttribute CanMinigunAttribute = new BaseMoneyAttribute("CanMinigun", () => 5000, () => GlobalInfo.CanCannonAttribute.IsEnabled);

		public BaseMoneyAttribute CanCannonCloudAttribute = new BaseMoneyAttribute("CanCannonCloud", () => 2500, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { LevelUpAttribute, CanLowerCostAttribute, CanThrowMoreAttribute, CanCannonAttribute, CanMinigunAttribute, CanCannonCloudAttribute };
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

		public int StoragePerLevel()
		{
			return 9;
		}

		public int GetMoreStorageValue()
		{
			return 10;
		}

		public int GetExtraTrashThrowned()
		{
			return StabilityLevel;
		}
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public List<Catapult_Entity> Entities;

	public GameObject MovingBalls;

	private Queue<GarbageInfo> _storedGarbage = new Queue<GarbageInfo>();

	public FanGroup Fan;

	public AutoDump AutoDump;

	private float _nextBallsLocation;

	private LevelHelper _levelHelper = new LevelHelper();

	private bool _mustProcessAll;

	public List<GameObject> MovingBallList;

	public Sprite BallFullSprite;

	public Sprite BallEmptySprite;

	public List<GameObject> OutputBarDisplay;

	private int _cachedTotalBalls;

	private int _cachedBallLeft;

	private int _cachedOutputCount;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyLevelAttribute HasLeftVacuumAttribute = new BaseMoneyLevelAttribute("HasLeftVacuum", 1, (int l) => GameController.Instance.AddPrestigeCountTax(500), () => GameController.GlobalInfo.CanVacuumAttribute.IsEnabled);

	public BaseMoneyLevelAttribute HasRightVacuumAttribute = new BaseMoneyLevelAttribute("HasRightVacuum", 1, (int l) => GameController.Instance.AddPrestigeCountTax(500), () => GameController.GlobalInfo.CanVacuumAttribute.IsEnabled);

	public BaseMoneyLevelAttribute HasMoreStorageAttribute = new BaseMoneyLevelAttribute("HasMoreStorage", 10, (int l) => GameController.Instance.AddPrestigeCountTax(150 + l * 50), () => Research.GlobalInfo.CanMoreStorageAttribute.IsEnabled);

	public BaseMoneyLevelAttribute HasThrowMoreAttribute = new BaseMoneyLevelAttribute("HasThrowMore", 10, (int l) => GameController.Instance.AddPrestigeCountTax(100 + l * 100), () => GlobalInfo.CanThrowMoreAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Catapult;

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		Entities[0].Info = BuildingInfos[0];
		Entities[1].Info = BuildingInfos[1];
		Entities[2].Info = BuildingInfos[2];
		Entities[3].Info = BuildingInfos[3];
		Entities[4].Info = BuildingInfos[4];
		Entities[0].Parent = this;
		Entities[1].Parent = this;
		Entities[2].Parent = this;
		Entities[3].Parent = this;
		Entities[4].Parent = this;
		foreach (GameObject item in OutputBarDisplay)
		{
			item.SetActive(value: false);
		}
		Fan.Initialize(this);
		AutoDump.Init(this);
		Fan.SetStatus(isLeftVisible: false, isRightVisible: false, isRunning: false);
		AutoDump.SetRunning(isRunning: false);
		Fan.FanPeon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		Fan.FanPeon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		Fan.FanPeon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
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
		_levelHelper.SetFloorVisibility();
		Fan.SetLeftVisibility(HasLeftVacuumAttribute.IsEnabled);
		Fan.SetRightVisibility(HasRightVacuumAttribute.IsEnabled);
		SetFanState();
		ProcessStoredGarbate();
		if (_cachedTotalBalls != (int)MathF.Ceiling((float)GetMaximumStorage() / 10f) || _cachedBallLeft != (int)MathF.Ceiling((float)_storedGarbage.Count / 10f))
		{
			_cachedTotalBalls = (int)MathF.Ceiling((float)GetMaximumStorage() / 10f);
			_cachedBallLeft = (int)MathF.Ceiling((float)_storedGarbage.Count / 10f);
			DrawBall();
		}
		if (UpgradeLevelToBuildingLevel() < 1 || _cachedOutputCount == GetLauncherAmount())
		{
			return;
		}
		_cachedOutputCount = GetLauncherAmount();
		for (int i = 0; i < OutputBarDisplay.Count; i++)
		{
			if (i < _cachedOutputCount)
			{
				OutputBarDisplay[i].SetActive(value: true);
			}
			else
			{
				OutputBarDisplay[i].SetActive(value: false);
			}
		}
	}

	private void DrawBall()
	{
		for (int i = 0; i < MovingBallList.Count; i++)
		{
			if (i + 1 <= _cachedTotalBalls)
			{
				MovingBallList[i].SetActive(value: true);
				if (i + 1 <= _cachedBallLeft)
				{
					MovingBallList[i].GetComponent<SpriteRenderer>().sprite = BallFullSprite;
				}
				else
				{
					MovingBallList[i].GetComponent<SpriteRenderer>().sprite = BallEmptySprite;
				}
			}
			else
			{
				MovingBallList[i].SetActive(value: false);
			}
		}
	}

	private void ProcessStoredGarbate()
	{
		if (_storedGarbage.Count > 0)
		{
			for (int i = 0; i < GetLauncherAmount(); i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (BuildingInfos[j].HasPeon && _storedGarbage.Count > 0 && (Entities[j].AmountStored() < GetLauncherAmount() || _mustProcessAll))
					{
						GarbageInfo garbageInfo = _storedGarbage.Dequeue();
						if (_mustProcessAll)
						{
							garbageInfo.ForceDoubleValue();
						}
						Entities[j].AddGarbage(garbageInfo);
					}
				}
			}
			if (_mustProcessAll && Working.Count > 0)
			{
				ProcessStoredGarbate();
			}
		}
		_mustProcessAll = false;
	}

	private void FixedUpdate()
	{
		if (Level >= 3)
		{
			if (_nextBallsLocation == 0f)
			{
				MovingBalls.transform.localPosition -= new Vector3(0f, 0.25f * Time.deltaTime, 0f);
			}
			else
			{
				MovingBalls.transform.localPosition += new Vector3(0f, 0.25f * Time.deltaTime, 0f);
			}
			if (_nextBallsLocation == 0f && MovingBalls.transform.localPosition.y <= _nextBallsLocation)
			{
				_nextBallsLocation = (float)UpgradeLevelToBuildingLevel() * 2f;
			}
			else if (_nextBallsLocation > 0f && MovingBalls.transform.localPosition.y >= _nextBallsLocation)
			{
				_nextBallsLocation = 0f;
			}
		}
	}

	public void ProcessAll()
	{
		_mustProcessAll = true;
	}

	public void IncreaseExecutionStats(int garbageCount)
	{
		int count = Working.Count;
		count = AddPowerStability(count);
		count = count;
		ExecutionCount++;
		Stability += count;
		TotalGarbageOut += garbageCount;
		GlobalInfo.TotalExecutionCount++;
		GlobalInfo.TotalGarbageOut += garbageCount;
	}

	public int GetAmountStored()
	{
		return _storedGarbage.Count;
	}

	public void UpgradePipe()
	{
	}

	public override int GetMaximumWorker()
	{
		if (HasLeftVacuumAttribute.IsEnabled || HasRightVacuumAttribute.IsEnabled)
		{
			return UpgradeLevelToBuildingLevel() + 2;
		}
		return UpgradeLevelToBuildingLevel() + 1;
	}

	public override Vector3 GetEnterLocation()
	{
		return DoorLocation.transform.position;
	}

	public override bool CanDumbGarbage(Garbage g, bool ignoreBan)
	{
		if (!ignoreBan && IsBanPeonDrop())
		{
			return false;
		}
		if (g != null && !g.Info.IsGarbage)
		{
			return false;
		}
		if (_storedGarbage.Count < GetMaximumStorage())
		{
			return true;
		}
		return false;
	}

	public override void DumpGarbage(Garbage g)
	{
		_storedGarbage.Enqueue(g.Info);
		GameController.Instance.GarbageController.DestroyGarbage(g);
	}

	public override void EnterBuilding(CharV2 c)
	{
		base.EnterBuilding(c);
		CountLevel();
		SetDisplay();
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		SetDisplay();
	}

	public void SetDisplay()
	{
		DisplayPeon();
		SetFanState();
	}

	public void DisplayPeon()
	{
		int num = CountLevel();
		for (int i = 0; i < 5; i++)
		{
			if (i < num)
			{
				BuildingInfos[i].PeonEnter();
			}
			else
			{
				BuildingInfos[i].PeonExit();
			}
		}
	}

	private int CountLevel()
	{
		int num = Working.Count;
		if ((HasLeftVacuumAttribute.IsEnabled || HasRightVacuumAttribute.IsEnabled) && num > 1)
		{
			num--;
		}
		return num;
	}

	public void SetFanState()
	{
		if ((HasLeftVacuumAttribute.IsEnabled || HasRightVacuumAttribute.IsEnabled) && Working.Count > 1)
		{
			if (Fan.SetRunning(isRunning: true))
			{
				ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_fan_on, base.transform.position.x);
			}
			AutoDump.SetRunning(isRunning: true);
		}
		else
		{
			if (Fan.SetRunning(isRunning: false))
			{
				ParentColumn.LocalSfx2Controller.StopLoop();
			}
			AutoDump.SetRunning(isRunning: false);
		}
	}

	public List<GarbageInfo> GetAllStored()
	{
		List<GarbageInfo> list = new List<GarbageInfo>();
		list.AddRange(_storedGarbage.ToArray());
		foreach (Catapult_Entity entity in Entities)
		{
			list.AddRange(entity._storedGarbage);
		}
		return list;
	}

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute> { HasLeftVacuumAttribute, HasRightVacuumAttribute, HasMoreStorageAttribute, HasThrowMoreAttribute };
	}

	public int GetMaximumStorage()
	{
		int num = Level * GlobalInfo.StoragePerLevel();
		if (HasMoreStorageAttribute.IsEnabled)
		{
			num += GlobalInfo.GetMoreStorageValue() * HasMoreStorageAttribute.Level;
		}
		return num;
	}

	public int GetLauncherAmount()
	{
		if (HasThrowMoreAttribute.IsEnabled)
		{
			return Level + GlobalInfo.GetExtraTrashThrowned() + HasThrowMoreAttribute.Level;
		}
		return Level + GlobalInfo.GetExtraTrashThrowned();
	}

	public override bool CanIncreaseLevel()
	{
		if (Level >= 4 && !GlobalInfo.CanCannonAttribute.IsEnabled)
		{
			return false;
		}
		if (Level >= 8 && !GlobalInfo.CanMinigunAttribute.IsEnabled)
		{
			return false;
		}
		return base.CanIncreaseLevel();
	}
}
