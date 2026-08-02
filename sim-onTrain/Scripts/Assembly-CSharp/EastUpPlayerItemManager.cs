using System.Collections.Generic;
using DG.Tweening;
using HQFPSTemplate;
using Synty.AnimationBaseLocomotion.Samples;
using UnityEngine;
using UnityEngine.Localization;

public class EastUpPlayerItemManager : MonoBehaviour
{
	public InventoryController inventoryController;

	public EquipmentInventoryAdder fpsInventory;

	[Header("Right Hand (Unarmed Items)")]
	public Transform unarmedItemParent;

	[ReadOnly]
	public List<UnarmedInventoryItem> unarmedItems = new List<UnarmedInventoryItem>();

	[ReadOnly]
	public UnarmedInventoryItem activeUnarmedItem;

	[Header("Left Hand (Unarmed Items)")]
	public Transform unarmedItemParentLeft;

	[ReadOnly]
	public List<UnarmedInventoryItem> unarmedItemsLeft = new List<UnarmedInventoryItem>();

	[ReadOnly]
	public UnarmedInventoryItem activeUnarmedItemLeft;

	private bool wasDeactivatedByRunning;

	[Header("Cooldown Settings")]
	public float eatingCooldown = 1.25f;

	public float drinkingCooldown = 1.25f;

	public float pouringCooldown = 1.25f;

	public float syringeCooldown = 1.25f;

	public float bandageCooldown = 1.25f;

	public float consumablePowerUpCooldown = 1f;

	private float lastEatingCompleteTime;

	private float lastDrinkingCompleteTime;

	private float lastPouringCompleteTime;

	private float lastSyringeCompleteTime;

	private float lastBandageCompleteTime;

	private float lastConsumablePowerUpCompleteTime;

	public PlayerWeaponController tpsWeaponSelector;

	private PlayerWeaponVisuals weaponVisuals;

	private PlayerInventory playerInventory;

	private Grabber grabber;

	private TSPlayerStatusHolder playerStatusHolder;

	[HideInInspector]
	public GrabbableObject lastGrabbableObject;

	private CollectableItemData lastEquippedItem;

	private PlayerMovement playerMovement;

	private SamplePlayerAnimationController animationController;

	private Interactor interactor;

	public CollectableItemData buildingHammer;

	[Header("Interaction Localization")]
	[SerializeField]
	private LocalizedString eatLocalized;

	[SerializeField]
	private LocalizedString drinkLocalized;

	[SerializeField]
	private LocalizedString pourLocalized;

	[SerializeField]
	private LocalizedString useLocalized;

	private int lastIndex = 1;

	public bool isFireBlocked;

	private bool isShowingConsumableInteraction;

	[HideInInspector]
	public InventorySlot lastSelectedSlot;

	private bool isInitialized;

	private ObjectBuilderUIManager builder;

	private bool holsteredForCPR;

	public int LastIndex
	{
		get
		{
			if (lastIndex > inventoryController.inventorySlots.Count)
			{
				lastIndex = 1;
			}
			else if (lastIndex < 1)
			{
				lastIndex = inventoryController.inventorySlots.Count;
			}
			return lastIndex;
		}
		set
		{
			lastIndex = value;
		}
	}

