using ModApi.Ui;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class ColorPickerDialogScript : DialogScript
	{
		public delegate void ColorPickerDialogDelegate(ColorPickerDialogScript d);

		private bool _allowHDR;

		private bool _allowTransparency = true;

		private Color32 _color;

		private Image _colorPreviewNew;

		private Image _colorPreviewOld;

		private Image _colorSelector;

		private RectTransform _colorSelectorPoint;

		private TMP_InputField _hexInput;

		private Image _hueSelector;

		private RectTransform _hueSelectorPoint;

		private XmlElement _panel;

		private SliderControl _sliderAlpha;

		private SliderControl _sliderBlue;

		private SliderControl _sliderGreen;

		private SliderControl _sliderIntensity;

		private SliderControl _sliderRed;

		private Toggle _toggleRgb;

		public Color AdjustedColor
		{
			get
			{
				float num = Mathf.Pow(2f, _sliderIntensity.Slider.value);
				Color result = Color;
				result.r *= num;
				result.g *= num;
				result.b *= num;
				return result;
			}
			set
			{
				float maxColorComponent = value.maxColorComponent;
				float valueWithoutNotify;
				if (maxColorComponent > 1f)
				{
					value.r /= maxColorComponent;
					value.g /= maxColorComponent;
					value.b /= maxColorComponent;
					valueWithoutNotify = Mathf.Log(maxColorComponent, 2f);
					Color = value;
				}
				else
				{
					Color = value;
					valueWithoutNotify = 0f;
				}
				_sliderIntensity.Slider.SetValueWithoutNotify(valueWithoutNotify);
				_sliderIntensity.ValueText.text = valueWithoutNotify.ToString("F");
			}
		}

		public Color32 Color
		{
			get
			{
				return _color;
			}
			set
			{
				if (_color.r != value.r || _color.g != value.g || _color.b != value.b || _color.a != value.a)
				{
					_color = value;
					this.ColorChanged?.Invoke(this);
				}
			}
		}

		public float Hue { get; private set; }

		public float Saturation { get; private set; }

		public float Value { get; private set; }

		private bool ColorModeRgb => _toggleRgb.isOn;

		public event ColorPickerDialogDelegate CancelClicked;

		public event ColorPickerDialogDelegate ColorChanged;

		public event ColorPickerDialogDelegate OkayClicked;

		public static ColorPickerDialogScript Create(Transform parent, bool allowTransparency = false, bool allowHDR = false)
		{
			ColorPickerDialogScript colorPickerDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/ColorPickerDialog", parent, delegate(ColorPickerDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
			colorPickerDialogScript._allowTransparency = allowTransparency;
			colorPickerDialogScript._allowHDR = allowHDR;
			return colorPickerDialogScript;
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				Object.Destroy(base.gameObject);
			});
		}

		protected virtual void Awake()
		{
		}

		protected bool RaiseCancelClickedEvent()
		{
			if (this.CancelClicked != null)
			{
				this.CancelClicked(this);
				return true;
			}
			return false;
		}

		protected bool RaiseOkayClickedEvent()
		{
			if (this.OkayClicked != null)
			{
				this.OkayClicked(this);
				return true;
			}
			return false;
		}

		protected override void Start()
		{
			base.Start();
			_colorPreviewOld.color = AdjustedColor;
			UpdateColor(Color);
			_panel.Show();
		}

		protected virtual void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				OnCancelClicked();
			}
		}

		private SliderControl CreateSliderControl(XmlElement panelElement)
		{
			SliderControl sliderControl = new SliderControl(panelElement);
			sliderControl.Slider.minValue = 0f;
			sliderControl.Slider.maxValue = 255f;
			sliderControl.Slider.onValueChanged.AddListener(OnSliderChanged);
			return sliderControl;
		}

		private void OnCancelClicked()
		{
			OnOldColorClicked();
			if (!RaiseCancelClickedEvent())
			{
				Close();
			}
		}

		private void OnColorModeChanged(bool value)
		{
			if (ColorModeRgb)
			{
				_sliderRed.LabelText.text = "Red";
				_sliderGreen.LabelText.text = "Green";
				_sliderBlue.LabelText.text = "Blue";
			}
			else
			{
				_sliderRed.LabelText.text = "Hue";
				_sliderGreen.LabelText.text = "Saturation";
				_sliderBlue.LabelText.text = "Value";
			}
			RefreshUI();
		}

		private void OnHexInputChanged(string s)
		{
			s = "#" + s.Trim(' ', '#');
			if (ColorUtility.TryParseHtmlString(s, out var color))
			{
				if (!_allowTransparency)
				{
					color.a = 1f;
				}
				UpdateColor(color);
			}
			else
			{
				RefreshUI();
			}
		}

		private void OnHueChanged(ColorPickerInputHandlerScript.InputData x)
		{
			if (x.Radius > 105f || x.IsDragging)
			{
				Hue = x.Angle / 360f;
				Color32 color = UnityEngine.Color.HSVToRGB(Hue, Saturation, Value);
				color.a = Color.a;
				Color = color;
				RefreshUI();
			}
			else
			{
				x.Cancelled = true;
			}
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			Button elementById = xmlLayout.GetElementById<Button>("cancel-button");
			Button elementById2 = xmlLayout.GetElementById<Button>("okay-button");
			elementById.onClick.AddListener(delegate
			{
				OnCancelClicked();
			});
			elementById2.onClick.AddListener(delegate
			{
				OnOkayClicked();
			});
			_sliderRed = CreateSliderControl(xmlLayout.GetElementById("slider-red"));
			_sliderGreen = CreateSliderControl(xmlLayout.GetElementById("slider-green"));
			_sliderBlue = CreateSliderControl(xmlLayout.GetElementById("slider-blue"));
			_sliderAlpha = CreateSliderControl(xmlLayout.GetElementById("slider-alpha"));
			_sliderIntensity = CreateSliderControl(xmlLayout.GetElementById("slider-intensity"));
			_sliderIntensity.Slider.minValue = -10f;
			_sliderIntensity.Slider.maxValue = 10f;
			_sliderIntensity.Slider.wholeNumbers = false;
			_hexInput = xmlLayout.GetElementById<TMP_InputField>("hex-input");
			_hexInput.onEndEdit.AddListener(delegate(string s)
			{
				OnHexInputChanged(s);
			});
			_colorPreviewOld = xmlLayout.GetElementById<Image>("color-preview-old");
			_colorPreviewNew = xmlLayout.GetElementById<Image>("color-preview-new");
			_colorSelectorPoint = xmlLayout.GetElementById<RectTransform>("color-selector-point");
			_hueSelectorPoint = xmlLayout.GetElementById<RectTransform>("hue-selector-point");
			_hueSelector = xmlLayout.GetElementById<Image>("hue-selector");
			_colorSelector = xmlLayout.GetElementById<Image>("color-selector");
			_colorSelector.material = Object.Instantiate(Game.Instance.ResourceLoader.LoadMaterial("Ui/Materials/ColorPickerMaterial"));
			_colorSelector.material.SetColor("HueColor", UnityEngine.Color.red);
			_toggleRgb = xmlLayout.GetElementById<Toggle>("toggle-rgb");
			_toggleRgb.onValueChanged.AddListener(delegate(bool x)
			{
				OnColorModeChanged(x);
			});
			_hueSelector.gameObject.AddComponent<ColorPickerInputHandlerScript>().OnInput = delegate(ColorPickerInputHandlerScript.InputData x)
			{
				OnHueChanged(x);
			};
			ColorPickerInputHandlerScript colorPickerInputHandlerScript = xmlLayout.GetElementById("color-selector-input").gameObject.AddComponent<ColorPickerInputHandlerScript>();
			colorPickerInputHandlerScript.Target = _colorSelector.rectTransform;
			colorPickerInputHandlerScript.OnInput = delegate(ColorPickerInputHandlerScript.InputData x)
			{
				OnSaturationValueChanged(x);
			};
			_panel.SetAttribute("active", "false");
		}

		private void OnOkayClicked()
		{
			if (!RaiseOkayClickedEvent())
			{
				Close();
			}
		}

		private void OnOldColorClicked()
		{
			AdjustedColor = _colorPreviewOld.color;
			UpdateColor(Color);
		}

		private void OnSaturationValueChanged(ColorPickerInputHandlerScript.InputData x)
		{
			Saturation = x.Position.x;
			Value = x.Position.y;
			Color32 color = UnityEngine.Color.HSVToRGB(Hue, Saturation, Value);
			color.a = Color.a;
			Color = color;
			RefreshUI();
		}

		private void OnSliderChanged(float x)
		{
			Color32 color;
			if (ColorModeRgb)
			{
				color = new Color32((byte)Mathf.Clamp(_sliderRed.Slider.value, 0f, 255f), (byte)Mathf.Clamp(_sliderGreen.Slider.value, 0f, 255f), (byte)Mathf.Clamp(_sliderBlue.Slider.value, 0f, 255f), (byte)Mathf.Clamp(_sliderAlpha.Slider.value, 0f, 255f));
				if (!_allowTransparency)
				{
					color.a = byte.MaxValue;
				}
				UpdateColor(color);
				return;
			}
			Hue = Mathf.Clamp01(_sliderRed.Slider.value / 255f);
			Saturation = Mathf.Clamp01(_sliderGreen.Slider.value / 255f);
			Value = Mathf.Clamp01(_sliderBlue.Slider.value / 255f);
			color = UnityEngine.Color.HSVToRGB(Hue, Saturation, Value);
			if (!_allowTransparency)
			{
				color.a = byte.MaxValue;
			}
			else
			{
				color.a = (byte)Mathf.Clamp(_sliderAlpha.Slider.value, 0f, 255f);
			}
			Color = color;
			RefreshUI();
		}

		private void RefreshUI()
		{
			_colorPreviewNew.color = AdjustedColor;
			UpdateSlider(ColorModeRgb ? ((float)(int)Color.r) : (Hue * 255f), _sliderRed);
			UpdateSlider(ColorModeRgb ? ((float)(int)Color.g) : (Saturation * 255f), _sliderGreen);
			UpdateSlider(ColorModeRgb ? ((float)(int)Color.b) : (Value * 255f), _sliderBlue);
			if (_allowTransparency)
			{
				UpdateSlider((int)Color.a, _sliderAlpha);
			}
			else
			{
				_sliderAlpha.Panel.Hide();
			}
			if (_allowTransparency)
			{
				_hexInput.text = ColorUtility.ToHtmlStringRGBA(Color);
			}
			else
			{
				_hexInput.text = ColorUtility.ToHtmlStringRGB(Color);
			}
			if (_allowHDR)
			{
				_sliderIntensity.ValueText.text = _sliderIntensity.Slider.value.ToString("F");
			}
			else
			{
				_sliderIntensity.Panel.Hide();
			}
			_colorSelectorPoint.anchorMin = new Vector2(Saturation, Value);
			_colorSelectorPoint.anchorMax = new Vector2(Saturation, Value);
			_hueSelectorPoint.localRotation = Quaternion.Euler(0f, 0f, Hue * 360f);
			Color value = UnityEngine.Color.HSVToRGB(Hue, 1f, 1f);
			_colorSelector.material.SetColor("_HueColor", value);
		}

		private void UpdateColor(Color32 color)
		{
			Color = color;
			UnityEngine.Color.RGBToHSV(Color, out var H, out var S, out var V);
			Hue = H;
			Saturation = S;
			Value = V;
			RefreshUI();
		}

		private void UpdateSlider(float value, SliderControl slider)
		{
			slider.ValueText.text = $"{(int)value}";
			slider.Slider.SetValueWithoutNotify((int)value);
		}
	}
}
