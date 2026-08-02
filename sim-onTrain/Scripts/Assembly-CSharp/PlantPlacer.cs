using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

public class PlantPlacer : MonoBehaviour, IInteractable
{
	public List<CollectableItemData> acceptableLiquids = new List<CollectableItemData>();

	public float requiredFuelForWatering = 25f;

	[SerializeField]
	private Transform interactionParent;

	private PlantPotController plantPotController;

	[SerializeField]
	private bool isActive;

	private bool isProcessingAction;

	private CollectableItemData lastShownItem;

	private bool didHideBottomInfo;

	[Header("Localization")]
	[SerializeField]
	private LocalizedString addPlantLocalized;

	[SerializeField]
	private LocalizedString addCleanWaterLocalized;

	[SerializeField]
	private LocalizedString collectLocalized;

	private Coroutine restoreBottomInfoCoroutine;

	public GameObject plantingDirt;

	private Renderer dirtRenderer;

	public int materyalIndex;

	public Material dryMaterial;

	public Material wateredMaterial;

	public Transform InteractionParent
	{
		get
		{
			return interactionParent;
		}
		set
		{
			interactionParent = value;
		}
	}

	private PlantPotController PotController
	{
		get
		{
			if (!(plantPotController == null))
			{
				return plantPotController;
			}
			return GetComponentInParent<PlantPotController>();
		}
	}

	public bool IsActive
	{
		get
		{
			return isActive;
		}
		set
		{
			isActive = value;
		}
	}

	public GameObject currentPlantObject { get; set; }

	public CollectableItemData currentPlanting { get; set; }

	private void Awake()
	{
		if (plantingDirt != null)
		{
			dirtRenderer = plantingDirt.GetComponent<Renderer>();
		}
	}

	private void Start()
	{
		StartCoroutine(CheckInitialWaterState());
	}

	private IEnumerator CheckInitialWaterState()
	{
		yield return new WaitForSeconds(0.5f);
		if (TryGetCurrentPlantData(out var data, out var _))
		{
			UpdateDirtColor(data.itHasWater);
		}
	}

	private bool TryGetCurrentPlantData(out PlantData data, out int index)
	{
		data = new PlantData();
		index = -1;
		if (PotController == null)
		{
			return false;
		}
		index = PotController.GetPlacerIndex(this);
		if (index == -1)
		{
			return false;
		}
		if (PotController.plants == null || PotController.plants.Count == 0)
		{
			return false;
		}
		if (index >= PotController.plants.Count)
		{
			return false;
		}
		data = PotController.plants[index];
		return true;
	}

