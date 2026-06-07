using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui.GradientEditor
{
	public class GradientHandleTrackScript : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler, IPointerClickHandler
	{
		[SerializeField]
		private RectTransform _referenceRect;

		[SerializeField]
		private float _selectionDistance = 20f;

		[SerializeField]
		private bool _isAlpha;

		private GradientEditorScript _parent;

		private RectTransform _rectTransform;

		private GradientEditorHandleScript _dragging;

		public List<GradientEditorHandleScript> Handles { get; set; }

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (Handles == null || !MouseInBounds(eventData, out var time))
			{
				return;
			}
			float num = _selectionDistance / _referenceRect.rect.width;
			_dragging = null;
			foreach (GradientEditorHandleScript handle in Handles)
			{
				if (handle.Active)
				{
					float num2 = Mathf.Abs(handle.Position - time);
					if (num2 < num)
					{
						num = num2;
						_dragging = handle;
						handle.Reserved = true;
					}
				}
			}
			if (_dragging == null)
			{
				if (Handles.Count >= 8 && Handles.All((GradientEditorHandleScript x) => x.Active))
				{
					_dragging = null;
					Game.Instance.UserInterface.CreateErrorDialog("Gradients in Unity do not support more than 8 " + (_isAlpha ? "alpha" : "color") + " keys.");
				}
				else
				{
					Color col = _parent.Gradient.Evaluate(time);
					if (_isAlpha)
					{
						_dragging = _parent.AddHandle(new GradientAlphaKey(col.a, time));
					}
					else
					{
						col.a = 1f;
						_dragging = _parent.AddHandle(new GradientColorKey(col, time));
					}
					if (_dragging != null)
					{
						_dragging.Reserved = true;
					}
				}
			}
			_parent.SetSelectedHandle(_dragging, _isAlpha);
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (_dragging != null)
			{
				if (MouseInBounds(eventData, out var time))
				{
					_dragging.Position = Mathf.Clamp01(time);
					_dragging.Reserved = true;
					_dragging.Active = true;
				}
				else
				{
					_dragging.Reserved = true;
					_dragging.Active = false;
				}
				_parent.Redraw();
			}
			_parent.SetSelectedHandle(_dragging, _isAlpha);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (!(_dragging != null))
			{
				return;
			}
			if (MouseInBounds(eventData, out var time))
			{
				_dragging.Position = Mathf.Clamp01(time);
				foreach (GradientEditorHandleScript handle in Handles)
				{
					if (handle != _dragging && handle.Position == _dragging.Position)
					{
						handle.Reserved = false;
						handle.Active = false;
					}
				}
			}
			else
			{
				_dragging.Active = false;
			}
			_parent.SetSelectedHandle(_dragging.Active ? _dragging : null, _isAlpha);
			_dragging.Reserved = false;
			_dragging = null;
			_parent.Redraw();
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			OnBeginDrag(eventData);
			OnEndDrag(eventData);
		}

		private void Awake()
		{
			_parent = GetComponentInParent<GradientEditorScript>();
			_rectTransform = GetComponent<RectTransform>();
		}

		private bool MouseInBounds(PointerEventData eventData, out float time)
		{
			time = 0f;
			if (!RectTransformUtility.RectangleContainsScreenPoint(_rectTransform, eventData.position, eventData.pressEventCamera))
			{
				return false;
			}
			RectTransformUtility.ScreenPointToLocalPointInRectangle(_referenceRect, eventData.position, eventData.pressEventCamera, out var localPoint);
			time = localPoint.x / _referenceRect.rect.width;
			return true;
		}
	}
}
