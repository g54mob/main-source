using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
	[Serializable]
	public class MenuEntry
	{
		public MenuType Type;

		public GameObject Prefab;
	}

	private Dictionary<MenuType, Menu> menuRegistry = new Dictionary<MenuType, Menu>();

	private Stack<Menu> menuStack = new Stack<Menu>();

	[SerializeField]
	private Menu[] menusToRegister;

	[SerializeField]
	private Canvas bgCanvas;

	[SerializeField]
	private Sprite bg;

	[SerializeField]
	private Sprite bgInventory;

	private CanvasGroup bgCanvasGroup;

	private LTDescr bgFadeTween;

	private Action<int, InputAction.CallbackContext> backHandler;

	private Action<int, InputAction.CallbackContext> pauseHandler;

	private bool isInitialized;

	[NonSerialized]
	public bool preventMenuClose;

	public static MenuManager Instance { get; private set; }

	public Menu CurrentMenu
	{
		get
		{
			if (menuStack.Count <= 0)
			{
				return null;
			}
			return menuStack.Peek();
		}
	}

	public event Action<Menu> MenuOpened;

	public event Action<Menu> MenuClosed;

	public event Action LastMenuClosed;

	private void OnEnable()
	{
		backHandler = delegate(int _, InputAction.CallbackContext ctx)
		{
			OnBackInput(ctx);
		};
		pauseHandler = delegate
		{
			OnPauseInput();
		};
	}

	private void OnDisable()
	{
		InputManager.Instance.OnBackPressed -= backHandler;
		InputManager.Instance.OnPausePressed -= pauseHandler;
	}

	private void Awake()
	{
		Instance = this;
		bgCanvasGroup = bgCanvas.GetComponent<CanvasGroup>();
		if (bgCanvasGroup == null)
		{
			bgCanvasGroup = bgCanvas.gameObject.AddComponent<CanvasGroup>();
		}
		Menu[] array = menusToRegister;
		foreach (Menu menu in array)
		{
			RegisterMenu(menu.MenuType, menu);
		}
	}

	private IEnumerator Start()
	{
		Menu[] array = menusToRegister;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Init();
		}
		OpenMenu(MenuType.Title);
		yield return new WaitUntil(() => InputManager.Instance != null);
		InputManager.Instance.OnBackPressed += backHandler;
		InputManager.Instance.OnPausePressed += pauseHandler;
	}

	private void Initialize()
	{
		if (!isInitialized)
		{
			isInitialized = true;
			InputManager.Instance.OnBackPressed += backHandler;
			InputManager.Instance.OnPausePressed += pauseHandler;
		}
	}

	private void OnBackInput(InputAction.CallbackContext ctx)
	{
		if (IsInExpandedTMPDropdown())
		{
			return;
		}
		Menu currentMenu = CurrentMenu;
		if ((object)currentMenu != null && currentMenu.MenuType == MenuType.Title)
		{
			return;
		}
		Menu currentMenu2 = CurrentMenu;
		if (((object)currentMenu2 == null || currentMenu2.MenuType != MenuType.GameOver) && !preventMenuClose)
		{
			if (CurrentMenu != null)
			{
				CloseCurrentMenu();
			}
			else if (ctx.control.device is Keyboard)
			{
				SaveManager.Instance.Save();
				OpenMenu(MenuType.Pause);
			}
		}
	}

	private void OnPauseInput()
	{
		Menu currentMenu = CurrentMenu;
		if ((object)currentMenu != null && currentMenu.MenuType == MenuType.Pause)
		{
			CloseCurrentMenu();
		}
		else if (CurrentMenu == null)
		{
			SaveManager.Instance.Save();
			OpenMenu(MenuType.Pause);
		}
	}

	public Menu GetMenu(MenuType menuType)
	{
		if (menuRegistry.TryGetValue(menuType, out var value))
		{
			return value;
		}
		Debug.LogError($"Tried to get unregistered menu {menuType}");
		return null;
	}

	public void RegisterMenu(MenuType menuType, Menu menu)
	{
		if (menuRegistry.ContainsKey(menuType))
		{
			Debug.LogError($"Tried to register already registered menu {menuType}");
		}
		else
		{
			menuRegistry.Add(menuType, menu);
		}
	}

	public void OpenMenu(MenuType menuType, params object[] menuArgs)
	{
		if (((bool)CurrentMenu && CurrentMenu.MenuType == MenuType.GameOver) || preventMenuClose)
		{
			return;
		}
		if (!menuRegistry.TryGetValue(menuType, out var value))
		{
			Debug.LogError($"Tried to open unregistered menu {menuType}");
			return;
		}
		if (CurrentMenu == value)
		{
			Debug.LogError($"Tried to open already open menu {menuType}");
			return;
		}
		if (CurrentMenu != null)
		{
			UnfocusMenu(CurrentMenu);
		}
		menuStack.Push(value);
		value.Open(menuArgs);
		StartCoroutine(FocusNextFrame(value));
		this.MenuOpened?.Invoke(value);
		HandleBackground(menuType);
		LogMenuStack();
		UpdateMenuSortingOrders();
	}

	public void CloseCurrentMenu()
	{
		if (menuStack.Count == 0 || CurrentMenu.MenuType == MenuType.GameOver || preventMenuClose)
		{
			return;
		}
		StartCoroutine(DelayInteract());
		Menu menu = menuStack.Pop();
		menu.ClearCachedSelection();
		menu.Close();
		StickySelection.Instance.AllowDeselectOnce();
		this.MenuClosed?.Invoke(menu);
		if (menuStack.Count > 0)
		{
			Menu menu2 = menuStack.Peek();
			menu2.Open();
			StartCoroutine(FocusNextFrame(menu2));
			if (menu2.MenuType != MenuType.Map)
			{
				bgCanvas.gameObject.SetActive(value: true);
				if (bgFadeTween != null)
				{
					LeanTween.cancel(bgFadeTween.id);
				}
				bgFadeTween = LeanTween.alphaCanvas(bgCanvasGroup, 0.75f, 0.25f).setIgnoreTimeScale(useUnScaledTime: true);
			}
			else
			{
				bgCanvas.gameObject.SetActive(value: false);
			}
		}
		else
		{
			if (bgFadeTween != null)
			{
				LeanTween.cancel(bgFadeTween.id);
			}
			bgFadeTween = LeanTween.alphaCanvas(bgCanvasGroup, 0f, 0.25f).setOnComplete((Action)delegate
			{
				bgCanvas.gameObject.SetActive(value: false);
			}).setIgnoreTimeScale(useUnScaledTime: true);
			this.LastMenuClosed?.Invoke();
		}
		LogMenuStack();
		UpdateMenuSortingOrders();
	}

	public void CloseAllMenus()
	{
		Menu currentMenu = CurrentMenu;
		if (((object)currentMenu == null || currentMenu.MenuType != MenuType.GameOver) && !preventMenuClose)
		{
			StartCoroutine(DelayInteract());
			while (menuStack.Count > 0)
			{
				Menu menu = menuStack.Pop();
				menu.ClearCachedSelection();
				menu.Close();
			}
			if (bgFadeTween != null)
			{
				LeanTween.cancel(bgFadeTween.id);
			}
			bgFadeTween = LeanTween.alphaCanvas(bgCanvasGroup, 0f, 0.25f).setOnComplete((Action)delegate
			{
				bgCanvas.gameObject.SetActive(value: false);
			}).setIgnoreTimeScale(useUnScaledTime: true);
			this.LastMenuClosed?.Invoke();
			LogMenuStack();
		}
	}

	private void UpdateMenuSortingOrders()
	{
		if (menuStack.Count == 0)
		{
			return;
		}
		int sortingOrder = 0;
		foreach (Menu item in menuStack.Reverse().Skip(1))
		{
			Canvas component = item.GetComponent<Canvas>();
			if (component != null && !item.LockSortingOrder)
			{
				component.overrideSorting = true;
				component.sortingOrder = sortingOrder++;
			}
		}
		bgCanvas.overrideSorting = true;
		bgCanvas.sortingOrder = -5;
		Menu menu = menuStack.Peek();
		Canvas component2 = menu.GetComponent<Canvas>();
		if (component2 != null && !menu.LockSortingOrder)
		{
			component2.overrideSorting = true;
			component2.sortingOrder = sortingOrder;
		}
	}

	private void UnfocusMenu(Menu menu)
	{
		CurrentMenu.CacheCurrentSelection();
		EventSystem.current.SetSelectedGameObject(null);
		menu.SetInteractivity(interactive: false);
	}

	private IEnumerator FocusNextFrame(Menu menu)
	{
		yield return null;
		menu.SetInteractivity(interactive: true);
		GameObject selectionToRestore = menu.GetSelectionToRestore();
		if (selectionToRestore != null)
		{
			EventSystem.current.SetSelectedGameObject(selectionToRestore);
			StickySelection.Instance.SetLastValid(selectionToRestore);
		}
		else
		{
			StickySelection.Instance.AllowDeselectOnce();
		}
	}

	private void HandleBackground(MenuType menuType)
	{
		bool showBG = false;
		if (menuType != MenuType.Map && menuType != MenuType.DifficultySelector && menuType != MenuType.FirstLoadPanel && menuType != MenuType.GameOver)
		{
			showBG = true;
		}
		bgCanvas.gameObject.SetActive(showBG);
		if (bgFadeTween != null)
		{
			LeanTween.cancel(bgFadeTween.id);
		}
		bgFadeTween = LeanTween.alphaCanvas(bgCanvasGroup, showBG ? 0.75f : 0f, 0.25f).setIgnoreTimeScale(useUnScaledTime: true).setOnComplete((Action)delegate
		{
			if (!showBG)
			{
				bgCanvas.gameObject.SetActive(value: false);
			}
		});
		bgCanvas.GetComponent<Image>().sprite = ((menuType == MenuType.Inventory || menuType == MenuType.TrainSelection || menuType == MenuType.ModuleSwapping) ? bgInventory : bg);
	}

	private void LogMenuStack()
	{
		if (menuStack.Count == 0)
		{
			Debug.Log("Menu stack is empty");
			return;
		}
		string text = string.Join(", ", menuStack);
		Debug.Log("Current menu stack (top to bottom): " + text);
	}

	private bool IsInExpandedTMPDropdown()
	{
		GameObject gameObject = EventSystem.current.currentSelectedGameObject;
		bool flag = true;
		while (gameObject != null)
		{
			if (gameObject.TryGetComponent<TMP_Dropdown>(out var _))
			{
				return !flag;
			}
			gameObject = gameObject.transform.parent?.gameObject;
			flag = false;
		}
		return false;
	}

	private IEnumerator DelayInteract()
	{
		InputManager.Instance.BlockInteract(block: true);
		yield return new WaitForEndOfFrame();
		yield return null;
		InputManager.Instance.BlockInteract(block: false);
	}

	public void HandleModuleSwapping()
	{
		if (GameManager.Instance.IsJourneyStarted)
		{
			Menu currentMenu = Instance.CurrentMenu;
			if ((object)currentMenu != null && currentMenu.MenuType == MenuType.ModuleSwapping)
			{
				Instance.CloseCurrentMenu();
				return;
			}
			Instance.CloseAllMenus();
			Instance.OpenMenu(MenuType.ModuleSwapping);
		}
	}
}
