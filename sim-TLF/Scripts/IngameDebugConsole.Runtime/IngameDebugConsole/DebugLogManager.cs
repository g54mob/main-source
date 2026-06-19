using System;
using System.Collections.Generic;
using System.IO;
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
		public static bool AllowMultipleInstances;

		[Header("Properties")]
		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, console window will persist between scenes (i.e. not be destroyed when scene changes)")]
		private bool singleton = true;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Minimum height of the console window")]
		private float minimumHeight = 200f;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, console window can be resized horizontally, as well")]
		private bool enableHorizontalResizing;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, console window's resize button will be located at bottom-right corner. Otherwise, it will be located at bottom-left corner")]
		private bool resizeFromRight = true;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Minimum width of the console window")]
		private float minimumWidth = 240f;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Opacity of the console window")]
		[Range(0f, 1f)]
		private float logWindowOpacity = 1f;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Opacity of the popup")]
		[Range(0f, 1f)]
		internal float popupOpacity = 1f;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Determines when the popup will show up (after the console window is closed)")]
		private PopupVisibility popupVisibility;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Determines which log types will show the popup on screen")]
		private DebugLogFilter popupVisibilityLogFilter = DebugLogFilter.All;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, console window will initially be invisible")]
		private bool startMinimized = true;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, pressing the Toggle Key will show/hide (i.e. toggle) the console window at runtime")]
		private bool toggleWithKey;

		[SerializeField]
		[HideInInspector]
		private KeyCode toggleKey = KeyCode.BackQuote;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, the console window will have a searchbar")]
		private bool enableSearchbar = true;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Width of the canvas determines whether the searchbar will be located inside the menu bar or underneath the menu bar. This way, the menu bar doesn't get too crowded on narrow screens. This value determines the minimum width of the canvas for the searchbar to appear inside the menu bar")]
		private float topSearchbarMinWidth = 360f;

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
		private bool receiveInfoLogs = true;

		[SerializeField]
		[HideInInspector]
		private bool receiveWarningLogs = true;

		[SerializeField]
		[HideInInspector]
		private bool receiveErrorLogs = true;

		[SerializeField]
		[HideInInspector]
		private bool receiveExceptionLogs = true;

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
		private int maxLogCount = int.MaxValue;

		[SerializeField]
		[HideInInspector]
		[Tooltip("How many log(s) to delete when the threshold is reached (all logs are iterated during this operation so it should neither be too low nor too high)")]
		private int logsToRemoveAfterMaxLogCount = 16;

		[SerializeField]
		[HideInInspector]
		[Tooltip("While the console window is hidden, incoming logs will be queued but not immediately processed until the console window is opened (to avoid wasting CPU resources). When the log queue exceeds this limit, the first logs in the queue will be processed to enforce this limit. Processed logs won't increase RAM usage if they've been seen before (i.e. collapsible logs) but this is not the case for queued logs, so if a log is spammed every frame, it will fill the whole queue in an instant. Which is why there is a queue limit")]
		private int queuedLogLimit = 256;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, the command input field at the bottom of the console window will automatically be cleared after entering a command")]
		internal bool clearCommandAfterExecution = true;

		[SerializeField]
		[HideInInspector]
		[Tooltip("Console keeps track of the previously entered commands. This value determines the capacity of the command history (you can scroll through the history via up and down arrow keys while the command input field is focused)")]
		internal int commandHistorySize = 15;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, while typing a command, all of the matching commands' signatures will be displayed in a popup")]
		internal bool showCommandSuggestions = true;

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
		private bool avoidScreenCutout = true;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, on Android and iOS devices with notch screens, the console window's popup won't be obscured by the screen cutouts")]
		internal bool popupAvoidsScreenCutout;

		[SerializeField]
		[Tooltip("If a log that isn't expanded is longer than this limit, it will be truncated. This greatly optimizes scrolling speed of collapsed logs if their log messages are long.")]
		internal int maxCollapsedLogLength = 200;

		[SerializeField]
		[FormerlySerializedAs("maxLogLength")]
		[Tooltip("If an expanded log is longer than this limit, it will be truncated. This optimizes scrolling speed while an expanded log is visible.")]
		internal int maxExpandedLogLength = 10000;

		[SerializeField]
		[HideInInspector]
		[Tooltip("If enabled, on standalone platforms, command input field will automatically be focused (start receiving keyboard input) after opening the console window")]
		private bool autoFocusOnCommandInputField = true;

		[Header("Visuals")]
		[SerializeField]
		private DebugLogItem logItemPrefab;

		[SerializeField]
		internal TMP_FontAsset logItemFontOverride;

		[SerializeField]
		private Sprite infoLog;

		[SerializeField]
		private Sprite warningLog;

		[SerializeField]
		private Sprite errorLog;

		internal Sprite[] logSpriteRepresentations;

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

		[Header("Internal References")]
		[SerializeField]
		private RectTransform logWindowTR;

		internal RectTransform canvasTR;

		[SerializeField]
		private RectTransform logItemsContainer;

		[SerializeField]
		private CommandInputField commandInputField;

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

		private bool isLogWindowVisible = true;

		private bool screenDimensionsChanged = true;

		private float logWindowPreviousWidth;

		private int infoEntryCount;

		private int warningEntryCount;

		private int errorEntryCount;

		private bool entryCountTextsDirty;

		private int newInfoEntryCount;

		private int newWarningEntryCount;

		private int newErrorEntryCount;

		private bool isCollapseOn;

		private DebugLogFilter logFilter = DebugLogFilter.All;

		private string searchTerm;

		private bool isInSearchMode;

		[NonSerialized]
		public bool SnapToBottom = true;

		private DynamicCircularBuffer<DebugLogEntry> collapsedLogEntries;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> collapsedLogEntriesTimestamps;

		private Dictionary<DebugLogEntry, DebugLogEntry> collapsedLogEntriesMap;

		private DynamicCircularBuffer<DebugLogEntry> uncollapsedLogEntries;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> uncollapsedLogEntriesTimestamps;

		private DynamicCircularBuffer<DebugLogEntry> logEntriesToShow;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> timestampsOfLogEntriesToShow;

		private int indexOfLogEntryToSelectAndFocus = -1;

		private bool shouldUpdateRecycledListView = true;

		private DynamicCircularBuffer<QueuedDebugLogEntry> queuedLogEntries;

		private DynamicCircularBuffer<DebugLogEntryTimestamp> queuedLogEntriesTimestamps;

		private object logEntriesLock;

		private int pendingLogToAutoExpand;

		private Stack<DebugLogEntry> pooledLogEntries;

		private Stack<DebugLogItem> pooledLogItems;

		private bool anyCollapsedLogRemoved;

		private int removedLogEntriesToShowCount;

		internal StringBuilder sharedStringBuilder;

		[NonSerialized]
		internal char[] textBuffer = new char[4096];

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

		public bool IsLogWindowVisible => isLogWindowVisible;

		public bool PopupEnabled
		{
			get
			{
				return popupManager.gameObject.activeSelf;
			}
			set
			{
				popupManager.gameObject.SetActive(value);
			}
		}

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				if (singleton)
				{
					UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
				}
			}
			else if (!AllowMultipleInstances && Instance != this)
			{
				UnityEngine.Object.Destroy(base.gameObject);
				return;
			}
			pooledLogEntries = new Stack<DebugLogEntry>(64);
			pooledLogItems = new Stack<DebugLogItem>(16);
			queuedLogEntries = new DynamicCircularBuffer<QueuedDebugLogEntry>(Mathf.Clamp(queuedLogLimit, 16, 4096));
			logEntriesLock = new object();
			sharedStringBuilder = new StringBuilder(1024);
			canvasTR = (RectTransform)base.transform;
			logItemsScrollRectTR = (RectTransform)logItemsScrollRect.transform;
			logItemsScrollRectOriginalSize = logItemsScrollRectTR.sizeDelta;
			logSpriteRepresentations = new Sprite[5];
			logSpriteRepresentations[3] = infoLog;
			logSpriteRepresentations[2] = warningLog;
			logSpriteRepresentations[0] = errorLog;
			logSpriteRepresentations[4] = errorLog;
			logSpriteRepresentations[1] = errorLog;
			filterInfoButton.color = filterButtonsSelectedColor;
			filterWarningButton.color = filterButtonsSelectedColor;
			filterErrorButton.color = filterButtonsSelectedColor;
			resizeButton.sprite = (enableHorizontalResizing ? resizeIconAllDirections : resizeIconVerticalOnly);
			collapsedLogEntries = new DynamicCircularBuffer<DebugLogEntry>(128);
			collapsedLogEntriesMap = new Dictionary<DebugLogEntry, DebugLogEntry>(128, new DebugLogEntryContentEqualityComparer());
			uncollapsedLogEntries = new DynamicCircularBuffer<DebugLogEntry>(256);
			logEntriesToShow = new DynamicCircularBuffer<DebugLogEntry>(256);
			if (captureLogTimestamps)
			{
				collapsedLogEntriesTimestamps = new DynamicCircularBuffer<DebugLogEntryTimestamp>(128);
				uncollapsedLogEntriesTimestamps = new DynamicCircularBuffer<DebugLogEntryTimestamp>(256);
				timestampsOfLogEntriesToShow = new DynamicCircularBuffer<DebugLogEntryTimestamp>(256);
				queuedLogEntriesTimestamps = new DynamicCircularBuffer<DebugLogEntryTimestamp>(queuedLogEntries.Capacity);
			}
			recycledListView.Initialize(this, logEntriesToShow, timestampsOfLogEntriesToShow, logItemPrefab.Transform.sizeDelta.y);
			commandInputField.Initialize(this);
			if (minimumWidth < 100f)
			{
				minimumWidth = 100f;
			}
			if (minimumHeight < 200f)
			{
				minimumHeight = 200f;
			}
			if (!resizeFromRight)
			{
				RectTransform rectTransform = (RectTransform)resizeButton.GetComponentInParent<DebugLogResizeListener>().transform;
				rectTransform.anchorMin = new Vector2(0f, rectTransform.anchorMin.y);
				rectTransform.anchorMax = new Vector2(0f, rectTransform.anchorMax.y);
				rectTransform.pivot = new Vector2(0f, rectTransform.pivot.y);
				((RectTransform)commandInputField.transform).anchoredPosition += new Vector2(rectTransform.sizeDelta.x, 0f);
			}
			if (enableSearchbar)
			{
				searchbar.GetComponent<TMP_InputField>().onValueChanged.AddListener(SearchTermChanged);
			}
			else
			{
				searchbar = null;
				searchbarSlotTop.gameObject.SetActive(value: false);
				searchbarSlotBottom.gameObject.SetActive(value: false);
			}
			filterInfoButton.gameObject.SetActive(receiveInfoLogs);
			filterWarningButton.gameObject.SetActive(receiveWarningLogs);
			filterErrorButton.gameObject.SetActive(receiveErrorLogs || receiveExceptionLogs);
			hideButton.onClick.AddListener(HideLogWindow);
			clearButton.onClick.AddListener(ClearLogs);
			collapseButton.GetComponent<Button>().onClick.AddListener(CollapseButtonPressed);
			filterInfoButton.GetComponent<Button>().onClick.AddListener(FilterLogButtonPressed);
			filterWarningButton.GetComponent<Button>().onClick.AddListener(FilterWarningButtonPressed);
			filterErrorButton.GetComponent<Button>().onClick.AddListener(FilterErrorButtonPressed);
			snapToBottomButton.GetComponent<Button>().onClick.AddListener(delegate
			{
				SnapToBottom = true;
			});
			localTimeUtcOffset = DateTime.Now - DateTime.UtcNow;
			dummyLogEntryTimestamp = default(DebugLogEntryTimestamp);
			nullPointerEventData = new PointerEventData(null);
			poolLogEntryAction = PoolLogEntry;
			removeUncollapsedLogEntryAction = RemoveUncollapsedLogEntry;
			shouldRemoveCollapsedLogEntryPredicate = ShouldRemoveCollapsedLogEntry;
			shouldRemoveLogEntryToShowPredicate = ShouldRemoveLogEntryToShow;
			updateLogEntryCollapsedIndexAction = UpdateLogEntryCollapsedIndex;
			if (receiveLogsWhileInactive)
			{
				Application.logMessageReceivedThreaded -= ReceivedLog;
				Application.logMessageReceivedThreaded += ReceivedLog;
			}
			Application.quitting += OnApplicationQuitting;
		}

		private void OnEnable()
		{
			if (!(Instance != this))
			{
				if (!receiveLogsWhileInactive)
				{
					Application.logMessageReceivedThreaded -= ReceivedLog;
					Application.logMessageReceivedThreaded += ReceivedLog;
				}
				_ = receiveLogcatLogsInAndroid;
			}
		}

		private void OnDisable()
		{
			if (!(Instance != this))
			{
				if (!receiveLogsWhileInactive)
				{
					Application.logMessageReceivedThreaded -= ReceivedLog;
				}
				DebugLogConsole.RemoveCommand("logs.save");
			}
		}

		private void Start()
		{
			if (startMinimized)
			{
				HideLogWindow();
				if (popupVisibility != PopupVisibility.Always)
				{
					popupManager.Hide();
				}
			}
			else
			{
				ShowLogWindow();
			}
			PopupEnabled = popupVisibility != PopupVisibility.Never;
		}

		private void OnDestroy()
		{
			if (Instance == this)
			{
				Instance = null;
			}
			if (receiveLogsWhileInactive)
			{
				Application.logMessageReceivedThreaded -= ReceivedLog;
			}
			Application.quitting -= OnApplicationQuitting;
		}

		private void OnApplicationQuitting()
		{
			isQuittingApplication = true;
		}

		private void OnRectTransformDimensionsChange()
		{
			screenDimensionsChanged = true;
		}

		private void Update()
		{
			lastElapsedSeconds = Time.realtimeSinceStartup;
			lastFrameCount = Time.frameCount;
			if (toggleWithKey && Input.GetKeyDown(toggleKey))
			{
				if (isLogWindowVisible)
				{
					HideLogWindow();
				}
				else
				{
					ShowLogWindow();
				}
			}
		}

		private void LateUpdate()
		{
			if (isQuittingApplication)
			{
				return;
			}
			int numberOfLogsToProcess = (isLogWindowVisible ? queuedLogEntries.Count : (queuedLogEntries.Count - queuedLogLimit));
			ProcessQueuedLogs(numberOfLogsToProcess);
			if (uncollapsedLogEntries.Count >= maxLogCount)
			{
				int numberOfLogsToRemove = Mathf.Min((!isLogWindowVisible) ? logsToRemoveAfterMaxLogCount : (uncollapsedLogEntries.Count - maxLogCount + logsToRemoveAfterMaxLogCount), uncollapsedLogEntries.Count);
				RemoveOldestLogs(numberOfLogsToRemove);
			}
			if (!isLogWindowVisible && !PopupEnabled)
			{
				return;
			}
			int num;
			int num2;
			int num3;
			lock (logEntriesLock)
			{
				num = newInfoEntryCount;
				num2 = newWarningEntryCount;
				num3 = newErrorEntryCount;
				newInfoEntryCount = 0;
				newWarningEntryCount = 0;
				newErrorEntryCount = 0;
			}
			if (num > 0 || num2 > 0 || num3 > 0)
			{
				if (num > 0)
				{
					infoEntryCount += num;
					if (isLogWindowVisible)
					{
						infoEntryCountText.text = infoEntryCount.ToString();
					}
				}
				if (num2 > 0)
				{
					warningEntryCount += num2;
					if (isLogWindowVisible)
					{
						warningEntryCountText.text = warningEntryCount.ToString();
					}
				}
				if (num3 > 0)
				{
					errorEntryCount += num3;
					if (isLogWindowVisible)
					{
						errorEntryCountText.text = errorEntryCount.ToString();
					}
				}
				if (!isLogWindowVisible)
				{
					entryCountTextsDirty = true;
					if (popupVisibility == PopupVisibility.WhenLogReceived && !popupManager.IsVisible && ((num > 0 && (popupVisibilityLogFilter & DebugLogFilter.Info) == DebugLogFilter.Info) || (num2 > 0 && (popupVisibilityLogFilter & DebugLogFilter.Warning) == DebugLogFilter.Warning) || (num3 > 0 && (popupVisibilityLogFilter & DebugLogFilter.Error) == DebugLogFilter.Error)))
					{
						popupManager.Show();
					}
					if (popupManager.IsVisible)
					{
						popupManager.NewLogsArrived(num, num2, num3);
					}
				}
			}
			if (isLogWindowVisible)
			{
				if (shouldUpdateRecycledListView)
				{
					OnLogEntriesUpdated(updateAllVisibleItemContents: false, validateScrollPosition: false);
				}
				if (indexOfLogEntryToSelectAndFocus >= 0)
				{
					if (indexOfLogEntryToSelectAndFocus < logEntriesToShow.Count)
					{
						recycledListView.SelectAndFocusOnLogItemAtIndex(indexOfLogEntryToSelectAndFocus);
					}
					indexOfLogEntryToSelectAndFocus = -1;
				}
				if (entryCountTextsDirty)
				{
					infoEntryCountText.text = infoEntryCount.ToString();
					warningEntryCountText.text = warningEntryCount.ToString();
					errorEntryCountText.text = errorEntryCount.ToString();
					entryCountTextsDirty = false;
				}
				float width = logWindowTR.rect.width;
				if (!Mathf.Approximately(width, logWindowPreviousWidth))
				{
					logWindowPreviousWidth = width;
					if ((bool)searchbar)
					{
						if (width >= topSearchbarMinWidth)
						{
							if (searchbar.parent == searchbarSlotBottom)
							{
								searchbarSlotTop.gameObject.SetActive(value: true);
								searchbar.SetParent(searchbarSlotTop, worldPositionStays: false);
								searchbarSlotBottom.gameObject.SetActive(value: false);
								logItemsScrollRectTR.anchoredPosition = Vector2.zero;
								logItemsScrollRectTR.sizeDelta = logItemsScrollRectOriginalSize;
							}
						}
						else if (searchbar.parent == searchbarSlotTop)
						{
							searchbarSlotBottom.gameObject.SetActive(value: true);
							searchbar.SetParent(searchbarSlotBottom, worldPositionStays: false);
							searchbarSlotTop.gameObject.SetActive(value: false);
							float y = searchbarSlotBottom.sizeDelta.y;
							logItemsScrollRectTR.anchoredPosition = new Vector2(0f, y * -0.5f);
							logItemsScrollRectTR.sizeDelta = logItemsScrollRectOriginalSize - new Vector2(0f, y);
						}
					}
				}
				if (SnapToBottom)
				{
					logItemsScrollRect.verticalNormalizedPosition = 0f;
					if (snapToBottomButton.activeSelf)
					{
						snapToBottomButton.SetActive(value: false);
					}
				}
				else
				{
					float verticalNormalizedPosition = logItemsScrollRect.verticalNormalizedPosition;
					if (snapToBottomButton.activeSelf != (verticalNormalizedPosition > 1E-06f && verticalNormalizedPosition < 0.9999f))
					{
						snapToBottomButton.SetActive(!snapToBottomButton.activeSelf);
					}
				}
			}
			if (screenDimensionsChanged)
			{
				if (!isLogWindowVisible)
				{
					popupManager.UpdatePosition(immediately: true);
				}
				screenDimensionsChanged = false;
			}
		}

		public void ShowLogWindow()
		{
			logWindowCanvasGroup.blocksRaycasts = true;
			logWindowCanvasGroup.alpha = logWindowOpacity;
			popupManager.Hide();
			OnLogEntriesUpdated(updateAllVisibleItemContents: true, validateScrollPosition: true);
			if (autoFocusOnCommandInputField)
			{
				StartCoroutine(commandInputField.ActivateCommandInputFieldCoroutine());
			}
			isLogWindowVisible = true;
			if (OnLogWindowShown != null)
			{
				OnLogWindowShown();
			}
		}

		public void HideLogWindow()
		{
			logWindowCanvasGroup.blocksRaycasts = false;
			logWindowCanvasGroup.alpha = 0f;
			if (commandInputField.isFocused)
			{
				commandInputField.DeactivateInputField();
			}
			if (popupVisibility == PopupVisibility.Always)
			{
				popupManager.Show();
			}
			isLogWindowVisible = false;
			if (EventSystem.current != null)
			{
				EventSystem.current.SetSelectedGameObject(null);
			}
			if (OnLogWindowHidden != null)
			{
				OnLogWindowHidden();
			}
		}

		public void ReceivedLog(string logString, string stackTrace, LogType logType)
		{
			if (isQuittingApplication)
			{
				return;
			}
			switch (logType)
			{
			case LogType.Log:
				if (!receiveInfoLogs)
				{
					return;
				}
				break;
			case LogType.Warning:
				if (!receiveWarningLogs)
				{
					return;
				}
				break;
			case LogType.Error:
				if (!receiveErrorLogs)
				{
					return;
				}
				break;
			case LogType.Assert:
			case LogType.Exception:
				if (!receiveExceptionLogs)
				{
					return;
				}
				break;
			}
			QueuedDebugLogEntry value = new QueuedDebugLogEntry(logString, stackTrace, logType);
			DebugLogEntryTimestamp value2;
			if (queuedLogEntriesTimestamps != null)
			{
				DateTime dateTime = DateTime.UtcNow + localTimeUtcOffset;
				value2 = new DebugLogEntryTimestamp(dateTime, lastElapsedSeconds, lastFrameCount);
			}
			else
			{
				value2 = dummyLogEntryTimestamp;
			}
			lock (logEntriesLock)
			{
				if (queuedLogEntries.Count + 1 >= maxLogCount)
				{
					switch (queuedLogEntries.RemoveFirst().logType)
					{
					case LogType.Log:
						newInfoEntryCount--;
						break;
					case LogType.Warning:
						newWarningEntryCount--;
						break;
					default:
						newErrorEntryCount--;
						break;
					}
					if (queuedLogEntriesTimestamps != null)
					{
						queuedLogEntriesTimestamps.RemoveFirst();
					}
				}
				queuedLogEntries.Add(value);
				if (queuedLogEntriesTimestamps != null)
				{
					queuedLogEntriesTimestamps.Add(value2);
				}
				switch (logType)
				{
				case LogType.Log:
					newInfoEntryCount++;
					break;
				case LogType.Warning:
					newWarningEntryCount++;
					break;
				default:
					newErrorEntryCount++;
					break;
				}
			}
		}

		private void ProcessQueuedLogs(int numberOfLogsToProcess)
		{
			for (int i = 0; i < numberOfLogsToProcess; i++)
			{
				QueuedDebugLogEntry queuedLogEntry;
				DebugLogEntryTimestamp timestamp;
				lock (logEntriesLock)
				{
					queuedLogEntry = queuedLogEntries.RemoveFirst();
					timestamp = ((queuedLogEntriesTimestamps != null) ? queuedLogEntriesTimestamps.RemoveFirst() : dummyLogEntryTimestamp);
				}
				ProcessLog(queuedLogEntry, timestamp);
			}
		}

		private void ProcessLog(QueuedDebugLogEntry queuedLogEntry, DebugLogEntryTimestamp timestamp)
		{
			LogType logType = queuedLogEntry.logType;
			DebugLogEntry debugLogEntry = ((pooledLogEntries.Count <= 0) ? new DebugLogEntry() : pooledLogEntries.Pop());
			debugLogEntry.Initialize(queuedLogEntry.logString, queuedLogEntry.stackTrace);
			DebugLogEntry value;
			bool flag = collapsedLogEntriesMap.TryGetValue(debugLogEntry, out value);
			if (!flag)
			{
				debugLogEntry.logType = logType;
				debugLogEntry.collapsedIndex = collapsedLogEntries.Count;
				collapsedLogEntries.Add(debugLogEntry);
				collapsedLogEntriesMap[debugLogEntry] = debugLogEntry;
				if (collapsedLogEntriesTimestamps != null)
				{
					collapsedLogEntriesTimestamps.Add(timestamp);
				}
			}
			else
			{
				PoolLogEntry(debugLogEntry);
				debugLogEntry = value;
				debugLogEntry.count++;
				if (collapsedLogEntriesTimestamps != null)
				{
					collapsedLogEntriesTimestamps[debugLogEntry.collapsedIndex] = timestamp;
				}
			}
			uncollapsedLogEntries.Add(debugLogEntry);
			if (uncollapsedLogEntriesTimestamps != null)
			{
				uncollapsedLogEntriesTimestamps.Add(timestamp);
			}
			int num = -1;
			if (isCollapseOn && flag)
			{
				if (isLogWindowVisible || timestampsOfLogEntriesToShow != null)
				{
					num = ((isInSearchMode || logFilter != DebugLogFilter.All) ? logEntriesToShow.IndexOf(debugLogEntry) : debugLogEntry.collapsedIndex);
					if (num >= 0)
					{
						if (timestampsOfLogEntriesToShow != null)
						{
							timestampsOfLogEntriesToShow[num] = timestamp;
						}
						if (isLogWindowVisible)
						{
							recycledListView.OnCollapsedLogEntryAtIndexUpdated(num);
						}
					}
				}
			}
			else if ((!isInSearchMode || queuedLogEntry.MatchesSearchTerm(searchTerm)) && (logFilter == DebugLogFilter.All || (logType == LogType.Log && (logFilter & DebugLogFilter.Info) == DebugLogFilter.Info) || (logType == LogType.Warning && (logFilter & DebugLogFilter.Warning) == DebugLogFilter.Warning) || (logType != LogType.Log && logType != LogType.Warning && (logFilter & DebugLogFilter.Error) == DebugLogFilter.Error)))
			{
				logEntriesToShow.Add(debugLogEntry);
				num = logEntriesToShow.Count - 1;
				if (timestampsOfLogEntriesToShow != null)
				{
					timestampsOfLogEntriesToShow.Add(timestamp);
				}
				shouldUpdateRecycledListView = true;
			}
			if (pendingLogToAutoExpand > 0 && --pendingLogToAutoExpand <= 0 && num >= 0)
			{
				indexOfLogEntryToSelectAndFocus = num;
			}
		}

		private void RemoveOldestLogs(int numberOfLogsToRemove)
		{
			if (numberOfLogsToRemove <= 0)
			{
				return;
			}
			DebugLogEntry debugLogEntry = ((indexOfLogEntryToSelectAndFocus >= 0 && indexOfLogEntryToSelectAndFocus < logEntriesToShow.Count) ? logEntriesToShow[indexOfLogEntryToSelectAndFocus] : null);
			anyCollapsedLogRemoved = false;
			removedLogEntriesToShowCount = 0;
			uncollapsedLogEntries.TrimStart(numberOfLogsToRemove, removeUncollapsedLogEntryAction);
			if (uncollapsedLogEntriesTimestamps != null)
			{
				uncollapsedLogEntriesTimestamps.TrimStart(numberOfLogsToRemove);
			}
			if (removedLogEntriesToShowCount > 0)
			{
				logEntriesToShow.TrimStart(removedLogEntriesToShowCount);
				if (timestampsOfLogEntriesToShow != null)
				{
					timestampsOfLogEntriesToShow.TrimStart(removedLogEntriesToShowCount);
				}
			}
			if (anyCollapsedLogRemoved)
			{
				collapsedLogEntries.RemoveAll(shouldRemoveCollapsedLogEntryPredicate, updateLogEntryCollapsedIndexAction, collapsedLogEntriesTimestamps);
				if (isCollapseOn)
				{
					removedLogEntriesToShowCount = logEntriesToShow.RemoveAll(shouldRemoveLogEntryToShowPredicate, null, timestampsOfLogEntriesToShow);
				}
			}
			if (removedLogEntriesToShowCount > 0)
			{
				if (debugLogEntry == null || debugLogEntry.count == 0)
				{
					indexOfLogEntryToSelectAndFocus = -1;
				}
				else
				{
					for (int num = Mathf.Min(indexOfLogEntryToSelectAndFocus, logEntriesToShow.Count - 1); num >= 0; num--)
					{
						if (logEntriesToShow[num] == debugLogEntry)
						{
							indexOfLogEntryToSelectAndFocus = num;
							break;
						}
					}
				}
				recycledListView.OnLogEntriesRemoved(removedLogEntriesToShowCount);
				if (isLogWindowVisible)
				{
					OnLogEntriesUpdated(updateAllVisibleItemContents: false, validateScrollPosition: true);
				}
			}
			else if (isLogWindowVisible && isCollapseOn)
			{
				recycledListView.RefreshCollapsedLogEntryCounts();
			}
			entryCountTextsDirty = true;
		}

		private void RemoveUncollapsedLogEntry(DebugLogEntry logEntry)
		{
			if (--logEntry.count <= 0)
			{
				anyCollapsedLogRemoved = true;
			}
			if (!isCollapseOn && logEntriesToShow[removedLogEntriesToShowCount] == logEntry)
			{
				removedLogEntriesToShowCount++;
			}
			if (logEntry.logType == LogType.Log)
			{
				infoEntryCount--;
			}
			else if (logEntry.logType == LogType.Warning)
			{
				warningEntryCount--;
			}
			else
			{
				errorEntryCount--;
			}
		}

		private bool ShouldRemoveCollapsedLogEntry(DebugLogEntry logEntry)
		{
			if (logEntry.count <= 0)
			{
				PoolLogEntry(logEntry);
				collapsedLogEntriesMap.Remove(logEntry);
				return true;
			}
			return false;
		}

		private bool ShouldRemoveLogEntryToShow(DebugLogEntry logEntry)
		{
			return logEntry.count <= 0;
		}

		private void UpdateLogEntryCollapsedIndex(DebugLogEntry logEntry, int collapsedIndex)
		{
			logEntry.collapsedIndex = collapsedIndex;
		}

		private void OnLogEntriesUpdated(bool updateAllVisibleItemContents, bool validateScrollPosition)
		{
			recycledListView.OnLogEntriesUpdated(updateAllVisibleItemContents);
			shouldUpdateRecycledListView = false;
			if (validateScrollPosition)
			{
				ValidateScrollPosition();
			}
		}

		private void PoolLogEntry(DebugLogEntry logEntry)
		{
			if (pooledLogEntries.Count < 4096)
			{
				logEntry.Clear();
				pooledLogEntries.Push(logEntry);
			}
		}

		internal void ValidateScrollPosition()
		{
			if (logItemsScrollRect.verticalNormalizedPosition <= Mathf.Epsilon)
			{
				logItemsScrollRect.verticalNormalizedPosition = 0.0001f;
			}
			logItemsScrollRect.OnScroll(nullPointerEventData);
		}

		public void AdjustLatestPendingLog(bool autoExpand, bool stripStackTrace)
		{
			lock (logEntriesLock)
			{
				if (queuedLogEntries.Count != 0)
				{
					if (autoExpand)
					{
						pendingLogToAutoExpand = queuedLogEntries.Count;
					}
					if (stripStackTrace)
					{
						QueuedDebugLogEntry queuedDebugLogEntry = queuedLogEntries[queuedLogEntries.Count - 1];
						queuedLogEntries[queuedLogEntries.Count - 1] = new QueuedDebugLogEntry(queuedDebugLogEntry.logString, string.Empty, queuedDebugLogEntry.logType);
					}
				}
			}
		}

		public void ClearLogs()
		{
			SnapToBottom = true;
			indexOfLogEntryToSelectAndFocus = -1;
			infoEntryCount = 0;
			warningEntryCount = 0;
			errorEntryCount = 0;
			infoEntryCountText.text = "0";
			warningEntryCountText.text = "0";
			errorEntryCountText.text = "0";
			collapsedLogEntries.ForEach(poolLogEntryAction);
			collapsedLogEntries.Clear();
			collapsedLogEntriesMap.Clear();
			uncollapsedLogEntries.Clear();
			logEntriesToShow.Clear();
			if (collapsedLogEntriesTimestamps != null)
			{
				collapsedLogEntriesTimestamps.Clear();
				uncollapsedLogEntriesTimestamps.Clear();
				timestampsOfLogEntriesToShow.Clear();
			}
			recycledListView.DeselectSelectedLogItem();
			OnLogEntriesUpdated(updateAllVisibleItemContents: true, validateScrollPosition: true);
		}

		private void CollapseButtonPressed()
		{
			isCollapseOn = !isCollapseOn;
			collapseButton.color = (isCollapseOn ? collapseButtonSelectedColor : collapseButtonNormalColor);
			recycledListView.SetCollapseMode(isCollapseOn);
			FilterLogs();
		}

		private void FilterLogButtonPressed()
		{
			logFilter ^= DebugLogFilter.Info;
			if ((logFilter & DebugLogFilter.Info) == DebugLogFilter.Info)
			{
				filterInfoButton.color = filterButtonsSelectedColor;
			}
			else
			{
				filterInfoButton.color = filterButtonsNormalColor;
			}
			FilterLogs();
		}

		private void FilterWarningButtonPressed()
		{
			logFilter ^= DebugLogFilter.Warning;
			if ((logFilter & DebugLogFilter.Warning) == DebugLogFilter.Warning)
			{
				filterWarningButton.color = filterButtonsSelectedColor;
			}
			else
			{
				filterWarningButton.color = filterButtonsNormalColor;
			}
			FilterLogs();
		}

		private void FilterErrorButtonPressed()
		{
			logFilter ^= DebugLogFilter.Error;
			if ((logFilter & DebugLogFilter.Error) == DebugLogFilter.Error)
			{
				filterErrorButton.color = filterButtonsSelectedColor;
			}
			else
			{
				filterErrorButton.color = filterButtonsNormalColor;
			}
			FilterLogs();
		}

		private void SearchTermChanged(string searchTerm)
		{
			if (searchTerm != null)
			{
				searchTerm = searchTerm.Trim();
			}
			this.searchTerm = searchTerm;
			bool flag = !string.IsNullOrEmpty(searchTerm);
			if (flag || isInSearchMode)
			{
				isInSearchMode = flag;
				FilterLogs();
			}
		}

		internal void Resize(PointerEventData eventData)
		{
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasTR, eventData.position, eventData.pressEventCamera, out var localPoint))
			{
				return;
			}
			Rect rect = ((RectTransform)resizeButton.rectTransform.parent).rect;
			float width = rect.width;
			float height = rect.height;
			Vector2 pivot = canvasTR.pivot;
			Vector2 size = canvasTR.rect.size;
			Vector2 anchorMin = logWindowTR.anchorMin;
			if (enableHorizontalResizing)
			{
				if (resizeFromRight)
				{
					localPoint.x += pivot.x * size.x + width;
					if (localPoint.x < minimumWidth)
					{
						localPoint.x = minimumWidth;
					}
					Vector2 anchorMax = logWindowTR.anchorMax;
					anchorMax.x = Mathf.Clamp01(localPoint.x / size.x);
					logWindowTR.anchorMax = anchorMax;
				}
				else
				{
					localPoint.x += pivot.x * size.x - width;
					if (localPoint.x > size.x - minimumWidth)
					{
						localPoint.x = size.x - minimumWidth;
					}
					anchorMin.x = Mathf.Clamp01(localPoint.x / size.x);
				}
			}
			float num = 0f - logWindowTR.sizeDelta.y;
			localPoint.y += pivot.y * size.y - height;
			if (localPoint.y > size.y - minimumHeight - num)
			{
				localPoint.y = size.y - minimumHeight - num;
			}
			anchorMin.y = Mathf.Clamp01(localPoint.y / size.y);
			logWindowTR.anchorMin = anchorMin;
		}

		private void FilterLogs()
		{
			recycledListView.OnBeforeFilterLogs();
			logEntriesToShow.Clear();
			if (timestampsOfLogEntriesToShow != null)
			{
				timestampsOfLogEntriesToShow.Clear();
			}
			if (logFilter != DebugLogFilter.None)
			{
				DynamicCircularBuffer<DebugLogEntry> dynamicCircularBuffer = (isCollapseOn ? collapsedLogEntries : uncollapsedLogEntries);
				DynamicCircularBuffer<DebugLogEntryTimestamp> dynamicCircularBuffer2 = (isCollapseOn ? collapsedLogEntriesTimestamps : uncollapsedLogEntriesTimestamps);
				if (logFilter == DebugLogFilter.All)
				{
					if (!isInSearchMode)
					{
						logEntriesToShow.AddRange(dynamicCircularBuffer);
						if (timestampsOfLogEntriesToShow != null)
						{
							timestampsOfLogEntriesToShow.AddRange(dynamicCircularBuffer2);
						}
					}
					else
					{
						int i = 0;
						for (int count = dynamicCircularBuffer.Count; i < count; i++)
						{
							if (dynamicCircularBuffer[i].MatchesSearchTerm(searchTerm))
							{
								logEntriesToShow.Add(dynamicCircularBuffer[i]);
								if (timestampsOfLogEntriesToShow != null)
								{
									timestampsOfLogEntriesToShow.Add(dynamicCircularBuffer2[i]);
								}
							}
						}
					}
				}
				else
				{
					bool flag = (logFilter & DebugLogFilter.Info) == DebugLogFilter.Info;
					bool flag2 = (logFilter & DebugLogFilter.Warning) == DebugLogFilter.Warning;
					bool flag3 = (logFilter & DebugLogFilter.Error) == DebugLogFilter.Error;
					int j = 0;
					for (int count2 = dynamicCircularBuffer.Count; j < count2; j++)
					{
						DebugLogEntry debugLogEntry = dynamicCircularBuffer[j];
						if (isInSearchMode && !debugLogEntry.MatchesSearchTerm(searchTerm))
						{
							continue;
						}
						bool flag4 = false;
						if (debugLogEntry.logType == LogType.Log)
						{
							if (flag)
							{
								flag4 = true;
							}
						}
						else if (debugLogEntry.logType == LogType.Warning)
						{
							if (flag2)
							{
								flag4 = true;
							}
						}
						else if (flag3)
						{
							flag4 = true;
						}
						if (flag4)
						{
							logEntriesToShow.Add(debugLogEntry);
							if (timestampsOfLogEntriesToShow != null)
							{
								timestampsOfLogEntriesToShow.Add(dynamicCircularBuffer2[j]);
							}
						}
					}
				}
			}
			recycledListView.OnAfterFilterLogs();
			OnLogEntriesUpdated(updateAllVisibleItemContents: true, validateScrollPosition: true);
		}

		public string GetAllLogs()
		{
			return GetAllLogs(int.MaxValue, float.PositiveInfinity);
		}

		public string GetAllLogs(int maxLogCount, float maxElapsedTime)
		{
			ProcessQueuedLogs(queuedLogEntries.Count);
			int i = uncollapsedLogEntries.Count - Mathf.Min(uncollapsedLogEntries.Count, maxLogCount);
			if (uncollapsedLogEntriesTimestamps != null)
			{
				for (float realtimeSinceStartup = Time.realtimeSinceStartup; i < uncollapsedLogEntries.Count && realtimeSinceStartup - uncollapsedLogEntriesTimestamps[i].elapsedSeconds > maxElapsedTime; i++)
				{
				}
			}
			int num = 0;
			int length = Environment.NewLine.Length;
			for (int j = i; j < uncollapsedLogEntries.Count; j++)
			{
				DebugLogEntry debugLogEntry = uncollapsedLogEntries[j];
				num += debugLogEntry.logString.Length + debugLogEntry.stackTrace.Length + length * 3;
			}
			if (uncollapsedLogEntriesTimestamps != null)
			{
				num += (uncollapsedLogEntries.Count - i) * 30;
			}
			num += 200;
			StringBuilder stringBuilder = new StringBuilder(num);
			for (int k = i; k < uncollapsedLogEntries.Count; k++)
			{
				DebugLogEntry debugLogEntry2 = uncollapsedLogEntries[k];
				if (uncollapsedLogEntriesTimestamps != null)
				{
					uncollapsedLogEntriesTimestamps[k].AppendFullTimestamp(stringBuilder);
					stringBuilder.Append(": ");
				}
				stringBuilder.AppendLine(debugLogEntry2.logString).AppendLine(debugLogEntry2.stackTrace).AppendLine();
			}
			stringBuilder.Append("Current time: ").AppendLine((DateTime.UtcNow + localTimeUtcOffset).ToString("F"));
			stringBuilder.Append("Version: ").AppendLine(Application.version);
			return stringBuilder.ToString();
		}

		public void GetAllLogs(out DynamicCircularBuffer<DebugLogEntry> logEntries, out DynamicCircularBuffer<DebugLogEntryTimestamp> logTimestamps)
		{
			ProcessQueuedLogs(queuedLogEntries.Count);
			logEntries = uncollapsedLogEntries;
			logTimestamps = uncollapsedLogEntriesTimestamps;
		}

		public void SaveLogsToFile()
		{
			SaveLogsToFile(Path.Combine(Application.persistentDataPath, DateTime.Now.ToString("dd-MM-yyyy--HH-mm-ss") + ".txt"));
		}

		public void SaveLogsToFile(string filePath)
		{
			File.WriteAllText(filePath, GetAllLogs());
			Debug.Log("Logs saved to: " + filePath);
		}

		private void CheckScreenCutout()
		{
			_ = avoidScreenCutout;
		}

		internal void PoolLogItem(DebugLogItem logItem)
		{
			logItem.CanvasGroup.alpha = 0f;
			logItem.CanvasGroup.blocksRaycasts = false;
			pooledLogItems.Push(logItem);
		}

		internal DebugLogItem PopLogItem()
		{
			DebugLogItem debugLogItem;
			if (pooledLogItems.Count > 0)
			{
				debugLogItem = pooledLogItems.Pop();
				debugLogItem.CanvasGroup.alpha = 1f;
				debugLogItem.CanvasGroup.blocksRaycasts = true;
			}
			else
			{
				debugLogItem = UnityEngine.Object.Instantiate(logItemPrefab, logItemsContainer, worldPositionStays: false);
				debugLogItem.Initialize(recycledListView);
			}
			return debugLogItem;
		}
	}
}
