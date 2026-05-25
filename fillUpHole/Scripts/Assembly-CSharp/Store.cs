using System.Collections.Generic;
using UnityEngine;

public class Store : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseMoneyAttribute CanMoreSpaceAttribute = new BaseMoneyAttribute("CanMoreSpace", () => 800, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { CanMoreSpaceAttribute };
		}
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public Store_MiniGame MiniGame;

	private LevelHelper _levelHelper = new LevelHelper();

	private float _outputTimer;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Store;

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
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
		BuildingInfos[3].Peon.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		BuildingInfos[3].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[4].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[4].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[4].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
	}

	private void Update()
	{
		_levelHelper.SetIsThrowing(HasThrowOutputAttribute.IsEnabled);
		_levelHelper.SetCanClose(Research.GlobalInfo.CanCloseOutputAttribute.IsEnabled);
		_levelHelper.SetFloorVisibility();
		if (Working.Count > 0)
		{
			_outputTimer += Time.deltaTime;
			if (_outputTimer >= 5f)
			{
				_outputTimer = 0f;
				OutputGarbage();
			}
		}
	}

	public void OutputGarbage()
	{
		if (!GameController.Instance.IsHoleFilled())
		{
			int num = 1 + GlobalInfo.StabilityLevel;
			int garbageSize = GetGarbageSize();
			int num2 = 0;
			int num3 = Working.Count;
			if (MiniGame.IsSuccess)
			{
				num *= 2;
				num3 *= 3;
			}
			num = AddPowerOutputAmount(num);
			num2 = _levelHelper.OutputGarbage(num, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Store, MiniGame.IsSuccess);
			TotalGarbageOut += num2;
			GlobalInfo.TotalGarbageOut += num2;
			if (num2 == 0)
			{
				_levelHelper.ShakeWithDust(MiniGame.IsSuccess, GetCloudChance() * 4f);
				num3 *= 2;
			}
			else
			{
				ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.ba_garbage_output, base.transform.position.x);
			}
			num3 = AddPowerStability(num3);
			Stability += num3;
		}
	}

	private void FixedUpdate()
	{
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		for (int i = 0; i < 5; i++)
		{
			if (i < Working.Count)
			{
				BuildingInfos[i].PeonEnter();
			}
			else
			{
				BuildingInfos[i].PeonExit();
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
		for (int i = 0; i < 5; i++)
		{
			if (i < Working.Count)
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
		return new List<BaseSavableAttribute> { HasThrowOutputAttribute };
	}

	public int GetGarbageSize()
	{
		int level = Level;
		return AddPowerOutputWeight(level);
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
