using System;
using System.Collections.Generic;
using Enviro;
using RainbowArt.CleanFlatUI;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using VideoKit;

public class GameManager : MonoBehaviour
{
	public class OnInstallWingBluePrintArg : EventArgs
	{
		public GameObject wing;

		public Transform rocket;
	}

	public class OnDrawWingBluePrintArg : EventArgs
	{
		public GameObject furniture;

		public Vector3 position;

		public Quaternion rotation;

		public Transform rocket;

		public int numOfWings;

		public bool canInstall;
	}

	public class OnCraftingTableArg : EventArgs
	{
		public Rocket rocket;
	}

	public class OnPartInstallBtnPressedArg : EventArgs
	{
		public GameObject part;

		public float partType;

		public int numOfWings;
	}

	public class OnAddBounsOnFoodArg : EventArgs
	{
		public float hungerGainBouns;

		public int knowledgeGainBouns;

		public int valueBouns;
	}

	public class OnMenuSelectedArg : EventArgs
	{
		public GameObject menuGO;

		public int maxStars;
	}

	public class OnCookingCompletedArg : EventArgs
	{
		public int stars;

		public int maxStars;
	}

	public class OnCookingStartArg : EventArgs
	{
		public Food food;

		public ProgressBarSpecialPattern panCookingGage;

		public ProgressBarSpecialPattern boilCookingGage;
	}

	public class OnDrawRocketMountBluePrintArg : EventArgs
	{
		public Rocket rocket;

		public Vector3 position;

		public bool canInstall;
	}

	public class OnDrawBluePrintArg : EventArgs
	{
		public GameObject furniture;

		public Vector3 position;

		public bool canInstall;

		public int tick;

		public Vector3 size;
	}

	public class OnDialogueChoiceBtnClickedArg : EventArgs
	{
		public ConversationUI.DialogueChoice choice;
	}

	public class OnConversatinoStartArg : EventArgs
	{
		public NPC npc;
	}

	public class OnShopItemClickedArg : EventArgs
	{
		public GameObject shopItem;

		public GameObject shopwindow;
	}

	public class OnMotorSelectedArg : EventArgs
	{
		public GameObject motorGO;
	}

	public class OnStartMotorCraftingArg : EventArgs
	{
		public AnimationCurve grainGeometryCurve;

		public ProgressBarPattern grindGage;
	}

	public class OnUnlockNewMotorArg : EventArgs
	{
		public GameObject motor;
	}

	public class OnMotorTestingStartArg : EventArgs
	{
		public CurrentCraftingRocketGrain grain;
	}

	public class OnDeliveryArrivedArg : EventArgs
	{
		public List<GameObject> items;
	}

	public VideoKitRecorder recorder;

	public Wind windManager;

	public Rocket currentLanchedRocket;

	public FirstPersonController player;

	public CinemachineCamera cinemachinePOVCamera;

	public CinemachinePanTilt cinemachinePanTilt;

	public CinemachineCamera rocketCamera;

	public CinemachineCamera rcCam;

	public bool isMotorCraftingTableUnlock;

	public bool isBasementUnlocked;

	public bool isCookingTableUnlocked;

	public bool twoStarCookingUnlocked;

	public bool threeStarCookingUnlocked;

	public bool isMyRoomUnlocked;

	public bool isEntranceUnlocked;

	public bool isParentsRoomUnlocked;

	public bool isPartTimeUnlocked;

	public bool isPowderRocketUnlocked;

	public bool isVideoUnlocked;

	public bool isDicaInstalled;

	public bool isRocketCamInstalled;

	public bool isWindRooksterInstalled;

	public bool isAnemometerInstalled;

	public bool isCpuInstalled;

	public bool isCodingUnlocked;

	public bool isJunkShopDoorUnlocked;

	public bool isRocketMountExist;

	public List<bool> rocketPerkList = new List<bool> { false, false, false, false, false };

	public List<bool> cookingPerkList = new List<bool> { false, false, false, false, false };

	public List<bool> intelPerkList = new List<bool> { false, false, false, false, false };

	public int perkPoint;

	public static GameManager S { get; private set; }

	public event EventHandler OnDeleteWingBluePrint;

	public event Action OnCancelWingInstalling;

	public event EventHandler OnWingInstalled;

	public event Action OnCpuInstalled;

	public event EventHandler<OnInstallWingBluePrintArg> OnInstallWingBluePrint;

