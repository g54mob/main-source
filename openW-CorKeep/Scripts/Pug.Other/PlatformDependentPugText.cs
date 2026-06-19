using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using Rewired;
using UnityEngine;

public class PlatformDependentPugText : MonoBehaviour
{
	public bool debug;

	public ControllerButtonToCharTable controllerButtonToCharTable;

	public List<PugText> pugTexts;

	public bool localize = true;

	public bool dontLocalizeConsoleStrings;

	public bool dontLocalizeConsoleFormatFields;

	public bool useSystemInput;

	public bool showControlMapperKeysInstead;

	public LocalizedString controlMapperKey;

	public bool UseDynamicSpriteAsset;

	[Header("PC")]
	public string textStringPCKeyboardOverride;

	public string[] formatFieldsPCKeyboardOverride;

	[Header("PS4")]
	public string textStringPS4Override;

	public string[] formatFieldsPS4Override;

	public string textStringPS4JapanOverride;

	public string[] formatFieldsPS4JapanOverride;

	[Header("PS5")]
	public string textStringPS5Override;

	public string[] formatFieldsPS5Override;

	[Header("GameCore")]
	public string textStringXboxOverride;

	public string[] formatFieldsXboxOverride;

	[Header("Switch")]
	public string textStringSwitchOverride;

	public string[] formatFieldsSwitchOverride;

	private string[] dynamicVersions;

	private bool userPrefersJoystick;

	private readonly string controlMapperPrefix = "ControlMapper/";

	private string controlMapperChar;

	private string previousControlMapperChar;

	private string controlMapperKeyWithoutPrefix;

	private List<ActionElementMap> actions = new List<ActionElementMap>();

	private bool hasBeenInitialized;

	public void SetControlMapperKey(LocalizedString _controlMapperKey)
	{
		if (!((string)_controlMapperKey == (string)controlMapperKey))
		{
			controlMapperKey = _controlMapperKey;
			if (!string.IsNullOrEmpty(controlMapperKey.mTerm))
			{
				controlMapperKeyWithoutPrefix = controlMapperKey.mTerm.Substring(controlMapperPrefix.Length);
			}
		}
	}

	public void Awake()
	{
		if (!showControlMapperKeysInstead)
		{
			SetControllerProperties();
		}
	}

	private void Start()
	{
		Update();
		UpdateText();
		hasBeenInitialized = true;
		if (!string.IsNullOrEmpty(controlMapperKey.mTerm))
		{
			controlMapperKeyWithoutPrefix = controlMapperKey.mTerm.Substring(controlMapperPrefix.Length);
		}
	}

	private void OnEnable()
	{
		if (hasBeenInitialized)
		{
			Update();
			UpdateText();
		}
	}

	private void Update()
	{
		bool flag = false;
		flag = ((!useSystemInput) ? (Manager.input.IsAnyGamepadConnected() && !Manager.input.singleplayerInputModule.PrefersKeyboardAndMouse()) : (Manager.input.IsAnyGamepadConnected() && !Manager.input.SystemPrefersKeyboardAndMouse()));
		if (showControlMapperKeysInstead)
		{
			Player player = (useSystemInput ? Manager.input.system : Manager.input.singleplayerInputModule.rewiredPlayer);
			if (!string.IsNullOrEmpty(controlMapperKeyWithoutPrefix))
			{
				string actionName = controlMapperKeyWithoutPrefix;
				Controller lastActiveController = player.controllers.GetLastActiveController();
				ActionElementMap actionElementMap = null;
				if (lastActiveController != null)
				{
					actionElementMap = player.controllers.maps.GetFirstElementMapWithAction(lastActiveController, actionName, skipDisabledMaps: true);
				}
				if (actionElementMap == null || actionElementMap.controllerMap.controllerType == ControllerType.Mouse)
				{
					actionElementMap = player.controllers.maps.GetFirstElementMapWithAction(actionName, skipDisabledMaps: true);
					player.controllers.maps.GetElementMapsWithAction(actionName, skipDisabledMaps: true, actions);
					foreach (ActionElementMap action in actions)
					{
						if (flag && action.controllerMap.controllerType == ControllerType.Joystick)
						{
							actionElementMap = action;
							break;
						}
						if (!flag && action.controllerMap.controllerType != ControllerType.Joystick)
						{
							actionElementMap = action;
							break;
						}
					}
				}
				controlMapperChar = null;
				if (actionElementMap != null)
				{
					controlMapperChar = controllerButtonToCharTable.GetControllerButtonCharacter(actionElementMap.controllerMap.controllerType, actionElementMap.controllerMap.controller.name, actionElementMap.elementIdentifierName);
				}
			}
		}
		else if (string.IsNullOrEmpty(textStringPCKeyboardOverride))
		{
			return;
		}
		if (userPrefersJoystick != flag || controlMapperChar != previousControlMapperChar)
		{
			previousControlMapperChar = controlMapperChar;
			userPrefersJoystick = flag;
			UpdateText();
		}
	}

	private void UpdateText()
	{
		if (showControlMapperKeysInstead)
		{
			foreach (PugText pugText in pugTexts)
			{
				if (pugText.GetText() != controlMapperChar)
				{
					pugText.localizePlaceholders = false;
					pugText.localize = false;
					pugText.formatFields = new string[0];
					pugText.Render(controlMapperChar);
				}
			}
			return;
		}
		if (userPrefersJoystick)
		{
			SetControllerProperties();
			return;
		}
		foreach (PugText pugText2 in pugTexts)
		{
			pugText2.localizePlaceholders = localize;
			pugText2.localize = localize;
			pugText2.formatFields = formatFieldsPCKeyboardOverride;
			pugText2.Render(textStringPCKeyboardOverride);
		}
	}

	private void SetControllerProperties()
	{
		foreach (PugText pugText in pugTexts)
		{
			pugText.localize = !dontLocalizeConsoleStrings;
			pugText.localizePlaceholders = !dontLocalizeConsoleFormatFields;
			string text = null;
			string[] array = null;
			array = formatFieldsXboxOverride;
			text = textStringXboxOverride;
			if (UseDynamicSpriteAsset && pugText.isUsingDynamicText)
			{
				if (dynamicVersions == null)
				{
					dynamicVersions = array.Select(PugText.GetButtonStringForThai).ToArray();
				}
				array = dynamicVersions;
			}
			pugText.formatFields = array;
			pugText.Render(text);
		}
	}
}
