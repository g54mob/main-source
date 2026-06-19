using TMPro;
using UnityEngine;

public class AutoFeederGUIController : MonoBehaviour
{
	public TextMeshPro amountText;

	public TextMeshPro objectNameText;

	public Transform objectDisplayTransform;

	public GameObject baseWindow;

	public AutoFeederBoxes boxesRef;

	public GameObject popupObjectSelectionWindow;

	private AutoFeeder feederRef;

	private GUIManagerPens guiManagerRef;

	private void Awake()
	{
		baseWindow.SetActive(value: true);
		popupObjectSelectionWindow.SetActive(value: false);
	}

	private void Initialize()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		InitializeGUI();
	}

	public void SetFeederRef(AutoFeeder newRef)
	{
		feederRef = newRef;
		Initialize();
		feederRef.Pause();
	}

	private void InitializeGUI()
	{
		guiManagerRef.DisableBG(LockReason.AUTO_FEEDER);
		UpdateAmountDisplay();
	}

	public void AmountIncrease()
	{
		feederRef.UpdateAmount(1);
		UpdateAmountDisplay();
	}

	public void AmountDecrease()
	{
		feederRef.UpdateAmount(-1);
		UpdateAmountDisplay();
	}

	public void ShowObjectSelectionPopupWindow()
	{
		baseWindow.SetActive(value: false);
		popupObjectSelectionWindow.SetActive(value: true);
		boxesRef.Preload();
		boxesRef.SetSelectedObject(feederRef.foodType);
		boxesRef.Load(OnBoxesLoaded);
		boxesRef.UpdateScrolling();
	}

	private void OnBoxesLoaded()
	{
	}

	public void CloseObjectSelectionPopupWindow()
	{
		boxesRef.Unload(OnBoxesUnloaded);
	}

	private void OnBoxesUnloaded()
	{
		baseWindow.SetActive(value: true);
		popupObjectSelectionWindow.SetActive(value: false);
	}

	public void UpdateItem(InventoryItem newItem)
	{
		feederRef.UpdateItem(newItem);
		CloseObjectSelectionPopupWindow();
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.AUTO_FEEDER);
		feederRef.Unpause();
		Object.Destroy(base.gameObject);
	}

	private void UpdateAmountDisplay()
	{
		amountText.text = feederRef.simultaneousFoodBits.ToString();
	}
}
