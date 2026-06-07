using System.Collections;
using System.Collections.Generic;
using Enviro;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	public BagUI bagUI;

	public PlayerInteractionUI playerInteractionUI;

	public NotificationUI notificationUI;

	public StorageUI storageUI;

	public MachineUI machineUI;

	public PalletMachineUI palletMachineUI;

	public ComputerUI computerUI;

	public PickerUI pickerUI;

	public DirtInventoryUI dirtInventoryUI;

	public DetectorTargetSelectionPanel detectorTargetSelectionPanel;

	[Header("Time Display")]
	public TextMeshProUGUI timeText;

	[Header("Day End")]
	public DayEndPanel dayEndPanel;

	[Header("Night UI")]
	[Tooltip("Gece olunca açılacak UI objesi")]
	public GameObject nightUIObject;

	[Header("Equipment UI")]
	public GameObject equipmentObj;

	public Image equipmentImage;

	public TextMeshProUGUI levelText;

	public GameObject levelObj;

	public List<EquipmentList> equipments = new List<EquipmentList>();

	[Header("Vehicle Occupants UI")]
	public VehicleOccupantsUI vehicleOccupantsUI;

	[Header("Forklift UI")]
	public GameObject forkliftUIRoot;

	public Animator forkliftAnimator;

	public GameObject liftObj;

	[Header("Building UI")]
	[Tooltip("Building mode aktifken gösterilecek UI paneli (isim, icon vs)")]
	public GameObject buildingUIPanel;

	[Tooltip("Aktif building'in ikonu")]
	public Image buildingIconImage;

	[Tooltip("Aktif building'in ismi")]
	public TextMeshProUGUI buildingNameText;

	[Header("Building Place Mode UI")]
	[Tooltip("Building place mode aktifken açılacak UI objeleri listesi (kontroller, tuş ikonları vs)")]
	public List<GameObject> buildingPlaceModeInputList = new List<GameObject>();

	[Tooltip("Sadece Equipments modunda ve kategoride birden fazla building varsa açılacak UI (scroll ile geçiş)")]
	public List<GameObject> buildingScrollInputList = new List<GameObject>();

	[Header("Building Cost UI")]
	[Tooltip("Building fiyatını gösteren UI objesi")]
	public GameObject buildingCostObj;

	[Tooltip("Building fiyat texti")]
	public TextMeshProUGUI buildingCostText;

	[Header("Equipment Cost UI")]
	[Tooltip("Equipment fiyatını gösteren UI objesi")]
	public GameObject equipmentCostObj;

	[Tooltip("Equipment fiyat texti")]
	public TextMeshProUGUI equipmentCostText;

	[Header("Contract HUD")]
	[Tooltip("ContractHUDItemUI prefab'ı (ContractInfoTemplate)")]
	public GameObject contractHUDItemPrefab;

	[Tooltip("Contract item'larının parent'ı (ContractHUDPanel)")]
	public Transform contractHUDContent;

	[Header("Delivery Point UI")]
	[Tooltip("Delivery point contract seçim paneli")]
	public DeliveryPointUI deliveryPointUI;

	[Header("Hold Input Fill UI")]
	public HoldInputFillUI holdInputFillUI;

	private List<ContractHUDItemUI> _spawnedContractHUDItems = new List<ContractHUDItemUI>();

	private bool _contractHUDDetailsExpanded = true;

	private GameManager gameManager;

	public GameObject lastOpenedUITab;

	private void Start()
	{
		gameManager = GameManager.Instance;
		if (buildingUIPanel != null)
		{
			buildingUIPanel.SetActive(value: false);
		}
		SubscribeToBuildingEvents();
		SubscribeToContractEvents();
		SubscribeToTimeEvent();
		SubscribeToDayNightEvents();
	}

	private void OnDestroy()
	{
		UnsubscribeFromBuildingEvents();
		UnsubscribeFromContractEvents();
		UnsubscribeFromTimeEvent();
		UnsubscribeFromDayNightEvents();
	}

	private void SubscribeToTimeEvent()
	{
		if (GameManager.Instance != null)
		{
			GameManager.Instance.OnMinuteChanged += OnTimeChanged;
			UpdateTimeDisplay(GameManager.Instance.CurrentTimeString);
		}
	}

	private void UnsubscribeFromTimeEvent()
	{
		if (GameManager.Instance != null)
		{
			GameManager.Instance.OnMinuteChanged -= OnTimeChanged;
		}
	}

	private void OnTimeChanged(string timeString)
	{
		UpdateTimeDisplay(timeString);
	}

	private void UpdateTimeDisplay(string timeString)
	{
		if (timeText != null)
		{
			timeText.text = timeString;
		}
	}

	private void SubscribeToBuildingEvents()
	{
		if (RadialBuildingManager.Instance != null)
		{
			RadialBuildingManager.Instance.OnBuildingModeStarted.AddListener(OnBuildingModeStarted);
			RadialBuildingManager.Instance.OnBuildingChanged.AddListener(OnBuildingChanged);
			RadialBuildingManager.Instance.OnBuildingModeStopped.AddListener(OnBuildingModeStopped);
		}
	}

	private void UnsubscribeFromBuildingEvents()
	{
		if (RadialBuildingManager.Instance != null)
		{
			RadialBuildingManager.Instance.OnBuildingModeStarted.RemoveListener(OnBuildingModeStarted);
			RadialBuildingManager.Instance.OnBuildingChanged.RemoveListener(OnBuildingChanged);
			RadialBuildingManager.Instance.OnBuildingModeStopped.RemoveListener(OnBuildingModeStopped);
		}
	}

	public void CloseLastOpenedUITab()
	{
		GameObject gameObject = lastOpenedUITab;
		if (gameObject != null)
		{
			T_Bag component = gameObject.GetComponent<T_Bag>();
			StorageUI component2 = gameObject.GetComponent<StorageUI>();
			if (component != null)
			{
				component.ShowBagUI(set: false);
				lastOpenedUITab = null;
			}
			else if (component2 != null)
			{
				component2.CloseUI();
				lastOpenedUITab = null;
			}
		}
	}

	public void OpenComputerUI()
	{
		computerUI.OnComputerPanelOpened();
	}

	public void CloseComputerUI()
	{
		computerUI.OnComputerPanelClosed();
	}

	public void SetEquipmentUI(ItemType item)
	{
		if (equipmentObj == null || equipmentImage == null || levelText == null)
		{
			return;
		}
		foreach (EquipmentList equipment in equipments)
		{
			foreach (GameObject input in equipment.inputList)
			{
				if (input != null)
				{
					input.SetActive(value: false);
				}
			}
		}
		if (item == ItemType.None)
		{
			equipmentObj.SetActive(value: false);
			return;
		}
		EquipmentList equipmentList = null;
		foreach (EquipmentList equipment2 in equipments)
		{
			if (equipment2.itemType != item)
			{
				continue;
			}
			if (equipmentList == null)
			{
				equipmentList = equipment2;
			}
			foreach (GameObject input2 in equipment2.inputList)
			{
				if (input2 != null)
				{
					input2.SetActive(value: true);
				}
			}
		}
		if (equipmentList == null)
		{
			equipmentObj.SetActive(value: false);
			return;
		}
		if (item == ItemType.Building)
		{
			equipmentObj.SetActive(value: false);
			return;
		}
		if (equipmentList.itemIcon != null)
		{
			equipmentImage.sprite = equipmentList.itemIcon;
		}
		equipmentObj.SetActive(value: true);
		levelText.text = "LVL " + gameManager.playerProgressManager.GetLevel(equipmentList.itemType);
		levelObj.SetActive(equipmentList.isLevelActive);
		if (item == ItemType.Dynamite)
		{
			if (gameManager.localEquipments != null)
			{
				SetEquipmentCost(50);
			}
		}
		else
		{
			CloseEquipmentCost();
		}
	}

	public void ClearEquipmentUI()
	{
		if (equipmentObj == null)
		{
			return;
		}
		equipmentObj.SetActive(value: false);
		foreach (EquipmentList equipment in equipments)
		{
			foreach (GameObject input in equipment.inputList)
			{
				if (input != null)
				{
					input.SetActive(value: false);
				}
			}
		}
		liftObj.SetActive(value: false);
		CloseBuildingUI();
		CloseBuildingPlaceModeUI();
	}

	public void Forklift_OnPalletEnter()
	{
		if (forkliftUIRoot != null)
		{
			forkliftUIRoot.SetActive(value: true);
		}
	}

	public void Forklift_OnPalletExit()
	{
		if (forkliftUIRoot != null)
		{
			forkliftUIRoot.SetActive(value: false);
		}
	}

	public void Forklift_OnAttach()
	{
		if (forkliftAnimator != null)
		{
			forkliftAnimator.SetTrigger("Attach");
		}
	}

	public void Forklift_OnDetach()
	{
		if (forkliftAnimator != null)
		{
			forkliftAnimator.SetTrigger("Detach");
		}
	}

	public void Forklift_OnDriverExit()
	{
		Forklift_OnPalletExit();
	}

	public void Forklift_RefreshState(bool hasPallet, bool palletInRange)
	{
		if (!(forkliftUIRoot == null))
		{
			bool active = palletInRange || hasPallet;
			forkliftUIRoot.SetActive(active);
		}
	}

	public void SetBuildingBoxUI(T_BuildingItemSO building)
	{
		if (!(building == null))
		{
			OpenBuildingUI(building);
			CloseBuildingCost();
		}
	}

	private void OnBuildingModeStarted(T_BuildingItemSO building)
	{
		OpenBuildingUI(building);
		OpenBuildingPlaceModeUI(building);
	}

	private void OnBuildingChanged(T_BuildingItemSO building, int currentIndex, int totalCount)
	{
		UpdateBuildingUI(building);
	}

	private void OnBuildingModeStopped()
	{
		CloseBuildingUI();
		CloseBuildingPlaceModeUI();
	}

	public void OpenBuildingUI(T_BuildingItemSO building)
	{
		if (buildingUIPanel == null)
		{
			return;
		}
		buildingUIPanel.SetActive(value: true);
		if (building != null)
		{
			if (buildingIconImage != null && building.Icon != null)
			{
				buildingIconImage.sprite = building.Icon;
				buildingIconImage.enabled = true;
			}
			if (buildingNameText != null)
			{
				string translation = LocalizationManager.GetTranslation(building.Name);
				buildingNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : building.Name);
			}
		}
	}

	public void UpdateBuildingUI(T_BuildingItemSO building)
	{
		if (!(buildingUIPanel == null) && buildingUIPanel.activeSelf && building != null)
		{
			if (buildingIconImage != null && building.Icon != null)
			{
				buildingIconImage.sprite = building.Icon;
			}
			if (buildingNameText != null)
			{
				string translation = LocalizationManager.GetTranslation(building.Name);
				buildingNameText.text = ((!string.IsNullOrEmpty(translation)) ? translation : building.Name);
			}
			SetBuildingCost(building.Price);
		}
	}

	public void CloseBuildingUI()
	{
		if (!(buildingUIPanel == null))
		{
			buildingUIPanel.SetActive(value: false);
			if (buildingIconImage != null)
			{
				buildingIconImage.sprite = null;
				buildingIconImage.enabled = false;
			}
			if (buildingNameText != null)
			{
				buildingNameText.text = "";
			}
		}
	}

	public void OpenBuildingPlaceModeUI(T_BuildingItemSO building = null)
	{
		foreach (GameObject buildingPlaceModeInput in buildingPlaceModeInputList)
		{
			if (buildingPlaceModeInput != null)
			{
				buildingPlaceModeInput.SetActive(value: true);
			}
		}
		bool flag = RadialBuildingManager.Instance != null && RadialBuildingManager.Instance.CurrentSource == BuildingModeSource.RadialMenu;
		bool active = false;
		if (flag)
		{
			T_BuildingCategorySO activeCategory = RadialBuildingManager.Instance.ActiveCategory;
			if (activeCategory != null && activeCategory.BuildingCount > 1)
			{
				active = true;
			}
		}
		foreach (GameObject buildingScrollInput in buildingScrollInputList)
		{
			if (buildingScrollInput != null)
			{
				buildingScrollInput.SetActive(active);
			}
		}
		if (flag && building != null)
		{
			SetBuildingCost(building.Price);
		}
		else
		{
			CloseBuildingCost();
		}
	}

	public void CloseBuildingPlaceModeUI()
	{
		foreach (GameObject buildingPlaceModeInput in buildingPlaceModeInputList)
		{
			if (buildingPlaceModeInput != null)
			{
				buildingPlaceModeInput.SetActive(value: false);
			}
		}
		foreach (GameObject buildingScrollInput in buildingScrollInputList)
		{
			if (buildingScrollInput != null)
			{
				buildingScrollInput.SetActive(value: false);
			}
		}
		CloseBuildingCost();
	}

	public void StartBuildingBoxPlaceMode(T_BuildingItemSO building)
	{
		CloseBuildingInputList();
		OpenBuildingPlaceModeUI(building);
		CloseBuildingCost();
	}

	public void StopBuildingBoxPlaceMode()
	{
		CloseBuildingPlaceModeUI();
		OpenBuildingInputList();
		CloseBuildingCost();
	}

	private void OpenBuildingInputList()
	{
		foreach (EquipmentList equipment in equipments)
		{
			if (equipment.itemType != ItemType.Building)
			{
				continue;
			}
			{
				foreach (GameObject input in equipment.inputList)
				{
					if (input != null)
					{
						input.SetActive(value: true);
					}
				}
				break;
			}
		}
	}

	private void CloseBuildingInputList()
	{
		foreach (EquipmentList equipment in equipments)
		{
			if (equipment.itemType != ItemType.Building)
			{
				continue;
			}
			{
				foreach (GameObject input in equipment.inputList)
				{
					if (input != null)
					{
						input.SetActive(value: false);
					}
				}
				break;
			}
		}
	}

	public void SetEquipmentCost(int price)
	{
		if (equipmentCostObj != null)
		{
			equipmentCostObj.SetActive(value: true);
		}
		if (equipmentCostText != null)
		{
			if (price <= 0)
			{
				equipmentCostText.text = LocalizationManager.GetTranslation("UI_FREE");
			}
			else
			{
				equipmentCostText.text = price.ToString();
			}
		}
	}

	public void CloseEquipmentCost()
	{
		if (equipmentCostObj != null)
		{
			equipmentCostObj.SetActive(value: false);
		}
		if (equipmentCostText != null)
		{
			equipmentCostText.text = "";
		}
	}

	public void SetBuildingCost(int price)
	{
		if (buildingCostObj != null)
		{
			buildingCostObj.SetActive(value: true);
		}
		if (buildingCostText != null)
		{
			if (price <= 0)
			{
				buildingCostText.text = LocalizationManager.GetTranslation("UI_FREE");
			}
			else
			{
				buildingCostText.text = price.ToString();
			}
		}
	}

	public void CloseBuildingCost()
	{
		if (buildingCostObj != null)
		{
			buildingCostObj.SetActive(value: false);
		}
		if (buildingCostText != null)
		{
			buildingCostText.text = "";
		}
	}

	public void OpenDetectorTargetSelectionPanel()
	{
		if (detectorTargetSelectionPanel != null)
		{
			detectorTargetSelectionPanel.OpenPanel();
		}
	}

	public void CloseDetectorTargetSelectionPanel()
	{
		if (detectorTargetSelectionPanel != null)
		{
			detectorTargetSelectionPanel.ClosePanel();
		}
	}

	public bool IsDetectorTargetSelectionPanelOpen()
	{
		if (detectorTargetSelectionPanel != null)
		{
			return detectorTargetSelectionPanel.IsOpen;
		}
		return false;
	}

	private void SubscribeToContractEvents()
	{
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onActiveContractSyncAdded.AddListener(OnActiveContractSyncAdded);
			ComputerContractManager.Instance.onActiveContractSyncRemoved.AddListener(OnActiveContractSyncRemoved);
			ComputerContractManager.Instance.onActiveContractSyncUpdated.AddListener(OnActiveContractSyncUpdated);
			StartCoroutine(WaitForSyncListAndRefreshHUD());
		}
		else
		{
			StartCoroutine(WaitAndSubscribeToContractEvents());
		}
	}

	private IEnumerator WaitAndSubscribeToContractEvents()
	{
		float timeout = 5f;
		float elapsed = 0f;
		while (elapsed < timeout)
		{
			if (ComputerContractManager.Instance != null)
			{
				ComputerContractManager.Instance.onActiveContractSyncAdded.AddListener(OnActiveContractSyncAdded);
				ComputerContractManager.Instance.onActiveContractSyncRemoved.AddListener(OnActiveContractSyncRemoved);
				ComputerContractManager.Instance.onActiveContractSyncUpdated.AddListener(OnActiveContractSyncUpdated);
				yield return StartCoroutine(WaitForSyncListAndRefreshHUD());
				yield break;
			}
			elapsed += 0.2f;
			yield return new WaitForSeconds(0.2f);
		}
		Debug.LogWarning("[UIManager] ComputerContractManager bulunamadı - Contract HUD çalışmayacak.");
	}

	private IEnumerator WaitForSyncListAndRefreshHUD()
	{
		float timeout = 5f;
		float elapsed = 0f;
		while (elapsed < timeout)
		{
			if (ComputerContractManager.Instance != null && ComputerContractManager.Instance.ActiveContractCount > 0)
			{
				RefreshContractHUD();
				yield break;
			}
			elapsed += 0.3f;
			yield return new WaitForSeconds(0.3f);
		}
		RefreshContractHUD();
	}

	private void UnsubscribeFromContractEvents()
	{
		if (ComputerContractManager.Instance != null)
		{
			ComputerContractManager.Instance.onActiveContractSyncAdded.RemoveListener(OnActiveContractSyncAdded);
			ComputerContractManager.Instance.onActiveContractSyncRemoved.RemoveListener(OnActiveContractSyncRemoved);
			ComputerContractManager.Instance.onActiveContractSyncUpdated.RemoveListener(OnActiveContractSyncUpdated);
		}
	}

	private void OnActiveContractSyncAdded(ActiveContractData contract)
	{
		AddContractHUDItem(contract);
	}

	private void OnActiveContractSyncRemoved(ActiveContractData contract)
	{
		if (contract.IsValid)
		{
			RemoveContractHUDItem(contract.activeId);
		}
		else
		{
			ClearContractHUD();
		}
	}

	private void OnActiveContractSyncUpdated(ActiveContractData contract)
	{
		UpdateContractHUDItem(contract);
	}

	private void AddContractHUDItem(ActiveContractData contract)
	{
		if (contractHUDItemPrefab == null || contractHUDContent == null)
		{
			return;
		}
		foreach (ContractHUDItemUI spawnedContractHUDItem in _spawnedContractHUDItems)
		{
			if (spawnedContractHUDItem != null && spawnedContractHUDItem.ActiveId == contract.activeId)
			{
				spawnedContractHUDItem.UpdateContractData(contract);
				return;
			}
		}
		GameObject gameObject = Object.Instantiate(contractHUDItemPrefab, contractHUDContent);
		ContractHUDItemUI component = gameObject.GetComponent<ContractHUDItemUI>();
		if (component != null)
		{
			component.Initialize(contract);
			component.SetDetailsExpanded(_contractHUDDetailsExpanded);
			bool firstItemOnly = _spawnedContractHUDItems.Count == 0;
			component.SetFirstItemOnly(firstItemOnly);
			_spawnedContractHUDItems.Add(component);
		}
		else
		{
			Debug.LogWarning("[UIManager] ContractHUDItemUI component bulunamadı!");
			Object.Destroy(gameObject);
		}
	}

	private void RemoveContractHUDItem(string activeId)
	{
		for (int num = _spawnedContractHUDItems.Count - 1; num >= 0; num--)
		{
			if (_spawnedContractHUDItems[num] != null && _spawnedContractHUDItems[num].ActiveId == activeId)
			{
				Object.Destroy(_spawnedContractHUDItems[num].gameObject);
				_spawnedContractHUDItems.RemoveAt(num);
				break;
			}
		}
	}

	private void UpdateContractHUDItem(ActiveContractData contract)
	{
		foreach (ContractHUDItemUI spawnedContractHUDItem in _spawnedContractHUDItems)
		{
			if (spawnedContractHUDItem != null && spawnedContractHUDItem.ActiveId == contract.activeId)
			{
				spawnedContractHUDItem.UpdateContractData(contract);
				break;
			}
		}
	}

	public void RefreshContractHUD()
	{
		ClearContractHUD();
		if (ComputerContractManager.Instance == null)
		{
			return;
		}
		foreach (ActiveContractData activeContract in ComputerContractManager.Instance.ActiveContracts)
		{
			AddContractHUDItem(activeContract);
		}
	}

	private void ClearContractHUD()
	{
		foreach (ContractHUDItemUI spawnedContractHUDItem in _spawnedContractHUDItems)
		{
			if (spawnedContractHUDItem != null)
			{
				Object.Destroy(spawnedContractHUDItem.gameObject);
			}
		}
		_spawnedContractHUDItems.Clear();
	}

	public void ToggleContractHUDDetails()
	{
		_contractHUDDetailsExpanded = !_contractHUDDetailsExpanded;
		foreach (ContractHUDItemUI spawnedContractHUDItem in _spawnedContractHUDItems)
		{
			if (spawnedContractHUDItem != null)
			{
				spawnedContractHUDItem.SetDetailsExpanded(_contractHUDDetailsExpanded);
			}
		}
	}

	public void ExpandContractHUDDetails()
	{
		_contractHUDDetailsExpanded = true;
		foreach (ContractHUDItemUI spawnedContractHUDItem in _spawnedContractHUDItems)
		{
			if (spawnedContractHUDItem != null)
			{
				spawnedContractHUDItem.ExpandDetails();
			}
		}
	}

	public void CollapseContractHUDDetails()
	{
		_contractHUDDetailsExpanded = false;
		foreach (ContractHUDItemUI spawnedContractHUDItem in _spawnedContractHUDItems)
		{
			if (spawnedContractHUDItem != null)
			{
				spawnedContractHUDItem.CollapseDetails();
			}
		}
	}

	private void SubscribeToDayNightEvents()
	{
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted += OnDayStarted;
			DayNightManager.Instance.OnDayEnded += OnDayEnded;
		}
		else
		{
			StartCoroutine(WaitAndSubscribeToDayNightEvents());
		}
	}

	private IEnumerator WaitAndSubscribeToDayNightEvents()
	{
		float timeout = 5f;
		float elapsed = 0f;
		while (elapsed < timeout)
		{
			if (DayNightManager.Instance != null)
			{
				DayNightManager.Instance.OnDayStarted += OnDayStarted;
				DayNightManager.Instance.OnDayEnded += OnDayEnded;
				yield break;
			}
			elapsed += 0.2f;
			yield return new WaitForSeconds(0.2f);
		}
		Debug.LogWarning("[UIManager] DayNightManager bulunamadı - Night UI çalışmayacak.");
	}

	private void UnsubscribeFromDayNightEvents()
	{
		if (DayNightManager.Instance != null)
		{
			DayNightManager.Instance.OnDayStarted -= OnDayStarted;
			DayNightManager.Instance.OnDayEnded -= OnDayEnded;
		}
	}

	private void OnDayStarted()
	{
		HideNightUI();
	}

	private void OnDayEnded()
	{
		ShowNightUI();
	}

	public void ShowNightUI()
	{
		if (nightUIObject != null)
		{
			nightUIObject.SetActive(value: true);
		}
	}

	public void HideNightUI()
	{
		if (nightUIObject != null)
		{
			nightUIObject.SetActive(value: false);
		}
	}

	public void SetNightUI(bool show)
	{
		if (nightUIObject != null)
		{
			nightUIObject.SetActive(show);
		}
	}
}
