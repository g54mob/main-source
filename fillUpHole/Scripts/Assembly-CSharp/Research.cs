using System.Collections.Generic;
using UnityEngine;

public class Research : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => (l == 0) ? 1 : 2, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseResearchAttribute CanCloseOutputAttribute = new BaseResearchAttribute("CanCloseOutput", () => 1200, () => true);

		public BaseResearchAttribute CanThrowOutputAttribute = new BaseResearchAttribute("CanThrowOutput", () => 900, () => true);

		public BaseResearchLevelAttribute CanMoreCloudAttribute = new BaseResearchLevelAttribute("CanMoreCloud", 5, (int l) => 250 + 250 * l, () => true);

		public BaseResearchAttribute CanMoreGarbageAttribute = new BaseResearchAttribute("CanMoreGarbage", () => 250, () => true);

		public BaseResearchAttribute CanMoreStorageAttribute = new BaseResearchAttribute("CanMoreStorage", () => 125, () => true);

		public BaseResearchAttribute CanExtraYellowShardAttribute = new BaseResearchAttribute("CanDoubleYellowShard", () => 125, () => true);

		public BaseMoneyLevelAttribute CanMoreRPAttribute = new BaseMoneyLevelAttribute("CanMoreRP", 5, (int l) => 1000 + 4000 * l, () => true);

		public BaseMoneyLevelAttribute CanMoneyToYellowAttribute = new BaseMoneyLevelAttribute("CanMoneyToYellow", 10, (int l) => 1000 + 5000 * l, () => true);

		public BaseShardBLevelAttribute CanResetAbilitiesAttribute = new BaseShardBLevelAttribute("CanResetAbilities", 1, (int l) => 1, () => true);

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute>
			{
				LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanCloseOutputAttribute, CanThrowOutputAttribute, CanMoreCloudAttribute, CanMoreGarbageAttribute, CanMoreStorageAttribute, CanExtraYellowShardAttribute, CanMoreRPAttribute,
				CanMoneyToYellowAttribute, CanResetAbilitiesAttribute
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

		public int GetRPGenerated()
		{
			return 1 + GlobalInfo.CanMoreRPAttribute.Level;
		}

		public int GetDefaultOutputPerCycle()
		{
			return 1;
		}

		public int GetDefaultGarbageSize()
		{
			return 1;
		}
	}

	public GameObject DoorLocation;

	public List<BuildingLevelInfo> BuildingInfos;

	public List<ParticleSystem> Particles;

	public GameObject ProgressFront;

	public Research_MiniGame MiniGame;

	private float _timeUntilFire;

	private LevelHelper _levelHelper = new LevelHelper();

	public GameObject Decoration2;

	public GameObject Decoration3;

	public GameObject Decoration4;

	public GarbageCounter GarbageCounter;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Research;

	private void Start()
	{
		_levelHelper.Init(BuildingInfos, this);
		MiniGame.ChangeStage(Research_MiniGame.StageEnum.Part1);
		BuildingInfos[0].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[0].Peon.ChangeSide(CharDisplay.SideEnum.Left, forceChange: true);
		BuildingInfos[0].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[1].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[1].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
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
		MiniGame.AutoDevice = HasAutoDeviceAttribute.IsEnabled;
		_levelHelper.SetIsThrowing(HasThrowOutputAttribute.IsEnabled);
		_levelHelper.SetCanClose(GlobalInfo.CanCloseOutputAttribute.IsEnabled);
		_levelHelper.SetFloorVisibility();
		if (Working.Count > 0)
		{
			if (GameController.Instance.IsHoleFilled())
			{
				return;
			}
			_timeUntilFire += Time.deltaTime;
			if (_timeUntilFire >= 5f)
			{
				MiniGame.ChangeStage(Research_MiniGame.StageEnum.Ending);
				_timeUntilFire = 0f;
				int rPPRoduce = GetRPPRoduce();
				if (MiniGame.IsSuccess)
				{
					GameController.Instance.GainRP(AddMoreTP_RP(rPPRoduce) * MINIGAME_AMOUNT_MUL);
				}
				else
				{
					GameController.Instance.GainRP(AddMoreTP_RP(rPPRoduce));
				}
				ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_gain_rp, base.transform.position.x);
				FinishCycle();
				ExecutionCount++;
				GlobalInfo.TotalExecutionCount++;
				MiniGame.ChangeStage(Research_MiniGame.StageEnum.None);
				MiniGame.ChangeStage(Research_MiniGame.StageEnum.Part1);
			}
			else if ((double)_timeUntilFire >= 0.5)
			{
				MiniGame.ChangeStage(Research_MiniGame.StageEnum.Part2);
			}
		}
		if (_timeUntilFire == 0f)
		{
			ProgressFront.transform.localScale = new Vector3(0f, 1f, 1f);
		}
		else
		{
			ProgressFront.transform.localScale = new Vector3(_timeUntilFire / 5f, 1f, 1f);
		}
		if (Decoration2.GetComponent<AnimationSprite>().IsPlaying() != Working.Count >= 2)
		{
			if (Working.Count >= 2)
			{
				Decoration2.GetComponent<AnimationSprite>().Play("PlayDeco");
			}
			else
			{
				Decoration2.GetComponent<AnimationSprite>().Play("");
			}
		}
		if (Decoration3.GetComponent<AnimationSprite>().IsPlaying() != Working.Count >= 3)
		{
			if (Working.Count >= 3)
			{
				Decoration3.GetComponent<AnimationSprite>().Play("PlayDeco");
			}
			else
			{
				Decoration3.GetComponent<AnimationSprite>().Play("");
			}
		}
		if (Decoration4.GetComponent<AnimationSprite>().IsPlaying() != Working.Count >= 4)
		{
			if (Working.Count >= 4)
			{
				Decoration4.GetComponent<AnimationSprite>().Play("PlayDeco");
			}
			else
			{
				Decoration4.GetComponent<AnimationSprite>().Play("");
			}
		}
	}

	private void FinishCycle()
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
			num2 = _levelHelper.OutputGarbage(num, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Research, MiniGame.IsSuccess);
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
			for (int i = 0; i < Working.Count; i++)
			{
				Particles[i].Play();
			}
			Stability += num3;
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
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		DisplayPeon();
		if (Working.Count == 0)
		{
			MiniGame.ChangeStage(Research_MiniGame.StageEnum.None);
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

	public int GetRPPRoduce()
	{
		return GlobalInfo.GetRPGenerated() * Working.Count + GlobalInfo.StabilityLevel;
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
}
