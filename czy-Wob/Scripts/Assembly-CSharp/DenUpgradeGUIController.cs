using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DenUpgradeGUIController : MonoBehaviour
{
	public GameObject denUpgradeHolderBoxPrefab;

	public CursorUpdateArea updateAreaRef;

	public GameObject noUpgradesText;

	public GameObject trashUpgradeButton;

	public RectTransform sliderAreaTransform;

	public RectTransform upgradeListTransform;

	public TextMeshProUGUI upgradeNameText;

	public Transform upgradeRotationTransform;

	public InchwormBounce upgradeRotationBouncer;

	public GameObject upgradeButtonRef;

	public GameObject removeUpgradeButtonRef;

	public GameObject removeUpgradePopupHolder;

	private DogDen denRef;

	private DenUpgradeBox currentlySelectedBox;

	private GameObject currentlyRotatedUpgrade;

	private string windowOpenSound = "incubator_window_open";

	private string windowCloseSound = "incubator_window_close";

	private int elementsPerRow = 3;

	private float finalOffset = 10f;

	private float initialOffset = -5f;

	private float verticalOffset = 50f;

	private float horizontalOffset = 50f;

	private List<GameObject> allUpgrades = new List<GameObject>();

	private GUIManagerPens guiManagerRef;

	private PlayerInventory inventoryRef;

	private void Start()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		guiManagerRef.DisableBG(LockReason.DENUPGRADE_GUI);
		guiManagerRef.RegisterNewPopup(LockReason.DENUPGRADE_GUI, stomp: true, CloseGUI);
		CreateBoxes();
		removeUpgradePopupHolder.SetActive(value: false);
		AudioController.Play(windowOpenSound);
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			CloseGUI();
		}
	}

	public void SetDogDenRef(DogDen newRef)
	{
		denRef = newRef;
		if (denRef.GetCurrentDenUpgrade() == DenUpgradeType.NONE)
		{
			removeUpgradeButtonRef.SetActive(value: false);
		}
		else
		{
			removeUpgradeButtonRef.SetActive(value: true);
		}
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.DENUPGRADE_GUI);
		guiManagerRef.ClearPopupRegistration(LockReason.DENUPGRADE_GUI);
		Object.Destroy(base.gameObject);
		AudioController.Play(windowCloseSound);
	}

	public void OnRemoveUpgradeButtonPressed()
	{
		removeUpgradePopupHolder.SetActive(value: true);
	}

	public void OnConfirmRemoveUpgradeButtonPressed()
	{
		removeUpgradePopupHolder.SetActive(value: false);
		denRef.ApplyDenUpgrade(DenUpgradeType.NONE);
		CloseGUI();
	}

	public void OnCancelRemoveUpgradeButtonPressed()
	{
		removeUpgradePopupHolder.SetActive(value: false);
	}

	public void OnUpgradeButtonPressed()
	{
		if (currentlySelectedBox == null)
		{
			CloseGUI();
			Debug.LogError("Attempting to upgrade a den without a selected box.");
			return;
		}
		InventoryItem containedItem = currentlySelectedBox.GetContainedItem();
		if (containedItem == null)
		{
			CloseGUI();
			Debug.LogError("Attempting to use a den upgrade that doesn't exit.");
			return;
		}
		inventoryRef.RemoveObjectFromInventory(containedItem);
		RefreshBoxes();
		denRef.ApplyDenUpgrade(containedItem.itemPrefab.GetComponent<DenUpgrade>().upgradeType);
		CloseGUI();
		GoalsController.ReportGoalEvent(GoalCondition.DEN_UPGRADE);
	}

	public void SelectBox(DenUpgradeBox newBox)
	{
		if (!(currentlySelectedBox == newBox))
		{
			if (currentlyRotatedUpgrade != null)
			{
				Object.Destroy(currentlyRotatedUpgrade);
				currentlyRotatedUpgrade = null;
			}
			if (currentlySelectedBox != null)
			{
				currentlySelectedBox.OnDeselected();
			}
			newBox.OnSelected();
			currentlySelectedBox = newBox;
			UpdateDisplay();
		}
	}

	public void OnTrashUpgradeButtonPressed()
	{
		InventoryItem containedItem = currentlySelectedBox.GetContainedItem();
		if (containedItem != null)
		{
			inventoryRef.RemoveObjectFromInventory(containedItem);
			RefreshBoxes();
		}
	}

	public void OnConfirmTrashUpgrade()
	{
		InventoryItem containedItem = currentlySelectedBox.GetContainedItem();
		if (containedItem != null)
		{
			inventoryRef.RemoveObjectFromInventory(containedItem);
			RefreshBoxes();
		}
	}

	private void RefreshBoxes()
	{
		for (int num = allUpgrades.Count - 1; num >= 0; num--)
		{
			Object.Destroy(allUpgrades[num]);
		}
		if (currentlyRotatedUpgrade != null)
		{
			Object.Destroy(currentlyRotatedUpgrade);
			currentlyRotatedUpgrade = null;
		}
		allUpgrades.Clear();
		CreateBoxes();
	}

	private void CreateBoxes()
	{
		Dictionary<InventoryItem, int> heldItemsOfType = inventoryRef.GetHeldItemsOfType(ItemType.DEN_UPGRADE);
		List<InventoryItem> list = new List<InventoryItem>();
		list.AddRange(heldItemsOfType.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			GameObject gameObject = Object.Instantiate(denUpgradeHolderBoxPrefab, upgradeListTransform);
			DenUpgradeBox component = gameObject.GetComponent<DenUpgradeBox>();
			component.SetControllerRef(this, updateAreaRef);
			component.SetContainedItem(list[i], heldItemsOfType[list[i]]);
			PositionNewBox(gameObject);
		}
		if (allUpgrades.Count == 0)
		{
			sliderAreaTransform.sizeDelta = new Vector2(0f, verticalOffset + finalOffset);
			upgradeListTransform.anchoredPosition3D = new Vector3(upgradeListTransform.anchoredPosition3D.x, initialOffset + finalOffset / 2f, 0f);
			upgradeNameText.text = "";
			noUpgradesText.SetActive(value: true);
			upgradeButtonRef.SetActive(value: false);
			trashUpgradeButton.SetActive(value: false);
		}
		else
		{
			noUpgradesText.SetActive(value: false);
			upgradeButtonRef.SetActive(value: true);
			if (TutorialController.IsTutorialActive())
			{
				trashUpgradeButton.SetActive(value: false);
			}
			else
			{
				trashUpgradeButton.SetActive(value: true);
			}
			SelectBox(allUpgrades[0].GetComponent<DenUpgradeBox>());
		}
	}

	private void PositionNewBox(GameObject obj)
	{
		int count = allUpgrades.Count;
		int num = count % elementsPerRow;
		int num2 = Mathf.FloorToInt(count / elementsPerRow);
		obj.transform.localPosition = Vector3.right * horizontalOffset * num + Vector3.down * verticalOffset * num2;
		float num3 = (float)(num2 + 1) * verticalOffset;
		float num4 = (float)num2 * verticalOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num3 + finalOffset);
		upgradeListTransform.anchoredPosition3D = new Vector3(upgradeListTransform.anchoredPosition3D.x, initialOffset + (num4 + finalOffset) / 2f, 0f);
		allUpgrades.Add(obj);
	}

	private void UpdateDisplay()
	{
		if (currentlySelectedBox == null)
		{
			upgradeNameText.text = "";
			return;
		}
		InventoryItem containedItem = currentlySelectedBox.GetContainedItem();
		currentlyRotatedUpgrade = Object.Instantiate(denRef.GetObjectForUpgradeType(containedItem.itemPrefab.GetComponent<DenUpgrade>().upgradeType));
		currentlyRotatedUpgrade.SetActive(value: true);
		currentlyRotatedUpgrade.transform.position = upgradeRotationTransform.position;
		currentlyRotatedUpgrade.transform.rotation = upgradeRotationTransform.rotation;
		upgradeNameText.text = containedItem.itemNameLocalized;
		upgradeRotationBouncer.RequestBounce();
		currentlyRotatedUpgrade.transform.SetParent(upgradeRotationTransform, worldPositionStays: true);
		currentlyRotatedUpgrade.transform.localScale = Vector3.one;
	}
}
