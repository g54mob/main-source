using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using I2.Loc;
using PimDeWitte.UnityMainThreadDispatcher;
using Pug.UnityExtensions;
using Rewired;
using Rewired.Localization;
using Rewired.UI.ControlMapper;
using UnityEngine;

public class ControlMappingMenu : RadicalMenu, IScrollable
{
	[Serializable]
	public class InputActionPlatformList
	{
		[field: SerializeField]
		public PlatformFlags Platforms { get; private set; }

		[field: SerializeField]
		public List<int> ActionIds { get; private set; }
	}

	public const string LOCALIZATION_PREFIX = "ControlMapper";

	public const string LOCALIZATION_CATEGORY_NAME_SUFFIX = "Category";

	public const string LOCALIZATION_CATEGORY_DESCRIPTION_SUFFIX = "Description";

	[Header("Control mapping configuration")]
	[SerializeField]
	private List<ControlMapping_CategoryLayoutData> _mappingLayoutData;

	[SerializeField]
	private ControlMapperLanguageData _languageData;

	[Tooltip("Specify mapping of platform type and input actions which should not be shown for control remapping. This is for any actions for features which are not available in certain platforms.")]
	[SerializeField]
	private List<InputActionPlatformList> _inputActionPlatformBlacklist = new List<InputActionPlatformList>();

	[Tooltip("Specify mapping of platform type and controller element identifier which should not be allowed for mapping.")]
	[SerializeField]
	private List<PlatformElementIdentifierBlacklist> _elementIdentifierPlatformBlacklist = new List<PlatformElementIdentifierBlacklist>();

	[SerializeField]
	private List<MenuHelperButtons.HelpButtonTypes> _helpButtonList;

	[SerializeField]
	private List<MenuHelperButtons.HelpButtonTypes> _helpButtonListNoJoystick;

	[SerializeField]
	private Transform _categorySelectionContainer;

	[SerializeField]
	private Transform _actionMappingContainer;

	[Header("Display configuration")]
	[Tooltip("Whether to display a button for a secondary keyboard mapping in the UI.")]
	[SerializeField]
	private bool _showSecondaryKeyboardMapping;

	[Tooltip("Whether to display a button for a secondary mouse mapping in the UI.")]
	[SerializeField]
	private bool _showSecondaryMouseMapping;

	[Tooltip("Whether to display a button for a secondary joystick mapping in the UI.")]
	[SerializeField]
	private bool _showSecondaryJoystickMapping;

	[Tooltip("A list of keyboard key names which should be localized. Key is the Rewired element name, value is the matching loca key in I2.")]
	[SerializeField]
	private List<KeyValuePair_String> _keyboardLocalizationWhitelist = new List<KeyValuePair_String>();

	[SerializeField]
	private float _scrollPadding = 5f;

	[Header("Mapping configuration")]
	[Tooltip("The time that's available for the user to assign a new mapping after the assignment flow has started.")]
	[SerializeField]
	private float _assignmentTimeout = 5f;

	[Header("UI element prefabs")]
	[SerializeField]
	private ControlMapping_CategorySelector categorySelectionButtonPrefab;

	[SerializeField]
	private ControlMapping_CategoryLabel _categoryLabelPrefab;

	[SerializeField]
	private ControlMapping_ActionMapping _fullActionMappingPrefab;

	[SerializeField]
	private ControlMapping_ActionMapping _singleControllerActionMappingPrefab;

	private TextAsset _elementLocalizationAsset;

	private ControlMappingManager _controlMappingManager;

	[Header("References")]
	[SerializeField]
	private ControlMapping_Popup _popup;

	[SerializeField]
	private ControlMapping_CalibrationMenu _calibrationMenu;

	[SerializeField]
	private GameObject _controllerTypeLabels;

	[SerializeField]
	private Transform _topMask;

	[SerializeField]
	private ScrollBar _scrollBarDefault;

	[SerializeField]
	private ScrollBar _scrollBarConsoles;

	private int _selectedDisplayCategoryIndex;

	private UIScrollWindow _uiScrollWindow;

	private PoolSystem _categoryButtonPool;

	private PoolSystem _actionMappingPool;

	private PoolSystem _categoryLabelPool;

	private ControlMapping_MappingController _mappingController;

	private List<ControlMapping_CategorySelector> _categorySelectors = new List<ControlMapping_CategorySelector>();

	private List<ControlMapping_ActionMapping> _actionMappings = new List<ControlMapping_ActionMapping>();

	private List<ControlMapping_CategoryLabel> _categoryLabels = new List<ControlMapping_CategoryLabel>();

	private bool layoutIsDirty;

	private ControlMapping_SingleActionMapping _activeSingleActionMapping;

	private bool _inputEnabled;

	private string _currentLanguageCode = "";