	private void UpdateDirtColor(bool isWatered)
	{
		if (plantingDirt == null)
		{
			Debug.LogWarning("[" + base.gameObject.name + "] PlantingDirt is null!");
			return;
		}
		if (dirtRenderer == null)
		{
			dirtRenderer = plantingDirt.GetComponent<Renderer>();
			if (dirtRenderer == null)
			{
				Debug.LogWarning("[" + base.gameObject.name + "] No Renderer found on plantingDirt!");
				return;
			}
		}
		Material material = (isWatered ? wateredMaterial : dryMaterial);
		if (material == null)
		{
			Debug.LogWarning($"[{base.gameObject.name}] Target material is null! IsWatered: {isWatered}, wateredMaterial: {wateredMaterial}, dryMaterial: {dryMaterial}");
		}
		else
		{
			Material[] materials = dirtRenderer.materials;
			if (materyalIndex >= 0 && materyalIndex < materials.Length)
			{
				materials[materyalIndex] = material;
				dirtRenderer.materials = materials;
			}
			else
			{
				Debug.LogWarning($"[{base.gameObject.name}] Material index {materyalIndex} is out of range! Materials count: {materials.Length}");
			}
		}
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		if (restoreBottomInfoCoroutine != null)
		{
			StopCoroutine(restoreBottomInfoCoroutine);
			restoreBottomInfoCoroutine = null;
		}
		if (InteractionPanel.Instance != null && InteractionPanel.Instance.IsBottomInfoLocked)
		{
			InteractionPanel.Instance.UnlockAndHideBottomInfo();
			didHideBottomInfo = true;
		}
		if (isProcessingAction || PotController == null)
		{
			return;
		}
		int placerIndex = PotController.GetPlacerIndex(this);
		if (placerIndex == -1)
		{
			return;
		}
		EastUpPlayerItemManager component = player.GetComponent<EastUpPlayerItemManager>();
		CollectableItemData collectableItemData = null;
		InventoryItem inventoryItem = null;
		if (component.lastSelectedSlot.InventoryItem != null && component.lastSelectedSlot.InventoryItem.collectableItemData != null)
		{
			collectableItemData = component.lastSelectedSlot.InventoryItem.collectableItemData;
			inventoryItem = component.lastSelectedSlot.InventoryItem;
		}
		if (collectableItemData != lastShownItem)
		{
			lastShownItem = collectableItemData;
		}
		PlantData data;
		int index;
		bool flag = TryGetCurrentPlantData(out data, out index);
		if (flag && data.isPlanted && data.growingStatus >= 1f)
		{
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(collectLocalized, "Collect"));
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				isProcessingAction = true;
				if (NetworkSoundPlayer.Instance != null)
				{
					NetworkSoundPlayer.Instance.PlaySound2DLocal(GameAudios.TakeItemGeneralSound);
				}
				CollectPlantWithRewards(player, data.plantName);
				PotController.CmdCollectPlant(placerIndex);
				StopInteract();
				InteractionPanel.Instance.HideInteraction();
				StartCoroutine(ResetProcessingFlag());
			}
			return;
		}
		bool flag2 = false;
		if (flag && !data.itHasWater && collectableItemData != null && (acceptableLiquids.Contains(collectableItemData) || collectableItemData.itemType == ItemType.Drink) && inventoryItem != null && inventoryItem.HasDurability() && inventoryItem.GetCurrentDurability() >= requiredFuelForWatering)
		{
			flag2 = true;
		}
		if (flag && data.isPlanted && data.growingStatus < 1f)
		{
			if (data.itHasWater)
			{
				return;
			}
			Color value = (flag2 ? InteractionPanel.Instance.positiveColor : InteractionPanel.Instance.negativeColor);
			InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, GetLocalizedString(addCleanWaterLocalized, "Add Clean Water"), hasHoldAction: false, 1f, null, value);
			if (flag2 && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
			{
				isProcessingAction = true;
				if (inventoryItem.ConsumeDurability(requiredFuelForWatering))
				{
					PotController.CmdAddWater(placerIndex);
				}
				Singleton<ItemManager>.Instance.CheckAndTransformToEmptyBottle(inventoryItem, collectableItemData);
				InteractionPanel.Instance.HideInteraction();
				StartCoroutine(ResetProcessingFlag());
			}
			return;
		}
		if (flag && data.isPlanted)
		{
			return;
		}
		int num;
		Color color;
		if (collectableItemData != null)
		{
			if (!PotController.accectablePlantTypes.Contains(collectableItemData.itemType))
			{
				num = (collectableItemData.isPlantable ? 1 : 0);
				if (num == 0)
				{
					goto IL_0348;
				}
			}
			else
			{
				num = 1;
			}
			color = InteractionPanel.Instance.positiveColor;
			goto IL_035e;
		}
		num = 0;
		goto IL_0348;
		IL_0348:
		color = InteractionPanel.Instance.negativeColor;
		goto IL_035e;
		IL_035e:
		Color value2 = color;
		string localizedString = GetLocalizedString(addPlantLocalized, "Add Plant");
		string message = ((num != 0) ? (localizedString + " (" + collectableItemData.GetLocalizedDisplayName() + ")") : localizedString);
		InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, message, hasHoldAction: false, 1f, null, value2);
		if (num != 0 && Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey))
		{
			isProcessingAction = true;
			PotController.CmdAddPlant(placerIndex, collectableItemData.itemName);
			inventoryItem.DecreaseItemCount(1);
			StopInteract();
			InteractionPanel.Instance.HideInteraction();
			StartCoroutine(ResetProcessingFlag());
		}
	}

	private void CollectPlantWithRewards(PlayerInventory player, string plantName)
	{
		CollectableItemData itemFromName = Singleton<ItemManager>.Instance.GetItemFromName(plantName);
		if (!(itemFromName != null) || itemFromName.rewardData == null)
		{
			return;
		}
		foreach (CostData rewardDatum in itemFromName.rewardData)
		{
			if (!(rewardDatum.item != null) || rewardDatum.cost <= 0)
			{
				continue;
			}
			CollectableItemData item = ((rewardDatum.item.mainItem != null) ? rewardDatum.item.mainItem : rewardDatum.item);
			int num = CountItemInSlots(player, item);
			player.AddItemInventory(rewardDatum.item, rewardDatum.cost);
			int num2 = CountItemInSlots(player, item) - num;
			int num3 = rewardDatum.cost - num2;
			if (num3 > 0)
			{
				DropItemToGround(player, rewardDatum.item, num3);
				if (Singleton<UserMessagePanel>.Instance != null)
				{
					Singleton<UserMessagePanel>.Instance.ShowInventoryFullMessage();
				}
			}
		}
	}

	private int CountItemInSlots(PlayerInventory player, CollectableItemData item)
	{
		int num = 0;
		foreach (InventorySlotsData inventorySlotsDatum in player.inventorySlotsData)
		{
			if (inventorySlotsDatum.item == item && inventorySlotsDatum.itemCountInSlot > 0)
			{
				num += inventorySlotsDatum.itemCountInSlot;
			}
		}
		return num;
	}

	private void DropItemToGround(PlayerInventory player, CollectableItemData item, int amount)
	{
		Transform transform = player.GetComponent<TSPlayerController>().activeCamera.transform;
		Vector3 spawnPoint = transform.position + transform.forward;
		Vector3 spawnForward = transform.position + transform.forward * 2f;
		if (item.hasDurability)
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClientWithDurability(item.itemName, amount, spawnPoint, spawnForward, item.startDurability);
		}
		else
		{
			NetworkSceneObjectSpawner.Instance.SpawnDropItemClient(item.itemName, amount, spawnPoint, spawnForward);
		}
	}

	private IEnumerator ResetProcessingFlag()
	{
		yield return new WaitForSeconds(0.5f);
		isProcessingAction = false;
	}

	private void Update()
	{
		if (Time.frameCount % 30 == 0 && TryGetCurrentPlantData(out var data, out var _))
		{
			UpdateDirtColor(data.itHasWater);
		}
	}

	public void StopInteract()
	{
		InteractionPanel.Instance.HideInteraction();
		lastShownItem = null;
		if (didHideBottomInfo)
		{
			restoreBottomInfoCoroutine = StartCoroutine(RestoreBottomInfoDelayed());
		}
	}

	private IEnumerator RestoreBottomInfoDelayed()
	{
		yield return new WaitForSeconds(0.5f);
		didHideBottomInfo = false;
		restoreBottomInfoCoroutine = null;
		EastUpPlayerItemManager eastUpPlayerItemManager = Object.FindObjectOfType<EastUpPlayerItemManager>();
		if (eastUpPlayerItemManager != null)
		{
			eastUpPlayerItemManager.UpdateConsumableInteraction();
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

	public void UpdatePlantVisual(PlantData plantData)
	{
		isProcessingAction = false;
		UpdateDirtColor(plantData.itHasWater);
		if (currentPlantObject != null)
		{
			Object.Destroy(currentPlantObject);
			currentPlantObject = null;
		}
		if (!plantData.isPlanted || string.IsNullOrEmpty(plantData.plantName))
		{
			return;
		}
		currentPlanting = Singleton<ItemManager>.Instance.GetItemFromName(plantData.plantName);
		if (!(currentPlanting == null) && currentPlanting.plantLevelPrefabs != null && currentPlanting.plantLevelPrefabs.Count != 0 && plantData.currentGrowLevel >= 0 && plantData.currentGrowLevel < currentPlanting.plantLevelPrefabs.Count)
		{
			GameObject gameObject = currentPlanting.plantLevelPrefabs[plantData.currentGrowLevel];
			if (!(gameObject == null))
			{
				currentPlantObject = Object.Instantiate(gameObject, base.transform.position, base.transform.rotation, base.transform);
			}
		}
	}

	public void ClearPlant()
	{
		isProcessingAction = false;
		if (currentPlantObject != null)
		{
			Object.Destroy(currentPlantObject);
		}
		currentPlanting = null;
		UpdateDirtColor(isWatered: false);
	}
}
