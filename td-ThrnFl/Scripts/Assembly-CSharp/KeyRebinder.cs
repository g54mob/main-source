using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Rewired;
using TMPro;
using UnityEngine;

public class KeyRebinder : MonoBehaviour
{
	public List<string> actionCategoriesToShow = new List<string>();

	public GameObject listeningToRemapPopUp;

	public ThronefallUIElement tabButton;

	public GameObject controlDevicesIconsPrefab;

	public ThronefallUIElement restoreControlsButtonPrefab;

	public ThronefallUIElement controllerPickerButtonPrefab;

	public ControlMapButton buttonPrefab;

	public Transform buttonParent;

	public TextMeshProUGUI remapListenTimerText;

	public List<ControlMapButton> buttons = new List<ControlMapButton>();

	private InputMapper keyboardMapper;

	private InputMapper mouseMapper;

	private InputMapper joystickMapper;

	private Joystick selectedJoystick;

	private ControllerMap keyboardMap;

	private ControllerMap mouseMap;

	private ControllerMap joystickMap;

	private bool listening;

	private bool mapCallbackRecieved;

	private const string uiCategory = "UI";

	private const string gameplayAlwaysCategory = "Gameplay Always";

	private readonly string[] gameplayNotOverlappingCategories = new string[2] { "Gameplay Day", "Gameplay Night" };

	private EnumSelector controllerSelector;

	private Dictionary<string, int> registeredJoysticks = new Dictionary<string, int>();

	private Player player => ReInput.players.GetPlayer(0);

	public Joystick SelectedJoystick => selectedJoystick;

	public ControllerMap KeyboardMap => keyboardMap;

	public ControllerMap MouseMap => mouseMap;

	public ControllerMap JoystickMap => joystickMap;

	private int UICategoryId => ReInput.mapping.GetActionCategoryId("UI");

	private int GameplayAlwaysCategoryId => ReInput.mapping.GetActionCategoryId("Gameplay Always");

	private List<int> GameplayNotOverlappingCategoriesIds
	{
		get
		{
			List<int> list = new List<int>();
			string[] array = gameplayNotOverlappingCategories;
			foreach (string text in array)
			{
				list.Add(ReInput.mapping.GetActionCategoryId(text));
			}
			return list;
		}
	}

	private void OnEnable()
	{
		keyboardMapper = new InputMapper();
		keyboardMapper.options.allowKeyboardModifierKeyAsPrimary = true;
		keyboardMapper.options.allowKeyboardKeysWithModifiers = false;
		keyboardMapper.options.ignoreMouseXAxis = true;
		keyboardMapper.options.ignoreMouseYAxis = true;
		keyboardMapper.options.timeout = 3f;
		keyboardMapper.options.checkForConflicts = true;
		keyboardMapper.ConflictFoundEvent += OnBindConflict;
		mouseMapper = new InputMapper();
		mouseMapper.options.ignoreMouseXAxis = true;
		mouseMapper.options.ignoreMouseYAxis = true;
		mouseMapper.options.timeout = 3f;
		mouseMapper.options.checkForConflicts = true;
		mouseMapper.ConflictFoundEvent += OnBindConflict;
		joystickMapper = new InputMapper();
		joystickMapper.options.ignoreMouseXAxis = true;
		joystickMapper.options.ignoreMouseYAxis = true;
		joystickMapper.options.timeout = 3f;
		joystickMapper.options.checkForConflicts = true;
		joystickMapper.ConflictFoundEvent += OnBindConflict;
		ReInput.ControllerConnectedEvent += OnControllerConnectionChange;
		ReInput.ControllerDisconnectedEvent += OnControllerConnectionChange;
		keyboardMapper.InputMappedEvent += OnInputMapped;
		mouseMapper.InputMappedEvent += OnInputMapped;
		joystickMapper.InputMappedEvent += OnInputMapped;
		listeningToRemapPopUp.SetActive(value: false);
		RegenerateButtons();
	}

