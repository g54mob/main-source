using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.UIReferences
{
	public class InfoSlider : MonoBehaviour
	{
		public enum ValuePosition
		{
			BeforeBar = 0,
			CenteredInBar = 1,
			AfterBar = 2
		}

		public enum ValueType
		{
			Decimal = 0,
			Percentage = 1
		}

		private Slider slider;

		private float value = 0.5f;

		private float maxValue;

		private Vector2 size;

		[SerializeField]
		[Range(0f, 4f)]
		private int precision;

		[SerializeField]
		private Image filledImage;

		[SerializeField]
		private Image emptyImage;

		[SerializeField]
		private TextMeshProUGUI valueText;

		[SerializeField]
		private ValueType valueType;

		[SerializeField]
		private string sufix = "";

		[SerializeField]
		private ValuePosition valuePosition;

		public void InitInfoSlider(ValuePosition _valuePosition = ValuePosition.CenteredInBar, ValueType _valueType = ValueType.Decimal, int _precision = 2, string _sufix = "", float _maxValue = 1f)
		{
			slider = GetComponent<Slider>();
			maxValue = _maxValue;
			slider.maxValue = maxValue;
			size = GetComponent<RectTransform>().sizeDelta;
			sufix = _sufix;
			SetValuePosition(_valuePosition);
			SetValueType(_valueType, _precision);
		}

		public void SetValuePosition(ValuePosition _valuePosition)
		{
			valuePosition = _valuePosition;
			switch (valuePosition)
			{
			case ValuePosition.BeforeBar:
				valueText.rectTransform.anchorMax = new Vector2(0f, 1f);
				valueText.rectTransform.anchorMin = new Vector2(0f, 0f);
				valueText.rectTransform.pivot = new Vector2(1f, 0.5f);
				valueText.rectTransform.anchoredPosition = new Vector3(-5f, 0f, 0f);
				break;
			case ValuePosition.CenteredInBar:
				valueText.rectTransform.anchorMax = new Vector2(0.5f, 1f);
				valueText.rectTransform.anchorMin = new Vector2(0.5f, 0f);
				valueText.rectTransform.pivot = new Vector2(0.5f, 0.5f);
				valueText.rectTransform.anchoredPosition = Vector3.zero;
				break;
			case ValuePosition.AfterBar:
				valueText.rectTransform.anchorMax = new Vector2(1f, 1f);
				valueText.rectTransform.anchorMin = new Vector2(1f, 0f);
				valueText.rectTransform.pivot = new Vector2(0f, 0.5f);
				valueText.rectTransform.anchoredPosition = new Vector3(-5f, 0f, 0f);
				break;
			}
		}

		public void SetValueType(ValueType _valueType, int _precision = 2)
		{
			valueType = _valueType;
			precision = _precision;
			valueText.fontSize = size.y - 2f;
			valueText.rectTransform.sizeDelta = new Vector2((4.25f + (float)precision * 1f) * (size.y - 2f), size.y);
		}

		public void SetValue(float _value)
		{
			value = _value;
			slider.value = value;
			switch (valueType)
			{
			case ValueType.Decimal:
				valueText.text = value.ToString("F" + precision) + sufix;
				break;
			case ValueType.Percentage:
				valueText.text = (value * 100f).ToString("F" + precision) + "%" + sufix;
				break;
			}
		}

		public void SetFilledColor(Color _color)
		{
			filledImage.color = _color;
		}

		public void SetEmptyColor(Color _color)
		{
			emptyImage.color = _color;
		}
	}
}
