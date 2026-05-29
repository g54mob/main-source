using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	public class ControlMapper : MonoBehaviour
	{
		private abstract class GUIElement
		{
			public readonly GameObject gameObject;

			protected readonly TMP_Text text;

			public readonly Selectable selectable;

			protected readonly UIElementInfo uiElementInfo;

			protected bool permanentStateSet;

			protected readonly List<GUIElement> children;

			public RectTransform rectTransform { get; private set; }

			public GUIElement(GameObject gameObject)
			{
			}

			public GUIElement(Selectable selectable, TMP_Text label)
			{
			}

			public virtual void SetInteractible(bool state, bool playTransition)
			{
			}

			public virtual void SetInteractible(bool state, bool playTransition, bool permanent)
			{
			}

			public virtual void SetTextWidth(int value)
			{
			}

			public virtual void SetFirstChildObjectWidth(LayoutElementSizeType type, int value)
			{
			}

			public virtual void SetLabel(string label)
			{
			}

			public virtual string GetLabel()
			{
				return null;
			}

			public virtual void AddChild(GUIElement child)
			{
			}

			public void SetElementInfoData(string identifier, int intData)
			{
			}

			public virtual void SetActive(bool state)
			{
			}

			protected virtual bool Init()
			{
				return false;
			}
		}

		private class GUIButton : GUIElement
		{
			protected Button button => null;

			public ButtonInfo buttonInfo => null;

			public GUIButton(GameObject gameObject)
			{
			}

			public GUIButton(Button button, TMP_Text label)
			{
			}

			public void SetButtonInfoData(string identifier, int intData)
			{
			}

			public void SetOnClickCallback(Action<ButtonInfo> callback)
			{
			}
		}

		private class GUIInputField : GUIElement
		{
			protected Button button => null;

			public InputFieldInfo fieldInfo => null;

			public bool hasToggle => false;

			public GUIToggle toggle { get; private set; }

			public int actionElementMapId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public int controllerId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public GUIInputField(GameObject gameObject)
			{
			}

			public GUIInputField(Button button, TMP_Text label)
			{
			}

			public void SetFieldInfoData(int actionId, AxisRange axisRange, ControllerType controllerType, int intData)
			{
			}

			public void SetOnClickCallback(Action<InputFieldInfo> callback)
			{
			}

			public virtual void SetInteractable(bool state, bool playTransition, bool permanent)
			{
			}

			public void AddToggle(GUIToggle toggle)
			{
			}
		}

		private class GUIToggle : GUIElement
		{
			protected Toggle toggle => null;

			public ToggleInfo toggleInfo => null;

			public int actionElementMapId
			{
				get
				{
					return 0;
				}
				set
				{
				}
			}

			public GUIToggle(GameObject gameObject)
			{
			}

			public GUIToggle(Toggle toggle, TMP_Text label)
			{
			}

			public void SetToggleInfoData(int actionId, AxisRange axisRange, ControllerType controllerType, int intData)
			{
			}

			public void SetOnSubmitCallback(Action<ToggleInfo, bool> callback)
			{
			}

			public void SetToggleState(bool state)
			{
			}
		}

		private class GUILabel
		{
			public GameObject gameObject { get; private set; }

			private TMP_Text text { get; set; }

			public RectTransform rectTransform { get; private set; }

			public GUILabel(GameObject gameObject)
			{
			}

			public GUILabel(TMP_Text label)
			{
			}

			public void SetSize(int width, int height)
			{
			}

			public void SetWidth(int width)
			{
			}

			public void SetHeight(int height)
			{
			}

			public void SetLabel(string label)
			{
			}

			public void SetFontStyle(FontStyles style)
			{
			}

			public void SetTextAlignment(TextAlignmentOptions alignment)
			{
			}

			public void SetActive(bool state)
			{
			}

			private bool Check()
			{
				return false;
			}
		}

		[Serializable]
		public class MappingSet
		{
			public enum ActionListMode
			{
				ActionCategory = 0,
				Action = 1
			}

			[SerializeField]
			private int _mapCategoryId;

			[SerializeField]
			private ActionListMode _actionListMode;

			[SerializeField]
			private int[] _actionCategoryIds;

			[SerializeField]
			private int[] _actionIds;

			private IList<int> _actionCategoryIdsReadOnly;

			private IList<int> _actionIdsReadOnly;

			public int mapCategoryId => 0;

			public ActionListMode actionListMode => default(ActionListMode);

			public IList<int> actionCategoryIds => null;

			public IList<int> actionIds => null;

			public bool isValid => false;

			public static MappingSet Default => null;

			public MappingSet()
			{
			}

			private MappingSet(int mapCategoryId, ActionListMode actionListMode, int[] actionCategoryIds, int[] actionIds)
			{
			}
		}

		[Serializable]
		public class InputBehaviorSettings
		{
			[SerializeField]
			private int _inputBehaviorId;

			[SerializeField]
			private bool _showJoystickAxisSensitivity;

			[SerializeField]
			private bool _showMouseXYAxisSensitivity;

			[SerializeField]
			private string _labelLanguageKey;

			[SerializeField]
			private string _joystickAxisSensitivityLabelLanguageKey;

			[SerializeField]
			private string _mouseXYAxisSensitivityLabelLanguageKey;

			[SerializeField]
			private Sprite _joystickAxisSensitivityIcon;

			[SerializeField]
			private Sprite _mouseXYAxisSensitivityIcon;

			[SerializeField]
			private float _joystickAxisSensitivityMin;

			[SerializeField]
			private float _joystickAxisSensitivityMax;

			[SerializeField]
			private float _mouseXYAxisSensitivityMin;

			[SerializeField]
			private float _mouseXYAxisSensitivityMax;

			public int inputBehaviorId => 0;

			public bool showJoystickAxisSensitivity => false;

			public bool showMouseXYAxisSensitivity => false;

			public string labelLanguageKey => null;

			public string joystickAxisSensitivityLabelLanguageKey => null;

			public string mouseXYAxisSensitivityLabelLanguageKey => null;

			public Sprite joystickAxisSensitivityIcon => null;

			public Sprite mouseXYAxisSensitivityIcon => null;

			public float joystickAxisSensitivityMin => 0f;

			public float joystickAxisSensitivityMax => 0f;

			public float mouseXYAxisSensitivityMin => 0f;

			public float mouseXYAxisSensitivityMax => 0f;

			public bool isValid => false;
		}

		[Serializable]
		private class Prefabs
		{
			[SerializeField]
			private GameObject _button;

			[SerializeField]
			private GameObject _fitButton;

			[SerializeField]
			private GameObject _inputGridLabel;

			[SerializeField]
			private GameObject _inputGridHeaderLabel;

			[SerializeField]
			private GameObject _inputGridFieldButton;

			[SerializeField]
			private GameObject _inputGridFieldInvertToggle;

			[SerializeField]
			private GameObject _window;

			[SerializeField]
			private GameObject _windowTitleText;

			[SerializeField]
			private GameObject _windowContentText;

			[SerializeField]
			private GameObject _fader;

			[SerializeField]
			private GameObject _calibrationWindow;

			[SerializeField]
			private GameObject _inputBehaviorsWindow;

			[SerializeField]
			private GameObject _centerStickGraphic;

			[SerializeField]
			private GameObject _moveStickGraphic;

			public GameObject button => null;

			public GameObject fitButton => null;

			public GameObject inputGridLabel => null;

			public GameObject inputGridHeaderLabel => null;

			public GameObject inputGridFieldButton => null;

			public GameObject inputGridFieldInvertToggle => null;

			public GameObject window => null;

			public GameObject windowTitleText => null;

			public GameObject windowContentText => null;

			public GameObject fader => null;

			public GameObject calibrationWindow => null;

			public GameObject inputBehaviorsWindow => null;

			public GameObject centerStickGraphic => null;

			public GameObject moveStickGraphic => null;

			public bool Check()
			{
				return false;
			}
		}

		[Serializable]
		private class References
		{
			[SerializeField]
			private Canvas _canvas;

			[SerializeField]
			private CanvasGroup _mainCanvasGroup;

			[SerializeField]
			private Transform _mainContent;

			[SerializeField]
			private Transform _mainContentInner;

			[SerializeField]
			private UIGroup _playersGroup;

			[SerializeField]
			private Transform _controllerGroup;

			[SerializeField]
			private Transform _controllerGroupLabelGroup;

			[SerializeField]
			private UIGroup _controllerSettingsGroup;

			[SerializeField]
			private UIGroup _assignedControllersGroup;

			[SerializeField]
			private Transform _settingsAndMapCategoriesGroup;

			[SerializeField]
			private UIGroup _settingsGroup;

			[SerializeField]
			private UIGroup _mapCategoriesGroup;

			[SerializeField]
			private Transform _inputGridGroup;

			[SerializeField]
			private Transform _inputGridContainer;

			[SerializeField]
			private Transform _inputGridHeadersGroup;

			[SerializeField]
			private Scrollbar _inputGridVScrollbar;

			[SerializeField]
			private ScrollRect _inputGridScrollRect;

			[SerializeField]
			private Transform _inputGridInnerGroup;

			[SerializeField]
			private TMP_Text _controllerNameLabel;

			[SerializeField]
			private Button _removeControllerButton;

			[SerializeField]
			private Button _assignControllerButton;

			[SerializeField]
			private Button _calibrateControllerButton;

			[SerializeField]
			private Button _doneButton;

			[SerializeField]
			private Button _restoreDefaultsButton;

			[SerializeField]
			private Selectable _defaultSelection;

			[SerializeField]
			private GameObject[] _fixedSelectableUIElements;

			[SerializeField]
			private Image _mainBackgroundImage;

			public Canvas canvas => null;

			public CanvasGroup mainCanvasGroup => null;

			public Transform mainContent => null;

			public Transform mainContentInner => null;

			public UIGroup playersGroup => null;

			public Transform controllerGroup => null;

			public Transform controllerGroupLabelGroup => null;

			public UIGroup controllerSettingsGroup => null;

			public UIGroup assignedControllersGroup => null;

			public Transform settingsAndMapCategoriesGroup => null;

			public UIGroup settingsGroup => null;

			public UIGroup mapCategoriesGroup => null;

			public Transform inputGridGroup => null;

			public Transform inputGridContainer => null;

			public Transform inputGridHeadersGroup => null;

			public Scrollbar inputGridVScrollbar => null;

			public ScrollRect inputGridScrollRect => null;

			public Transform inputGridInnerGroup => null;

			public TMP_Text controllerNameLabel => null;

			public Button removeControllerButton => null;

			public Button assignControllerButton => null;

			public Button calibrateControllerButton => null;

			public Button doneButton => null;

			public Button restoreDefaultsButton => null;

			public Selectable defaultSelection => null;

			public GameObject[] fixedSelectableUIElements => null;

			public Image mainBackgroundImage => null;

			public LayoutElement inputGridLayoutElement { get; set; }

			public Transform inputGridActionColumn { get; set; }

			public Transform inputGridKeyboardColumn { get; set; }

			public Transform inputGridMouseColumn { get; set; }

			public Transform inputGridControllerColumn { get; set; }

			public Transform inputGridHeader1 { get; set; }

			public Transform inputGridHeader2 { get; set; }

			public Transform inputGridHeader3 { get; set; }

			public Transform inputGridHeader4 { get; set; }

			public bool Check()
			{
				return false;
			}
		}

		private class InputActionSet
		{
			private int _actionId;

			private AxisRange _axisRange;

			public int actionId => 0;

			public AxisRange axisRange => default(AxisRange);

			public InputActionSet(int actionId, AxisRange axisRange)
			{
			}
		}

		private class InputMapping
		{
			public string actionName { get; private set; }

			public InputFieldInfo fieldInfo { get; private set; }

			public ControllerMap map { get; private set; }

			public ActionElementMap aem { get; private set; }

			public ControllerType controllerType { get; private set; }

			public int controllerId { get; private set; }

			public ControllerPollingInfo pollingInfo { get; set; }

			public ModifierKeyFlags modifierKeyFlags { get; set; }

			public AxisRange axisRange => default(AxisRange);

			public string elementName => null;

			public InputMapping(string actionName, InputFieldInfo fieldInfo, ControllerMap map, ActionElementMap aem, ControllerType controllerType, int controllerId)
			{
			}

			public ElementAssignment ToElementAssignment(ControllerPollingInfo pollingInfo)
			{
				return default(ElementAssignment);
			}

			public ElementAssignment ToElementAssignment(ControllerPollingInfo pollingInfo, ModifierKeyFlags modifierKeyFlags)
			{
				return default(ElementAssignment);
			}

			public ElementAssignment ToElementAssignment()
			{
				return default(ElementAssignment);
			}
		}

		private class AxisCalibrator
		{
			public AxisCalibrationData data;

			public readonly Joystick joystick;

			public readonly int axisIndex;

			private Controller.Axis axis;

			private bool firstRun;

			public bool isValid => false;

			public AxisCalibrator(Joystick joystick, int axisIndex)
			{
			}

			public void RecordMinMax()
			{
			}

			public void RecordZero()
			{
			}

			public void Commit()
			{
			}
		}

		private class IndexedDictionary<TKey, TValue>
		{
			private class Entry
			{
				public TKey key;

				public TValue value;

				public Entry(TKey key, TValue value)
				{
				}
			}

			private List<Entry> list;

			public int Count => 0;

			public TValue Item => default(TValue);

			public TValue Get(TKey key)
			{
				return default(TValue);
			}

			public bool TryGet(TKey key, out TValue value)
			{
				value = default(TValue);
				return false;
			}

			public void Add(TKey key, TValue value)
			{
			}

			public int IndexOfKey(TKey key)
			{
				return 0;
			}

			public bool ContainsKey(TKey key)
			{
				return false;
			}

			public void Clear()
			{
			}
		}

		private enum LayoutElementSizeType
		{
			MinSize = 0,
			PreferredSize = 1
		}

		private enum WindowType
		{
			None = 0,
			ChooseJoystick = 1,
			JoystickAssignmentConflict = 2,
			ElementAssignment = 3,
			ElementAssignmentPrePolling = 4,
			ElementAssignmentPolling = 5,
			ElementAssignmentResult = 6,
			ElementAssignmentConflict = 7,
			Calibration = 8,
			CalibrateStep1 = 9,
			CalibrateStep2 = 10
		}

		private class InputGrid
		{
			private InputGridEntryList list;

			private List<GameObject> groups;

			public void AddMapCategory(int mapCategoryId)
			{
			}

			public void AddAction(int mapCategoryId, InputAction action, AxisRange axisRange)
			{
			}

			public void AddActionCategory(int mapCategoryId, int actionCategoryId)
			{
			}

			public void AddInputFieldSet(int mapCategoryId, InputAction action, AxisRange axisRange, ControllerType controllerType, GameObject fieldSetContainer)
			{
			}

			public void AddInputField(int mapCategoryId, InputAction action, AxisRange axisRange, ControllerType controllerType, int fieldIndex, GUIInputField inputField)
			{
			}

			public void AddGroup(GameObject group)
			{
			}

			public void AddActionLabel(int mapCategoryId, int actionId, AxisRange axisRange, GUILabel label)
			{
			}

			public void AddActionCategoryLabel(int mapCategoryId, int actionCategoryId, GUILabel label)
			{
			}

			public bool Contains(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int fieldIndex)
			{
				return false;
			}

			public GUIInputField GetGUIInputField(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int fieldIndex)
			{
				return null;
			}

			public IEnumerable<InputActionSet> GetActionSets(int mapCategoryId)
			{
				return null;
			}

			public void SetColumnHeight(int mapCategoryId, float height)
			{
			}

			public float GetColumnHeight(int mapCategoryId)
			{
				return 0f;
			}

			public void SetFieldsActive(int mapCategoryId, bool state)
			{
			}

			public void SetFieldLabel(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int index, string label)
			{
			}

			public void PopulateField(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int controllerId, int index, int actionElementMapId, string label, bool invert)
			{
			}

			public void SetFixedFieldData(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int controllerId)
			{
			}

			public void InitializeFields(int mapCategoryId)
			{
			}

			public void Show(int mapCategoryId)
			{
			}

			public void HideAll()
			{
			}

			public void ClearLabels(int mapCategoryId)
			{
			}

			private void ClearGroups()
			{
			}

			public void ClearAll()
			{
			}
		}

		private class InputGridEntryList
		{
			private class MapCategoryEntry
			{
				private List<ActionEntry> _actionList;

				private IndexedDictionary<int, ActionCategoryEntry> _actionCategoryList;

				private float _columnHeight;

				public List<ActionEntry> actionList => null;

				public IndexedDictionary<int, ActionCategoryEntry> actionCategoryList => null;

				public float columnHeight
				{
					get
					{
						return 0f;
					}
					set
					{
					}
				}

				public ActionEntry GetActionEntry(int actionId, AxisRange axisRange)
				{
					return null;
				}

				public int IndexOfActionEntry(int actionId, AxisRange axisRange)
				{
					return 0;
				}

				public bool ContainsActionEntry(int actionId, AxisRange axisRange)
				{
					return false;
				}

				public ActionEntry AddAction(InputAction action, AxisRange axisRange)
				{
					return null;
				}

				public ActionCategoryEntry GetActionCategoryEntry(int actionCategoryId)
				{
					return null;
				}

				public ActionCategoryEntry AddActionCategory(int actionCategoryId)
				{
					return null;
				}

				public void SetAllActive(bool state)
				{
				}
			}

			private class ActionEntry
			{
				private IndexedDictionary<int, FieldSet> fieldSets;

				public GUILabel label;

				public readonly InputAction action;

				public readonly AxisRange axisRange;

				public readonly InputActionSet actionSet;

				public ActionEntry(InputAction action, AxisRange axisRange)
				{
				}

				public void SetLabel(GUILabel label)
				{
				}

				public bool Matches(int actionId, AxisRange axisRange)
				{
					return false;
				}

				public void AddInputFieldSet(ControllerType controllerType, GameObject fieldSetContainer)
				{
				}

				public void AddInputField(ControllerType controllerType, int fieldIndex, GUIInputField inputField)
				{
				}

				public GUIInputField GetGUIInputField(ControllerType controllerType, int fieldIndex)
				{
					return null;
				}

				public bool Contains(ControllerType controllerType, int fieldId)
				{
					return false;
				}

				public void SetFieldLabel(ControllerType controllerType, int index, string label)
				{
				}

				public void PopulateField(ControllerType controllerType, int controllerId, int index, int actionElementMapId, string label, bool invert)
				{
				}

				public void SetFixedFieldData(ControllerType controllerType, int controllerId)
				{
				}

				public void Initialize()
				{
				}

				public void SetActive(bool state)
				{
				}

				public void ClearLabels()
				{
				}

				public void SetFieldsActive(bool state)
				{
				}
			}

			private class FieldSet
			{
				public readonly GameObject groupContainer;

				public readonly IndexedDictionary<int, GUIInputField> fields;

				public FieldSet(GameObject groupContainer)
				{
				}
			}

			private class ActionCategoryEntry
			{
				public readonly int actionCategoryId;

				public GUILabel label;

				public ActionCategoryEntry(int actionCategoryId)
				{
				}

				public void SetLabel(GUILabel label)
				{
				}

				public void SetActive(bool state)
				{
				}
			}

			private IndexedDictionary<int, MapCategoryEntry> entries;

			public void AddMapCategory(int mapCategoryId)
			{
			}

			public void AddAction(int mapCategoryId, InputAction action, AxisRange axisRange)
			{
			}

			private ActionEntry AddActionEntry(int mapCategoryId, InputAction action, AxisRange axisRange)
			{
				return null;
			}

			public void AddActionLabel(int mapCategoryId, int actionId, AxisRange axisRange, GUILabel label)
			{
			}

			public void AddActionCategory(int mapCategoryId, int actionCategoryId)
			{
			}

			private ActionCategoryEntry AddActionCategoryEntry(int mapCategoryId, int actionCategoryId)
			{
				return null;
			}

			public void AddActionCategoryLabel(int mapCategoryId, int actionCategoryId, GUILabel label)
			{
			}

			public void AddInputFieldSet(int mapCategoryId, InputAction action, AxisRange axisRange, ControllerType controllerType, GameObject fieldSetContainer)
			{
			}

			public void AddInputField(int mapCategoryId, InputAction action, AxisRange axisRange, ControllerType controllerType, int fieldIndex, GUIInputField inputField)
			{
			}

			public bool Contains(int mapCategoryId, int actionId, AxisRange axisRange)
			{
				return false;
			}

			public bool Contains(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int fieldIndex)
			{
				return false;
			}

			public void SetColumnHeight(int mapCategoryId, float height)
			{
			}

			public float GetColumnHeight(int mapCategoryId)
			{
				return 0f;
			}

			public GUIInputField GetGUIInputField(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int fieldIndex)
			{
				return null;
			}

			private ActionEntry GetActionEntry(int mapCategoryId, int actionId, AxisRange axisRange)
			{
				return null;
			}

			private ActionEntry GetActionEntry(int mapCategoryId, InputAction action, AxisRange axisRange)
			{
				return null;
			}

			public IEnumerable<InputActionSet> GetActionSets(int mapCategoryId)
			{
				return null;
			}

			public void SetFieldsActive(int mapCategoryId, bool state)
			{
			}

			public void SetLabel(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int index, string label)
			{
			}

			public void PopulateField(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int controllerId, int index, int actionElementMapId, string label, bool invert)
			{
			}

			public void SetFixedFieldData(int mapCategoryId, int actionId, AxisRange axisRange, ControllerType controllerType, int controllerId)
			{
			}

			public void InitializeFields(int mapCategoryId)
			{
			}

			public void Show(int mapCategoryId)
			{
			}

			public void HideAll()
			{
			}

			public void ClearLabels(int mapCategoryId)
			{
			}

			public void Clear()
			{
			}
		}

		private class WindowManager
		{
			private List<Window> windows;

			private GameObject windowPrefab;

			private Transform parent;

			private GameObject fader;

			private int idCounter;

			public bool isWindowOpen => false;

			public Window topWindow => null;

			public WindowManager(GameObject windowPrefab, GameObject faderPrefab, Transform parent)
			{
			}

			public Window OpenWindow(string name, int width, int height)
			{
				return null;
			}

			public Window OpenWindow(GameObject windowPrefab, string name)
			{
				return null;
			}

			public void CloseTop()
			{
			}

			public void CloseWindow(int windowId)
			{
			}

			public void CloseWindow(Window window)
			{
			}

			public void CloseAll()
			{
			}

			public void CancelAll()
			{
			}

			public Window GetWindow(int windowId)
			{
				return null;
			}

			public bool IsFocused(int windowId)
			{
				return false;
			}

			public void Focus(int windowId)
			{
			}

			public void Focus(Window window)
			{
			}

			private void DefocusOtherWindows(int focusedWindowId)
			{
			}

			private void UpdateFader()
			{
			}

			private void FocusTopWindow()
			{
			}

			private void SetFaderActive(bool state)
			{
			}

			private Window InstantiateWindow(string name, int width, int height)
			{
				return null;
			}

			private Window InstantiateWindow(string name, GameObject windowPrefab)
			{
				return null;
			}

			private void DestroyWindow(Window window)
			{
			}

			private int GetNewId()
			{
				return 0;
			}

			public void ClearCompletely()
			{
			}
		}

		public const int versionMajor = 1;

		public const int versionMinor = 1;

		public const bool usesTMPro = true;

		private const float blockInputOnFocusTimeout = 0.1f;

		private const string buttonIdentifier_playerSelection = "PlayerSelection";

		private const string buttonIdentifier_removeController = "RemoveController";

		private const string buttonIdentifier_assignController = "AssignController";

		private const string buttonIdentifier_calibrateController = "CalibrateController";

		private const string buttonIdentifier_editInputBehaviors = "EditInputBehaviors";

		private const string buttonIdentifier_mapCategorySelection = "MapCategorySelection";

		private const string buttonIdentifier_assignedControllerSelection = "AssignedControllerSelection";

		private const string buttonIdentifier_done = "Done";

		private const string buttonIdentifier_restoreDefaults = "RestoreDefaults";

		[SerializeField]
		private InputManager _rewiredInputManager;

		[SerializeField]
		private bool _dontDestroyOnLoad;

		[SerializeField]
		private bool _openOnStart;

		[SerializeField]
		private int _keyboardMapDefaultLayout;

		[SerializeField]
		private int _mouseMapDefaultLayout;

		[SerializeField]
		private int _joystickMapDefaultLayout;

		[SerializeField]
		private MappingSet[] _mappingSets;

		[SerializeField]
		private bool _showPlayers;

		[SerializeField]
		private bool _showControllers;

		[SerializeField]
		private bool _showKeyboard;

		[SerializeField]
		private bool _showMouse;

		[SerializeField]
		private int _maxControllersPerPlayer;

		[SerializeField]
		private bool _showActionCategoryLabels;

		[SerializeField]
		private int _keyboardInputFieldCount;

		[SerializeField]
		private int _mouseInputFieldCount;

		[SerializeField]
		private int _controllerInputFieldCount;

		[SerializeField]
		private bool _showFullAxisInputFields;

		[SerializeField]
		private bool _showSplitAxisInputFields;

		[SerializeField]
		private bool _allowElementAssignmentConflicts;

		[SerializeField]
		private bool _allowElementAssignmentSwap;

		[SerializeField]
		private int _actionLabelWidth;

		[SerializeField]
		private int _keyboardColMaxWidth;

		[SerializeField]
		private int _mouseColMaxWidth;

		[SerializeField]
		private int _controllerColMaxWidth;

		[SerializeField]
		private int _inputRowHeight;

		[SerializeField]
		private RectOffset _inputRowPadding;

		[SerializeField]
		private int _inputRowFieldSpacing;

		[SerializeField]
		private int _inputColumnSpacing;

		[SerializeField]
		private int _inputRowCategorySpacing;

		[SerializeField]
		private int _invertToggleWidth;

		[SerializeField]
		private int _defaultWindowWidth;

		[SerializeField]
		private int _defaultWindowHeight;

		[SerializeField]
		private float _controllerAssignmentTimeout;

		[SerializeField]
		private float _preInputAssignmentTimeout;

		[SerializeField]
		private float _inputAssignmentTimeout;

		[SerializeField]
		private float _axisCalibrationTimeout;

		[SerializeField]
		private bool _ignoreMouseXAxisAssignment;

		[SerializeField]
		private bool _ignoreMouseYAxisAssignment;

		[SerializeField]
		private int _screenToggleAction;

		[SerializeField]
		private int _screenOpenAction;

		[SerializeField]
		private int _screenCloseAction;

		[SerializeField]
		private int _universalCancelAction;

		[SerializeField]
		private bool _universalCancelClosesScreen;

		[SerializeField]
		private bool _showInputBehaviorSettings;

		[SerializeField]
		private InputBehaviorSettings[] _inputBehaviorSettings;

		[SerializeField]
		private bool _useThemeSettings;

		[SerializeField]
		private ThemeSettings _themeSettings;

		[SerializeField]
		private LanguageDataBase _language;

		[SerializeField]
		private Prefabs prefabs;

		[SerializeField]
		private References references;

		[SerializeField]
		private bool _showPlayersGroupLabel;

		[SerializeField]
		private bool _showControllerGroupLabel;

		[SerializeField]
		private bool _showAssignedControllersGroupLabel;

		[SerializeField]
		private bool _showSettingsGroupLabel;

		[SerializeField]
		private bool _showMapCategoriesGroupLabel;

		[SerializeField]
		private bool _showControllerNameLabel;

		[SerializeField]
		private bool _showAssignedControllers;

		private Action _ScreenClosedEvent;

		private Action _ScreenOpenedEvent;

		private Action _PopupWindowOpenedEvent;

		private Action _PopupWindowClosedEvent;

		private Action _InputPollingStartedEvent;

		private Action _InputPollingEndedEvent;

		[SerializeField]
		private UnityEvent _onScreenClosed;

		[SerializeField]
		private UnityEvent _onScreenOpened;

		[SerializeField]
		private UnityEvent _onPopupWindowClosed;

		[SerializeField]
		private UnityEvent _onPopupWindowOpened;

		[SerializeField]
		private UnityEvent _onInputPollingStarted;

		[SerializeField]
		private UnityEvent _onInputPollingEnded;

		private static ControlMapper Instance;

		private bool initialized;

		private int playerCount;

		private InputGrid inputGrid;

		private WindowManager windowManager;

		private int currentPlayerId;

		private int currentMapCategoryId;

		private List<GUIButton> playerButtons;

		private List<GUIButton> mapCategoryButtons;

		private List<GUIButton> assignedControllerButtons;

		private GUIButton assignedControllerButtonsPlaceholder;

		private List<GameObject> miscInstantiatedObjects;

		private GameObject canvas;

		private GameObject lastUISelection;

		private int currentJoystickId;

		private float blockInputOnFocusEndTime;

		private bool isPollingForInput;

		private InputMapping pendingInputMapping;

		private AxisCalibrator pendingAxisCalibration;

		private Action<InputFieldInfo> inputFieldActivatedDelegate;

		private Action<ToggleInfo, bool> inputFieldInvertToggleStateChangedDelegate;

		private Action _restoreDefaultsDelegate;

		public InputManager rewiredInputManager
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool dontDestroyOnLoad
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int keyboardMapDefaultLayout
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int mouseMapDefaultLayout
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int joystickMapDefaultLayout
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool showPlayers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showControllers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showKeyboard
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showMouse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int maxControllersPerPlayer
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool showActionCategoryLabels
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int keyboardInputFieldCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int mouseInputFieldCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int controllerInputFieldCount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool showFullAxisInputFields
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showSplitAxisInputFields
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool allowElementAssignmentConflicts
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool allowElementAssignmentSwap
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int actionLabelWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int keyboardColMaxWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int mouseColMaxWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int controllerColMaxWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int inputRowHeight
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int inputColumnSpacing
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int inputRowCategorySpacing
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int invertToggleWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int defaultWindowWidth
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int defaultWindowHeight
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float controllerAssignmentTimeout
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float preInputAssignmentTimeout
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float inputAssignmentTimeout
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float axisCalibrationTimeout
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool ignoreMouseXAxisAssignment
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ignoreMouseYAxisAssignment
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool universalCancelClosesScreen
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showInputBehaviorSettings
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool useThemeSettings
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LanguageDataBase language
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool showPlayersGroupLabel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showControllerGroupLabel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showAssignedControllersGroupLabel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showSettingsGroupLabel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showMapCategoriesGroupLabel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showControllerNameLabel
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool showAssignedControllers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public Action restoreDefaultsDelegate
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool isOpen => false;

		private bool isFocused => false;

		private bool inputAllowed => false;

		private int inputGridColumnCount => 0;

		private int inputGridWidth => 0;

		private Player currentPlayer => null;

		private InputCategory currentMapCategory => null;

		private MappingSet currentMappingSet => null;

		private Joystick currentJoystick => null;

		private bool isJoystickSelected => false;

		private GameObject currentUISelection => null;

		private bool showSettings => false;

		private bool showMapCategories => false;

		public event Action ScreenClosedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action ScreenOpenedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action PopupWindowClosedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action PopupWindowOpenedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action InputPollingStartedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event Action InputPollingEndedEvent
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction onScreenClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction onScreenOpened
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction onPopupWindowClosed
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction onPopupWindowOpened
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction onInputPollingStarted
		{
			add
			{
			}
			remove
			{
			}
		}

		public event UnityAction onInputPollingEnded
		{
			add
			{
			}
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		private void PreInitialize()
		{
		}

		private void Initialize()
		{
		}

		private void OnJoystickConnected(ControllerStatusChangedEventArgs args)
		{
		}

		private void OnJoystickDisconnected(ControllerStatusChangedEventArgs args)
		{
		}

		private void OnJoystickPreDisconnect(ControllerStatusChangedEventArgs args)
		{
		}

		public void OnButtonActivated(ButtonInfo buttonInfo)
		{
		}

		public void OnInputFieldActivated(InputFieldInfo fieldInfo)
		{
		}

		public void OnInputFieldInvertToggleStateChanged(ToggleInfo toggleInfo, bool newState)
		{
		}

		private void OnPlayerSelected(int playerId, bool redraw)
		{
		}

		private void OnControllerSelected(int joystickId)
		{
		}

		private void OnRemoveCurrentController()
		{
		}

		private void OnMapCategorySelected(int id, bool redraw)
		{
		}

		private void OnRestoreDefaults()
		{
		}

		private void OnScreenToggleActionPressed(InputActionEventData data)
		{
		}

		private void OnScreenOpenActionPressed(InputActionEventData data)
		{
		}

		private void OnScreenCloseActionPressed(InputActionEventData data)
		{
		}

		private void OnUniversalCancelActionPressed(InputActionEventData data)
		{
		}

		private void OnWindowCancel(int windowId)
		{
		}

		private void OnRemoveElementAssignment(int windowId, ControllerMap map, ActionElementMap aem)
		{
		}

		private void OnBeginElementAssignment(InputFieldInfo fieldInfo, ControllerMap map, ActionElementMap aem, string actionName)
		{
		}

		private void OnControllerAssignmentConfirmed(int windowId, Player player, int controllerId)
		{
		}

		private void OnMouseAssignmentConfirmed(int windowId, Player player)
		{
		}

		private void OnElementAssignmentConflictReplaceConfirmed(int windowId, InputMapping mapping, ElementAssignment assignment, bool skipOtherPlayers, bool allowSwap)
		{
		}

		private void OnElementAssignmentAddConfirmed(int windowId, InputMapping mapping, ElementAssignment assignment)
		{
		}

		private void OnRestoreDefaultsConfirmed(int windowId)
		{
		}

		private void OnAssignControllerWindowUpdate(int windowId)
		{
		}

		private void OnElementAssignmentPrePollingWindowUpdate(int windowId)
		{
		}

		private void OnJoystickElementAssignmentPollingWindowUpdate(int windowId)
		{
		}

		private void OnKeyboardElementAssignmentPollingWindowUpdate(int windowId)
		{
		}

		private void OnMouseElementAssignmentPollingWindowUpdate(int windowId)
		{
		}

		private void OnCalibrateAxisStep1WindowUpdate(int windowId)
		{
		}

		private void OnCalibrateAxisStep2WindowUpdate(int windowId)
		{
		}

		private void ShowAssignControllerWindow()
		{
		}

		private void ShowControllerAssignmentConflictWindow(int controllerId)
		{
		}

		private void ShowBeginElementAssignmentReplacementWindow(InputFieldInfo fieldInfo, InputAction action, ControllerMap map, ActionElementMap aem, string actionName)
		{
		}

		private void ShowCreateNewElementAssignmentWindow(InputFieldInfo fieldInfo, InputAction action, ControllerMap map, string actionName)
		{
		}

		private void ShowElementAssignmentPrePollingWindow()
		{
		}

		private void ShowElementAssignmentPollingWindow()
		{
		}

		private void ShowJoystickElementAssignmentPollingWindow()
		{
		}

		private void ShowKeyboardElementAssignmentPollingWindow()
		{
		}

		private void ShowMouseElementAssignmentPollingWindow()
		{
		}

		private void ShowElementAssignmentConflictWindow(ElementAssignment assignment, bool skipOtherPlayers)
		{
		}

		private void ShowMouseAssignmentConflictWindow()
		{
		}

		private void ShowCalibrateControllerWindow()
		{
		}

		private void ShowCalibrateAxisStep1Window()
		{
		}

		private void ShowCalibrateAxisStep2Window()
		{
		}

		private void ShowEditInputBehaviorsWindow()
		{
		}

		private void ShowRestoreDefaultsWindow()
		{
		}

		private void CreateInputGrid()
		{
		}

		private void InitializeInputGrid()
		{
		}

		private void RefreshInputGridStructure()
		{
		}

		private void CreateHeaderLabels()
		{
		}

		private void CreateActionLabelColumn()
		{
		}

		private void CreateKeyboardInputFieldColumn()
		{
		}

		private void CreateMouseInputFieldColumn()
		{
		}

		private void CreateControllerInputFieldColumn()
		{
		}

		private void CreateInputFieldColumn(string name, ControllerType controllerType, int maxWidth, int cols, bool disableFullAxis)
		{
		}

		private void CreateInputActionLabels()
		{
		}

		private void CreateInputFields()
		{
		}

		private void CreateInputFields(Transform columnXform, ControllerType controllerType, int maxWidth, int cols, bool disableFullAxis)
		{
		}

		private void CreateInputFieldSet(Transform parent, int mapCategoryId, InputAction action, AxisRange axisRange, ControllerType controllerType, int cols, int fieldWidth, ref int yPos, bool disableFullAxis)
		{
		}

		private void PopulateInputFields()
		{
		}

		private void PopulateInputFieldGroup(InputActionSet actionSet, ControllerMap controllerMap, ControllerType controllerType, int controllerId, int maxFields)
		{
		}

		private void DisableInputFieldGroup(InputActionSet actionSet, ControllerType controllerType, int fieldCount)
		{
		}

		private void ResetInputGridScrollBar()
		{
		}

		private void CreateLayout()
		{
		}

		private void Draw()
		{
		}

		private void DrawPlayersGroup()
		{
		}

		private void DrawControllersGroup()
		{
		}

		private void DrawSettingsGroup()
		{
		}

		private void DrawMapCategoriesGroup()
		{
		}

		private void DrawWindowButtonsGroup()
		{
		}

		private void Redraw(bool listsChanged, bool playTransitions)
		{
		}

		private void RedrawPlayerGroup(bool playTransitions)
		{
		}

		private void RedrawControllerGroup()
		{
		}

		private void RedrawMapCategoriesGroup(bool playTransitions)
		{
		}

		private void RedrawInputGrid(bool listsChanged)
		{
		}

		private void ForceRefresh()
		{
		}

		private void CreateInputCategoryRow(ref int rowCount, InputCategory category)
		{
		}

		private GUILabel CreateLabel(string labelText, Transform parent, Vector2 offset)
		{
			return null;
		}

		private GUILabel CreateLabel(GameObject prefab, string labelText, Transform parent, Vector2 offset)
		{
			return null;
		}

		private GUIButton CreateButton(string labelText, Transform parent, Vector2 offset)
		{
			return null;
		}

		private GUIButton CreateFitButton(string labelText, Transform parent, Vector2 offset)
		{
			return null;
		}

		private GUIInputField CreateInputField(Transform parent, Vector2 offset, string label, int actionId, AxisRange axisRange, ControllerType controllerType, int fieldIndex)
		{
			return null;
		}

		private GUIInputField CreateInputField(Transform parent, Vector2 offset)
		{
			return null;
		}

		private GUIToggle CreateToggle(GameObject prefab, Transform parent, Vector2 offset, string label, int actionId, AxisRange axisRange, ControllerType controllerType, int fieldIndex)
		{
			return null;
		}

		private GUIToggle CreateToggle(GameObject prefab, Transform parent, Vector2 offset)
		{
			return null;
		}

		private GameObject InstantiateGUIObject(GameObject prefab, Transform parent, Vector2 offset)
		{
			return null;
		}

		private GameObject CreateNewGUIObject(string name, Transform parent, Vector2 offset)
		{
			return null;
		}

		private GameObject InitializeNewGUIGameObject(GameObject gameObject, Transform parent, Vector2 offset)
		{
			return null;
		}

		private GameObject CreateNewColumnGroup(string name, Transform parent, int maxWidth)
		{
			return null;
		}

		private Window OpenWindow(bool closeOthers)
		{
			return null;
		}

		private Window OpenWindow(string name, bool closeOthers)
		{
			return null;
		}

		private Window OpenWindow(GameObject windowPrefab, bool closeOthers)
		{
			return null;
		}

		private Window OpenWindow(GameObject windowPrefab, string name, bool closeOthers)
		{
			return null;
		}

		private void OpenModal(string title, string message, string confirmText, Action<int> confirmAction, string cancelText, Action<int> cancelAction, bool closeOthers)
		{
		}

		private void CloseWindow(int windowId)
		{
		}

		private void CloseTopWindow()
		{
		}

		private void CloseAllWindows()
		{
		}

		private void ChildWindowOpened()
		{
		}

		private void ChildWindowClosed()
		{
		}

		private bool HasElementAssignmentConflicts(Player player, InputMapping mapping, ElementAssignment assignment, bool skipOtherPlayers)
		{
			return false;
		}

		private bool IsBlockingAssignmentConflict(InputMapping mapping, ElementAssignment assignment, bool skipOtherPlayers)
		{
			return false;
		}

		private IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(Player player, InputMapping mapping, ElementAssignment assignment, bool skipOtherPlayers)
		{
			return null;
		}

		private bool CreateConflictCheck(InputMapping mapping, ElementAssignment assignment, out ElementAssignmentConflictCheck conflictCheck)
		{
			conflictCheck = default(ElementAssignmentConflictCheck);
			return false;
		}

		private void PollKeyboardForAssignment(out ControllerPollingInfo pollingInfo, out bool modifierKeyPressed, out ModifierKeyFlags modifierFlags, out string label)
		{
			pollingInfo = default(ControllerPollingInfo);
			modifierKeyPressed = default(bool);
			modifierFlags = default(ModifierKeyFlags);
			label = null;
		}

		private bool GetFirstElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, out ElementAssignmentConflictInfo conflict, bool skipOtherPlayers)
		{
			conflict = default(ElementAssignmentConflictInfo);
			return false;
		}

		private bool GetFirstElementAssignmentConflict(Player player, ElementAssignmentConflictCheck conflictCheck, out ElementAssignmentConflictInfo conflict)
		{
			conflict = default(ElementAssignmentConflictInfo);
			return false;
		}

		private void StartAxisCalibration(int axisIndex)
		{
		}

		private void EndAxisCalibration()
		{
		}

		private void SetUISelection(GameObject selection)
		{
		}

		private void RestoreLastUISelection()
		{
		}

		private void SetDefaultUISelection()
		{
		}

		private void SelectDefaultMapCategory(bool redraw)
		{
		}

		private void CheckUISelection()
		{
		}

		private void OnUIElementSelected(GameObject selectedObject)
		{
		}

		private void SetIsFocused(bool state)
		{
		}

		public void Toggle()
		{
		}

		public void Open()
		{
		}

		private void Open(bool force)
		{
		}

		public void Close(bool save)
		{
		}

		private void Clear()
		{
		}

		private void ClearCompletely()
		{
		}

		private void ClearSpawnedObjects()
		{
		}

		private void ClearVarsOnPlayerChange()
		{
		}

		private void ClearVarsOnJoystickChange()
		{
		}

		private void ClearAllVars()
		{
		}

		public void Reset()
		{
		}

		private void SetActionAxisInverted(bool state, ControllerType controllerType, int actionElementMapId)
		{
		}

		private ControllerMap GetControllerMap(ControllerType type)
		{
			return null;
		}

		private ControllerMap GetControllerMapOrCreateNew(ControllerType controllerType, int controllerId, int layoutId)
		{
			return null;
		}

		private int CountIEnumerable<T>(IEnumerable<T> enumerable)
		{
			return 0;
		}

		private int GetDefaultMapCategoryId()
		{
			return 0;
		}

		private void SubscribeFixedUISelectionEvents()
		{
		}

		private void SubscribeMenuControlInputEvents()
		{
		}

		private void UnsubscribeMenuControlInputEvents()
		{
		}

		private void SubscribeRewiredInputEventAllPlayers(int actionId, Action<InputActionEventData> callback)
		{
		}

		private void UnsubscribeRewiredInputEventAllPlayers(int actionId, Action<InputActionEventData> callback)
		{
		}

		private int GetMaxControllersPerPlayer()
		{
			return 0;
		}

		private bool ShowAssignedControllers()
		{
			return false;
		}

		private void InspectorPropertyChanged(bool reset = false)
		{
		}

		private void AssignController(Player player, int controllerId)
		{
		}

		private void RemoveAllControllers(Player player)
		{
		}

		private void RemoveController(Player player, int controllerId)
		{
		}

		private bool IsAllowedAssignment(InputMapping pendingInputMapping, ControllerPollingInfo pollingInfo)
		{
			return false;
		}

		private void InputPollingStarted()
		{
		}

		private void InputPollingStopped()
		{
		}

		private int GetControllerInputFieldCount(ControllerType controllerType)
		{
			return 0;
		}

		private bool ShowSwapButton(int windowId, InputMapping mapping, ElementAssignment assignment, bool skipOtherPlayers)
		{
			return false;
		}

		private bool SwapIsSameInputRange(ControllerElementType origElementType, AxisRange origAxisRange, Pole origAxisContribution, ControllerElementType conflictElementType, AxisRange conflictAxisRange, Pole conflictAxisContribution)
		{
			return false;
		}

		public static void ApplyTheme(ThemedElement.ElementInfo[] elementInfo)
		{
		}

		public static LanguageDataBase GetLanguage()
		{
			return null;
		}
	}
}
