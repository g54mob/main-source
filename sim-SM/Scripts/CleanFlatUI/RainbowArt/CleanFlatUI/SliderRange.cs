using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public class SliderRange : UIBehaviour, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler, ICanvasElement, IPointerDownHandler
	{
		public enum AxisEnum
		{
			Horizontal = 0,
			Vertical = 1
		}

		[Serializable]
		public class RangedSliderEvent : UnityEvent<float>
		{
		}

		[SerializeField]
		private RectTransform fillRect;

		[SerializeField]
		private RectTransform handle1Rect;

		[SerializeField]
		private RectTransform handle2Rect;

		[SerializeField]
		private AxisEnum axis;

		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue;

		[SerializeField]
		private bool wholeNumbers;

		[SerializeField]
		private float value1;

		[SerializeField]
		private float value2;

		[SerializeField]
		private bool hasText;

		[SerializeField]
		private Text text1;

		[SerializeField]
		private Text text2;

		private RectTransform fillContainerRect;

		private RectTransform handleContainerRect;

		private Vector2 offset;

		private bool bDelayedUpdate;

		private bool isDragingHandle1;

		[SerializeField]
		private RangedSliderEvent onValue1Changed;

		[SerializeField]
		private RangedSliderEvent onValue2Changed;

		public AxisEnum Axis
		{
			get
			{
				return default(AxisEnum);
			}
			set
			{
			}
		}

		public float MinValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MaxValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool WholeNumbers
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual float Value1
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public virtual float Value2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool HasText
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float NormalizedValue1
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float NormalizedValue2
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public RangedSliderEvent OnValue1Changed
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RangedSliderEvent OnValue2Changed
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		Transform ICanvasElement.transform => null;

		public virtual void SetValue1WithoutNotify(float input)
		{
		}

		public virtual void SetValue2WithoutNotify(float input)
		{
		}

		protected SliderRange()
		{
		}

		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		public virtual void LayoutComplete()
		{
		}

		public virtual void GraphicUpdateComplete()
		{
		}

		protected override void OnEnable()
		{
		}

		protected override void OnDisable()
		{
		}

		protected virtual void Update()
		{
		}

		protected override void OnDidApplyAnimationProperties()
		{
		}

		protected virtual void SetValue1(float val, bool sendCallback = true)
		{
		}

		protected virtual void SetValue2(float val, bool sendCallback = true)
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		private void UpdateText()
		{
		}

		private void UpdateGUI()
		{
		}

		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
		}

		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		public void SetDirection(AxisEnum direction, bool includeRectLayouts)
		{
		}
	}
}
