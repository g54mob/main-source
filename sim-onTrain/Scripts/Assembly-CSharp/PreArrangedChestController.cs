using System.Collections.Generic;
using DG.Tweening;
using Mirror;
using UnityEngine;

public class PreArrangedChestController : MonoBehaviour, IInteractable
{
	[Header("Pre-Arranged Items")]
	[Tooltip("Sahnede onceden ayarlanacak itemler")]
	public List<PreArrangedItemData> preArrangedItems = new List<PreArrangedItemData>();

	[Header("Chest Settings")]
	public int inventorySlotMaxCapacity = 32;

	public int slotCount = 20;

	[Header("Chunk Registration")]
	public int chunkID;

	public int objectID;

	[Header("Visuals")]
	public Transform chestCap;

	public Vector3 chestOpeningRotation;

	public bool useChestCap = true;

	public bool useOpeningSound = true;

	[Header("Interaction")]
	[SerializeField]
	private Transform interactionParent;

	[HideInInspector]
	public List<InventorySlotsDataNetwork> localInventoryData = new List<InventorySlotsDataNetwork>();

	[HideInInspector]
	public bool isOpen;

	private bool isActive;

	private ChestUIManager chestUIManager;

	private bool isShowingInteraction;

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

	private void Awake()
	{
		chestUIManager = Object.FindObjectOfType<ChestUIManager>();
	}

	private void OnEnable()
	{
		IsActive = true;
	}

	private void Start()
	{
		ChunkDataHolder componentInParent = GetComponentInParent<ChunkDataHolder>();
		if (componentInParent != null)
		{
			chunkID = componentInParent.chunkID;
		}
		PreArrangedChestNetworkManager.Register(this);
		if (NetworkServer.active && PreArrangedChestNetworkManager.Instance != null)
		{
			PreArrangedChestNetworkManager.Instance.InitializeChest(chunkID, objectID, preArrangedItems, slotCount, inventorySlotMaxCapacity);
		}
	}

	private void OnDisable()
	{
		PreArrangedChestNetworkManager.Unregister(this);
	}

	public void Interact(PlayerInventory player, Vector3 hitPoint)
	{
		Debug.Log($"[PreArrangedChest] Interact called - IsActive:{IsActive}, ManagerInstance:{PreArrangedChestNetworkManager.Instance != null}, chunkID:{chunkID}, objectID:{objectID}");
		if (!IsActive)
		{
			Debug.LogWarning("[PreArrangedChest] IsActive false, return");
			return;
		}
		if (PreArrangedChestNetworkManager.Instance == null)
		{
			Debug.LogWarning("[PreArrangedChest] Manager Instance null, return");
			return;
		}
		InteractionPanel.Instance.ShowInteractionOverlay(base.transform, player.transform, Singleton<UserPrefencesManager>.Instance.keyData.InteractKey, "Open Chest");
		if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.InteractKey) && !Singleton<MainUIManager>.Instance.isInGamePanelOpened && chestUIManager.closeCooldown <= 0f)
		{
			chestUIManager.openedPreArrangedChest = this;
			chestUIManager.openedChest = null;
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(chestUIManager);
			if (NetworkServer.active)
			{
				List<InventorySlotsDataNetwork> chestInventory = PreArrangedChestNetworkManager.Instance.GetChestInventory(chunkID, objectID);
				if (chestInventory != null)
				{
					SetInventoryData(chestInventory.ToArray());
				}
			}
			PreArrangedChestNetworkManager.Instance.CmdOpenChest(chunkID, objectID);
			chestUIManager.ShowPanel();
		}
		if (!isShowingInteraction)
		{
			isShowingInteraction = true;
		}
	}

	public void StopInteract()
	{
		isShowingInteraction = false;
		InteractionPanel.Instance.HidePanels();
	}

	public void OpenChestAnimation()
	{
		if (useChestCap && chestCap != null)
		{
			chestCap.DOKill();
			chestCap.DOLocalRotate(chestOpeningRotation, 1f).SetEase(Ease.Linear);
		}
		if (useOpeningSound && NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySoundLocalOnly(GameAudios.WoodenDoorOpen, base.transform.position);
		}
	}

	public void CloseChestAnimation()
	{
		if (useChestCap && chestCap != null)
		{
			chestCap.DOKill();
			chestCap.DOLocalRotateQuaternion(Quaternion.identity, 1f);
		}
		if (useOpeningSound && NetworkSoundPlayer.Instance != null)
		{
			NetworkSoundPlayer.Instance.PlaySoundLocalOnly(GameAudios.WoodenDoorClose, base.transform.position);
		}
	}

	public void SetInventoryData(InventorySlotsDataNetwork[] slots)
	{
		localInventoryData.Clear();
		localInventoryData.AddRange(slots);
		if (chestUIManager != null && chestUIManager.isPanelOpen && chestUIManager.openedPreArrangedChest == this)
		{
			chestUIManager.LoadChestData();
		}
	}

	public void Register()
	{
	}

	private void OnDestroy()
	{
		if (isShowingInteraction && InteractionPanel.Instance != null)
		{
			InteractionPanel.Instance.HideInteraction();
		}
	}
}