	private void OnDisable()
	{
		ReInput.ControllerConnectedEvent -= OnControllerConnectionChange;
		ReInput.ControllerDisconnectedEvent -= OnControllerConnectionChange;
	}

	public void RegenerateButtons()
	{
		int num = 0;
		buttons.Clear();
		List<GameObject> list = new List<GameObject>();
		foreach (Transform item in buttonParent)
		{
			list.Add(item.gameObject);
		}
		for (int num2 = list.Count - 1; num2 >= 0; num2--)
		{
			Object.Destroy(list[num2]);
		}
		ThronefallUIElement thronefallUIElement = Object.Instantiate(controllerPickerButtonPrefab, buttonParent);
		thronefallUIElement.gameObject.AddComponent<ScrollElementID>().id = num;
		num++;
		controllerSelector = thronefallUIElement.GetComponentInChildren<EnumSelector>();
		controllerSelector.onChange.AddListener(OnControllerSelectionChange);
		RefreshControllerPickOptions();
		RefreshAllMaps();
		ThronefallUIElement thronefallUIElement2 = Object.Instantiate(restoreControlsButtonPrefab, buttonParent);
		thronefallUIElement2.gameObject.AddComponent<ScrollElementID>().id = num;
		num++;
		Object.Instantiate(controlDevicesIconsPrefab, buttonParent).gameObject.AddComponent<ScrollElementID>().id = num;
		num++;
		foreach (string item2 in actionCategoriesToShow)
		{
			ControlMapButton controlMapButton = null;
			foreach (InputAction item3 in ReInput.mapping.ActionsInCategory(item2))
			{
				if (item3.userAssignable)
				{
					if (item3.type == InputActionType.Axis)
					{
						controlMapButton = Object.Instantiate(buttonPrefab, buttonParent);
						controlMapButton.SetData(item3, this, ControlMapButton.AxisMode.Positive);
						controlMapButton.gameObject.AddComponent<ScrollElementID>().id = num;
						num++;
						buttons.Add(controlMapButton);
						controlMapButton = Object.Instantiate(buttonPrefab, buttonParent);
						controlMapButton.SetData(item3, this, ControlMapButton.AxisMode.Negative);
						controlMapButton.gameObject.AddComponent<ScrollElementID>().id = num;
						num++;
						buttons.Add(controlMapButton);
					}
					else
					{
						controlMapButton = Object.Instantiate(buttonPrefab, buttonParent);
						controlMapButton.SetData(item3, this, ControlMapButton.AxisMode.Button);
						controlMapButton.gameObject.AddComponent<ScrollElementID>().id = num;
						num++;
						buttons.Add(controlMapButton);
					}
				}
			}
		}
		thronefallUIElement.topNav = tabButton;
		thronefallUIElement.botNav = thronefallUIElement2;
		thronefallUIElement2.topNav = thronefallUIElement;
		for (int i = 0; i < buttons.Count; i++)
		{
			if (i == 0)
			{
				buttons[i].target.topNav = thronefallUIElement2;
			}
			else
			{
				buttons[i].target.topNav = buttons[i - 1].target;
			}
			if (i == buttons.Count - 1)
			{
				buttons[i].target.botNav = tabButton;
			}
			else
			{
				buttons[i].target.botNav = buttons[i + 1].target;
			}
		}
		tabButton.botNav = thronefallUIElement;
		tabButton.topNav = buttons[buttons.Count - 1].target;
		thronefallUIElement2.botNav = buttons[0].target;
		GetComponentInParent<UIFrame>().RefetchManagedElements();
	}

	public void UpdateButtonLabels()
	{
		foreach (ControlMapButton button in buttons)
		{
			button.Refresh();
		}
	}

	public void OnControllerConnectionChange(ControllerStatusChangedEventArgs args)
	{
		RefreshControllerPickOptions();
		RefreshSelectedJoystickAndLoadMap();
		UpdateButtonLabels();
	}

