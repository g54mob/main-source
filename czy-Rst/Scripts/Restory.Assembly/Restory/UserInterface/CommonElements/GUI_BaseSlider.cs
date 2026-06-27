using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Restory.UserInterface.CommonElements
{
	[RequireComponent(typeof(RectTransform))]
	public class GUI_BaseSlider : GUI_Selectable, IMoveHandler, IEventSystemHandler, IDragHandler, IInitializePotentialDragHandler
	{
		public enum Axis
		{
			Horizontal = 0,
			Vertical = 1
		}

		public enum Direction
		{
			LeftToRight = 0,
			RightToLeft = 1,
			BottomToTop = 2,
			TopToBottom = 3
		}

		[Serializable]
		public class SliderEvent : UnityEvent<float>
		{
		}

		[SerializeField]
		private RectTransform fillRect;

		[SerializeField]
		private RectTransform handleRect;

		[Space]
		[SerializeField]
		private Direction direction;

		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue = 1f;

		[SerializeField]
		private bool wholeNumbers;

		[SerializeField]
		private float value = 1f;

		[Space]
		[SerializeField]
		private bool autoSizeStep = true;

		[SerializeField]
		private float stepSize = 1f;

		[Space]
		[SerializeField]
		private SliderEvent onValueChanged = new SliderEvent();

		private Image fillImage;

		private Transform fillTransform;

		private RectTransform fillContainerRect;

		private Transform handleTransform;

		private RectTransform handleContainerRect;

		private Vector2 offset = Vector2.zero;

		private DrivenRectTransformTracker tracker;

		public RectTransform FillRect
		{
			get
			{
				return fillRect;
			}
			set
			{
				fillRect = value;
				UpdateCachedReferences();
				UpdateVisuals();
			}
		}

		public RectTransform HandleRect
		{
			get
			{
				return handleRect;
			}
			set
			{
				handleRect = value;
				UpdateCachedReferences();
				UpdateVisuals();
			}
		}

		public Direction CurDirection
		{
			get
			{
				return direction;
			}
			set
			{
				direction = value;
				UpdateVisuals();
			}
		}

		public float MinValue
		{
			get
			{
				return minValue;
			}
			set
			{
				minValue = value;
				SetValue(this.value);
			}
		}

		public float MaxValue
		{
			get
			{
				return maxValue;
			}
			set
			{
				maxValue = value;
				SetValue(this.value);
			}
		}

		public bool WholeNumbers
		{
			get
			{
				return wholeNumbers;
			}
			set
			{
				wholeNumbers = value;
				SetValue(this.value);
			}
		}

		public float Value
		{
			get
			{
				if (!WholeNumbers)
				{
					return value;
				}
				return Mathf.Round(value);
			}
			set
			{
				SetValue(value);
			}
		}

		public float NormalizedValue
		{
			get
			{
				if (!Mathf.Approximately(MinValue, MaxValue))
				{
					return Mathf.InverseLerp(MinValue, MaxValue, Value);
				}
				return 0f;
			}
			set
			{
				Value = Mathf.Lerp(MinValue, MaxValue, value);
			}
		}

		public Axis CurrentAxis
		{
			get
			{
				if (direction != Direction.LeftToRight && direction != Direction.RightToLeft)
				{
					return Axis.Vertical;
				}
				return Axis.Horizontal;
			}
		}

		public bool IsReverseValue
		{
			get
			{
				if (direction != Direction.RightToLeft)
				{
					return direction == Direction.TopToBottom;
				}
				return true;
			}
		}

		public bool AutoSizeStep
		{
			get
			{
				return autoSizeStep;
			}
			set
			{
				autoSizeStep = value;
			}
		}

		public float StepSize
		{
			get
			{
				if (!WholeNumbers)
				{
					if (!autoSizeStep)
					{
						return stepSize;
					}
					return (MaxValue - MinValue) * 0.1f;
				}
				return 1f;
			}
			set
			{
				stepSize = value;
			}
		}

		public event UnityAction<float> OnValueChanged
		{
			add
			{
				onValueChanged.AddListener(value);
			}
			remove
			{
				onValueChanged.RemoveListener(value);
			}
		}

		private void VisualsValidate()
		{
			UpdateCachedReferences();
			UpdateVisuals();
		}

		private void ValueValidate()
		{
			SetValue(value, sendCallback: false);
			UpdateVisuals();
		}

		private void MinMaxValueValidate()
		{
			WholeNumbersValidate();
		}

		private void WholeNumbersValidate()
		{
			if (WholeNumbers)
			{
				minValue = Mathf.Round(minValue);
				maxValue = Mathf.Round(maxValue);
			}
			UpdateVisuals();
		}

		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			UpdateCachedReferences();
			SetValue(value, sendCallback: false);
			UpdateVisuals();
		}

		protected override void OnDisable()
		{
			tracker.Clear();
			base.OnDisable();
		}

		protected virtual void UpdateCachedReferences()
		{
			if ((bool)fillRect)
			{
				fillTransform = fillRect.transform;
				fillImage = fillRect.GetComponent<Image>();
				if (fillTransform.parent != null)
				{
					fillContainerRect = fillTransform.parent.GetComponent<RectTransform>();
				}
			}
			else
			{
				fillContainerRect = null;
				fillImage = null;
			}
			if ((bool)handleRect)
			{
				handleTransform = handleRect.transform;
				if (handleTransform.parent != null)
				{
					handleContainerRect = handleTransform.parent.GetComponent<RectTransform>();
				}
			}
			else
			{
				handleContainerRect = null;
			}
		}

		public void SetValueWithoutNotify(float value)
		{
			SetValue(value, sendCallback: false);
		}

		protected virtual void SetValue(float input, bool sendCallback = true)
		{
			float num = Mathf.Clamp(input, MinValue, MaxValue);
			if (WholeNumbers)
			{
				num = Mathf.Round(num);
			}
			if (value != num)
			{
				value = num;
				UpdateVisuals();
				if (sendCallback)
				{
					onValueChanged.Invoke(num);
				}
			}
		}

		public void SetDirection(Direction direction, bool includeRectLayouts)
		{
			Axis currentAxis = CurrentAxis;
			bool isReverseValue = IsReverseValue;
			CurDirection = direction;
			if (includeRectLayouts)
			{
				if (CurrentAxis != currentAxis)
				{
					RectTransformUtility.FlipLayoutAxes(base.transform as RectTransform, keepPositioning: true, recursive: true);
				}
				if (IsReverseValue != isReverseValue)
				{
					RectTransformUtility.FlipLayoutOnAxis(base.transform as RectTransform, (int)CurrentAxis, keepPositioning: true, recursive: true);
				}
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			UpdateVisuals();
		}

		protected virtual void UpdateVisuals()
		{
			tracker.Clear();
			if (fillContainerRect != null)
			{
				tracker.Add(this, fillRect, DrivenTransformProperties.Anchors);
				Vector2 zero = Vector2.zero;
				Vector2 one = Vector2.one;
				if (fillImage != null && fillImage.type == Image.Type.Filled)
				{
					fillImage.fillAmount = NormalizedValue;
				}
				else if (IsReverseValue)
				{
					zero[(int)CurrentAxis] = 1f - NormalizedValue;
				}
				else
				{
					one[(int)CurrentAxis] = NormalizedValue;
				}
				fillRect.anchorMin = zero;
				fillRect.anchorMax = one;
			}
			if (handleContainerRect != null)
			{
				tracker.Add(this, handleRect, DrivenTransformProperties.Anchors);
				Vector2 zero2 = Vector2.zero;
				Vector2 one2 = Vector2.one;
				Axis currentAxis = CurrentAxis;
				float num = (one2[(int)CurrentAxis] = (IsReverseValue ? (1f - NormalizedValue) : NormalizedValue));
				zero2[(int)currentAxis] = num;
				handleRect.anchorMin = zero2;
				handleRect.anchorMax = one2;
			}
		}

		protected virtual void UpdateDrag(PointerEventData eventData, Camera cam)
		{
			RectTransform rectTransform = handleContainerRect ?? fillContainerRect;
			if (rectTransform != null && rectTransform.rect.size[(int)CurrentAxis] > 0f && RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, eventData.position, cam, out var localPoint))
			{
				localPoint -= rectTransform.rect.position;
				float num = Mathf.Clamp01((localPoint - offset)[(int)CurrentAxis] / rectTransform.rect.size[(int)CurrentAxis]);
				NormalizedValue = (IsReverseValue ? (1f - num) : num);
			}
		}

		protected virtual bool CanDrag(PointerEventData eventData)
		{
			if (IsActive() && IsInteractable())
			{
				return eventData.button == PointerEventData.InputButton.Left;
			}
			return false;
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			if (!CanDrag(eventData))
			{
				return;
			}
			base.OnPointerDown(eventData);
			offset = Vector2.zero;
			if (handleContainerRect != null && RectTransformUtility.RectangleContainsScreenPoint(handleRect, eventData.position, eventData.enterEventCamera))
			{
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(handleRect, eventData.position, eventData.pressEventCamera, out var localPoint))
				{
					offset = localPoint;
				}
			}
			else
			{
				UpdateDrag(eventData, eventData.pressEventCamera);
			}
		}

		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = false;
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if (CanDrag(eventData))
			{
				UpdateDrag(eventData, eventData.pressEventCamera);
			}
		}

		public virtual void OnMove(AxisEventData eventData)
		{
			if (!IsActive() || !IsInteractable())
			{
				return;
			}
			switch (CurrentAxis)
			{
			case Axis.Horizontal:
				switch (eventData.moveDir)
				{
				case MoveDirection.Left:
					SetValue(IsReverseValue ? (Value + StepSize) : (Value - StepSize));
					break;
				case MoveDirection.Right:
					SetValue(IsReverseValue ? (Value - StepSize) : (Value + StepSize));
					break;
				}
				break;
			case Axis.Vertical:
				switch (eventData.moveDir)
				{
				case MoveDirection.Up:
					SetValue(IsReverseValue ? (Value - StepSize) : (Value + StepSize));
					break;
				case MoveDirection.Down:
					SetValue(IsReverseValue ? (Value + StepSize) : (Value - StepSize));
					break;
				}
				break;
			}
		}
	}
}
