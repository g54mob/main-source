using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	public class SliderRangeTransition : UIBehaviour, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler, ICanvasElement, IPointerDownHandler
	{
		public enum AxisEnum
		{
			Horizontal = 0,
			Vertical = 1
		}

		[Serializable]
		public class RangedSliderTransitionEvent : UnityEvent<float>
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
		private float maxValue = 1f;

		[SerializeField]
		private bool wholeNumbers;

		[SerializeField]
		private float value1;

		[SerializeField]
		private float value2;

		[SerializeField]
		private bool hasText = true;

		[SerializeField]
		private TextMeshProUGUI text1;

		[SerializeField]
		private TextMeshProUGUI text2;

		[SerializeField]
		private Animator animatorHandle1;

		[SerializeField]
		private Animator animatorHandle2;

		private RectTransform fillContainerRect;

		private RectTransform handleContainerRect;

		private Vector2 offset = Vector2.zero;

		private bool bDelayedUpdate;

		private bool isDragingHandle1;

		[SerializeField]
		private RangedSliderTransitionEvent onValue1Changed = new RangedSliderTransitionEvent();

		[SerializeField]
		private RangedSliderTransitionEvent onValue2Changed = new RangedSliderTransitionEvent();

		public AxisEnum Axis
		{
			get
			{
				return axis;
			}
			set
			{
				if (axis != value)
				{
					SetDirection(value);
					UpdateGUI();
				}
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
				float num = value;
				if (wholeNumbers)
				{
					num = Mathf.Round(num);
				}
				if (num != minValue)
				{
					minValue = num;
					SetValue1(value1);
					UpdateGUI();
				}
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
				float num = value;
				if (wholeNumbers)
				{
					num = Mathf.Round(num);
				}
				if (num != maxValue)
				{
					maxValue = num;
					SetValue1(value1);
					UpdateGUI();
				}
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
				if (wholeNumbers != value)
				{
					wholeNumbers = value;
					SetValue1(value1);
					UpdateGUI();
				}
			}
		}

		public virtual float Value1
		{
			get
			{
				if (wholeNumbers)
				{
					return Mathf.Round(value1);
				}
				return value1;
			}
			set
			{
				SetValue1(value);
			}
		}

		public virtual float Value2
		{
			get
			{
				if (wholeNumbers)
				{
					return Mathf.Round(value2);
				}
				return value2;
			}
			set
			{
				SetValue2(value);
			}
		}

		public float NormalizedValue1
		{
			get
			{
				if (Mathf.Approximately(MinValue, MaxValue))
				{
					return 0f;
				}
				return Mathf.InverseLerp(MinValue, MaxValue, Value1);
			}
			set
			{
				Value1 = Mathf.Lerp(MinValue, MaxValue, value);
			}
		}

		public float NormalizedValue2
		{
			get
			{
				if (Mathf.Approximately(MinValue, MaxValue))
				{
					return 0f;
				}
				return Mathf.InverseLerp(MinValue, MaxValue, Value2);
			}
			set
			{
				Value2 = Mathf.Lerp(MinValue, MaxValue, value);
			}
		}

		public RangedSliderTransitionEvent OnValue1Changed
		{
			get
			{
				return onValue1Changed;
			}
			set
			{
				onValue1Changed = value;
			}
		}

		public RangedSliderTransitionEvent OnValue2Changed
		{
			get
			{
				return onValue2Changed;
			}
			set
			{
				onValue2Changed = value;
			}
		}

		public bool HasText
		{
			get
			{
				return hasText;
			}
			set
			{
				hasText = value;
				UpdateText();
			}
		}

		Transform ICanvasElement.transform => base.transform;

		public virtual void SetValue1WithoutNotify(float input)
		{
			SetValue1(input, sendCallback: false);
		}

		public virtual void SetValue2WithoutNotify(float input)
		{
			SetValue2(input, sendCallback: false);
		}

		protected SliderRangeTransition()
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
			base.OnEnable();
			fillContainerRect = fillRect.parent.GetComponent<RectTransform>();
			handleContainerRect = handle1Rect.parent.GetComponent<RectTransform>();
			SetValue1(value1, sendCallback: false);
			SetValue2(value2, sendCallback: false);
			UpdateGUI();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
		}

		protected virtual void Update()
		{
			if (bDelayedUpdate)
			{
				bDelayedUpdate = false;
				SetValue1(value1, sendCallback: false);
				SetValue2(value2, sendCallback: false);
				UpdateGUI();
			}
		}

		protected override void OnDidApplyAnimationProperties()
		{
			if (IsActive())
			{
				SetValue1(value1, sendCallback: false);
				SetValue2(value2, sendCallback: false);
				UpdateGUI();
			}
		}

		protected virtual void SetValue1(float val, bool sendCallback = true)
		{
			float num = val;
			if (num > value2)
			{
				num = value2;
			}
			num = Mathf.Clamp(num, MinValue, MaxValue);
			if (wholeNumbers)
			{
				num = Mathf.Round(num);
			}
			if (value1 != num)
			{
				value1 = num;
				UpdateGUI();
				if (sendCallback)
				{
					onValue1Changed.Invoke(num);
				}
			}
		}

		protected virtual void SetValue2(float val, bool sendCallback = true)
		{
			float num = val;
			if (num < value1)
			{
				num = value1;
			}
			num = Mathf.Clamp(num, MinValue, MaxValue);
			if (wholeNumbers)
			{
				num = Mathf.Round(num);
			}
			if (value2 != num)
			{
				value2 = num;
				UpdateGUI();
				if (sendCallback)
				{
					onValue2Changed.Invoke(num);
				}
			}
		}

		private void UpdateText()
		{
			if (text1 != null && text1.gameObject.activeSelf != hasText)
			{
				text1.gameObject.SetActive(hasText);
			}
			if (text2 != null && text2.gameObject.activeSelf != hasText)
			{
				text2.gameObject.SetActive(hasText);
			}
			if (hasText && text1 != null && text2 != null)
			{
				float num = (float)Math.Round(value1, 1);
				text1.text = num.ToString() ?? "";
				float num2 = (float)Math.Round(value2, 1);
				text2.text = num2.ToString() ?? "";
			}
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			if (IsActive())
			{
				UpdateGUI();
			}
		}

		private void UpdateGUI()
		{
			if (fillContainerRect != null)
			{
				Vector2 zero = Vector2.zero;
				Vector2 one = Vector2.one;
				zero[(int)Axis] = NormalizedValue1;
				one[(int)Axis] = NormalizedValue2;
				fillRect.anchorMin = zero;
				fillRect.anchorMax = one;
			}
			if (handleContainerRect != null)
			{
				Vector2 zero2 = Vector2.zero;
				Vector2 one2 = Vector2.one;
				AxisEnum index = Axis;
				float value = (one2[(int)Axis] = NormalizedValue1);
				zero2[(int)index] = value;
				handle1Rect.anchorMin = zero2;
				handle1Rect.anchorMax = one2;
				zero2 = Vector2.zero;
				one2 = Vector2.one;
				AxisEnum index2 = Axis;
				value = (one2[(int)Axis] = NormalizedValue2);
				zero2[(int)index2] = value;
				handle2Rect.anchorMin = zero2;
				handle2Rect.anchorMax = one2;
			}
			UpdateText();
		}

		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
			RectTransform rectTransform = handleContainerRect ?? fillContainerRect;
			if (!(rectTransform != null) || !(rectTransform.rect.size[(int)Axis] > 0f))
			{
				return;
			}
			Vector2 position = eventData.position;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, position, cam, out var localPoint))
			{
				localPoint -= rectTransform.rect.position;
				float num = Mathf.Clamp01((localPoint - offset)[(int)Axis] / rectTransform.rect.size[(int)Axis]);
				if (isDragingHandle1)
				{
					NormalizedValue1 = num;
					PlayAnimation(animatorHandle1);
				}
				else
				{
					NormalizedValue2 = num;
					PlayAnimation(animatorHandle2);
				}
			}
		}

		private bool MayDrag(PointerEventData eventData)
		{
			if (IsActive())
			{
				return eventData.button == PointerEventData.InputButton.Left;
			}
			return false;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (!MayDrag(eventData))
			{
				return;
			}
			offset = Vector2.zero;
			if (RectTransformUtility.RectangleContainsScreenPoint(handle2Rect, eventData.pointerPressRaycast.screenPosition, eventData.enterEventCamera))
			{
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(handle2Rect, eventData.pointerPressRaycast.screenPosition, eventData.pressEventCamera, out var localPoint))
				{
					offset = localPoint;
				}
				isDragingHandle1 = false;
				PlayAnimation(animatorHandle2);
				return;
			}
			if (RectTransformUtility.RectangleContainsScreenPoint(handle1Rect, eventData.pointerPressRaycast.screenPosition, eventData.enterEventCamera))
			{
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(handle1Rect, eventData.pointerPressRaycast.screenPosition, eventData.pressEventCamera, out var localPoint2))
				{
					offset = localPoint2;
				}
				isDragingHandle1 = true;
				PlayAnimation(animatorHandle1);
				return;
			}
			RectTransform rectTransform = handleContainerRect;
			if (!(rectTransform != null) || !(rectTransform.rect.size[(int)Axis] > 0f))
			{
				return;
			}
			Vector2 position = eventData.position;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, position, eventData.pressEventCamera, out var localPoint3))
			{
				localPoint3 -= rectTransform.rect.position;
				float num = Mathf.Clamp01((localPoint3 - offset)[(int)Axis] / rectTransform.rect.size[(int)Axis]);
				if (Mathf.Abs(num - NormalizedValue1) <= Mathf.Abs(num - NormalizedValue2))
				{
					NormalizedValue1 = num;
					PlayAnimation(animatorHandle1);
				}
				else
				{
					NormalizedValue2 = num;
					PlayAnimation(animatorHandle2);
				}
			}
		}

		public virtual void OnDrag(PointerEventData eventData)
		{
			if (MayDrag(eventData))
			{
				UpdateDrag(eventData, eventData.pressEventCamera);
			}
		}

		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
			eventData.useDragThreshold = true;
		}

		public void SetDirection(AxisEnum direction)
		{
			AxisEnum axisEnum = axis;
			axis = direction;
			if (axis != axisEnum)
			{
				RectTransformUtility.FlipLayoutAxes(base.transform as RectTransform, keepPositioning: true, recursive: true);
			}
		}

		public void PlayAnimation(Animator animatorHandle)
		{
			if (animatorHandle != null)
			{
				animatorHandle.Play("Transition", 0, 0f);
			}
		}
	}
}
