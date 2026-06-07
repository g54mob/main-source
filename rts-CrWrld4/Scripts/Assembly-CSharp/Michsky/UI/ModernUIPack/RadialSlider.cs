using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class RadialSlider : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IDragHandler
	{
		private const string PREFS_UI_SAVE_NAME = "Radial";

		[SerializeField]
		private Image sliderImage;

		[SerializeField]
		private Transform indicatorPivot;

		[SerializeField]
		private TextMeshProUGUI valueText;

		[SerializeField]
		private int sliderID;

		[SerializeField]
		private float maxValue;

		[SerializeField]
		private float currentValue;

		[SerializeField]
		private int decimals;

		[SerializeField]
		private bool isPercent;

		[SerializeField]
		private bool rememberValue;

		[SerializeField]
		private bool enableCurrentValue;

		[SerializeField]
		private UnityEvent onValueChanged;

		private GraphicRaycaster graphicRaycaster;

		private RectTransform hitRectTransform;

		private bool isPointerDown;

		private float currentAngle;

		private float currentAngleOnPointerDown;

		private float valueDisplayPrecision;

		public float SliderAngle
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SliderValue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float SliderValueRaw
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void LoadState()
		{
		}

		public void SaveState()
		{
		}

		public void UpdateUI()
		{
		}

		private bool HasValueChanged()
		{
			return false;
		}

		private void HandleSliderMouseInput(PointerEventData eventData, bool allowValueWrap)
		{
		}
	}
}
