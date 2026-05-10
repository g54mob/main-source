using System;
using System.Collections.Generic;
using NaisuPorter.CommonScripts;
using UnityEngine;
using UnityEngine.Localization.Components;
using __Project__.Scripts.Data;
using __Project__.Scripts.FloorPaintSystem;
using __Project__.Scripts.WallPaintSystem;

public class SaveManager : NoktaSingleton<SaveManager>
{
	[Serializable]
	public class ProgressionContainer
	{
		public List<int> UnlockedLicenses;

		public List<LoanData> LoanDatas;

		public float Money;

		public CartData CartData;

		public List<BoxData> BoxDatas;

		public List<VehicleData> VehicleDatas;

		public List<FurnitureBoxData> FurnitureBoxDatas;

		public List<FurnitureBoxData> BucketBoxDatas;

		public List<DisplayData> DisplayDatas;

		public List<RackData> RackDatas;

		public List<CheckoutData> CheckoutDatas;

		public List<ScaleData> ScaleData;

		public List<CategorySignData> CategorySignDatas;

		public DailyStatisticsData DailyStatisticsData;

		public List<FurnitureData> FurnitureDatas;

		public TransformData ComputerTransform;

		public List<int> CrateProductsData;

		public List<SecurityCameraSaveData> SecurityCameraSaveDatas;

		public List<IceCreamManager.StandData> IceCreamStandData;

		public float CurrentTime;

		public int CurrentDay;

		public int LastDayPricesChanged;

		public SerializableVector2 LastWholesaleOfferShown;

		public bool MysteryBox;

		public bool IsGarbageOnboardingCompleted;

		public int CleanedGarbageCount;

		public int CleanedDirtCount;

		public int CleanedGlassCount;

		public int CompletedCheckoutCount;

		public int CurrentStorePoint;

		public int CurrentStoreLevel;

		public int StoreUpgradeLevel;

		public bool IsStoreOpen;

		public int PaintedWallCount;

		public int PaintedFloorCount;

		public bool IsTabletBought;

		public bool IsTabletOrdered;

		public bool IsCrateBought;

		public bool IsCrateEnabled;

		public bool IsBatBought;

		public bool IsBatEnabled;

		public bool IsNewGame;

		public bool IsSecurityWarningShowed;

		public bool IsTutorialShoplifterBeaten;

		public bool IsShoplifterWarningShowed;

		public bool IsEnableShoplifterWarningShowed;

		public bool IsVeggiesWarningShowed;

		public bool IsScaleBought;

		public bool IsStallBought;

		public bool IsAnyVeggieBought;

		public bool IsAnyVeggiePlacedToStall;

		public bool IsScaleTutorialCompleted;

		public bool IsOnlineOrderTutorialCompleted;

		public bool HasAnyProductBought;

		public bool HasAnyProductPlaced;

		public bool HasAnyPriceSet;

		public SerializableVector3 StoreLightPosition;

		public float StoreLightRotationY;

		public SerializableVector3 StorageLightPosition;

		public float StorageLightRotationY;
	}

	[Serializable]
	public class PriceContainer
	{
		public List<Pricing> Prices;

		public List<Pricing> PricesSetByPlayer;

		public List<Pricing> AverageCosts;

		public List<Pricing> DailyPriceChanges;

		public List<Pricing> PreviousPrices;

		public List<Pricing> PricingDatas;
	}

	[Serializable]
	public class SettingsContainer
	{
		public int LanguageSetting;

		public float MouseSensitivity;

		public float RotateSensitivity;

		public bool InvertYAxis;

		public bool InvertXAxis;

		public bool RunInBackground;

		public bool EnableShoplifters;

		public int QualitySetting;

		public int QualityBeforeCustomized;

		public string ResolutionSetting;

		public bool FullScreen;

		public int FOV;

		public bool VSync;

		public bool IsCustomSelected;

		public int TextureQuality;

		public int AntiAliasing;

		public int ShadowQuality;

		public int UpscalingFilter;

		public bool IsHDROpen;

		public bool IsPostProcessOpen;

		public float MasterVolume;

		public float MusicVolume;

		public float SFXVolume;

		public int TargetFrameRateIndex;
	}

	[Serializable]
	public class OnboardingContaioner
	{
		public int Step;

		public bool LightsTutorial;

		public bool OverChange;

		public bool CompletedShelfObjective;

		public string Version;

		public bool CompletedNameObjective;
	}

	[Serializable]
	public class ExpensesData
	{
		public float CurrentDayBillAmount;

		public List<PlayerPaymentData> Bills;

		public List<PlayerPaymentData> Rents;

		public List<PlayerPaymentData> LoanRepayments;
	}

	[Serializable]
	public class EmployeesData
	{
		public List<int> CashiersData;

		public List<int> RestockersData;

		public List<int> CustomerHelpersData;

		public List<int> JanitorsData;

