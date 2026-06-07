using ModApi.Input.Events;
using UI.Xml;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Design
{
	public class FingerToolButtonScript : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler
	{
		private FingerTool _fingerTool;

		private bool _selected;

		public XmlElement Element { get; private set; }

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
						Element.AddClass("finger-button-selected");
					}
					else
					{
						Element.RemoveClass("finger-button-selected");
					}
				}
			}
		}

		public void Initialize(FingerTool fingerTool, FingerToolMode fingerToolMode, XmlElement element)
		{
			_fingerTool = fingerTool;
			Mode = fingerToolMode;
			Element = element;
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
