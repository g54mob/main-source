using System;
using System.Collections.Generic;
using Assets.Scripts.Ui;
using ModApi.Flight.MapView;
using ModApi.Flight.UI;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.UI
{
	public class ContextMenuController : XmlLayoutController, IContextMenu, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private class ContextMenuItem
		{
			private Button _button;

			private ContextMenuController _contextMenu;

			private Image _image;

			private LayoutElement _layoutElement;

			private TextMeshProUGUI _textMeshPro;

			public Action Action { get; private set; }

			public bool AutoCloseOnClick { get; private set; }

			public Sprite Icon
			{
				get
				{
					return _image.sprite;
				}
				private set
				{
					_image.sprite = value;
				}
			}

			public Color IconColor
			{
				get
				{
					return _image.color;
				}
				private set
				{
					_image.color = value;
				}
			}

			public LayoutElement Layout => _layoutElement;

			public string Name
			{
				get
				{
					return _textMeshPro.text;
				}
				private set
				{
					_textMeshPro.text = value;
				}
			}

			public XmlElement XmlElement { get; }

			public ContextMenuItem(XmlElement xmlElement, ContextMenuController contextMenu)
			{
				XmlElement = xmlElement;
				_contextMenu = contextMenu;
				_button = xmlElement.GetComponent<Button>();
				_textMeshPro = xmlElement.GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
				_image = xmlElement.GetElementByInternalId<Image>("context-menu-item-icon");
				_layoutElement = xmlElement.GetComponent<LayoutElement>();
				_button.onClick.AddListener(OnClick);
			}

			public void Activate(string name, Sprite icon, Color? iconColor, Action action, bool autoCloseOnClick = true)
			{
				Name = name;
				Icon = icon;
				Action = action;
				AutoCloseOnClick = autoCloseOnClick;
				if (icon != null)
				{
					XmlElement.RemoveClass("context-menu-item-no-icon");
					XmlElement.AddClass("context-menu-item-with-icon");
				}
				else
				{
					XmlElement.RemoveClass("context-menu-item-with-icon");
					XmlElement.AddClass("context-menu-item-no-icon");
				}
				XmlElement.SetActive(active: true);
				IconColor = iconColor ?? Color.white;
				_textMeshPro.ForceMeshUpdate();
				_layoutElement.preferredWidth = _textMeshPro.preferredWidth + _textMeshPro.rectTransform.anchoredPosition.x + 4f;
			}

			public void Deactivate()
			{
				Name = string.Empty;
				Icon = null;
				Action = null;
				XmlElement.SetActive(active: false);
			}

			private void OnClick()
			{
				try
				{
					Action?.Invoke();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
				if (AutoCloseOnClick)
				{
					_contextMenu.HideContextMenu();
				}
			}
		}

		private Canvas _canvas;

		private XmlElement _contextMenu;

		private XmlElement _contextMenuItemTemplate;

		private bool _isMouseOverContextMenu;

		private int _itemCount;

		private List<ContextMenuItem> _items;

		public bool IsVisible => _contextMenu.gameObject.activeInHierarchy;

		public void AddContextMenuItem(string name, Sprite icon, Color? iconColor, Action action, bool autoCloseOnClick = true)
		{
			_itemCount++;
			while (_itemCount > _items.Count)
			{
				XmlElement xmlElement = UiUtilities.CloneTemplate(_contextMenuItemTemplate, _contextMenu);
				_items.Add(new ContextMenuItem(xmlElement, this));
				xmlElement.rectTransform.SetSiblingIndex(_items.Count - 1);
			}
			_items[_itemCount - 1].Activate(name, icon, iconColor, action, autoCloseOnClick);
		}

		public void ClearContextMenu()
		{
			for (int i = 0; i < _itemCount; i++)
			{
				_items[i].Deactivate();
			}
			_itemCount = 0;
		}

		public void HideContextMenu()
		{
			if (IsVisible)
			{
				_contextMenu.SetActive(active: false);
				ClearContextMenu();
			}
		}

		public override void LayoutRebuilt(ParseXmlResult parseResult)
		{
			base.LayoutRebuilt(parseResult);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_isMouseOverContextMenu = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_isMouseOverContextMenu = false;
		}

		public void ShowContextMenu(Vector2 position)
		{
			if (_itemCount == 0)
			{
				Debug.LogError("Unable to show the context menu with zero items");
				return;
			}
			_contextMenu.SetActive(active: true);
			_contextMenu.rectTransform.position = position + new Vector2(0f, _items[0].Layout.preferredHeight / 2f) * _canvas.scaleFactor;
			LayoutRebuilder.ForceRebuildLayoutImmediate(_contextMenu.rectTransform);
			Vector3 zero = Vector3.zero;
			Vector3[] array = new Vector3[4];
			_contextMenu.rectTransform.GetWorldCorners(array);
			if (array[0].y < 0f)
			{
				zero.y = 0f - array[0].y;
			}
			else if (array[1].y > (float)Screen.height)
			{
				zero.y = (float)Screen.height - array[1].y;
			}
			if (array[0].x < 0f)
			{
				zero.x = 0f - array[0].x;
			}
			else if (array[3].x > (float)Screen.width)
			{
				zero.x = (float)Screen.width - array[3].x;
			}
			if (zero != Vector3.zero)
			{
				_contextMenu.rectTransform.position += zero;
			}
		}

		protected virtual void OnDestroy()
		{
			IMapViewManager mapViewManager = Game.Instance.FlightScene?.ViewManager?.MapViewManager;
			if (mapViewManager != null)
			{
				mapViewManager.ForegroundStateChanging -= OnMapViewForgroundStateChanging;
			}
		}

		protected virtual void Start()
		{
			_canvas = GetComponentInParent<Canvas>();
			_canvas.overrideSorting = true;
			_canvas.sortingOrder = 10;
			_contextMenu = base.xmlLayout.GetElementById("context-menu");
			_contextMenuItemTemplate = _contextMenu.GetElementByInternalId("context-menu-button-template");
			_items = new List<ContextMenuItem>();
			Game.Instance.FlightScene.ViewManager.MapViewManager.ForegroundStateChanging += OnMapViewForgroundStateChanging;
			HideContextMenu();
		}

		protected virtual void Update()
		{
			if ((UnityEngine.Input.GetMouseButtonDown(0) || UnityEngine.Input.GetMouseButtonDown(1) || UnityEngine.Input.GetMouseButtonDown(2)) && IsVisible && !_isMouseOverContextMenu)
			{
				HideContextMenu();
			}
		}

		private void OnMapViewForgroundStateChanging(bool foreground)
		{
			HideContextMenu();
		}
	}
}
