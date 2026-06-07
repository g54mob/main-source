using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi;
using ModApi.Common.Events;
using TMPro;
using UI.Tables;
using UI.Xml;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Dev.Philip.UiTesting.Scripts
{
	public class InfoPanel : XmlLayoutController
	{
		protected const bool DefaultAllowDragging = true;

		protected const int DefaultHeight = 200;

		protected const int DefaultWidth = 200;

		private const string NotInitializedError = "Panel must be initialized";

		private static bool _currentToggleVisibility;

		private static Transform _defaultParent;

		private static Transform _disabledContainer;

		private static bool _enabledByDefault;

		private static RectAlignment _lastAlignment;

		private static float _lastInitialPadding;

		private static float _lastPadding;

		private static List<InfoPanel> _panels;

		private Dictionary<string, UnityAction> _actionsButton = new Dictionary<string, UnityAction>();

		private Dictionary<string, UnityAction<int>> _actionsDropdown = new Dictionary<string, UnityAction<int>>();

		private Dictionary<string, Func<string>> _actionsDynamicText = new Dictionary<string, Func<string>>();

		private Dictionary<string, UnityAction<bool>> _actionsToggle = new Dictionary<string, UnityAction<bool>>();

		private bool _allowDragging = true;

		private XAttribute _contentStyle;

		private XAttribute _contentTextStyle;

		private Dictionary<XmlElementReference<TextMeshProUGUI>, Func<string>> _dynamicText = new Dictionary<XmlElementReference<TextMeshProUGUI>, Func<string>>();

		private UnityAction _headerClicked;

		private XAttribute _headerStyle;

		private int _height;

		private Dictionary<string, TextMeshProUGUI> _immediateLogControls = new Dictionary<string, TextMeshProUGUI>();

		private Dictionary<string, bool> _toogleButtonStates = new Dictionary<string, bool>();

		private int _width;

		private XDocument _xmlDoc;

		private XmlLayout _xmlLayout;

		private XElement _xmlLayoutTable;

		public static bool EnabledByDefault
		{
			get
			{
				return _enabledByDefault;
			}
			set
			{
				_enabledByDefault = value;
				_currentToggleVisibility = value;
				SetGlobalVisibility(value, autoArrange: true);
			}
		}

		public string StyleContent { get; set; } = "infoPanelContent";

		public string StyleContentDropdownLabel { get; set; } = "infoPanelContentDropLabel";

		public string StyleContentDropdownText { get; set; } = "infoPanelContentDropText";

		public string StyleContentText { get; set; } = "infoPanelContentText";

		public string StyleHeader { get; set; } = "sectionHeaderRow";

		public string StyleRowSize { get; set; } = "compactRow";

		public TableLayout TableLayout => base.xmlLayout.GetComponentInChildren<TableLayout>();

		public Dictionary<string, bool> ToggleStates => _toogleButtonStates;

		protected Canvas Canvas { get; private set; }

		private XAttribute ContentStyle
		{
			get
			{
				if (_contentStyle == null)
				{
					_contentStyle = new XAttribute("class", $"{StyleContent} {StyleRowSize}");
				}
				return _contentStyle;
			}
		}

		private XAttribute ContentTextStyle
		{
			get
			{
				if (_contentTextStyle == null)
				{
					_contentTextStyle = new XAttribute("class", $"{StyleContentText} {StyleRowSize}");
				}
				return _contentTextStyle;
			}
		}

		private XAttribute HeaderStyle
		{
			get
			{
				if (_headerStyle == null)
				{
					_headerStyle = new XAttribute("class", $"{StyleHeader} {StyleRowSize}");
				}
				return _headerStyle;
			}
		}

		static InfoPanel()
		{
			_currentToggleVisibility = true;
			_lastAlignment = RectAlignment.UpperRight;
			_lastInitialPadding = 80f;
			_lastPadding = 5f;
			_panels = new List<InfoPanel>();
			SceneManager.activeSceneChanged += OnActiveSceneChanged;
			EnabledByDefault = true;
		}

		public static void AutoArrange()
		{
			AutoArrange(_lastAlignment, _lastInitialPadding, _lastPadding);
		}

		public static void AutoArrange(RectAlignment align, float initialPadding = 0f, float padding = 5f)
		{
			_lastAlignment = align;
			_lastInitialPadding = initialPadding;
			_lastPadding = padding;
			AutoArrangePerform(align, initialPadding, padding);
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				AutoArrangePerform(align, initialPadding, padding);
			});
		}

		public static T Create<T>(string name, UnityAction onHeaderClicked, bool forceVisible = false) where T : InfoPanel
		{
			return Create<T>(name, createHeader: true, onHeaderClicked, null, null, null, null, forceVisible);
		}

		public static T Create<T>(string name, bool createHeader, UnityAction onHeaderClicked, int? width, int? height, bool? draggable, Transform parent, bool forceVisible) where T : InfoPanel
		{
			Canvas canvas = new GameObject($"InfoPanelCanvas({name})").AddComponent<Canvas>();
			if (parent != null)
			{
				canvas.transform.SetParent(parent);
			}
			else
			{
				if (_defaultParent == null)
				{
					_defaultParent = new GameObject("InfoPanels").transform;
				}
				if (_disabledContainer == null)
				{
					_disabledContainer = new GameObject("Disabled").transform;
					_disabledContainer.gameObject.SetActive(value: false);
				}
				canvas.transform.SetParent(_defaultParent);
			}
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.worldCamera = Camera.current;
			canvas.gameObject.AddComponent<GraphicRaycaster>();
			T val = canvas.gameObject.AddComponent<T>();
			val.Clear(width, height, draggable);
			val.Canvas = canvas;
			if (createHeader)
			{
				val.AddHeader(name, onHeaderClicked);
			}
			val.RebuildUi();
			_panels.Add(val);
			if (!forceVisible)
			{
				val.Canvas.enabled = EnabledByDefault;
			}
			Utilities.SetLayerRecursive(canvas.gameObject, 5);
			return val;
		}

		public static float GetPreferredHeightAllChildren(RectTransform rectTransform)
		{
			float num = 0f;
			RectTransform[] componentsInChildren = rectTransform.GetComponentsInChildren<RectTransform>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				float preferredHeight = LayoutUtility.GetPreferredHeight(componentsInChildren[i]);
				num = ((preferredHeight > num) ? preferredHeight : num);
			}
			return num;
		}

		public static void SetGlobalVisibility(bool visible, bool autoArrange)
		{
			foreach (InfoPanel panel in _panels)
			{
				panel.Canvas.enabled = visible;
			}
			if (autoArrange)
			{
				AutoArrange();
			}
		}

		public static void ToggleVisibility()
		{
			_currentToggleVisibility = !_currentToggleVisibility;
			SetGlobalVisibility(_currentToggleVisibility, autoArrange: true);
		}

		public void AddButton(string desc, string buttonText, UnityAction onClicked, bool rebuildUi = true)
		{
			AddButton(null, desc, buttonText, onClicked, rebuildUi);
		}

		public void AddButton(string id, string desc, string buttonText, UnityAction onClicked, bool rebuildUi = true)
		{
			id = (string.IsNullOrEmpty(id) ? desc : id);
			if (!_actionsButton.ContainsKey(id))
			{
				_xmlLayoutTable.Add(ContentRow(new XElement("Cell", ContentText(desc)), new XElement("Cell", new XElement("Button", new XAttribute("id", id), ContentText(buttonText)))));
				_actionsButton.Add(id, onClicked);
				if (rebuildUi)
				{
					RebuildUi();
				}
			}
		}

		public void AddDropdown(string desc, string toolTip, UnityAction<int> onSelectionChanged, int? selectedItem, List<string> items, bool rebuildUi = true)
		{
			AddDropdown(null, desc, toolTip, onSelectionChanged, selectedItem, items, rebuildUi);
		}

		public void AddDropdown(string id, string desc, string toolTip, UnityAction<int> onSelectionChanged, int? selectedItem, List<string> items, bool rebuildUi = true)
		{
			id = (string.IsNullOrEmpty(id) ? desc : id);
			if (_actionsDropdown.ContainsKey(id))
			{
				return;
			}
			XAttribute xAttribute = new XAttribute("toolTip", toolTip);
			xAttribute = null;
			XElement xElement = new XElement("TextMeshProDropdown", ContentTextStyle, new XAttribute("id", id), xAttribute);
			_xmlLayoutTable.Add(ContentRow(new XElement("Cell", ContentText(desc)), new XElement("Cell", xElement)));
			xElement.Add(new XElement("TMP_DropdownLabel", new XAttribute("class", StyleContentDropdownLabel)));
			xElement.Add(new XElement("TMP_OptionTextTemplate", new XAttribute("class", StyleContentDropdownText)));
			int num = 0;
			foreach (string item in items)
			{
				XElement xElement2 = new XElement("TMP_Option", item);
				if (selectedItem == num)
				{
					xElement2.Add(new XAttribute("selected", "true"));
				}
				xElement.Add(xElement2);
				num++;
			}
			_actionsDropdown.Add(id, onSelectionChanged);
			if (rebuildUi)
			{
				RebuildUi();
			}
		}

		public void AddDynamicText(string desc, Func<string> text, bool rebuildUi = true)
		{
			AddDynamicText(null, desc, text, rebuildUi);
		}

		public void AddDynamicText(string id, string desc, Func<string> text, bool rebuildUi = true)
		{
			id = (string.IsNullOrEmpty(id) ? desc : id);
			if (!_actionsDynamicText.ContainsKey(id))
			{
				_xmlLayoutTable.Add(ContentRow(new XElement("Cell", ContentText(desc)), new XElement("Cell", ContentText(string.IsNullOrEmpty(id) ? null : new XAttribute("id", id), string.Empty))));
				_actionsDynamicText.Add(id, text);
				if (rebuildUi)
				{
					RebuildUi();
				}
			}
		}

		public void AddHeader(string text, UnityAction onClicked, bool rebuildUi = true)
		{
			_xmlLayoutTable.Add(CreateHeaderRow(new XElement("Cell", new XAttribute("columnSpan", "2"), new XAttribute("dontUseTableCellBackground", "1"), new XElement("Button", new XAttribute("id", "headerId"), new XAttribute("text", text)))));
			_headerClicked = onClicked;
			if (rebuildUi)
			{
				RebuildUi();
			}
		}

		public void AddStaticText(string desc, object value, bool rebuildUi = true)
		{
			AddStaticText(null, desc, value, rebuildUi);
		}

		public void AddStaticText(string id, string desc, object value, bool rebuildUi = true)
		{
			id = (string.IsNullOrEmpty(id) ? desc : id);
			_xmlLayoutTable.Add(ContentRow(new XElement("Cell", ContentText(desc)), new XElement("Cell", ContentText(string.IsNullOrEmpty(id) ? null : new XAttribute("id", id), value))));
			if (rebuildUi)
			{
				RebuildUi();
			}
		}

		public void AddToggleButton(string desc, bool initialValue, UnityAction<bool> onChanged, bool rebuildUi = true)
		{
			if (_toogleButtonStates.ContainsKey(desc))
			{
				_toogleButtonStates[desc] = initialValue;
			}
			else
			{
				_toogleButtonStates.Add(desc, initialValue);
			}
			AddToggleButton(null, desc, initialValue, delegate(bool x)
			{
				_toogleButtonStates[desc] = x;
				onChanged(x);
			}, rebuildUi);
		}

		public void AddToggleButton(string id, string desc, bool initialValue, UnityAction<bool> onChanged, bool rebuildUi = true)
		{
			id = (string.IsNullOrEmpty(id) ? desc : id);
			if (!_actionsToggle.ContainsKey(id))
			{
				_xmlLayoutTable.Add(ContentRow(new XElement("Cell", ContentText(desc)), new XElement("Cell", new XElement("Toggle", new XAttribute("isOn", initialValue), new XAttribute("toggleheight", "13"), new XAttribute("togglewidth", "13"), new XAttribute("id", id)))));
				_actionsToggle.Add(id, onChanged);
			}
			else
			{
				_ = _actionsToggle[id];
			}
			if (rebuildUi)
			{
				RebuildUi();
			}
		}

		public void Clear(int? width, int? height, bool? allowDragging)
		{
			_width = (width.HasValue ? width.Value : 200);
			_height = (height.HasValue ? height.Value : 200);
			_allowDragging = !allowDragging.HasValue || allowDragging.Value;
			CreateXmlDoc();
		}

		public void LogValue(string desc, object value)
		{
			LogValue(desc, desc, value);
		}

		public void LogValue(string id, string desc, object value)
		{
			id = (string.IsNullOrEmpty(id) ? desc : id);
			if (!_immediateLogControls.ContainsKey(id))
			{
				AddStaticText(id, desc, value);
				RebuildUi();
				XmlElementReference<TextMeshProUGUI> xmlElementReference = XmlElementReference<TextMeshProUGUI>(id);
				_immediateLogControls.Add(id, xmlElementReference);
			}
			_immediateLogControls[id].text = value.ToString();
		}

		public virtual void RebuildUi()
		{
			if (_xmlLayout == null)
			{
				_xmlLayout = base.xmlLayout;
			}
			_xmlLayout.Xml = _xmlDoc.ToString();
			_xmlLayout.RebuildLayout();
			if (_headerClicked != null)
			{
				XmlElementReference<Button>("headerId").element.onClick.AddListener(_headerClicked);
			}
			RefreshActions();
			RefreshControlReferences();
		}

		public void SetPosition(Vector2 position)
		{
			RectTransform component = TableLayout.GetComponent<RectTransform>();
			component.localPosition = Vector3.zero;
			component.localPosition = -component.anchoredPosition + position;
		}

		protected virtual void OnDestroy()
		{
			_panels.Remove(this);
		}

		protected virtual void Update()
		{
			foreach (KeyValuePair<XmlElementReference<TextMeshProUGUI>, Func<string>> item in _dynamicText)
			{
				item.Key.element.text = item.Value();
			}
		}

		private static void AutoArrangePerform(RectAlignment align, float initialPadding = 0f, float padding = 5f)
		{
			Vector2 vector;
			Vector2 anchorMin;
			Vector2 pivot;
			switch (align)
			{
			case RectAlignment.UpperCenter:
				vector = new Vector2(0.5f, 1f);
				anchorMin = vector;
				pivot = vector;
				break;
			case RectAlignment.UpperLeft:
				vector = new Vector2(0f, 1f);
				anchorMin = vector;
				pivot = vector;
				break;
			case RectAlignment.UpperRight:
				vector = new Vector2(1f, 1f);
				anchorMin = vector;
				pivot = vector;
				break;
			default:
				throw new InvalidOperationException("Unsupported alignment");
			}
			float num = initialPadding;
			foreach (InfoPanel panel in _panels)
			{
				RectTransform obj = panel.TableLayout.transform as RectTransform;
				obj.anchorMax = vector;
				obj.anchorMin = anchorMin;
				obj.pivot = pivot;
				panel.SetPosition(new Vector2(0f, 0f - num));
				num += GetPreferredHeightAllChildren(panel.transform as RectTransform) + padding;
			}
		}

		private static void OnActiveSceneChanged(Scene arg0, Scene arg1)
		{
			Reset();
		}

		private static void Reset()
		{
			_currentToggleVisibility = false;
			_defaultParent = null;
			_disabledContainer = null;
			_enabledByDefault = false;
			_lastAlignment = RectAlignment.UpperRight;
			_lastInitialPadding = 80f;
			_lastPadding = 5f;
			_panels.Clear();
		}

		private XElement ContentRow(params object[] content)
		{
			return CreateRow(ContentStyle, content);
		}

		private XElement ContentText(params object[] content)
		{
			return new XElement("TextMeshPro", ContentTextStyle, content);
		}

		private XElement CreateHeaderRow(params object[] content)
		{
			return CreateRow(HeaderStyle, content);
		}

		private XElement CreateRow(XAttribute style, params object[] content)
		{
			return new XElement("Row", style, content);
		}

		private XElement CreateText(XAttribute style, params object[] content)
		{
			return new XElement("TextMeshPro", style, content);
		}

		private void CreateXmlDoc()
		{
			_xmlDoc = new XDocument();
			XElement xElement = new XElement("XmlLayout");
			_xmlDoc.Add(xElement);
			XElement content = new XElement("Include", new XAttribute("path", "Ui/Xml/InfoPanel/InfoPanelStyles.xml"));
			xElement.Add(content);
			_xmlLayoutTable = new XElement("TableLayout", new XAttribute("autoCalculateHeight", "true"), new XAttribute("width", _width.ToString()), new XAttribute("allowDragging", _allowDragging.ToString()), new XAttribute("returnToOriginalPositionWhenReleased", "false"));
			xElement.Add(_xmlLayoutTable);
		}

		private void RefreshActions()
		{
			_dynamicText.Clear();
			foreach (KeyValuePair<string, Func<string>> item in _actionsDynamicText)
			{
				_dynamicText.Add(XmlElementReference<TextMeshProUGUI>(item.Key), item.Value);
			}
			foreach (KeyValuePair<string, UnityAction<bool>> item2 in _actionsToggle)
			{
				XmlElementReference<Toggle>(item2.Key).element.onValueChanged.AddListener(item2.Value);
			}
			foreach (KeyValuePair<string, UnityAction> item3 in _actionsButton)
			{
				XmlElementReference<Button>(item3.Key).element.onClick.AddListener(item3.Value);
			}
			foreach (KeyValuePair<string, UnityAction<int>> item4 in _actionsDropdown)
			{
				XmlElementReference<TMP_Dropdown>(item4.Key).element.onValueChanged.AddListener(item4.Value);
			}
		}

		private void RefreshControlReferences()
		{
			List<string> list = _immediateLogControls.Keys.ToList();
			_immediateLogControls.Clear();
			foreach (string item in list)
			{
				_immediateLogControls.Add(item, XmlElementReference<TextMeshProUGUI>(item));
			}
		}
	}
}