	public event EventHandler<OnDrawWingBluePrintArg> OnDrawWingBluePrint;

	public event Action<GameObject, Vector3, Transform> OnDrawCpuBluePrint;

	public event EventHandler OnCraftingDone;

	public event Action OnPaintingDone;

	public event EventHandler<OnCraftingTableArg> OnCraftingTable;

	public event Action<Rocket> OnPaintingTable;

	public event EventHandler<OnPartInstallBtnPressedArg> OnPartInstallBtnPressed;

	public event Action<string> OnPartInstallBtnPressedCustomMotor;

	public event EventHandler<OnAddBounsOnFoodArg> OnAddBounsOnFood;

	public event EventHandler OnToTheNextStep;

	public event EventHandler OnCookingTable;

	public event EventHandler OnCookingDone;

	public event EventHandler<OnCookingStartArg> OnCookingStart;

	public event EventHandler OnPanCookingStart;

	public event EventHandler OnStackCookingStart;

	public event EventHandler OnBoilCookingStart;

	public event EventHandler OnBoilCookingDone;

	public event EventHandler<OnCookingCompletedArg> OnCookingCompleted;

	public event EventHandler<OnMenuSelectedArg> OnMenuSelected;

	public event EventHandler OnFoodStacked;

	public event Action OnPanCookingDone;

	public event EventHandler OnDeleteBluePrint;

	public event EventHandler OnInstallBluePrint;

	public event Action<GameObject, Transform> OnInstallCpuBluePrint;

	public event Action OnInstallRocketMountBluePrint;

	public event EventHandler<OnDrawBluePrintArg> OnDrawBulePrint;

	public event EventHandler<OnDrawRocketMountBluePrintArg> OnDrawRocketMountBluePrint;

	public event Action<Furniture> OnFurnitureObtained;

	public event EventHandler OnNewRecorded;

	public event Action<int> OnRocketLaunch;

	public event EventHandler OnRocketLanded;

	public event EventHandler OnPlayerLevelUp;

	public event EventHandler<OnDialogueChoiceBtnClickedArg> OnDialogueChoiceBtnClicked;

	public event EventHandler OnEndConversation;

	public event EventHandler<OnConversatinoStartArg> OnConversationStart;

	public event EventHandler OnHandoverRocket;

	public event Action OnOffPlayerUI;

	public event Action OnOnPlayerUI;

	public event EventHandler OnMoneyUpdated;

	public event Action OnTicketUpdated;

	public event EventHandler OnComputerInteracted;

	public event EventHandler<OnShopItemClickedArg> OnShopItemClicked;

	public event EventHandler OnMotorCraftingTableInteracted;

	public event EventHandler<OnMotorSelectedArg> OnMotorSelected;

	public event EventHandler OnMotorCraftingDone;

	public event EventHandler<OnStartMotorCraftingArg> OnStartMotorCrafting;

	public event EventHandler OnMotorMensurationStart;

	public event EventHandler OnMotorToTheNextStep;

	public event EventHandler OnMotorGrindStart;

	public event EventHandler OnMotorCastingStart;

	public event EventHandler OnMotorIngredBoilingStart;

	public event EventHandler OnMotorCraftingCompleted;

	public event EventHandler OnBoilCompleted;

	public event EventHandler<OnUnlockNewMotorArg> OnUnlockNewMotor;

	public event EventHandler<OnMotorTestingStartArg> OnMotorTestingStart;

	public event EventHandler OnGrainExploded;

	public event EventHandler OnGrainIgnited;

	public event EventHandler OnPlayerPressTab;

	public event Action OnPlayerEat;

	public event Action OnRocketOnHand;

	public event Action OnShoppingBagNeeded;

	public event EventHandler<OnDeliveryArrivedArg> OnDeliveryArrived;

	public event Action<List<GameObject>, List<GameObject>> OnGroceryArrived;

	public event Action OnRcCarSpawned;

	public event Action OnBusStopInteracted;

	public event Action OnPlayerTryGetOut;

	public event Action OnPartTimeUnlocked;

	public event Action OnRocketCrashed;

	public event Action OnBasementUnlocked;

	public event Action OnCookingTableUnlocked;

	public event Action OnMyRoomUnlocked;

	public event Action OnEntranceUnlocked;

	public event Action OnParentsRoomUnlocked;