	private ControlMapping_ActionMapping ActionMappingPrefab
	{
		get
		{
			int num = 0;
			for (int i = 0; i < 3; i++)
			{
				ControllerType controllerType = (ControllerType)i;
				if (_controlMappingManager.PlatformSupportsMappingForControllerType(controllerType))
				{
					num++;
				}
			}
			if (num != 1)
			{
				return _fullActionMappingPrefab;
			}
			return _singleControllerActionMappingPrefab;
		}
	}

	private ScrollBar ActiveScrollBar
	{
		get
		{
			if (_controlMappingManager.DebugConsole)
			{
				return _scrollBarConsoles;
			}
			return _scrollBarDefault;
		}
	}

	private Player _player => Manager.input.singleplayerInputModule.rewiredPlayer;

	private Player _systemPlayer => Manager.input.system;

	protected override int DefaultOptionIndex => _categorySelectors.Count;

	public override bool UseCustomHelpButtons => true;

	public static string GetLocalizedControlMappingTerm(string term)
	{
		return LocalizationManager.GetTranslation("ControlMapper/" + term);
	}

	private void Update()
	{
		PollForInput();
		if (layoutIsDirty)
		{
			_categorySelectionContainer.GetComponent<LinearLayoutUIComponent>()?.RenderUIComponent(force: true);
			_actionMappingContainer.GetComponent<LinearLayoutUIComponent>()?.RenderUIComponent(force: true);
			layoutIsDirty = false;
			if (base.selectedIndex == -1 || menuOptions.Count <= base.selectedIndex)
			{
				SelectOptionIndex(DefaultOptionIndex);
			}
			else
			{
				menuOptions[base.selectedIndex].OnSelected();
			}
		}
		_mappingController.Update();
	}

	private void PollForInput()
	{
		if (_inputEnabled && !_mappingController.IsBusy)
		{
			if (_systemPlayer.GetButtonDown(301))
			{
				OpenCalibrationMenu();
				_inputEnabled = false;
			}
			if (_systemPlayer.GetButtonDown(300))
			{
				ResetDefaults();
			}
			if (_systemPlayer.GetButtonDown(298))
			{
				SelectNextOrPreviousCategory(next: true);
			}
			else if (_systemPlayer.GetButtonDown(299))
			{
				SelectNextOrPreviousCategory(next: false);
			}
		}
	}

