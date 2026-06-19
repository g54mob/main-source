using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StorageChestGUIController : MonoBehaviour
{
	public GameObject itemHolderBoxPrefab;

	public CursorUpdateArea roomUpdateAreaRef;

	public CursorUpdateArea storageUpdateAreaRef;

	public GameObject trashItemButton;

	public RectTransform roomItemListTransform;

	public RectTransform roomItemSliderAreaTransform;

	public RectTransform storageItemListTransform;

	public RectTransform storageItemSliderAreaTransform;

	public TextMeshProUGUI itemNameText;

	public Image selectedItemIconHolder;

	public InchwormBounce itemRotationBouncer;

	public GameObject storeButton;

	public GameObject storeAllButton;

	public GameObject removeButton;

	public GameObject removeAllButton;

	public GameObject numberSelectionPopup;

	public TextMeshProUGUI numberSelectionPopupLabel;

	public TextMeshProUGUI numberSelectionPopupTotalOwned;

	public TextMeshProUGUI numberSelectionPopupCurrentValue;

	public CoreSliderUnityGUI numberSelectionPopupSlider;

	public CoreButtonUnityGUI numberSelectionPopupOkayButton;

	public GameObject loadingDogText;

	public TextMeshProUGUI dogNameText;

	public Transform dogRotationTransform;

	public InchwormBounce dogRotationBouncer;

	public ObjectRotationArea dogRotationArea;

	private int currentSelectionNumber;

	private int currentSelectionMax;

	private StorageBox currentlySelectedBox;

	private List<GameObject> inWorldObjects = new List<GameObject>();

	private List<InventoryItem> inWorldInventoryItemKeys = new List<InventoryItem>();

	private Dictionary<InventoryItem, List<GameObject>> inWorldInventoryItems = new Dictionary<InventoryItem, List<GameObject>>();

	private int elementsPerRow = 3;

	private float finalOffset = 10f;

	private float initialOffset = -5f;

	private float verticalOffset = 50f;

	private float horizontalOffset = 50f;

	private bool isLoadingDog;

	private bool needsDogRefresh;

	private GameObject currentlyRotatedDog;

	private bool GUIClosed;

	private string windowOpenSound = "incubator_window_open";

	private string windowCloseSound = "incubator_window_close";

	private string trashItemSound = "chest_trash";

	private string storeItemSound = "chest_store";

	private string storeAllItemsSound = "chest_storeAll";

	private string removeItemSound = "chest_remove";

	private string removeAllItemsSound = "chest_removeAll";

	private string showAmountPopupSound = "chest_amountPopup";

	private string sliderTickSound = "chest_slider_tick";

	private List<GameObject> allRoomItemBoxes = new List<GameObject>();

	private List<GameObject> allStorageItemBoxes = new List<GameObject>();

	private InventoryManager invRef;

	private ObjectRegistration regRef;

	private DogRegistration dogRegRef;

	private StorageChest storageChestRef;

	private GUIManagerPens guiManagerRef;

	private void Awake()
	{
		regRef = ObjectRegistration.GetRegistrationScript();
		guiManagerRef = regRef.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		invRef = regRef.GetGlobalComponent<InventoryManager>(GlobalObject.INVENTORY_MANAGER);
		dogRegRef = regRef.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		guiManagerRef.DisableBG(LockReason.STORAGE_CHEST);
		guiManagerRef.RegisterNewPopup(LockReason.STORAGE_CHEST, stomp: true, CloseGUI);
		numberSelectionPopup.SetActive(value: false);
		AudioController.Play(windowOpenSound);
	}

	private void Start()
	{
		StoreObjectRefs();
		CreateBoxes();
	}

	private void StoreObjectRefs()
	{
		inWorldObjects = regRef.GetAllObjectsForTag(TagsEnum.ALL);
		for (int num = inWorldObjects.Count - 1; num >= 0; num--)
		{
			if (inWorldObjects[num].CompareTag(Tags.COCOON) || inWorldObjects[num].CompareTag(Tags.DOG))
			{
				inWorldObjects.RemoveAt(num);
				continue;
			}
			if (inWorldObjects[num].CompareTag(Tags.FOOD))
			{
				RegisterTaggedObject component = inWorldObjects[num].GetComponent<RegisterTaggedObject>();
				if (component != null && (!component.canSaveLoad || component.saveAsAlternativeItem != null))
				{
					inWorldObjects.RemoveAt(num);
					continue;
				}
			}
			ObjectID component2 = inWorldObjects[num].GetComponent<ObjectID>();
			if (component2 == null)
			{
				inWorldObjects.RemoveAt(num);
			}
			else if ((!inWorldObjects[num].CompareTag(Tags.FOOD) || !(inWorldObjects[num].GetComponent<CrackedDogCore>() != null)) && (inWorldObjects[num].CompareTag(Tags.TOY) || inWorldObjects[num].CompareTag(Tags.CAPSULE) || inWorldObjects[num].CompareTag(Tags.FOOD) || inWorldObjects[num].CompareTag(Tags.DIRT_CLUMP) || inWorldObjects[num].CompareTag(Tags.SNOWBALL) || inWorldObjects[num].CompareTag(Tags.EGG) || inWorldObjects[num].CompareTag(Tags.POOP) || inWorldObjects[num].CompareTag(Tags.SEED_PACKET) || inWorldObjects[num].CompareTag(Tags.DEN_UPGRADE) || inWorldObjects[num].CompareTag(Tags.VACUUM) || inWorldObjects[num].CompareTag(Tags.GIFT)))
			{
				if (!inWorldInventoryItems.ContainsKey(component2.item))
				{
					inWorldInventoryItemKeys.Add(component2.item);
					inWorldInventoryItems[component2.item] = new List<GameObject>();
				}
				inWorldInventoryItems[component2.item].Add(inWorldObjects[num]);
				inWorldObjects.RemoveAt(num);
			}
		}
	}

	private void Update()
	{
		if (GameControls.actions.CloseMenu.WasPressed)
		{
			if (numberSelectionPopup.activeSelf)
			{
				OnCloseNumberSelectionPopupButtonPressed();
			}
			else
			{
				CloseGUI();
			}
		}
	}

	private void OnDestroy()
	{
		GUIClosed = true;
	}

	public void CloseGUI()
	{
		GUIClosed = true;
		guiManagerRef.EnableBG(LockReason.STORAGE_CHEST);
		guiManagerRef.ClearPopupRegistration(LockReason.STORAGE_CHEST);
		storageChestRef.SpawnQueuedObjects();
		Object.Destroy(base.gameObject);
		AudioController.Play(windowCloseSound);
	}

	public void SetStorageRef(StorageChest newRef)
	{
		storageChestRef = newRef;
	}

	public void OnCloseNumberSelectionPopupButtonPressed()
	{
		numberSelectionPopup.SetActive(value: false);
	}

	public void OnCurrentSelectionNumberFinalized()
	{
		int num = currentSelectionNumber;
		currentSelectionNumber = Mathf.RoundToInt(numberSelectionPopupSlider.value * ((float)currentSelectionMax - 1f));
		currentSelectionNumber++;
		if (currentSelectionNumber != num)
		{
			AudioController.Play(sliderTickSound);
		}
		numberSelectionPopupCurrentValue.text = currentSelectionNumber.ToString();
	}

	public void OnIncrementSelectionNumberPressed()
	{
		if (currentSelectionNumber < currentSelectionMax)
		{
			currentSelectionNumber++;
			numberSelectionPopupCurrentValue.text = currentSelectionNumber.ToString();
			AudioController.Play(sliderTickSound);
			numberSelectionPopupSlider.SetValueWithoutNotify(((float)currentSelectionNumber - 1f) / ((float)currentSelectionMax - 1f));
		}
	}

	public void OnDecrementSelectionNumberPressed()
	{
		if (currentSelectionNumber > 1)
		{
			currentSelectionNumber--;
			numberSelectionPopupCurrentValue.text = currentSelectionNumber.ToString();
			AudioController.Play(sliderTickSound);
			numberSelectionPopupSlider.SetValueWithoutNotify(((float)currentSelectionNumber - 1f) / ((float)currentSelectionMax - 1f));
		}
	}

	public void OnTrashItemPressed()
	{
		currentSelectionMax = currentlySelectedBox.GetNumberOfContainedItems();
		currentSelectionNumber = currentSelectionMax;
		if (currentSelectionMax == 1)
		{
			OnConfirmTrashItemPressed();
			return;
		}
		numberSelectionPopup.SetActive(value: true);
		AudioController.Play(showAmountPopupSound);
		numberSelectionPopupLabel.text = ScriptLocalization.GUI.GUI_CHEST_HOWMANY_TRASH;
		numberSelectionPopupSlider.SetValueWithoutNotify(1f);
		numberSelectionPopupCurrentValue.text = currentSelectionNumber.ToString();
		numberSelectionPopupTotalOwned.text = currentSelectionMax.ToString();
		numberSelectionPopupOkayButton.onClick.RemoveAllListeners();
		numberSelectionPopupOkayButton.onClick.AddListener(delegate
		{
			OnConfirmTrashItemPressed();
		});
	}

	public void OnConfirmTrashItemPressed()
	{
		numberSelectionPopup.SetActive(value: false);
		bool isInQueue = currentlySelectedBox.GetIsInQueue();
		bool isStorageBox = currentlySelectedBox.GetIsStorageBox();
		InventoryItem containedInventoryItem = currentlySelectedBox.GetContainedInventoryItem();
		SaveableTaggedObjectNoDepth containedSavedObject = currentlySelectedBox.GetContainedSavedObject();
		if (isStorageBox)
		{
			if (containedInventoryItem != null)
			{
				storageChestRef.RemoveItem(containedInventoryItem, currentSelectionNumber);
			}
			else if (containedSavedObject != null)
			{
				storageChestRef.RemoveObject(containedSavedObject);
			}
		}
		else if (isInQueue)
		{
			if (containedInventoryItem != null)
			{
				storageChestRef.RemoveInventoryItemFromQueue(containedInventoryItem, currentSelectionNumber);
			}
			else if (containedSavedObject != null)
			{
				storageChestRef.RemoveSavedObjectFromQueue(containedSavedObject);
			}
		}
		else
		{
			GameObject containedObject = currentlySelectedBox.GetContainedObject();
			if (containedObject != null)
			{
				RegisterTaggedObject component = containedObject.GetComponent<RegisterTaggedObject>();
				if (component != null)
				{
					component.SetSafeDestroy();
				}
				inWorldObjects.Remove(containedObject);
				Object.Destroy(containedObject);
			}
			else
			{
				List<GameObject> allContainedItems = currentlySelectedBox.GetAllContainedItems();
				for (int num = allContainedItems.Count - 1; num >= currentSelectionMax - currentSelectionNumber; num--)
				{
					RegisterTaggedObject component2 = allContainedItems[num].GetComponent<RegisterTaggedObject>();
					if (component2 != null)
					{
						component2.SetSafeDestroy();
					}
					inWorldInventoryItems[containedInventoryItem].Remove(allContainedItems[num]);
					Object.Destroy(allContainedItems[num]);
				}
				if (inWorldInventoryItems[containedInventoryItem].Count == 0)
				{
					inWorldInventoryItems.Remove(containedInventoryItem);
					inWorldInventoryItemKeys.Remove(containedInventoryItem);
				}
			}
		}
		AudioController.Play(trashItemSound);
		RefreshBoxes();
	}

	public void OnStoreItemPressed()
	{
		currentSelectionMax = currentlySelectedBox.GetNumberOfContainedItems();
		currentSelectionNumber = currentSelectionMax;
		if (currentSelectionMax == 1)
		{
			OnConfirmStoreItemPressed();
			return;
		}
		numberSelectionPopup.SetActive(value: true);
		AudioController.Play(showAmountPopupSound);
		numberSelectionPopupLabel.text = ScriptLocalization.GUI.GUI_CHEST_HOWMANY_STORE;
		numberSelectionPopupSlider.SetValueWithoutNotify(1f);
		numberSelectionPopupCurrentValue.text = currentSelectionNumber.ToString();
		numberSelectionPopupTotalOwned.text = currentSelectionMax.ToString();
		numberSelectionPopupOkayButton.onClick.RemoveAllListeners();
		numberSelectionPopupOkayButton.onClick.AddListener(delegate
		{
			OnConfirmStoreItemPressed();
		});
	}

	public void OnConfirmStoreItemPressed(bool refresh = true)
	{
		numberSelectionPopup.SetActive(value: false);
		bool isInQueue = currentlySelectedBox.GetIsInQueue();
		GameObject containedObject = currentlySelectedBox.GetContainedObject();
		InventoryItem containedInventoryItem = currentlySelectedBox.GetContainedInventoryItem();
		SaveableTaggedObjectNoDepth containedSavedObject = currentlySelectedBox.GetContainedSavedObject();
		if (containedInventoryItem != null)
		{
			if (!isInQueue)
			{
				List<GameObject> allContainedItems = currentlySelectedBox.GetAllContainedItems();
				storageChestRef.AddItem(containedInventoryItem, currentSelectionNumber);
				for (int i = 0; i < currentSelectionNumber; i++)
				{
					RegisterTaggedObject component = allContainedItems[i].GetComponent<RegisterTaggedObject>();
					if (component != null)
					{
						component.SetSafeDestroy();
					}
					inWorldInventoryItems[containedInventoryItem].Remove(allContainedItems[i]);
					Object.Destroy(allContainedItems[i]);
				}
				if (inWorldInventoryItems[containedInventoryItem].Count == 0)
				{
					inWorldInventoryItems.Remove(containedInventoryItem);
					inWorldInventoryItemKeys.Remove(containedInventoryItem);
				}
			}
			else
			{
				storageChestRef.AddItem(containedInventoryItem, currentSelectionNumber);
				storageChestRef.RemoveInventoryItemFromQueue(containedInventoryItem, currentSelectionNumber);
			}
		}
		else if (!isInQueue && containedObject != null)
		{
			SaveableTaggedObjectNoDepth saveableTaggedObjectForObject = regRef.GetSaveableTaggedObjectForObject(invRef, currentlySelectedBox.GetContainedObject(), saveGameObjectInfo: false);
			RegisterTaggedObject component2 = containedObject.GetComponent<RegisterTaggedObject>();
			if (component2 != null)
			{
				component2.SetSafeDestroy();
			}
			storageChestRef.AddObject(saveableTaggedObjectForObject);
			inWorldObjects.Remove(containedObject);
			Object.Destroy(containedObject);
		}
		else if (containedSavedObject != null)
		{
			if (isInQueue)
			{
				storageChestRef.AddObject(containedSavedObject);
				storageChestRef.RemoveSavedObjectFromQueue(containedSavedObject);
			}
			else
			{
				GameObject objectForUID = regRef.GetObjectForUID(containedSavedObject.objID);
				RegisterTaggedObject component3 = objectForUID.GetComponent<RegisterTaggedObject>();
				if (component3 != null)
				{
					component3.SetSafeDestroy();
				}
				storageChestRef.AddObject(containedSavedObject);
				inWorldObjects.Remove(objectForUID);
				Object.Destroy(objectForUID);
			}
		}
		if (refresh)
		{
			AudioController.Play(storeItemSound);
			RefreshBoxes();
		}
	}

	public void OnStoreAllPressed()
	{
		for (int num = allRoomItemBoxes.Count - 1; num >= 0; num--)
		{
			currentlySelectedBox = allRoomItemBoxes[num].GetComponent<StorageBox>();
			currentSelectionNumber = currentlySelectedBox.GetNumberOfContainedItems();
			OnConfirmStoreItemPressed(refresh: false);
		}
		AudioController.Play(storeAllItemsSound);
		RefreshBoxes();
	}

	public void OnRemoveAllPressed()
	{
		List<InventoryItem> allContainedItemKeys = storageChestRef.GetAllContainedItemKeys();
		for (int num = allContainedItemKeys.Count - 1; num >= 0; num--)
		{
			InventoryItem itemRef = allContainedItemKeys[num];
			int numberOfItemStored = storageChestRef.GetNumberOfItemStored(itemRef);
			storageChestRef.AddInventoryItemToQueue(itemRef, numberOfItemStored);
			storageChestRef.RemoveItem(itemRef, numberOfItemStored);
		}
		List<SaveableTaggedObjectNoDepth> allContainedObjects = storageChestRef.GetAllContainedObjects();
		for (int num2 = allContainedObjects.Count - 1; num2 >= 0; num2--)
		{
			storageChestRef.AddSavedObjectToQueue(allContainedObjects[num2]);
			storageChestRef.RemoveObject(allContainedObjects[num2]);
		}
		AudioController.Play(removeAllItemsSound);
		RefreshBoxes();
	}

	public void OnRemoveItemPressed()
	{
		currentSelectionMax = currentlySelectedBox.GetNumberOfContainedItems();
		currentSelectionNumber = currentSelectionMax;
		if (currentSelectionMax == 1)
		{
			OnConfirmRemoveItemPressed();
			return;
		}
		numberSelectionPopup.SetActive(value: true);
		AudioController.Play(showAmountPopupSound);
		numberSelectionPopupLabel.text = ScriptLocalization.GUI.GUI_CHEST_HOWMANY_REMOVE;
		numberSelectionPopupSlider.SetValueWithoutNotify(1f);
		numberSelectionPopupCurrentValue.text = currentSelectionNumber.ToString();
		numberSelectionPopupTotalOwned.text = currentSelectionMax.ToString();
		numberSelectionPopupOkayButton.onClick.RemoveAllListeners();
		numberSelectionPopupOkayButton.onClick.AddListener(delegate
		{
			OnConfirmRemoveItemPressed();
		});
	}

	public void OnConfirmRemoveItemPressed()
	{
		numberSelectionPopup.SetActive(value: false);
		InventoryItem containedInventoryItem = currentlySelectedBox.GetContainedInventoryItem();
		SaveableTaggedObjectNoDepth containedSavedObject = currentlySelectedBox.GetContainedSavedObject();
		if (containedInventoryItem != null)
		{
			storageChestRef.RemoveItem(containedInventoryItem, currentSelectionNumber);
			storageChestRef.AddInventoryItemToQueue(containedInventoryItem, currentSelectionNumber);
		}
		else if (containedSavedObject != null)
		{
			storageChestRef.RemoveObject(containedSavedObject);
			storageChestRef.AddSavedObjectToQueue(containedSavedObject);
		}
		AudioController.Play(removeItemSound);
		RefreshBoxes();
	}

	public void SelectBox(StorageBox newBox)
	{
		if (currentlySelectedBox == null)
		{
			trashItemButton.SetActive(value: false);
		}
		else
		{
			trashItemButton.SetActive(value: true);
		}
		if (!(currentlySelectedBox == newBox) || !(currentlySelectedBox != null))
		{
			if (currentlyRotatedDog != null)
			{
				Object.Destroy(currentlyRotatedDog);
				currentlyRotatedDog = null;
			}
			if (currentlySelectedBox != null)
			{
				currentlySelectedBox.OnDeselected();
			}
			if (newBox != null)
			{
				newBox.OnSelected();
			}
			currentlySelectedBox = newBox;
			if (newBox == null)
			{
				storeButton.SetActive(value: false);
				removeButton.SetActive(value: false);
			}
			else if (newBox.GetIsStorageBox())
			{
				storeButton.SetActive(value: false);
				removeButton.SetActive(value: true);
			}
			else
			{
				storeButton.SetActive(value: true);
				removeButton.SetActive(value: false);
			}
			if (allRoomItemBoxes.Count > 0)
			{
				storeAllButton.SetActive(value: true);
			}
			else
			{
				storeAllButton.SetActive(value: false);
			}
			if (allStorageItemBoxes.Count > 0)
			{
				removeAllButton.SetActive(value: true);
			}
			else
			{
				removeAllButton.SetActive(value: false);
			}
			UpdateDisplay();
		}
	}

	private void RefreshBoxes()
	{
		int lastIndex = 0;
		bool lastBoxWasStorage = false;
		if (currentlySelectedBox != null)
		{
			lastIndex = currentlySelectedBox.GetIndex();
			lastBoxWasStorage = currentlySelectedBox.GetIsStorageBox();
		}
		for (int num = allRoomItemBoxes.Count - 1; num >= 0; num--)
		{
			Object.Destroy(allRoomItemBoxes[num]);
		}
		for (int num2 = allStorageItemBoxes.Count - 1; num2 >= 0; num2--)
		{
			Object.Destroy(allStorageItemBoxes[num2]);
		}
		loadingDogText.SetActive(value: false);
		selectedItemIconHolder.gameObject.SetActive(value: false);
		allRoomItemBoxes.Clear();
		allStorageItemBoxes.Clear();
		CreateBoxes(lastBoxWasStorage, lastIndex);
	}

	private void CreateBoxes(bool lastBoxWasStorage = true, int lastIndex = 0)
	{
		int num = 0;
		List<InventoryItem> allContainedItemKeys = storageChestRef.GetAllContainedItemKeys();
		Dictionary<InventoryItem, int> allContainedItems = storageChestRef.GetAllContainedItems();
		for (int i = 0; i < allContainedItemKeys.Count; i++)
		{
			GameObject gameObject = Object.Instantiate(itemHolderBoxPrefab, storageItemListTransform);
			StorageBox component = gameObject.GetComponent<StorageBox>();
			component.SetControllerRef(this, storageUpdateAreaRef, isStorageBox: true);
			component.SetContainedItem(allContainedItemKeys[i], allContainedItems[allContainedItemKeys[i]], num, inQueue: false);
			PositionNewStoredBox(gameObject);
			num++;
		}
		List<SaveableTaggedObjectNoDepth> allContainedObjects = storageChestRef.GetAllContainedObjects();
		for (int j = 0; j < allContainedObjects.Count; j++)
		{
			GameObject gameObject2 = Object.Instantiate(itemHolderBoxPrefab, storageItemListTransform);
			InventoryItem itemForPath = invRef.GetItemForPath(allContainedObjects[j].itemPath);
			string objName = itemForPath.itemNameLocalized;
			if (allContainedObjects[j].crackedCore != null)
			{
				objName = ObjectIndicatorController.GetReadableCrackedCoreQuality(allContainedObjects[j].crackedCore.quality);
			}
			StorageBox component2 = gameObject2.GetComponent<StorageBox>();
			component2.SetControllerRef(this, storageUpdateAreaRef, isStorageBox: true);
			component2.SetContainedItem(allContainedObjects[j], 1, num, itemForPath.icon, objName, inQueue: false);
			PositionNewStoredBox(gameObject2);
			num++;
		}
		List<SaveableTaggedObjectNoDepth> list = storageChestRef.GetinWorldQueueObjects();
		List<InventoryItem> list2 = storageChestRef.GetinWorldQueueInventoryItemKeys();
		num = 0;
		for (int k = 0; k < list2.Count; k++)
		{
			GameObject gameObject3 = Object.Instantiate(itemHolderBoxPrefab, roomItemListTransform);
			StorageBox component3 = gameObject3.GetComponent<StorageBox>();
			component3.SetControllerRef(this, roomUpdateAreaRef, isStorageBox: false);
			component3.SetContainedItem(list2[k], storageChestRef.GetNumberOfHeldInventoryItemsOfType(list2[k]), num, inQueue: true);
			PositionNewRoomBox(gameObject3);
			num++;
		}
		for (int l = 0; l < list.Count; l++)
		{
			GameObject gameObject4 = Object.Instantiate(itemHolderBoxPrefab, roomItemListTransform);
			InventoryItem itemForPath2 = invRef.GetItemForPath(list[l].itemPath);
			string objName2 = itemForPath2.itemNameLocalized;
			if (list[l].crackedCore != null)
			{
				objName2 = ObjectIndicatorController.GetReadableCrackedCoreQuality(list[l].crackedCore.quality);
			}
			StorageBox component4 = gameObject4.GetComponent<StorageBox>();
			component4.SetControllerRef(this, roomUpdateAreaRef, isStorageBox: false);
			component4.SetContainedItem(list[l], 1, num, itemForPath2.icon, objName2, inQueue: true);
			PositionNewRoomBox(gameObject4);
			num++;
		}
		for (int m = 0; m < inWorldInventoryItemKeys.Count; m++)
		{
			GameObject gameObject5 = Object.Instantiate(itemHolderBoxPrefab, roomItemListTransform);
			StorageBox component5 = gameObject5.GetComponent<StorageBox>();
			component5.SetControllerRef(this, roomUpdateAreaRef, isStorageBox: false);
			component5.SetContainedItem(inWorldInventoryItemKeys[m], inWorldInventoryItems[inWorldInventoryItemKeys[m]], num, inQueue: false);
			PositionNewRoomBox(gameObject5);
			num++;
		}
		for (int n = 0; n < inWorldObjects.Count; n++)
		{
			ObjectID component6 = inWorldObjects[n].GetComponent<ObjectID>();
			if (component6 == null)
			{
				continue;
			}
			GameObject gameObject6 = Object.Instantiate(itemHolderBoxPrefab, roomItemListTransform);
			StorageBox component7 = gameObject6.GetComponent<StorageBox>();
			component7.SetControllerRef(this, roomUpdateAreaRef, isStorageBox: false);
			bool flag = false;
			if (inWorldObjects[n].CompareTag(Tags.FOOD) && inWorldObjects[n].GetComponent<CrackedDogCore>() != null)
			{
				flag = true;
			}
			if (inWorldObjects[n].CompareTag(Tags.DOG_CORE) || flag)
			{
				SaveableTaggedObjectNoDepth saveableTaggedObjectForObject = regRef.GetSaveableTaggedObjectForObject(invRef, inWorldObjects[n], saveGameObjectInfo: false);
				InventoryItem itemForPath3 = invRef.GetItemForPath(saveableTaggedObjectForObject.itemPath);
				string objName3 = itemForPath3.itemNameLocalized;
				if (flag)
				{
					objName3 = ObjectIndicatorController.GetReadableCrackedCoreQuality(inWorldObjects[n].GetComponent<CrackedDogCore>().GetCoreQuality());
				}
				component7.SetContainedItem(saveableTaggedObjectForObject, 1, num, itemForPath3.icon, objName3, inQueue: false);
			}
			else
			{
				component7.SetContainedItem(component6, 1, num, inQueue: false);
			}
			PositionNewRoomBox(gameObject6);
			num++;
		}
		if (allStorageItemBoxes.Count == 0)
		{
			storageItemSliderAreaTransform.sizeDelta = new Vector2(0f, verticalOffset + finalOffset);
			storageItemListTransform.anchoredPosition3D = new Vector3(storageItemListTransform.anchoredPosition3D.x, initialOffset + finalOffset / 2f, 0f);
		}
		if (allRoomItemBoxes.Count == 0)
		{
			roomItemSliderAreaTransform.sizeDelta = new Vector2(0f, verticalOffset + finalOffset);
			roomItemListTransform.anchoredPosition3D = new Vector3(roomItemListTransform.anchoredPosition3D.x, initialOffset + finalOffset / 2f, 0f);
		}
		SelectBox(null);
		if (lastBoxWasStorage)
		{
			if (allStorageItemBoxes.Count > 0)
			{
				int index = ((allStorageItemBoxes.Count <= lastIndex) ? (allStorageItemBoxes.Count - 1) : lastIndex);
				SelectBox(allStorageItemBoxes[index].GetComponent<StorageBox>());
			}
			else if (allRoomItemBoxes.Count > 0)
			{
				SelectBox(allRoomItemBoxes[0].GetComponent<StorageBox>());
			}
		}
		else if (allRoomItemBoxes.Count > 0)
		{
			int index2 = ((allRoomItemBoxes.Count <= lastIndex) ? (allRoomItemBoxes.Count - 1) : lastIndex);
			SelectBox(allRoomItemBoxes[index2].GetComponent<StorageBox>());
		}
		else if (allStorageItemBoxes.Count > 0)
		{
			SelectBox(allStorageItemBoxes[0].GetComponent<StorageBox>());
		}
	}

	private void PositionNewStoredBox(GameObject obj)
	{
		int count = allStorageItemBoxes.Count;
		int num = count % elementsPerRow;
		int num2 = Mathf.FloorToInt(count / elementsPerRow);
		obj.transform.localPosition = Vector3.right * horizontalOffset * num + Vector3.down * verticalOffset * num2;
		float num3 = (float)(num2 + 1) * verticalOffset;
		float num4 = (float)num2 * verticalOffset;
		storageItemSliderAreaTransform.sizeDelta = new Vector2(0f, num3 + finalOffset);
		storageItemListTransform.anchoredPosition3D = new Vector3(storageItemListTransform.anchoredPosition3D.x, initialOffset + (num4 + finalOffset) / 2f, 0f);
		allStorageItemBoxes.Add(obj);
	}

	private void PositionNewRoomBox(GameObject obj)
	{
		int count = allRoomItemBoxes.Count;
		int num = count % elementsPerRow;
		int num2 = Mathf.FloorToInt(count / elementsPerRow);
		obj.transform.localPosition = Vector3.right * horizontalOffset * num + Vector3.down * verticalOffset * num2;
		float num3 = (float)(num2 + 1) * verticalOffset;
		float num4 = (float)num2 * verticalOffset;
		roomItemSliderAreaTransform.sizeDelta = new Vector2(0f, num3 + finalOffset);
		roomItemListTransform.anchoredPosition3D = new Vector3(roomItemListTransform.anchoredPosition3D.x, initialOffset + (num4 + finalOffset) / 2f, 0f);
		allRoomItemBoxes.Add(obj);
	}

	private void UpdateDisplay()
	{
		loadingDogText.SetActive(value: false);
		dogRotationBouncer.gameObject.SetActive(value: false);
		dogRotationArea.SetMouseInputAllowed(val: false);
		if (currentlySelectedBox == null)
		{
			dogNameText.text = "";
			itemNameText.text = "";
			trashItemButton.SetActive(value: false);
			selectedItemIconHolder.gameObject.SetActive(value: false);
			return;
		}
		trashItemButton.SetActive(value: true);
		selectedItemIconHolder.gameObject.SetActive(value: true);
		itemNameText.text = currentlySelectedBox.GetContainedName();
		selectedItemIconHolder.sprite = currentlySelectedBox.GetContainedIcon();
		SaveableTaggedObjectNoDepth containedSavedObject = currentlySelectedBox.GetContainedSavedObject();
		if (containedSavedObject != null && containedSavedObject.core != null)
		{
			CreateRotationDog(containedSavedObject.core);
			dogNameText.text = containedSavedObject.core.dogName;
			dogRotationArea.SetMouseInputAllowed(val: true);
			dogRotationBouncer.gameObject.SetActive(value: true);
			selectedItemIconHolder.gameObject.SetActive(value: false);
		}
		else
		{
			dogNameText.text = "";
		}
		itemRotationBouncer.RequestBounce();
	}

	private void CreateRotationDog(SaveableDogCore sc)
	{
		if (isLoadingDog)
		{
			needsDogRefresh = true;
			return;
		}
		isLoadingDog = true;
		loadingDogText.SetActive(value: true);
		dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, sc.dogGene, null, manualDog: false, dogProfile: sc.dogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: sc.dogAge, customDogAgeProgress: 0f);
	}

	private void CreateRotationDog(DogCore ac)
	{
		if (isLoadingDog)
		{
			needsDogRefresh = true;
			return;
		}
		isLoadingDog = true;
		loadingDogText.SetActive(value: true);
		dogRegRef.RequestNewDog(dogRotationTransform.position, dogRotationTransform.rotation, ac.dogGene, null, manualDog: false, dogProfile: ac.dogProfile, callback: OnNewDogCreated, playerOwned: false, useBaseGeneWithoutMutation: false, timeslice: true, forceCacheThumbnails: false, dummyDog: false, customDogAge: ac.dogAge, customDogAgeProgress: 0f);
	}

	private void OnNewDogCreated(GameObject dog)
	{
		if (GUIClosed)
		{
			Object.Destroy(dog);
			return;
		}
		isLoadingDog = false;
		if (needsDogRefresh || currentlySelectedBox == null)
		{
			Object.Destroy(dog);
			needsDogRefresh = false;
			if (currentlySelectedBox != null)
			{
				SaveableTaggedObjectNoDepth containedSavedObject = currentlySelectedBox.GetContainedSavedObject();
				if (containedSavedObject != null && containedSavedObject.core != null)
				{
					CreateRotationDog(containedSavedObject.core);
				}
			}
			else
			{
				loadingDogText.SetActive(value: false);
			}
		}
		else
		{
			currentlyRotatedDog = dog;
			loadingDogText.SetActive(value: false);
			dogRotationBouncer.RequestBounce();
			dogRegRef.MakeDogSuitableForUIDisplay(dog);
			dog.transform.SetParent(dogRotationTransform, worldPositionStays: true);
		}
	}
}