	private void RefreshAllMaps()
	{
		foreach (ControllerMap allMap in player.controllers.maps.GetAllMaps())
		{
			if (allMap.controller.type == ControllerType.Keyboard && allMap.categoryId == 0)
			{
				keyboardMap = allMap;
			}
		}
		foreach (ControllerMap allMap2 in player.controllers.maps.GetAllMaps())
		{
			if (allMap2.controller.type == ControllerType.Mouse && allMap2.categoryId == 0)
			{
				mouseMap = allMap2;
			}
		}
		RefreshSelectedJoystickAndLoadMap();
	}

	private void RefreshSelectedJoystickAndLoadMap()
	{
		selectedJoystick = null;
		if (controllerSelector != null && registeredJoysticks.TryGetValue(controllerSelector.options[controllerSelector.Index], out var value))
		{
			selectedJoystick = player.controllers.GetController<Joystick>(value);
			if (selectedJoystick != null)
			{
				joystickMap = player.controllers.maps.GetMap(selectedJoystick, 0, 0);
			}
			else
			{
				joystickMap = null;
			}
		}
	}

	private void RefreshControllerPickOptions()
	{
		if (controllerSelector == null)
		{
			return;
		}
		controllerSelector.options.Clear();
		registeredJoysticks.Clear();
		if (player.controllers.joystickCount > 0)
		{
			foreach (Joystick joystick in player.controllers.Joysticks)
			{
				controllerSelector.options.Add(joystick.name);
				registeredJoysticks.Add(joystick.name, joystick.id);
			}
		}
		else
		{
			controllerSelector.options.Add(LocalizationManager.GetTermTranslation("Controls/No Controller"));
		}
		controllerSelector.UpdateDisplay();
	}

	private void OnControllerSelectionChange()
	{
		RefreshSelectedJoystickAndLoadMap();
		UpdateButtonLabels();
	}

	public void TriggerRebind(InputAction actionToMap, ActionElementMap keyboardMapToReplace, ActionElementMap mouseMapToReplace, ActionElementMap joystickMapToReplace, ControlMapButton.AxisMode axisMode)
	{
		if (!listening)
		{
			listening = true;
			player.controllers.maps.SetAllMapsEnabled(state: false);
			listeningToRemapPopUp.SetActive(value: true);
			StartCoroutine(ListenForRebind(actionToMap, keyboardMapToReplace, mouseMapToReplace, joystickMapToReplace, axisMode));
		}
	}

