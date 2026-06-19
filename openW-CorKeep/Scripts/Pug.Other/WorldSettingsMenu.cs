using System;
using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class WorldSettingsMenu : RadicalMenu
{
	[Serializable]
	public struct SubMenuTab<T> where T : WorldSettingsSubMenu
	{
		public T subMenu;

		public WorldSettingsTab tab;
	}

	public SubMenuTab<WorldInfoMenu> worldInfoMenu;

	public SubMenuTab<WorldGenerationMenu> worldGenerationMenu;

	public SubMenuTab<WorldContentMenu> worldContentMenu;

	public bool isCreateNewWorldMenu;

	public RadicalMenuOption_Done createNewWorldButton;

	private WorldInfo _worldInfo;

	private List<SubMenuTab<WorldSettingsSubMenu>> _allMenus = new List<SubMenuTab<WorldSettingsSubMenu>>();

	private int _currentSubMenuIndex = -1;

	protected override void Awake()
	{
		base.Awake();
		_allMenus.Add(new SubMenuTab<WorldSettingsSubMenu>
		{
			subMenu = worldInfoMenu.subMenu,
			tab = worldInfoMenu.tab
		});
		_allMenus.Add(new SubMenuTab<WorldSettingsSubMenu>
		{
			subMenu = worldGenerationMenu.subMenu,
			tab = worldGenerationMenu.tab
		});
		if (worldContentMenu.subMenu != null)
		{
			_allMenus.Add(new SubMenuTab<WorldSettingsSubMenu>
			{
				subMenu = worldContentMenu.subMenu,
				tab = worldContentMenu.tab
			});
		}
		if (!(worldContentMenu.subMenu != null))
		{
			return;
		}
		List<RadicalMenuOption> list = worldContentMenu.subMenu.InitializeOptions();
		Debug.Log($"Initialized {list.Count} options for world content menu.");
		foreach (RadicalMenuOption item in list)
		{
			menuOptions.Add(item);
		}
		RadicalMenuOption radicalMenuOption = list[0];
		radicalMenuOption.topUIElements.Add(worldContentMenu.tab);
		foreach (SubMenuTab<WorldSettingsSubMenu> allMenu in _allMenus)
		{
			allMenu.tab.bottomUIElements.Add(radicalMenuOption);
		}
	}

	public void LateUpdate()
	{
		UpdateSubMenusAvailable();
		if (isCreateNewWorldMenu)
		{
			createNewWorldButton.SetInteractable(CanCreateWorldFromCurrentSettings());
		}
	}

	public override void Activate()
	{
		base.Activate();
		if (isCreateNewWorldMenu)
		{
			_worldInfo = new WorldInfo
			{
				version = 1,
				seedString = PugRandom.GenerateWorldSeed(),
				worldGenerationType = WorldGenerationType.FullRelease
			};
			_worldInfo.MarkAllContentBundlesAsViewed();
		}
		else
		{
			_worldInfo = Manager.saves.GetWorldInfo();
		}
		UpdateSubMenusAvailable();
		ActivateMenuIndex(0);
	}

	public override void Deactivate(bool pop)
	{
		if (!isCreateNewWorldMenu)
		{
			Manager.saves.WriteWorldInfo();
		}
		_worldInfo = null;
		_currentSubMenuIndex = -1;
		base.Deactivate(pop);
	}

	private void UpdateSubMenusAvailable()
	{
		worldGenerationMenu.tab.gameObject.SetActive(_worldInfo.worldGenerationType == WorldGenerationType.FullRelease);
		if (worldContentMenu.tab != null)
		{
			worldContentMenu.tab.gameObject.SetActive(_worldInfo.worldGenerationType == WorldGenerationType.FullRelease);
			if (!_worldInfo.HasViewedAllContentBundles())
			{
				worldContentMenu.tab.HighlightUntilActivated();
				worldContentMenu.tab.SetTooltipUntilActivated("Menu/NewContentAvailableTooltip");
			}
		}
	}

	private void ActivateMenuIndex(int index)
	{
		if (_currentSubMenuIndex == index)
		{
			return;
		}
		if (_currentSubMenuIndex != -1 && _allMenus[_currentSubMenuIndex].subMenu.HasPendingChanges())
		{
			ConfirmDiscardCurrentChanges(index);
			return;
		}
		if (_currentSubMenuIndex != -1)
		{
			_allMenus[_currentSubMenuIndex].subMenu.Deactivate();
		}
		for (int i = 0; i < _allMenus.Count; i++)
		{
			_allMenus[i].subMenu.gameObject.SetActive(i == index);
			_allMenus[i].tab.SetActive(i == index);
		}
		_allMenus[index].subMenu.Activate(_worldInfo);
		_currentSubMenuIndex = index;
		RenderUIComponent(force: true);
	}

	private void ConfirmDiscardCurrentChanges(int nextIndex)
	{
		Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/DiscardUnconfirmedChanges", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, delegate(PopupResponse response)
		{
			if (!response.IsCancel)
			{
				_allMenus[_currentSubMenuIndex].subMenu.Reset();
				ActivateMenuIndex(nextIndex);
			}
		}, new List<string> { "cancelDialogue", "Menu/Reset" }, 10f, 0.8f, 0, 16f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: true, 0f);
	}

	public void ActivateWorldInfoMenu()
	{
		ActivateMenuIndex(0);
	}

	public void ActivateWorldGenerationMenu()
	{
		ActivateMenuIndex(1);
	}

	public void ActivateWorldContentMenu()
	{
		ActivateMenuIndex(2);
	}

	public bool CanCreateWorldFromCurrentSettings()
	{
		return HasValidWorldName();
	}

	public void HighlightSettingBlockingWorldCreation()
	{
		if (!HasValidWorldName())
		{
			ActivateMenuIndex(0);
			worldInfoMenu.subMenu.nameInput.Shake();
		}
	}

	private bool HasValidWorldName()
	{
		return _worldInfo.name.Trim() != "";
	}

	public void CreateWorldFromCurrentSettings()
	{
		if (_worldInfo.worldGenerationType != WorldGenerationType.FullRelease)
		{
			_worldInfo.worldGenerationSettings.Clear();
		}
		_worldInfo.creationDate = new CreationDate(DateTime.Now);
		Manager.saves.GetWorldInfo().CopyValuesFrom(_worldInfo);
		Manager.saves.WriteWorldInfo();
		MenuType type = ((_worldInfo.worldGenerationType == WorldGenerationType.Creative) ? MenuType.CREATIVE_CHARACTER_CHOOSER : MenuType.CHARACTER_CHOOSER);
		Manager.menu.PopMenu();
		Manager.menu.PushMenu(type);
	}
}
