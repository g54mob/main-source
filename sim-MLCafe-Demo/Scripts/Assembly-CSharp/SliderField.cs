using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderField : MonoBehaviour
{
	private enum LabelValueDecimalMode
	{
		FullNumbers = 0,
		FirstDigit = 1,
		TwoDigits = 2,
		Float = 3
	}

	private enum LabelPosition
	{
		First = 0,
		LeftSlider = 1,
		RightSlider = 2,
		End = 3
	}

	[Header("Slider Editor Properties")]
	[SerializeField]
	private bool useSliderProperty = true;

	[SerializeField]
	private Slider sliderProperty;

	[SerializeField]
	private Image imgHandle;

	[SerializeField]
	private Image imgBackground;

	[SerializeField]
	private Image imgFill;

	[SerializeField]
	private float width = 150f;

	[SerializeField]
	private float height = 10f;

	[Header("Text Property")]
	[SerializeField]
	private bool useLabelValue;

	[SerializeField]
	private bool useLabelSlider;

	[SerializeField]
	private TMP_Text labelValue;

	[SerializeField]
	private TMP_Text labelSlider;

	[SerializeField]
	private bool useLabelValueContentFitter = true;

	[SerializeField]
	private bool useLabelSliderContentFitter = true;

	[SerializeField]
	private float fixedLabelSliderWidth = 150f;

	[SerializeField]
	private float fixedLabelValueWidth = 50f;

	[SerializeField]
	private string title;

	[SerializeField]
	private string labelValuePrefix;

	[SerializeField]
	private string labelValueSuffix;

	[SerializeField]
	private LabelValueDecimalMode labelValueDecimalMode = LabelValueDecimalMode.FirstDigit;

	[SerializeField]
	private float displayValueMultiplier = 1f;

	[SerializeField]
	private LabelPosition labelValuePosition = LabelPosition.LeftSlider;

	[SerializeField]
	private Color colorLabelValue = Color.white;

	[SerializeField]
	private Color colorLabelSlider = Color.white;

	[SerializeField]
	private TMP_FontAsset fontAsset;

	[SerializeField]
	private float fontScale = 16f;

	[SerializeField]
	private TextAlignmentOptions textAlignmentOptions;

	[Header("Handle")]
	[SerializeField]
	private Color handleColor = Color.white;

	[SerializeField]
	private float handleScale = 10f;

	[SerializeField]
	private Sprite handleIcon;

	[Header("Slider Section")]
	[SerializeField]
	private Color fillColor = Color.white;

	[SerializeField]
	private Color backGroundColor = Color.gray;

	[SerializeField]
	private Sprite panelSprite;

	[SerializeField]
	private Sprite fillSprite;

	[SerializeField]
	private float pixelsPerUnit = 50f;

	[SerializeField]
	private bool intSlider;

	[SerializeField]
	private bool roundValueDigits;

	[SerializeField]
	private LabelValueDecimalMode valueDigits = LabelValueDecimalMode.Float;

	[SerializeField]
	private float startAmount;

	[SerializeField]
	private float endAmount = 1f;

	[SerializeField]
	[Range(0f, 1f)]
	private float startFill = 0.5f;

	[SerializeField]
	private bool previewMode;

	[SerializeField]
	private UnityEvent<float> OnSliderValueChanged = new UnityEvent<float>();

	private void Awake()
	{
		if (previewMode)
		{
			if (useSliderProperty)
			{
				sliderProperty.minValue = startAmount;
				sliderProperty.maxValue = endAmount;
				sliderProperty.SetValueWithoutNotify(Mathf.Lerp(startAmount, endAmount, startFill));
				sliderProperty.wholeNumbers = intSlider;
			}
			else
			{
				imgFill.fillAmount = Mathf.Lerp(startAmount, endAmount, startFill);
			}
		}
	}

	public void SetTextTitle(string localizedText)
	{
		title = localizedText;
		labelSlider.text = localizedText;
		UpdateLabels();
	}

	public float GetSliderValue()
	{
		return sliderProperty.value;
	}

	public void SetSliderMax(float max)
	{
		sliderProperty.maxValue = max;
		UpdateLabels();
	}

	public void SetSliderMin(float min)
	{
		sliderProperty.minValue = min;
		UpdateLabels();
	}

	public UnityEvent<float> GetOnSliderValueChangedEvent()
	{
		return OnSliderValueChanged;
	}

	private float GetRoundedValue(float value)
	{
		if (roundValueDigits)
		{
			float num = value;
			switch (valueDigits)
			{
			case LabelValueDecimalMode.FullNumbers:
				num = Mathf.Round(value);
				break;
			case LabelValueDecimalMode.FirstDigit:
				num = Mathf.Round(value * 10f) / 10f;
				break;
			case LabelValueDecimalMode.TwoDigits:
				num = Mathf.Round(value * 100f) / 100f;
				break;
			}
			value = num;
			if (useSliderProperty)
			{
				sliderProperty.SetValueWithoutNotify(value);
			}
			else
			{
				imgFill.fillAmount = value;
			}
		}
		else
		{
			imgFill.fillAmount = value;
		}
		return value;
	}

	public void Init(float value)
	{
		float roundedValue = GetRoundedValue(value);
		if (useSliderProperty)
		{
			sliderProperty.SetValueWithoutNotify(roundedValue);
		}
		else
		{
			imgFill.fillAmount = roundedValue;
		}
		UpdateLabels();
	}

	public void OnValueChange(float value)
	{
		value = GetRoundedValue(value);
		OnSliderValueChanged.Invoke(value);
		UpdateLabels();
	}

	public void SetValueWithoutNotify(float value)
	{
		float roundedValue = GetRoundedValue(value);
		sliderProperty.SetValueWithoutNotify(roundedValue);
		UpdateLabels();
	}

	private void UpdateLabels()
	{
		if (useSliderProperty)
		{
			string text = (sliderProperty.value * displayValueMultiplier).ToString();
			switch (labelValueDecimalMode)
			{
			case LabelValueDecimalMode.FullNumbers:
				text = Mathf.CeilToInt(sliderProperty.value * displayValueMultiplier).ToString();
				break;
			case LabelValueDecimalMode.FirstDigit:
				text = $"{sliderProperty.value * displayValueMultiplier:0.0}";
				break;
			case LabelValueDecimalMode.TwoDigits:
				text = $"{sliderProperty.value * displayValueMultiplier:0.00}";
				break;
			case LabelValueDecimalMode.Float:
				text = (sliderProperty.value * displayValueMultiplier).ToString();
				break;
			}
			labelValue.text = labelValuePrefix + " " + text + " " + labelValueSuffix;
		}
		else
		{
			string text2 = (imgFill.fillAmount * displayValueMultiplier).ToString();
			switch (labelValueDecimalMode)
			{
			case LabelValueDecimalMode.FullNumbers:
				text2 = Mathf.CeilToInt(imgFill.fillAmount * displayValueMultiplier).ToString();
				break;
			case LabelValueDecimalMode.FirstDigit:
				text2 = $"{imgFill.fillAmount * displayValueMultiplier:0.0}";
				break;
			case LabelValueDecimalMode.TwoDigits:
				text2 = $"{imgFill.fillAmount * displayValueMultiplier:0.00}";
				break;
			case LabelValueDecimalMode.Float:
				text2 = (imgFill.fillAmount * displayValueMultiplier).ToString();
				break;
			}
			labelValue.text = labelValuePrefix + " " + text2 + " " + labelValueSuffix;
		}
	}
}
