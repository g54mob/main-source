using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace IngameDebugConsole
{
	public class DebugLogManager : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CActivateCommandInputFieldCoroutine_003Ed__186 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CActivateCommandInputFieldCoroutine_003Ed__186(int _003C_003E1__state)
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

		[Header("Properties")]
		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, console window will persist between scenes (i.e. not be destroyed when scene changes)")]
		private bool singleton;

		[SerializeField]
		[HideInInspector]
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
		[HideInInspector]
		[Tooltip("Minimum width of the console window")]
		private float minimumWidth;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Opacity of the console window")]
		[Range(0f, 1f)]
		private float logWindowOpacity;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Opacity of the popup")]
		[Range(0f, 1f)]
		internal float popupOpacity;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Determines when the popup will show up (after the console window is closed)")]
		private PopupVisibility popupVisibility;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Determines which log types will show the popup on screen")]
		private DebugLogFilter popupVisibilityLogFilter;

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
		[Tooltip("If enabled, clicking the resize button of the console window will copy all logs to clipboard. It'll also play a scale animation to give feedback.")]
		internal bool copyAllLogsOnResizeButtonClick;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, the console window will continue receiving logs in the background even if its GameObject is inactive. But the console window's GameObject needs to be activated at least once because its Awake function must be triggered for this to work")]
		private bool receiveLogsWhileInactive;

		[SerializeField]
		[HideInInspector]
		private bool receiveInfoLogs;

		[SerializeField]
		[HideInInspector]
		private bool receiveWarningLogs;

		[SerializeField]
		[HideInInspector]
		private bool receiveErrorLogs;

		[SerializeField]
		[HideInInspector]
		private bool receiveExceptionLogs;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, the arrival times of logs will be recorded and displayed when a log is expanded")]
		private bool captureLogTimestamps;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, timestamps will be displayed for logs even if they aren't expanded")]
		internal bool alwaysDisplayTimestamps;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If the number of logs reach this limit, the oldest log(s) will be deleted to limit the RAM usage. It's recommended to set this value as low as possible")]
		private int maxLogCount;

		[SerializeField]
		[HideInInspector]
		[Tooltip("How many log(s) to delete when the threshold is reached (all logs are iterated during this operation so it should neither be too low nor too high)")]
		private int logsToRemoveAfterMaxLogCount;

		[SerializeField]
		[HideInInspector]
		[Tooltip("While the console window is hidden, incoming logs will be queued but not immediately processed until the console window is opened (to avoid wasting CPU resources). When the log queue exceeds this limit, the first logs in the queue will be processed to enforce this limit. Processed logs won't increase RAM usage if they've been seen before (i.e. collapsible logs) but this is not the case for queued logs, so if a log is spammed every frame, it will fill the whole queue in an instant. Which is why there is a queue limit")]
		private int queuedLogLimit;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, the command input field at the bottom of the console window will automatically be cleared after entering a command")]
		private bool clearCommandAfterExecution;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Console keeps track of the previously entered commands. This value determines the capacity of the command history (you can scroll through the history via up and down arrow keys while the command input field is focused)")]
		private int commandHistorySize;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, while typing a command, all of the matching commands' signatures will be displayed in a popup")]
		private bool showCommandSuggestions;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, on Android platform, logcat entries of the application will also be logged to the console with the prefix \"LOGCAT: \". This may come in handy especially if you want to access the native logs of your Android plugins (like Admob)")]
		private bool receiveLogcatLogsInAndroid;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Native logs will be filtered using these arguments. If left blank, all native logs of the application will be logged to the console. But if you want to e.g. see Admob's logs only, you can enter \"-s Ads\" (without quotes) here")]
		private string logcatArguments;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, on Android and iOS devices with notch screens, the console window will be repositioned so that the cutout(s) don't obscure it")]
		private bool avoidScreenCutout;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, on Android and iOS devices with notch screens, the console window's popup won't be obscured by the screen cutouts")]
		internal bool popupAvoidsScreenCutout;

		[SerializeField]
		[Tooltip("If a log that isn't expanded is longer than this limit, it will be truncated. This greatly optimizes scrolling speed of collapsed logs if their log messages are long.")]
		internal int maxCollapsedLogLength;

		[SerializeField]
		[FormerlySerializedAs("maxLogLength")]
		[Tooltip("If an expanded log is longer than this limit, it will be truncated. This optimizes scrolling speed while an expanded log is visible.")]
		internal int maxExpandedLogLength;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, on standalone platforms, command input field will automatically be focused (start receiving keyboard input) after opening the console window")]
		private bool autoFocusOnCommandInputField;

		[Header("Visuals")]
		[SerializeField]
		private DebugLogItem logItemPrefab;

		[SerializeField]
		internal TMP_FontAsset logItemFontOverride;

		[SerializeField]
		private TextMeshProUGUI commandSuggestionPrefab;

		[SerializeField]
		private Sprite infoLog;

		[SerializeField]
		private Sprite warningLog;

		[SerializeField]
		private Sprite errorLog;

		internal static Sprite[] logSpriteRepresentations;

		[SerializeField]
		private Sprite resizeIconAllDirections;

		[SerializeField]
		private Sprite resizeIconVerticalOnly;

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

		[Header("Internal References")]
		[SerializeField]
		private RectTransform logWindowTR;

		internal RectTransform canvasTR;

		[SerializeField]
		private RectTransform logItemsContainer;

		[SerializeField]
		private RectTransform commandSuggestionsContainer;

		[SerializeField]
		private TMP_InputField commandInputField;

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
		private TextMeshProUGUI infoEntryCountText;

		[SerializeField]
		private TextMeshProUGUI warningEntryCountText;

		[SerializeField]
		private TextMeshProUGUI errorEntryCountText;

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

		[NonSerialized]
		public bool SnapToBottom;

		private DynamicCircularBuffer<DebugLogEntry> collapsedLogEntries;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> collapsedLogEntriesTimestamps;

		private Dictionary<DebugLogEntry, DebugLogEntry> collapsedLogEntriesMap;

		private DynamicCircularBuffer<DebugLogEntry> uncollapsedLogEntries;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> uncollapsedLogEntriesTimestamps;

		private DynamicCircularBuffer<DebugLogEntry> logEntriesToShow;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> timestampsOfLogEntriesToShow;

		private int indexOfLogEntryToSelectAndFocus;

		private bool shouldUpdateRecycledListView;

		private DynamicCircularBuffer<QueuedDebugLogEntry> queuedLogEntries;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> queuedLogEntriesTimestamps;

		private object logEntriesLock;

		private int pendingLogToAutoExpand;

		private List<TextMeshProUGUI> commandSuggestionInstances;

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

		private Stack<DebugLogEntry> pooledLogEntries;

		private Stack<DebugLogItem> pooledLogItems;

		private bool anyCollapsedLogRemoved;

		private int removedLogEntriesToShowCount;

		private CircularBuffer<string> commandHistory;

		private int commandHistoryIndex;

		private string unfinishedCommand;

		internal StringBuilder sharedStringBuilder;

		[NonSerialized]
		internal char[] textBuffer;

		private TimeSpan localTimeUtcOffset;

		private float lastElapsedSeconds;

		private int lastFrameCount;

		private DebugLogEntryTimestamp dummyLogEntryTimestamp;

		private PointerEventData nullPointerEventData;

		private Action<DebugLogEntry> poolLogEntryAction;

		private Action<DebugLogEntry> removeUncollapsedLogEntryAction;

		private Predicate<DebugLogEntry> shouldRemoveCollapsedLogEntryPredicate;

		private Predicate<DebugLogEntry> shouldRemoveLogEntryToShowPredicate;

		private Action<DebugLogEntry, int> updateLogEntryCollapsedIndexAction;

		public Action OnLogWindowShown;

		public Action OnLogWindowHidden;

		private bool isQuittingApplication;

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

		private void OnApplicationQuitting()
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

		private void RemoveOldestLogs(int numberOfLogsToRemove)
		{
		}

		private void RemoveUncollapsedLogEntry(DebugLogEntry logEntry)
		{
		}

		private bool ShouldRemoveCollapsedLogEntry(DebugLogEntry logEntry)
		{
			return false;
		}

		private bool ShouldRemoveLogEntryToShow(DebugLogEntry logEntry)
		{
			return false;
		}

		private void UpdateLogEntryCollapsedIndex(DebugLogEntry logEntry, int collapsedIndex)
		{
		}

		private void OnLogEntriesUpdated(bool updateAllVisibleItemContents, bool validateScrollPosition)
		{
		}

		private void PoolLogEntry(DebugLogEntry logEntry)
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

		public string GetAllLogs(int maxLogCount, float maxElapsedTime)
		{
			return null;
		}

		public void GetAllLogs(out DynamicCircularBuffer<DebugLogEntry> logEntries, out DynamicCircularBuffer<DebugLogEntryTimestamp> logTimestamps)
		{
			logEntries = null;
			logTimestamps = null;
		}

		public void SaveLogsToFile()
		{
		}

		public void SaveLogsToFile(string filePath)
		{
		}

		private void CheckScreenCutout()
		{
		}

		[IteratorStateMachine(typeof(_003CActivateCommandInputFieldCoroutine_003Ed__186))]
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
