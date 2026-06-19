using TMPro;
using UnityEngine;

public class GardenSignGUIController_Old : MonoBehaviour
{
	public TextMeshPro objectNameText;

	public TextMeshPro objectCostText;

	public Transform objectDisplayTransform;

	public TextMeshPro mulchNameText;

	public GameObject mulchRemoveButton;

	public SpriteRenderer mulchDisplayRenderer;

	public GameObject baseWindow;

	public MulchBoxes mulchBoxesRef;

	public GardenSignBoxes boxesRef;

	public GameObject popupObjectSelectionWindow;

	private bool viewingMulch;

	public bool viewingGrowables;

	private InventoryItem currentItemType;

	private GameObject currentPreviewObject;

	private Mulch currentMulch;

	private GrowableObject currentGrowable;

	private GardenPlot gardenPlotRef;

	private GUIManagerPens guiManagerRef;

	private InventoryManager inventoryRef;

	private void Awake()
	{
		baseWindow.SetActive(value: true);
		popupObjectSelectionWindow.SetActive(value: false);
	}

	private void Initialize()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		InitializeGUI();
	}

	public void SetPlotRef(GardenPlot newRef)
	{
		gardenPlotRef = newRef;
		Initialize();
	}

	private void InitializeGUI()
	{
		guiManagerRef.DisableBG(LockReason.GARDEN_SIGN);
		currentMulch = null;
		currentGrowable = gardenPlotRef.GetCurrentGrowable();
		UpdateObjectTypeDisplay();
		ShowObjectSelectionPopupWindow();
	}

	public void ShowObjectSelectionPopupWindow()
	{
		viewingGrowables = true;
		baseWindow.SetActive(value: false);
		popupObjectSelectionWindow.SetActive(value: true);
		boxesRef.Preload();
		boxesRef.SetSelectedObject(currentGrowable);
		boxesRef.Load(OnBoxesLoaded);
		boxesRef.UpdateScrolling();
	}

	public void ShowMulchSelectionPopupWindow()
	{
		viewingMulch = true;
		baseWindow.SetActive(value: false);
		popupObjectSelectionWindow.SetActive(value: true);
		mulchBoxesRef.Preload();
		mulchBoxesRef.SetSelectedObject(currentMulch);
		mulchBoxesRef.Load(OnBoxesLoaded);
		mulchBoxesRef.UpdateScrolling();
	}

	private void OnBoxesLoaded()
	{
	}

	public void CloseObjectSelectionPopupWindow()
	{
		if (viewingMulch)
		{
			viewingMulch = false;
			mulchBoxesRef.Unload(OnBoxesUnloaded);
		}
		else if (viewingGrowables)
		{
			viewingGrowables = false;
			boxesRef.Unload(OnBoxesUnloaded);
		}
	}

	private void OnBoxesUnloaded()
	{
		baseWindow.SetActive(value: true);
		popupObjectSelectionWindow.SetActive(value: false);
	}

	public void UpdateGrowable(GrowableObject newItem)
	{
		currentGrowable = newItem;
		UpdateObjectTypeDisplay();
		CloseObjectSelectionPopupWindow();
	}

	public void UpdateMulchType(Mulch newMulch)
	{
		currentMulch = newMulch;
		UpdateObjectTypeDisplay();
		CloseObjectSelectionPopupWindow();
	}

	public void RemoveMulch()
	{
		currentMulch = null;
		UpdateObjectTypeDisplay();
		gardenPlotRef.ClearPreviousMulch();
	}

	public void UpdateGrowableAndCloseGUI()
	{
		gardenPlotRef.PlantNewGrowable(currentGrowable, currentMulch);
		UpdateObjectTypeDisplay();
		CloseGUI();
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.GARDEN_SIGN);
		Object.Destroy(base.gameObject);
	}

	private void UpdateObjectTypeDisplay()
	{
	}
}
