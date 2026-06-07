using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace HSVPicker
{
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("UI/BoxSlider", 35)]
	public class BoxSlider : Selectable, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler, ICanvasElement
	{
		public enum Direction
		{
			LeftToRight = 0,
			RightToLeft = 1,
			BottomToTop = 2,
			TopToBottom = 3
		}

		[Serializable]
		public class BoxSliderEvent : UnityEvent<float, float>
		{
		}

		private enum Axis
		{
			Horizontal = 0,
			Vertical = 1
		}

		[SerializeField]
		private RectTransform m_HandleRect;

		[Space(6f)]
		[SerializeField]
		private float m_MinValue;

		[SerializeField]
		private float m_MaxValue;

		[SerializeField]
		private bool m_WholeNumbers;

		[SerializeField]
		private float m_Value;

		[SerializeField]
		private float m_ValueY;

		[Space(6f)]
		[SerializeField]
		private BoxSliderEvent m_OnValueChanged;

		private Transform m_HandleTransform;

		private RectTransform m_HandleContainerRect;

		private Vector2 m_Offset;

		private DrivenRectTransformTracker m_Tracker;

		public RectTransform handleRect
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public float minValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float maxValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool wholeNumbers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

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

		public float normalizedValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float valueY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float normalizedValueY
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public BoxSliderEvent onValueChanged
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private float stepSize => 0f;

		Transform ICanvasElement.transform => null;

		protected BoxSlider()
		{
		}

		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		public void LayoutComplete()
		{
		}

		public void GraphicUpdateComplete()
		{
		}

		public static bool SetClass<T>(ref T currentValue, T newValue) where T : class
		{
			return false;
		}

		public static bool SetStruct<T>(ref T currentValue, T newValue) where T : struct
		{
			return false;
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		private void UpdateCachedReferences()
		{
		}

		private void Set(float input)
		{
		}

		private void Set(float input, bool sendCallback)
		{
		}

		private void SetY(float input)
		{
		}

		private void SetY(float input, bool sendCallback)
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		private void UpdateVisuals()
		{
		}

		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
		}

		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}
	}
}
