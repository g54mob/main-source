using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacementModeGUI : MonoBehaviour
{
	public RectTransform leftPanel;

	public CursorUpdateArea updateAreaRef;

	public GameObject objectHolderBoxPrefab;

	public TextMeshProUGUI activeCategoryName;

	public GameObject denInfoButton;

	public GameObject placementControls;

	public GameObject denInfoWindow;

	public TextScaleInOnLoad denInfoHeaderBouncer;

	public TextMeshProUGUI denInfoDenNumberText;

	public RectTransform boxListTransform;

	public RectTransform sliderAreaTransform;

	public Image activeObjectIconHolder;

	public GameObject activeObjectPanel;

	public TextMeshProUGUI activeObjectNumleft;

	public GameObject activeObjectNumleftHolder;

	public Image selectButton;

	public Image destroyButton;

	public CoreButtonUnityGUI pruneButton;

	public CoreButtonUnityGUI massCleanButton;

	public Color modeButtonActiveColor;

	public Color modeButtonInactiveColor;

	public Material validObjectMaterial;

	public Material invalidObjectMaterial;

	public GameObject plantPrunedParicles;

	public GameObject objectPlacementParticles;

	public GameObject objectDestructionParticles;

	public Tooltip tooltip;

	public TextMeshProUGUI rotateCommandText;

	public TextMeshProUGUI scaleIncreaseCommandText;

	public TextMeshProUGUI scaleDecreaseCommandText;

	public PlacementModeTab startingTab;

	private PlacementModeTab activeTab;

	private CustomizationType currentCategory = CustomizationType.TOY;

	private ColorBlock pruneColorBlockDefault;

	private ColorBlock pruneColorBlockActive;

	private float leftPanelActiveX;

	private float leftPanelInactiveX = -438f;

	private bool leftPanelVisible = true;

	private string leftPanelShowSound = "placementPanelOpen";

	private string leftPanelHideSound = "placementPanelClose";

	private int elementsPerRow = 2;

	private float finalOffset = 250f;

	private float initialOffset = -10f;

	private float verticalOffset = 160f;

	private float horizontalOffset = 160f;

	private List<GameObject> allBoxes = new List<GameObject>();

	private PlacementBox currentlySelectedBox;

	private ControlManager controlsRef;

	private CursorController cursorRef;

	private ResearchManager researchRef;

	private PlayerInventory inventoryRef;

	private void Awake()
	{
		pruneColorBlockDefault = pruneButton.colors;
		pruneColorBlockActive = default(ColorBlock);
		pruneColorBlockActive.colorMultiplier = 1f;
		pruneColorBlockActive.normalColor = pruneColorBlockDefault.pressedColor;
		pruneColorBlockActive.pressedColor = pruneColorBlockDefault.pressedColor;
		pruneColorBlockActive.selectedColor = pruneColorBlockDefault.selectedColor;
		pruneColorBlockActive.disabledColor = pruneColorBlockDefault.disabledColor;
		pruneColorBlockActive.highlightedColor = pruneColorBlockDefault.pressedColor;
		ObjectPlacementManager.plantPrunedParticles = plantPrunedParicles;
		ObjectPlacementManager.objectPlacementParticles = objectPlacementParticles;
		ObjectPlacementManager.objectDestructionParticles = objectDestructionParticles;
	}

	private void Start()
	{
		ObjectPlacementManager.SetPlacementModeGUIRef(this);
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		cursorRef = registrationScript.GetGlobalComponent<CursorController>(GlobalObject.CURSOR);
		controlsRef = registrationScript.GetGlobalComponent<ControlManager>(GlobalObject.CONTROL_MANAGER);
		researchRef = registrationScript.GetGlobalComponent<ResearchManager>(GlobalObject.RESEARCH_MANAGER);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		CreateBoxes(fromRefresh: false, playSounds: false);
		HidePlacementControls();
		SetActiveTab(startingTab, playSounds: false);
		denInfoWindow.SetActive(value: false);
	}

	private void OnEnable()
	{
		CloseDenInfoWindow();
		ShowPanels(playSounds: false);
		RefreshCurrentCategory();
		if (TutorialController.IsTutorialActive() && activeTab != null)
		{
			if (activeTab.tabType == CustomizationType.UTILITY)
			{
				TutorialController.OnUtilitiesTabVisible();
			}
			else
			{
				TutorialController.OnUtilitiesTabHidden();
			}
		}
		string gUI_PLCMNT_ROTATE = ScriptLocalization.GUI.GUI_PLCMNT_ROTATE;
		string gUI_PLCMNT_SCALE_INCREASE = ScriptLocalization.GUI.GUI_PLCMNT_SCALE_INCREASE;
		string gUI_PLCMNT_SCALE_DECREASE = ScriptLocalization.GUI.GUI_PLCMNT_SCALE_DECREASE;
		int length = gUI_PLCMNT_ROTATE.IndexOf('[');
		int num = gUI_PLCMNT_ROTATE.IndexOf(']');
		int length2 = gUI_PLCMNT_SCALE_INCREASE.IndexOf('[');
		int num2 = gUI_PLCMNT_SCALE_INCREASE.IndexOf(']');
		int length3 = gUI_PLCMNT_SCALE_DECREASE.IndexOf('[');
		int num3 = gUI_PLCMNT_SCALE_DECREASE.IndexOf(']');
		if (controlsRef == null)
		{
			rotateCommandText.text = gUI_PLCMNT_ROTATE.Substring(0, length) + gUI_PLCMNT_ROTATE.Substring(num + 1);
			scaleIncreaseCommandText.text = gUI_PLCMNT_SCALE_INCREASE.Substring(0, length2) + gUI_PLCMNT_SCALE_INCREASE.Substring(num2 + 1);
			scaleDecreaseCommandText.text = gUI_PLCMNT_SCALE_DECREASE.Substring(0, length3) + gUI_PLCMNT_SCALE_DECREASE.Substring(num3 + 1);
			return;
		}
		string currentActiveBindingForCommand = controlsRef.GetCurrentActiveBindingForCommand(ControlCommand.ROTATE_HELD_OBJECT_RIGHT, cursorRef);
		string currentActiveBindingForCommand2 = controlsRef.GetCurrentActiveBindingForCommand(ControlCommand.INC_HELD_OBJECT_SCALE, cursorRef);
		string currentActiveBindingForCommand3 = controlsRef.GetCurrentActiveBindingForCommand(ControlCommand.DEC_HELD_OBJECT_SCALE, cursorRef);
		gUI_PLCMNT_ROTATE = gUI_PLCMNT_ROTATE.Substring(0, length) + currentActiveBindingForCommand + gUI_PLCMNT_ROTATE.Substring(num + 1);
		gUI_PLCMNT_SCALE_INCREASE = gUI_PLCMNT_SCALE_INCREASE.Substring(0, length2) + currentActiveBindingForCommand2 + gUI_PLCMNT_SCALE_INCREASE.Substring(num2 + 1);
		gUI_PLCMNT_SCALE_DECREASE = gUI_PLCMNT_SCALE_DECREASE.Substring(0, length3) + currentActiveBindingForCommand3 + gUI_PLCMNT_SCALE_DECREASE.Substring(num3 + 1);
		rotateCommandText.text = gUI_PLCMNT_ROTATE;
		scaleIncreaseCommandText.text = gUI_PLCMNT_SCALE_INCREASE;
		scaleDecreaseCommandText.text = gUI_PLCMNT_SCALE_DECREASE;
	}

	public void OnDenInfoButtonPressed()
	{
		denInfoWindow.SetActive(value: true);
		denInfoHeaderBouncer.RequestScaleIn();
		UpdateDenNumberText();
	}

	public void CloseDenInfoWindow()
	{
		denInfoWindow.SetActive(value: false);
	}

	public void DecrementDenCounter()
	{
		RoomBase currentPlacementRoom = ObjectPlacementManager.GetCurrentPlacementRoom();
		int numberOfDensToBuild = currentPlacementRoom.GetNumberOfDensToBuild();
		currentPlacementRoom.UpdateNumberOfDensToBuild(numberOfDensToBuild - 1);
		UpdateDenNumberText();
	}

	public void IncrementDenCounter()
	{
		RoomBase currentPlacementRoom = ObjectPlacementManager.GetCurrentPlacementRoom();
		int numberOfDensToBuild = currentPlacementRoom.GetNumberOfDensToBuild();
		currentPlacementRoom.UpdateNumberOfDensToBuild(numberOfDensToBuild + 1);
		UpdateDenNumberText();
	}

	private void UpdateDenNumberText()
	{
		denInfoDenNumberText.text = ObjectPlacementManager.GetCurrentPlacementRoom().GetNumberOfDensToBuild().ToString();
	}

	public void OnExitButtonPressed()
	{
		ObjectPlacementManager.GoBackAMode();
	}

	public bool IsDenInfoWindowActive()
	{
		return denInfoWindow.activeSelf;
	}

	public Material GetMaterialForObjectState(PlaceableObjectState state)
	{
		switch (state)
		{
		case PlaceableObjectState.DEFAULT:
			return null;
		case PlaceableObjectState.SELECTED_FOR_MOVE:
			return validObjectMaterial;
		case PlaceableObjectState.SELECTED_FOR_DELETE:
			return invalidObjectMaterial;
		case PlaceableObjectState.VALID_PLACEMENT:
			return null;
		case PlaceableObjectState.INVALID_PLACEMENT:
			return invalidObjectMaterial;
		default:
			Debug.LogError("Invalid or unimplemented state passed to GetMaterialForObjectState.");
			return null;
		}
	}

	public void SetActiveTab(PlacementModeTab newTab, bool playSounds = true)
	{
		if (TutorialController.IsTutorialActive())
		{
			if (newTab.tabType == CustomizationType.UTILITY)
			{
				TutorialController.OnUtilitiesTabVisible();
			}
			else
			{
				TutorialController.OnUtilitiesTabHidden();
			}
		}
		activeCategoryName.text = GetCategoryNameForCategory(newTab.tabType);
		if (activeTab == newTab)
		{
			if (leftPanelVisible)
			{
				HidePanels();
			}
			else
			{
				ShowPanels(playSounds);
			}
			return;
		}
		currentCategory = newTab.tabType;
		RefreshBoxes();
		newTab.SetActive();
		if (activeTab != null)
		{
			activeTab.SetInactive();
		}
		activeTab = newTab;
		ShowPanels(playSounds);
	}

	public void HidePanels(bool playSounds = true)
	{
		HideLeftPanel(playSounds);
	}

	public void ShowPanels(bool playSounds = true)
	{
		RefreshBoxes();
		selectButton.color = modeButtonInactiveColor;
		destroyButton.color = modeButtonInactiveColor;
		pruneButton.colors = pruneColorBlockDefault;
		ShowLeftPanel(playSounds);
		HidePlacementControls();
		ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.IDLE);
	}

	public void HideLeftPanel(bool playSounds = true)
	{
		if (leftPanelVisible && playSounds)
		{
			AudioController.Play(leftPanelHideSound);
		}
		leftPanelVisible = false;
		leftPanel.anchoredPosition = new Vector2(leftPanelInactiveX, leftPanel.anchoredPosition.y);
		tooltip.gameObject.SetActive(value: false);
		if (TutorialController.IsTutorialActive())
		{
			TutorialController.OnUtilitiesTabHidden();
		}
	}

	public void ShowLeftPanel(bool playSounds = true)
	{
		if (!leftPanelVisible && playSounds)
		{
			AudioController.Play(leftPanelShowSound);
		}
		HideActiveObjectPanel();
		leftPanelVisible = true;
		leftPanel.anchoredPosition = new Vector2(leftPanelActiveX, leftPanel.anchoredPosition.y);
		if (TutorialController.IsTutorialActive() && currentCategory == CustomizationType.UTILITY)
		{
			TutorialController.OnUtilitiesTabVisible();
		}
		activeCategoryName.text = GetCategoryNameForCategory(currentCategory);
	}

	public void ShowActiveObjectPanel(RoomCustomizationObject activeObject)
	{
		activeObjectPanel.SetActive(value: true);
		activeObjectIconHolder.sprite = activeObject.icon;
		UpdateActiveObjectLeftText(activeObject);
	}

	public void ShowActiveObjectPanel(InventoryItem activeItem)
	{
		activeObjectPanel.SetActive(value: true);
		activeObjectIconHolder.sprite = activeItem.icon;
		UpdateActiveObjectLeftText(activeItem);
	}

	public void ShowPlacementControls()
	{
		denInfoButton.SetActive(value: false);
		placementControls.SetActive(value: true);
	}

	public void HidePlacementControls()
	{
		denInfoButton.SetActive(value: true);
		placementControls.SetActive(value: false);
	}

	public void UpdateActiveObjectLeftText(RoomCustomizationObject activeObject)
	{
		if (activeObjectPanel.activeSelf)
		{
			activeObjectNumleftHolder.SetActive(value: false);
		}
	}

	public int UpdateActiveObjectLeftText(InventoryItem activeItem)
	{
		if (!activeObjectPanel.activeSelf)
		{
			return -1;
		}
		int numberOfItemHeld = inventoryRef.GetNumberOfItemHeld(activeItem);
		if (numberOfItemHeld <= 1)
		{
			activeObjectNumleftHolder.SetActive(value: false);
		}
		else
		{
			activeObjectNumleftHolder.SetActive(value: true);
			activeObjectNumleft.text = numberOfItemHeld.ToString();
		}
		return numberOfItemHeld;
	}

	public void HideActiveObjectPanel()
	{
		activeObjectPanel.SetActive(value: false);
	}

	private string GetCategoryNameForCategory(CustomizationType categoryType)
	{
		switch (categoryType)
		{
		case CustomizationType.CARPET:
			return ScriptLocalization.GUI.GUI_PLCMNT_CARPETS;
		case CustomizationType.DECORATION:
			return ScriptLocalization.GUI.GUI_PLCMNT_DECORATIONS;
		case CustomizationType.GARDENING:
			return ScriptLocalization.GUI.GUI_PLCMNT_GARDENING;
		case CustomizationType.TOY:
			return ScriptLocalization.GUI.GUI_PLCMNT_TOYS;
		case CustomizationType.WALLPAPER:
			return ScriptLocalization.GUI.GUI_PLCMNT_WALLPAPERS;
		case CustomizationType.WALL:
			return ScriptLocalization.GUI.GUI_PLCMNT_WALLS;
		case CustomizationType.UTILITY:
			return ScriptLocalization.GUI.GUI_PLCMNT_UTILS;
		case CustomizationType.DEN_UPGRADES:
			return ScriptLocalization.GUI.GUI_PLCMNT_DENUPGRADES;
		default:
			Debug.LogError("Invalid categoryType: " + categoryType);
			return "ERROR";
		}
	}

	public void OnSelectButtonPressed()
	{
		HidePanels();
		ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.SELECT);
		selectButton.color = modeButtonActiveColor;
		destroyButton.color = modeButtonInactiveColor;
		pruneButton.colors = pruneColorBlockDefault;
	}

	public void OnDestroyButtonPressed()
	{
		HidePanels();
		ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.DESTROY);
		destroyButton.color = modeButtonActiveColor;
		selectButton.color = modeButtonInactiveColor;
		pruneButton.colors = pruneColorBlockDefault;
	}

	public void OnPruneButtonPressed()
	{
		HidePanels();
		ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.PRUNE);
		selectButton.color = modeButtonInactiveColor;
		destroyButton.color = modeButtonInactiveColor;
		pruneButton.colors = pruneColorBlockActive;
		pruneButton.OnPointerExit(null);
		pruneButton.interactable = false;
	}

	public void OnMassCleanButtonPressed()
	{
		HidePanels();
		ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.SELECT);
		selectButton.color = modeButtonActiveColor;
		destroyButton.color = modeButtonInactiveColor;
		pruneButton.colors = pruneColorBlockDefault;
		massCleanButton.OnPointerExit(null);
		massCleanButton.interactable = false;
		ObjectPlacementManager.ShowMassCleanPopup(ObjectRegistration.GetRegistrationScript().GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI));
	}

	public void OnPlantPlaced()
	{
		GoalsController.ReportGoalEvent(GoalCondition.PLANT_SEED);
		InventoryItem containedInventoryItem = currentlySelectedBox.GetContainedInventoryItem();
		inventoryRef.RemoveObjectFromInventory(containedInventoryItem);
		if (UpdateActiveObjectLeftText(containedInventoryItem) <= 0)
		{
			ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.IDLE);
			ShowPanels();
		}
	}

	public void OnPlaceButtonPressed(bool playSounds = true)
	{
		if (currentCategory == CustomizationType.GARDENING)
		{
			InventoryItem containedInventoryItem = currentlySelectedBox.GetContainedInventoryItem();
			ObjectPlacementManager.SetDraggableObjectPrefab(containedInventoryItem.itemPrefab.GetComponent<SeedPacket>().containedPlant, !containedInventoryItem.placeableObjectOverride, containedInventoryItem);
			ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.PLACE, playSounds);
			ObjectPlacementManager.SetObjectPlacedCallback(OnPlantPlaced);
			HidePanels(playSounds);
			return;
		}
		RoomCustomizationObject containedItem = currentlySelectedBox.GetContainedItem();
		switch (containedItem.objectType)
		{
		case CustomizationType.CARPET:
			ObjectPlacementManager.ApplyCarpetToRoom(containedItem);
			return;
		case CustomizationType.WALLPAPER:
			ObjectPlacementManager.ApplyWallpaperToRoom(containedItem);
			return;
		}
		ObjectPlacementManager.SetDraggableObjectPrefab(containedItem);
		ObjectPlacementManager.SetSubMode(ObjectPlacementManager.SubMode.PLACE, playSounds);
		HidePanels(playSounds);
	}

	public void RefreshCurrentCategory()
	{
		int selectedBoxIndex = GetSelectedBoxIndex();
		RefreshBoxes();
		SelectBoxByIndex(selectedBoxIndex, fromRefresh: true);
	}

	private void SelectBoxByIndex(int index, bool fromRefresh = false)
	{
		if (index >= allBoxes.Count)
		{
			index = allBoxes.Count - 1;
		}
		if (index >= 0)
		{
			SelectBox(allBoxes[index].GetComponent<PlacementBox>(), fromRefresh);
		}
	}

	private int GetSelectedBoxIndex()
	{
		for (int i = 0; i < allBoxes.Count; i++)
		{
			if (currentlySelectedBox.gameObject == allBoxes[i])
			{
				return i;
			}
		}
		return 0;
	}

	public void SelectBox(PlacementBox newBox, bool fromRefresh = false, bool playSounds = true)
	{
		currentlySelectedBox = newBox;
		if (!fromRefresh)
		{
			OnPlaceButtonPressed(playSounds);
		}
	}

	private void RefreshBoxes()
	{
		for (int num = allBoxes.Count - 1; num >= 0; num--)
		{
			Object.Destroy(allBoxes[num]);
		}
		allBoxes.Clear();
		CreateBoxes(fromRefresh: true);
	}

	private void CreateBoxes(bool fromRefresh = false, bool playSounds = true)
	{
		if (researchRef == null)
		{
			return;
		}
		if (currentCategory == CustomizationType.GARDENING)
		{
			Dictionary<InventoryItem, int> heldItemsOfType = inventoryRef.GetHeldItemsOfType(ItemType.SEED_PACKET);
			List<InventoryItem> list = new List<InventoryItem>();
			list.AddRange(heldItemsOfType.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				GameObject gameObject = Object.Instantiate(objectHolderBoxPrefab, boxListTransform);
				PlacementBox component = gameObject.GetComponent<PlacementBox>();
				component.SetControllerRef(this, updateAreaRef);
				component.SetContainedItem(list[i], heldItemsOfType[list[i]], tooltip);
				PositionNewBox(gameObject);
			}
		}
		else if (currentCategory == CustomizationType.DEN_UPGRADES)
		{
			Dictionary<InventoryItem, int> heldItemsOfType2 = inventoryRef.GetHeldItemsOfType(ItemType.DEN_UPGRADE);
			List<InventoryItem> list2 = new List<InventoryItem>();
			list2.AddRange(heldItemsOfType2.Keys);
			for (int j = 0; j < list2.Count; j++)
			{
				GameObject gameObject2 = Object.Instantiate(objectHolderBoxPrefab, boxListTransform);
				PlacementBox component2 = gameObject2.GetComponent<PlacementBox>();
				component2.SetControllerRef(this, updateAreaRef);
				component2.SetContainedItem(list2[j], heldItemsOfType2[list2[j]], tooltip);
				PositionNewBox(gameObject2);
			}
		}
		else
		{
			List<RoomCustomizationObject> unlockedRoomCustomizationObjectsOfType = researchRef.GetUnlockedRoomCustomizationObjectsOfType(currentCategory);
			for (int k = 0; k < unlockedRoomCustomizationObjectsOfType.Count; k++)
			{
				GameObject gameObject3 = Object.Instantiate(objectHolderBoxPrefab, boxListTransform);
				PlacementBox component3 = gameObject3.GetComponent<PlacementBox>();
				component3.SetControllerRef(this, updateAreaRef);
				component3.SetContainedItem(unlockedRoomCustomizationObjectsOfType[k], 1, tooltip);
				PositionNewBox(gameObject3);
			}
		}
		if (allBoxes.Count == 0)
		{
			sliderAreaTransform.sizeDelta = new Vector2(0f, verticalOffset + finalOffset);
			boxListTransform.anchoredPosition3D = new Vector3(boxListTransform.anchoredPosition3D.x, initialOffset + finalOffset / 2f, 0f);
			currentlySelectedBox = null;
		}
		else
		{
			SelectBox(allBoxes[0].GetComponent<PlacementBox>(), fromRefresh, playSounds);
		}
	}

	private void PositionNewBox(GameObject obj)
	{
		int num = allBoxes.Count % elementsPerRow;
		int num2 = Mathf.FloorToInt(allBoxes.Count / elementsPerRow);
		obj.transform.localPosition = Vector3.right * horizontalOffset * num + Vector3.down * verticalOffset * num2;
		float num3 = (float)num2 * verticalOffset;
		float num4 = (float)(num2 - 1) * verticalOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num3 + finalOffset);
		boxListTransform.anchoredPosition3D = new Vector3(boxListTransform.anchoredPosition3D.x, initialOffset + (num4 + finalOffset) / 2f, 0f);
		allBoxes.Add(obj);
	}
}
