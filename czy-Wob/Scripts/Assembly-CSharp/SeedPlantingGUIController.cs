using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SeedPlantingGUIController : MonoBehaviour
{
	public GameObject seedsHolderBoxPrefab;

	public CursorUpdateArea updateAreaRef;

	public GameObject noSeedsText;

	public GameObject trashSeedButton;

	public RectTransform sliderAreaTransform;

	public RectTransform seedsListTransform;

	public TextMeshProUGUI seedNameText;

	public Transform seedRotationTransform;

	public InchwormBounce seedRotationBouncer;

	public GameObject plantButtonRef;

	private Hole holeRef;

	private SeedBox currentlySelectedBox;

	private GameObject currentlyRotatedSeedPacket;

	private string windowOpenSound = "incubator_window_open";

	private string windowCloseSound = "incubator_window_close";

	private int elementsPerRow = 3;

	private float finalOffset = 10f;

	private float initialOffset = -5f;

	private float verticalOffset = 50f;

	private float horizontalOffset = 50f;

	private List<GameObject> allSeeds = new List<GameObject>();

	private GUIManagerPens guiManagerRef;

	private PlayerInventory inventoryRef;

	private void Awake()
	{
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = registrationScript.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		inventoryRef = registrationScript.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER).playerInventory;
		guiManagerRef.DisableBG(LockReason.SEED_GUI);
		guiManagerRef.RegisterNewPopup(LockReason.SEED_GUI, stomp: true, CloseGUI);
		CreateBoxes();
		AudioController.Play(windowOpenSound);
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			CloseGUI();
		}
	}

	public void SetHoleRef(Hole newRef)
	{
		holeRef = newRef;
	}

	public void CloseGUI()
	{
		guiManagerRef.EnableBG(LockReason.SEED_GUI);
		guiManagerRef.ClearPopupRegistration(LockReason.SEED_GUI);
		Object.Destroy(base.gameObject);
		AudioController.Play(windowCloseSound);
	}

	public void OnPlantButtonPressed()
	{
		if (currentlySelectedBox == null)
		{
			CloseGUI();
			Debug.LogError("Attempting to plant a seed without a selected box.");
			return;
		}
		InventoryItem containedItem = currentlySelectedBox.GetContainedItem();
		if (containedItem == null)
		{
			CloseGUI();
			Debug.LogError("Attempting to plant a seed that doesn't exit.");
			return;
		}
		inventoryRef.RemoveObjectFromInventory(containedItem);
		RefreshBoxes();
		holeRef.PlantSeed(containedItem);
		CloseGUI();
	}

	public void SelectBox(SeedBox newBox)
	{
		if (!(currentlySelectedBox == newBox))
		{
			if (currentlyRotatedSeedPacket != null)
			{
				Object.Destroy(currentlyRotatedSeedPacket);
				currentlyRotatedSeedPacket = null;
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

	public void OnTrashSeedPacketButtonPressed()
	{
		InventoryItem containedItem = currentlySelectedBox.GetContainedItem();
		if (containedItem != null)
		{
			inventoryRef.RemoveObjectFromInventory(containedItem);
			RefreshBoxes();
		}
	}

	public void OnConfirmTrashSeedPacket()
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
		for (int num = allSeeds.Count - 1; num >= 0; num--)
		{
			Object.Destroy(allSeeds[num]);
		}
		if (currentlyRotatedSeedPacket != null)
		{
			Object.Destroy(currentlyRotatedSeedPacket);
			currentlyRotatedSeedPacket = null;
		}
		allSeeds.Clear();
		CreateBoxes();
	}

	private void CreateBoxes()
	{
		Dictionary<InventoryItem, int> heldItemsOfType = inventoryRef.GetHeldItemsOfType(ItemType.SEED_PACKET);
		List<InventoryItem> list = new List<InventoryItem>();
		list.AddRange(heldItemsOfType.Keys);
		for (int i = 0; i < list.Count; i++)
		{
			GameObject gameObject = Object.Instantiate(seedsHolderBoxPrefab, seedsListTransform);
			SeedBox component = gameObject.GetComponent<SeedBox>();
			component.SetControllerRef(this, updateAreaRef);
			component.SetContainedItem(list[i], heldItemsOfType[list[i]]);
			PositionNewBox(gameObject);
		}
		if (allSeeds.Count == 0)
		{
			sliderAreaTransform.sizeDelta = new Vector2(0f, verticalOffset + finalOffset);
			seedsListTransform.anchoredPosition3D = new Vector3(seedsListTransform.anchoredPosition3D.x, initialOffset + finalOffset / 2f, 0f);
			seedNameText.text = "";
			noSeedsText.SetActive(value: true);
			plantButtonRef.SetActive(value: false);
			trashSeedButton.SetActive(value: false);
		}
		else
		{
			noSeedsText.SetActive(value: false);
			plantButtonRef.SetActive(value: true);
			if (TutorialController.IsTutorialActive())
			{
				trashSeedButton.SetActive(value: false);
			}
			else
			{
				trashSeedButton.SetActive(value: true);
			}
			SelectBox(allSeeds[0].GetComponent<SeedBox>());
		}
	}

	private void PositionNewBox(GameObject obj)
	{
		int count = allSeeds.Count;
		int num = count % elementsPerRow;
		int num2 = Mathf.FloorToInt(count / elementsPerRow);
		obj.transform.localPosition = Vector3.right * horizontalOffset * num + Vector3.down * verticalOffset * num2;
		float num3 = (float)(num2 + 1) * verticalOffset;
		float num4 = (float)num2 * verticalOffset;
		sliderAreaTransform.sizeDelta = new Vector2(0f, num3 + finalOffset);
		seedsListTransform.anchoredPosition3D = new Vector3(seedsListTransform.anchoredPosition3D.x, initialOffset + (num4 + finalOffset) / 2f, 0f);
		allSeeds.Add(obj);
	}

	private void UpdateDisplay()
	{
		if (currentlySelectedBox == null)
		{
			seedNameText.text = "";
			return;
		}
		InventoryItem containedItem = currentlySelectedBox.GetContainedItem();
		currentlyRotatedSeedPacket = Object.Instantiate(containedItem.itemPrefab);
		currentlyRotatedSeedPacket.transform.position = seedRotationTransform.position;
		currentlyRotatedSeedPacket.transform.rotation = seedRotationTransform.rotation;
		Object.Destroy(currentlyRotatedSeedPacket.GetComponent<Rigidbody>());
		Object.Destroy(currentlyRotatedSeedPacket.GetComponent<SeedPacket>());
		Object.Destroy(currentlyRotatedSeedPacket.GetComponent<InteractableBase>());
		Object.Destroy(currentlyRotatedSeedPacket.GetComponent<RegisterTaggedObject>());
		seedNameText.text = containedItem.itemNameLocalized;
		seedRotationBouncer.RequestBounce();
		currentlyRotatedSeedPacket.transform.SetParent(seedRotationTransform, worldPositionStays: true);
	}
}