	private IEnumerator ListenForRebind(InputAction actionToMap, ActionElementMap keyboardMapToReplace, ActionElementMap mouseMapToReplace, ActionElementMap joystickMapToReplace, ControlMapButton.AxisMode axisMode)
	{
		yield return new WaitForSecondsRealtime(0.1f);
		mapCallbackRecieved = false;
		Dictionary<AxisCalibration, float> modifiedAxes = new Dictionary<AxisCalibration, float>();
		if (selectedJoystick != null)
		{
			foreach (AxisCalibration axis in selectedJoystick.calibrationMap.Axes)
			{
				modifiedAxes.Add(axis, axis.deadZone);
				axis.deadZone = 0.75f;
			}
		}
		AxisRange actionRange = AxisRange.Positive;
		switch (axisMode)
		{
		case ControlMapButton.AxisMode.Positive:
			actionRange = AxisRange.Positive;
			break;
		case ControlMapButton.AxisMode.Negative:
			actionRange = AxisRange.Negative;
			break;
		}
		if (keyboardMap != null)
		{
			keyboardMapper.Start(new InputMapper.Context
			{
				actionId = actionToMap.id,
				controllerMap = keyboardMap,
				actionRange = actionRange,
				actionElementMapToReplace = keyboardMapToReplace
			});
		}
		if (mouseMap != null)
		{
			mouseMapper.Start(new InputMapper.Context
			{
				actionId = actionToMap.id,
				controllerMap = mouseMap,
				actionRange = actionRange,
				actionElementMapToReplace = mouseMapToReplace
			});
		}
		if (joystickMap != null)
		{
			joystickMapper.Start(new InputMapper.Context
			{
				actionId = actionToMap.id,
				controllerMap = joystickMap,
				actionRange = actionRange,
				actionElementMapToReplace = joystickMapToReplace
			});
		}
		while (keyboardMapper.timeRemaining > 0f || joystickMapper.timeRemaining > 0f || mouseMapper.timeRemaining > 0f)
		{
			remapListenTimerText.text = Mathf.RoundToInt(keyboardMapper.timeRemaining).ToString();
			if (mapCallbackRecieved)
			{
				break;
			}
			yield return null;
		}
		keyboardMapper.Stop();
		mouseMapper.Stop();
		joystickMapper.Stop();
		listeningToRemapPopUp.SetActive(value: false);
		UpdateButtonLabels();
		if (selectedJoystick != null)
		{
			foreach (AxisCalibration axis2 in selectedJoystick.calibrationMap.Axes)
			{
				if (modifiedAxes.TryGetValue(axis2, out var value))
				{
					axis2.deadZone = value;
				}
			}
		}
		yield return new WaitForSecondsRealtime(0.1f);
		listening = false;
		player.controllers.maps.SetAllMapsEnabled(state: true);
		ControlConfigSaveLoad.SaveControlConfigToJson();
	}

	private void OnInputMapped(InputMapper.InputMappedEventData e)
	{
		mapCallbackRecieved = true;
	}

	private void OnBindConflict(InputMapper.ConflictFoundEventData e)
	{
		int gameplayAlwaysCategoryId = GameplayAlwaysCategoryId;
		List<int> gameplayNotOverlappingCategoriesIds = GameplayNotOverlappingCategoriesIds;
		int uICategoryId = UICategoryId;
		int categoryId = e.assignment.action.categoryId;
		List<int> list = new List<int>();
		foreach (ElementAssignmentConflictInfo conflict in e.conflicts)
		{
			list.Add(conflict.action.categoryId);
		}
		List<ElementAssignmentConflictInfo> list2 = new List<ElementAssignmentConflictInfo>();
		if (categoryId == gameplayAlwaysCategoryId)
		{
			foreach (ElementAssignmentConflictInfo conflict2 in e.conflicts)
			{
				if (conflict2.action.categoryId == categoryId || gameplayNotOverlappingCategoriesIds.Contains(conflict2.action.categoryId))
				{
					list2.Add(conflict2);
				}
			}
		}
		else if (gameplayNotOverlappingCategoriesIds.Contains(categoryId))
		{
			foreach (ElementAssignmentConflictInfo conflict3 in e.conflicts)
			{
				if (conflict3.action.categoryId == categoryId || conflict3.action.categoryId == gameplayAlwaysCategoryId)
				{
					list2.Add(conflict3);
				}
			}
		}
		if (categoryId == uICategoryId)
		{
			foreach (ElementAssignmentConflictInfo conflict4 in e.conflicts)
			{
				if (conflict4.action.categoryId == uICategoryId)
				{
					list2.Add(conflict4);
				}
			}
		}
		foreach (ElementAssignmentConflictInfo item in list2)
		{
			item.controllerMap.DeleteElementMap(item.elementMapId);
		}
		e.responseCallback(InputMapper.ConflictResponse.Add);
	}

	public void TriggerControlsReset()
	{
		player.controllers.maps.LoadDefaultMaps(ControllerType.Mouse);
		player.controllers.maps.LoadDefaultMaps(ControllerType.Keyboard);
		player.controllers.maps.LoadDefaultMaps(ControllerType.Joystick);
		ControlConfigSaveLoad.SaveControlConfigToJson();
		RefreshAllMaps();
		UpdateButtonLabels();
	}
}
