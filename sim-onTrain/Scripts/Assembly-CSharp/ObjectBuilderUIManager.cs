using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ObjectBuilderUIManager : UIPanelBase
{
	public GameObject craftUIPrefab;

	public Transform craftUIPrefabContainer;

	public ScrollRect craftScrollRect;

	private InventoryManagerUI inventoryManager;

	private List<InventorySlot> inventorySlots = new List<InventorySlot>();

	private List<BuildItemUI> buildItems = new List<BuildItemUI>();

	[SerializeField]
	private List<BuildCategorizer> categories = new List<BuildCategorizer>();

	[HideInInspector]
	public BuildCategorizer lastCagegorizer;

	[Header("Wagon")]
	public CollectableItemData wagonItemData;

	public Color selectedButtonColor;

	public Color buttonNormalColor;

	[HideInInspector]
	public GameObject mainPlayer;

	public bool canBuild;

	private Grabber grabber;

	public UnityEvent<bool> OnBuildingModeChanged = new UnityEvent<bool>();

	public static ObjectBuilderUIManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		buildItems = GetComponentsInChildren<BuildItemUI>().ToList();
		inventoryManager = Object.FindObjectOfType<InventoryManagerUI>(includeInactive: true);
		inventorySlots = GetComponentsInChildren<InventorySlot>().ToList();
		if (craftScrollRect == null)
		{
			craftScrollRect = craftUIPrefabContainer.GetComponentInParent<ScrollRect>();
		}
	}

	public void Initialize(TSPlayerController player)
	{
		if (player.isLocalPlayer)
		{
			mainPlayer = player.gameObject;
			grabber = mainPlayer.GetComponent<Grabber>();
		}
	}

	private void Update()
	{
		if (ChatPanelController.isInputFocused)
		{
			return;
		}
		if (isPanelOpen && Input.GetKeyUp(Singleton<UserPrefencesManager>.Instance.keyData.BuildKey))
		{
			ChangePanelActive();
			return;
		}
		KeyData keyData = Singleton<UserPrefencesManager>.Instance.keyData;
		if (!isPanelOpen && Singleton<MainUIManager>.Instance.isInGamePanelOpened && Input.GetKeyUp(keyData.BuildKey) && keyData.BuildKey != keyData.InventoryKey)
		{
			ChangePanelActive();
		}
		else if (TrainGameManager.isInputActive && Input.GetKeyUp(keyData.BuildKey) && keyData.BuildKey != keyData.InventoryKey)
		{
			ChangePanelActive();
		}
	}

	public void SetCategoryItems(List<CollectableItemData> craftingObjects)
	{
		while (buildItems.Count < craftingObjects.Count)
		{
			BuildItemUI component = Object.Instantiate(craftUIPrefab, craftUIPrefabContainer).GetComponent<BuildItemUI>();
			if (component != null)
			{
				buildItems.Add(component);
				continue;
			}
			Debug.LogError("craftUIPrefab'da CraftItemUI component'i bulunamadı!");
			break;
		}
		for (int i = 0; i < craftingObjects.Count; i++)
		{
			buildItems[i].gameObject.SetActive(value: true);
			buildItems[i].SetNeededsPart(craftingObjects[i]);
			buildItems[i].buildObjectData = craftingObjects[i];
		}
		for (int j = craftingObjects.Count; j < buildItems.Count; j++)
		{
			buildItems[j].gameObject.SetActive(value: false);
		}
		if (craftScrollRect != null)
		{
			craftScrollRect.verticalNormalizedPosition = 1f;
			craftScrollRect.horizontalNormalizedPosition = 0f;
		}
	}

	public void OpenBuild(bool skipBuildModeChangeEvent = false)
	{
		if (!canBuild && !skipBuildModeChangeEvent)
		{
			OnBuildingModeChanged.Invoke(arg0: true);
		}
		canBuild = true;
	}

	public void StopBuild(bool skipBuildModeChangeEvent = false)
	{
		if (canBuild && !skipBuildModeChangeEvent)
		{
			OnBuildingModeChanged.Invoke(arg0: false);
		}
		canBuild = false;
	}

	public void ChangePanelActive()
	{
		if (!isPanelOpen)
		{
			if (!WrenchController.isWrenchActive)
			{
				if (Singleton<UserMessagePanel>.Instance != null)
				{
					Singleton<UserMessagePanel>.Instance.ShowWrenchWarningMessage();
				}
				return;
			}
			if (categories.Count > 0)
			{
				BuildCategorizer buildCategorizer = ((lastCagegorizer != null) ? lastCagegorizer : categories[0]);
				foreach (BuildCategorizer category in categories)
				{
					if (category != null)
					{
						category.SetSelected(category == buildCategorizer);
					}
				}
				SetCategoryItems(buildCategorizer.buildingObjects);
				lastCagegorizer = buildCategorizer;
			}
			Singleton<MainUIManager>.Instance.OnInGamePanelOpened.Invoke(this);
			Cursor.lockState = CursorLockMode.Confined;
			ShowPanel();
			TaskEventManager.OnOpenBuildCanvasTaskCompleted.Invoke();
			foreach (InventorySlot inventorySlot in inventorySlots)
			{
				inventorySlot.isShowing = true;
			}
			StopBuild();
			if (PipePlacementController.IsPipeModeActive)
			{
				PipePlacementController pipePlacementController = Object.FindObjectOfType<PipePlacementController>();
				if (pipePlacementController != null)
				{
					pipePlacementController.Deactivate();
				}
			}
			if (inventoryManager != null)
			{
				inventoryManager.isOpenedExternal = true;
				inventoryManager.ShowPanel();
			}
			return;
		}
		Cursor.lockState = CursorLockMode.Locked;
		Singleton<MainUIManager>.Instance.OnInGamePanelClosed.Invoke(this);
		HidePanel();
		foreach (InventorySlot inventorySlot2 in inventorySlots)
		{
			inventorySlot2.isShowing = false;
		}
		if (inventoryManager != null)
		{
			inventoryManager.isOpenedExternal = false;
			inventoryManager.HidePanel();
		}
	}
}