		public List<RestockerManagementData> RestockerManagementDatas;

		public List<int> SecurityGuardsData;

		public List<int> BakersData;

		public List<int> IceCreamHelpersData;
	}

	[Serializable]
	public class StorageData
	{
		public bool Purchased;

		public int StorageLevel;
	}

	[Serializable]
	public class CustomizationContainer
	{
		public CustomizationData CustomizationData;

		public List<BucketSaveData> BucketSaveDataList;

		public List<FloorBoxSaveData> FloorBoxSaveDataList;

		public List<PaintData> PaintDataList;

		public List<FloorSaveData> FloorSaveDataList;

		public int PaintedWallsCount;

		public int PaintedFloorsCount;
	}

	[Serializable]
	public class OldCustomizationContainer
	{
		public CustomizationData CustomizationData;

		public List<BucketSaveData> BucketSaveDataList;

		public List<FloorBoxData> FloorBoxSaveDataList;

		public List<PaintData> PaintDataList;

		public List<OldFloorSaveData> FloorSaveDataList;

		public int PaintedWallsCount;

		public int PaintedFloorsCount;
	}

	[Serializable]
	public class AchievementContainer
	{
		public Dictionary<AchievementId, Achievement> AchievementsDict;
	}

	[Serializable]
	public class CleaningContainer
	{
		public int GarbageCount;

		public int DirtCount;

		public List<DustingSaveData> DustingDataList;
	}

	[Serializable]
	public class OrdersContainer
	{
		public int LastOrderID;

		public int CompletedOrderCount;

		public int FailedOrderCount;

		public List<OrderListData> OrdersGenerated;

		public List<float> OrdersPlannedForToday;

		public List<int> PaperbagProducts;
	}

	[Serializable]
	public class VendingContainer
	{
		public List<VendingData> vendingData;
	}

	[SerializeField]
	private string m_EmptySave;

	[SerializeField]
	private int m_MaxBackupCount;

	[Space]
	[SerializeField]
	private CanvasGroup m_SaveErrorUI;

	[SerializeField]
	private LocalizeStringEvent m_ErrorMessage;

	[SerializeField]
	private float m_ErrorInterval;

	public ProgressionContainer Progression;

	[Obsolete("Use SettingsManager instead", true)]
	public SettingsContainer Settings;

	public OnboardingContaioner Onboarding;

	public PriceContainer Price;

	public ExpensesData Expenses;

	public EmployeesData Employees;

	public StorageData Storage;

	public CustomizationContainer Customization;

	public AchievementContainer Achievement;

	public CleaningContainer Cleaning;

	public OrdersContainer OnlineOrders;

	public VendingContainer Vending;

	private SaveInfo m_SlotInfo;

	private float m_LastErrorTime;

	public Action OnSaveRequested;

	public Action OnSaveLoaded;

	public Action OnSlaveSettingsLoaded;

	public bool IsSaveFileLoaded;

	public bool IsReadyForDLCCheck;

	public bool IsSlaveSettingsLoaded;

	private static SaveManager _instance;

	private ES3Settings m_ES3Settings;

	private string m_CurrentSaveFilePath;

	public const int k_MaxSaveSlots = 3;

	public bool isOnboardingFinished;

	public Action OnSaveDeleted;

	public new static SaveManager Instance => null;

	public string CurrentSaveFilePath => null;

	public bool HasProgression => false;

	private void Awake()
	{
	}

	private void TryUpdateExistingSavesToSlots()
	{
	}

	private void OnAfterInitialize()
	{
	}

	public void CreateLoadNewSave(SaveInfo info)
	{
	}

	public void CreateLoadNewSave_MP(SaveInfo info)
	{
	}

	public void Save(SaveInfo saveInfo)
	{
	}

	private void Save(string saveName)
	{
	}

	public void Save()
	{
	}

	public void SaveSettings()
	{
	}

	private string GetBackupPath(int slotIndex)
	{
		return null;
	}

	private string GetSlotPath(int slotIndex)
	{
		return null;
	}

	public bool TryFetchSlotInfo(int slotIndex, out SaveInfo info)
	{
		info = default(SaveInfo);
		return false;
	}

	public SaveInfo[] FetchSaveInfo()
	{
		return null;
	}

	public void Load(SaveInfo info)
	{
	}

	public void LoadLast()
	{
	}

	private void ApplySaveData()
	{
	}

	private void SetOnboardingFinished()
	{
	}

	private void MigrateCustomizationData()
	{
	}

	public void Clear()
	{
	}

	public byte[] Encode(object data)
	{
		return null;
	}

	public T Decode<T>(byte[] loadData)
	{
		return default(T);
	}

	private void ShowSaveErrorMessage(string errorKey)
	{
	}

	public void RequestDeleteBackup(string path)
	{
	}

	public void RequestDeleteSave(SaveInfo saveInfo)
	{
	}

	private void UpdateSaveFilePath()
	{
	}
}
