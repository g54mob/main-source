using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Compressor : BaseBuildingWorker
{
	public class MyGlobalInfo : BaseGlobalInfo
	{
		public BaseShardYLevelAttribute LevelUpAttribute = new BaseShardYLevelAttribute("LevelUp", 5, (int l) => (l != 0) ? 2 : 4, () => true);

		public BaseBookAttribute CanLowerCostAttribute = new BaseBookAttribute("CanLowerCost", () => 1, () => true);

		public BaseBookAttribute CanAutoDeviceAttribute = new BaseBookAttribute("CanAutoDevice", () => 2, () => true);

		public BaseResearchLevelAttribute CanBetterSmallCompressAttribute = new BaseResearchLevelAttribute("CanBetterSmallCompress", 5, (int l) => 250 + l * 50, () => true);

		public BaseResearchLevelAttribute CanCompressMediumAttribute = new BaseResearchLevelAttribute("CanCompressMedium", 5, (int l) => 500 + l * 50, () => true);

		public BaseResearchLevelAttribute CanCompressLargeAttribute = new BaseResearchLevelAttribute("CanCompressLarge", 5, (int l) => 1500 + l * 100, () => true);

		public BaseMoneyLevelAttribute CanGarbageMoreMoneyAttribute = new BaseMoneyLevelAttribute("CanGarbageMoreMoney", 5, (int l) => 4500 + l * 500, () => true);

		public BaseResearchAttribute CanCaptureFlyingAttribute = new BaseResearchAttribute("CanCapture", () => 250, () => true);

		public BaseMoneyLevelAttribute CanMediumOnLowStabilityAttribute = new BaseMoneyLevelAttribute("CanMediumOnLowStability", 1, (int l) => 7500, () => true);

		public BaseShardYLevelAttribute CanConvertYtoBAttribute = new BaseShardYLevelAttribute("CanConvertYtoB", 5, (int l) => 5, () => true);

		public BaseShardBLevelAttribute CanConvertBtoYAttribute = new BaseShardBLevelAttribute("CanConvertBtoY", 5, (int l) => 1, () => true);

		public BaseShardBLevelAttribute CanDoublecompressAttribute = new BaseShardBLevelAttribute("CanDoublecompress", 1, (int l) => 2, () => true);

		public BaseShardYLevelAttribute CanCompress8Attribute = new BaseShardYLevelAttribute("CanCompress8", 1, (int l) => 4, () => true);

		public BaseShardBLevelAttribute CanCompressFromCompressorAttribute = new BaseShardBLevelAttribute("CanCompressFromCompressor", 1, (int l) => 3, () => true);

		public float ADDED_STABILITY_PERC = 0.05f;

		public override List<BaseSavableAttribute> GetStaticAttributes()
		{
			return new List<BaseSavableAttribute>
			{
				LevelUpAttribute, CanLowerCostAttribute, CanAutoDeviceAttribute, CanBetterSmallCompressAttribute, CanCompressMediumAttribute, CanGarbageMoreMoneyAttribute, CanCaptureFlyingAttribute, CanCompressLargeAttribute, CanMediumOnLowStabilityAttribute, CanConvertYtoBAttribute,
				CanConvertBtoYAttribute, CanDoublecompressAttribute, CanCompress8Attribute, CanCompressFromCompressorAttribute
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

		public int StoragePerLevel()
		{
			return 9;
		}

		public int GetMoreStorageValue()
		{
			return 10;
		}

		public float WeightBonusPerLevel()
		{
			return 0.05f;
		}

		public int GetInputAmount()
		{
			if (GlobalInfo.CanCompress8Attribute.IsEnabled)
			{
				return 8;
			}
			return 4;
		}
	}

	public GameObject DoorLocation;

	public GameObject ThrowInputLocation;

	public GameObject ManualInputLocation;

	public GameObject GarbageSIcon;

	public GameObject GarbageMIcon;

	public GameObject GarbageLIcon;

	public List<BuildingLevelInfo> BuildingInfos;

	public GameObject Compress;

	public GameObject CaptureImage;

	public Compressor_MiniGame MiniGame;

	public GarbageCounter GarbageCounter;

	private Queue<GarbageInfo> _storedSmallGarbage = new Queue<GarbageInfo>();

	private Queue<GarbageInfo> _storedMediumGarbage = new Queue<GarbageInfo>();

	private Queue<GarbageInfo> _storedLargeGarbage = new Queue<GarbageInfo>();

	public FanGroup Fan;

	public AutoDump AutoDump;

	private Tweener _movementAnim;

	private LevelHelper _levelHelper = new LevelHelper();

	private bool _mustProcessAll;

	private Animator _animator;

	public List<GameObject> MovingBallList;

	public Sprite BallFullSprite;

	public Sprite BallEmptySprite;

	private int _cachedTotalBalls;

	private int _cachedBallLeft;

	private bool _cachedCanMedium;

	private bool _cachedCanLarge;

	public static MyGlobalInfo GlobalInfo = new MyGlobalInfo();

	public BaseMoneyAttribute HasCatchAttribute = new BaseMoneyAttribute("HasCatch", () => GameController.Instance.AddPrestigeCountTax(500), () => GlobalInfo.CanCaptureFlyingAttribute.IsEnabled);

	public BaseMoneyAttribute HasThrowOutputAttribute = new BaseMoneyAttribute("HasThrowOutput", () => GameController.Instance.AddPrestigeCountTax(500), () => Research.GlobalInfo.CanThrowOutputAttribute.IsEnabled);

	public BaseMoneyLevelAttribute HasLeftVacuumAttribute = new BaseMoneyLevelAttribute("HasLeftVacuum", 1, (int l) => GameController.Instance.AddPrestigeCountTax(500), () => GameController.GlobalInfo.CanVacuumAttribute.IsEnabled);

	public BaseMoneyLevelAttribute HasRightVacuumAttribute = new BaseMoneyLevelAttribute("HasRightVacuum", 1, (int l) => GameController.Instance.AddPrestigeCountTax(500), () => GameController.GlobalInfo.CanVacuumAttribute.IsEnabled);

	public BaseMoneyLevelAttribute HasMoreStorageAttribute = new BaseMoneyLevelAttribute("HasMoreStorage", 10, (int l) => GameController.Instance.AddPrestigeCountTax(150 + l * 50), () => Research.GlobalInfo.CanMoreStorageAttribute.IsEnabled);

	public BaseMoneyAttribute HasAutoDeviceAttribute = new BaseMoneyAttribute("HasAutoDevice", () => 10000, () => GlobalInfo.CanAutoDeviceAttribute.IsEnabled);

	public override BuildingTypeEnum BuildingType => BuildingTypeEnum.Compressor;

	private void Start()
	{
		_animator = GetComponent<Animator>();
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
		BuildingInfos[3].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[3].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		BuildingInfos[4].Peon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		BuildingInfos[4].Peon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		BuildingInfos[4].Peon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		Fan.Initialize(this);
		AutoDump.Init(this);
		Fan.SetStatus(isLeftVisible: false, isRightVisible: false, isRunning: false);
		AutoDump.SetRunning(isRunning: false);
		Fan.FanPeon.ChangeLocation(CharDisplay.LocationEnum.Inside, forceChange: true);
		Fan.FanPeon.ChangeSide(CharDisplay.SideEnum.Right, forceChange: true);
		Fan.FanPeon.ChangeMovement(CharDisplay.MovementEnum.None, forceChange: true);
		GarbageMIcon.SetActive(value: false);
		GarbageLIcon.SetActive(value: false);
	}

	private void Update()
	{
		MiniGame.AutoDevice = HasAutoDeviceAttribute.IsEnabled;
		_levelHelper.SetIsThrowing(HasThrowOutputAttribute.IsEnabled);
		_levelHelper.SetCanClose(Research.GlobalInfo.CanCloseOutputAttribute.IsEnabled);
		_levelHelper.SetFloorVisibility();
		Fan.SetLeftVisibility(HasLeftVacuumAttribute.IsEnabled);
		Fan.SetRightVisibility(HasRightVacuumAttribute.IsEnabled);
		SetFanState();
		if (Working.Count > 0)
		{
			EnterGarbage();
		}
		if (MiniGame.IsSuccess)
		{
			Compress.GetComponent<SpriteRenderer>().color = GameController.EvilColor;
		}
		else
		{
			Compress.GetComponent<SpriteRenderer>().color = Color.white;
		}
		if (MiniGame.Stage == Compressor_MiniGame.StageEnum.None && CanCompress() && Working.Count > 0)
		{
			MiniGame.ChangeStage(Compressor_MiniGame.StageEnum.Part1);
			float duration = 2f;
			Compress.transform.localPosition = new Vector3(-0.5f, Compress.transform.localPosition.y, 0f);
			Sequence sequence = DOTween.Sequence();
			sequence.Append(Compress.transform.DOLocalMoveX(0f, duration));
			sequence.AppendCallback(delegate
			{
				ChangeMiniGame();
			});
			sequence.Append(Compress.transform.DOLocalMoveX(-0.5f, duration));
			sequence.OnComplete(delegate
			{
				OnLoopComplete();
			});
		}
		if (HasCatchAttribute.IsEnabled)
		{
			CaptureImage.SetActive(value: true);
		}
		else
		{
			CaptureImage.SetActive(value: false);
		}
		if (_cachedTotalBalls != (int)MathF.Ceiling((float)GetMaximumStorage() / 10f) || _cachedBallLeft != (int)MathF.Ceiling((float)(_storedSmallGarbage.Count + _storedMediumGarbage.Count + _storedLargeGarbage.Count) / 10f))
		{
			_cachedTotalBalls = (int)MathF.Ceiling((float)GetMaximumStorage() / 10f);
			_cachedBallLeft = (int)MathF.Ceiling((float)(_storedSmallGarbage.Count + _storedMediumGarbage.Count + _storedLargeGarbage.Count) / 10f);
			DrawBall();
		}
		if (!_cachedCanMedium && GlobalInfo.CanCompressMediumAttribute.IsEnabled)
		{
			_cachedCanMedium = true;
			GarbageMIcon.SetActive(value: true);
		}
		if (!_cachedCanLarge && GlobalInfo.CanCompressLargeAttribute.IsEnabled)
		{
			_cachedCanLarge = true;
			GarbageLIcon.SetActive(value: true);
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

	private bool CanCompress()
	{
		if (_storedSmallGarbage.Count >= GlobalInfo.GetInputAmount())
		{
			return true;
		}
		if (_storedMediumGarbage.Count >= GlobalInfo.GetInputAmount())
		{
			return true;
		}
		if (_storedLargeGarbage.Count >= GlobalInfo.GetInputAmount())
		{
			return true;
		}
		return false;
	}

	public bool AreFanActive()
	{
		if (Working.Count > 1 && (HasLeftVacuumAttribute.IsEnabled || HasRightVacuumAttribute.IsEnabled))
		{
			return true;
		}
		return false;
	}

	private void ChangeMiniGame()
	{
		MiniGame.ChangeStage(Compressor_MiniGame.StageEnum.Part2);
	}

	private void OnLoopComplete()
	{
		MiniGame.ChangeStage(Compressor_MiniGame.StageEnum.Ending);
		ParentColumn.LocalSfx2Controller.PlayFromDistance(SoundManager.SoundTypeEnum.bs_compress, base.transform.position.x);
		ThrowGarbage();
		MiniGame.ChangeStage(Compressor_MiniGame.StageEnum.None);
	}

	private void EnterGarbage()
	{
		if (!HasCatchAttribute.IsEnabled)
		{
			return;
		}
		BoxCollider2D component = GetComponent<BoxCollider2D>();
		Collider2D[] array = Physics2D.OverlapBoxAll(component.bounds.center, component.bounds.size, 0f);
		for (int i = 0; i < array.Length; i++)
		{
			Garbage component2 = array[i].gameObject.GetComponent<Garbage>();
			if (component2 != null && CanDumbGarbage(component2, ignoreBan: true))
			{
				DumpGarbage(component2);
			}
		}
	}

	public int GetAmountStored()
	{
		return _storedSmallGarbage.Count + _storedMediumGarbage.Count + _storedLargeGarbage.Count;
	}

	public int GetCompressedCount()
	{
		int num = Working.Count;
		if (AreFanActive())
		{
			num--;
		}
		return num;
	}

	private void ThrowGarbage()
	{
		if (GameController.Instance.IsHoleFilled() || GarbageCounter.IsOverLimit)
		{
			return;
		}
		int compressedCount = GetCompressedCount();
		OutputGarbage();
		for (int i = 0; i < compressedCount; i++)
		{
			if (_storedMediumGarbage.Count >= GlobalInfo.GetInputAmount())
			{
				int num = 0;
				int num2 = 0;
				for (int j = 0; j < GlobalInfo.GetInputAmount(); j++)
				{
					GarbageInfo garbageInfo = _storedMediumGarbage.Dequeue();
					num += garbageInfo.Weight;
				}
				num = (int)((float)num * (1f + GetWeightBoost()));
				num += (int)((float)num * 0.05f * (float)GlobalInfo.CanCompressMediumAttribute.Level);
				if (_mustProcessAll)
				{
					num *= 2;
				}
				if (GlobalInfo.CanCompress8Attribute.IsEnabled)
				{
					num /= 2;
				}
				int num3 = 1;
				if (GlobalInfo.CanCompress8Attribute.IsEnabled)
				{
					num3++;
				}
				if (GlobalInfo.CanDoublecompressAttribute.IsEnabled)
				{
					num3 *= 2;
				}
				for (int k = 0; k < num3; k++)
				{
					num2 += _levelHelper.OutputOneLevelGarbage(1, new GarbageInfo(num, GarbageInfo.GarbageTypeEnum.GarbageL, GarbageInfo.CameFromEnum.Compressed, isEvil: false), 0f);
				}
				TotalGarbageOut += num2;
				GlobalInfo.TotalGarbageOut += num2;
			}
			else if (_storedLargeGarbage.Count >= GlobalInfo.GetInputAmount())
			{
				int num4 = 0;
				int num5 = 0;
				for (int l = 0; l < GlobalInfo.GetInputAmount(); l++)
				{
					GarbageInfo garbageInfo2 = _storedLargeGarbage.Dequeue();
					num4 += garbageInfo2.Weight;
				}
				num4 = (int)((float)num4 * (1f + GetWeightBoost()));
				num4 += (int)((float)num4 * 0.05f * (float)GlobalInfo.CanCompressLargeAttribute.Level);
				if (_mustProcessAll)
				{
					num4 *= 2;
				}
				if (GlobalInfo.CanCompress8Attribute.IsEnabled)
				{
					num4 /= 2;
				}
				int num6 = 1;
				if (GlobalInfo.CanCompress8Attribute.IsEnabled)
				{
					num6++;
				}
				if (GlobalInfo.CanDoublecompressAttribute.IsEnabled)
				{
					num6 *= 2;
				}
				for (int m = 0; m < num6; m++)
				{
					num5 += _levelHelper.OutputOneLevelGarbage(1, new GarbageInfo(num4, GarbageInfo.GarbageTypeEnum.GarbageXL, GarbageInfo.CameFromEnum.Compressed, isEvil: false), 0f);
				}
				TotalGarbageOut += num5;
				GlobalInfo.TotalGarbageOut += num5;
			}
			else if (_storedSmallGarbage.Count >= GlobalInfo.GetInputAmount())
			{
				int num7 = 0;
				int num8 = 0;
				for (int n = 0; n < GlobalInfo.GetInputAmount(); n++)
				{
					GarbageInfo garbageInfo3 = _storedSmallGarbage.Dequeue();
					num7 += garbageInfo3.Weight;
				}
				num7 = (int)((float)num7 * (1f + GetWeightBoost()));
				num7 += (int)((float)num7 * 0.05f * (float)GlobalInfo.CanBetterSmallCompressAttribute.Level);
				if (_mustProcessAll)
				{
					num7 *= 2;
				}
				if (GlobalInfo.CanCompress8Attribute.IsEnabled)
				{
					num7 /= 2;
				}
				int num9 = 1;
				if (GlobalInfo.CanCompress8Attribute.IsEnabled)
				{
					num9++;
				}
				if (GlobalInfo.CanDoublecompressAttribute.IsEnabled)
				{
					num9 *= 2;
				}
				for (int num10 = 0; num10 < num9; num10++)
				{
					num8 += _levelHelper.OutputOneLevelGarbage(1, new GarbageInfo(num7, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.Compressed, isEvil: false), 0f);
				}
				TotalGarbageOut += num8;
				GlobalInfo.TotalGarbageOut += num8;
			}
		}
		if (_mustProcessAll && Working.Count > 0 && (_storedLargeGarbage.Count >= GlobalInfo.GetInputAmount() || _storedMediumGarbage.Count >= GlobalInfo.GetInputAmount() || _storedSmallGarbage.Count >= GlobalInfo.GetInputAmount()))
		{
			ThrowGarbage();
		}
		_mustProcessAll = false;
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
			num3 = _levelHelper.OutputGarbage(num, garbageSize, GetCloudChance(), GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.Compressor, MiniGame.IsSuccess);
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

	public void ProcessAll()
	{
		_mustProcessAll = true;
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
		return ManualInputLocation.transform.position;
	}

	public override bool CanDumbGarbage(Garbage g, bool ignoreBan)
	{
		if (!ignoreBan && IsBanPeonDrop())
		{
			return false;
		}
		if (g.Info.CameFrom == GarbageInfo.CameFromEnum.Compressed && !GlobalInfo.CanCompressFromCompressorAttribute.IsEnabled)
		{
			return false;
		}
		if (g.Info.GarbageType != GarbageInfo.GarbageTypeEnum.GarbageS)
		{
			if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageM)
			{
				if (!GlobalInfo.CanCompressMediumAttribute.IsEnabled)
				{
					return false;
				}
			}
			else
			{
				if (g.Info.GarbageType != GarbageInfo.GarbageTypeEnum.GarbageL)
				{
					return false;
				}
				if (!GlobalInfo.CanCompressLargeAttribute.IsEnabled)
				{
					return false;
				}
			}
		}
		if (GetAmountStored() >= GetMaximumStorage())
		{
			return false;
		}
		return true;
	}

	public override void DumpGarbage(Garbage g)
	{
		if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageS)
		{
			_storedSmallGarbage.Enqueue(g.Info);
			GameController.Instance.GarbageController.DestroyGarbage(g);
		}
		else if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageM)
		{
			_storedMediumGarbage.Enqueue(g.Info);
			GameController.Instance.GarbageController.DestroyGarbage(g);
		}
		else if (g.Info.GarbageType == GarbageInfo.GarbageTypeEnum.GarbageL)
		{
			_storedLargeGarbage.Enqueue(g.Info);
			GameController.Instance.GarbageController.DestroyGarbage(g);
		}
	}

	public override bool CanHaveThrowGarbage(Garbage g)
	{
		if (!HasCatchAttribute.IsEnabled)
		{
			return false;
		}
		return CanDumbGarbage(g, ignoreBan: true);
	}

	public override Vector3 ThrowGarbageLocation()
	{
		return ThrowInputLocation.transform.position;
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

	public override void EnterBuilding(CharV2 c)
	{
		base.EnterBuilding(c);
		_animator.SetBool("PlayLevel2", BuildingInfos[1].HasPeon);
		_animator.SetBool("PlayLevel3", BuildingInfos[2].HasPeon);
		_animator.SetBool("PlayLevel4", BuildingInfos[3].HasPeon);
		SetDisplay();
	}

	public override void ExitBuilding(CharV2 c)
	{
		base.ExitBuilding(c);
		if (Working.Count == 0 && _movementAnim != null)
		{
			_movementAnim.Kill();
			_movementAnim = null;
		}
		_animator.SetBool("PlayLevel2", BuildingInfos[1].HasPeon);
		_animator.SetBool("PlayLevel3", BuildingInfos[2].HasPeon);
		_animator.SetBool("PlayLevel4", BuildingInfos[3].HasPeon);
		SetDisplay();
		if (Working.Count == 0)
		{
			MiniGame.ChangeStage(Compressor_MiniGame.StageEnum.None);
		}
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

	public void SetFanState()
	{
		if ((HasLeftVacuumAttribute.IsEnabled || HasRightVacuumAttribute.IsEnabled) && Working.Count > 1)
		{
			if (Fan.SetRunning(isRunning: true))
			{
				ParentColumn.LocalSfx2Controller.PlayLoopFromDistance(SoundManager.SoundTypeEnum.bs_fan_on, base.transform.position.x);
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
		list.AddRange(_storedSmallGarbage.ToArray());
		list.AddRange(_storedMediumGarbage.ToArray());
		list.AddRange(_storedLargeGarbage.ToArray());
		return list;
	}

	public override BaseGlobalInfo GetGlobalInfo()
	{
		return GlobalInfo;
	}

	public override List<BaseSavableAttribute> GetInstanceAttributes()
	{
		return new List<BaseSavableAttribute> { HasCatchAttribute, HasThrowOutputAttribute, HasLeftVacuumAttribute, HasRightVacuumAttribute, HasMoreStorageAttribute, HasAutoDeviceAttribute };
	}

	public float GetWaitingSpeed()
	{
		return 5.5f;
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

	public float GetWeightBoost()
	{
		return 0f + (float)GlobalInfo.StabilityLevel * GlobalInfo.ADDED_STABILITY_PERC;
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
}
