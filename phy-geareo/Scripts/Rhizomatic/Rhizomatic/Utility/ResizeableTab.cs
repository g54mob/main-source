using UnityEngine;
using UnityEngine.EventSystems;

namespace Rhizomatic.Utility
{
	public class ResizeableTab : MonoBehaviour, IDragHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler
	{
		public enum Mode
		{
			Horizontal = 0,
			Vertical = 1
		}

		public Canvas canvas;

		public RectTransform rect;

		public Mode mode;

		public float smooth;

		public float speed;

		public float _value;

		public float minValue;

		public float maxValue;

		public float[] grids;

		private bool isDragging;

		private Vector2 startValue;

		private float onDown;

		private Vector2 startPos;

		private float clickTime;

		private float clickRadius;

		public float value
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void LateUpdate()
		{
		}

		public virtual void OnDrag(PointerEventData e)
		{
		}

		public virtual void OnPointerDown(PointerEventData e)
		{
		}

		public virtual void OnPointerUp(PointerEventData e)
		{
		}

		public void Snap()
		{
		}
	}
}
