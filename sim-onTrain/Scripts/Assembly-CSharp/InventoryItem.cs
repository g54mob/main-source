using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField]
	private GameObject countRect;

	[SerializeField]
	private Image itemImage;

	[SerializeField]
	private TextMeshProUGUI countText;

	[SerializeField]
	private Image durabilityImage;

	[SerializeField]
	private Image durabilityImageBG;

	[SerializeField]
	private ItemInfoPanel itemInfoPanel;

	[Header("Durability Colors")]
	[SerializeField]
	private Gradient durabilityColorGradient;

	public bool isEmpty = true;

	public InventorySlot connectedSlot;

	public CollectableItemData collectableItemData;

	public InventorySlotsData inventoryData;

	public float durabilityRatio;

	public int collectedCount;

	public bool itemHasBar;

	private PlayerInventory playerInventory;

	private RectTransform rectTransform;

	private Canvas canvas;

	private CanvasGroup canvasGroup;

	private bool isDragging;

	private bool isDragSplit;

	private int dragAmount;

	private int originalAmount;

	private bool isHovering;

	private float lastLeftClickTime = -1f;

	private const float doubleClickThreshold = 0.3f;

	[SerializeField]
	private GameObject inventoryDragItemPrefab;

	private InventoryItemDragClone dragItemClone;

	private List<InventorySlot> allInventorySlots = new List<InventorySlot>();

	public EastUpPlayerItemManager itemChooser;

	private bool isInitialized;

	private bool isSilentOperation;

	private ChestUIManager chestUIManager;

	private ChemistryTableUIManager chemistryTableUIManager;

	public bool IsDragging => isDragging;

	private void Start()
	{
		chestUIManager = Object.FindObjectOfType<ChestUIManager>(includeInactive: true);
		chemistryTableUIManager = Object.FindObjectOfType<ChemistryTableUIManager>(includeInactive: true);
	}

	private void Update()
	{
		if (TrainGameManager.isInputActive && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.DropKey))
		{
			HandleItemDrop();
		}
		if (isHovering && itemInfoPanel != null && !isEmpty && itemInfoPanel.infoParent != null)
		{
			if (!Cursor.visible)
			{
				isHovering = false;
				itemInfoPanel.HidePanel();
			}
			else
			{
				Vector2 vector = Input.mousePosition;
				itemInfoPanel.infoParent.position = vector;
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (isEmpty || collectableItemData == null || !Cursor.visible)
		{
			return;
		}
		isHovering = true;
		if (itemInfoPanel != null)
		{
			itemInfoPanel.SetPanel(collectableItemData.GetLocalizedDisplayName(), collectableItemData.GetLocalizedDescription());
			itemInfoPanel.ShowPanel();
			if (itemInfoPanel.infoParent != null)
			{
				itemInfoPanel.infoParent.position = Input.mousePosition;
			}
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isHovering = false;
		if (itemInfoPanel != null)
		{
			itemInfoPanel.HidePanel();
		}
	}

	public void Initialize(InventoryController inventoryController)
	{
		if (!isInitialized)
		{
			isInitialized = true;
			connectedSlot = GetComponentInParent<InventorySlot>();
			rectTransform = GetComponent<RectTransform>();
			canvas = GetComponentInParent<Canvas>();
			canvasGroup = GetComponentInParent<CanvasGroup>();
			playerInventory = TrainGameManager.instance.mainPlayer.GetComponent<PlayerInventory>();
			allInventorySlots = Object.FindObjectsOfType<InventorySlot>(includeInactive: true).ToList();
			if (itemInfoPanel == null)
			{
				itemInfoPanel = Object.FindObjectOfType<ItemInfoPanel>(includeInactive: true);
			}
			itemImage.enabled = false;
			countRect.SetActive(value: false);
		}
	}

	public void UpdateInventoryData(InventorySlotsData data, bool silent)
	{
		isSilentOperation = silent;
		UpdateInventoryData(data);
		isSilentOperation = false;
	}

	public void UpdateInventoryData(InventorySlotsData data)
	{
		inventoryData = data;
		if (data == null || data.item == null)
		{
			ClearInventoryData();
			return;
		}
		collectableItemData = data.item;
		itemImage.enabled = true;
		itemImage.sprite = collectableItemData.itemImage;
		collectedCount = data.itemCountInSlot;
		if (collectableItemData.hasDurability && durabilityImage != null && durabilityImageBG != null)
		{
			durabilityRatio = data.GetDurabilityRatio();
			if (collectableItemData.changeColorForDurability)
			{
				durabilityImage.color = GetDurabilityColor(durabilityRatio);
			}
			else
			{
				durabilityImage.color = Color.white;
			}
			itemHasBar = true;
			countRect.SetActive(value: false);
			durabilityImage.gameObject.SetActive(value: true);
			durabilityImageBG.gameObject.SetActive(value: true);
			durabilityImage.fillAmount = durabilityRatio;
		}
		else
		{
			itemHasBar = false;
			if (durabilityImage != null)
			{
				durabilityImage.gameObject.SetActive(value: false);
			}
			if (durabilityImageBG != null)
			{
				durabilityImageBG.gameObject.SetActive(value: false);
			}
			countRect.SetActive(value: true);
			countText.SetText(data.itemCountInSlot.ToString());
		}
		if (data.itemCountInSlot > 0)
		{
			isEmpty = false;
		}
		else
		{
			isEmpty = true;
		}
	}

	public bool IncreaseDurability(float amount)
	{
		if (inventoryData?.item == null || !inventoryData.item.hasDurability)
		{
			return false;
		}
		float maxDurabilityCapacity = inventoryData.item.maxDurabilityCapacity;
		float num = Mathf.Min(inventoryData.currentDurability + amount, maxDurabilityCapacity);
		if (num != inventoryData.currentDurability)
		{
			inventoryData.currentDurability = num;
			durabilityRatio = inventoryData.GetDurabilityRatio();
			NotifyDurabilityChanged();
			return true;
		}
		return false;
	}

	public bool DecreaseDurability(float amount)
	{
		if (inventoryData?.item == null || !inventoryData.item.hasDurability)
		{
			return false;
		}
		if (inventoryData.currentDurability <= 0f)
		{
			if (collectableItemData.clearItemOnDurabilityFinished)
			{
				StartCoroutine(DestroyItemDelayed());
			}
			return false;
		}
		float currentDurability = Mathf.Max(inventoryData.currentDurability - amount, 0f);
		inventoryData.currentDurability = currentDurability;
		durabilityRatio = inventoryData.GetDurabilityRatio();
		NotifyDurabilityChanged();
		if (inventoryData.currentDurability <= 0f && collectableItemData.clearItemOnDurabilityFinished)
		{
			StartCoroutine(DestroyItemDelayed());
		}
		return true;
	}

	public bool DecreaseDurability()
	{
		if (inventoryData?.item == null || !inventoryData.item.hasDurability)
		{
			return false;
		}
		return DecreaseDurability(inventoryData.item.durabilityDecreasePerUse);
	}

	public bool CanUse()
	{
		if (ObjectBuilderUIManager.Instance.canBuild)
		{
			return true;
		}
		if (inventoryData?.item == null)
		{
			return false;
		}
		if (inventoryData.item.hasDurability && inventoryData.currentDurability <= 0f)
		{
			return false;
		}
		return true;
	}

	public bool ConsumeDurability(float amount)
	{
		if (inventoryData?.item == null || !inventoryData.item.hasDurability)
		{
			return false;
		}
		return DecreaseDurability(amount);
	}

	public void RepairDurability()
	{
		if (!(inventoryData?.item == null) && inventoryData.item.hasDurability)
		{
			inventoryData.SetDurabilityToMax();
			durabilityRatio = inventoryData.GetDurabilityRatio();
			NotifyDurabilityChanged();
		}
	}

	public float GetDurabilityRatio()
	{
		return inventoryData?.GetDurabilityRatio() ?? 0f;
	}

	public float GetCurrentDurability()
	{
		return inventoryData?.currentDurability ?? 0f;
	}

	public float GetMaxDurability()
	{
		return (inventoryData?.item?.maxDurabilityCapacity).GetValueOrDefault();
	}

	public bool HasDurability()
	{
		if (inventoryData?.item != null)
		{
			return inventoryData.item.hasDurability;
		}
		return false;
	}

	public bool IsDurabilityEmpty()
	{
		if (HasDurability())
		{
			return inventoryData.currentDurability <= 0f;
		}
		return false;
	}

	public bool IsDurabilityFull()
	{
		if (!HasDurability())
		{
			return false;
		}
		return inventoryData.currentDurability >= inventoryData.item.maxDurabilityCapacity;
	}

	private void NotifyDurabilityChanged()
	{
		if (isSilentOperation || !HasDurability())
		{
			return;
		}
		UpdateDurabilityUI();
		if (playerInventory != null)
		{
			playerInventory.UpdateInventoryDataFromSlots();
			TsPlayerNetworkHelper component = playerInventory.GetComponent<TsPlayerNetworkHelper>();
			if (component != null && InventorySaver.Instance != null)
			{
				InventorySaver.Instance.RequestInventoryUpdate(component.steamID);
			}
		}
	}

	private void UpdateDurabilityUI()
	{
		if (durabilityImage != null && collectableItemData != null && collectableItemData.hasDurability)
		{
			durabilityRatio = inventoryData.GetDurabilityRatio();
			durabilityImage.fillAmount = durabilityRatio;
			if (collectableItemData.changeColorForDurability)
			{
				durabilityImage.color = GetDurabilityColor(durabilityRatio);
			}
			else
			{
				durabilityImage.color = Color.white;
			}
		}
	}

	private IEnumerator DestroyItemDelayed()
	{
		yield return new WaitForEndOfFrame();
		yield return new WaitForSeconds(0.1f);
		DestroyItemDueToDurability();
	}

	private void DestroyItemDueToDurability()
	{
		if (inventoryData != null)
		{
			inventoryData.Clear();
		}
		ClearInventoryData();
		if (connectedSlot != null)
		{
			connectedSlot.HasItem = false;
			connectedSlot.inventoryCount = 0;
		}
		if (playerInventory != null)
		{
			playerInventory.UpdateInventoryDataFromSlots();
			TsPlayerNetworkHelper component = playerInventory.GetComponent<TsPlayerNetworkHelper>();
			if (component != null && InventorySaver.Instance != null)
			{
				InventorySaver.Instance.RequestInventoryUpdate(component.steamID);
			}
		}
	}

	private Color GetDurabilityColor(float ratio)
	{
		ratio = Mathf.Clamp01(ratio);
		if (durabilityColorGradient == null)
		{
			durabilityColorGradient = new Gradient();
			GradientColorKey[] colorKeys = new GradientColorKey[3]
			{
				new GradientColorKey(Color.red, 0f),
				new GradientColorKey(Color.yellow, 0.5f),
				new GradientColorKey(Color.green, 1f)
			};
			GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2]
			{
				new GradientAlphaKey(1f, 0f),
				new GradientAlphaKey(1f, 1f)
			};
			durabilityColorGradient.SetKeys(colorKeys, alphaKeys);
		}
		return durabilityColorGradient.Evaluate(ratio);
	}

	public void DecreaseItemCount(int count)
	{
		inventoryData.itemCountInSlot -= count;
		collectedCount -= count;
		if (collectedCount <= 0)
		{
			if (inventoryData != null)
			{
				inventoryData.Clear();
			}
			ClearInventoryData();
			if (connectedSlot != null)
			{
				connectedSlot.HasItem = false;
				connectedSlot.inventoryCount = 0;
			}
			if (playerInventory != null)
			{
				playerInventory.UpdateInventoryDataFromSlots();
			}
		}
		else
		{
			countText.SetText(inventoryData.itemCountInSlot.ToString());
		}
	}

	public void ClearInventoryData()
	{
		ClearInventoryData(silent: false);
	}

	public void ClearInventoryData(bool silent)
	{
		isSilentOperation = silent;
		itemImage.enabled = false;
		countRect.SetActive(value: false);
		if (durabilityImage != null)
		{
			durabilityImage.gameObject.SetActive(value: false);
		}
		if (durabilityImageBG != null)
		{
			durabilityImageBG.gameObject.SetActive(value: false);
		}
		collectableItemData = null;
		inventoryData = null;
		collectedCount = 0;
		isEmpty = true;
		itemHasBar = false;
		if (!silent)
		{
			TrainGameManager.instance.itemChooser.CheckItemSlots();
		}
		isSilentOperation = false;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (isEmpty)
		{
			return;
		}
		if (itemInfoPanel != null)
		{
			itemInfoPanel.HidePanel();
			isHovering = false;
		}
		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			HandleShiftClick();
			return;
		}
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			float unscaledTime = Time.unscaledTime;
			if (lastLeftClickTime > 0f && unscaledTime - lastLeftClickTime <= 0.3f)
			{
				lastLeftClickTime = -1f;
				HandleShiftClick();
				return;
			}
			lastLeftClickTime = unscaledTime;
		}
		isDragging = true;
		originalAmount = inventoryData.itemCountInSlot;
		if (Input.GetKey(KeyCode.LeftShift))
		{
			dragAmount = Mathf.Max(1, inventoryData.itemCountInSlot / 2);
			if (inventoryData.itemCountInSlot - dragAmount <= 0)
			{
				isDragSplit = false;
				dragAmount = inventoryData.itemCountInSlot;
				canvasGroup.blocksRaycasts = false;
				countRect.SetActive(value: false);
				Debug.Log("Ctrl basılı ama kalan miktar 0, normal sürükleme yapılıyor");
			}
			else
			{
				isDragSplit = true;
				inventoryData.itemCountInSlot -= dragAmount;
				UpdateInventoryData(inventoryData);
				CreateDragClone();
				Debug.Log($"Split sürükleme: {dragAmount} sürükleniyor, {inventoryData.itemCountInSlot} kalıyor");
			}
		}
		else if (eventData.button == PointerEventData.InputButton.Right)
		{
			dragAmount = 1;
			if (inventoryData.itemCountInSlot <= 1)
			{
				isDragSplit = false;
				dragAmount = inventoryData.itemCountInSlot;
				canvasGroup.blocksRaycasts = false;
				countRect.SetActive(value: false);
				Debug.Log("Sağ click ama sadece 1 item var, normal sürükleme yapılıyor");
			}
			else
			{
				isDragSplit = true;
				inventoryData.itemCountInSlot -= dragAmount;
				UpdateInventoryData(inventoryData);
				CreateDragClone();
				Debug.Log($"Sağ click split: 1 sürükleniyor, {inventoryData.itemCountInSlot} kalıyor");
			}
		}
		else
		{
			isDragSplit = false;
			dragAmount = inventoryData.itemCountInSlot;
			canvasGroup.blocksRaycasts = false;
			countRect.SetActive(value: false);
		}
	}

	private void CreateDragClone()
	{
		if (inventoryDragItemPrefab == null)
		{
			Debug.LogError("InventoryDragItem prefab'ı tanımlanmamış!");
			return;
		}
		GameObject gameObject = Object.Instantiate(inventoryDragItemPrefab, base.transform.parent);
		dragItemClone = gameObject.GetComponent<InventoryItemDragClone>();
		if (dragItemClone == null)
		{
			Debug.LogError("DragClone objesinde InventoryItemDragClone scripti bulunamadı!");
			Object.Destroy(gameObject);
			return;
		}
		RectTransform component = gameObject.GetComponent<RectTransform>();
		if (component != null)
		{
			component.anchorMin = rectTransform.anchorMin;
			component.anchorMax = rectTransform.anchorMax;
			component.pivot = rectTransform.pivot;
			component.sizeDelta = rectTransform.sizeDelta;
			component.anchoredPosition = rectTransform.anchoredPosition;
			component.localScale = rectTransform.localScale;
			Vector3 position = component.position;
			component.SetParent(canvas.transform, worldPositionStays: true);
			component.position = position;
		}
		dragItemClone.Initialize(collectableItemData, dragAmount);
		CanvasGroup canvasGroup = gameObject.GetComponent<CanvasGroup>();
		if (canvasGroup == null)
		{
			canvasGroup = gameObject.AddComponent<CanvasGroup>();
		}
		canvasGroup.alpha = 0.8f;
		canvasGroup.blocksRaycasts = false;
		component.SetAsLastSibling();
		Debug.Log($"Drag clone oluşturuldu. Original size: {rectTransform.sizeDelta}, Clone size: {component.sizeDelta}, Count: {dragAmount}");
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (isDragging)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out var localPoint);
			if (isDragSplit && dragItemClone != null)
			{
				dragItemClone.transform.position = canvas.transform.TransformPoint(localPoint);
			}
			else
			{
				rectTransform.position = canvas.transform.TransformPoint(localPoint);
			}
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		isDragging = false;
		canvasGroup.blocksRaycasts = true;
		Vector2 mousePos = Input.mousePosition;
		InventorySlot inventorySlot = (from obj in allInventorySlots.Where((InventorySlot x) => x.isShowing).ToList()
			orderby Vector3.Distance(obj.GetComponent<RectTransform>().position, mousePos)
			select obj).First();
		bool flag = false;
		if (RectTransformUtility.RectangleContainsScreenPoint(inventorySlot.GetComponent<RectTransform>(), mousePos))
		{
			flag = true;
			if (isDragSplit)
			{
				HandleSplitDrop(inventorySlot);
			}
			else if (inventorySlot != connectedSlot)
			{
				ChangeObjectSlot(connectedSlot, inventorySlot);
			}
		}
		if (!flag)
		{
			if (isDragSplit)
			{
				inventoryData.itemCountInSlot += dragAmount;
				UpdateInventoryData(inventoryData);
				DropItemToGround(dragAmount);
			}
			else
			{
				DropItemToGround(dragAmount);
			}
		}
		if (isDragSplit && dragItemClone != null)
		{
			Object.Destroy(dragItemClone.gameObject);
			dragItemClone = null;
		}
		ResetPosition();
	}

	private void HandleSplitDrop(InventorySlot targetSlot)
	{
		if (chemistryTableUIManager != null && chemistryTableUIManager.isPanelOpen)
		{
			if (targetSlot == chemistryTableUIManager.outputSlot && connectedSlot != chemistryTableUIManager.outputSlot)
			{
				inventoryData.itemCountInSlot += dragAmount;
				UpdateInventoryData(inventoryData);
				return;
			}
			if (targetSlot == chemistryTableUIManager.fuelSlot && inventoryData.item != null)
			{
				ChemistryTableController currentTable = chemistryTableUIManager.GetCurrentTable();
				if (currentTable != null && !currentTable.IsFuelItem(inventoryData.item))
				{
					inventoryData.itemCountInSlot += dragAmount;
					UpdateInventoryData(inventoryData);
					return;
				}
			}
			ChemistryTableController currentTable2 = chemistryTableUIManager.GetCurrentTable();
			if (currentTable2 != null && currentTable2.isProcessing)
			{
				if (chemistryTableUIManager.inputSlots.IndexOf(targetSlot) >= 0)
				{
					inventoryData.itemCountInSlot += dragAmount;
					UpdateInventoryData(inventoryData);
					return;
				}
				int num = chemistryTableUIManager.inputSlots.IndexOf(connectedSlot);
				if (num >= 0)
				{
					int neededAmountForInputSlot = currentTable2.GetNeededAmountForInputSlot(num);
					if (inventoryData.itemCountInSlot < neededAmountForInputSlot)
					{
						inventoryData.itemCountInSlot += dragAmount;
						UpdateInventoryData(inventoryData);
						return;
					}
				}
			}
		}
		InventorySlotsData inventorySlotsData = null;
		if (playerInventory.mainInventorySlots.Contains(targetSlot))
		{
			inventorySlotsData = playerInventory.inventorySlotsData.Find((InventorySlotsData x) => x.slotID == targetSlot.inventoryID);
			if (inventorySlotsData == null)
			{
				Debug.LogError($"Player main slot data bulunamadı! Slot ID: {targetSlot.inventoryID}");
				inventoryData.itemCountInSlot += dragAmount;
				UpdateInventoryData(inventoryData);
				return;
			}
		}
		else
		{
			inventorySlotsData = targetSlot.InventoryItem.inventoryData;
			if (inventorySlotsData == null)
			{
				inventorySlotsData = new InventorySlotsData
				{
					slotID = targetSlot.inventoryID,
					item = null,
					itemCountInSlot = 0,
					currentMagazineCount = 0
				};
				targetSlot.InventoryItem.inventoryData = inventorySlotsData;
			}
		}
		bool flag = false;
		if (targetSlot == connectedSlot)
		{
			inventoryData.itemCountInSlot += dragAmount;
			UpdateInventoryData(inventoryData);
			return;
		}
		if (inventorySlotsData.item == null)
		{
			inventorySlotsData.item = inventoryData.item;
			inventorySlotsData.itemCountInSlot = dragAmount;
			if (IsWeaponOrTool(inventoryData.item))
			{
				inventorySlotsData.currentMagazineCount = inventoryData.currentMagazineCount;
			}
			if (inventoryData.item.hasDurability)
			{
				float num2 = inventoryData.currentDurability / (float)inventoryData.itemCountInSlot;
				inventorySlotsData.currentDurability = num2 * (float)dragAmount;
				inventoryData.currentDurability -= inventorySlotsData.currentDurability;
			}
			targetSlot.InventoryItem.UpdateInventoryData(inventorySlotsData);
			targetSlot.HasItem = true;
			targetSlot.inventoryCount = dragAmount;
			flag = true;
		}
		else if (inventorySlotsData.item == inventoryData.item)
		{
			int itemSizeMultiplier = inventoryData.item.GetItemSizeMultiplier();
			int num3 = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.inventorySlotSize : playerInventory.inventorySlotMaxCapacity) / itemSizeMultiplier;
			int num4 = Mathf.Min(dragAmount, num3 - inventorySlotsData.itemCountInSlot);
			if (num4 > 0)
			{
				inventorySlotsData.itemCountInSlot += num4;
				if (IsWeaponOrTool(inventoryData.item))
				{
					inventorySlotsData.currentMagazineCount = inventoryData.currentMagazineCount;
				}
				if (inventoryData.item.hasDurability && num4 > 0)
				{
					float num5 = inventoryData.currentDurability / (float)inventoryData.itemCountInSlot * (float)num4;
					inventorySlotsData.currentDurability += num5;
					inventoryData.currentDurability -= num5;
				}
				int num6 = dragAmount - num4;
				if (num6 > 0)
				{
					inventoryData.itemCountInSlot += num6;
				}
				targetSlot.InventoryItem.UpdateInventoryData(inventorySlotsData);
				UpdateInventoryData(inventoryData);
				flag = true;
			}
			else
			{
				inventoryData.itemCountInSlot += dragAmount;
				UpdateInventoryData(inventoryData);
			}
		}
		else
		{
			CollectableItemData item = inventoryData.item;
			int itemCountInSlot = inventoryData.itemCountInSlot;
			int currentMagazineCount = inventoryData.currentMagazineCount;
			float currentDurability = inventoryData.currentDurability;
			inventoryData.item = inventorySlotsData.item;
			inventoryData.itemCountInSlot = inventorySlotsData.itemCountInSlot;
			inventoryData.currentMagazineCount = inventorySlotsData.currentMagazineCount;
			inventoryData.currentDurability = inventorySlotsData.currentDurability;
			inventorySlotsData.item = item;
			inventorySlotsData.itemCountInSlot = dragAmount;
			if (IsWeaponOrTool(item))
			{
				inventorySlotsData.currentMagazineCount = currentMagazineCount;
			}
			if (item != null && item.hasDurability)
			{
				float num7 = currentDurability / (float)itemCountInSlot;
				inventorySlotsData.currentDurability = num7 * (float)dragAmount;
			}
			if (itemCountInSlot > 0)
			{
				inventoryData.itemCountInSlot += itemCountInSlot;
				if (item != null && item.hasDurability)
				{
					float num8 = currentDurability - inventorySlotsData.currentDurability;
					inventoryData.currentDurability += num8;
				}
			}
			UpdateInventoryData(inventoryData);
			targetSlot.InventoryItem.UpdateInventoryData(inventorySlotsData);
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		bool num9 = playerInventory.mainInventorySlots.Contains(connectedSlot);
		bool flag2 = playerInventory.mainInventorySlots.Contains(targetSlot);
		if (num9 || flag2)
		{
			NotifyInventoryChanged(connectedSlot, targetSlot);
		}
		else if (chestUIManager != null && chestUIManager.isPanelOpen && chestUIManager.HasOpenedChest)
		{
			if (IsChestSlot(connectedSlot))
			{
				UpdateSingleChestSlot(chestUIManager, connectedSlot);
			}
			if (IsChestSlot(targetSlot))
			{
				UpdateSingleChestSlot(chestUIManager, targetSlot);
			}
		}
		if (!(chemistryTableUIManager != null) || !chemistryTableUIManager.isPanelOpen)
		{
			return;
		}
		ChemistryTableController currentTable3 = chemistryTableUIManager.GetCurrentTable();
		if (currentTable3 != null && currentTable3.isProcessing)
		{
			int num10 = chemistryTableUIManager.inputSlots.IndexOf(connectedSlot);
			if (num10 >= 0 && inventoryData != null)
			{
				int itemCountInSlot2 = inventoryData.itemCountInSlot;
				currentTable3.TryReduceInputItemCount(num10, itemCountInSlot2);
			}
		}
		chemistryTableUIManager.OnSlotsChanged();
	}

	private void HandleShiftClick()
	{
		if (chestUIManager != null && chestUIManager.isPanelOpen)
		{
			Debug.Log("[HandleShiftClick] Chest açık, chest transfer yapılıyor");
			if (connectedSlot.inventoryID >= 1000)
			{
				TransferToPlayerInventory();
			}
			else
			{
				TransferToChest(chestUIManager);
			}
			return;
		}
		if (chemistryTableUIManager != null && chemistryTableUIManager.isPanelOpen)
		{
			if (connectedSlot == chemistryTableUIManager.fuelSlot || chemistryTableUIManager.inputSlots.Contains(connectedSlot) || connectedSlot == chemistryTableUIManager.outputSlot)
			{
				TransferToPlayerInventory();
			}
			else if (connectedSlot.isBottomInventory)
			{
				TransferToMainInventory();
			}
			else
			{
				TransferToBottomInventory();
			}
			return;
		}
		Debug.Log($"[HandleShiftClick] Inventory içi transfer başlıyor. isBottomInventory: {connectedSlot.isBottomInventory}");
		if (connectedSlot.isBottomInventory)
		{
			Debug.Log("[HandleShiftClick] Bottom'dan main'e transfer");
			TransferToMainInventory();
		}
		else
		{
			Debug.Log("[HandleShiftClick] Main'den bottom'a transfer");
			TransferToBottomInventory();
		}
	}

	private void TransferToPlayerInventory()
	{
		if (playerInventory == null || isEmpty)
		{
			return;
		}
		List<InventorySlot> mainInventorySlots = playerInventory.mainInventorySlots;
		while (!isEmpty)
		{
			InventorySlot inventorySlot = FindStackableSlot(mainInventorySlots);
			if (inventorySlot == null)
			{
				inventorySlot = FindEmptySlot(mainInventorySlots);
			}
			if (!(inventorySlot == null))
			{
				ChangeObjectSlot(connectedSlot, inventorySlot);
				continue;
			}
			break;
		}
	}

	private void TransferToChest(ChestUIManager chestUIManager)
	{
		if (isEmpty)
		{
			return;
		}
		List<InventorySlot> slots = (from s in chestUIManager.GetComponentsInChildren<InventorySlot>()
			where s.gameObject.activeSelf && s.inventoryID >= 1000
			select s).ToList();
		while (!isEmpty)
		{
			InventorySlot inventorySlot = FindStackableSlot(slots);
			if (inventorySlot == null)
			{
				inventorySlot = FindEmptySlot(slots);
			}
			if (!(inventorySlot == null))
			{
				ChangeObjectSlot(connectedSlot, inventorySlot);
				continue;
			}
			break;
		}
	}

	private void TransferToMainInventory()
	{
		if (!(playerInventory == null) && !isEmpty)
		{
			List<InventorySlot> slots = playerInventory.mainInventorySlots.Where((InventorySlot s) => !s.isBottomInventory).ToList();
			InventorySlot inventorySlot = FindVerifiedStackableSlot(slots);
			if (inventorySlot == null)
			{
				inventorySlot = FindVerifiedEmptySlot(slots);
			}
			if (!(inventorySlot == null))
			{
				ChangeObjectSlot(connectedSlot, inventorySlot);
			}
		}
	}

	private void TransferToBottomInventory()
	{
		if (!(playerInventory == null) && !isEmpty)
		{
			List<InventorySlot> slots = playerInventory.mainInventorySlots.Where((InventorySlot s) => s.isBottomInventory).ToList();
			InventorySlot inventorySlot = FindVerifiedStackableSlot(slots);
			if (inventorySlot == null)
			{
				inventorySlot = FindVerifiedEmptySlot(slots);
			}
			if (!(inventorySlot == null))
			{
				ChangeObjectSlot(connectedSlot, inventorySlot);
			}
		}
	}

	private InventorySlot FindStackableSlot(List<InventorySlot> slots)
	{
		if (collectableItemData == null)
		{
			return null;
		}
		int itemSizeMultiplier = collectableItemData.GetItemSizeMultiplier();
		int num = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.inventorySlotSize : playerInventory.inventorySlotMaxCapacity) / itemSizeMultiplier;
		foreach (InventorySlot slot in slots)
		{
			if (slot.HasItem && slot.InventoryItem.collectableItemData == collectableItemData && slot.inventoryCount < num)
			{
				return slot;
			}
		}
		return null;
	}

	private InventorySlot FindEmptySlot(List<InventorySlot> slots)
	{
		foreach (InventorySlot slot in slots)
		{
			if (!slot.HasItem || slot.InventoryItem.isEmpty)
			{
				return slot;
			}
		}
		return null;
	}

	private InventorySlot FindVerifiedEmptySlot(List<InventorySlot> slots)
	{
		if (playerInventory == null)
		{
			return null;
		}
		foreach (InventorySlot slot in slots)
		{
			InventorySlotsData inventorySlotsData = playerInventory.inventorySlotsData.Find((InventorySlotsData x) => x.slotID == slot.inventoryID);
			if (inventorySlotsData != null && (inventorySlotsData.item == null || inventorySlotsData.itemCountInSlot <= 0))
			{
				return slot;
			}
		}
		return null;
	}

	private InventorySlot FindVerifiedStackableSlot(List<InventorySlot> slots)
	{
		if (collectableItemData == null || playerInventory == null)
		{
			return null;
		}
		int itemSizeMultiplier = collectableItemData.GetItemSizeMultiplier();
		int num = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.inventorySlotSize : playerInventory.inventorySlotMaxCapacity) / itemSizeMultiplier;
		foreach (InventorySlot slot in slots)
		{
			InventorySlotsData inventorySlotsData = playerInventory.inventorySlotsData.Find((InventorySlotsData x) => x.slotID == slot.inventoryID);
			if (inventorySlotsData != null && inventorySlotsData.item == collectableItemData && inventorySlotsData.itemCountInSlot > 0 && inventorySlotsData.itemCountInSlot < num)
			{
				return slot;
			}
		}
		return null;
	}

	private void HandleItemDrop(bool directlyDrop = false)
	{
		if (IsMouseOverThisItem() && !isEmpty)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				DropItemToGround(inventoryData.itemCountInSlot);
			}
			else
			{
				DropItemToGround(1);
			}
		}
	}

	public void DropItemFromSlots()
	{
		if (!MainUIManager.isInventoryActive && !isEmpty && inventoryData != null && !(collectableItemData == null))
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				DropItemToGround(inventoryData.itemCountInSlot);
			}
			else
			{
				DropItemToGround(1);
			}
		}
	}

	private bool IsMouseOverThisItem()
	{
		Vector2 screenPoint = Input.mousePosition;
		return RectTransformUtility.RectangleContainsScreenPoint(rectTransform, screenPoint);
	}

	private void DropItemToGround(int amount)
	{
		if (collectableItemData == null || playerInventory == null || playerInventory.defaultDropPrefab == null)
		{
			return;
		}
		if (chemistryTableUIManager != null && chemistryTableUIManager.isPanelOpen && connectedSlot != null)
		{
			ChemistryTableController currentTable = chemistryTableUIManager.GetCurrentTable();
			if (currentTable != null && currentTable.isProcessing && chemistryTableUIManager.inputSlots.Contains(connectedSlot))
			{
				return;
			}
		}
		Transform transform = playerInventory.GetComponent<TSPlayerController>().activeCamera.transform;
		Vector3 spawnPoint = transform.transform.position + transform.transform.forward;
		Vector3 spawnForward = transform.transform.position + transform.transform.forward * 2f;
		if (collectableItemData.hasDurability && inventoryData != null)
		{
			float num = inventoryData.GetDurabilityRatio();
			float durability = collectableItemData.maxDurabilityCapacity * num;
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClientWithDurability(collectableItemData.itemName, amount, spawnPoint, spawnForward, durability);
			float num2 = collectableItemData.maxDurabilityCapacity * num * (float)amount;
			float a = inventoryData.currentDurability - num2;
			inventoryData.currentDurability = Mathf.Max(a, 0f);
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClient(collectableItemData.itemName, amount, spawnPoint, spawnForward);
		}
		inventoryData.itemCountInSlot -= amount;
		if (inventoryData.itemCountInSlot <= 0)
		{
			inventoryData.item = null;
			inventoryData.itemCountInSlot = 0;
			ClearInventoryData();
		}
		else
		{
			UpdateInventoryData(inventoryData);
		}
		if (connectedSlot != null && inventoryData != null)
		{
			connectedSlot.HasItem = inventoryData.item != null;
			connectedSlot.inventoryCount = inventoryData.itemCountInSlot;
		}
		Grabber component = playerInventory.GetComponent<Grabber>();
		if (component != null && component.selectedGrabbleObject != null)
		{
			component.CancelBuild(directlyDestroy: true);
		}
		if (chemistryTableUIManager != null && chemistryTableUIManager.isPanelOpen && connectedSlot != null)
		{
			ChemistryTableController currentTable2 = chemistryTableUIManager.GetCurrentTable();
			if (currentTable2 != null)
			{
				int num3 = chemistryTableUIManager.inputSlots.IndexOf(connectedSlot);
				if (num3 >= 0)
				{
					if (inventoryData == null || inventoryData.item == null || inventoryData.itemCountInSlot <= 0)
					{
						currentTable2.TryRemoveInputItem(num3);
					}
					else
					{
						currentTable2.TryReduceInputItemCount(num3, inventoryData.itemCountInSlot);
					}
					return;
				}
				if (connectedSlot == chemistryTableUIManager.fuelSlot)
				{
					for (int i = 0; i < amount; i++)
					{
						currentTable2.TryRemoveFuel();
					}
					return;
				}
				if (connectedSlot == chemistryTableUIManager.outputSlot)
				{
					currentTable2.TryTakeOutput();
					return;
				}
			}
		}
		if (playerInventory != null)
		{
			playerInventory.UpdateInventoryDataFromSlots();
			TsPlayerNetworkHelper component2 = playerInventory.GetComponent<TsPlayerNetworkHelper>();
			if (component2 != null && InventorySaver.Instance != null)
			{
				InventorySaver.Instance.RequestInventoryUpdate(component2.steamID);
			}
		}
	}

	private void ResetPosition()
	{
		base.transform.DOKill();
		base.transform.DOLocalMove(Vector3.zero, 0.1f).OnComplete(delegate
		{
			if (collectableItemData != null)
			{
				if (collectableItemData.hasDurability)
				{
					countRect.SetActive(value: false);
					if (durabilityImage != null)
					{
						durabilityImage.gameObject.SetActive(value: true);
						durabilityImageBG.gameObject.SetActive(value: true);
					}
				}
				else
				{
					countRect.SetActive(value: true);
					if (durabilityImage != null)
					{
						durabilityImage.gameObject.SetActive(value: false);
						durabilityImageBG.gameObject.SetActive(value: false);
					}
				}
			}
			else
			{
				countRect.SetActive(value: false);
				if (durabilityImage != null)
				{
					durabilityImage.gameObject.SetActive(value: false);
					durabilityImageBG.gameObject.SetActive(value: false);
				}
			}
		});
		isDragSplit = false;
		dragAmount = 0;
		originalAmount = 0;
	}

	public void ChangeObjectSlot(InventorySlot mainSlot, InventorySlot connectedSlot)
	{
		InventorySlotsData inventorySlotsData = null;
		InventorySlotsData inventorySlotsData2 = null;
		bool flag = playerInventory.mainInventorySlots.Contains(mainSlot);
		inventorySlotsData = ((!flag) ? mainSlot.InventoryItem.inventoryData : playerInventory.inventorySlotsData.Find((InventorySlotsData x) => x.slotID == mainSlot.inventoryID));
		bool flag2 = playerInventory.mainInventorySlots.Contains(connectedSlot);
		if (flag2)
		{
			inventorySlotsData2 = playerInventory.inventorySlotsData.Find((InventorySlotsData x) => x.slotID == connectedSlot.inventoryID);
		}
		else
		{
			inventorySlotsData2 = connectedSlot.InventoryItem.inventoryData;
			if (inventorySlotsData2 == null)
			{
				inventorySlotsData2 = new InventorySlotsData
				{
					slotID = connectedSlot.inventoryID,
					item = null,
					itemCountInSlot = 0,
					currentMagazineCount = 0,
					currentDurability = 0f
				};
				connectedSlot.InventoryItem.inventoryData = inventorySlotsData2;
			}
		}
		if (inventorySlotsData == null)
		{
			Debug.LogError($"Main slot data bulunamadı! Slot ID: {mainSlot.inventoryID}");
			return;
		}
		if (inventorySlotsData2 == null)
		{
			Debug.LogError($"Connected slot data bulunamadı! Slot ID: {connectedSlot.inventoryID}");
			return;
		}
		if (chemistryTableUIManager != null && chemistryTableUIManager.isPanelOpen)
		{
			if (connectedSlot == chemistryTableUIManager.outputSlot && mainSlot != chemistryTableUIManager.outputSlot)
			{
				return;
			}
			if (mainSlot == chemistryTableUIManager.outputSlot && inventorySlotsData2 != null && inventorySlotsData2.item != null)
			{
				DropItemToGround(inventorySlotsData.itemCountInSlot);
				return;
			}
			if (connectedSlot == chemistryTableUIManager.fuelSlot && inventorySlotsData.item != null)
			{
				ChemistryTableController currentTable = chemistryTableUIManager.GetCurrentTable();
				if (currentTable != null && !currentTable.IsFuelItem(inventorySlotsData.item))
				{
					return;
				}
			}
			if (mainSlot == chemistryTableUIManager.fuelSlot && inventorySlotsData2 != null && inventorySlotsData2.item != null)
			{
				ChemistryTableController currentTable2 = chemistryTableUIManager.GetCurrentTable();
				if (currentTable2 != null && !currentTable2.IsFuelItem(inventorySlotsData2.item))
				{
					return;
				}
			}
			ChemistryTableController currentTable3 = chemistryTableUIManager.GetCurrentTable();
			if (currentTable3 != null && currentTable3.isProcessing)
			{
				if (chemistryTableUIManager.inputSlots.IndexOf(connectedSlot) >= 0)
				{
					return;
				}
				int num = chemistryTableUIManager.inputSlots.IndexOf(mainSlot);
				if (num >= 0 && inventorySlotsData.item != null)
				{
					int neededAmountForInputSlot = currentTable3.GetNeededAmountForInputSlot(num);
					int itemCountInSlot = inventorySlotsData.itemCountInSlot;
					int num2 = itemCountInSlot - neededAmountForInputSlot;
					if (num2 <= 0)
					{
						return;
					}
					int num3 = num2;
					if (inventorySlotsData2.item != null && inventorySlotsData2.item != inventorySlotsData.item)
					{
						return;
					}
					if (inventorySlotsData2.item == inventorySlotsData.item)
					{
						int itemSizeMultiplier = inventorySlotsData.item.GetItemSizeMultiplier();
						int b = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.inventorySlotSize : playerInventory.inventorySlotMaxCapacity) / itemSizeMultiplier - inventorySlotsData2.itemCountInSlot;
						num3 = Mathf.Min(num2, b);
					}
					if (num3 > 0)
					{
						if (inventorySlotsData2.item == null)
						{
							inventorySlotsData2.item = inventorySlotsData.item;
						}
						inventorySlotsData2.itemCountInSlot += num3;
						inventorySlotsData.itemCountInSlot -= num3;
						if (inventorySlotsData.item.hasDurability && itemCountInSlot > 0)
						{
							float num4 = inventorySlotsData.currentDurability / (float)itemCountInSlot;
							inventorySlotsData2.currentDurability += num4 * (float)num3;
							inventorySlotsData.currentDurability -= num4 * (float)num3;
						}
						mainSlot.InventoryItem.UpdateInventoryData(inventorySlotsData);
						connectedSlot.InventoryItem.UpdateInventoryData(inventorySlotsData2);
						mainSlot.HasItem = inventorySlotsData.item != null && inventorySlotsData.itemCountInSlot > 0;
						connectedSlot.HasItem = inventorySlotsData2.item != null;
						mainSlot.inventoryCount = inventorySlotsData.itemCountInSlot;
						connectedSlot.inventoryCount = inventorySlotsData2.itemCountInSlot;
						if (flag || flag2)
						{
							NotifyInventoryChanged(mainSlot, connectedSlot);
						}
						currentTable3.TryReduceInputItemCount(num, inventorySlotsData.itemCountInSlot);
						if (chemistryTableUIManager.isPanelOpen)
						{
							chemistryTableUIManager.OnSlotsChanged();
						}
					}
					return;
				}
			}
		}
		if (inventorySlotsData == null || inventorySlotsData2 == null)
		{
			return;
		}
		if (connectedSlot.inventorySlotType == InventorySlotType.Research && inventorySlotsData.item != null)
		{
			if (inventorySlotsData2.item == null)
			{
				inventorySlotsData2.item = inventorySlotsData.item;
				inventorySlotsData2.itemCountInSlot = 1;
				if (IsWeaponOrTool(inventorySlotsData.item))
				{
					inventorySlotsData2.currentMagazineCount = inventorySlotsData.currentMagazineCount;
				}
				if (inventorySlotsData.item.hasDurability)
				{
					inventorySlotsData.currentDurability -= (inventorySlotsData2.currentDurability = inventorySlotsData.currentDurability / (float)inventorySlotsData.itemCountInSlot);
				}
				inventorySlotsData.itemCountInSlot--;
				if (inventorySlotsData.itemCountInSlot <= 0)
				{
					inventorySlotsData.item = null;
					inventorySlotsData.itemCountInSlot = 0;
					inventorySlotsData.currentMagazineCount = 0;
					inventorySlotsData.currentDurability = 0f;
				}
			}
			else if (inventorySlotsData2.item == inventorySlotsData.item)
			{
				if (inventorySlotsData2.itemCountInSlot < 1)
				{
					int num5 = Mathf.Min(1 - inventorySlotsData2.itemCountInSlot, inventorySlotsData.itemCountInSlot);
					inventorySlotsData2.itemCountInSlot += num5;
					if (IsWeaponOrTool(inventorySlotsData.item))
					{
						inventorySlotsData2.currentMagazineCount = inventorySlotsData.currentMagazineCount;
					}
					if (inventorySlotsData.item.hasDurability && num5 > 0)
					{
						float num6 = inventorySlotsData.currentDurability / (float)inventorySlotsData.itemCountInSlot * (float)num5;
						float num7 = inventorySlotsData2.currentDurability + num6;
						if (num7 <= inventorySlotsData.item.maxDurabilityCapacity)
						{
							inventorySlotsData2.currentDurability = num7;
							inventorySlotsData.currentDurability -= num6;
						}
						else
						{
							inventorySlotsData2.currentDurability = inventorySlotsData.item.maxDurabilityCapacity;
							inventorySlotsData.currentDurability -= inventorySlotsData.item.maxDurabilityCapacity - inventorySlotsData2.currentDurability;
						}
					}
					inventorySlotsData.itemCountInSlot -= num5;
					if (inventorySlotsData.itemCountInSlot <= 0)
					{
						inventorySlotsData.item = null;
						inventorySlotsData.itemCountInSlot = 0;
						inventorySlotsData.currentMagazineCount = 0;
						inventorySlotsData.currentDurability = 0f;
					}
				}
			}
			else
			{
				CollectableItemData item = inventorySlotsData.item;
				int itemCountInSlot2 = inventorySlotsData.itemCountInSlot;
				int currentMagazineCount = inventorySlotsData.currentMagazineCount;
				float currentDurability = inventorySlotsData.currentDurability;
				inventorySlotsData.item = inventorySlotsData2.item;
				inventorySlotsData.itemCountInSlot = inventorySlotsData2.itemCountInSlot;
				inventorySlotsData.currentMagazineCount = inventorySlotsData2.currentMagazineCount;
				inventorySlotsData.currentDurability = inventorySlotsData2.currentDurability;
				inventorySlotsData2.item = item;
				inventorySlotsData2.itemCountInSlot = 1;
				if (IsWeaponOrTool(item))
				{
					inventorySlotsData2.currentMagazineCount = currentMagazineCount;
				}
				if (item != null && item.hasDurability)
				{
					float currentDurability2 = currentDurability / (float)itemCountInSlot2;
					inventorySlotsData2.currentDurability = currentDurability2;
				}
				if (itemCountInSlot2 > 1)
				{
					inventorySlotsData.itemCountInSlot += itemCountInSlot2 - 1;
					if (item != null && item.hasDurability)
					{
						float num8 = currentDurability - inventorySlotsData2.currentDurability;
						inventorySlotsData.currentDurability += num8;
					}
				}
			}
		}
		else if (inventorySlotsData.item != null && inventorySlotsData2.item != null && inventorySlotsData.item == inventorySlotsData2.item)
		{
			int itemSizeMultiplier2 = inventorySlotsData.item.GetItemSizeMultiplier();
			int num9 = ((Singleton<GameSettings>.Instance != null) ? Singleton<GameSettings>.Instance.inventorySlotSize : playerInventory.inventorySlotMaxCapacity) / itemSizeMultiplier2;
			int num10 = inventorySlotsData.itemCountInSlot + inventorySlotsData2.itemCountInSlot;
			if (num10 <= num9)
			{
				inventorySlotsData2.itemCountInSlot = num10;
				if (IsWeaponOrTool(inventorySlotsData.item))
				{
					inventorySlotsData2.currentMagazineCount = inventorySlotsData.currentMagazineCount;
				}
				if (inventorySlotsData.item.hasDurability)
				{
					float num11 = inventorySlotsData.currentDurability + inventorySlotsData2.currentDurability;
					if (num11 <= inventorySlotsData.item.maxDurabilityCapacity)
					{
						inventorySlotsData2.currentDurability = num11;
					}
					else
					{
						inventorySlotsData2.currentDurability = inventorySlotsData.item.maxDurabilityCapacity;
					}
				}
				inventorySlotsData.item = null;
				inventorySlotsData.itemCountInSlot = 0;
				inventorySlotsData.currentMagazineCount = 0;
				inventorySlotsData.currentDurability = 0f;
			}
			else
			{
				int num12 = num9 - inventorySlotsData2.itemCountInSlot;
				if (num12 > 0)
				{
					int num13 = Mathf.Min(num12, inventorySlotsData.itemCountInSlot);
					inventorySlotsData2.itemCountInSlot += num13;
					if (IsWeaponOrTool(inventorySlotsData.item))
					{
						inventorySlotsData2.currentMagazineCount = inventorySlotsData.currentMagazineCount;
					}
					if (inventorySlotsData.item.hasDurability && num13 > 0)
					{
						float num14 = inventorySlotsData.currentDurability / (float)inventorySlotsData.itemCountInSlot * (float)num13;
						float num15 = inventorySlotsData2.currentDurability + num14;
						if (num15 <= inventorySlotsData.item.maxDurabilityCapacity)
						{
							inventorySlotsData2.currentDurability = num15;
							inventorySlotsData.currentDurability -= num14;
						}
						else
						{
							inventorySlotsData2.currentDurability = inventorySlotsData.item.maxDurabilityCapacity;
							inventorySlotsData.currentDurability -= inventorySlotsData.item.maxDurabilityCapacity - inventorySlotsData2.currentDurability;
						}
					}
					inventorySlotsData.itemCountInSlot -= num13;
					if (inventorySlotsData.itemCountInSlot <= 0)
					{
						inventorySlotsData.item = null;
						inventorySlotsData.itemCountInSlot = 0;
						inventorySlotsData.currentMagazineCount = 0;
						inventorySlotsData.currentDurability = 0f;
					}
				}
				else
				{
					CollectableItemData item2 = inventorySlotsData.item;
					int itemCountInSlot3 = inventorySlotsData.itemCountInSlot;
					int currentMagazineCount2 = inventorySlotsData.currentMagazineCount;
					float currentDurability3 = inventorySlotsData.currentDurability;
					inventorySlotsData.item = inventorySlotsData2.item;
					inventorySlotsData.itemCountInSlot = inventorySlotsData2.itemCountInSlot;
					inventorySlotsData.currentMagazineCount = inventorySlotsData2.currentMagazineCount;
					inventorySlotsData.currentDurability = inventorySlotsData2.currentDurability;
					inventorySlotsData2.item = item2;
					inventorySlotsData2.itemCountInSlot = itemCountInSlot3;
					inventorySlotsData2.currentMagazineCount = currentMagazineCount2;
					inventorySlotsData2.currentDurability = currentDurability3;
				}
			}
		}
		else
		{
			CollectableItemData item3 = inventorySlotsData.item;
			int itemCountInSlot4 = inventorySlotsData.itemCountInSlot;
			int currentMagazineCount3 = inventorySlotsData.currentMagazineCount;
			float currentDurability4 = inventorySlotsData.currentDurability;
			inventorySlotsData.item = inventorySlotsData2.item;
			inventorySlotsData.itemCountInSlot = inventorySlotsData2.itemCountInSlot;
			inventorySlotsData.currentMagazineCount = inventorySlotsData2.currentMagazineCount;
			inventorySlotsData.currentDurability = inventorySlotsData2.currentDurability;
			inventorySlotsData2.item = item3;
			inventorySlotsData2.itemCountInSlot = itemCountInSlot4;
			inventorySlotsData2.currentMagazineCount = currentMagazineCount3;
			inventorySlotsData2.currentDurability = currentDurability4;
		}
		mainSlot.InventoryItem.UpdateInventoryData(inventorySlotsData);
		connectedSlot.InventoryItem.UpdateInventoryData(inventorySlotsData2);
		mainSlot.HasItem = inventorySlotsData.item != null;
		connectedSlot.HasItem = inventorySlotsData2.item != null;
		mainSlot.inventoryCount = inventorySlotsData.itemCountInSlot;
		connectedSlot.inventoryCount = inventorySlotsData2.itemCountInSlot;
		if (flag || flag2)
		{
			NotifyInventoryChanged(mainSlot, connectedSlot);
		}
		else if (chestUIManager != null && chestUIManager.isPanelOpen && chestUIManager.HasOpenedChest)
		{
			if (IsChestSlot(mainSlot))
			{
				UpdateSingleChestSlot(chestUIManager, mainSlot);
			}
			if (IsChestSlot(connectedSlot))
			{
				UpdateSingleChestSlot(chestUIManager, connectedSlot);
			}
		}
		if (chemistryTableUIManager != null && chemistryTableUIManager.isPanelOpen)
		{
			chemistryTableUIManager.OnSlotsChanged();
		}
	}

	private bool IsWeaponOrTool(CollectableItemData item)
	{
		if (item.itemType != ItemType.TorsoHandTool)
		{
			return item.itemType == ItemType.Weapon;
		}
		return true;
	}

	private void NotifyInventoryChanged(InventorySlot slot1, InventorySlot slot2)
	{
		if (isSilentOperation)
		{
			return;
		}
		if (playerInventory != null)
		{
			playerInventory.UpdateInventoryDataFromSlots();
			TsPlayerNetworkHelper component = playerInventory.GetComponent<TsPlayerNetworkHelper>();
			if (component != null && InventorySaver.Instance != null)
			{
				InventorySaver.Instance.RequestInventoryUpdate(component.steamID);
			}
		}
		if (chestUIManager != null && chestUIManager.isPanelOpen && chestUIManager.HasOpenedChest)
		{
			if (IsChestSlot(slot1))
			{
				UpdateSingleChestSlot(chestUIManager, slot1);
			}
			if (IsChestSlot(slot2))
			{
				UpdateSingleChestSlot(chestUIManager, slot2);
			}
		}
	}

	private void NotifyChemistryTableSlotChanged(InventorySlot slot, InventorySlotsData slotData)
	{
		if (chemistryTableUIManager == null || !chemistryTableUIManager.isPanelOpen)
		{
			return;
		}
		ChemistryTableController currentTable = chemistryTableUIManager.GetCurrentTable();
		if (currentTable == null)
		{
			return;
		}
		if (chemistryTableUIManager.fuelSlot == slot)
		{
			if (slotData.item != null && slotData.itemCountInSlot > 0)
			{
				currentTable.TryAddFuel(slotData.item.itemName, 1);
				if (playerInventory != null)
				{
					playerInventory.AddItemInventory(slotData.item, -1);
				}
				slotData.item = null;
				slotData.itemCountInSlot = 0;
			}
		}
		else if (chemistryTableUIManager.inputSlots.Contains(slot))
		{
			int num = chemistryTableUIManager.inputSlots.IndexOf(slot);
			if (num >= 0 && slotData.item != null && slotData.itemCountInSlot > 0)
			{
				currentTable.TryAddInputItem(num, slotData.item.itemName, slotData.itemCountInSlot);
				if (playerInventory != null)
				{
					playerInventory.AddItemInventory(slotData.item, -slotData.itemCountInSlot);
				}
				slotData.item = null;
				slotData.itemCountInSlot = 0;
			}
		}
		else if (chemistryTableUIManager.outputSlot == slot && (slotData.item == null || slotData.itemCountInSlot == 0))
		{
			chemistryTableUIManager.OnOutputSlotItemTaken();
		}
	}

	private void UpdateSingleChestSlot(ChestUIManager chestUIManager, InventorySlot slot)
	{
		InventorySlot[] componentsInChildren = chestUIManager.GetComponentsInChildren<InventorySlot>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!(componentsInChildren[i] == slot))
			{
				continue;
			}
			InventorySlot inventorySlot = componentsInChildren[i];
			string text = "";
			int count = 0;
			float durability = 0f;
			int magazineCount = 0;
			if (inventorySlot.InventoryItem != null && inventorySlot.InventoryItem.collectableItemData != null && inventorySlot.InventoryItem.collectedCount > 0)
			{
				text = inventorySlot.InventoryItem.collectableItemData.itemName;
				if (string.IsNullOrEmpty(text))
				{
					text = inventorySlot.InventoryItem.collectableItemData.name;
				}
				count = inventorySlot.InventoryItem.collectedCount;
				durability = inventorySlot.InventoryItem.inventoryData?.currentDurability ?? 0f;
				magazineCount = inventorySlot.InventoryItem.inventoryData?.currentMagazineCount ?? 0;
			}
			if (chestUIManager.openedPreArrangedChest != null && PreArrangedChestNetworkManager.Instance != null)
			{
				PreArrangedChestController openedPreArrangedChest = chestUIManager.openedPreArrangedChest;
				PreArrangedChestNetworkManager.Instance.CmdUpdateSlot(openedPreArrangedChest.chunkID, openedPreArrangedChest.objectID, i, text, count, durability, magazineCount);
			}
			else if (chestUIManager.openedChest != null)
			{
				chestUIManager.openedChest.CmdUpdateSlot(i, text, count, durability, magazineCount);
			}
			break;
		}
	}

	private bool IsChestSlot(InventorySlot slot)
	{
		return slot.inventoryID >= 1000;
	}

	private void UpdateChestData(ChestUIManager chestUIManager)
	{
		InventorySlot[] componentsInChildren = chestUIManager.GetComponentsInChildren<InventorySlot>();
		int num = 0;
		if (chestUIManager.openedPreArrangedChest != null)
		{
			num = chestUIManager.openedPreArrangedChest.localInventoryData.Count;
		}
		else if (chestUIManager.openedChest != null)
		{
			num = chestUIManager.openedChest.inventorySlotsData.Count;
		}
		for (int i = 0; i < componentsInChildren.Length && i < num; i++)
		{
			InventorySlot inventorySlot = componentsInChildren[i];
			string itemName = "";
			int count = 0;
			float durability = 0f;
			int magazineCount = 0;
			if (inventorySlot.InventoryItem.collectableItemData != null && inventorySlot.InventoryItem.collectedCount > 0)
			{
				itemName = inventorySlot.InventoryItem.collectableItemData.name;
				count = inventorySlot.InventoryItem.collectedCount;
				durability = inventorySlot.InventoryItem.inventoryData?.currentDurability ?? 0f;
				magazineCount = inventorySlot.InventoryItem.inventoryData?.currentMagazineCount ?? 0;
			}
			if (chestUIManager.openedPreArrangedChest != null && PreArrangedChestNetworkManager.Instance != null)
			{
				PreArrangedChestController openedPreArrangedChest = chestUIManager.openedPreArrangedChest;
				PreArrangedChestNetworkManager.Instance.CmdUpdateSlot(openedPreArrangedChest.chunkID, openedPreArrangedChest.objectID, i, itemName, count, durability, magazineCount);
			}
			else if (chestUIManager.openedChest != null)
			{
				chestUIManager.openedChest.CmdUpdateSlot(i, itemName, count, durability, magazineCount);
			}
		}
		Debug.Log("Chest veriler UI'dan güncellendi");
	}
}
