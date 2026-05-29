using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public enum State
	{
		Idle = 0,
		CanPlantSeed = 1,
		CanBuild = 2,
		CanBuildHouse = 3,
		CanUpgrade = 4,
		CanDecorate = 5,
		CanPlaceAnimal = 6,
		CanFertilize = 7,
		CanDemolish = 8,
		CanRemoveCrop = 9,
		CanMoveBuilding = 10,
		IsMovingBuilding = 11,
		CanInspectCrops = 12,
		CanPlaceSign = 13,
		CanRemoveSign = 14,
		CanMoveAnimal = 15,
		IsMovingAnimal = 16
	}

	public string build;

	public bool demo;

	public bool qualityUpdate;

	public bool contentUpdate;

	public bool disablePlayerLog;

	public static GameManager ins;

	public State state;

	[Header("Settings")]
	public bool dev_mode;

	[SerializeField]
	private GameObject dev_console;

	[SerializeField]
	private GameObject crossover_button;

	[SerializeField]
	private TMP_Text dev_timer;

	[SerializeField]
	private TMP_Text dev_fps;

	private int lastFrameIndex;

	private float[] frameDeltaTimeArray;

	public float timeElapsed;

	public float totalTimeElapsed;

	[SerializeField]
	private TMP_Text timeElapsedText;

	public float tooltipFade = 0.3f;

	public Color lockedC = new Color(0f, 0f, 0f, 0.2f);

	[SerializeField]
	private GameObject paused;

	[Header("General audio")]
	public AudioClip tickAudio;

	public AudioClip errorAudio;

	[Header("Grid color")]
	public Color gridColor;

	public Color highlightColor;

	[Header("Watering can")]
	public int chatterCharges = 4;

	public int maxWaterUses = 6;

	public List<WaterSource> waterSources;

	[Header("Crops")]
	public CropType cropSelected;

	public int currentCropSelectedIndexInInventory;

	public bool spawnGoldenPumpkin;

	public GiantCrop goldenGiantPumpkin;

	public GiantCrop giantPumpkin;

	public GiantCrop giantTomato;

	public GiantCrop giantCucumber;

	public GiantCrop giantZucchini;

	public GiantCrop giantRedCabbage;

	public GiantCrop giantWhitePumpkin;

	public Sprite jackoLanternCropSprite;

	public Sprite[] jackoLanternSprites;

	public CropManager cropManager;

	public List<CropSlot> cropSlots;

	public List<CropPatch> cropPatches;

	[Header("Buildings")]
	public BuildingManager buildingManager;

	public GridSystem gridSystem;

	public List<Building> buildings;

	public List<GameObject> bots;

	public List<BuildingBox> boxesToMove;

	public List<BiofuelConverter> bioConverters;

	public List<Collider2D> storageUnits;

	public List<Collider2D> fertilizerFacilities;

	public List<House> housesToBeBuilt;

	public List<House> houses;

	public List<Beehive> beehives;

	public List<GameObject> beesButterflies;

	public List<BulbletAI> bees;

	public List<Transform> flowers;

	public List<BerryBush> berryBushes;

	public List<Tree> trees;

	public List<GameObject> animals;

	public List<Bench> benches;

	[Header("Reaper Shop")]
	public ReaperShopUI reaperShopPanel;

	public float reaperTimer;

	public Sprite commonChipSprite;

	public Sprite rareChipSprite;

	public Sprite legendaryChipSprite;

	public Sprite uberChipSprite;

	public Sprite commonChipMiniSprite;

	public Sprite rareChipMiniSprite;

	public Sprite legendaryChipMiniSprite;

	public Sprite uberChipMiniSprite;

	[Header("Animal farming")]
	public Fossil fossil;

	public List<Feeder> feeders;

	public List<Poop> piecesOfPoop;

	public int numberOfCows;

	public int numberOfPigs;

	public int numberOfChickens;

	public List<GoldcrestPos> goldcrestPositions;

	public List<Deer> deers;

	[Header("Mining")]
	public BuildingSO beltUp;

	public BuildingSO beltRight;

	public BuildingSO beltDown;

	public BuildingSO beltLeft;

	[Header("Blocked lands")]
	public BlockedLand.State[] blockedLands;

	public BlockedLand[] blockedLandObjects;

	public int[] blockedLandCosts;

	private int timeSpeed = 1;

	[Header("Selected")]
	public BuildingSO buildingSelected;

	public Building buildingSelectedForMoving;

	public int buildingSPCost;

	public int buildingBFCost;

	public int buildingFOCost;

	public Decoration decorSelected;

	public Decoration decorSelectedForMoving;

	public House houseSelected;

	public House houseSelectedForMoving;

	public AnimalSO animalSelected;

	public Animal animalSelectedForMoving;

	public int animalFSCost;

	public int animalBFCost;

	public CropSO cropSignSelected;

	[Header("Houses")]
	public List<CharacterInteraction> npcs;

	public WorkerAI rusty;

	public PrioritySystem rustyPriority;

	public WorkerAI haiku;

	public PrioritySystem haikuPriority;

	public FossilWorkerAI slate;

	public bool autoPlantSeeds = true;

	public bool canUpgradeBuildings;

	public GameObject[] echoUnlocks;

	public GameObject echoBlocker;

	public GameObject[] shopUnlocks;

	public GameObject shopBlocker;

	public GameObject[] haikuUnlocks;

	public GameObject haikuBlocker;

	public GameObject[] slateUnlocks;

	public GameObject slateBlocker;

	public GameObject[] forbicUnlocks;

	public GameObject forbicBlocker;

	public GameObject[] pinionUnlocks;

	public GameObject pinionBlocker;

	[Header("Robot stats")]
	public int waterBotCharges = 4;

	public int harvestBotCharges = 6;

	public int carryBotCharges = 4;

	public int berryBotCharges = 3;

	public int wasteBotCharges = 5;

	public int fertilizerBotCharges = 6;

	public int feederBotCharges = 4;

	public int biofuelToSparePartsRatio = 10;

	[Header("Incremental prices")]
	public int incrWaterBotSpeed;

	public int incrHarvestBotSpeed;

	public int incrCarryBotSpeed;

	public int incrFeederBotSpeed;

	public int incrWasteBotSpeed;

	public int incrFertBotSpeed;

	public int incrBerryBotSpeed;

	public int incrWaterBotCapacity;

	public int incrHarvestBotCapacity;

	public int incrCarryBotCapacity;

	public int incrFeederBotCapacity;

	public int incrWasteBotCapacity;

	public int incrFertBotCapacity;

	public int incrBerryBotCapacity;

	[Space]
	public int berryBushSPPrice;

	public float berryBushSPCoefficient;

	[Space]
	public int berryBushBFPrice;

	public float berryBushBFCoefficient;

	[Header("Camera")]
	public Camera mainCam;

	public Camera clearCam;

	[HideInInspector]
	public Vector2 mousePositionInWorld;

	public bool canUseLetterShortcuts = true;

	[Header("Night mode")]
	public bool isNight;

	[Header("Pop up number")]
	public GameObject popUpParent;

	public ResourcePopUp popUp;

	public ResourcePopUp sparePartsPopUp;

	public ResourcePopUp biofuelPopUp;

	public ResourcePopUp fossilPopUp;

	public ResourcePopUp fertPopUp;

	public ResourcePopUp regrowthPopUp;

	public ResourcePopUp iconPopUp;

	public ResourcePopUp heartPopUp;

	[Header("Tutorial boxes")]
	public bool firstBuild;

	public bool convertBiofuelTutorialPlayed;

	public GameObject convertBiofuelTutorial;

	public TitleScreen titleScreenScript;

	public Sprite removeIcontip;

	public Sprite inspectIcon;

	public string missing404;

	public bool isLoadingNewGame;

	public SidePanelManager sidePanelManager;

	[Header("Swap Font")]
	public TMP_FontAsset fontAsset;

	[Header("Crossover Things")]
	public List<VampireBat> vampireBats;

	public GarlicCircle garlicCircle;

	public List<VampireSurvivorExperienceMagnet> expMagnets;

	public GameObject balatroCard;

	public BalatroPopUp balatroPopUp;

	public List<BalatroJokerHand> jokerHands;

	public bool balatroSoundEffects = true;

	private float initialTimeElapsed;

	private float initialTotalTimeElapsed;

	private int month;

	private List<CropType> cropsUnlockedList = new List<CropType>();

	private bool alternateRandomCropSlot;

	private void Awake()
	{
		ins = this;
		frameDeltaTimeArray = new float[50];
	}

	private string TimeFormatter(float seconds)
	{
		float num = Mathf.Floor(seconds % 60f * 100f) / 100f;
		int num2 = (int)(seconds / 60f) % 60;
		int num3 = (int)(seconds / 3600f);
		return $"{num3}:{num2:00}:{num:00}";
	}

	private float CalculateFPS()
	{
		float num = 0f;
		for (int i = 0; i < frameDeltaTimeArray.Length; i++)
		{
			num += frameDeltaTimeArray[i];
		}
		return (float)frameDeltaTimeArray.Length / num;
	}

	private void Start()
	{
		initialTimeElapsed = timeElapsed;
		initialTotalTimeElapsed = totalTimeElapsed;
	}

	private void TestBelts(BuildingSO beltType)
	{
		ins.buildingSelected = beltType;
		ins.buildingSPCost = 10;
		ins.buildingBFCost = 1;
		ins.buildingFOCost = 0;
		ins.state = State.CanBuild;
	}

	private void Update()
	{
		timeElapsed = initialTimeElapsed + Time.timeSinceLevelLoad;
		totalTimeElapsed = initialTotalTimeElapsed + Time.timeSinceLevelLoad;
		AchievementManager.ins.CheckTimer(timeElapsed);
		AchievementManager.ins.CheckTimer(totalTimeElapsed);
		mousePositionInWorld = mainCam.ScreenToWorldPoint(Input.mousePosition);
		if (dev_mode)
		{
			dev_timer.text = TimeFormatter(timeElapsed);
		}
		if (timeElapsedText.gameObject.activeInHierarchy)
		{
			timeElapsedText.text = TimeFormatter(timeElapsed);
		}
		if (dev_mode && Input.GetKeyDown(KeyCode.RightArrow))
		{
			timeSpeed *= 2;
			if (timeSpeed > 64)
			{
				timeSpeed = 64;
			}
			Time.timeScale = timeSpeed;
		}
		if (dev_mode && Input.GetKeyDown(KeyCode.LeftArrow))
		{
			timeSpeed /= 2;
			if (timeSpeed < 1)
			{
				timeSpeed = 1;
			}
			Time.timeScale = timeSpeed;
		}
		if (dev_mode && Input.GetKeyDown(KeyCode.W))
		{
			TestBelts(beltUp);
		}
		if (dev_mode && Input.GetKeyDown(KeyCode.S))
		{
			TestBelts(beltDown);
		}
		if (dev_mode && Input.GetKeyDown(KeyCode.A))
		{
			TestBelts(beltLeft);
		}
		if (dev_mode && Input.GetKeyDown(KeyCode.D))
		{
			TestBelts(beltRight);
		}
		if (dev_mode)
		{
			frameDeltaTimeArray[lastFrameIndex] = Time.deltaTime;
			lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;
			dev_fps.text = CalculateFPS().ToString("n0");
		}
		if (Input.GetKey(KeyCode.J) && Input.GetKeyDown(KeyCode.L))
		{
			dev_mode = !dev_mode;
			dev_console.SetActive(dev_mode);
			if (SaveData.ins.verticalMode)
			{
				dev_console.GetComponent<RectTransform>().anchoredPosition = new Vector2(102f, -186f);
			}
			dev_timer.gameObject.SetActive(dev_mode);
			dev_fps.gameObject.SetActive(dev_mode);
			crossover_button.SetActive(value: true);
		}
		if (canUseLetterShortcuts && (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Space)))
		{
			if (Time.timeScale <= 0f)
			{
				Unpause();
			}
			else
			{
				Pause();
			}
		}
		if ((state == State.CanPlantSeed && Input.GetMouseButtonDown(1)) || (state == State.CanPlantSeed && Input.GetKeyDown(KeyCode.Escape)))
		{
			SetStateToIdle();
		}
		if ((state == State.CanRemoveCrop && Input.GetMouseButtonDown(1)) || (state == State.CanRemoveCrop && Input.GetKeyDown(KeyCode.Escape)))
		{
			SetStateToIdle();
		}
		if ((state == State.CanDemolish && Input.GetMouseButtonDown(1)) || (state == State.CanDemolish && Input.GetKeyDown(KeyCode.Escape)))
		{
			SetStateToIdle();
		}
		if ((state == State.CanUpgrade && Input.GetMouseButtonDown(1)) || (state == State.CanUpgrade && Input.GetKeyDown(KeyCode.Escape)))
		{
			UpgradePanel.ins.HideUpgradePanel();
		}
		if ((state == State.CanInspectCrops && Input.GetMouseButtonDown(1)) || (state == State.CanInspectCrops && Input.GetKeyDown(KeyCode.Escape)))
		{
			SetStateToIdle();
		}
		if ((state == State.CanPlaceSign && Input.GetMouseButtonDown(1)) || (state == State.CanPlaceSign && Input.GetKeyDown(KeyCode.Escape)))
		{
			SetStateToIdle();
		}
		if ((state == State.CanRemoveSign && Input.GetMouseButtonDown(1)) || (state == State.CanRemoveSign && Input.GetKeyDown(KeyCode.Escape)))
		{
			SetStateToIdle();
		}
		if (canUseLetterShortcuts && (Input.GetKeyDown(KeyCode.Backspace) || Input.GetKeyDown(KeyCode.Delete)))
		{
			if (state != State.CanDemolish)
			{
				state = State.CanDemolish;
				SoundManager.ins.PlaySound(tickAudio);
				TooltipSystem.ShowIcontip(removeIcontip);
			}
			else
			{
				SetStateToIdle();
			}
		}
		if (canUseLetterShortcuts && Input.GetKeyDown(KeyCode.I))
		{
			if (state != State.CanInspectCrops)
			{
				state = State.CanInspectCrops;
				SoundManager.ins.PlaySound(tickAudio);
				TooltipSystem.ShowIcontip(inspectIcon);
			}
			else
			{
				SetStateToIdle();
			}
		}
		if (canUseLetterShortcuts && Input.GetKeyDown(KeyCode.R))
		{
			if (SaveData.ins.transparencyMode != 3)
			{
				Screen.SetResolution(Screen.width, Screen.height, FullScreenMode.FullScreenWindow);
			}
			mainCam.GetComponent<CameraZoomAndMove>().Restart();
		}
		if (canUseLetterShortcuts && Input.GetKeyDown(KeyCode.T))
		{
			mainCam.GetComponent<DisplayChanger>().ResetGameResolutionOnCurrentDisplay();
			mainCam.GetComponent<TransparentWindow>().ResetGameResolutionOnCurrentDisplay();
			mainCam.GetComponent<PlainWindow>().ResetGameResolutionOnCurrentDisplay();
			mainCam.GetComponent<CameraZoomAndMove>().Restart();
		}
	}

	public void Unpause()
	{
		Time.timeScale = 1f;
		if ((bool)paused)
		{
			paused.SetActive(value: false);
		}
	}

	private void Pause()
	{
		Time.timeScale = 0f;
		if ((bool)paused)
		{
			paused.SetActive(value: true);
		}
	}

	public void SetStateToIdle()
	{
		state = State.Idle;
		TooltipSystem.HideIcontip();
		TooltipSystem.HideSigntip();
		GridSystem.ins.cursor.Hide();
		GridSystem.ins.cursor.ChangeRangeTo(0);
	}

	public void SetCurrentCropSelectedTo(CropType cropType)
	{
		cropSelected = cropType;
		currentCropSelectedIndexInInventory = Inventory.ins.getCropIndexInInventoryList(cropType);
	}

	public int getCropIndexInList(CropType type)
	{
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return i;
			}
		}
		return -1;
	}

	public string getCropName(CropType type)
	{
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return cropManager.cropCatalog[i].cropName;
			}
		}
		return "";
	}

	public bool isCropUnlocked(CropType type)
	{
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return cropManager.cropUnlocked[i];
			}
		}
		return false;
	}

	public void SetCropUnlocked(CropType type, bool state)
	{
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				cropManager.cropUnlocked[i] = state;
				break;
			}
		}
	}

	public float getCropDaysToGrow(CropType type)
	{
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return cropManager.cropCatalog[i].growingDays;
			}
		}
		return 0f;
	}

	public int getCropWaterDemand(CropType type)
	{
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return cropManager.cropCatalog[i].waterDemand;
			}
		}
		return 0;
	}

	public Sprite getCropSprite(CropType type)
	{
		if (type == CropType.Pumpkin && IsOctober())
		{
			return jackoLanternCropSprite;
		}
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return cropManager.cropCatalog[i].cropSprite;
			}
		}
		return null;
	}

	public Sprite[] getCropSprites(CropType type)
	{
		Sprite[] array = new Sprite[6];
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				for (int j = 0; j < cropManager.cropCatalog[i].spriteList.Length; j++)
				{
					array[j] = cropManager.cropCatalog[i].spriteList[j];
				}
				break;
			}
		}
		if (type == CropType.Pumpkin && IsOctober())
		{
			for (int k = 0; k < jackoLanternSprites.Length; k++)
			{
				array[k] = jackoLanternSprites[k];
			}
		}
		return array;
	}

	public bool IsOctober()
	{
		if (month == 0)
		{
			month = DateTime.Now.Month;
		}
		return month == 10;
	}

	public Sprite getCropSeedSprite(CropType type)
	{
		Sprite result = null;
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return cropManager.cropCatalog[i].spriteList[0];
			}
		}
		return result;
	}

	public int getCropBiofuelYield(CropType type)
	{
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return cropManager.cropCatalog[i].biofuelYield;
			}
		}
		return 0;
	}

	public CropSO getCropSO(CropType type)
	{
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType == type)
			{
				return cropManager.cropCatalog[i];
			}
		}
		Debug.Log("Cannot find crop scriptable object", this);
		return null;
	}

	public CropType getRandomUnlockedCrop()
	{
		cropsUnlockedList.Clear();
		for (int i = 0; i < cropManager.cropCatalog.Length; i++)
		{
			if (cropManager.cropCatalog[i].cropType != CropType.Raspberries && cropManager.cropCatalog[i].cropType != CropType.Blackberries && cropManager.cropCatalog[i].cropType != CropType.Blueberries && cropManager.cropCatalog[i].cropType != CropType.Strawberry && cropManager.cropCatalog[i].cropType != CropType.RedGooseberries && cropManager.cropCatalog[i].cropType != CropType.Cloudberries && cropManager.cropCatalog[i].cropType != CropType.Boysenberries && cropManager.cropCatalog[i].cropType != CropType.BlackCurrant && cropManager.cropCatalog[i].cropType != CropType.RedCurrant && cropManager.cropUnlocked[i])
			{
				cropsUnlockedList.Add(cropManager.cropCatalog[i].cropType);
			}
		}
		return cropsUnlockedList[UnityEngine.Random.Range(0, cropsUnlockedList.Count)];
	}

	public BuildingSO getBuildingSO(BuildingType building)
	{
		for (int i = 0; i < buildingManager.buildCatalog.Length; i++)
		{
			if (buildingManager.buildCatalog[i].buildType == building)
			{
				return buildingManager.buildCatalog[i];
			}
		}
		return null;
	}

	public CropSlot getClosestCropSlotThat(CropSlot.State state, Vector2 workerPos)
	{
		if (cropSlots.Count == 0)
		{
			return null;
		}
		List<CropSlot> list = new List<CropSlot>();
		for (int i = 0; i < cropSlots.Count; i++)
		{
			if (cropSlots[i].state == state)
			{
				list.Add(cropSlots[i]);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		CropSlot result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public CropSlot getClosestCropSlotThat(CropSlot.State state, Vector2 workerPos, Vector2 station, float range)
	{
		if (cropSlots.Count == 0)
		{
			return null;
		}
		List<CropSlot> list = new List<CropSlot>();
		for (int i = 0; i < cropSlots.Count; i++)
		{
			if (!(Vector2.Distance(cropSlots[i].transform.position, station) > range) && cropSlots[i].state == state)
			{
				list.Add(cropSlots[i]);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		CropSlot result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public CropSlot getClosestCropSlotThatCanBeSeeded(Vector2 workerPos)
	{
		if (cropSlots.Count == 0)
		{
			return null;
		}
		List<CropSlot> list = new List<CropSlot>();
		for (int i = 0; i < cropSlots.Count; i++)
		{
			if ((!(cropSlots[i].cropPatchParent.cropSign != null) || cropSlots[i].cropPatchParent.cropSign.getCropType() != CropType.DontSeedSign) && cropSlots[i].state == CropSlot.State.Empty)
			{
				list.Add(cropSlots[i]);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		CropSlot result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public CropSlot getClosestCropSlotThatNeedsFertilizer(Vector2 workerPos, Vector2 station, float range)
	{
		if (cropSlots.Count == 0)
		{
			return null;
		}
		List<CropSlot> list = new List<CropSlot>();
		for (int i = 0; i < cropSlots.Count; i++)
		{
			if (!(Vector2.Distance(cropSlots[i].transform.position, station) > range) && cropSlots[i].fertilizedTimer <= 0f && !cropSlots[i].markedForFertilizing)
			{
				list.Add(cropSlots[i]);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		CropSlot result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public CropPatch getClosestCropPatch(Vector2 workerPos)
	{
		CropPatch result = null;
		CropSlot closestCropSlotThat = getClosestCropSlotThat(CropSlot.State.Empty, workerPos);
		if (closestCropSlotThat != null)
		{
			result = closestCropSlotThat.cropPatchParent;
		}
		return result;
	}

	public CropPatch getClosestEmptyCropPatch(Vector2 workerPos)
	{
		if (cropSlots.Count == 0)
		{
			return null;
		}
		List<CropPatch> list = new List<CropPatch>();
		for (int i = 0; i < cropSlots.Count; i++)
		{
			if (cropSlots[i].state != CropSlot.State.Empty || list.Contains(cropSlots[i].cropPatchParent))
			{
				continue;
			}
			bool flag = true;
			for (int j = 0; j < cropSlots[i].cropPatchParent.cropSlots.Length; j++)
			{
				if (cropSlots[i].cropPatchParent.cropSlots[j].state != CropSlot.State.Empty)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				list.Add(cropSlots[i].cropPatchParent);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		CropPatch result = null;
		float num = 99999f;
		for (int k = 0; k < list.Count; k++)
		{
			float num2 = Vector2.Distance(list[k].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[k];
				num = num2;
			}
		}
		return result;
	}

	public Building getClosestBuildSlotThat(Building.State state, Vector2 workerPos)
	{
		if (buildings.Count == 0)
		{
			return null;
		}
		List<Building> list = new List<Building>();
		for (int i = 0; i < buildings.Count; i++)
		{
			if (buildings[i].state == state)
			{
				list.Add(buildings[i]);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		Building result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].center.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public BuildingBox getClosestBuildingBoxThat(BuildingBox.State state, Vector2 workerPos)
	{
		if (boxesToMove.Count == 0)
		{
			return null;
		}
		List<BuildingBox> list = new List<BuildingBox>();
		for (int i = 0; i < boxesToMove.Count; i++)
		{
			if (boxesToMove[i].state == state)
			{
				list.Add(boxesToMove[i]);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		BuildingBox result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(boxesToMove[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public BiofuelSlot getClosestBiofuelSlotThat(BiofuelSlot.State state, Vector2 workerPos)
	{
		if (bioConverters.Count == 0)
		{
			return null;
		}
		List<BiofuelSlot> list = new List<BiofuelSlot>();
		for (int i = 0; i < bioConverters.Count; i++)
		{
			for (int j = 0; j < bioConverters[i].allSlots.Length; j++)
			{
				if (bioConverters[i].allSlots[j].state == state)
				{
					list.Add(bioConverters[i].allSlots[j]);
				}
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		BiofuelSlot result = null;
		float num = 99999f;
		for (int k = 0; k < list.Count; k++)
		{
			float num2 = Vector2.Distance(list[k].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[k];
				num = num2;
			}
		}
		return result;
	}

	public WaterSource getClosestWaterSource(Vector2 workerPos)
	{
		if (waterSources.Count == 0)
		{
			return null;
		}
		List<WaterSource> list = new List<WaterSource>();
		for (int i = 0; i < waterSources.Count; i++)
		{
			list.Add(waterSources[i]);
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		WaterSource result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public Vector2 getClosestPointOnWaterSourceCollider(WaterSource waterSource, Vector2 workerPos)
	{
		return waterSource.GetComponent<Collider2D>().ClosestPoint(workerPos);
	}

	public Vector2 getClosestStorage(Vector2 workerPos)
	{
		if (storageUnits.Count == 0)
		{
			return Vector2.zero;
		}
		List<Collider2D> list = new List<Collider2D>();
		for (int i = 0; i < storageUnits.Count; i++)
		{
			list.Add(storageUnits[i]);
		}
		if (list.Count == 1)
		{
			return list[0].ClosestPoint(workerPos);
		}
		Collider2D collider2D = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].ClosestPoint(workerPos), workerPos);
			if (num2 < num)
			{
				collider2D = list[j];
				num = num2;
			}
		}
		return collider2D.ClosestPoint(workerPos);
	}

	public Vector2 getClosestFertilizerFacility(Vector2 workerPos)
	{
		if (fertilizerFacilities.Count == 0)
		{
			return Vector2.zero;
		}
		List<Collider2D> list = new List<Collider2D>();
		for (int i = 0; i < fertilizerFacilities.Count; i++)
		{
			list.Add(fertilizerFacilities[i]);
		}
		if (list.Count == 1)
		{
			return list[0].ClosestPoint(workerPos);
		}
		Collider2D collider2D = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].ClosestPoint(workerPos), workerPos);
			if (num2 < num)
			{
				collider2D = list[j];
				num = num2;
			}
		}
		return collider2D.ClosestPoint(workerPos);
	}

	public Bench getClosestBench(Vector2 workerPos)
	{
		if (benches.Count == 0)
		{
			return null;
		}
		List<Bench> list = new List<Bench>();
		for (int i = 0; i < benches.Count; i++)
		{
			if (!benches[i].occupied)
			{
				list.Add(benches[i]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		Bench result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public FeederSlot getClosestFeederSlotTo(FeederSlot.State state, Vector2 workerPos, Vector2 parentStation, float range)
	{
		if (feeders.Count == 0)
		{
			return null;
		}
		List<FeederSlot> list = new List<FeederSlot>();
		for (int i = 0; i < feeders.Count; i++)
		{
			if (Vector2.Distance(feeders[i].transform.position, parentStation) > range)
			{
				continue;
			}
			for (int j = 0; j < feeders[i].feederSlots.Length; j++)
			{
				if (feeders[i].feederSlots[j].state == state)
				{
					list.Add(feeders[i].feederSlots[j]);
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		FeederSlot result = null;
		float num = 99999f;
		for (int k = 0; k < list.Count; k++)
		{
			float num2 = Vector2.Distance(list[k].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[k];
				num = num2;
			}
		}
		return result;
	}

	public FeederSlot getAvailableFeederSlotFrom(AnimalSlot animalSlot)
	{
		List<FeederSlot> list = new List<FeederSlot>();
		for (int i = 0; i < animalSlot.parentFeeder.feederSlots.Length; i++)
		{
			if (animalSlot.parentFeeder.feederSlots[i].state == FeederSlot.State.Filled)
			{
				list.Add(animalSlot.parentFeeder.feederSlots[i]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public Poop getClosestPoopThat(Poop.State state, Vector2 workerPos, Vector2 station, float range)
	{
		if (piecesOfPoop.Count == 0)
		{
			return null;
		}
		List<Poop> list = new List<Poop>();
		for (int i = 0; i < piecesOfPoop.Count; i++)
		{
			if (!(Vector2.Distance(piecesOfPoop[i].transform.position, station) > range) && piecesOfPoop[i].state == state)
			{
				list.Add(piecesOfPoop[i]);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		Poop result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public BerryBush getClosestBerryBushThat(BerryBush.State state, Vector2 workerPos, Vector2 station, float range)
	{
		if (berryBushes.Count == 0)
		{
			return null;
		}
		List<BerryBush> list = new List<BerryBush>();
		for (int i = 0; i < berryBushes.Count; i++)
		{
			if (!(Vector2.Distance(berryBushes[i].transform.position, station) > range) && berryBushes[i].state == state)
			{
				list.Add(berryBushes[i]);
			}
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		BerryBush result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public Beehive getClosestBeehiveTo(Vector2 workerPos)
	{
		if (beehives.Count == 0)
		{
			return null;
		}
		if (beehives.Count == 1)
		{
			return beehives[0];
		}
		Beehive result = null;
		float num = 99999f;
		for (int i = 0; i < beehives.Count; i++)
		{
			float num2 = Vector2.Distance(beehives[i].transform.position, workerPos);
			if (num2 < num)
			{
				result = beehives[i];
				num = num2;
			}
		}
		return result;
	}

	public Beehive getClosestBeehiveMarkedForHarvest(Vector2 workerPos)
	{
		if (beehives.Count == 0)
		{
			return null;
		}
		List<Beehive> list = new List<Beehive>();
		for (int i = 0; i < beehives.Count; i++)
		{
			if (beehives[i].markedForHarvest)
			{
				list.Add(beehives[i]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		if (list.Count == 1)
		{
			return list[0];
		}
		Beehive result = null;
		float num = 99999f;
		for (int j = 0; j < list.Count; j++)
		{
			float num2 = Vector2.Distance(list[j].transform.position, workerPos);
			if (num2 < num)
			{
				result = list[j];
				num = num2;
			}
		}
		return result;
	}

	public void DistributeBees()
	{
		if (!this)
		{
			return;
		}
		int num = 0;
		int count = beehives.Count;
		if (beehives.Count == 0)
		{
			return;
		}
		for (int i = 0; i < bees.Count; i++)
		{
			bees[i].AssignNewBeehiveAsParent(beehives[num]);
			num++;
			if (num >= count)
			{
				num = 0;
			}
		}
	}

	public BerryBush getClosestBerryBushTo(Vector2 workerPos)
	{
		if (berryBushes.Count == 0)
		{
			return null;
		}
		if (berryBushes.Count == 1)
		{
			return berryBushes[0];
		}
		BerryBush result = null;
		float num = 99999f;
		for (int i = 0; i < berryBushes.Count; i++)
		{
			float num2 = Vector2.Distance(berryBushes[i].transform.position, workerPos);
			if (num2 < num)
			{
				result = berryBushes[i];
				num = num2;
			}
		}
		return result;
	}

	public BlockedLand getBlockedLandMarkedForClearing()
	{
		for (int i = 0; i < blockedLands.Length; i++)
		{
			if (blockedLands[i] == BlockedLand.State.MarkedForClearing)
			{
				return blockedLandObjects[i];
			}
		}
		return null;
	}

	public Vector2Int getRandomUnlockedTileCoord()
	{
		List<Vector2Int> list = new List<Vector2Int>();
		for (int i = 0; i < GridSystem.ins.gridSize.x; i++)
		{
			for (int j = 0; j < GridSystem.ins.gridSize.y; j++)
			{
				if (GridSystem.ins.tile[i, j].unlocked)
				{
					list.Add(GridSystem.ins.tile[i, j].coordinates);
				}
			}
		}
		if (list.Count == 0)
		{
			return new Vector2Int(-1, -1);
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public CropSlot getRandomCropSlot()
	{
		List<CropSlot> list = new List<CropSlot>();
		alternateRandomCropSlot = !alternateRandomCropSlot;
		if (alternateRandomCropSlot)
		{
			for (int i = 0; i < cropSlots.Count; i++)
			{
				if (cropSlots[i].state == CropSlot.State.Empty)
				{
					list.Add(cropSlots[i]);
				}
			}
		}
		else
		{
			for (int j = 0; j < cropSlots.Count; j++)
			{
				if (cropSlots[j].state != CropSlot.State.GiantCrop)
				{
					list.Add(cropSlots[j]);
				}
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public CropSlot getRandomCropSlotInRange(Vector2 workerPos, float range)
	{
		List<CropSlot> list = new List<CropSlot>();
		for (int i = 0; i < cropSlots.Count; i++)
		{
			if (!(Vector2.Distance(cropSlots[i].transform.position, workerPos) > range))
			{
				list.Add(cropSlots[i]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public CropSlot getRandomNonImprovedCropSlotInRange(Vector2 workerPos, float range)
	{
		List<CropSlot> list = new List<CropSlot>();
		for (int i = 0; i < cropSlots.Count; i++)
		{
			if (!cropSlots[i].improvedRegrowthCycle && !cropSlots[i].markedForImprovement && cropSlots[i].state != CropSlot.State.Empty && cropSlots[i].state != CropSlot.State.GiantCrop && cropSlots[i].state != CropSlot.State.Fossil && !(Vector2.Distance(cropSlots[i].transform.position, workerPos) > range))
			{
				list.Add(cropSlots[i]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public CropManager.GMO getGMO(CropSO cropSO)
	{
		if (cropSO.cropIndexInList < 0 || cropSO.cropIndexInList >= cropManager.cropGmoStats.Length)
		{
			return default(CropManager.GMO);
		}
		return cropManager.cropGmoStats[cropSO.cropIndexInList];
	}

	public float getClosebyMultiplier(Vector2 workerPos, Vector2 targetPos)
	{
		float num = 0f;
		float num2 = Vector2.Distance(workerPos, targetPos);
		if (num2 > 10f)
		{
			return 0.1f;
		}
		return 1.1f - num2 * 0.1f;
	}

	public CropManager.GMO GetCropGMO(CropSO crop)
	{
		return cropManager.cropGmoStats[crop.cropIndexInList];
	}

	public void IncrementAnimalPricing(AnimalSO animal, int amount)
	{
		if (animal.animalName == "Cow")
		{
			numberOfCows += amount;
		}
		if (animal.animalName == "Pig")
		{
			numberOfPigs += amount;
		}
		if (numberOfCows < 0)
		{
			numberOfCows = 0;
		}
		if (numberOfPigs < 0)
		{
			numberOfPigs = 0;
		}
		if (animal.animalName == "Cow")
		{
			Inventory.ins.RecalculateCowPrices();
		}
		if (animal.animalName == "Pig")
		{
			Inventory.ins.RecalculatePigPrices();
		}
	}

	public void RemoveIncrementalPriceFrom(BuildingType type, int speedLvl, int capacityLvl)
	{
		if (type == BuildingType.WaterBot)
		{
			incrWaterBotSpeed -= speedLvl;
			incrWaterBotCapacity -= capacityLvl;
			if (incrWaterBotSpeed <= 0)
			{
				incrWaterBotSpeed = 0;
			}
			if (incrWaterBotCapacity <= 0)
			{
				incrWaterBotCapacity = 0;
			}
		}
		if (type == BuildingType.HarvestBot)
		{
			incrHarvestBotSpeed -= speedLvl;
			incrHarvestBotCapacity -= capacityLvl;
			if (incrHarvestBotSpeed <= 0)
			{
				incrHarvestBotSpeed = 0;
			}
			if (incrHarvestBotCapacity <= 0)
			{
				incrHarvestBotCapacity = 0;
			}
		}
		if (type == BuildingType.CarryBot)
		{
			incrCarryBotSpeed -= speedLvl;
			incrCarryBotCapacity -= capacityLvl;
			if (incrCarryBotSpeed <= 0)
			{
				incrCarryBotSpeed = 0;
			}
			if (incrCarryBotCapacity <= 0)
			{
				incrCarryBotCapacity = 0;
			}
		}
		if (type == BuildingType.FeederBot)
		{
			incrFeederBotSpeed -= speedLvl;
			incrFeederBotCapacity -= capacityLvl;
			if (incrFeederBotSpeed <= 0)
			{
				incrFeederBotSpeed = 0;
			}
			if (incrFeederBotCapacity <= 0)
			{
				incrFeederBotCapacity = 0;
			}
		}
		if (type == BuildingType.WasteBot)
		{
			incrWasteBotSpeed -= speedLvl;
			incrWasteBotCapacity -= capacityLvl;
			if (incrWasteBotSpeed <= 0)
			{
				incrWasteBotSpeed = 0;
			}
			if (incrWasteBotCapacity <= 0)
			{
				incrWasteBotCapacity = 0;
			}
		}
		if (type == BuildingType.FertilizerBot)
		{
			incrFertBotSpeed -= speedLvl;
			incrFertBotCapacity -= capacityLvl;
			if (incrFertBotSpeed <= 0)
			{
				incrFertBotSpeed = 0;
			}
			if (incrFertBotCapacity <= 0)
			{
				incrFertBotCapacity = 0;
			}
		}
		if (type == BuildingType.BerryBot)
		{
			incrBerryBotSpeed -= speedLvl;
			incrBerryBotCapacity -= capacityLvl;
			if (incrBerryBotSpeed <= 0)
			{
				incrBerryBotSpeed = 0;
			}
			if (incrBerryBotCapacity <= 0)
			{
				incrBerryBotCapacity = 0;
			}
		}
	}

	public void UnlockFeaturesFrom(HouseType houseType)
	{
		switch (houseType)
		{
		case HouseType.EchoHouse:
		{
			canUpgradeBuildings = true;
			echoBlocker.SetActive(value: false);
			for (int l = 0; l < echoUnlocks.Length; l++)
			{
				echoUnlocks[l].SetActive(value: true);
			}
			break;
		}
		case HouseType.SonnetShop:
		{
			shopBlocker.SetActive(value: false);
			for (int n = 0; n < shopUnlocks.Length; n++)
			{
				shopUnlocks[n].SetActive(value: true);
			}
			break;
		}
		case HouseType.HaikuHouse:
		{
			haikuBlocker.SetActive(value: false);
			for (int j = 0; j < haikuUnlocks.Length; j++)
			{
				haikuUnlocks[j].SetActive(value: true);
			}
			break;
		}
		case HouseType.SlateBarn:
		{
			slateBlocker.SetActive(value: false);
			for (int m = 0; m < slateUnlocks.Length; m++)
			{
				slateUnlocks[m].SetActive(value: true);
			}
			break;
		}
		case HouseType.ForbicHouse:
		{
			forbicBlocker.SetActive(value: false);
			for (int k = 0; k < forbicUnlocks.Length; k++)
			{
				forbicUnlocks[k].SetActive(value: true);
			}
			break;
		}
		case HouseType.PinionHouse:
		{
			pinionBlocker.SetActive(value: false);
			for (int i = 0; i < forbicUnlocks.Length; i++)
			{
				pinionUnlocks[i].SetActive(value: true);
			}
			break;
		}
		}
	}

	public CharacterInteraction GetFreeNPCinRange(Vector2 pos, float range)
	{
		List<CharacterInteraction> list = new List<CharacterInteraction>();
		for (int i = 0; i < npcs.Count; i++)
		{
			if (!npcs[i].isBusy && !npcs[i].isTalking && Vector2.Distance(pos, npcs[i].transform.position) < range)
			{
				list.Add(npcs[i]);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public Transform GetRandomNPCInRangeForPet(Vector2 pos, float range)
	{
		if (Vector2.Distance(pos, rusty.transform.position) < range)
		{
			return rusty.transform;
		}
		if (Vector2.Distance(pos, haiku.transform.position) < range)
		{
			return haiku.transform;
		}
		List<Transform> list = new List<Transform>();
		for (int i = 0; i < npcs.Count; i++)
		{
			if (Vector2.Distance(pos, npcs[i].transform.position) < range)
			{
				list.Add(npcs[i].transform);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public bool isPathFree(Vector2 npc1, Vector2 npc2)
	{
		Vector2 vector = (npc1 + npc2) / 2f;
		if (Vector2.Distance(Vector2.up * 2.5f, vector) < 4f)
		{
			return false;
		}
		Vector2Int xYCoordinates = GridSystem.ins.getXYCoordinates(vector);
		for (int i = 0; i < houses.Count; i++)
		{
			Vector2Int coords = houses[i].getCoords();
			Vector2Int size = houses[i].size;
			coords += new Vector2Int(1, -1);
			size += new Vector2Int(2, 2);
			for (int j = 0; j < size.x; j++)
			{
				for (int k = 0; k < size.y; k++)
				{
					if (coords.x - j == xYCoordinates.x && coords.y + k == xYCoordinates.y)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(Vector2.up * 2.5f, 4f);
	}

	public void SpawnPopUp(Vector2 position, int amount)
	{
		ResourcePopUp resourcePopUp = UnityEngine.Object.Instantiate(popUp, popUpParent.transform);
		resourcePopUp.transform.position = position;
		resourcePopUp.DisplayNumber(amount);
	}

	public void SpawnSparePartsPopUp(Vector2 position, int amount)
	{
		if (amount != 0)
		{
			ResourcePopUp resourcePopUp = UnityEngine.Object.Instantiate(sparePartsPopUp, popUpParent.transform);
			resourcePopUp.transform.position = position;
			resourcePopUp.DisplayNumber(amount);
		}
	}

	public void SpawnBiofuelPopUp(Vector2 position, int amount)
	{
		if (amount != 0)
		{
			ResourcePopUp resourcePopUp = UnityEngine.Object.Instantiate(biofuelPopUp, popUpParent.transform);
			resourcePopUp.transform.position = position;
			resourcePopUp.DisplayNumber(amount);
		}
	}

	public void SpawnFossilPopUp(Vector2 position, int amount)
	{
		if (amount != 0)
		{
			ResourcePopUp resourcePopUp = UnityEngine.Object.Instantiate(fossilPopUp, popUpParent.transform);
			resourcePopUp.transform.position = position;
			resourcePopUp.DisplayNumber(amount);
		}
	}

	public void SpawnFertilizerPopUp(Vector2 position, int amount)
	{
		if (amount != 0)
		{
			ResourcePopUp resourcePopUp = UnityEngine.Object.Instantiate(fertPopUp, popUpParent.transform);
			resourcePopUp.transform.position = position;
			resourcePopUp.DisplayNumber(amount);
		}
	}

	public void SpawnRegrowthPopUp(Vector2 position, int amount)
	{
		if (amount != 0)
		{
			ResourcePopUp resourcePopUp = UnityEngine.Object.Instantiate(regrowthPopUp, popUpParent.transform);
			resourcePopUp.transform.position = position;
			resourcePopUp.DisplayText("+" + amount);
		}
	}

	public void SpawnIconPopUp(Vector2 position, Sprite sprite, int amount)
	{
		if (amount != 0)
		{
			ResourcePopUp resourcePopUp = UnityEngine.Object.Instantiate(iconPopUp, popUpParent.transform);
			resourcePopUp.transform.position = position;
			resourcePopUp.SetSprite(sprite);
			resourcePopUp.DisplayNumber(amount);
		}
	}

	public void SpawnHeartPopUp(Vector2 position)
	{
		ResourcePopUp resourcePopUp = UnityEngine.Object.Instantiate(heartPopUp, popUpParent.transform);
		resourcePopUp.transform.position = position;
		resourcePopUp.DisplayNumber(0);
	}

	public void SpawnBalatroPopUp(Vector2 position, string msg, float time, Color color)
	{
		BalatroPopUp obj = UnityEngine.Object.Instantiate(balatroPopUp, popUpParent.transform);
		obj.transform.position = position;
		obj.Show(msg, time, color);
	}

	public bool checkIfAllLandsUnblocked()
	{
		for (int i = 0; i < blockedLands.Length; i++)
		{
			if (blockedLands[i] != BlockedLand.State.Cleared)
			{
				return false;
			}
		}
		return true;
	}

	public void MarkAllWaterTilesAsOccupied()
	{
		for (int i = 0; i < waterSources.Count; i++)
		{
			waterSources[i].MarkTilesAsOccupied();
		}
	}

	public void MarkAllTreeTilesAsOccupied()
	{
		for (int i = 0; i < trees.Count; i++)
		{
			trees[i].MarkTilesAsOccupied();
		}
	}

	public Sprite getChipSprite(CropManager.GmoTier tier)
	{
		return tier switch
		{
			CropManager.GmoTier.Common => commonChipSprite, 
			CropManager.GmoTier.Rare => rareChipSprite, 
			CropManager.GmoTier.Uber => uberChipSprite, 
			_ => legendaryChipSprite, 
		};
	}

	public Sprite getChipMiniSprite(CropManager.GmoTier tier)
	{
		return tier switch
		{
			CropManager.GmoTier.Common => commonChipMiniSprite, 
			CropManager.GmoTier.Rare => rareChipMiniSprite, 
			CropManager.GmoTier.Uber => uberChipMiniSprite, 
			_ => legendaryChipMiniSprite, 
		};
	}

	public void CheckUnlockedMapsOnStart()
	{
		if (checkIfAllLandsUnblocked())
		{
			if (SaveData.ins.mapsUnlocked < (int)SaveData.ins.farmType)
			{
				SaveData.ins.mapsUnlocked = (int)SaveData.ins.farmType;
			}
			if (SaveData.ins.farmType == (SaveData.FarmType)SaveData.ins.mapsUnlocked)
			{
				SaveData.ins.mapsUnlocked++;
				StartCoroutine(TriggerUnlockFarmAchievement());
			}
		}
	}

	private IEnumerator TriggerUnlockFarmAchievement()
	{
		yield return null;
		AchievementManager.ins.UnlockFarm(SaveData.ins.mapsUnlocked);
	}

	public void UnlockNextMap()
	{
		if (checkIfAllLandsUnblocked())
		{
			if (SaveData.ins.farmType == SaveData.FarmType.GrassyPlains && SaveData.ins.mapsUnlocked == 0)
			{
				SaveData.ins.mapsUnlocked = 1;
				titleScreenScript.gameObject.SetActive(value: true);
				titleScreenScript.ShowNewMapText();
				AchievementManager.ins.UnlockFarm(SaveData.ins.mapsUnlocked);
			}
			if (SaveData.ins.farmType == SaveData.FarmType.Swamp && SaveData.ins.mapsUnlocked == 1)
			{
				SaveData.ins.mapsUnlocked = 2;
				titleScreenScript.gameObject.SetActive(value: true);
				titleScreenScript.ShowNewMapText();
				AchievementManager.ins.UnlockFarm(SaveData.ins.mapsUnlocked);
			}
			if (SaveData.ins.farmType == SaveData.FarmType.Desert && SaveData.ins.mapsUnlocked == 2)
			{
				SaveData.ins.mapsUnlocked = 100;
				titleScreenScript.gameObject.SetActive(value: true);
				titleScreenScript.ShowAllMapsText();
				AchievementManager.ins.UnlockFarm(SaveData.ins.mapsUnlocked);
			}
			SaveData.ins.SaveAchievementsFile();
		}
	}

	public void ChangeSFXVolume(float value)
	{
		SoundManager.ins.ChangeEffectsVolume(value);
	}

	public void ChangeMusicVolume(float value)
	{
		SoundManager.ins.ChangeMusicVolume(value);
	}

	public bool checkIfMouseIsInBoxArea(Vector2 center, Vector2 boxSize)
	{
		bool result = false;
		if (mousePositionInWorld.x < center.x + boxSize.x && mousePositionInWorld.x > center.x - boxSize.x && mousePositionInWorld.y < center.y + boxSize.y && mousePositionInWorld.y > center.y - boxSize.y)
		{
			result = true;
		}
		return result;
	}
}
