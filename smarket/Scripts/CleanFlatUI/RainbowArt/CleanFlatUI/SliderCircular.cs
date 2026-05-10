using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public class SliderCircular : UIBehaviour, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler, ICanvasElement, IPointerDownHandler
	{
		public enum FillOrigin
		{
			Top = 0,
			Right = 1,
			Bottom = 2,
			Left = 3
		}

		[Serializable]
		public class SliderCircularEvent : UnityEvent<float>
		{
		}

		[SerializeField]
		private FillOrigin fillOrigin;

		[SerializeField]
		private Image fillImage;

		[SerializeField]
		private RectTransform handleRect;

		[SerializeField]
		private RectTransform handleRootRect;

		[SerializeField]
		private bool clockwise;

		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue;

		[SerializeField]
		private bool wholeNumbers;

		[SerializeField]
		private float value;

		[SerializeField]
		private bool hasText;

		[SerializeField]
		private Text text;

		private Vector2 offset;

		private bool bDelayedUpdate;

		private RectTransform fillImageRect;

		[SerializeField]
		private SliderCircularEvent onValueChanged;

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

		public virtual float Value
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

		public bool Clockwise
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public FillOrigin CurFillOrigin
		{
			get
			{
				return default(FillOrigin);
			}
			set
			{
			}
		}

		public float NormalizedValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public SliderCircularEvent OnValueChanged
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

		public virtual void SetValueWithoutNotify(float input)
		{
		}

		protected SliderCircular()
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

		protected virtual void SetValue(float val, bool sendCallback = true)
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		private void UpdateGUI()
		{
		}

		private void UpdateText()
		{
		}

		private float GetAngleWithFillOrign(Vector2 pos)
		{
			return 0f;
		}

		private Vector2 GetOriginVector(FillOrigin origin)
		{
			return default(Vector2);
		}

		private void UpdateFillImageOrign()
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
	}
}
