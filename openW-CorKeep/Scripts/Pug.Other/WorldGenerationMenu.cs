using System;
using System.Collections.Generic;
using PugWorldGen;

public class WorldGenerationMenu : WorldSettingsSubMenu, IScrollable
{
	private const WorldGenerationSettingLevel DEFAULT_LEVEL = WorldGenerationSettingLevel.Normal;

	public UIScrollWindow uiScrollWindow;

	public UIComponentMonoBehaviour scrollingContent;

	public List<SelectParamValueOption> options;

	public RadicalMenuOption_Apply resetOption;

	public bool readOnly;

	private WorldInfo _worldInfo;

	public override void Activate(WorldInfo worldInfo)
	{
		_worldInfo = worldInfo;
		EnsureGenerationSettingsInitialized(worldInfo);
		InitializeOptionsFromWorldInfo(worldInfo);
		UpdateReadOnly();
		UpdateButtonStates();
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public bool IsBottomElementSelected()
	{
		for (int num = options.Count - 1; num >= 0; num--)
		{
			if (options[num].gameObject.activeInHierarchy)
			{
				return options[num] == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public bool IsTopElementSelected()
	{
		foreach (SelectParamValueOption option in options)
		{
			if (option.gameObject.activeInHierarchy)
			{
				return option == Manager.ui.currentSelectedUIElement;
			}
		}
		return false;
	}

	public float GetCurrentWindowHeight()
	{
		return scrollingContent.GetUIComponentRenderHeight();
	}

	private void EnsureGenerationSettingsInitialized(WorldInfo worldInfo)
	{
		List<LevelWorldGenerationSetting> worldGenerationSettings = worldInfo.worldGenerationSettings;
		int num = Enum.GetNames(typeof(WorldGenerationSettingType)).Length;
		for (int i = 0; i < num; i++)
		{
			WorldGenerationSettingType type = (WorldGenerationSettingType)i;
			if (!HasValueForSetting(worldGenerationSettings, type))
			{
				worldGenerationSettings.Add(new LevelWorldGenerationSetting
				{
					type = type,
					level = WorldGenerationSettingLevel.Normal
				});
			}
		}
	}

	private bool HasValueForSetting(List<LevelWorldGenerationSetting> settings, WorldGenerationSettingType type)
	{
		foreach (LevelWorldGenerationSetting setting in settings)
		{
			if (setting.type == type)
			{
				return true;
			}
		}
		return false;
	}

	private void InitializeOptionsFromWorldInfo(WorldInfo worldInfo)
	{
		foreach (LevelWorldGenerationSetting worldGenerationSetting in worldInfo.worldGenerationSettings)
		{
			int type = (int)worldGenerationSetting.type;
			options[type].activeIndex = (int)worldGenerationSetting.level;
		}
	}

	private void UpdateWorldInfoFromOptions()
	{
		foreach (LevelWorldGenerationSetting worldGenerationSetting in _worldInfo.worldGenerationSettings)
		{
			int type = (int)worldGenerationSetting.type;
			worldGenerationSetting.level = (WorldGenerationSettingLevel)options[type].activeIndex;
		}
	}

	public override void Reset()
	{
		_worldInfo.worldGenerationSettings.Clear();
		EnsureGenerationSettingsInitialized(_worldInfo);
		InitializeOptionsFromWorldInfo(_worldInfo);
		UpdateButtonStates();
		uiScrollWindow.SetScrollValue(0f);
	}

	private void UpdateReadOnly()
	{
		foreach (SelectParamValueOption option in options)
		{
			option.readOnly = readOnly;
		}
		resetOption.gameObject.SetActive(!readOnly);
	}

	private bool HasAnyNonDefaultSettings()
	{
		foreach (LevelWorldGenerationSetting worldGenerationSetting in _worldInfo.worldGenerationSettings)
		{
			if (worldGenerationSetting.level != WorldGenerationSettingLevel.Normal)
			{
				return true;
			}
		}
		return false;
	}

	private void Update()
	{
		if (!readOnly)
		{
			UpdateButtonStates();
		}
		UpdateWorldInfoFromOptions();
	}

	private void UpdateButtonStates()
	{
		resetOption.SetInteractable(HasAnyNonDefaultSettings());
	}

	public void OnReset()
	{
		if (HasAnyNonDefaultSettings())
		{
			Manager.menu.centerPopUpText.StartNewDisplaySequence("Menu/ResetToDefaultsDialog", null, menuInputCooldown: true, 0f, 1.5f, useUnscaledTime: true, 0f, 1f, localize: true, TextManager.FontFace.boldMedium, ResetCallBack, new List<string> { "cancelDialogue", "Menu/Reset" }, 10f, 0.8f, 0, 16f, secondOptionPopsAllMenus: false, pauseGame: true, holdToConfirm: false, localizePlaceholders: true, 0f);
		}
	}

	private void ResetCallBack(PopupResponse response)
	{
		if (response.IsConfirm)
		{
			Reset();
		}
	}
}
