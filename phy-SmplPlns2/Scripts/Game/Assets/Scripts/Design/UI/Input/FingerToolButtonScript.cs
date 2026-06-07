using Assets.Scripts.UI;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design.UI.Input
{
	public class FingerToolButtonScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
	{
		private FingerTool _fingerTool;

		private bool _selected;

		public FingerToolMode Mode { get; private set; }

		public bool Selected
		{
			get
			{
				return _selected;
			}
			set
			{
				if (_selected != value)
				{
					_selected = value;
					if (value)
					{
						Widget.AddClass("finger-button-selected");
					}
					else
					{
						Widget.RemoveClass("finger-button-selected");
					}
				}
			}
		}

		public Widget Widget { get; private set; }

		public void Initialize(FingerTool fingerTool, FingerToolMode fingerToolMode, Widget widget)
		{
			_fingerTool = fingerTool;
			Mode = fingerToolMode;
			Widget = widget;
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
			_fingerTool.OnBeginDrag(this, eventData);
		}

		public void OnDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
			_fingerTool.OnDrag(this, eventData);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			_fingerTool.OnPointerDown(this, eventData);
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_fingerTool.OnPointerUp(this, eventData);
		}
	}
}
