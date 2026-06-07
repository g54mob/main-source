using System;
using ModApi.Common.Collections;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class SpinnerScript : MonoBehaviour
	{
		private bool _initialized;

		private TMP_InputField _inputField;

		[SerializeField]
		private Button _nextButton;

		private bool _nextButtonVisible = true;

		private float _numericValue;

		[SerializeField]
		private Button _prevButton;

		private bool _prevButtonVisible = true;

		private TextMeshProUGUI _text;

		private string _value;

		private CircularList<string> _values = new CircularList<string>();

		private XmlElement _xmlElement;

		public float MaxValue { get; set; }

		public float MinValue { get; set; }

		public Button NextButton => _nextButton;

		public bool NextButtonVisible
		{
			get
			{
				return _nextButtonVisible;
			}
			set
			{
				if (_nextButtonVisible != value)
				{
					_nextButtonVisible = value;
					_nextButton.gameObject.SetActive(value);
				}
			}
		}

		public string NumericFormat { get; set; }

		public float NumericValue => _numericValue;

		public bool NumericWrap { get; set; }

		public Func<string, string> OnLabelRequested { get; set; }

		public Action<float> OnNumericValueChanged { get; set; }

		public Action<string> OnValueChanged { get; set; }

		public Button PrevButton => _prevButton;

		public bool PrevButtonVisible
		{
			get
			{
				return _prevButtonVisible;
			}
			set
			{
				if (_prevButtonVisible != value)
				{
					_prevButtonVisible = value;
					_prevButton.gameObject.SetActive(value);
				}
			}
		}

		public SpinnerType SpinnerType { get; set; }

		public float StepSize { get; set; }

		public TextMeshProUGUI Text => _text;

		public string Value
		{
			get
			{
				return _value;
			}
			set
			{
				Initialize();
				_value = value;
				if (_inputField != null)
				{
					_inputField.text = OnLabelRequested(value);
				}
				else if (_text != null)
				{
					_text.text = OnLabelRequested(value);
				}
			}
		}

		public CircularList<string> Values => _values;

		public SpinnerScript()
		{
			SpinnerType = SpinnerType.Text;
			OnLabelRequested = (string x) => x;
		}

		public void SetNumericValue(float value)
		{
			if (NumericWrap)
			{
				if (value > MaxValue)
				{
					value = MinValue + (value - MaxValue);
				}
				else if (value < MinValue)
				{
					value = MaxValue + (value - MinValue);
				}
			}
			_numericValue = Mathf.Clamp(value, MinValue, MaxValue);
			Value = NumericValue.ToString(NumericFormat);
		}

		protected virtual void OnDestroy()
		{
			OnNumericValueChanged = null;
			OnLabelRequested = null;
			OnValueChanged = null;
		}

		protected virtual void Start()
		{
			Initialize();
		}

		private void Initialize()
		{
			if (!_initialized)
			{
				_initialized = true;
				_nextButton.onClick.AddListener(delegate
				{
					OnButtonClicked(1);
				});
				_prevButton.onClick.AddListener(delegate
				{
					OnButtonClicked(-1);
				});
				_xmlElement = GetComponent<XmlElement>();
				_inputField = GetComponentInChildren<TMP_InputField>();
				if (_inputField != null)
				{
					_inputField.text = OnLabelRequested(Value);
					_inputField.onEndEdit.AddListener(OnInputEndEdit);
				}
				else
				{
					_text = GetComponentInChildren<TextMeshProUGUI>();
					_text.text = OnLabelRequested(Value);
				}
			}
		}

		private void OnButtonClicked(int direction)
		{
			if (_xmlElement != null)
			{
				_xmlElement.PlaySound(_xmlElement.OnClickSound);
			}
			if (SpinnerType == SpinnerType.Text)
			{
				if (Values.Count > 0)
				{
					if (direction > 0)
					{
						Value = Values.NextValue(Value);
					}
					else
					{
						Value = Values.PreviousValue(Value);
					}
					if (OnValueChanged != null)
					{
						OnValueChanged(Value);
					}
				}
			}
			else if (SpinnerType == SpinnerType.Numeric)
			{
				SetNumericValue(NumericValue + (float)direction * StepSize);
				if (OnNumericValueChanged != null)
				{
					OnNumericValueChanged(NumericValue);
				}
			}
		}

		private void OnInputEndEdit(string value)
		{
			if (SpinnerType == SpinnerType.Text)
			{
				OnValueChanged?.Invoke(value);
			}
			else if (SpinnerType == SpinnerType.Numeric)
			{
				_ = _numericValue;
				if (float.TryParse(value, out var result))
				{
					SetNumericValue(result);
					OnNumericValueChanged?.Invoke(NumericValue);
				}
			}
		}
	}
}
