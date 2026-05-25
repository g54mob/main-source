using System.Collections.Generic;
using UnityEngine;

public class Temple : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardRLevelAttribute LevelUpAttribute = new BaseShardRLevelAttribute("LevelUp", 1, (int l) => 3, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseShardRLevelAttribute CanExtraPortal1Attribute = new BaseShardRLevelAttribute("CanExtraPortal1", 1, (int l) => 1, () => true);

		public BaseShardRLevelAttribute CanExtraPortal2Attribute = new BaseShardRLevelAttribute("CanExtraPortal2", 1, (int l) => 1, () => true);

		public BaseShardRLevelAttribute CanHaveLazerAttribute = new BaseShardRLevelAttribute("CanHaveLazer", 1, (int l) => 1, () => true);

		public BaseShardRLevelAttribute CanMoreRPAttribute = new BaseShardRLevelAttribute("CanMoreRP", 1, (int l) => 1, () => true);

		public BaseShardRLevelAttribute CanBiggerOutputAttribute = new BaseShardRLevelAttribute("CanBiggerOutput", 1, (int l) => 1, () => true);

		public BaseShardYLevelAttribute CanYtoRAttribute = new BaseShardYLevelAttribute("CanYtoR", 2, (int l) => 10, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute> { LevelUpAttribute, CanLowerCostAttribute, CanExtraPortal1Attribute, CanExtraPortal2Attribute, CanHaveLazerAttribute, CanMoreRPAttribute, CanBiggerOutputAttribute, CanYtoRAttribute };
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
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public Temple_MiniGame MiniGame;

	private float _timeUntilFire;

	private LevelHelper _levelHelper = new LevelHelper();

	public GameObject TopBallOff;

	public GameObject TopBallOn;

	public GameObject LazerParticle;

	public GameObject SideBall1;

	public GameObject SideBall2;

	private bool _hasLazer;

	private bool _cachedP1;

	private bool _cachedP2;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Temple;

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		BuildingInfos[0].Peon.ChangeLocation(CharDisplay.LocationEnum.Outside, forceChange: true);
		BuildingInfos[0].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[0].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[0].Peon.ChangeEye(CharDisplay.EyeSpriteEnum.Closed);
		BuildingInfos[0].Peon.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		BuildingInfos[1].Peon.ChangeLocation(CharDisplay.LocationEnum.Outside, forceChange: true);
		BuildingInfos[1].Peon.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		BuildingInfos[1].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[1].Peon.ChangeEye(CharDisplay.EyeSpriteEnum.Closed);
		BuildingInfos[1].Peon.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		BuildingInfos[2].Peon.ChangeLocation(CharDisplay.LocationEnum.Outside, forceChange: true);
		BuildingInfos[2].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[2].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[2].Peon.ChangeEye(CharDisplay.EyeSpriteEnum.Closed);
		BuildingInfos[2].Peon.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		BuildingInfos[3].Peon.ChangeLocation(CharDisplay.LocationEnum.Outside, forceChange: true);
		BuildingInfos[3].Peon.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		BuildingInfos[3].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[3].Peon.ChangeEye(CharDisplay.EyeSpriteEnum.Closed);
		BuildingInfos[3].Peon.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		BuildingInfos[4].Peon.ChangeLocation(CharDisplay.LocationEnum.Outside, forceChange: true);
		BuildingInfos[4].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[4].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[4].Peon.ChangeEye(CharDisplay.EyeSpriteEnum.Closed);
		BuildingInfos[4].Peon.ChangeMouth(CharDisplay.MouthSpriteEnum.OpenSmall);
		_cachedP1 = GlobalInfo.CanExtraPortal1Attribute.IsEnabled;
		_cachedP2 = GlobalInfo.CanExtraPortal1Attribute.IsEnabled;
		TopBallOff.SetActive(value: true);
		TopBallOn.SetActive(value: false);
		LazerParticle.SetActive(value: false);
		SideBall1.SetActive(value: false);
		SideBall2.SetActive(value: false);
	}

	private void Update()
	{
		if (!(GameController.Instance == null))
		{
			_levelHelper.SetFloorVisibility();
			if (Working.Count > 0)
			{
				_timeUntilFire += Time.deltaTime;
			}
			if (!_hasLazer && GlobalInfo.CanHaveLazerAttribute.IsEnabled)
			{
				_hasLazer = true;
				TopBallOff.SetActive(value: false);
				TopBallOn.SetActive(value: true);
				LazerParticle.SetActive(value: true);
			}
			if (!SideBall1.activeSelf && GlobalInfo.CanExtraPortal1Attribute.IsEnabled)
			{
				SideBall1.SetActive(value: true);
			}
			if (!SideBall2.activeSelf && GlobalInfo.CanExtraPortal2Attribute.IsEnabled)
			{
				SideBall2.SetActive(value: true);
			}
			if (_cachedP1 != GlobalInfo.CanExtraPortal1Attribute.IsEnabled)
			{
				_cachedP1 = GlobalInfo.CanExtraPortal1Attribute.IsEnabled;
				SetupPortal();
			}
			if (_cachedP2 != GlobalInfo.CanExtraPortal2Attribute.IsEnabled)
			{
				_cachedP2 = GlobalInfo.CanExtraPortal2Attribute.IsEnabled;
				SetupPortal();
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
		if (Working.Count == 0)
		{
			ParentColumn.LocalSfx2Controller.PlayLoopFromDistance(SoundManager.SoundTypeEnum.bs_temple_praying, base.transform.position.x);
		}
		base.EnterBuilding(c);
		_timeUntilFire = 0f;
		DisplayPeon();
		SetupPortal();
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		_timeUntilFire = 0f;
		DisplayPeon();
		SetupPortal();
		if (Working.Count == 0)
		{
			ParentColumn.LocalSfx2Controller.StopLoop();
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
		FlyingMinion.FlyingSpeed = count;
	}

	private void SetupPortal()
	{
		if (GlobalInfo.CanExtraPortal1Attribute.IsEnabled && Working.Count >= 2)
		{
			GameController.Instance.Portals[0].gameObject.SetActive(value: true);
			GameController.Instance.Portals[0].SetForce(Working.Count);
		}
		else
		{
			GameController.Instance.Portals[0].gameObject.SetActive(value: false);
			GameController.Instance.Portals[0].SetForce(0);
		}
		if (GlobalInfo.CanExtraPortal2Attribute.IsEnabled && Working.Count >= 3)
		{
			GameController.Instance.Portals[1].gameObject.SetActive(value: true);
			GameController.Instance.Portals[1].SetForce(Working.Count);
		}
		else
		{
			GameController.Instance.Portals[1].gameObject.SetActive(value: false);
			GameController.Instance.Portals[1].SetForce(0);
		}
		if (GlobalInfo.CanHaveLazerAttribute.IsEnabled && Working.Count >= 4)
		{
			GameController.Instance.Portals[2].gameObject.SetActive(value: true);
			GameController.Instance.Portals[2].SetForce(Working.Count);
		}
		else
		{
			GameController.Instance.Portals[2].gameObject.SetActive(value: false);
			GameController.Instance.Portals[2].SetForce(0);
		}
	}

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute>();
	}
}
