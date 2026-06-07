using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Ui;
using DigitalLegacy.UI.Sizing;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Flight.MapView;
using ModApi.Flight.UI;
using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI
{
	public class FlightLogScript : MonoBehaviour, IFlightLogUI
	{
		private class LogEntryUI
		{
			public Image ButtonImage { get; }

			public FlightLogEntry LogEntry { get; set; }

			public string Text
			{
				get
				{
					return TextMeshPro.text;
				}
				set
				{
					TextMeshPro.text = value;
				}
			}

			public TextMeshProUGUI TextMeshPro { get; }

			public RectTransform Transform { get; }

			public LogEntryUI(TextMeshProUGUI textMeshPro, RectTransform transform, Image buttonImage)
			{
				TextMeshPro = textMeshPro;
				Transform = transform;
				ButtonImage = buttonImage;
			}
		}

		private SimpleContentSizeFitter _contentSizeFitter;

		private List<FlightLogEntry> _filteredLogEntries = new List<FlightLogEntry>();

		private bool _inMapView;

		private XmlElement _logEntriesContent;

		private float _logEntriesViewportHeight;

		private TextMeshProUGUI _logEntryDetails;

		private float _logEntryHeight;

		private TextMeshProUGUI _logEntryTemplate;

		private FlightLogEntryCategory _logFilter = FlightLogEntryCategory.All;

		private RectTransform _panelRoot;

		private LayoutElement _panelRootLayout;

		private XmlElement _pinElement;

		private bool _pinned;

		private bool _refreshUI = true;

		private uResize _resize;

		private ScrollRect _scrollRectDetails;

		private LayoutElement _scrollRectDetailsLayout;

		private ScrollRect _scrollRectLog;

		private LayoutElement _scrollRectLogLayout;

		private RectTransform _scrollRectLogTransform;

		private FlightLogEntry _selectedLog;

		private LayoutElement _titleTextLayout;

		private List<LogEntryUI> _uiLogEntries;

		public bool Collapsed
		{
			get
			{
				return !_scrollRectLog.gameObject.activeSelf;
			}
			set
			{
				if (value == _scrollRectLog.gameObject.activeSelf)
				{
					_scrollRectLog.gameObject.SetActive(!value);
					if (value)
					{
						_scrollRectDetails.gameObject.SetActive(value: false);
						return;
					}
					RefreshUI();
					_scrollRectLog.verticalNormalizedPosition = 0f;
				}
			}
		}

		public IFlightLog FlightLog { get; private set; }

		public bool Pinned
		{
			get
			{
				return _pinned;
			}
			set
			{
				_pinned = value;
				if (value)
				{
					if (!_pinElement.HasClass("inspector-panel-pin-selected"))
					{
						_pinElement.AddClass("inspector-panel-pin-selected");
					}
				}
				else
				{
					_pinElement.RemoveClass("inspector-panel-pin-selected");
				}
			}
		}

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				if (_inMapView)
				{
					VisibleInMapView = value;
					if (!value && Pinned)
					{
						VisibleInGameView = value;
					}
				}
				else
				{
					VisibleInGameView = value;
					if (!value && Pinned)
					{
						VisibleInMapView = value;
					}
				}
				Pinned = false;
				UpdateVisibility();
			}
		}

		public bool VisibleInGameView { get; private set; }

		public bool VisibleInMapView { get; private set; }

		public static FlightLogScript Create(RectTransform parent, IFlightLog flightLog)
		{
			FlightLogScript flightLogScript = UiUtilities.CreateUiGameObject("FlightLog", parent).AddComponent<FlightLogScript>();
			flightLogScript.FlightLog = flightLog;
			flightLogScript.FlightLog.LogEntryAdded += flightLogScript.OnLogAdded;
			Game.Instance.UserInterface.BuildUserInterfaceFromResource("Ui/Xml/Flight/FlightLogPanel", flightLogScript, flightLogScript.OnLayoutRebuilt);
			return flightLogScript;
		}

		protected virtual void OnDestroy()
		{
			FlightLog.LogEntryAdded -= OnLogAdded;
			IMapViewManager mapViewManager = Game.Instance.FlightScene?.ViewManager?.MapViewManager;
			if (mapViewManager != null)
			{
				mapViewManager.ForegroundStateChanged -= MapViewVisibleStateChanged;
			}
		}

		protected virtual void Start()
		{
			Game.Instance.FlightScene.ViewManager.MapViewManager.ForegroundStateChanged += MapViewVisibleStateChanged;
			UpdateFilteredLogEntryList();
			RebuildLogEntries();
			Visible = false;
			if (Visible)
			{
				RefreshUI();
			}
		}

		protected virtual void Update()
		{
			if (_refreshUI)
			{
				RefreshUI();
				return;
			}
			foreach (LogEntryUI uiLogEntry in _uiLogEntries)
			{
				FlightLogEntry logEntry = uiLogEntry.LogEntry;
				if (logEntry != null && logEntry.IsDynamic)
				{
					uiLogEntry.Text = uiLogEntry.LogEntry.Text;
				}
			}
			FlightLogEntry selectedLog = _selectedLog;
			if (selectedLog != null && selectedLog.IsDynamic)
			{
				_logEntryDetails.text = _selectedLog.Text;
			}
		}

		private void MapViewVisibleStateChanged(bool foreground)
		{
			_inMapView = foreground;
			UpdateVisibility();
		}

		private void OnCloseClicked()
		{
			Visible = false;
		}

		private void OnDragEnd()
		{
			SavePositionToUserPrefs();
		}

		private void OnLayoutRebuilt(IXmlLayoutController xmlLayoutController)
		{
			_uiLogEntries = new List<LogEntryUI>();
			XmlLayout xmlLayout = (XmlLayout)xmlLayoutController.XmlLayout;
			XmlElement xmlElement = xmlLayout.XmlElement;
			_panelRoot = xmlLayout.GetElementById<RectTransform>("flight-log-panel");
			_scrollRectLog = xmlElement.GetElementByInternalId<ScrollRect>("scroll-view-log");
			_logEntriesContent = xmlElement.GetElementByInternalId("log-entries-content");
			_scrollRectDetails = xmlElement.GetElementByInternalId<ScrollRect>("scroll-view-log-details");
			_logEntryDetails = xmlElement.GetElementByInternalId<TextMeshProUGUI>("log-entry-details-text");
			_logEntryTemplate = xmlElement.GetElementByInternalId<TextMeshProUGUI>("template-log-entry");
			_pinElement = xmlElement.GetElementByInternalId("pin-button");
			_titleTextLayout = xmlElement.GetElementByInternalId("title-text").GetComponentInParent<LayoutElement>();
			_panelRootLayout = _panelRoot.GetComponent<LayoutElement>();
			_scrollRectLogLayout = _scrollRectLog.GetComponent<LayoutElement>();
			_scrollRectDetailsLayout = _scrollRectDetails.GetComponent<LayoutElement>();
			_scrollRectLogTransform = _scrollRectLog.GetComponent<RectTransform>();
			_contentSizeFitter = _scrollRectLog.content.GetComponent<SimpleContentSizeFitter>();
			_logEntryHeight = _logEntryTemplate.rectTransform.sizeDelta.y;
			_scrollRectLog.onValueChanged.AddListener(OnScroll);
			_scrollRectDetails.gameObject.SetActive(value: false);
			_panelRoot.GetComponent<XmlElement>().AddOnEndDragEvent(OnDragEnd);
			Vector2? vector2OrNull = Game.Instance.Settings.UserPrefs.GetVector2OrNull("FlightLog.Position");
			if (vector2OrNull.HasValue)
			{
				_panelRoot.anchoredPosition = vector2OrNull.Value;
			}
			if (!Device.IsMobileBuild)
			{
				SetupResize();
				Vector2? vector2OrNull2 = Game.Instance.Settings.UserPrefs.GetVector2OrNull("FlightLog.Size");
				if (vector2OrNull2.HasValue)
				{
					_panelRoot.sizeDelta = vector2OrNull2.Value;
					_scrollRectLogLayout.preferredHeight = vector2OrNull2.Value.y;
				}
			}
		}

		private void OnLogAdded(FlightLogEntry logEntry)
		{
			if (_logFilter.HasFlag(logEntry.Category))
			{
				_filteredLogEntries.Add(logEntry);
				if (Visible && !Collapsed)
				{
					_refreshUI = true;
				}
			}
		}

		private void OnLogEntryClicked(Image logEntryImage)
		{
			LogEntryUI logEntryUI = _uiLogEntries.FirstOrDefault((LogEntryUI x) => x.ButtonImage == logEntryImage);
			if (logEntryUI == null)
			{
				Debug.LogError("Could not determine the flight log entry that was clicked.");
			}
			else if (_selectedLog == logEntryUI.LogEntry)
			{
				_selectedLog = null;
				_scrollRectDetails.gameObject.SetActive(value: false);
				_resize.MinSize = new Vector2(250f, 55f);
			}
			else if (logEntryUI.LogEntry != null)
			{
				_selectedLog = logEntryUI.LogEntry;
				_logEntryDetails.text = logEntryUI.LogEntry.Text;
				_scrollRectDetails.gameObject.SetActive(value: true);
				_resize.MinSize = new Vector2(250f, 55f + _scrollRectDetailsLayout.preferredHeight);
				IPartScript associatedPart = logEntryUI.LogEntry.AssociatedPart;
				if (associatedPart != null && associatedPart.GameObject != null && associatedPart.GameObject.activeInHierarchy && !associatedPart.Data.IsDestroyed)
				{
					Game.Instance.FlightScene.ViewManager.GameView.SelectedPart = associatedPart;
				}
			}
		}

		private void OnMainHeaderClicked()
		{
			Collapsed = !Collapsed;
		}

		private void OnPinClicked()
		{
			Pinned = !Pinned;
		}

		private void OnResizeEnd()
		{
			OnResizeUpdate();
			string key = "FlightLog.Size";
			Vector2 value = new Vector2((int)_panelRootLayout.preferredWidth, (int)_scrollRectLogLayout.preferredHeight);
			Game.Instance.Settings.UserPrefs.SetVector2(key, value);
			SavePositionToUserPrefs();
			_panelRootLayout.preferredHeight = -1f;
			_panelRootLayout.preferredWidth = -1f;
		}

		private void OnResizeUpdate()
		{
			int num = (((int?)_titleTextLayout?.preferredHeight) ?? 30) + 5;
			float num2 = 0f;
			if (_scrollRectDetails.gameObject.activeSelf)
			{
				num2 = _scrollRectDetailsLayout.preferredHeight;
			}
			_scrollRectLogLayout.preferredHeight = _panelRootLayout.preferredHeight - (float)num - num2;
		}

		private void OnScroll(Vector2 arg)
		{
			RefreshUI();
		}

		private void RebuildLogEntries()
		{
			foreach (LogEntryUI uiLogEntry in _uiLogEntries)
			{
				Object.Destroy(uiLogEntry.Transform.gameObject);
			}
			_uiLogEntries.Clear();
			_logEntriesViewportHeight = _scrollRectLogTransform.sizeDelta.y;
			int num = Mathf.CeilToInt(_logEntriesViewportHeight / _logEntryHeight) + 1;
			_uiLogEntries = new List<LogEntryUI>();
			for (int i = 0; i < num; i++)
			{
				XmlElement xmlElement = UiUtilities.CloneTemplate(_logEntryTemplate.GetComponent<XmlElement>(), _logEntriesContent);
				xmlElement.name = $"Flight Log Entry {i}";
				xmlElement.SetActive(active: true);
				RectTransform rectTransform = xmlElement.rectTransform;
				TextMeshProUGUI component = xmlElement.GetComponent<TextMeshProUGUI>();
				Image componentInChildren = xmlElement.GetComponentInChildren<Image>();
				LogEntryUI item = new LogEntryUI(component, rectTransform, componentInChildren);
				_uiLogEntries.Add(item);
			}
		}

		private void RefreshUI()
		{
			_refreshUI = false;
			float y = _scrollRectLogTransform.sizeDelta.y;
			if (!Mathf.Approximately(_logEntriesViewportHeight, y))
			{
				RebuildLogEntries();
			}
			else if (y == 0f)
			{
				_refreshUI = true;
				return;
			}
			float num = Mathf.Max(0f, _scrollRectLog.content.localPosition.y);
			bool flag = false;
			Vector2 sizeDelta = _logEntriesContent.rectTransform.sizeDelta;
			float num2 = (float)_filteredLogEntries.Count * _logEntryHeight;
			if (!Mathf.Approximately(sizeDelta.y, num2))
			{
				float num3 = sizeDelta.y - (num + _logEntriesViewportHeight);
				flag = (num3 <= _logEntryHeight && num3 > -5f) || (sizeDelta.y < _logEntriesViewportHeight && num2 > _logEntriesViewportHeight);
				_logEntriesContent.rectTransform.sizeDelta = new Vector2(sizeDelta.x, num2);
				_contentSizeFitter.MatchChildDimensions();
			}
			if (flag)
			{
				_scrollRectLog.content.localPosition = new Vector3(0f, _logEntriesContent.rectTransform.sizeDelta.y - _logEntriesViewportHeight, 0f);
				num = Mathf.Max(0f, _scrollRectLog.content.localPosition.y);
			}
			int num4 = (int)(num / _logEntryHeight);
			int num5 = num4 % _uiLogEntries.Count;
			for (int i = 0; i < _uiLogEntries.Count; i++)
			{
				LogEntryUI logEntryUI = _uiLogEntries[num5];
				int num6 = num4 + i;
				if (num6 < _filteredLogEntries.Count)
				{
					logEntryUI.LogEntry = _filteredLogEntries[num6];
					logEntryUI.Text = logEntryUI.LogEntry.Text;
				}
				else
				{
					logEntryUI.LogEntry = null;
					logEntryUI.Text = string.Empty;
				}
				logEntryUI.Transform.anchoredPosition = new Vector2(0f, 0f - _logEntryHeight * (float)num6);
				num5 = (num5 + 1) % _uiLogEntries.Count;
			}
		}

		private void SavePositionToUserPrefs()
		{
			string key = "FlightLog.Position";
			Vector2 anchoredPosition = _panelRoot.anchoredPosition;
			Game.Instance.Settings.UserPrefs.SetVector2(key, new Vector2((int)anchoredPosition.x, (int)anchoredPosition.y));
		}

		private void SetupResize()
		{
			IResourceLoader resourceLoader = Game.Instance.ResourceLoader;
			uResize uResize2 = _panelRoot.gameObject.AddComponent<uResize>();
			uResize2.AllowResizeFromBottom = true;
			uResize2.AllowResizeFromBottomLeft = true;
			uResize2.AllowResizeFromBottomRight = true;
			uResize2.AllowResizeFromLeft = true;
			uResize2.AllowResizeFromRight = true;
			uResize2.AllowResizeFromTop = true;
			uResize2.AllowResizeFromTopRight = true;
			uResize2.AllowResizeFromTopLeft = true;
			uResize2.MinSize = new Vector2(250f, 55f);
			uResize2.ResizeListenerOffsetMin = new Vector2(-6f, -6f);
			uResize2.ResizeListenerOffsetMax = new Vector2(6f, 6f);
			uResize2.ResizeListenerThickness = 8f;
			uResize2.OnResizeUpdate.AddListener(OnResizeUpdate);
			uResize2.OnResizeEnd.AddListener(OnResizeEnd);
			_resize = uResize2;
			uResize_CursorController obj = _panelRoot.gameObject.AddComponent<uResize_CursorController>();
			obj.HorizontalCursor = resourceLoader.LoadTexture("Ui/Sprites/Common/ResizeArrowHorizontal_small");
			obj.VerticalCursor = resourceLoader.LoadTexture("Ui/Sprites/Common/ResizeArrowVertical_small");
			obj.TopRightCursor = resourceLoader.LoadTexture("Ui/Sprites/Common/ResizeArrowDiagonal1_small");
			obj.TopLeftCursor = resourceLoader.LoadTexture("Ui/Sprites/Common/ResizeArrowDiagonal2_small");
			obj.BottomLeftCursor = obj.TopRightCursor;
			obj.BottomRightCursor = obj.TopLeftCursor;
			_titleTextLayout.minHeight = _titleTextLayout.preferredHeight;
		}

		private void UpdateFilteredLogEntryList()
		{
			_filteredLogEntries = ((_logFilter == FlightLogEntryCategory.All) ? FlightLog.LogEntries.ToList() : FlightLog.LogEntries.Where((FlightLogEntry x) => _logFilter.HasFlag(x.Category)).ToList());
		}

		private void UpdateVisibility()
		{
			bool visible = Visible;
			bool flag = Pinned || (_inMapView && VisibleInMapView) || (!_inMapView && VisibleInGameView);
			if (flag != visible)
			{
				base.gameObject.SetActive(flag);
				if (flag)
				{
					RefreshUI();
					_scrollRectLog.verticalNormalizedPosition = 0f;
				}
			}
		}
	}
}
