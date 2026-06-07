using System;
using System.Collections.Generic;
using ModApi.Craft.Parts;
using ModApi.Design;
using ModApi.Input.Events;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design
{
	public class FingerTool : IFingerTool
	{
		private List<FingerToolButtonScript> _buttons = new List<FingerToolButtonScript>();

		private DesignerScript _designer;

		private DesignerWidgetScript _designerWidget;

		private Vector2 _dragStart;

		private XmlElement _element;

		private bool _enabled = true;

		private Vector2 _grabDelta;

		private FingerToolButtonScript _movePartButton;

		private bool _partButtonsEnabled = true;

		private RectTransform _rect;

		private FingerToolButtonScript _selectedButton;

		private bool _supported;

		public bool Enabled
		{
			get
			{
				if (_enabled)
				{
					return _supported;
				}
				return false;
			}
			set
			{
				if (_enabled != value && _supported)
				{
					_enabled = value;
					if (_element != null)
					{
						_element?.SetActive(value);
						this.OnEnabledChanged?.Invoke(this, new EventArgs());
						_rect.anchoredPosition = Vector2.zero;
					}
				}
			}
		}

		public bool PartButtonsEnabled => _partButtonsEnabled;

		public Vector2 Position
		{
			get
			{
				return _rect.position;
			}
			set
			{
				_rect.position = value;
			}
		}

		private bool IsDragging => _selectedButton != null;

		public event EventHandler OnEnabledChanged;

		public FingerTool(XmlElement element, IDesigner designer, DesignerWidgetScript designerWidget)
		{
			_element = element;
			_designer = designer as DesignerScript;
			_designerWidget = designerWidget;
			if (element != null)
			{
				_rect = _element.GetComponent<RectTransform>();
				_element.GetChildElementsWithClass("finger-button");
				InitializeButton("select-part", FingerToolMode.SelectPart);
				_movePartButton = InitializeButton("move-part", FingerToolMode.MovePart);
				InitializeButton("clone-part", FingerToolMode.ClonePart);
				InitializeButton("clone-group", FingerToolMode.CloneGroup);
				InitializeButton("detach-part", FingerToolMode.DetachPart);
				_supported = true;
				_enabled = true;
			}
			else
			{
				_supported = false;
				_enabled = false;
			}
		}

		public void OnAddPartFinish(PointerEventData eventData)
		{
			OnPointerUp(_movePartButton, eventData);
		}

		public void OnAddPartMove(PointerEventData eventData)
		{
			OnDrag(_movePartButton, eventData);
		}

		public void OnAddPartStart(DesignerPart part, PointerEventData eventData)
		{
			SetPartButtonsEnabled(enable: true);
			Vector2 vector = eventData.position - (Vector2)_movePartButton.transform.position;
			_rect.position += (Vector3)vector;
			_designer.AddPart(part, _rect.position);
			Vector2 position = eventData.position;
			OnPointerDown(_movePartButton, eventData);
			eventData.position = position;
			OnBeginDrag(_movePartButton, eventData);
		}

		public void OnBeginDrag(FingerToolButtonScript button, PointerEventData eventData)
		{
			Vector2 position = eventData.position;
			_grabDelta = new Vector2(_rect.position.x, _rect.position.y) - eventData.position;
			_dragStart = position + _grabDelta;
		}

		public void OnDrag(FingerToolButtonScript button, PointerEventData eventData)
		{
			_rect.position = eventData.position + _grabDelta;
			if (button.Mode == FingerToolMode.SelectPart)
			{
				SelectPartAtCurrentPosition();
			}
			else
			{
				_designerWidget.FingerToolMode = button.Mode;
				eventData.position = _rect.position;
				_designerWidget.OnDrag(eventData);
			}
			ClampTransformToScreen(_rect);
			ClampTransformToScreen(_movePartButton.transform);
		}

		public void OnPointerDown(FingerToolButtonScript button, PointerEventData eventData)
		{
			_selectedButton = button;
			_selectedButton.Selected = true;
			if (button.Mode == FingerToolMode.SelectPart)
			{
				SelectPartAtCurrentPosition();
				return;
			}
			_designerWidget.FingerToolMode = button.Mode;
			eventData.position = _rect.position;
			_designerWidget.OnPointerDown(eventData);
		}

		public void OnPointerUp(FingerToolButtonScript button, PointerEventData eventData)
		{
			if (button.Mode != FingerToolMode.SelectPart)
			{
				eventData.position = _rect.position;
				_designerWidget.OnPointerUp(eventData);
				_designerWidget.FingerToolMode = FingerToolMode.None;
			}
			if (_selectedButton != null)
			{
				_selectedButton.Selected = false;
				_selectedButton = null;
			}
		}

		public void ResetToDragStart()
		{
			_rect.position = _dragStart;
		}

		private void ClampTransformToScreen(Transform transform)
		{
			Vector3 position = transform.position;
			position.x = Mathf.Clamp(position.x, 5f, (float)Screen.width - 5f);
			position.y = Mathf.Clamp(position.y, 5f, (float)Screen.height - 5f);
			Vector3 vector = position - transform.position;
			_rect.transform.position += vector;
		}

		private FingerToolButtonScript InitializeButton(string fingerButtonId, FingerToolMode fingerToolMode)
		{
			XmlElement elementByInternalId = _element.GetElementByInternalId(fingerButtonId);
			FingerToolButtonScript fingerToolButtonScript = elementByInternalId.gameObject.AddComponent<FingerToolButtonScript>();
			fingerToolButtonScript.Initialize(this, fingerToolMode, elementByInternalId);
			_buttons.Add(fingerToolButtonScript);
			return fingerToolButtonScript;
		}

		private void SelectPartAtCurrentPosition()
		{
			PartRaycastResult partAtScreenPosition = _designer.GetPartAtScreenPosition(_rect.position);
			if (partAtScreenPosition.PartScript != null && _designer.SelectedPart != partAtScreenPosition.PartScript && _designer.AllowPartSelection)
			{
				_designer.SelectPart(partAtScreenPosition.PartScript, null, justAdded: false);
			}
			SetPartButtonsEnabled(partAtScreenPosition.PartScript != null);
		}

		private void SetPartButtonsEnabled(bool enable)
		{
			if (_partButtonsEnabled == enable)
			{
				return;
			}
			_partButtonsEnabled = enable;
			foreach (FingerToolButtonScript button in _buttons)
			{
				if (button.Mode != FingerToolMode.SelectPart)
				{
					button.Element.SetActive(enable);
				}
			}
		}
	}
}
