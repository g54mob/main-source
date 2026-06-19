using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class RadicalMenu : UIComponentMonoBehaviour
{
	public enum MenuType
	{
		PAUSE = 0,
		OPTIONS = 1,
		DEBUG = 2,
		VIDEO_OPTIONS = 3,
		GRAPHICS_OPTIONS = 4,
		POP_UP = 5,
		GALLERY = 6,
		[Obsolete]
		DELETE_PROGRESS = 7,
		JOIN_GAME = 8,
		CHARACTER_CUSTOMIZATION = 9,
		CHARACTER_CHOOSER = 10,
		UI_OPTIONS = 11,
		AUDIO_OPTIONS = 12,
		PERFORMANCE_OPTIONS = 13,
		GAMEPLAY_OPTIONS = 14,
		SELECT_WORLD = 15,
		CREATE_WORLD = 16,
		[Obsolete]
		CHARACTER_CHOOSER_JOIN_GAME = 17,
		[Obsolete]
		DELETE_CHARACTERS = 18,
		[Obsolete]
		DELETE_WORLDS = 19,
		CHARACTER_TYPE_SELECTION = 20,
		CREDITS = 21,
		MANAGE_PLAYERS_MENU = 22,
		MAGIC_MIRROR = 23,
		CREATIVE_CHARACTER_CHOOSER = 24,
		[Obsolete]
		DELETE_CREATIVE_CHARACTERS = 25,
		INVITE_FRIENDS = 26,
		SELECT_SESSION = 27,
		EULA_MENU = 28,
		[Obsolete]
		WORLD_GENERATION = 29,
		LOAD_WORLD_FROM_MOD = 30,
		WORLD_SETTINGS = 31,
		BILIBILI_CONNECT = 32,
		DEVELOPER = 33,
		CONTROL_MAPPER = 34
	}

	public const float _ME_VIRTUAL_HEIGHT_OF_ENTRIES = 2f;

	public const float _ME_START_POSITION_Y = -1f;

	[Header("Menu entry settings:")]
	public float menuEntryVirtualHeight = 2f;

	public float menuEntryStartPositionY = -1f;

	public float menuEntryHorizontalSpacing = 1.4f;

	public bool placeOptionsHorizontally;

	[Header("Other settings:")]
	public bool autoPositioning = true;

	[Tooltip("If assigning elements to this list then only those will be auto positioned.")]
	public List<RadicalMenuOption> autoPositioningOverride;

	public bool rememberSelectedIndex = true;

	public bool pausesGame = true;

	public bool obfuscatesMusic = true;

	public bool fadeOutAudioEffects = true;

	public bool exitClosesMenu = true;

	public bool backClosesMenu = true;

	public bool popsOtherActiveMenus = true;

	public bool playSoundOnActivate;

	public bool useUIElementsForNavigation;

	public bool shouldRenderDescendants;

	[HideInInspector]
	public bool backNeverClosesMenu;

	[HideInInspector]
	public List<RadicalMenuOption> menuOptions = new List<RadicalMenuOption>();

	private bool _startCalled;

	private List<MenuHelperButtons.HelpButtonTypes> helpButtonsNoSelect = new List<MenuHelperButtons.HelpButtonTypes>
	{
		MenuHelperButtons.HelpButtonTypes.NAVIGATE,
		MenuHelperButtons.HelpButtonTypes.BACK
	};

	public int selectedIndex { get; protected set; } = -1;

	protected virtual int DefaultOptionIndex => 0;

	public virtual bool UseCustomHelpButtons => false;

	public RadicalMenuOption GetSelectedMenuOption()
	{
		if (selectedIndex >= 0 && selectedIndex < menuOptions.Count)
		{
			return menuOptions[selectedIndex];
		}
		return null;
	}

	public List<KeyValuePair<int, RadicalMenuOption>> GetAllCurrentlyActiveMenuOptionsAndIndices()
	{
		List<KeyValuePair<int, RadicalMenuOption>> list = new List<KeyValuePair<int, RadicalMenuOption>>();
		for (int i = 0; i < menuOptions.Count; i++)
		{
			if (menuOptions[i].GetActiveStateInCurrentScene() == OptionActiveState.ACTIVE)
			{
				list.Add(new KeyValuePair<int, RadicalMenuOption>(i, menuOptions[i]));
			}
		}
		return list;
	}

	public List<RadicalMenuOption> GetAllCurrentlyActiveMenuOptions()
	{
		List<RadicalMenuOption> list = new List<RadicalMenuOption>();
		foreach (RadicalMenuOption item in (autoPositioningOverride != null && autoPositioningOverride.Count > 0) ? autoPositioningOverride : menuOptions)
		{
			OptionActiveState activeStateInCurrentScene = item.GetActiveStateInCurrentScene();
			if (activeStateInCurrentScene == OptionActiveState.ACTIVE || activeStateInCurrentScene == OptionActiveState.GRAYED_OUT)
			{
				list.Add(item);
			}
		}
		return list;
	}

	public int CountAllCurrentlyActiveMenuOptions()
	{
		int num = 0;
		foreach (RadicalMenuOption menuOption in menuOptions)
		{
			if (menuOption.GetActiveStateInCurrentScene() == OptionActiveState.ACTIVE)
			{
				num++;
			}
		}
		return num;
	}

	private void Start()
	{
		if (shouldRenderDescendants)
		{
			RenderUIComponent(force: true);
			RenderUIComponentOrphans(force: true);
		}
		_startCalled = true;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (_startCalled && shouldRenderDescendants)
		{
			RenderUIComponent(force: true);
			RenderUIComponentOrphans(force: true);
		}
	}

	protected virtual void Awake()
	{
		GetComponentsInChildren(includeInactive: true, menuOptions);
	}

	public virtual void UpdatePosition()
	{
		float num = menuEntryStartPositionY;
		List<RadicalMenuOption> allCurrentlyActiveMenuOptions = GetAllCurrentlyActiveMenuOptions();
		float num2 = 0f;
		float num3 = Mathf.Sign(menuEntryVirtualHeight);
		foreach (RadicalMenuOption item in allCurrentlyActiveMenuOptions)
		{
			float num4 = 0f;
			if (item.labelText != null)
			{
				item.labelText.Render(item.labelText.GetText());
				if (item.labelText.displayedTextStringLinesAmount > 1)
				{
					int displayedTextStringLinesAmount = item.labelText.displayedTextStringLinesAmount;
					num4 = item.labelText.dimensions.height / (float)displayedTextStringLinesAmount * (float)(displayedTextStringLinesAmount - 1);
				}
			}
			num2 += num3 * (Mathf.Abs(menuEntryVirtualHeight) + num4);
			num2 += item.extraVerticalSpacing;
		}
		num += 0.5f * num2;
		if (placeOptionsHorizontally)
		{
			foreach (RadicalMenuOption item2 in allCurrentlyActiveMenuOptions)
			{
				item2.transform.localPosition = new Vector3(0f, item2.transform.localPosition.y, item2.transform.localPosition.z);
			}
			if (allCurrentlyActiveMenuOptions.Count == 1)
			{
				return;
			}
			float num5 = 0f;
			for (int i = 0; i < allCurrentlyActiveMenuOptions.Count; i++)
			{
				num5 += allCurrentlyActiveMenuOptions[i].labelText.dimensions.size.x;
				if (i < allCurrentlyActiveMenuOptions.Count - 1)
				{
					num5 += menuEntryHorizontalSpacing;
				}
			}
			float num6 = (0f - num5) / 2f;
			float num7 = 0f;
			{
				foreach (RadicalMenuOption item3 in allCurrentlyActiveMenuOptions)
				{
					Vector3 localPosition = item3.transform.localPosition;
					item3.transform.localPosition = new Vector3(num6 + num7 + item3.labelText.dimensions.size.x / 2f, localPosition.y, localPosition.z);
					num7 += item3.labelText.dimensions.size.x + menuEntryHorizontalSpacing;
				}
				return;
			}
		}
		foreach (RadicalMenuOption item4 in allCurrentlyActiveMenuOptions)
		{
			num -= item4.extraVerticalSpacing;
			Vector3 localPosition2 = item4.transform.localPosition;
			Vector3 localPosition3 = new Vector3(localPosition2.x, num, localPosition2.z);
			item4.transform.localPosition = localPosition3;
			float num8 = 0f;
			if (item4.labelText != null && item4.labelText.displayedTextStringLinesAmount > 1)
			{
				int displayedTextStringLinesAmount2 = item4.labelText.displayedTextStringLinesAmount;
				num8 = item4.labelText.dimensions.height / (float)displayedTextStringLinesAmount2 * (float)(displayedTextStringLinesAmount2 - 1);
			}
			num -= num3 * (Mathf.Abs(menuEntryVirtualHeight) + num8);
		}
	}

	public virtual void Activate()
	{
		Manager.menu.DisableDefaultMapCategory();
		if (playSoundOnActivate)
		{
			Manager.menu.AttemptToPlayMenuSfx(SfxID.FIXME_menu_select, 0.6f, 0f, reuse: false);
		}
		base.gameObject.SetActive(value: true);
		Manager.camera.ShowHUD(show: false);
		int num = -1;
		for (int i = 0; i < menuOptions.Count; i++)
		{
			OptionActiveState activeStateInCurrentScene = menuOptions[i].GetActiveStateInCurrentScene();
			bool flag = activeStateInCurrentScene == OptionActiveState.ACTIVE || activeStateInCurrentScene == OptionActiveState.GRAYED_OUT;
			if (flag)
			{
				menuOptions[i].OnParentMenuActivation();
			}
			menuOptions[i].gameObject.SetActive(flag);
			if (num == -1 && flag)
			{
				num = i;
			}
		}
		if (Manager.input.SystemIsUsingMouse())
		{
			DeselectAnyCurrentOption(playEffect: false);
		}
		else if (rememberSelectedIndex)
		{
			if (selectedIndex != MathUtilities.Clamp(selectedIndex, 0, menuOptions.Count - 1))
			{
				SelectOptionIndex(num);
			}
			else if (menuOptions[selectedIndex].GetActiveStateInCurrentScene() == OptionActiveState.ACTIVE)
			{
				SelectOptionIndex(selectedIndex);
			}
			else
			{
				SelectOptionIndex(num);
			}
		}
		else if (num >= 0)
		{
			SelectOptionIndex(num);
		}
		if (autoPositioning)
		{
			UpdatePosition();
		}
		RenderUIComponent();
	}

	public virtual void Deactivate(bool pop)
	{
		Manager.menu.EnableDefaultMapCategory();
		base.gameObject.SetActive(value: false);
		Manager.camera.ShowHUD(show: true);
		CleanupAndReset();
	}

	public void CleanupAndReset()
	{
		for (int i = 0; i < menuOptions.Count; i++)
		{
			menuOptions[i].OnCleanupAndReset();
		}
	}

	public bool SelectIndexInDirection(Direction.Id direction)
	{
		RadicalMenuOption selectedMenuOption = GetSelectedMenuOption();
		if (selectedMenuOption == null && !Manager.input.SystemPrefersKeyboardAndMouse())
		{
			return SelectOptionIndex(DefaultOptionIndex);
		}
		if (selectedMenuOption != null)
		{
			if (selectedMenuOption.handleNavigationInternally)
			{
				return selectedMenuOption.NavigateInternally(direction);
			}
			UIelement adjacentUIElement = selectedMenuOption.GetAdjacentUIElement(direction, selectedMenuOption.transform.position);
			for (int i = 0; i < menuOptions.Count; i++)
			{
				if (menuOptions[i] != null && menuOptions[i].IsSelectionEnabled() && adjacentUIElement == menuOptions[i])
				{
					return SelectOptionIndex(i);
				}
			}
		}
		return false;
	}

	public virtual bool SelectNextIndex()
	{
		if (!CanChangeIndex())
		{
			return false;
		}
		if (useUIElementsForNavigation)
		{
			return SelectIndexInDirection(Direction.Id.back);
		}
		if (menuOptions.Count <= 0)
		{
			return false;
		}
		int num = (selectedIndex + 1) % menuOptions.Count;
		while (num != selectedIndex && !menuOptions[num].IsSelectionEnabled())
		{
			num = (num + 1) % menuOptions.Count;
		}
		return SelectOptionIndex(num);
	}

	public virtual bool SelectPrevIndex()
	{
		if (!CanChangeIndex())
		{
			return false;
		}
		if (useUIElementsForNavigation)
		{
			return SelectIndexInDirection(Direction.Id.forward);
		}
		if (menuOptions.Count <= 0)
		{
			return false;
		}
		int num = MathUtilities.Negmod(selectedIndex - 1, menuOptions.Count);
		while (num != selectedIndex && !menuOptions[num].IsSelectionEnabled())
		{
			num = MathUtilities.Negmod(num - 1, menuOptions.Count);
		}
		return SelectOptionIndex(num);
	}

	public bool SelectOptionIndex(int index)
	{
		if (!CanChangeIndex())
		{
			return false;
		}
		if (selectedIndex == index)
		{
			return false;
		}
		UIelement previousInternalOption = null;
		if (selectedIndex != -1 && selectedIndex < menuOptions.Count)
		{
			previousInternalOption = menuOptions[selectedIndex].GetInternalOption();
			menuOptions[selectedIndex].OnDeselected();
		}
		menuOptions[index].OnPreSelected(previousInternalOption);
		selectedIndex = index;
		menuOptions[index].OnSelected();
		OnSelectedOptionChanged();
		return true;
	}

	public void DeselectAnyCurrentOption(bool playEffect = true)
	{
		if (CanChangeIndex())
		{
			if (selectedIndex != -1 && selectedIndex < menuOptions.Count)
			{
				menuOptions[selectedIndex].OnDeselected(playEffect);
			}
			selectedIndex = -1;
			OnSelectedOptionChanged();
		}
	}

	public int GetIndexForOption(UIelement option)
	{
		for (int i = 0; i < menuOptions.Count; i++)
		{
			if (menuOptions[i] == option)
			{
				return i;
			}
		}
		return -1;
	}

	protected virtual void OnSelectedOptionChanged()
	{
	}

	public virtual void OnFirstOpened()
	{
	}

	public virtual bool OnCloseMenuRequest()
	{
		return true;
	}

	public static RadicalMenu TypeToMenu(MenuType type)
	{
		switch (type)
		{
		case MenuType.OPTIONS:
			return Manager.menu.optionsMenu;
		case MenuType.PAUSE:
			return Manager.menu.pauseMenu;
		case MenuType.VIDEO_OPTIONS:
			return Manager.menu.videoOptionsMenu;
		case MenuType.GRAPHICS_OPTIONS:
			return Manager.menu.graphicsOptionsMenu;
		case MenuType.UI_OPTIONS:
			return Manager.menu.uiOptionsMenu;
		case MenuType.PERFORMANCE_OPTIONS:
			return Manager.menu.performanceOptionsMenu;
		case MenuType.POP_UP:
			return Manager.menu.popUpMenu;
		case MenuType.GALLERY:
			return Manager.menu.galleryMenu;
		case MenuType.JOIN_GAME:
			return Manager.menu.joinGameMenu;
		case MenuType.BILIBILI_CONNECT:
			return Manager.menu.bilibiliConnectMenu;
		case MenuType.CHARACTER_TYPE_SELECTION:
			return Manager.menu.characterTypeSelectionMenu;
		case MenuType.CHARACTER_CUSTOMIZATION:
			return Manager.menu.characterCustomizationMenu;
		case MenuType.CHARACTER_CHOOSER:
		case MenuType.CREATIVE_CHARACTER_CHOOSER:
			return Manager.menu.characterChooserMenu;
		case MenuType.SELECT_WORLD:
			return Manager.menu.selectWorldMenu;
		case MenuType.CREATE_WORLD:
			return Manager.menu.createWorldMenu;
		case MenuType.AUDIO_OPTIONS:
			return Manager.menu.audioOptionsMenu;
		case MenuType.GAMEPLAY_OPTIONS:
			return Manager.menu.gameplayOptionsMenu;
		case MenuType.CREDITS:
			return Manager.menu.creditsMenu;
		case MenuType.MANAGE_PLAYERS_MENU:
			return Manager.menu.banListMenu;
		case MenuType.MAGIC_MIRROR:
			return Manager.menu.characterMagicMirrorMenu;
		case MenuType.INVITE_FRIENDS:
			return Manager.menu.inviteFriendsMenu;
		case MenuType.SELECT_SESSION:
			return Manager.menu.selectSessionMenu;
		case MenuType.EULA_MENU:
			return Manager.menu.eulaMenu;
		case MenuType.LOAD_WORLD_FROM_MOD:
			return Manager.menu.loadWorldFromModMenu;
		case MenuType.WORLD_SETTINGS:
			return Manager.menu.worldSettingsMenu;
		case MenuType.DEVELOPER:
			return Manager.menu.developerMenu;
		case MenuType.CONTROL_MAPPER:
			return Manager.menu.controlMappingMenu;
		default:
			Debug.LogError("RadicalMenu.Type " + type.ToString() + " is not supported by RadicalMenu.TypeToMenu on this platform.");
			return null;
		}
	}

	public void ActivateSelectedIndex()
	{
		menuOptions[selectedIndex].OnActivated();
	}

	protected void ResetSelectedIndex()
	{
		selectedIndex = 0;
	}

	protected bool CanChangeIndex()
	{
		if (selectedIndex != -1)
		{
			return menuOptions[selectedIndex].CanBeDeselected();
		}
		return true;
	}

	private void LateUpdate()
	{
		if (Manager.load.IsSceneTransitionOrLoading() || selectedIndex == -1)
		{
			return;
		}
		for (int i = 0; i < menuOptions.Count; i++)
		{
			if (i == selectedIndex)
			{
				menuOptions[i].OnSelectedLateUpdate();
			}
			else
			{
				menuOptions[i].OnDeselectedLateUpdate();
			}
		}
	}

	internal bool SkimRight()
	{
		bool flag = false;
		if (useUIElementsForNavigation)
		{
			flag = SelectIndexInDirection(Direction.Id.right);
		}
		if (!flag)
		{
			if (selectedIndex >= 0)
			{
				return menuOptions[selectedIndex].OnSkimRight();
			}
			return false;
		}
		return true;
	}

	internal bool SkimLeft()
	{
		bool flag = false;
		if (useUIElementsForNavigation)
		{
			flag = SelectIndexInDirection(Direction.Id.left);
		}
		if (!flag)
		{
			if (selectedIndex >= 0)
			{
				return menuOptions[selectedIndex].OnSkimLeft();
			}
			return false;
		}
		return true;
	}

	public bool CanActivateCurrentOption()
	{
		if (GetSelectedMenuOption() != null)
		{
			return GetSelectedMenuOption().CanBeActivated();
		}
		return false;
	}

	public virtual List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		if (CanActivateCurrentOption())
		{
			return Manager.menu.defaultHelpButtons;
		}
		return helpButtonsNoSelect;
	}
}