	public event Action OnVideoUnlocked;

	public event Action<string> OnNewVidRecorded;

	public event Action<int> OnTutorialWindowOn;

	public event Action OnJunkScaleSell;

	public event Action<QuestData, Transform> OnStartParttime;

	public event Action<RocketAttachment> OnPaintTemp;

	public event Action OnPaintRocket;

	public event Action OnDeletePaintTemp;

	public event Action OnTearDownUnlocked;

	public event Action OnCameraInstalled;

	public event Action OnDecalEmpty;

	public event Action OnGrainRocketNeeded;

	public event Action OnCpuNeeded;

	public event Action OnDeviceNeeded;

	public event Action OnHandsFull;

	public event Action OnNotenoughMoney;

	public event Action OnTrashWrong;

	public event Action OnCannotDisassemble;

	public event Action OnRocketMountExist;

	public event Action OnAlreadyPayed;

	private void Awake()
	{
		if (S != null && S != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		S = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LoadGmData();
	}

	private void Start()
	{
		ES3AutoSaveMgr.OnBeforeSave += ES3AutoSaveMgr_OnBeforeSave;
		int num = LayerMask.NameToLayer("DistanceCulling");
		if (num < 0)
		{
			Debug.LogError("DistanceCulling 레이어 없음!");
			return;
		}
		float[] array = Camera.main.layerCullDistances;
		if (array.Length < 32)
		{
			array = new float[32];
		}
		array[num] = 30f;
		Camera.main.layerCullDistances = array;
		Camera.main.cullingMask |= 1 << num;
		SceneManager.sceneLoaded += SceneManager_sceneLoaded;
		PauseUI.OnSaveAndQuit += PauseUI_OnSaveAndQuit;
		recorder.mediaPathPrefix = Application.persistentDataPath;
		SetEnviroQuality();
	}

	public void SetEnviroQuality()
	{
		int qualityLevel = QualitySettings.GetQualityLevel();
		if (EnviroManager.instance != null && EnviroManager.instance.Quality != null)
		{
			EnviroQualities settings = EnviroManager.instance.Quality.Settings;
			if (qualityLevel >= 0 && qualityLevel < settings.Qualities.Count)
			{
				settings.defaultQuality = settings.Qualities[qualityLevel];
			}
			else
			{
				Debug.LogWarning("Enviro 3 퀄리티 리스트 인덱스를 벗어났습니다. 인스펙터 세팅을 확인해주세요.");
			}
		}
	}

	private void ES3AutoSaveMgr_OnBeforeSave()
	{
		SaveGmData();
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
		PauseUI.OnSaveAndQuit -= PauseUI_OnSaveAndQuit;
		ES3AutoSaveMgr.OnBeforeSave -= ES3AutoSaveMgr_OnBeforeSave;
	}

	private void PauseUI_OnSaveAndQuit()
	{
		SaveGmData();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
	{
		int num = LayerMask.NameToLayer("DistanceCulling");
		if (num < 0)
		{
			Debug.LogError("DistanceCulling 레이어 없음!");
			return;
		}
		float[] array = Camera.main.layerCullDistances;
		if (array.Length < 32)
		{
			array = new float[32];
		}
		array[num] = 30f;
		Camera.main.layerCullDistances = array;
		Camera.main.cullingMask |= 1 << num;
	}

	private void SaveGmData()
	{
		ES3.Save("Gm_isJunkShopDoorUnlocked", isJunkShopDoorUnlocked);
		ES3.Save("Gm_MotorCrafitngTableUnlock", isMotorCraftingTableUnlock);
		ES3.Save("Gm_BasementUnlocked", isBasementUnlocked);
		ES3.Save("Gm_CookingTableUnlocked", isCookingTableUnlocked);
		ES3.Save("Gm_MyRoomUnlocked", isMyRoomUnlocked);
		ES3.Save("Gm_ParentsRoomUnlocked", isParentsRoomUnlocked);
		ES3.Save("Gm_EntranceUnlocked", isEntranceUnlocked);
		ES3.Save("Gm_PartTimeUnlocked", isPartTimeUnlocked);
		ES3.Save("Gm_TwoStarCookingUnlocked", twoStarCookingUnlocked);
		ES3.Save("Gm_ThreeStarCookingUnlocked", threeStarCookingUnlocked);
		ES3.Save("Gm_PowderRocketUnlocked", isPowderRocketUnlocked);
		ES3.Save("Gm_VideoUnlocked", isVideoUnlocked);
		ES3.Save("Gm_WindRoosterInstalled", isWindRooksterInstalled);
		ES3.Save("Gm_AnemometerInstalled", isAnemometerInstalled);
		ES3.Save("Gm_CpuInstalled", isCpuInstalled);
		ES3.Save("Gm_CodingUnlocked", isCodingUnlocked);
		ES3.Save("Gm_RocketPerk", rocketPerkList);
		ES3.Save("Gm_CookingPerk", cookingPerkList);
		ES3.Save("Gm_intelPerk", intelPerkList);
		ES3.Save("Gm_perkPoint", perkPoint);
	}

	private void LoadGmData()
	{
		isJunkShopDoorUnlocked = ES3.Load("Gm_isJunkShopDoorUnlocked", defaultValue: false);
		isMotorCraftingTableUnlock = ES3.Load("Gm_MotorCrafitngTableUnlock", defaultValue: false);
		isBasementUnlocked = ES3.Load("Gm_BasementUnlocked", defaultValue: false);
		isCookingTableUnlocked = ES3.Load("Gm_CookingTableUnlocked", defaultValue: false);
		isMyRoomUnlocked = ES3.Load("Gm_MyRoomUnlocked", defaultValue: false);
		isParentsRoomUnlocked = ES3.Load("Gm_ParentsRoomUnlocked", defaultValue: false);
		isEntranceUnlocked = ES3.Load("Gm_EntranceUnlocked", defaultValue: false);
		isPartTimeUnlocked = ES3.Load("Gm_PartTimeUnlocked", defaultValue: false);
		twoStarCookingUnlocked = ES3.Load("Gm_TwoStarCookingUnlocked", defaultValue: false);
		threeStarCookingUnlocked = ES3.Load("Gm_ThreeStarCookingUnlocked", defaultValue: false);
		isPowderRocketUnlocked = ES3.Load("Gm_PowderRocketUnlocked", defaultValue: false);
		rocketPerkList = ES3.Load("Gm_RocketPerk", rocketPerkList);
		cookingPerkList = ES3.Load("Gm_CookingPerk", cookingPerkList);
		intelPerkList = ES3.Load("Gm_intelPerk", intelPerkList);
		isVideoUnlocked = ES3.Load("Gm_VideoUnlocked", defaultValue: false);
		isWindRooksterInstalled = ES3.Load("Gm_WindRoosterInstalled", defaultValue: false);
		isAnemometerInstalled = ES3.Load("Gm_AnemometerInstalled", defaultValue: false);
		isCpuInstalled = ES3.Load("Gm_CpuInstalled", defaultValue: false);
		isCodingUnlocked = ES3.Load("Gm_CodingUnlocked", defaultValue: false);
		perkPoint = ES3.Load("Gm_perkPoint", 0);
	}

	private void Update()
	{
	}

	public void CrafingDone()
	{
		this.OnCraftingDone?.Invoke(this, EventArgs.Empty);
	}

	public void PaintingDone()
	{
		this.OnPaintingDone?.Invoke();
	}

	public void CookingDone()
	{
		this.OnCookingDone?.Invoke(this, EventArgs.Empty);
	}

	public void CookingStart(Food food, ProgressBarSpecialPattern panCookingGage, ProgressBarSpecialPattern boilCookingGage)
	{
		this.OnCookingStart?.Invoke(this, new OnCookingStartArg
		{
			food = food,
			panCookingGage = panCookingGage,
			boilCookingGage = boilCookingGage
		});
	}

	public void InteractingWithCraftingTable(Rocket rocket)
	{
		this.OnCraftingTable?.Invoke(this, new OnCraftingTableArg
		{
			rocket = rocket
		});
	}

	public void InteractingWithPaintingTable(Rocket rocket)
	{
		this.OnPaintingTable?.Invoke(rocket);
	}

	public void InteractingWithCookingTable()
	{
		this.OnCookingTable?.Invoke(this, EventArgs.Empty);
	}

	public void RocketLaunched(int type)
	{
		this.OnRocketLaunch?.Invoke(type);
	}

	public void RocketLanded()
	{
		this.OnRocketLanded?.Invoke(this, EventArgs.Empty);
	}

	public void ShoppingBagNeeded()
	{
		this.OnShoppingBagNeeded?.Invoke();
	}

	public void FurnitureObtained(Furniture furniture)
	{
		this.OnFurnitureObtained?.Invoke(furniture);
	}

	public void DrawBluePrint(GameObject furniture, Vector3 position, bool canInstall, int tick, Vector3 size)
	{
		this.OnDrawBulePrint?.Invoke(this, new OnDrawBluePrintArg
		{
			furniture = furniture,
			position = position,
			canInstall = canInstall,
			tick = tick,
			size = size
		});
	}

	public void DrawRocketMountBluePrint(Rocket rocket, Vector3 positon, bool canInstall)
	{
		this.OnDrawRocketMountBluePrint?.Invoke(this, new OnDrawRocketMountBluePrintArg
		{
			rocket = rocket,
			position = positon,
			canInstall = canInstall
		});
	}

	public void DrawWingBluePrint(GameObject wing, Vector3 position, Quaternion rotation, Transform rocket, int numOfWings, bool canInstall)
	{
		this.OnDrawWingBluePrint?.Invoke(this, new OnDrawWingBluePrintArg
		{
			furniture = wing,
			position = position,
			rotation = rotation,
			rocket = rocket,
			numOfWings = numOfWings,
			canInstall = canInstall
		});
	}

	public void DrawCpuBluePrint(GameObject cpu, Vector3 position, Transform rocket)
	{
		this.OnDrawCpuBluePrint?.Invoke(cpu, position, rocket);
	}

	public void PaintTemp(RocketAttachment rocketPart)
	{
		this.OnPaintTemp?.Invoke(rocketPart);
	}

	public void Paint()
	{
		this.OnPaintRocket?.Invoke();
	}

	public void DeletePaintTemp()
	{
		this.OnDeletePaintTemp?.Invoke();
	}

	public void DeleteBluePrint()
	{
		this.OnDeleteBluePrint?.Invoke(this, EventArgs.Empty);
	}

	public void InstallBulePrint()
	{
		this.OnInstallBluePrint?.Invoke(this, EventArgs.Empty);
	}

	public void InstallCpuBluePrint(GameObject cpuGO, Transform rocket)
	{
		this.OnInstallCpuBluePrint?.Invoke(cpuGO, rocket);
	}

	public void InstallRocketMountBluePrint()
	{
		this.OnInstallRocketMountBluePrint?.Invoke();
	}

	public void InstallWingBluePrint(GameObject part, Transform rocket)
	{
		this.OnInstallWingBluePrint?.Invoke(this, new OnInstallWingBluePrintArg
		{
			wing = part,
			rocket = rocket
		});
	}

	public void PartInstallBtnPressed(GameObject part, float partType, int numOfWing)
	{
		this.OnPartInstallBtnPressed?.Invoke(this, new OnPartInstallBtnPressedArg
		{
			part = part,
			partType = partType,
			numOfWings = numOfWing
		});
	}

	public void PartInstallBtnPressedCustomMotor(string name)
	{
		this.OnPartInstallBtnPressedCustomMotor?.Invoke(name);
	}

	public void PlayerLevelUp()
	{
		this.OnPlayerLevelUp?.Invoke(this, EventArgs.Empty);
		perkPoint++;
	}

	public void PanCookingStart()
	{
		this.OnPanCookingStart?.Invoke(this, EventArgs.Empty);
	}

	public void StackCookingStart()
	{
		this.OnStackCookingStart?.Invoke(this, EventArgs.Empty);
	}

	public void ToTheNextStep()
	{
		this.OnToTheNextStep?.Invoke(this, EventArgs.Empty);
	}

	public void CookingCompleted(int stars, int maxStar)
	{
		this.OnCookingCompleted?.Invoke(this, new OnCookingCompletedArg
		{
			stars = stars,
			maxStars = maxStar
		});
	}

	public void NewVidRercorded(string fileName)
	{
		this.OnNewVidRecorded?.Invoke(fileName);
	}

	public void MenuSelected(GameObject menuGO, int maxStars)
	{
		this.OnMenuSelected?.Invoke(this, new OnMenuSelectedArg
		{
			menuGO = menuGO,
			maxStars = maxStars
		});
	}

	public void FoodStacked()
	{
		this.OnFoodStacked?.Invoke(this, EventArgs.Empty);
	}

	public void StartConversation(NPC npc)
	{
		this.OnConversationStart?.Invoke(this, new OnConversatinoStartArg
		{
			npc = npc
		});
	}

	public void EndConversation()
	{
		Cursor.visible = false;
		this.OnEndConversation?.Invoke(this, EventArgs.Empty);
	}

	public void DialogueChoiceBtnClicked(ConversationUI.DialogueChoice choice)
	{
		this.OnDialogueChoiceBtnClicked?.Invoke(this, new OnDialogueChoiceBtnClickedArg
		{
			choice = choice
		});
	}

	public void TicketUpdated()
	{
		this.OnTicketUpdated?.Invoke();
	}

	public void MoneyUpdated()
	{
		this.OnMoneyUpdated?.Invoke(this, EventArgs.Empty);
	}

	public void ComputerInteracted()
	{
		this.OnComputerInteracted?.Invoke(this, EventArgs.Empty);
	}

	public void ShopItemClicked(GameObject itemGO, GameObject shopwindow)
	{
		this.OnShopItemClicked?.Invoke(this, new OnShopItemClickedArg
		{
			shopItem = itemGO,
			shopwindow = shopwindow
		});
	}

	public void MotorCraftingTableInteracted()
	{
		this.OnMotorCraftingTableInteracted?.Invoke(this, EventArgs.Empty);
	}

	public void MotorSelected(GameObject motorGO)
	{
		this.OnMotorSelected?.Invoke(this, new OnMotorSelectedArg
		{
			motorGO = motorGO
		});
	}

	public void MotorCraftingDone()
	{
		this.OnMotorCraftingDone?.Invoke(this, EventArgs.Empty);
	}

	public void StartMotorCrafting(AnimationCurve curve, ProgressBarPattern grindGage)
	{
		this.OnStartMotorCrafting?.Invoke(this, new OnStartMotorCraftingArg
		{
			grainGeometryCurve = curve,
			grindGage = grindGage
		});
	}

	public void MotorMensurationStart()
	{
		this.OnMotorMensurationStart?.Invoke(this, EventArgs.Empty);
	}

	public void MotorToTheNextStep()
	{
		this.OnMotorToTheNextStep?.Invoke(this, EventArgs.Empty);
	}

	public void MotorGrindStart()
	{
		this.OnMotorGrindStart?.Invoke(this, EventArgs.Empty);
	}

	public void MotorCastingStart()
	{
		this.OnMotorCastingStart?.Invoke(this, EventArgs.Empty);
	}

	public void MotorCraftingCompleted()
	{
		this.OnMotorCraftingCompleted?.Invoke(this, EventArgs.Empty);
	}

	public void UnlockNewMotor(GameObject motor)
	{
		this.OnUnlockNewMotor?.Invoke(this, new OnUnlockNewMotorArg
		{
			motor = motor
		});
	}

	public void MotorTestingStart(CurrentCraftingRocketGrain grain)
	{
		this.OnMotorTestingStart?.Invoke(this, new OnMotorTestingStartArg
		{
			grain = grain
		});
	}

	public void GrainIgnited()
	{
		this.OnGrainIgnited?.Invoke(this, EventArgs.Empty);
	}

	public void GrainExploded()
	{
		this.OnGrainExploded?.Invoke(this, EventArgs.Empty);
	}

	public void PlayerPressTab()
	{
		this.OnPlayerPressTab?.Invoke(this, EventArgs.Empty);
	}

	public void HandoverRocket()
	{
		this.OnHandoverRocket?.Invoke(this, EventArgs.Empty);
	}

	public void WingInstalled()
	{
		this.OnWingInstalled?.Invoke(this, EventArgs.Empty);
	}

	public void CpuInstalled()
	{
		this.OnCpuInstalled?.Invoke();
	}

	public void DeleteWingBluePrint()
	{
		this.OnDeleteWingBluePrint?.Invoke(this, EventArgs.Empty);
	}

	public void CancelWingInstalling()
	{
		this.OnCancelWingInstalling?.Invoke();
	}

	public void MotorIngredBoilStart()
	{
		this.OnMotorIngredBoilingStart?.Invoke(this, EventArgs.Empty);
	}

	public void BoilCompleted()
	{
		this.OnBoilCompleted?.Invoke(this, EventArgs.Empty);
	}

	public void BoilCookingStart()
	{
		this.OnBoilCookingStart?.Invoke(this, EventArgs.Empty);
	}

	public void BoilCookingDone()
	{
		this.OnBoilCookingDone?.Invoke(this, EventArgs.Empty);
	}

	public void AddBounsOnFood(float hungerBouns, int knowledgeBouns, int valueBouns)
	{
		this.OnAddBounsOnFood?.Invoke(this, new OnAddBounsOnFoodArg
		{
			hungerGainBouns = hungerBouns,
			knowledgeGainBouns = knowledgeBouns,
			valueBouns = valueBouns
		});
	}

	public void PlayerEat()
	{
		this.OnPlayerEat?.Invoke();
	}

	public void RocketOnHand()
	{
		this.OnRocketOnHand?.Invoke();
	}

	public void DeliveryArrived(List<GameObject> items)
	{
		this.OnDeliveryArrived?.Invoke(this, new OnDeliveryArrivedArg
		{
			items = items
		});
	}

	public void RcCarSpawned()
	{
		this.OnRcCarSpawned?.Invoke();
	}

	public void GroceryArrived(List<GameObject> grocery, List<GameObject> rocket)
	{
		this.OnGroceryArrived?.Invoke(grocery, rocket);
	}

	public void TotheOpenField()
	{
	}

	public void BusStopInteracted()
	{
		this.OnBusStopInteracted?.Invoke();
	}

	public void BasementUnlocked()
	{
		isBasementUnlocked = true;
		this.OnBasementUnlocked?.Invoke();
	}

	public void VideoUnlocked()
	{
		isVideoUnlocked = true;
		this.OnVideoUnlocked?.Invoke();
	}

	public void MyRoomUnlocked()
	{
		isMyRoomUnlocked = true;
		this.OnMyRoomUnlocked?.Invoke();
	}

	public void EntracneUnlocked()
	{
		isEntranceUnlocked = true;
		this.OnEntranceUnlocked?.Invoke();
	}

	public void ParentsRoomUnlocked()
	{
		isParentsRoomUnlocked = true;
		this.OnParentsRoomUnlocked?.Invoke();
	}

	public void CookingTableUnlocked()
	{
		this.OnCookingTableUnlocked?.Invoke();
		isCookingTableUnlocked = true;
	}

	public void PartTimeUnlocked()
	{
		this.OnPartTimeUnlocked?.Invoke();
		isPartTimeUnlocked = true;
	}

	public void RocketCrashed()
	{
		this.OnRocketCrashed?.Invoke();
	}

	public void JunkScaleSell()
	{
		this.OnJunkScaleSell?.Invoke();
	}

	public void TutorialWIndowOn(int index)
	{
		this.OnTutorialWindowOn?.Invoke(index);
	}

	public void StartPartTime(QuestData parttime, Transform questboard)
	{
		this.OnStartParttime?.Invoke(parttime, questboard);
	}

	public void OffPlayerUI()
	{
		this.OnOffPlayerUI?.Invoke();
	}

	public void OnPlayerUI()
	{
		this.OnOnPlayerUI?.Invoke();
	}

	public void PlayerTryGetOut()
	{
		this.OnPlayerTryGetOut?.Invoke();
	}

	public void PanCookingDone()
	{
		this.OnPanCookingDone?.Invoke();
	}

	public void HandsFull()
	{
		this.OnHandsFull?.Invoke();
	}

	public void NotEnoughMoney()
	{
		this.OnNotenoughMoney?.Invoke();
	}

	public void TryTrashWrongStuff()
	{
		this.OnTrashWrong?.Invoke();
	}

	public void CannotDisassemble()
	{
		this.OnCannotDisassemble?.Invoke();
	}

	public void DeviceNeeded()
	{
		this.OnDeviceNeeded?.Invoke();
	}

	public void CpuNeeded()
	{
		this.OnCpuNeeded?.Invoke();
	}

	public void GrainRocketNeeded()
	{
		this.OnGrainRocketNeeded?.Invoke();
	}

	public void TearDownUnlocked()
	{
		this.OnTearDownUnlocked?.Invoke();
	}

	public void AlreadyPayed()
	{
		this.OnAlreadyPayed?.Invoke();
	}

	public void CameraInstalled()
	{
		this.OnCameraInstalled?.Invoke();
	}

	public void DecalEmpty()
	{
		this.OnDecalEmpty?.Invoke();
	}

	public void RocketMountExist()
	{
		this.OnRocketMountExist?.Invoke();
	}
}
