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
		private bool clockwise = true;

		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue = 1f;

		[SerializeField]
		private bool wholeNumbers;

		[SerializeField]
		private float value;

		[SerializeField]
		private bool hasText = true;

		[SerializeField]
		private TextMeshProUGUI text;

		private Vector2 offset = Vector2.zero;

		private bool bDelayedUpdate;

		private RectTransform fillImageRect;

		[SerializeField]
		private SliderCircularEvent onValueChanged = new SliderCircularEvent();

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
					SetValue(this.value);
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
					SetValue(this.value);
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
					SetValue(this.value);
					UpdateGUI();
				}
			}
		}

		public virtual float Value
		{
			get
			{
				if (wholeNumbers)
				{
					return Mathf.Round(value);
				}
				return value;
			}
			set
			{
				SetValue(value);
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

		public bool Clockwise
		{
			get
			{
				return clockwise;
			}
			set
			{
				if (clockwise != value)
				{
					clockwise = value;
					UpdateGUI();
				}
			}
		}

		public FillOrigin CurFillOrigin
		{
			get
			{
				return fillOrigin;
			}
			set
			{
				if (fillOrigin != value)
				{
					fillOrigin = value;
					UpdateGUI();
				}
			}
		}

		public float NormalizedValue
		{
			get
			{
				if (Mathf.Approximately(MinValue, MaxValue))
				{
					return 0f;
				}
				return Mathf.InverseLerp(MinValue, MaxValue, Value);
			}
			set
			{
				Value = Mathf.Lerp(MinValue, MaxValue, value);
			}
		}

		public SliderCircularEvent OnValueChanged
		{
			get
			{
				return onValueChanged;
			}
			set
			{
				onValueChanged = value;
			}
		}

		Transform ICanvasElement.transform => base.transform;

		public virtual void SetValueWithoutNotify(float input)
		{
			SetValue(input, sendCallback: false);
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
			base.OnEnable();
			fillImageRect = fillImage.GetComponent<RectTransform>();
			UpdateFillImageOrign();
			SetValue(value, sendCallback: false);
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
				UpdateFillImageOrign();
				SetValue(value, sendCallback: false);
				UpdateGUI();
			}
		}

		protected override void OnDidApplyAnimationProperties()
		{
			if (IsActive())
			{
				SetValue(value, sendCallback: false);
				UpdateGUI();
			}
		}

		protected virtual void SetValue(float val, bool sendCallback = true)
		{
			float num = val;
			num = Mathf.Clamp(num, MinValue, MaxValue);
			if (wholeNumbers)
			{
				num = Mathf.Round(num);
			}
			if (value != num)
			{
				value = num;
				UpdateGUI();
				if (sendCallback)
				{
					onValueChanged.Invoke(num);
				}
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
			float normalizedValue = NormalizedValue;
			fillImage.fillAmount = normalizedValue;
			if (clockwise)
			{
				float z = (0f - normalizedValue) * 360f - (float)((int)fillOrigin * 90);
				handleRootRect.localEulerAngles = new Vector3(0f, 0f, z);
			}
			else
			{
				float z2 = normalizedValue * 360f - (float)((int)fillOrigin * 90);
				handleRootRect.localEulerAngles = new Vector3(0f, 0f, z2);
			}
			UpdateText();
		}

		private void UpdateText()
		{
			if (text != null && text.gameObject.activeSelf != hasText)
			{
				text.gameObject.SetActive(hasText);
			}
			if (hasText && text != null)
			{
				float num = (float)Math.Round(value, 1);
				text.text = num.ToString() ?? "";
			}
		}

		private float GetAngleWithFillOrign(Vector2 pos)
		{
			Vector2 originVector = GetOriginVector(fillOrigin);
			if (clockwise)
			{
				float num = Vector2.SignedAngle(originVector, pos);
				if (num > 0f)
				{
					return 360f - num;
				}
				return 0f - num;
			}
			float num2 = Vector2.SignedAngle(originVector, pos);
			if (num2 > 0f)
			{
				return num2;
			}
			return 360f + num2;
		}

		private Vector2 GetOriginVector(FillOrigin origin)
		{
			return origin switch
			{
				FillOrigin.Top => new Vector2(0f, 1f), 
				FillOrigin.Bottom => new Vector2(0f, -1f), 
				FillOrigin.Left => new Vector2(-1f, 0f), 
				FillOrigin.Right => new Vector2(1f, 0f), 
				_ => Vector2.zero, 
			};
		}

		private void UpdateFillImageOrign()
		{
			if (fillOrigin == FillOrigin.Top)
			{
				fillImage.fillOrigin = 2;
			}
			else if (fillOrigin == FillOrigin.Bottom)
			{
				fillImage.fillOrigin = 0;
			}
			else if (fillOrigin == FillOrigin.Left)
			{
				fillImage.fillOrigin = 3;
			}
			else if (fillOrigin == FillOrigin.Right)
			{
				fillImage.fillOrigin = 1;
			}
			fillImage.fillClockwise = clockwise;
		}

		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
			_ = fillImageRect;
			Vector2 position = eventData.position;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(fillImageRect, position, cam, out var localPoint))
			{
				float normalizedValue = GetAngleWithFillOrign(localPoint) / 360f;
				NormalizedValue = normalizedValue;
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
			if (RectTransformUtility.RectangleContainsScreenPoint(handleRect, eventData.pointerPressRaycast.screenPosition, eventData.enterEventCamera))
			{
				if (RectTransformUtility.ScreenPointToLocalPointInRectangle(handleRect, eventData.pointerPressRaycast.screenPosition, eventData.pressEventCamera, out var localPoint))
				{
					offset = localPoint;
				}
				return;
			}
			_ = fillImageRect;
			Vector2 position = eventData.position;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(fillImageRect, position, eventData.pressEventCamera, out var localPoint2))
			{
				float normalizedValue = GetAngleWithFillOrign(localPoint2) / 360f;
				NormalizedValue = normalizedValue;
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
	}
}
