using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace IngameDebugConsole
{
	public class DebugLogManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CActivateCommandInputFieldCoroutine_003Ed__161 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DebugLogManager _003C_003E4__this;

			object IEnumerator<object>.Current
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
			public _003CActivateCommandInputFieldCoroutine_003Ed__161(int _003C_003E1__state)
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
		}

		[Tooltip("If enabled, console window will persist between scenes (i.e. not be destroyed when scene changes)")]
		[HideInInspector]
		[SerializeField]
		[Header("Properties")]
		private bool singleton;

		[HideInInspector]
		[SerializeField]
		[Tooltip("Minimum height of the console window")]
		private float minimumHeight;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, console window can be resized horizontally, as well")]
		private bool enableHorizontalResizing;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, console window's resize button will be located at bottom-right corner. Otherwise, it will be located at bottom-left corner")]
		private bool resizeFromRight;

		[SerializeField]
		[Tooltip("Minimum width of the console window")]
		[HideInInspector]
		private float minimumWidth;

		[Tooltip("If disabled, no popup will be shown when the console window is hidden")]
		[SerializeField]
		[HideInInspector]
		private bool enablePopup;

		[Tooltip("If enabled, console will be initialized as a popup")]
		[SerializeField]
		[HideInInspector]
		private bool startInPopupMode;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, console window will initially be invisible")]
		private bool startMinimized;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, pressing the Toggle Key will show/hide (i.e. toggle) the console window at runtime")]
		private bool toggleWithKey;

		[SerializeField]
		[HideInInspector]
		private KeyCode toggleKey;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, the console window will have a searchbar")]
		private bool enableSearchbar;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Width of the canvas determines whether the searchbar will be located inside the menu bar or underneath the menu bar. This way, the menu bar doesn't get too crowded on narrow screens. This value determines the minimum width of the canvas for the searchbar to appear inside the menu bar")]
		private float topSearchbarMinWidth;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, the console window will continue receiving logs in the background even if its GameObject is inactive. But the console window's GameObject needs to be activated at least once because its Awake function must be triggered for this to work")]
		private bool receiveLogsWhileInactive;

		[HideInInspector]
		[SerializeField]
		private bool receiveInfoLogs;

		[HideInInspector]
		[SerializeField]
		private bool receiveWarningLogs;

		[HideInInspector]
		[SerializeField]
		private bool receiveErrorLogs;

		[HideInInspector]
		[SerializeField]
		private bool receiveExceptionLogs;

		[Tooltip("If enabled, the arrival times of logs will be recorded and displayed when a log is expanded")]
		[HideInInspector]
		[SerializeField]
		private bool captureLogTimestamps;

		[Tooltip("If enabled, timestamps will be displayed for logs even if they aren't expanded")]
		[HideInInspector]
		[SerializeField]
		internal bool alwaysDisplayTimestamps;

		[HideInInspector]
		[SerializeField]
		[Tooltip("While the console window is hidden, incoming logs will be queued but not immediately processed until the console window is opened (to avoid wasting CPU resources). When the log queue exceeds this limit, the first logs in the queue will be processed to enforce this limit. Processed logs won't increase RAM usage if they've been seen before (i.e. collapsible logs) but this is not the case for queued logs, so if a log is spammed every frame, it will fill the whole queue in an instant. Which is why there is a queue limit")]
		private int queuedLogLimit;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, the command input field at the bottom of the console window will automatically be cleared after entering a command")]
		private bool clearCommandAfterExecution;

		[Tooltip("Console keeps track of the previously entered commands. This value determines the capacity of the command history (you can scroll through the history via up and down arrow keys while the command input field is focused)")]
		[SerializeField]
		[HideInInspector]
		private int commandHistorySize;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, while typing a command, all of the matching commands' signatures will be displayed in a popup")]
		private bool showCommandSuggestions;

		[Tooltip("If enabled, on Android platform, logcat entries of the application will also be logged to the console with the prefix \"LOGCAT: \". This may come in handy especially if you want to access the native logs of your Android plugins (like Admob)")]
		[HideInInspector]
		[SerializeField]
		private bool receiveLogcatLogsInAndroid;

		[Tooltip("Native logs will be filtered using these arguments. If left blank, all native logs of the application will be logged to the console. But if you want to e.g. see Admob's logs only, you can enter \"-s Ads\" (without quotes) here")]
		[HideInInspector]
		[SerializeField]
		private string logcatArguments;

		[Tooltip("If enabled, on Android and iOS devices with notch screens, the console window will be repositioned so that the cutout(s) don't obscure it")]
		[HideInInspector]
		[SerializeField]
		private bool avoidScreenCutout;

		[HideInInspector]
		[SerializeField]
		[Tooltip("If enabled, on Android and iOS devices with notch screens, the console window's popup won't be obscured by the screen cutouts")]
		internal bool popupAvoidsScreenCutout;

		[SerializeField]
		[Tooltip("If a log is longer than this limit, it will be truncated. This helps avoid reaching Unity's 65000 vertex limit for UI canvases")]
		private int maxLogLength;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, on standalone platforms, command input field will automatically be focused (start receiving keyboard input) after opening the console window")]
		private bool autoFocusOnCommandInputField;

		[Header("Visuals")]
		[SerializeField]
		private DebugLogItem logItemPrefab;

		[SerializeField]
		private Text commandSuggestionPrefab;

		[SerializeField]
		private Sprite infoLog;

		[SerializeField]
		private Sprite warningLog;

		[SerializeField]
		private Sprite errorLog;

		[SerializeField]
		private Sprite resizeIconAllDirections;

		[SerializeField]
		private Sprite resizeIconVerticalOnly;

		private Dictionary<LogType, Sprite> logSpriteRepresentations;

		[SerializeField]
		private Color collapseButtonNormalColor;

		[SerializeField]
		private Color collapseButtonSelectedColor;

		[SerializeField]
		private Color filterButtonsNormalColor;

		[SerializeField]
		private Color filterButtonsSelectedColor;

		[SerializeField]
		private string commandSuggestionHighlightStart;

		[SerializeField]
		private string commandSuggestionHighlightEnd;

		[SerializeField]
		[Header("Internal References")]
		private RectTransform logWindowTR;

		internal RectTransform canvasTR;

		[SerializeField]
		private RectTransform logItemsContainer;

		[SerializeField]
		private RectTransform commandSuggestionsContainer;

		[SerializeField]
		private InputField commandInputField;

		[SerializeField]
		private Button hideButton;

		[SerializeField]
		private Button clearButton;

		[SerializeField]
		private Image collapseButton;

		[SerializeField]
		private Image filterInfoButton;

		[SerializeField]
		private Image filterWarningButton;

		[SerializeField]
		private Image filterErrorButton;

		[SerializeField]
		private Text infoEntryCountText;

		[SerializeField]
		private Text warningEntryCountText;

		[SerializeField]
		private Text errorEntryCountText;

		[SerializeField]
		private RectTransform searchbar;

		[SerializeField]
		private RectTransform searchbarSlotTop;

		[SerializeField]
		private RectTransform searchbarSlotBottom;

		[SerializeField]
		private Image resizeButton;

		[SerializeField]
		private GameObject snapToBottomButton;

		[SerializeField]
		private CanvasGroup logWindowCanvasGroup;

		[SerializeField]
		private DebugLogPopup popupManager;

		[SerializeField]
		private ScrollRect logItemsScrollRect;

		private RectTransform logItemsScrollRectTR;

		private Vector2 logItemsScrollRectOriginalSize;

		[SerializeField]
		private DebugLogRecycledListView recycledListView;

		private bool isLogWindowVisible;

		private bool screenDimensionsChanged;

		private float logWindowPreviousWidth;

		private int infoEntryCount;

		private int warningEntryCount;

		private int errorEntryCount;

		private bool entryCountTextsDirty;

		private int newInfoEntryCount;

		private int newWarningEntryCount;

		private int newErrorEntryCount;

		private bool isCollapseOn;

		private DebugLogFilter logFilter;

		private string searchTerm;

		private bool isInSearchMode;

		private bool snapToBottom;

		private List<DebugLogEntry> collapsedLogEntries;

		private List<DebugLogEntryTimestamp> collapsedLogEntriesTimestamps;

		private Dictionary<DebugLogEntry, int> collapsedLogEntriesMap;

		private DebugLogIndexList<int> uncollapsedLogEntriesIndices;

		private DebugLogIndexList<DebugLogEntryTimestamp> uncollapsedLogEntriesTimestamps;

		private DebugLogIndexList<int> indicesOfListEntriesToShow;

		private DebugLogIndexList<DebugLogEntryTimestamp> timestampsOfListEntriesToShow;

		private int indexOfLogEntryToSelectAndFocus;

		private bool shouldUpdateRecycledListView;

		private DynamicCircularBuffer<QueuedDebugLogEntry> queuedLogEntries;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> queuedLogEntriesTimestamps;

		private object logEntriesLock;

		private int pendingLogToAutoExpand;

		private List<Text> commandSuggestionInstances;

		private int visibleCommandSuggestionInstances;

		private List<ConsoleMethodInfo> matchingCommandSuggestions;

		private List<int> commandCaretIndexIncrements;

		private string commandInputFieldPrevCommand;

		private string commandInputFieldPrevCommandName;

		private int commandInputFieldPrevParamCount;

		private int commandInputFieldPrevCaretPos;

		private int commandInputFieldPrevCaretArgumentIndex;

		private string commandInputFieldAutoCompleteBase;

		private bool commandInputFieldAutoCompletedNow;

		private List<DebugLogEntry> pooledLogEntries;

		private List<DebugLogItem> pooledLogItems;

		private CircularBuffer<string> commandHistory;

		private int commandHistoryIndex;

		private string unfinishedCommand;

		internal StringBuilder sharedStringBuilder;

		private TimeSpan localTimeUtcOffset;

		private float lastElapsedSeconds;

		private int lastFrameCount;

		private DebugLogEntryTimestamp dummyLogEntryTimestamp;

		private PointerEventData nullPointerEventData;

		public Action OnLogWindowShown;

		public Action OnLogWindowHidden;

		public static DebugLogManager Instance { get; private set; }

		public bool IsLogWindowVisible => false;

		public bool PopupEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void Start()
		{
		}

		private void OnDestroy()
		{
		}

		private void OnRectTransformDimensionsChange()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void ShowLogWindow()
		{
		}

		public void HideLogWindow()
		{
		}

		private char OnValidateCommand(string text, int charIndex, char addedChar)
		{
			return '\0';
		}

		public void ReceivedLog(string logString, string stackTrace, LogType logType)
		{
		}

		private void ProcessQueuedLogs(int numberOfLogsToProcess)
		{
		}

		private void ProcessLog(QueuedDebugLogEntry queuedLogEntry, DebugLogEntryTimestamp timestamp)
		{
		}

		public void SetSnapToBottom(bool snapToBottom)
		{
		}

		internal void ValidateScrollPosition()
		{
		}

		public void AdjustLatestPendingLog(bool autoExpand, bool stripStackTrace)
		{
		}

		public void ClearLogs()
		{
		}

		private void CollapseButtonPressed()
		{
		}

		private void FilterLogButtonPressed()
		{
		}

		private void FilterWarningButtonPressed()
		{
		}

		private void FilterErrorButtonPressed()
		{
		}

		private void SearchTermChanged(string searchTerm)
		{
		}

		private void RefreshCommandSuggestions(string command)
		{
		}

		private void OnEditCommand(string command)
		{
		}

		private void OnEndEditCommand(string command)
		{
		}

		internal void Resize(PointerEventData eventData)
		{
		}

		private void FilterLogs()
		{
		}

		public string GetAllLogs()
		{
			return null;
		}

		private void SaveLogsToFile()
		{
		}

		private void SaveLogsToFile(string filePath)
		{
		}

		private void CheckScreenCutout()
		{
		}

		[IteratorStateMachine(typeof(_003CActivateCommandInputFieldCoroutine_003Ed__161))]
		private IEnumerator ActivateCommandInputFieldCoroutine()
		{
			return null;
		}

		internal void PoolLogItem(DebugLogItem logItem)
		{
		}

		internal DebugLogItem PopLogItem()
		{
			return null;
		}
	}
}
