using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Inventory : Menu
{
	private enum InventoryMode
	{
		Module = 0,
		Relic = 1,
		Upgrade = 2
	}

	[Header("Module")]
	[SerializeField]
	private float camMoveToModuleTime = 0.1f;

	[SerializeField]
	private Image selectModuleImage;

	private Module[] modules;

	private int moduleIndex;

	[Header("Grids")]
	[SerializeField]
	private InventoryGrid? gridUpgrades;

	[SerializeField]
	private InventoryGrid? gridRelics;

	[Header("Cards")]
	[SerializeField]
	private ModuleCard cardModule;

	[SerializeField]
	private TextMeshProUGUI upgradeNameTxt;

	[SerializeField]
	private TextMeshProUGUI upgradeRarityText;

	[SerializeField]
	private TextMeshProUGUI upgradeDescriptionTxt;

	[SerializeField]
	private TextMeshProUGUI relicNameTxt;

	[SerializeField]
	private TextMeshProUGUI relicTypeTxt;

	[SerializeField]
	private TextMeshProUGUI relicDescriptionTxt;

	[SerializeField]
	private TrainCard cardTrain;

	[Header("Other")]
	[SerializeField]
	private Toggle showAllUpgrades;

	[SerializeField]
	private Module playerAndGeneralStats;

	[SerializeField]
	private Tweener[] inventoryChildrenTw;

	[SerializeField]
	private Image backgroundToFade;

	[SerializeField]
	[Range(0f, 1f)]
	private float startAlpha;

	[SerializeField]
	[Range(0f, 1f)]
	private float endAlpha = 0.75f;

	[SerializeField]
	private GameObject aGo;

	[SerializeField]
	private GameObject dGo;

	[SerializeField]
	private GameObject ltGo;

	[SerializeField]
	private GameObject rtGo;

	[SerializeField]
	private Image moduleSelectorImg;

	[SerializeField]
	private Sprite moduleSelectorStop;

	[SerializeField]
	private Sprite moduleSelectorMoving;

	[SerializeField]
	private Scrollbar scrollBar;

	[SerializeField]
	private ScrollRect scrollRect;

	[SerializeField]
	private Button handleUp;

	[SerializeField]
	private Button handleDown;

	[SerializeField]
	private AudioSource moduleSelectionAudioSource;

	private Action<int, InputAction.CallbackContext> inputHandler;

	private int relicIndexBeforeMove;

	private InventoryMode currentMode;

	private const float stickDeadZone = 0.2f;

	private bool stickReleased = true;

	public override void Init()
	{
		inputHandler = (Action<int, InputAction.CallbackContext>)Delegate.Combine(inputHandler, (Action<int, InputAction.CallbackContext>)delegate
		{
			HandleInventoryInput();
		});
		InputManager.Instance.OnInventoryPressed += inputHandler;
		InputManager.Instance.OnLT += delegate
		{
			TryNavigateModules(Dir.Left);
		};
		InputManager.Instance.OnRT += delegate
		{
			TryNavigateModules(Dir.Right);
		};
		gridUpgrades.SlotEnhancementPressed += HandleUpgradePressed;
		gridRelics.SlotEnhancementPressed += HandleRelicPressed;
		showAllUpgrades.onValueChanged.AddListener(OnShowAllToggleChanged);
		handleUp.onClick.AddListener(buttonScrollUp);
		handleDown.onClick.AddListener(buttonScrollDown);
	}

	private void Update()
	{
		if (!GameManager.Instance.IsJourneyStarted || !base.gameObject.activeSelf)
		{
			return;
		}
		relicIndexBeforeMove = ((currentMode == InventoryMode.Relic) ? GetSelectedIndex(gridRelics) : (-1));
		Vector2 move = InputManager.Instance.GetAnyIdentifiedMoveInput().Move;
		if (move.magnitude < 0.2f)
		{
			stickReleased = true;
		}
		else if (stickReleased)
		{
			stickReleased = false;
			if (move.x < -0.2f)
			{
				TryNavigateModules(Dir.Left);
			}
			else if (move.x > 0.2f)
			{
				TryNavigateModules(Dir.Right);
			}
		}
	}

	public void HandleInventoryInput()
	{
		if (GameManager.Instance.IsJourneyStarted)
		{
			Menu currentMenu = MenuManager.Instance.CurrentMenu;
			if ((object)currentMenu != null && currentMenu.MenuType == MenuType.Inventory)
			{
				MenuManager.Instance.CloseCurrentMenu();
				return;
			}
			MenuManager.Instance.CloseAllMenus();
			MenuManager.Instance.OpenMenu(MenuType.Inventory);
		}
	}

	protected override void OnOpen()
	{
		modules = Train.Instance.Modules.Where((Module m) => m).ToArray();
		Array.Resize(ref modules, modules.Length + 1);
		modules[modules.Length - 1] = playerAndGeneralStats;
		SetModule(modules[moduleIndex]);
		moduleSelectorImg.sprite = moduleSelectorStop;
		Color c = backgroundToFade.color;
		backgroundToFade.color = new Color(c.r, c.g, c.b, 0f);
		GetComponent<AudioSource>().Play();
		LeanTween.value(backgroundToFade.gameObject, startAlpha, endAlpha, inventoryChildrenTw[0].Duration).setIgnoreTimeScale(useUnScaledTime: true).setOnUpdate(delegate(float alpha)
		{
			backgroundToFade.color = new Color(c.r, c.g, c.b, alpha);
		});
		if (InputManager.Instance.IsLastInputGamepad)
		{
			aGo.SetActive(value: false);
			dGo.SetActive(value: false);
			rtGo.SetActive(value: true);
			ltGo.SetActive(value: true);
		}
		else
		{
			aGo.SetActive(value: true);
			dGo.SetActive(value: true);
			rtGo.SetActive(value: false);
			ltGo.SetActive(value: false);
		}
		Tweener[] array = inventoryChildrenTw;
		for (int num = 0; num < array.Length; num++)
		{
			array[num].Move(isToEndPos: true);
		}
		cardTrain.SetInfo();
		ClearTextFields();
		if (gridRelics != null)
		{
			InventoryGrid? inventoryGrid = gridRelics;
			Enhancement[] relicsInInventory = UpgradeManager.Instance.RelicsInInventory;
			inventoryGrid.Populate(relicsInInventory);
		}
		gridUpgrades.RemoveOutlines(null);
		gridRelics.RemoveOutlines(null);
		if (HasAnyInteractableSlot(gridUpgrades))
		{
			SelectTopLeft(gridUpgrades);
		}
		else if (HasAnyInteractableSlot(gridRelics))
		{
			SelectTopLeft(gridRelics);
		}
		gridUpgrades.RemoveOutlines(null);
		gridRelics.RemoveOutlines(null);
	}

	protected override void OnClose()
	{
		Tweener[] array = inventoryChildrenTw;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Reset();
		}
	}

	private void TryNavigateModules(Dir dir)
	{
		if (base.gameObject.activeSelf)
		{
			int num = ((dir != Dir.Right) ? 1 : (-1));
			int num2 = moduleIndex;
			int num3 = modules.Length;
			do
			{
				moduleIndex = (moduleIndex + num + num3) % num3;
			}
			while (modules[moduleIndex] == null && moduleIndex != num2);
			if (modules[moduleIndex] != null)
			{
				SetModule(modules[moduleIndex]);
			}
		}
	}

	private void SelectTopLeft(InventoryGrid grid)
	{
		StartCoroutine(SelectTopLeftNextFrame(grid));
	}

	private IEnumerator SelectTopLeftNextFrame(InventoryGrid grid)
	{
		yield return null;
		for (int i = 0; i < grid.slots.Length; i++)
		{
			if (grid.slots[i].Button.interactable)
			{
				EventSystem.current.SetSelectedGameObject(grid.slots[i].gameObject);
				break;
			}
		}
	}

	private void SetModule(Module module)
	{
		LeanTween.cancel(CameraController.Instance.gameObject);
		LeanTween.move(CameraController.Instance.gameObject, module.transform.position, camMoveToModuleTime).setEase(LeanTweenType.easeInOutQuad).setIgnoreTimeScale(useUnScaledTime: true)
			.setOnStart(delegate
			{
				moduleSelectorImg.sprite = moduleSelectorMoving;
			})
			.setOnComplete((Action)delegate
			{
				moduleSelectorImg.sprite = moduleSelectorStop;
			});
		cardModule.SetEnhancement(module.Enhancement);
		moduleSelectionAudioSource.Play();
		ClearTextFields();
		gridUpgrades.RemoveOutlines(null);
		if (gridUpgrades != null && !showAllUpgrades.isOn)
		{
			InventoryGrid? inventoryGrid = gridUpgrades;
			Enhancement[] upgrades = module.StatsSO.Upgrades;
			inventoryGrid.Populate(upgrades);
		}
		else if (gridUpgrades != null && showAllUpgrades.isOn)
		{
			gridUpgrades.PopulateAll(modules);
		}
		gridUpgrades.SetupSlotNavigation(gridRelics);
		gridRelics.SetupSlotNavigation(gridUpgrades);
		if (HasAnyInteractableSlot(gridUpgrades))
		{
			SelectTopLeft(gridUpgrades);
		}
		else if (HasAnyInteractableSlot(gridRelics))
		{
			SelectTopLeft(gridRelics);
		}
	}

	private void HandleRelicPressed(Enhancement relic)
	{
		relicNameTxt.text = relic.NameKey.GetLocalizedString();
		relicTypeTxt.text = StringFormatHelper.GetRarityString(relic);
		relicDescriptionTxt.text = relic.DescriptionKey.GetLocalizedString();
	}

	private void HandleUpgradePressed(Enhancement upgrade)
	{
		upgradeNameTxt.text = upgrade.NameKey.GetLocalizedString();
		upgradeRarityText.text = StringFormatHelper.GetRarityString(upgrade);
		upgradeDescriptionTxt.text = upgrade.DescriptionKey.GetLocalizedString();
	}

	private void OnShowAllToggleChanged(bool isOn)
	{
		SetModule(modules[moduleIndex]);
		gridUpgrades.RemoveOutlines(null);
	}

	private bool IsRelicSlot(GameObject obj)
	{
		InventorySlot[] slots = gridRelics.slots;
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].gameObject == obj)
			{
				return true;
			}
		}
		return false;
	}

	private bool IsInBottomRow(InventoryGrid grid, int index)
	{
		return index / grid.Cols == grid.Rows - 1;
	}

	private void TrySelectBelow(InventoryGrid grid, int index)
	{
		if (IsInBottomRow(grid, index))
		{
			currentMode = InventoryMode.Module;
			grid.RemoveOutlines(null);
			StickySelection.Instance.ForceDeselect();
		}
	}

	private bool HasAnyInteractableSlot(InventoryGrid grid)
	{
		InventorySlot[] slots = grid.slots;
		for (int i = 0; i < slots.Length; i++)
		{
			if (slots[i].Button.interactable)
			{
				return true;
			}
		}
		return false;
	}

	private int GetSelectedIndex(InventoryGrid grid)
	{
		GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
		if (currentSelectedGameObject == null)
		{
			return -1;
		}
		for (int i = 0; i < grid.slots.Length; i++)
		{
			if (grid.slots[i].Button.gameObject == currentSelectedGameObject)
			{
				return i;
			}
		}
		return -1;
	}

	private void ClearTextFields()
	{
		upgradeDescriptionTxt.text = "";
		upgradeNameTxt.text = "";
		upgradeRarityText.text = "";
		relicDescriptionTxt.text = "";
		relicNameTxt.text = "";
		relicTypeTxt.text = "";
	}

	private void OnDestroy()
	{
		InputManager.Instance.OnInventoryPressed += inputHandler;
	}

	private void buttonScrollUp()
	{
		if (scrollBar.value != 0f)
		{
			scrollBar.value = Mathf.Clamp01(scrollBar.value - 0.2f);
		}
	}

	private void buttonScrollDown()
	{
		if (scrollBar.value != 1f)
		{
			scrollBar.value = Mathf.Clamp01(scrollBar.value + 0.2f);
		}
	}
}