	public void Initialize()
	{
		_controlMappingManager = Manager.controlMapping as ControlMappingManager;
		_mappingController = new ControlMapping_MappingController(_languageData, _popup, _assignmentTimeout, ignoreMouseAxes: true, IsElementAllowedCallback);
		_uiScrollWindow = GetComponent<UIScrollWindow>();
		_calibrationMenu.Initialize(_mappingController, _languageData, _systemPlayer);
		_calibrationMenu.MenuClosed += delegate
		{
			_inputEnabled = true;
			_uiScrollWindow.enabled = true;
		};
		GameObject gameObject = new GameObject("Pool ControlMapping_CategorySelector");
		UnityEngine.Object.DontDestroyOnLoad(gameObject);
		_categoryButtonPool = new PoolSystem(categorySelectionButtonPrefab.gameObject, typeof(ControlMapping_CategorySelector), gameObject.transform, autoEnable: true, 6, 10, -1, "ControlMapping_CategorySelector");
		GameObject gameObject2 = new GameObject("Pool ControlMapping_ActionMapping");
		UnityEngine.Object.DontDestroyOnLoad(gameObject2);
		_actionMappingPool = new PoolSystem(ActionMappingPrefab.gameObject, typeof(ControlMapping_ActionMapping), gameObject2.transform, autoEnable: true, 10, 256, -1, "ControlMapping_ActionMapping");
		GameObject gameObject3 = new GameObject("Pool ControlMapping_CategoryLabel");
		UnityEngine.Object.DontDestroyOnLoad(gameObject3);
		_categoryLabelPool = new PoolSystem(_categoryLabelPrefab.gameObject, typeof(ControlMapping_CategoryLabel), gameObject3.transform, autoEnable: true, 5, 10, -1, "ControlMapping_CategoryLabel");
		SetScrollbarValues(_controlMappingManager.DebugConsole);
		ActiveScrollBar.gameObject.SetActive(value: true);
		_uiScrollWindow.scrollBar = ActiveScrollBar;
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			_uiScrollWindow.ResetScroll();
		});
	}

	private void SetScrollbarValues(bool consoleValues)
	{
		if (consoleValues)
		{
			_uiScrollWindow.minScrollPos = 0f;
			_topMask.SetLocalPositionY(8.95f);
			_controllerTypeLabels.SetActive(value: false);
		}
		else
		{
			_uiScrollWindow.minScrollPos = -1.5f;
			_topMask.SetLocalPositionY(7.72f);
			_controllerTypeLabels.SetActive(value: true);
		}
	}

	private void OpenCalibrationMenu()
	{
		if (ReInput.controllers.joystickCount > 0)
		{
			Joystick lastActiveController = ReInput.controllers.GetLastActiveController<Joystick>();
			if (lastActiveController != null)
			{
				Manager.menu.PushMenu(_calibrationMenu);
				_calibrationMenu.Setup(lastActiveController);
				return;
			}
		}
		Debug.LogWarning("ControlMappingMenu.OpenCalibrationMenu: no joystick found. Aborting calibration.");
	}

	private void ResetDefaults()
	{
		_inputEnabled = false;
		_mappingController.StartResetDefaults();
	}

	private void SelectNextOrPreviousCategory(bool next)
	{
		ControlMapping_CategorySelector controlMapping_CategorySelector = _categorySelectors.FirstOrDefault((ControlMapping_CategorySelector selector) => selector.CategoryId.Equals(_selectedDisplayCategoryIndex));
		if (controlMapping_CategorySelector == null)
		{
			return;
		}
		int num = _categorySelectors.IndexOf(controlMapping_CategorySelector);
		if (num != -1)
		{
			int index = Math.Clamp((!next) ? (--num) : (++num), 0, _categorySelectors.Count - 1);
			ControlMapping_CategorySelector controlMapping_CategorySelector2 = _categorySelectors[index];
			if (!(controlMapping_CategorySelector2 == null))
			{
				controlMapping_CategorySelector.SetActive(select: false);
				controlMapping_CategorySelector2.SetActive(select: true);
				ChangeCategory(controlMapping_CategorySelector2.CategoryId);
			}
		}
	}

	private void OnActionMappingChanged(ActionElementMap mapping)
	{
		if (_activeSingleActionMapping == null)
		{
			Debug.LogWarning("ControlMappingMenu.OnActionMappingChanged: no active single action mapping present. This should not be possible.");
			return;
		}
		ActionElementMap actionElementMap = _activeSingleActionMapping.ActionElementMap;
		if (actionElementMap != null && !actionElementMap.Equals(mapping))
		{
			Debug.LogWarning(string.Format("{0}.{1}: the active single action mapping (actionId:{2}) is not the same as the one we got a mapping change event for (actionId:{3}).", "ControlMappingMenu", "OnActionMappingChanged", _activeSingleActionMapping.ActionElementMap.actionId, mapping.actionId));
		}
		RefreshCurrentCategoryUi();
	}

	private void OnActionMappingStarted()
	{
		_inputEnabled = false;
		Manager.input.DisableSystemInput();
		_uiScrollWindow.enabled = false;
	}

	private void OnActionMappingCompleted(ControlMappingUserResponse response)
	{
		StartUpdateInputEnableRoutine(onlySystemInput: false);
		if (response == ControlMappingUserResponse.Confirm)
		{
			RefreshCurrentCategoryUi();
		}
	}

	private void OnActionMappingConflictFound()
	{
		StartUpdateInputEnableRoutine(onlySystemInput: true);
	}

	private void OnRemoveOrReassignElement()
	{
		_inputEnabled = false;
	}

	private void OnRemoveOrReassignElementCanceled()
	{
		_inputEnabled = true;
	}

	private void OnCalibrationStarted()
	{
		_inputEnabled = false;
		Manager.input.DisableSystemInput();
		_uiScrollWindow.enabled = false;
	}

	private void OnCalibrationCompleted()
	{
		Manager.input.EnableSystemInput();
	}

	private void OnResetToDefaultsCompleted(bool reset)
	{
		StartUpdateInputEnableRoutine(onlySystemInput: false);
		if (reset)
		{
			Debug.Log("ControlMappingMenu.ResetDefaults: loading default input mappings for player " + _player.name + ".");
			if (_controlMappingManager.PlatformSupportsMappingForControllerType(ControllerType.Keyboard))
			{
				_player.controllers.maps.LoadDefaultMaps(ControllerType.Keyboard);
			}
			if (_controlMappingManager.PlatformSupportsMappingForControllerType(ControllerType.Mouse))
			{
				_player.controllers.maps.LoadDefaultMaps(ControllerType.Mouse);
			}
			if (_controlMappingManager.PlatformSupportsMappingForControllerType(ControllerType.Joystick))
			{
				_player.controllers.maps.LoadDefaultMaps(ControllerType.Joystick);
			}
			Manager.input.AssignJoysticksToSingleplayerInputModule();
			RefreshCurrentCategoryUi();
		}
	}

	private void OnJoystickDisconnected(ControllerStatusChangedEventArgs args)
	{
		_mappingController.Cleanup();
		UnityMainThreadDispatcher.Instance().Enqueue(RefreshCurrentCategoryUi);
	}

	private void OnJoystickConnected(ControllerStatusChangedEventArgs args)
	{
		UnityMainThreadDispatcher.Instance().Enqueue(delegate
		{
			UnityMainThreadDispatcher.Instance().StartCoroutine(WaitOnJoystickConnected(args));
		});
	}

	private IEnumerator WaitOnJoystickConnected(ControllerStatusChangedEventArgs args)
	{
		yield return new WaitForSeconds(1f);
		_mappingController.Cleanup();
		Manager.input.GetRewiredUserDataStore()?.LoadControllerData(args.controllerType, args.controllerId);
		UnityMainThreadDispatcher.Instance().Enqueue(RefreshCurrentCategoryUi);
	}

	private void StartUpdateInputEnableRoutine(bool onlySystemInput)
	{
		StartCoroutine(UpdateEnableInputRoutine(onlySystemInput));
	}

	private IEnumerator UpdateEnableInputRoutine(bool onlySystemInput)
	{
		yield return new WaitForSecondsRealtime(0.5f);
		Manager.input.EnableSystemInput();
		if (!onlySystemInput)
		{
			_uiScrollWindow.enabled = true;
			_inputEnabled = true;
		}
	}

	private void CreateCategorySelection()
	{
		if (_categorySelectionContainer == null)
		{
			Debug.LogError("ControlMappingMenu.CreateCategorySelection: container for the buttons is null. Please assign it in the inspector.");
			return;
		}
		CleanupCategoryButtons();
		for (int i = 0; i < _mappingLayoutData.Count; i++)
		{
			ControlMapping_CategoryLayoutData controlMapping_CategoryLayoutData = _mappingLayoutData[i];
			GameObject freeObject = _categoryButtonPool.GetFreeObject(deferOnOccupied: false, deferReparent: true);
			ControlMapping_CategorySelector component = freeObject.GetComponent<ControlMapping_CategorySelector>();
			_categorySelectors.Add(component);
			freeObject.transform.SetParent(_categorySelectionContainer);
			string mTerm = controlMapping_CategoryLayoutData.CategoryName.mTerm;
			component.Setup(i, mTerm);
			component.CategoryActivated += OnCategoryActivated;
			menuOptions.Add(component);
		}
		layoutIsDirty = true;
	}

	private void OnCategoryActivated(ControlMapping_CategorySelector categorySelector)
	{
		ControlMapping_CategorySelector controlMapping_CategorySelector = _categorySelectors.FirstOrDefault((ControlMapping_CategorySelector s) => s.CategoryId.Equals(_selectedDisplayCategoryIndex));
		if (controlMapping_CategorySelector != null)
		{
			controlMapping_CategorySelector.SetActive(select: false);
		}
		categorySelector.SetActive(select: true);
		ChangeCategory(categorySelector.CategoryId);
	}

	private void RefreshCurrentCategoryUi()
	{
		ChangeCategory(_selectedDisplayCategoryIndex, force: true);
	}

	private void ChangeCategory(int categoryId, bool force = false)
	{
		if (_selectedDisplayCategoryIndex != categoryId)
		{
			DeselectAnyCurrentOption();
		}
		else if (!force)
		{
			return;
		}
		if (_mappingLayoutData == null || categoryId < 0 || categoryId >= _mappingLayoutData.Count)
		{
			Debug.LogError(string.Format("{0}.{1}: invalid category id {2}.", "ControlMappingMenu", "ChangeCategory", categoryId));
			return;
		}
		CleanupActionMappings();
		CleanupCategoryLabels();
		_selectedDisplayCategoryIndex = categoryId;
		ControlMapping_CategoryLayoutData controlMapping_CategoryLayoutData = _mappingLayoutData[categoryId];
		if (controlMapping_CategoryLayoutData == null)
		{
			return;
		}
		for (int i = 0; i < controlMapping_CategoryLayoutData.CategoryLayoutData.Count; i++)
		{
			CategoryLayoutData categoryLayoutData = controlMapping_CategoryLayoutData.CategoryLayoutData[i];
			if (categoryLayoutData == null)
			{
				continue;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(categoryLayoutData.MappingSet.mapCategoryId);
			Dictionary<ControllerType, ControllerMap> controllerMaps = new Dictionary<ControllerType, ControllerMap>();
			bool flag = TryAddControllerMap(ref controllerMaps, ControllerType.Keyboard, mapCategory) && _controlMappingManager.PlatformSupportsMappingForControllerType(ControllerType.Keyboard);
			bool flag2 = TryAddControllerMap(ref controllerMaps, ControllerType.Mouse, mapCategory) && _controlMappingManager.PlatformSupportsMappingForControllerType(ControllerType.Mouse);
			bool flag3 = TryAddControllerMap(ref controllerMaps, ControllerType.Joystick, mapCategory) && _controlMappingManager.PlatformSupportsMappingForControllerType(ControllerType.Joystick);
			List<ActionElementMap> allMappings = controllerMaps.Values.SelectMany((ControllerMap x) => x.AllMaps).ToList();
			ActionMappingDisplayConfig config = new ActionMappingDisplayConfig
			{
				ShowKeyboard = flag,
				ShowMouse = flag2,
				ShowJoystick = flag3,
				ShowKeyboardSecondaryMapping = (flag && _showSecondaryKeyboardMapping),
				ShowMouseSecondaryMapping = (flag2 && _showSecondaryMouseMapping),
				ShowJoystickSecondaryMapping = (flag3 && _showSecondaryJoystickMapping)
			};
			switch (categoryLayoutData.MappingSet.actionListMode)
			{
			case ControlMapper.MappingSet.ActionListMode.ActionCategory:
			{
				for (int num = 0; num < categoryLayoutData.MappingSet.actionCategoryIds.Count; num++)
				{
					int mapCategoryId = categoryLayoutData.MappingSet.actionCategoryIds[num];
					InputAction[] array = (from inputAction2 in ReInput.mapping.ActionsInCategory(mapCategoryId, sort: true)
						where inputAction2.userAssignable && ActionIsSupportedOnCurrentPlatform(inputAction2)
						select inputAction2).ToArray();
					if (array.Length != 0)
					{
						InputCategory actionCategory = ReInput.mapping.GetActionCategory(mapCategoryId);
						CreateCategoryLabel(categoryLayoutData.ShowActionCategoryName(num) ? GetCategoryLabelLocaKey(actionCategory.name, getName: true) : null, categoryLayoutData.ShowActionCategoryDescription(num) ? GetCategoryLabelLocaKey(actionCategory.name, getName: false) : null, i == 0);
					}
					InputAction[] array2 = array;
					foreach (InputAction inputAction in array2)
					{
						CreateActionMappingUiElement(inputAction.id, categoryLayoutData.MappingSet.mapCategoryId, config, allMappings);
					}
				}
				break;
			}
			case ControlMapper.MappingSet.ActionListMode.Action:
			{
				List<int> list = new List<int>();
				foreach (int actionId in categoryLayoutData.MappingSet.actionIds)
				{
					InputAction action = ReInput.mapping.GetAction(actionId);
					if (action.userAssignable && ActionIsSupportedOnCurrentPlatform(action))
					{
						list.Add(actionId);
					}
				}
				foreach (int item in list)
				{
					CreateActionMappingUiElement(item, categoryLayoutData.MappingSet.mapCategoryId, config, allMappings);
				}
				break;
			}
			default:
				throw new NotImplementedException();
			}
		}
		SetupNavigationForSingleActionMappings();
		layoutIsDirty = true;
		void CreateActionMappingUiElement(int inputActionId, int mapCategoryId2, ActionMappingDisplayConfig config2, List<ActionElementMap> allMappings2)
		{
			InputAction action2 = ReInput.mapping.GetAction(inputActionId);
			if (action2.type == InputActionType.Axis)
			{
				CreateActionMappingUiElementForMappingType(action2, mapCategoryId2, config2, ActionMappingType.PositiveAxis, allMappings2);
				CreateActionMappingUiElementForMappingType(action2, mapCategoryId2, config2, ActionMappingType.NegativeAxis, allMappings2);
			}
			else if (action2.type == InputActionType.Button)
			{
				CreateActionMappingUiElementForMappingType(action2, mapCategoryId2, config2, ActionMappingType.Default, allMappings2);
			}
		}
		void CreateActionMappingUiElementForMappingType(InputAction inputAction2, int mapCategoryId2, ActionMappingDisplayConfig displayConfig, ActionMappingType actionMappingType, List<ActionElementMap> source2)
		{
			List<ActionElementMap> source = source2.Where(delegate(ActionElementMap x)
			{
				bool flag4 = x.actionId.Equals(inputAction2.id);
				if (flag4 && x.elementType == ControllerElementType.Axis && x.axisRange == AxisRange.Full)
				{
					Debug.LogError(string.Format("{0}: user-assignable action \"{1}\" (id:{2}) has a mapping (id:{3}) for a full axis range. This is not currently supported and the mapping should be converted to two separate axis mappings.", "ControlMappingMenu", x.actionDescriptiveName, x.actionId, x.id), this);
					return false;
				}
				bool flag5 = AreEqual(x.axisContribution, actionMappingType);
				return flag4 && flag5;
			}).ToList();
			ControlMapping_ActionMapping freeComponent = _actionMappingPool.GetFreeComponent<ControlMapping_ActionMapping>(deferOnOccupied: false, deferReparent: true);
			_actionMappings.Add(freeComponent);
			freeComponent.transform.SetParent(_actionMappingContainer);
			freeComponent.Setup(displayConfig, actionMappingType, mapCategoryId2, inputAction2, source.ToList(), _keyboardLocalizationWhitelist);
			freeComponent.ActionMappingActivated += ActionMappingActivated;
			freeComponent.ActionMappingSelected += ActionMappingSelected;
			menuOptions.AddRange(freeComponent.GetActiveSingleActionMappingElements());
		}
		void CreateCategoryLabel(string nameKey, string descriptionKey, bool isFirst)
		{
			if (!((nameKey == null && descriptionKey == null) || isFirst))
			{
				ControlMapping_CategoryLabel freeComponent = _categoryLabelPool.GetFreeComponent<ControlMapping_CategoryLabel>();
				freeComponent.Setup(nameKey, descriptionKey, isFirst ? 4 : 16);
				freeComponent.transform.SetParent(_actionMappingContainer);
				_categoryLabels.Add(freeComponent);
			}
		}
		bool TryAddControllerMap(ref Dictionary<ControllerType, ControllerMap> reference, ControllerType controllerType, InputMapCategory inputMapCategory)
		{
			if (_controlMappingManager.PlatformSupportsMappingForControllerType(controllerType))
			{
				ControllerMap lastActiveControllerMap = GetLastActiveControllerMap(controllerType, inputMapCategory.id);
				if (lastActiveControllerMap != null)
				{
					reference.Add(controllerType, lastActiveControllerMap);
					return true;
				}
				Debug.LogWarning(string.Format("{0}.{1}: no {2} map found for map category with id {3} ({4}).", "ControlMappingMenu", "TryAddControllerMap", controllerType, inputMapCategory.id, inputMapCategory.name));
				return false;
			}
			Debug.LogWarning(string.Format("{0}.{1}: custom mapping for {2} is not supported on platform {3}.", "ControlMappingMenu", "TryAddControllerMap", controllerType, Application.platform));
			return false;
		}
	}

	private bool AreEqual(Pole axisContribution, ActionMappingType mappingType)
	{
		switch (axisContribution)
		{
		case Pole.Positive:
			if (mappingType != ActionMappingType.Default)
			{
				return mappingType == ActionMappingType.PositiveAxis;
			}
			return true;
		case Pole.Negative:
			if (mappingType != ActionMappingType.Default)
			{
				return mappingType == ActionMappingType.NegativeAxis;
			}
			return true;
		default:
			throw new ArgumentOutOfRangeException("axisContribution", axisContribution, null);
		}
	}

	private string GetCategoryLabelLocaKey(string category, bool getName)
	{
		return "ControlMapper/" + category + (getName ? "Category" : "Description");
	}

	private void SetupNavigationForSingleActionMappings()
	{
		for (int i = 0; i < _actionMappings.Count; i++)
		{
			ControlMapping_ActionMapping controlMapping_ActionMapping = _actionMappings[i];
			ControlMapping_ActionMapping controlMapping_ActionMapping2 = ((i > 0) ? _actionMappings[i - 1] : null);
			ControlMapping_ActionMapping controlMapping_ActionMapping3 = ((i < _actionMappings.Count - 1) ? _actionMappings[i + 1] : null);
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 2; k++)
				{
					ControlMapping_SingleActionMapping singleActionMapping = controlMapping_ActionMapping.GetSingleActionMapping((ControllerType)j, k == 0);
					if (controlMapping_ActionMapping2 != null)
					{
						ControlMapping_SingleActionMapping singleActionMapping2 = controlMapping_ActionMapping2.GetSingleActionMapping((ControllerType)j, k == 0);
						singleActionMapping.topUIElements.Add(singleActionMapping2);
						singleActionMapping.topUIElements.AddRange(controlMapping_ActionMapping2.GetActiveSingleActionMappingElements());
					}
					if (controlMapping_ActionMapping3 != null)
					{
						ControlMapping_SingleActionMapping singleActionMapping3 = controlMapping_ActionMapping3.GetSingleActionMapping((ControllerType)j, k == 0);
						singleActionMapping.bottomUIElements.Add(singleActionMapping3);
						singleActionMapping.bottomUIElements.AddRange(controlMapping_ActionMapping3.GetActiveSingleActionMappingElements());
					}
				}
			}
		}
	}

	private bool ActionIsSupportedOnCurrentPlatform(InputAction inputAction)
	{
		foreach (InputActionPlatformList item in _inputActionPlatformBlacklist)
		{
			if (item.Platforms.MatchesCurrentPlatform() && item.ActionIds.Contains(inputAction.id))
			{
				return false;
			}
		}
		return true;
	}

	private void ActionMappingActivated(ControlMapping_ActionMapping actionMapping, ControlMapping_SingleActionMapping singleMapping)
	{
		_activeSingleActionMapping = singleMapping;
		AxisRange axisRange = ((actionMapping.ActionMappingType != ActionMappingType.NegativeAxis) ? AxisRange.Positive : AxisRange.Negative);
		if (singleMapping.ActionElementMap == null)
		{
			ControllerMap lastActiveControllerMap = GetLastActiveControllerMap(singleMapping.ControllerType, actionMapping.MapCategoryId);
			_mappingController.StartAddActionMap(actionMapping.InputAction, axisRange, lastActiveControllerMap);
		}
		else
		{
			_mappingController.StartElementAssignmentChange(actionMapping.InputAction, axisRange, singleMapping.ActionElementMap?.controllerMap, singleMapping.ActionElementMap);
		}
	}

	private void ActionMappingSelected(ControlMapping_ActionMapping actionMapping, ControlMapping_SingleActionMapping singleMapping)
	{
		_uiScrollWindow.MoveScrollToIncludePosition(actionMapping.transform.localPosition.y, _scrollPadding);
	}

	private ControllerMap GetLastActiveControllerMap(ControllerType controllerType, int inputMapCategoryID)
	{
		int controllerId = 0;
		if (ReInput.controllers.GetLastActiveController().type == ControllerType.Joystick)
		{
			controllerId = ReInput.controllers.GetLastActiveController<Joystick>()?.id ?? 0;
		}
		return _player.controllers.maps.GetFirstMapInCategory(controllerType, controllerId, inputMapCategoryID);
	}

	private void Cleanup()
	{
		_mappingController.ActionMappingChanged -= OnActionMappingChanged;
		_mappingController.ActionMappingStarted -= OnActionMappingStarted;
		_mappingController.ActionMappingCompleted -= OnActionMappingCompleted;
		_mappingController.ActionMappingConflictFound -= OnActionMappingConflictFound;
		_mappingController.ResetToDefaultsCompleted -= OnResetToDefaultsCompleted;
		_mappingController.CalibrationStarted -= OnCalibrationStarted;
		_mappingController.CalibrationCompleted -= OnCalibrationCompleted;
		_mappingController.ActionRemoveOrReassignElement -= OnRemoveOrReassignElement;
		_mappingController.ActionRemoveOrReassignElementCanceled -= OnRemoveOrReassignElementCanceled;
		ReInput.ControllerConnectedEvent -= OnJoystickConnected;
		ReInput.ControllerDisconnectedEvent -= OnJoystickDisconnected;
		_uiScrollWindow.ResetScroll();
		base.selectedIndex = -1;
		_mappingController.Cleanup();
		CleanupActionMappings();
		CleanupCategoryLabels();
		CleanupCategoryButtons();
		menuOptions.Clear();
		ReInput.localization.Reload();
	}

	private void SaveChanges()
	{
		Manager.input.GetRewiredUserDataStore()?.SavePlayerData(0);
	}

	private void CleanupActionMappings()
	{
		foreach (ControlMapping_ActionMapping actionMapping in _actionMappings)
		{
			IEnumerable<RadicalMenuOption> activeElements = actionMapping.GetActiveSingleActionMappingElements();
			menuOptions.RemoveAll((RadicalMenuOption menuOption) => activeElements.Contains(menuOption));
			actionMapping.Cleanup();
			_actionMappingPool.Free(actionMapping);
		}
		_actionMappings.Clear();
	}

	private void CleanupCategoryLabels()
	{
		foreach (ControlMapping_CategoryLabel categoryLabel in _categoryLabels)
		{
			_categoryLabelPool.Free(categoryLabel);
		}
		_categoryLabels.Clear();
	}

	private void CleanupCategoryButtons()
	{
		foreach (ControlMapping_CategorySelector categorySelector in _categorySelectors)
		{
			_categoryButtonPool.Free(categorySelector);
		}
		_categorySelectors.Clear();
	}

	private bool PlatformAllowsMappingToElementIdentifier(ControllerElementIdentifier elementIdentifier)
	{
		PlatformFlags platformFlags;
		switch (Application.platform)
		{
		case RuntimePlatform.PS4:
			platformFlags = PlatformFlags.PS4;
			break;
		case RuntimePlatform.PS5:
			platformFlags = PlatformFlags.PS5;
			break;
		case RuntimePlatform.GameCoreXboxSeries:
		case RuntimePlatform.GameCoreXboxOne:
			platformFlags = PlatformFlags.Xbox;
			break;
		case RuntimePlatform.Switch:
			platformFlags = PlatformFlags.Switch;
			break;
		default:
			platformFlags = PlatformFlags.PC;
			break;
		}
		foreach (PlatformElementIdentifierBlacklist item in _elementIdentifierPlatformBlacklist)
		{
			if ((item.Platform.HasFlag(platformFlags) && item.ElementIdentifierIds.Contains(elementIdentifier.id)) || item.ElementIdentifierNames.Contains(elementIdentifier.name))
			{
				return false;
			}
		}
		return true;
	}

	private bool IsElementAllowedCallback(ControllerPollingInfo info)
	{
		return PlatformAllowsMappingToElementIdentifier(info.elementIdentifier);
	}

	public override List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		InputManager.ControllerPlatformType activeControllerPlatformType = Manager.input.GetActiveControllerPlatformType(checkSystemInput: true);
		bool flag = activeControllerPlatformType == InputManager.ControllerPlatformType.Keyboard || activeControllerPlatformType == InputManager.ControllerPlatformType.Mouse;
		if (_player.controllers.joystickCount <= 0 || flag)
		{
			return _helpButtonListNoJoystick;
		}
		return _helpButtonList;
	}

	protected override void Awake()
	{
	}

	public override void Activate()
	{
		if (_actionMappingPool == null || _categoryButtonPool == null)
		{
			Initialize();
		}
		LocalizedStringProvider localizedStringProvider = (LocalizedStringProvider)ReInput.localization.localizedStringProvider;
		if (localizedStringProvider != null && !_currentLanguageCode.Equals(Manager.prefs.language))
		{
			string text = $"ControlMapping{Path.DirectorySeparatorChar}RewiredElementLocalization_{Manager.prefs.language}";
			TextAsset textAsset = Resources.Load<TextAsset>(text);
			if (textAsset != null)
			{
				localizedStringProvider.localizedStringsFile = textAsset;
				_currentLanguageCode = Manager.prefs.language;
			}
			else
			{
				Debug.LogWarning("ControlMappingMenu: no localization asset found for language code " + Manager.prefs.language + ". Expected Resources/" + text + ". Controller element names will not be localized.");
			}
		}
		_inputEnabled = true;
		_uiScrollWindow.enabled = true;
		_mappingController.ActionMappingChanged += OnActionMappingChanged;
		_mappingController.ActionMappingStarted += OnActionMappingStarted;
		_mappingController.ActionMappingCompleted += OnActionMappingCompleted;
		_mappingController.ActionMappingConflictFound += OnActionMappingConflictFound;
		_mappingController.ResetToDefaultsCompleted += OnResetToDefaultsCompleted;
		_mappingController.CalibrationStarted += OnCalibrationStarted;
		_mappingController.CalibrationCompleted += OnCalibrationCompleted;
		_mappingController.ActionRemoveOrReassignElement += OnRemoveOrReassignElement;
		_mappingController.ActionRemoveOrReassignElementCanceled += OnRemoveOrReassignElementCanceled;
		ReInput.ControllerConnectedEvent += OnJoystickConnected;
		ReInput.ControllerDisconnectedEvent += OnJoystickDisconnected;
		_selectedDisplayCategoryIndex = 0;
		CreateCategorySelection();
		RefreshCurrentCategoryUi();
		OnCategoryActivated(_categorySelectors.FirstOrDefault((ControlMapping_CategorySelector x) => x.CategoryId.Equals(_selectedDisplayCategoryIndex)));
		base.Activate();
		base.selectedIndex = -1;
	}

	public override void Deactivate(bool pop)
	{
		Cleanup();
		SaveChanges();
		base.Deactivate(pop);
	}

	public void UpdateContainingElements(float scroll)
	{
	}

	public IEnumerable<UIelement> GetChildElements()
	{
		return menuOptions;
	}

	public bool IsBottomElementSelected()
	{
		ControlMapping_ActionMapping controlMapping_ActionMapping = _actionMappings.LastOrDefault();
		if (controlMapping_ActionMapping == null)
		{
			return false;
		}
		int num = controlMapping_ActionMapping.GetActiveSingleActionMappingElements().Count();
		List<UIelement> list = GetChildElements().ToList();
		int num2 = list.IndexOf(Manager.ui.currentSelectedUIElement);
		if (num2 < 0)
		{
			return false;
		}
		return num2 >= list.Count - num;
	}

	public bool IsTopElementSelected()
	{
		ControlMapping_ActionMapping controlMapping_ActionMapping = _actionMappings.FirstOrDefault();
		if (controlMapping_ActionMapping == null)
		{
			return false;
		}
		int num = controlMapping_ActionMapping.GetActiveSingleActionMappingElements().Count();
		int num2 = GetChildElements().ToList().IndexOf(Manager.ui.currentSelectedUIElement);
		if (num2 < 0)
		{
			return false;
		}
		return num2 <= num;
	}

	public float GetCurrentWindowHeight()
	{
		return _actionMappingContainer.GetComponent<LinearLayoutUIComponent>()?.GetUIComponentRenderHeight() ?? 0f;
	}
}
