using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class ControlMapper : MonoBehaviour
	{
		private abstract class GUIElement
		{
			public readonly GameObject gameObject;

			protected readonly Text text;

			public readonly Selectable selectable;

			protected readonly UIElementInfo uiElementInfo;

			protected bool permanentStateSet;

			protected readonly List<GUIElement> children;

			public RectTransform rectTransform { get; private set; }

			public GUIElement(GameObject gameObject)
			{
			}

			public GUIElement(Selectable selectable, Text label)
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

			public GUIButton(Button button, Text label)
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

			public GUIInputField(Button button, Text label)
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

			public GUIToggle(Toggle toggle, Text label)
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

			private Text text { get; set; }

			public RectTransform rectTransform { get; private set; }

			public GUILabel(GameObject gameObject)
			{
			}

			public GUILabel(Text label)
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

			public void SetFontStyle(FontStyle style)
			{
			}

			public void SetTextAlignment(TextAnchor alignment)
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
			[Tooltip("The Map Category that will be displayed to the user for remapping.")]
			private int _mapCategoryId;

			[SerializeField]
			[Tooltip("Choose whether you want to list Actions to display for this Map Category by individual Action or by all the Actions in an Action Category.")]
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
			[Tooltip("The Input Behavior that will be displayed to the user for modification.")]
			private int _inputBehaviorId;

			[SerializeField]
			[Tooltip("If checked, a slider will be displayed so the user can change this value.")]
			private bool _showJoystickAxisSensitivity;

			[SerializeField]
			[Tooltip("If checked, a slider will be displayed so the user can change this value.")]
			private bool _showMouseXYAxisSensitivity;

			[SerializeField]
			[Tooltip("If set to a non-blank value, this key will be used to look up the name in Language to be displayed as the title for the Input Behavior control set. Otherwise, the name field of the InputBehavior will be used.")]
			private string _labelLanguageKey;

			[SerializeField]
			[Tooltip("If set to a non-blank value, this name will be displayed above the individual slider control. Otherwise, no name will be displayed.")]
			private string _joystickAxisSensitivityLabelLanguageKey;

			[SerializeField]
			[Tooltip("If set to a non-blank value, this key will be used to look up the name in Language to be displayed above the individual slider control. Otherwise, no name will be displayed.")]
			private string _mouseXYAxisSensitivityLabelLanguageKey;

			[SerializeField]
			[Tooltip("The icon to display next to the slider. Set to none for no icon.")]
			private Sprite _joystickAxisSensitivityIcon;

			[SerializeField]
			[Tooltip("The icon to display next to the slider. Set to none for no icon.")]
			private Sprite _mouseXYAxisSensitivityIcon;

			[SerializeField]
			[Tooltip("Minimum value the user is allowed to set for this property.")]
			private float _joystickAxisSensitivityMin;

			[SerializeField]
			[Tooltip("Maximum value the user is allowed to set for this property.")]
			private float _joystickAxisSensitivityMax;

			[SerializeField]
			[Tooltip("Minimum value the user is allowed to set for this property.")]
			private float _mouseXYAxisSensitivityMin;

			[SerializeField]
			[Tooltip("Maximum value the user is allowed to set for this property.")]
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
			private Text _controllerNameLabel;

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

			public Text controllerNameLabel => null;

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

			public TValue this[int index] => default(TValue);

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

			[CompilerGenerated]
			private sealed class _003CGetActionSets_003Ed__18 : IEnumerable<InputActionSet>, IEnumerable, IEnumerator<InputActionSet>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private InputActionSet _003C_003E2__current;

				private int _003C_003El__initialThreadId;

				public InputGridEntryList _003C_003E4__this;

				private int mapCategoryId;

				public int _003C_003E3__mapCategoryId;

				private List<ActionEntry> _003Clist_003E5__2;

				private int _003Ccount_003E5__3;

				private int _003Ci_003E5__4;

				InputActionSet IEnumerator<InputActionSet>.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return null;
					}
				}

				[DebuggerHidden]
				public _003CGetActionSets_003Ed__18(int _003C_003E1__state)
				{
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					return false;
				}

				bool IEnumerator.MoveNext()
				{
					//ILSpy generated this explicit interface implementation from .override directive in MoveNext
					return this.MoveNext();
				}

				[DebuggerHidden]
				void IEnumerator.Reset()
				{
				}

				[DebuggerHidden]
				IEnumerator<InputActionSet> IEnumerable<InputActionSet>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
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

			[IteratorStateMachine(typeof(_003CGetActionSets_003Ed__18))]
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

		[CompilerGenerated]
		private sealed class _003CElementAssignmentConflicts_003Ed__420 : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ElementAssignmentConflictInfo _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Player player;

			public Player _003C_003E3__player;

			private InputMapping mapping;

			public InputMapping _003C_003E3__mapping;

			public ControlMapper _003C_003E4__this;

			private ElementAssignment assignment;

			public ElementAssignment _003C_003E3__assignment;

			private bool skipOtherPlayers;

			public bool _003C_003E3__skipOtherPlayers;

			private ElementAssignmentConflictCheck _003CconflictCheck_003E5__2;

			private IEnumerator<ElementAssignmentConflictInfo> _003C_003E7__wrap2;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(ElementAssignmentConflictInfo);
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CElementAssignmentConflicts_003Ed__420(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			private void _003C_003Em__Finally2()
			{
			}

			private void _003C_003Em__Finally3()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public const int versionMajor = 1;

		public const int versionMinor = 1;

		public const bool usesTMPro = false;

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
		[Tooltip("Must be assigned a Rewired Input Manager scene object or prefab.")]
		private InputManager _rewiredInputManager;

		[SerializeField]
		[Tooltip("Set to True to prevent the Game Object from being destroyed when a new scene is loaded.\n\nNOTE: Changing this value from True to False at runtime will have no effect because Object.DontDestroyOnLoad cannot be undone once set.")]
		private bool _dontDestroyOnLoad;

		[SerializeField]
		[Tooltip("Open the control mapping screen immediately on start. Mainly used for testing.")]
		private bool _openOnStart;

		[SerializeField]
		[Tooltip("The Layout of the Keyboard Maps to be displayed.")]
		private int _keyboardMapDefaultLayout;

		[SerializeField]
		[Tooltip("The Layout of the Mouse Maps to be displayed.")]
		private int _mouseMapDefaultLayout;

		[SerializeField]
		[Tooltip("The Layout of the Mouse Maps to be displayed.")]
		private int _joystickMapDefaultLayout;

		[SerializeField]
		private MappingSet[] _mappingSets;

		[SerializeField]
		[Tooltip("Display a selectable list of Players. If your game only supports 1 player, you can disable this.")]
		private bool _showPlayers;

		[SerializeField]
		[Tooltip("Display the Controller column for input mapping.")]
		private bool _showControllers;

		[SerializeField]
		[Tooltip("Display the Keyboard column for input mapping.")]
		private bool _showKeyboard;

		[SerializeField]
		[Tooltip("Display the Mouse column for input mapping.")]
		private bool _showMouse;

		[SerializeField]
		[Tooltip("The maximum number of controllers allowed to be assigned to a Player. If set to any value other than 1, a selectable list of currently-assigned controller will be displayed to the user. [0 = infinite]")]
		private int _maxControllersPerPlayer;

		[SerializeField]
		[Tooltip("Display section labels for each Action Category in the input field grid. Only applies if Action Categories are used to display the Action list.")]
		private bool _showActionCategoryLabels;

		[SerializeField]
		[Tooltip("The number of input fields to display for the keyboard. If you want to support alternate mappings on the same device, set this to 2 or more.")]
		private int _keyboardInputFieldCount;

		[SerializeField]
		[Tooltip("The number of input fields to display for the mouse. If you want to support alternate mappings on the same device, set this to 2 or more.")]
		private int _mouseInputFieldCount;

		[SerializeField]
		[Tooltip("The number of input fields to display for joysticks. If you want to support alternate mappings on the same device, set this to 2 or more.")]
		private int _controllerInputFieldCount;

		[SerializeField]
		[Tooltip("Display a full-axis input assignment field for every axis-type Action in the input field grid. Also displays an invert toggle for the user  to invert the full-axis assignment direction.\n\n*IMPORTANT*: This field is required if you have made any full-axis assignments in the Rewired Input Manager or in saved XML user data. Disabling this field when you have full-axis assignments will result in the inability for the user to view, remove, or modify these full-axis assignments. In addition, these assignments may cause conflicts when trying to remap the same axes to Actions.")]
		private bool _showFullAxisInputFields;

		[SerializeField]
		[Tooltip("Display a positive and negative input assignment field for every axis-type Action in the input field grid.\n\n*IMPORTANT*: These fields are required to assign buttons, keyboard keys, and hat or D-Pad directions to axis-type Actions. If you have made any split-axis assignments or button/key/D-pad assignments to axis-type Actions in the Rewired Input Manager or in saved XML user data, disabling these fields will result in the inability for the user to view, remove, or modify these assignments. In addition, these assignments may cause conflicts when trying to remap the same elements to Actions.")]
		private bool _showSplitAxisInputFields;

		[SerializeField]
		[Tooltip("Show glyphs if available. Glyph Provider must be configured for glyphs to be displayed. See Glyphs documentation for more information.")]
		private bool _showGlyphs;

		[SerializeField]
		[Tooltip("If enabled, when an element assignment conflict is found, an option will be displayed that allows the user to make the conflicting assignment anyway.")]
		private bool _allowElementAssignmentConflicts;

		[SerializeField]
		[Tooltip("If enabled, when an element assignment conflict is found, an option will be displayed that allows the user to swap conflicting assignments. This only applies to the first conflicting assignment found. This option will not be displayed if allowElementAssignmentConflicts is true.")]
		private bool _allowElementAssignmentSwap;

		[SerializeField]
		[Tooltip("The width in relative pixels of the Action label column.")]
		private int _actionLabelWidth;

		[SerializeField]
		[Tooltip("The width in relative pixels of the Keyboard column.")]
		private int _keyboardColMaxWidth;

		[SerializeField]
		[Tooltip("The width in relative pixels of the Mouse column.")]
		private int _mouseColMaxWidth;

		[SerializeField]
		[Tooltip("The width in relative pixels of the Controller column.")]
		private int _controllerColMaxWidth;

		[SerializeField]
		[Tooltip("The height in relative pixels of the input grid button rows.")]
		private int _inputRowHeight;

		[SerializeField]
		[Tooltip("The padding of the input grid button rows.")]
		private RectOffset _inputRowPadding;

		[SerializeField]
		[Tooltip("The width in relative pixels of spacing between input fields in a single column.")]
		private int _inputRowFieldSpacing;

		[SerializeField]
		[Tooltip("The width in relative pixels of spacing between columns.")]
		private int _inputColumnSpacing;

		[SerializeField]
		[Tooltip("The height in relative pixels of the space between Action Category sections. Only applicable if Show Action Category Labels is checked.")]
		private int _inputRowCategorySpacing;

		[SerializeField]
		[Tooltip("The width in relative pixels of the invert toggle buttons.")]
		private int _invertToggleWidth;

		[SerializeField]
		[Tooltip("The width in relative pixels of generated popup windows.")]
		private int _defaultWindowWidth;

		[SerializeField]
		[Tooltip("The height in relative pixels of generated popup windows.")]
		private int _defaultWindowHeight;

		[SerializeField]
		[Tooltip("The time in seconds the user has to press an element on a controller when assigning a controller to a Player. If this time elapses with no user input a controller, the assignment will be canceled.")]
		private float _controllerAssignmentTimeout;

		[SerializeField]
		[Tooltip("The time in seconds the user has to press an element on a controller while waiting for axes to be centered before assigning input.")]
		private float _preInputAssignmentTimeout;

		[SerializeField]
		[Tooltip("The time in seconds the user has to press an element on a controller when assigning input. If this time elapses with no user input on the target controller, the assignment will be canceled.")]
		private float _inputAssignmentTimeout;

		[SerializeField]
		[Tooltip("The time in seconds the user has to press an element on a controller during calibration.")]
		private float _axisCalibrationTimeout;

		[SerializeField]
		[Tooltip("If checked, mouse X-axis movement will always be ignored during input assignment. Check this if you don't want the horizontal mouse axis to be user-assignable to any Actions.")]
		private bool _ignoreMouseXAxisAssignment;

		[SerializeField]
		[Tooltip("If checked, mouse Y-axis movement will always be ignored during input assignment. Check this if you don't want the vertical mouse axis to be user-assignable to any Actions.")]
		private bool _ignoreMouseYAxisAssignment;

		[SerializeField]
		[Tooltip("An Action that when activated will alternately close or open the main screen as long as no popup windows are open.")]
		private int _screenToggleAction;

		[SerializeField]
		[Tooltip("An Action that when activated will open the main screen if it is closed.")]
		private int _screenOpenAction;

		[SerializeField]
		[Tooltip("An Action that when activated will close the main screen as long as no popup windows are open.")]
		private int _screenCloseAction;

		[SerializeField]
		[Tooltip("An Action that when activated will cancel and close any open popup window. Use with care because the element assigned to this Action can never be mapped by the user (because it would just cancel his assignment).")]
		private int _universalCancelAction;

		[SerializeField]
		[Tooltip("If enabled, Universal Cancel will also close the main screen if pressed when no windows are open.")]
		private bool _universalCancelClosesScreen;

		[SerializeField]
		[Tooltip("If checked, controls will be displayed which will allow the user to customize certain Input Behavior settings.")]
		private bool _showInputBehaviorSettings;

		[SerializeField]
		[Tooltip("Customizable settings for user-modifiable Input Behaviors. This can be used for settings like Mouse Look Sensitivity.")]
		private InputBehaviorSettings[] _inputBehaviorSettings;

		[SerializeField]
		[Tooltip("If enabled, UI elements will be themed based on the settings in Theme Settings.")]
		private bool _useThemeSettings;

		[SerializeField]
		[Tooltip("Must be assigned a ThemeSettings object. Used to theme UI elements.")]
		private ThemeSettings _themeSettings;

		[SerializeField]
		[Tooltip("Must be assigned a LanguageData object. Used to retrieve language entries for UI elements.")]
		private LanguageDataBase _language;

		[SerializeField]
		[Tooltip("A list of prefabs. You should not have to modify this.")]
		private Prefabs prefabs;

		[SerializeField]
		[Tooltip("A list of references to elements in the hierarchy. You should not have to modify this.")]
		private References references;

		[SerializeField]
		[Tooltip("Show the label for the Players button group?")]
		private bool _showPlayersGroupLabel;

		[SerializeField]
		[Tooltip("Show the label for the Controller button group?")]
		private bool _showControllerGroupLabel;

		[SerializeField]
		[Tooltip("Show the label for the Assigned Controllers button group?")]
		private bool _showAssignedControllersGroupLabel;

		[SerializeField]
		[Tooltip("Show the label for the Settings button group?")]
		private bool _showSettingsGroupLabel;

		[SerializeField]
		[Tooltip("Show the label for the Map Categories button group?")]
		private bool _showMapCategoriesGroupLabel;

		[SerializeField]
		[Tooltip("Show the label for the current controller name?")]
		private bool _showControllerNameLabel;

		[SerializeField]
		[Tooltip("Show the Assigned Controllers group? If joystick auto-assignment is enabled in the Rewired Input Manager and the max joysticks per player is set to any value other than 1, the Assigned Controllers group will always be displayed.")]
		private bool _showAssignedControllers;

		private Action _ScreenClosedEvent;

		private Action _ScreenOpenedEvent;

		private Action _PopupWindowOpenedEvent;

		private Action _PopupWindowClosedEvent;

		private Action _InputPollingStartedEvent;

		private Action _InputPollingEndedEvent;

		private Action _ThemeAppliedEvent;

		[SerializeField]
		[Tooltip("Event sent when the UI is closed.")]
		private UnityEvent _onScreenClosed;

		[SerializeField]
		[Tooltip("Event sent when the UI is opened.")]
		private UnityEvent _onScreenOpened;

		[SerializeField]
		[Tooltip("Event sent when a popup window is closed.")]
		private UnityEvent _onPopupWindowClosed;

		[SerializeField]
		[Tooltip("Event sent when a popup window is opened.")]
		private UnityEvent _onPopupWindowOpened;

		[SerializeField]
		[Tooltip("Event sent when polling for input has started.")]
		private UnityEvent _onInputPollingStarted;

		[SerializeField]
		[Tooltip("Event sent when polling for input has ended.")]
		private UnityEvent _onInputPollingEnded;

		private static ControlMapper Instance;

		[NonSerialized]
		private bool initialized;

		[NonSerialized]
		private int playerCount;

		private InputGrid inputGrid;

		private WindowManager windowManager;

		[NonSerialized]
		private int currentPlayerId;

		[NonSerialized]
		private int currentMapCategoryId;

		[NonSerialized]
		private List<GUIButton> playerButtons;

		[NonSerialized]
		private List<GUIButton> mapCategoryButtons;

		[NonSerialized]
		private List<GUIButton> assignedControllerButtons;

		private GUIButton assignedControllerButtonsPlaceholder;

		[NonSerialized]
		private List<GameObject> miscInstantiatedObjects;

		[NonSerialized]
		private GameObject canvas;

		[NonSerialized]
		private GameObject lastUISelection;

		[NonSerialized]
		private int currentJoystickId;

		[NonSerialized]
		private float blockInputOnFocusEndTime;

		[NonSerialized]
		private bool isPollingForInput;

		[NonSerialized]
		private List<ThemedElement> themedElements;

		[NonSerialized]
		private InputMapping pendingInputMapping;

		[NonSerialized]
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

		public bool showGlyphs
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

		public ThemeSettings themeSettings
		{
			get
			{
				return null;
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

		public static ControlMapper current => null;

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

		[IteratorStateMachine(typeof(_003CElementAssignmentConflicts_003Ed__420))]
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

		private void ApplyTheme()
		{
		}

		public static void Register(ThemedElement themedElement)
		{
		}

		public static void Unregister(ThemedElement themedElement)
		{
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
