using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
	public Sign Sign;

	public int Distance;

	public LocalSfx2Controller LocalSfx2Controller;

	public House HousePrefab;

	public Catapult CatapultPrefab;

	public Temple TemplePrefab;

	public Helicopter HelicopterPrefab;

	public Research ResearchPrefab;

	public HotAirStation HotAirStationPrefab;

	public Store StorePrefab;

	public Training TrainingPrefab;

	public Industry IndustryPrefab;

	public Power PowerPrefab;

	public Rock RockPrefab;

	public Compressor CompressorPrefab;

	public Drone DronePrefab;

	public HoleThrow HoleThrow;

	public List<GameObject> PeonIcon;

	public GameObject HasPowerIcon;

	public GameObject BanPeonIcon;

	public Sprite HasPeonIconSprite;

	public Sprite NoPeonIconSprite;

	public GameObject StabilityProgress;

	public DotLevel DotLevel;

	public BaseBuilding Buildings;

	private int _cachedNumWorker;

	private int _cachedTotalWorkerSize;

	private float _stabilityProgressOriginalX;

	private float _stabilityProgressOriginalScaleX;

	private float _stabilityProgressOriginalScaleY;

	private void Awake()
	{
		if (StabilityProgress != null)
		{
			_stabilityProgressOriginalX = StabilityProgress.transform.localPosition.x;
			_stabilityProgressOriginalScaleX = StabilityProgress.transform.localScale.x;
			_stabilityProgressOriginalScaleY = StabilityProgress.transform.localScale.y;
		}
	}

	private void Start()
	{
		if (HoleThrow != null)
		{
			Buildings = HoleThrow;
		}
		if (HasPowerIcon != null)
		{
			HasPowerIcon.SetActive(value: false);
		}
		if (BanPeonIcon != null)
		{
			BanPeonIcon.SetActive(value: false);
		}
		foreach (GameObject item in PeonIcon)
		{
			item.SetActive(value: false);
		}
	}

	private void Update()
	{
		if (Buildings is BaseBuildingWorker)
		{
			if (_cachedNumWorker != ((BaseBuildingWorker)Buildings).Working.Count || _cachedTotalWorkerSize != ((BaseBuildingWorker)Buildings).GetMaximumWorker())
			{
				_cachedNumWorker = ((BaseBuildingWorker)Buildings).Working.Count;
				_cachedTotalWorkerSize = ((BaseBuildingWorker)Buildings).GetMaximumWorker();
				for (int i = 0; i < PeonIcon.Count; i++)
				{
					if (i < _cachedTotalWorkerSize)
					{
						PeonIcon[i].SetActive(value: true);
						if (i < _cachedNumWorker)
						{
							PeonIcon[i].GetComponent<SpriteRenderer>().sprite = HasPeonIconSprite;
						}
						else
						{
							PeonIcon[i].GetComponent<SpriteRenderer>().sprite = NoPeonIconSprite;
						}
					}
					else
					{
						PeonIcon[i].SetActive(value: false);
					}
				}
			}
		}
		else
		{
			foreach (GameObject item in PeonIcon)
			{
				item.SetActive(value: false);
			}
		}
		if (HasPowerIcon != null)
		{
			if (Buildings != null)
			{
				if (Buildings.HasPower())
				{
					HasPowerIcon.SetActive(value: true);
				}
				else
				{
					HasPowerIcon.SetActive(value: false);
				}
			}
			else
			{
				HasPowerIcon.SetActive(value: false);
			}
		}
		if (BanPeonIcon != null)
		{
			if (Buildings != null)
			{
				if (Buildings.IsBanPeonDrop())
				{
					BanPeonIcon.SetActive(value: true);
				}
				else
				{
					BanPeonIcon.SetActive(value: false);
				}
			}
			else
			{
				BanPeonIcon.SetActive(value: false);
			}
		}
		if (Buildings != null && Buildings.IsUnstable())
		{
			bool flag = false;
			if (Buildings.GetGlobalInfo() != null)
			{
				if (Buildings.GetGlobalInfo().TotalEvilCount > 0 && Buildings.GetGlobalInfo().EvilExplosionCount == 0)
				{
					Buildings.GetGlobalInfo().EvilExplosionCount++;
					flag = true;
				}
				Buildings.GetGlobalInfo().StabilityLevel++;
			}
			if (Buildings.GetLevel() == 10 && Installation.CanGenerateBook() && !Buildings.GetGlobalInfo().HasSpawnBook)
			{
				Buildings.GetGlobalInfo().HasSpawnBook = true;
				GlobalSfx2Controller.Instance.PlayFromDistance(SoundManager.SoundTypeEnum.ga_book_appear, base.transform.position.x);
				if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Helicopter)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Helicopter, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Catapult)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Catapult, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.House)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.House, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Research)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Research, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.HotAirBaloon)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Balloon, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Training)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Training, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Industry)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Industry, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Power)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Power, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Compressor)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Compressor, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Drone)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Drone, isEvil: false);
				}
				else if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Temple)
				{
					GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4.5f, 0f), 1, GarbageInfo.GarbageTypeEnum.Book, GarbageInfo.CameFromEnum.Temple, isEvil: false);
				}
			}
			if (!CharDisplay.HasRelax)
			{
				switch (Buildings.BuildingType)
				{
				case BaseBuilding.BuildingTypeEnum.Catapult:
					GameController.Instance.ToastPanel.AddItem("A Catapult with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.Helicopter:
					GameController.Instance.ToastPanel.AddItem("A Helipad with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.House:
					GameController.Instance.ToastPanel.AddItem("A House with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.Research:
					GameController.Instance.ToastPanel.AddItem("A Research Lab with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.HotAirBaloon:
					GameController.Instance.ToastPanel.AddItem("A Hangar with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.Training:
					GameController.Instance.ToastPanel.AddItem("A Training with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.Industry:
					GameController.Instance.ToastPanel.AddItem("A Factory with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.Power:
					GameController.Instance.ToastPanel.AddItem("A Power building with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.Compressor:
					GameController.Instance.ToastPanel.AddItem("A Compressor with low durability got destroyed.");
					break;
				case BaseBuilding.BuildingTypeEnum.Drone:
					GameController.Instance.ToastPanel.AddItem("A Cloud Seeder with low durability got destroyed.");
					break;
				default:
					GameController.Instance.ToastPanel.AddItem("A building with low durability got destroyed.");
					break;
				}
			}
			else
			{
				switch (Buildings.BuildingType)
				{
				case BaseBuilding.BuildingTypeEnum.Catapult:
					GameController.Instance.ToastPanel.AddItem("A Catapult's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.Helicopter:
					GameController.Instance.ToastPanel.AddItem("A Helipad's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.House:
					GameController.Instance.ToastPanel.AddItem("A House's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.Research:
					GameController.Instance.ToastPanel.AddItem("A Research Lab's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.HotAirBaloon:
					GameController.Instance.ToastPanel.AddItem("A Hangar's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.Training:
					GameController.Instance.ToastPanel.AddItem("A Training's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.Industry:
					GameController.Instance.ToastPanel.AddItem("A Factory's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.Power:
					GameController.Instance.ToastPanel.AddItem("A Power building's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.Compressor:
					GameController.Instance.ToastPanel.AddItem("A Compressor's durability went to zero and got reset.");
					break;
				case BaseBuilding.BuildingTypeEnum.Drone:
					GameController.Instance.ToastPanel.AddItem("A Cloud Seeder's durability went to zero and got reset.");
					break;
				default:
					GameController.Instance.ToastPanel.AddItem("A building's durability reached zero and was reset.");
					break;
				}
			}
			GlobalSfx2Controller.Instance.Play(SoundManager.SoundTypeEnum.ba_destroy_building_s);
			for (int j = 0; j < Buildings.YellowShardCountWhenDurabilityDown(); j++)
			{
				GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4f, 0f), 1, GarbageInfo.GarbageTypeEnum.ShardYellow, GarbageInfo.CameFromEnum.None, isEvil: false);
			}
			if (CharDisplay.HasRelax)
			{
				Buildings.ResetStability();
			}
			else
			{
				DestroyBuilding(Buildings, GameController.Instance.GetStabilityDestroyPercentage(), Compressor.GlobalInfo.CanMediumOnLowStabilityAttribute.IsEnabled);
			}
			GlobalSfx2Controller.Instance.PlayFromDistance(SoundManager.SoundTypeEnum.ga_shard_appear, base.transform.position.x);
			if (flag && Installation.CanGenerateEvilGarbage())
			{
				GameController.Instance.GarbageController.Generate(new Vector3(base.transform.position.x, 4f, 0f), 1, GarbageInfo.GarbageTypeEnum.ShardRed, GarbageInfo.CameFromEnum.None, isEvil: false);
				GlobalSfx2Controller.Instance.PlayFromDistance(SoundManager.SoundTypeEnum.ga_signing, base.transform.position.x);
			}
		}
		if (StabilityProgress != null)
		{
			if (Buildings != null)
			{
				if (Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Hole || Buildings.BuildingType == BaseBuilding.BuildingTypeEnum.Temple)
				{
					StabilityProgress.SetActive(value: false);
				}
				else
				{
					float num = 1f;
					num = ((Buildings.BuildingType != BaseBuilding.BuildingTypeEnum.Rock) ? Buildings.GetStabilityPercentage() : ((Rock)Buildings).GetRockPercentage());
					float num2 = _stabilityProgressOriginalScaleX * num;
					StabilityProgress.transform.localScale = new Vector2(num2, _stabilityProgressOriginalScaleY);
					StabilityProgress.transform.localPosition = new Vector3(_stabilityProgressOriginalX - (_stabilityProgressOriginalScaleX - num2) / 2f, StabilityProgress.transform.localPosition.y, StabilityProgress.transform.localPosition.z);
					StabilityProgress.SetActive(value: true);
				}
			}
			else
			{
				StabilityProgress.SetActive(value: false);
			}
		}
		if (DotLevel != null)
		{
			DotLevel.ProcessDots(Buildings);
		}
	}

	public BaseBuilding.BuildingTypeEnum GetBuildingType()
	{
		if (Buildings != null)
		{
			return Buildings.BuildingType;
		}
		return BaseBuilding.BuildingTypeEnum.None;
	}

	public BaseBuilding CreateFirstBuilding(BaseBuilding.BuildingTypeEnum type)
	{
		if (Buildings == null)
		{
			BaseBuilding baseBuilding = null;
			Vector3 zero = Vector3.zero;
			switch (type)
			{
			case BaseBuilding.BuildingTypeEnum.Catapult:
				baseBuilding = Object.Instantiate(CatapultPrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Helicopter:
				baseBuilding = Object.Instantiate(HelicopterPrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Drone:
				baseBuilding = Object.Instantiate(DronePrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.House:
				if (!Industry.GlobalInfo.LevelUpAttribute.IsEnabled)
				{
					Industry.GlobalInfo.LevelUpAttribute.ForceLevel(1);
					GameController.Instance.ToastPanel.AddItem("Factory can now be built.");
				}
				baseBuilding = Object.Instantiate(HousePrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Temple:
				baseBuilding = Object.Instantiate(TemplePrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Research:
				baseBuilding = Object.Instantiate(ResearchPrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.HotAirBaloon:
				baseBuilding = Object.Instantiate(HotAirStationPrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Store:
				baseBuilding = Object.Instantiate(StorePrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Training:
				baseBuilding = Object.Instantiate(TrainingPrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Industry:
				if (!Catapult.GlobalInfo.LevelUpAttribute.IsEnabled)
				{
					Catapult.GlobalInfo.LevelUpAttribute.ForceLevel(1);
					GameController.Instance.ToastPanel.AddItem("Catapult can now be built.");
				}
				baseBuilding = Object.Instantiate(IndustryPrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Power:
				baseBuilding = Object.Instantiate(PowerPrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Rock:
				baseBuilding = Object.Instantiate(RockPrefab, zero, Quaternion.identity, base.transform);
				break;
			case BaseBuilding.BuildingTypeEnum.Compressor:
				baseBuilding = Object.Instantiate(CompressorPrefab, zero, Quaternion.identity, base.transform);
				break;
			}
			if (baseBuilding != null)
			{
				baseBuilding.UniqueNumber = GameController.Instance.ColumnsController.GetNewUniqueIndex();
				baseBuilding.ParentColumn = this;
				baseBuilding.gameObject.transform.localPosition = Vector3.zero;
				Buildings = baseBuilding;
			}
			Buildings.ChangeIsOnTop(GameController.Instance.AreBuildingOnTop);
		}
		GameController.Instance.ColumnsController.UpdateColumnUpdatedByPower();
		return Buildings;
	}

	public Vector3 GetEnterLocation()
	{
		if (Buildings != null)
		{
			return Buildings.GetEnterLocation();
		}
		return Vector3.zero;
	}

	public bool CanEnter(CharV2 c)
	{
		if (Buildings != null && Buildings.CanEnter(c))
		{
			return true;
		}
		return false;
	}

	public void ReserveBuilding(CharV2 c)
	{
		if (Buildings != null && Buildings.CanEnter(c))
		{
			Buildings.AddWorker(c);
		}
	}

	public void EnterBuilding(CharV2 c)
	{
		if (Buildings != null && Buildings.CanEnter(c))
		{
			Buildings.EnterBuilding(c);
		}
	}

	public bool CanDumbGarbage(Garbage g)
	{
		if (Buildings != null && Buildings.CanDumbGarbage(g, ignoreBan: false))
		{
			return true;
		}
		return false;
	}

	public bool DumpGarbage(Garbage g)
	{
		if (Buildings != null && Buildings.CanDumbGarbage(g, ignoreBan: true))
		{
			g.IsReserved = false;
			g.transform.parent = base.transform;
			Buildings.DumpGarbage(g);
			return true;
		}
		return false;
	}

	public void DestroyBuilding(BaseBuilding building, float percentageGiven, bool canOutputMedium)
	{
		float num = Buildings.MoneySpent;
		if (Buildings != null)
		{
			if (Buildings is Catapult)
			{
				foreach (GarbageInfo item in ((Catapult)Buildings).GetAllStored())
				{
					num += (float)item.Weight;
				}
			}
			if (Buildings is Compressor)
			{
				foreach (GarbageInfo item2 in ((Compressor)Buildings).GetAllStored())
				{
					num += (float)item2.Weight;
				}
			}
			LocalSfx2Controller.StopLoop();
			Buildings.DirectDestroyBuilding();
		}
		Buildings = null;
		int num2 = (int)(num * percentageGiven);
		if (num <= 15f)
		{
			num2 = (int)num;
		}
		if (!canOutputMedium)
		{
			int num3 = 0;
			int num4 = 5;
			if (num2 / num4 > 50)
			{
				num4 = num2 / 50;
			}
			num3 = num2 / num4;
			for (int i = 0; i < num3; i++)
			{
				GameController.Instance.GarbageController.Generate(base.transform.position + new Vector3(0f, 3f, 0f), num4, GarbageInfo.GarbageTypeEnum.GarbageS, GarbageInfo.CameFromEnum.None, isEvil: false).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
			}
		}
		else
		{
			int num5 = 0;
			int num6 = 25;
			if (num2 / num6 > 50)
			{
				num6 = num2 / 50;
			}
			num5 = num2 / num6;
			for (int j = 0; j < num5; j++)
			{
				GameController.Instance.GarbageController.Generate(base.transform.position + new Vector3(0f, 3f, 0f), num6, GarbageInfo.GarbageTypeEnum.GarbageM, GarbageInfo.CameFromEnum.None, isEvil: false).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-3, 3), 3f), ForceMode2D.Impulse);
			}
		}
		GameController.Instance.PeonController.VerifyPeonDestination();
		GameController.Instance.ColumnsController.UpdateColumnUpdatedByPower();
	}

	public void EarthquakeReduceStability()
	{
		if (Buildings != null)
		{
			Buildings.EarthquakeReduceStability();
		}
	}

	public void LowerStability(float percentage)
	{
		if (Buildings != null)
		{
			Buildings.LowerStability(percentage);
		}
	}

	public static int CountBuildingType(BaseBuilding.BuildingTypeEnum bt)
	{
		int num = 0;
		foreach (ColumnController column in GameController.Instance.ColumnsController.GetColumns())
		{
			if (column.Buildings != null && column.Buildings.BuildingType == bt)
			{
				num++;
			}
		}
		return num;
	}
}