	private string GetLocalizedString(LocalizedString localizedString, string fallback)
	{
		if (localizedString != null && !localizedString.IsEmpty)
		{
			string localizedString2 = localizedString.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString2))
			{
				return localizedString2;
			}
		}
		return fallback;
	}

	public Animator GetFPSArmsAnimator()
	{
		if (fpsInventory == null || fpsInventory.equipmentHandler == null)
		{
			return null;
		}
		if (fpsInventory.equipmentHandler.FPArmsHandler == null)
		{
			return null;
		}
		return fpsInventory.equipmentHandler.FPArmsHandler.Animator;
	}

	public void SetCPRHolster(bool active)
	{
		if (fpsInventory == null)
		{
			return;
		}
		if (active)
		{
			if (!holsteredForCPR && !(lastEquippedItem == null))
			{
				holsteredForCPR = true;
				fpsInventory.TryUnequipItem();
			}
		}
		else if (holsteredForCPR)
		{
			holsteredForCPR = false;
			if (lastEquippedItem != null)
			{
				fpsInventory.TryEquipItem(lastEquippedItem);
			}
		}
	}

	private void OnEnable()
	{
		unarmedItems = new List<UnarmedInventoryItem>(unarmedItemParent.GetComponentsInChildren<UnarmedInventoryItem>(includeInactive: true));
		if (unarmedItemParentLeft != null)
		{
			unarmedItemsLeft = new List<UnarmedInventoryItem>(unarmedItemParentLeft.GetComponentsInChildren<UnarmedInventoryItem>(includeInactive: true));
		}
		playerInventory = GetComponent<PlayerInventory>();
		grabber = GetComponent<Grabber>();
		fpsInventory = GetComponent<EquipmentInventoryAdder>();
		weaponVisuals = ((tpsWeaponSelector != null) ? tpsWeaponSelector.GetComponent<PlayerWeaponVisuals>() : null);
		playerStatusHolder = GetComponent<TSPlayerStatusHolder>();
		playerMovement = GetComponent<PlayerMovement>();
		animationController = GetComponent<SamplePlayerAnimationController>();
		interactor = GetComponent<Interactor>();
		builder = Object.FindObjectOfType<ObjectBuilderUIManager>();
		builder.OnBuildingModeChanged.AddListener(OnBuildModeChanged);
		Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		Singleton<ObjectManager>.Instance?.OnObjectPlaced.AddListener(delegate(GrabbableObject x)
		{
			if (x == lastGrabbableObject)
			{
				lastGrabbableObject = null;
			}
		});
	}

	private void OnDisable()
	{
		Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.RemoveListener(Initialize);
		playerInventory.OnCollectableCollected.RemoveListener(CheckOnCollectableAdded);
		Singleton<ObjectManager>.Instance?.OnObjectPlaced.RemoveListener(delegate(GrabbableObject x)
		{
			if (x == lastGrabbableObject)
			{
				lastGrabbableObject = null;
			}
		});
	}

	public void CloseFireInput()
	{
		isFireBlocked = true;
	}

	public void OpenFireInput()
	{
		StartCoroutine(DuubyUtilities.WaitEndOfFixedUpdate(delegate
		{
			isFireBlocked = false;
		}));
	}

	private void Initialize(TSPlayerController player)
	{
		if (!isInitialized)
		{
			playerInventory.OnCollectableCollected.AddListener(CheckOnCollectableAdded);
			ChooseItem(9);
			DOVirtual.DelayedCall(1f, delegate
			{
				ChooseItem(1);
			});
		}
	}

	private void CheckOnCollectableAdded(CollectableItemData data, int count, float durability)
	{
		inventoryController.inventorySlots.Find((InventorySlot x) => x.inventoryID == lastSelectedSlot.inventoryID);
		if (activeUnarmedItem != null || activeUnarmedItemLeft != null)
		{
			CollectableItemData selectedSlotItemData = GetSelectedSlotItemData();
			bool num = activeUnarmedItem != null && selectedSlotItemData != activeUnarmedItem.itemData;
			bool flag = activeUnarmedItemLeft != null && selectedSlotItemData != activeUnarmedItemLeft.itemData;
			if (num || flag)
			{
				StartCoroutine(DuubyUtilities.WaitForEndOfTheFrame(delegate
				{
					ChooseItem(LastIndex, directlyOpen: true);
				}));
			}
			else
			{
				UpdateConsumableInteraction();
			}
		}
		else if (lastEquippedItem == null && lastEquippedItem != buildingHammer && count > 0)
		{
			StartCoroutine(DuubyUtilities.WaitForEndOfTheFrame(delegate
			{
				ChooseItem(LastIndex, directlyOpen: true);
			}));
		}
	}

	private void Update()
	{
		DropItem();
		CheckStoryPaperLearning();
		CheckRunningState();
		CheckHoldableDurability();
		if (grabber != null && grabber.selectedGrabbleObject == null && lastGrabbableObject != null)
		{
			lastGrabbableObject = null;
		}
		bool flag = (grabber != null && grabber.selectedGrabbleObject != null) || PipePlacementController.IsPipeModeActive;
		if (lastEquippedItem != null && lastEquippedItem == buildingHammer && !flag)
		{
			fpsInventory.TryUnequipItem();
			tpsWeaponSelector.UnEquip();
			lastEquippedItem = null;
		}
		if (TrainGameManager.isInputActive && !TrainGameManager.isMouseLocked)
		{
			ChooseItemWithScroll();
			if (0 == 0)
			{
				CheckFood();
				CheckDrink();
				CheckBandage();
				CheckSyringe();
				CheckConsumablePowerUp();
			}
			else if (Input.GetMouseButtonDown(1))
			{
				Debug.Log($"[Bandage-Check] BLOCKED by interactable: {interactor.lastInteractable}");
			}
			ChooseItemWithKeyboard();
		}
	}

	private void CheckRunningState()
	{
		if (fpsInventory == null || fpsInventory.player == null)
		{
			return;
		}
		bool active = fpsInventory.player.Run.Active;
		bool flag = playerStatusHolder != null && playerStatusHolder.isCPR;
		if (active || flag)
		{
			if (playerStatusHolder != null)
			{
				if (playerStatusHolder.isEating)
				{
					playerStatusHolder.StopEating();
				}
				if (playerStatusHolder.isDrinking)
				{
					playerStatusHolder.StopDrinking();
				}
				if (playerStatusHolder.isBandaging)
				{
					playerStatusHolder.StopBandaging();
				}
			}
			if (activeUnarmedItem != null && activeUnarmedItem.holdAnimationType != HoldAnimationType.HoldFishingRod)
			{
				DeactivateCurrentUnarmedItem();
				wasDeactivatedByRunning = true;
			}
		}
		else if (!active && !flag && wasDeactivatedByRunning)
		{
			wasDeactivatedByRunning = false;
			CollectableItemData selectedSlotItemData = GetSelectedSlotItemData();
			if (selectedSlotItemData != null && (selectedSlotItemData.itemType == ItemType.Food || selectedSlotItemData.itemType == ItemType.Drink || selectedSlotItemData.itemType == ItemType.Holdable || selectedSlotItemData.itemType == ItemType.Bandage || selectedSlotItemData.itemType == ItemType.EatPowerUp || selectedSlotItemData.itemType == ItemType.DrinkPowerUp))
			{
				ActivateUnarmedItem(selectedSlotItemData);
			}
		}
	}

	private void CheckHoldableDurability()
	{
		if ((activeUnarmedItem == null && activeUnarmedItemLeft == null) || lastSelectedSlot == null || lastSelectedSlot.InventoryItem == null)
		{
			return;
		}
		CollectableItemData collectableItemData = lastSelectedSlot.InventoryItem.collectableItemData;
		if (!(collectableItemData == null) && collectableItemData.itemType == ItemType.Holdable && collectableItemData.hasDurability && collectableItemData.continuousDurabilityDecrease)
		{
			float amount = collectableItemData.durabilityDecreasePerUse * Time.deltaTime;
			if (!lastSelectedSlot.InventoryItem.DecreaseDurability(amount) || lastSelectedSlot.InventoryItem.inventoryData.currentDurability <= 0f)
			{
				DeactivateCurrentUnarmedItem();
			}
		}
	}

	private void CheckStoryPaperLearning()
	{
		if (!(lastSelectedSlot == null) && !(lastSelectedSlot.InventoryItem == null))
		{
			CollectableItemData collectableItemData = lastSelectedSlot.InventoryItem.collectableItemData;
			if (!(collectableItemData == null) && collectableItemData.itemType == ItemType.StoryPaper && Input.GetKeyDown(KeyCode.F))
			{
				LearnStoryPaper(collectableItemData);
			}
		}
	}

	private void LearnStoryPaper(CollectableItemData storyData)
	{
		if (!storyData.isLearned && CollectableDataSaver.Instance != null)
		{
			CollectableDataSaver.Instance.SetItemLearned(storyData.itemName, learned: true);
			StoryBoardPanel storyBoardPanel = Object.FindObjectOfType<StoryBoardPanel>();
			if (storyBoardPanel != null)
			{
				storyBoardPanel.RefreshStoryPapers();
			}
		}
	}

	public void CheckFood()
	{
		if (lastSelectedSlot == null || lastSelectedSlot.InventoryItem == null || lastEquippedItem == buildingHammer)
		{
			return;
		}
		CollectableItemData collectableItemData = lastSelectedSlot.InventoryItem.collectableItemData;
		if (collectableItemData == null || collectableItemData.itemType != ItemType.Food)
		{
			if (playerStatusHolder.isEating)
			{
				playerStatusHolder.StopEating();
			}
		}
		else if (Input.GetMouseButtonDown(1) && !(Time.time < lastEatingCompleteTime + eatingCooldown))
		{
			playerStatusHolder.StartEating();
		}
	}

	public void CheckDrink()
	{
		if (lastSelectedSlot == null || lastSelectedSlot.InventoryItem == null || lastEquippedItem == buildingHammer)
		{
			return;
		}
		CollectableItemData collectableItemData = lastSelectedSlot.InventoryItem.collectableItemData;
		if (collectableItemData == null || collectableItemData.itemType != ItemType.Drink)
		{
			if (playerStatusHolder.isDrinking)
			{
				playerStatusHolder.StopDrinking();
			}
			return;
		}
		bool num = IsDirtyWater(collectableItemData);
		bool flag = IsEmptyWaterBottle(collectableItemData);
		if (!num && !flag && Input.GetMouseButtonDown(1))
		{
			if (Time.time < lastDrinkingCompleteTime + drinkingCooldown)
			{
				return;
			}
			playerStatusHolder.StartDrinking();
		}
		if (!flag && Input.GetMouseButtonDown(2) && !(Time.time < lastPouringCompleteTime + pouringCooldown))
		{
			playerStatusHolder.StartPouring();
		}
	}

	private bool IsDirtyWater(CollectableItemData item)
	{
		if (item == null || Singleton<ItemManager>.Instance == null)
		{
			return false;
		}
		foreach (WaterBottleData waterBottleData in Singleton<ItemManager>.Instance.waterBottleDatas)
		{
			if (waterBottleData.dirtyWaterBottle == item)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsEmptyWaterBottle(CollectableItemData item)
	{
		if (item == null || Singleton<ItemManager>.Instance == null)
		{
			return false;
		}
		foreach (WaterBottleData waterBottleData in Singleton<ItemManager>.Instance.waterBottleDatas)
		{
			if (waterBottleData.emptyBottle == item)
			{
				return true;
			}
		}
		return false;
	}

	public void CheckBandage()
	{
		if (lastSelectedSlot == null || lastSelectedSlot.InventoryItem == null || lastEquippedItem == buildingHammer)
		{
			if (Input.GetMouseButtonDown(1))
			{
				Debug.Log(string.Format("[Bandage-Check] BLOCKED - slot:{0} item:{1} isHammer:{2}", (lastSelectedSlot != null) ? "OK" : "NULL", (lastSelectedSlot?.InventoryItem != null) ? "OK" : "NULL", lastEquippedItem == buildingHammer));
			}
			return;
		}
		CollectableItemData collectableItemData = lastSelectedSlot.InventoryItem.collectableItemData;
		if (collectableItemData == null || collectableItemData.itemType != ItemType.Bandage)
		{
			if (playerStatusHolder.isBandaging)
			{
				playerStatusHolder.StopBandaging();
			}
		}
		else if (Input.GetMouseButtonDown(1))
		{
			bool flag = Time.time < lastBandageCompleteTime + bandageCooldown;
			Debug.Log($"[Bandage-Check] RightClick detected - item:{collectableItemData.itemName} type:{collectableItemData.itemType} onCooldown:{flag}");
			if (!flag)
			{
				playerStatusHolder.StartBandaging();
			}
		}
	}

	public void CheckSyringe()
	{
		if (lastSelectedSlot == null || lastSelectedSlot.InventoryItem == null || lastEquippedItem == buildingHammer)
		{
			return;
		}
		CollectableItemData collectableItemData = lastSelectedSlot.InventoryItem.collectableItemData;
		if (collectableItemData == null || collectableItemData.itemType != ItemType.Syringe)
		{
			if (playerStatusHolder.isUsingSyringe)
			{
				playerStatusHolder.StopUsingSyringe();
			}
		}
		else if (Input.GetMouseButtonDown(1) && !(Time.time < lastSyringeCompleteTime + syringeCooldown))
		{
			playerStatusHolder.StartUsingSyringe();
		}
	}

	public void CheckConsumablePowerUp()
	{
		if (lastSelectedSlot == null || lastSelectedSlot.InventoryItem == null || lastEquippedItem == buildingHammer)
		{
			if (playerStatusHolder.isUsingConsumablePowerUp)
			{
				playerStatusHolder.StopConsumablePowerUp();
			}
			return;
		}
		CollectableItemData collectableItemData = lastSelectedSlot.InventoryItem.collectableItemData;
		if (collectableItemData == null || (collectableItemData.itemType != ItemType.EatPowerUp && collectableItemData.itemType != ItemType.DrinkPowerUp))
		{
			if (playerStatusHolder.isUsingConsumablePowerUp)
			{
				playerStatusHolder.StopConsumablePowerUp();
			}
		}
		else if (Input.GetMouseButtonDown(1))
		{
			Debug.Log($"[ConsumablePowerUp] RightClick - item:{collectableItemData.itemName} type:{collectableItemData.itemType} isUsing:{playerStatusHolder.isUsingConsumablePowerUp} cooldown:{Time.time < lastConsumablePowerUpCompleteTime + consumablePowerUpCooldown}");
			if (!(Time.time < lastConsumablePowerUpCompleteTime + consumablePowerUpCooldown))
			{
				playerStatusHolder.StartConsumablePowerUp();
			}
		}
	}

	public void CheckItemSlots()
	{
		if (lastEquippedItem != null && lastEquippedItem == buildingHammer)
		{
			return;
		}
		lastSelectedSlot = inventoryController.inventorySlots.Find((InventorySlot x) => x.inventoryID == lastIndex);
		if (lastSelectedSlot.InventoryItem == null)
		{
			Debug.Log("first");
			if (lastEquippedItem != null || activeUnarmedItem != null || activeUnarmedItemLeft != null)
			{
				Debug.Log("second");
				ChooseItem(LastIndex, directlyOpen: true);
			}
			return;
		}
		CollectableItemData collectableItemData = lastSelectedSlot.InventoryItem.collectableItemData;
		if ((!(collectableItemData != null) || !(lastEquippedItem == collectableItemData)) && (!(collectableItemData != null) || (collectableItemData.itemType != ItemType.Food && collectableItemData.itemType != ItemType.Drink && collectableItemData.itemType != ItemType.Holdable && collectableItemData.itemType != ItemType.Bandage && collectableItemData.itemType != ItemType.EatPowerUp && collectableItemData.itemType != ItemType.DrinkPowerUp) || ((!(activeUnarmedItem != null) || !(activeUnarmedItem.itemData == collectableItemData)) && (!(activeUnarmedItemLeft != null) || !(activeUnarmedItemLeft.itemData == collectableItemData)))))
		{
			if (collectableItemData != null && lastEquippedItem != collectableItemData)
			{
				ChooseItem(lastIndex, directlyOpen: true);
			}
			else if (collectableItemData == null && (lastEquippedItem != null || activeUnarmedItem != null || activeUnarmedItemLeft != null))
			{
				ChooseItem(lastIndex, directlyOpen: true);
			}
		}
	}

	private void DropItem()
	{
		if (TrainGameManager.isInputActive && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.DropKey) && !(lastSelectedSlot == null) && !(lastSelectedSlot.InventoryItem == null) && !lastSelectedSlot.InventoryItem.isEmpty)
		{
			lastSelectedSlot.InventoryItem.DropItemFromSlots();
		}
	}

	public void ChooseItemWithIndex(int index)
	{
		LastIndex = index + 1;
		ChooseItem(LastIndex);
	}

	public bool IsSelectedSlotEmpty()
	{
		if (!(lastSelectedSlot == null) && !(lastSelectedSlot.InventoryItem == null))
		{
			return lastSelectedSlot.InventoryItem.collectableItemData == null;
		}
		return true;
	}

	private void ChooseItemWithKeyboard()
	{
		for (int i = 1; i < 10; i++)
		{
			if (Input.GetKeyDown((KeyCode)(48 + i)))
			{
				LastIndex = i;
				ChooseItem(LastIndex);
			}
		}
	}

	private void ChooseItemWithScroll()
	{
		if (Input.mouseScrollDelta.y > 0f)
		{
			LastIndex--;
			ChooseItem(LastIndex);
		}
		else if (Input.mouseScrollDelta.y < 0f)
		{
			LastIndex++;
			ChooseItem(LastIndex);
		}
	}

	private void OnBuildModeChanged(bool activated)
	{
		if (!activated)
		{
			return;
		}
		if (playerStatusHolder != null)
		{
			if (playerStatusHolder.isEating)
			{
				playerStatusHolder.StopEating();
			}
			if (playerStatusHolder.isDrinking)
			{
				playerStatusHolder.StopDrinking();
			}
			if (playerStatusHolder.isBandaging)
			{
				playerStatusHolder.StopBandaging();
			}
		}
		DeactivateCurrentUnarmedItem();
		HideConsumableInteraction();
		if (grabber != null && !grabber.isBuildMenuPlacement)
		{
			lastEquippedItem = buildingHammer;
			fpsInventory.TryEquipItem(buildingHammer);
		}
	}

	public CollectableItemData GetSelectedSlotItemData()
	{
		if (lastSelectedSlot == null)
		{
			return null;
		}
		if (lastSelectedSlot.InventoryItem == null)
		{
			return null;
		}
		return lastSelectedSlot.InventoryItem.collectableItemData;
	}

	public void ChooseItem(int index, bool directlyOpen = false)
	{
		LastIndex = index;
		InventorySlot inventorySlot = inventoryController.inventorySlots.Find((InventorySlot x) => x.inventoryID == index);
		wasDeactivatedByRunning = false;
		if (lastSelectedSlot == inventorySlot && !directlyOpen)
		{
			return;
		}
		if (playerStatusHolder != null)
		{
			if (playerStatusHolder.isEating)
			{
				playerStatusHolder.StopEating();
			}
			if (playerStatusHolder.isDrinking)
			{
				playerStatusHolder.StopDrinking();
			}
			if (playerStatusHolder.isUsingSyringe)
			{
				playerStatusHolder.StopUsingSyringe();
			}
			if (playerStatusHolder.isBandaging)
			{
				playerStatusHolder.StopBandaging();
			}
		}
		if (lastSelectedSlot != null)
		{
			lastSelectedSlot.SetSelection(select: false);
		}
		if (PipePlacementController.IsPipeModeActive)
		{
			PipePlacementController pipePlacementController = Object.FindObjectOfType<PipePlacementController>();
			if (pipePlacementController != null)
			{
				pipePlacementController.Deactivate();
			}
		}
		if (grabber.selectedGrabbleObject != null)
		{
			bool skipBuildModeChangeEvent = inventorySlot != null && inventorySlot.InventoryItem != null && inventorySlot.InventoryItem.collectableItemData != null && inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.Placeable;
			grabber.CancelBuild(directlyDestroy: true, skipBuildModeChangeEvent);
			lastGrabbableObject = null;
		}
		if (inventorySlot != null)
		{
			lastSelectedSlot = inventorySlot;
			inventorySlot.SetSelection(select: true);
		}
		if (inventorySlot == null || inventorySlot.InventoryItem.collectableItemData == null)
		{
			if (lastEquippedItem != null)
			{
				fpsInventory.TryUnequipItem();
				tpsWeaponSelector.UnEquip();
				lastEquippedItem = null;
			}
			DeactivateCurrentUnarmedItem();
			HideConsumableInteraction();
			return;
		}
		if (inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.Weapon || inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.TorsoHandTool || inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.Syringe || inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.FullBodyHandTool)
		{
			if (lastEquippedItem != null)
			{
				fpsInventory.TryUnequipItem();
				tpsWeaponSelector.UnEquip();
			}
			DeactivateCurrentUnarmedItem();
			lastEquippedItem = inventorySlot.InventoryItem.collectableItemData;
			fpsInventory.TryEquipItem(inventorySlot.InventoryItem.collectableItemData);
			tpsWeaponSelector.EquipWeapon(lastEquippedItem);
		}
		else if (inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.Placeable)
		{
			if (lastEquippedItem != null)
			{
				fpsInventory.TryUnequipItem();
				tpsWeaponSelector.UnEquip();
			}
			DeactivateCurrentUnarmedItem();
			lastEquippedItem = null;
			GrabbableObject grabbable = (lastGrabbableObject = Object.Instantiate(inventorySlot.InventoryItem.collectableItemData.itemPrefab).GetComponent<GrabbableObject>());
			grabber.GrabObject(grabbable);
		}
		else
		{
			if (lastEquippedItem != null)
			{
				fpsInventory.TryUnequipItem();
				tpsWeaponSelector.UnEquip();
				lastEquippedItem = null;
			}
			if (inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.Food || inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.Drink || inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.Holdable || inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.Bandage || inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.EatPowerUp || inventorySlot.InventoryItem.collectableItemData.itemType == ItemType.DrinkPowerUp)
			{
				ActivateUnarmedItem(inventorySlot.InventoryItem.collectableItemData);
			}
			else
			{
				DeactivateCurrentUnarmedItem();
			}
		}
		UpdateConsumableInteraction();
	}

	public void ActivateUnarmedItem(CollectableItemData itemData)
	{
		DeactivateCurrentUnarmedItem();
		if (!(itemData == null))
		{
			UnarmedInventoryItem unarmedInventoryItem = unarmedItems.Find((UnarmedInventoryItem x) => x.itemData == itemData);
			if (unarmedInventoryItem != null)
			{
				unarmedInventoryItem.gameObject.SetActive(value: true);
				activeUnarmedItem = unarmedInventoryItem;
				PlayHoldAnimation();
			}
			UnarmedInventoryItem unarmedInventoryItem2 = unarmedItemsLeft.Find((UnarmedInventoryItem x) => x.itemData == itemData);
			if (unarmedInventoryItem2 != null)
			{
				unarmedInventoryItem2.gameObject.SetActive(value: true);
				activeUnarmedItemLeft = unarmedInventoryItem2;
				PlayHoldAnimationLeft();
			}
			if ((unarmedInventoryItem != null && unarmedInventoryItem.isLockedRunningAnimation) || (unarmedInventoryItem2 != null && unarmedInventoryItem2.isLockedRunningAnimation))
			{
				SetRunningAnimationLockState(isLocked: true);
			}
			if (((unarmedInventoryItem != null && unarmedInventoryItem.holdAnimationType == HoldAnimationType.HoldGasLamp) || (unarmedInventoryItem2 != null && unarmedInventoryItem2.holdAnimationType == HoldAnimationType.HoldGasLamp)) && weaponVisuals != null)
			{
				weaponVisuals.SetOilLampActive(active: true);
			}
		}
	}

	public void DeactivateCurrentUnarmedItem()
	{
		bool flag = (activeUnarmedItem != null && activeUnarmedItem.isLockedRunningAnimation) || (activeUnarmedItemLeft != null && activeUnarmedItemLeft.isLockedRunningAnimation);
		bool num = (activeUnarmedItem != null && activeUnarmedItem.holdAnimationType == HoldAnimationType.HoldGasLamp) || (activeUnarmedItemLeft != null && activeUnarmedItemLeft.holdAnimationType == HoldAnimationType.HoldGasLamp);
		if (activeUnarmedItem != null)
		{
			activeUnarmedItem.gameObject.SetActive(value: false);
			activeUnarmedItem = null;
			ResetAllHoldAnimations();
		}
		if (activeUnarmedItemLeft != null)
		{
			activeUnarmedItemLeft.gameObject.SetActive(value: false);
			activeUnarmedItemLeft = null;
			ResetAllHoldAnimationsLeft();
		}
		if (flag)
		{
			SetRunningAnimationLockState(isLocked: false);
		}
		if (num && weaponVisuals != null)
		{
			weaponVisuals.SetOilLampActive(active: false);
		}
	}

	private void SetRunningAnimationLockState(bool isLocked)
	{
		if (playerMovement != null)
		{
			playerMovement.isLockedRunningAnimation = isLocked;
			if (isLocked && fpsInventory != null && fpsInventory.player != null && fpsInventory.player.Run.Active)
			{
				fpsInventory.player.Run.ForceStop();
			}
		}
		if (animationController != null)
		{
			animationController.isLockedRunningAnimation = isLocked;
			if (isLocked)
			{
				animationController.ForceStopSprint();
			}
		}
	}

	public void PlayHoldAnimation()
	{
		if (activeUnarmedItem == null)
		{
			return;
		}
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			ResetAllHoldAnimations();
			if (activeUnarmedItem.holdAnimationType != HoldAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItem.holdAnimationKey, value: true);
			}
		}
	}

	public void PlayUseAnimation()
	{
		if (activeUnarmedItem == null)
		{
			return;
		}
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			if (activeUnarmedItem.holdAnimationType != HoldAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItem.holdAnimationKey, value: false);
			}
			if (activeUnarmedItem.useAnimationType != UseAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItem.useAnimationKey, value: true);
			}
		}
	}

	public void StopUseAnimation()
	{
		if (activeUnarmedItem == null)
		{
			return;
		}
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			if (activeUnarmedItem.useAnimationType != UseAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItem.useAnimationKey, value: false);
			}
			if (activeUnarmedItem.holdAnimationType != HoldAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItem.holdAnimationKey, value: true);
			}
		}
	}

	public void StartEatingCooldown()
	{
		lastEatingCompleteTime = Time.time;
	}

	public void StartDrinkingCooldown()
	{
		lastDrinkingCompleteTime = Time.time;
	}

	public void StartPouringCooldown()
	{
		lastPouringCompleteTime = Time.time;
	}

	public void StartSyringeCooldown()
	{
		lastSyringeCompleteTime = Time.time;
	}

	public void StartBandageCooldown()
	{
		lastBandageCompleteTime = Time.time;
	}

	public void StartConsumablePowerUpCooldown()
	{
		lastConsumablePowerUpCompleteTime = Time.time;
	}

	private void ResetAllHoldAnimations()
	{
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			fPSArmsAnimator.SetBool(AnimationKeys.HoldFruit, value: false);
			fPSArmsAnimator.SetBool(AnimationKeys.HoldBottle, value: false);
			fPSArmsAnimator.SetBool(AnimationKeys.HoldBigEat, value: false);
			fPSArmsAnimator.SetBool(AnimationKeys.HoldGasLamp, value: false);
			fPSArmsAnimator.SetBool(AnimationKeys.HoldFishingRod, value: false);
		}
	}

	private void ResetAllUseAnimations()
	{
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			fPSArmsAnimator.SetBool(AnimationKeys.EatingFruit, value: false);
			fPSArmsAnimator.SetBool(AnimationKeys.BottleUse, value: false);
			fPSArmsAnimator.SetBool(AnimationKeys.EatingBig, value: false);
		}
	}

	public void PlayHoldAnimationLeft()
	{
		if (activeUnarmedItemLeft == null)
		{
			return;
		}
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			ResetAllHoldAnimationsLeft();
			if (activeUnarmedItemLeft.holdAnimationType != HoldAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItemLeft.holdAnimationKey, value: true);
			}
		}
	}

	public void PlayUseAnimationLeft()
	{
		if (activeUnarmedItemLeft == null)
		{
			return;
		}
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			if (activeUnarmedItemLeft.holdAnimationType != HoldAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItemLeft.holdAnimationKey, value: false);
			}
			if (activeUnarmedItemLeft.useAnimationType != UseAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItemLeft.useAnimationKey, value: true);
			}
		}
	}

	public void StopUseAnimationLeft()
	{
		if (activeUnarmedItemLeft == null)
		{
			return;
		}
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			if (activeUnarmedItemLeft.useAnimationType != UseAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItemLeft.useAnimationKey, value: false);
			}
			if (activeUnarmedItemLeft.holdAnimationType != HoldAnimationType.None)
			{
				fPSArmsAnimator.SetBool(activeUnarmedItemLeft.holdAnimationKey, value: true);
			}
		}
	}

	private void ResetAllHoldAnimationsLeft()
	{
		Animator fPSArmsAnimator = GetFPSArmsAnimator();
		if (!(fPSArmsAnimator == null))
		{
			fPSArmsAnimator.SetBool(AnimationKeys.HoldGasLamp, value: false);
			fPSArmsAnimator.SetBool(AnimationKeys.HoldFishingRod, value: false);
		}
	}

	public void UpdateConsumableInteraction()
	{
		if (InteractionPanel.Instance == null)
		{
			return;
		}
		CollectableItemData selectedSlotItemData = GetSelectedSlotItemData();
		if (selectedSlotItemData == null || lastEquippedItem == buildingHammer)
		{
			HideConsumableInteraction();
			return;
		}
		List<InteractionData> list = new List<InteractionData>();
		switch (selectedSlotItemData.itemType)
		{
		case ItemType.Food:
			list.Add(new InteractionData(KeyCode.Mouse1, GetLocalizedString(eatLocalized, "Eat")));
			break;
		case ItemType.Drink:
		{
			bool flag = IsDirtyWater(selectedSlotItemData);
			if (IsEmptyWaterBottle(selectedSlotItemData))
			{
				HideConsumableInteraction();
				return;
			}
			if (!flag)
			{
				list.Add(new InteractionData(KeyCode.Mouse1, GetLocalizedString(drinkLocalized, "Drink")));
			}
			list.Add(new InteractionData(KeyCode.Mouse2, GetLocalizedString(pourLocalized, "Pour")));
			break;
		}
		case ItemType.Bandage:
			list.Add(new InteractionData(KeyCode.Mouse1, GetLocalizedString(useLocalized, "Use")));
			break;
		case ItemType.Syringe:
			list.Add(new InteractionData(KeyCode.Mouse1, GetLocalizedString(useLocalized, "Use")));
			break;
		case ItemType.EatPowerUp:
			list.Add(new InteractionData(KeyCode.Mouse1, GetLocalizedString(useLocalized, "Use")));
			break;
		case ItemType.DrinkPowerUp:
			list.Add(new InteractionData(KeyCode.Mouse1, GetLocalizedString(useLocalized, "Use")));
			break;
		default:
			HideConsumableInteraction();
			return;
		}
		InteractionPanel.Instance.ShowBottomInfoLocked(list);
		isShowingConsumableInteraction = true;
	}

	private void HideConsumableInteraction()
	{
		if (isShowingConsumableInteraction)
		{
			if (InteractionPanel.Instance != null)
			{
				InteractionPanel.Instance.UnlockAndHideBottomInfo();
			}
			isShowingConsumableInteraction = false;
		}
	}
}
