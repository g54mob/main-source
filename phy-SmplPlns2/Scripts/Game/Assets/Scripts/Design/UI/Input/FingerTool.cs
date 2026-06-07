using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Parts;
using Assets.Scripts.UI;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design.UI.Input
{
	public class FingerTool
	{
		private List<FingerToolButtonScript> _buttons = new List<FingerToolButtonScript>();

		private DesignerScript _designer;

		private DesignerScreenInputScript _designerScreenInput;

		private Vector2 _dragStart;

		private bool _enabled = true;

		private Vector2 _grabDelta;

		private FingerToolButtonScript _movePartButton;

		private bool _partButtonsEnabled = true;

		private RectTransform _rect;

		private FingerToolButtonScript _selectedButton;

		private bool _supported;

		private Widget _widget;

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
					if (_widget != null)
					{
						_widget.Visible = value;
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

		public FingerTool(Widget widget, DesignerScript designer, DesignerScreenInputScript designerScreenInput)
		{
			_widget = widget;
			_designer = designer;
			_designerScreenInput = designerScreenInput;
			if (_widget != null)
			{
				_rect = _widget.GetComponent<RectTransform>();
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
				_designerScreenInput.FingerToolMode = button.Mode;
				eventData.position = _rect.position;
				_designerScreenInput.OnDrag(eventData);
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
			_designerScreenInput.FingerToolMode = button.Mode;
			eventData.position = _rect.position;
			_designerScreenInput.OnPointerDown(eventData);
		}

		public void OnPointerUp(FingerToolButtonScript button, PointerEventData eventData)
		{
			if (button.Mode != FingerToolMode.SelectPart)
			{
				eventData.position = _rect.position;
				_designerScreenInput.OnPointerUp(eventData);
				_designerScreenInput.FingerToolMode = FingerToolMode.None;
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
			Widget widget = _widget.FindWidget(fingerButtonId);
			FingerToolButtonScript fingerToolButtonScript = widget.gameObject.AddComponent<FingerToolButtonScript>();
			fingerToolButtonScript.Initialize(this, fingerToolMode, widget);
			_buttons.Add(fingerToolButtonScript);
			return fingerToolButtonScript;
		}

		private void SelectPartAtCurrentPosition()
		{
			PartScript partAtScreenPosition = _designer.GetPartAtScreenPosition(_rect.position);
			if (partAtScreenPosition != null && _designer.SelectedPart != partAtScreenPosition && _designer.Designer.Tools.SelectedTool.AllowPartSelection)
			{
				_designer.Designer.SelectedPart = partAtScreenPosition;
			}
			SetPartButtonsEnabled(partAtScreenPosition != null);
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
					button.Widget.Visible = enable;
				}
			}
		}
	}
}
