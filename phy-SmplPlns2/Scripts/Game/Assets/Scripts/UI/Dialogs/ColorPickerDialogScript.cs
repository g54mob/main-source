using System.Threading.Tasks;
using Assets.Scripts.UI.Controls;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Dialogs
{
	public class ColorPickerDialogScript : WidgetScript
	{
		public delegate void ColorPickerDialogDelegate(ColorPickerDialogScript d);

		private bool _allowHDR;

		private Color32 _color;

		private ButtonWidget _colorPreviewNew;

		private ButtonWidget _colorPreviewOld;

		private Image _colorSelector;

		private RectTransform _colorSelectorPoint;

		private float? _emissionDay;

		private float? _emissionDayOriginal;

		private float? _emissionNight;

		private float? _emissionNightOriginal;

		private bool _hasMaterialOverrides;

		private TMP_InputField _hexInput;

		private Image _hueSelector;

		private RectTransform _hueSelectorPoint;

		private float? _metallic;

		private float? _metallicOriginal;

		private bool _showMaterialProperties;

		private SliderControl _sliderAlpha;

		private SliderControl _sliderBlue;

		private SliderControl _sliderDayEmission;

		private SliderControl _sliderGreen;

		private SliderControl _sliderIntensity;

		private SliderControl _sliderMetallic;

		private SliderControl _sliderNightEmission;

		private SliderControl _sliderRed;

		private SliderControl _sliderSmoothness;

		private float? _smoothness;

		private float? _smoothnessOriginal;

		private ToggleWidget _toggleMaterialOverrides;

		private Toggle _toggleRgb;

		public Color AdjustedColor
		{
			get
			{
				float num = Mathf.Pow(2f, _sliderIntensity.Slider.Slider.value);
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
				_sliderIntensity.Slider.Slider.SetValueWithoutNotify(valueWithoutNotify);
				_sliderIntensity.ValueText.Text = valueWithoutNotify.ToString("F");
			}
		}

		public bool AllowTransparency { get; set; }

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

		public float? EmissionDay => _emissionDay;

		public float EmissionDayDefault { get; private set; }

		public float? EmissionNight => _emissionNight;

		public float EmissionNightDefault { get; private set; }

		public IFlyout Flyout { get; private set; }

		public float Hue { get; private set; }

		public float? Metallic => _metallic;

		public float MetallicDefault { get; private set; }

		public float Saturation { get; private set; }

		public bool ShowMaterialProperties
		{
			get
			{
				return _showMaterialProperties;
			}
			set
			{
				_showMaterialProperties = value;
				base.Widget.ExecuteOnWidgetsOfClass("material-property", delegate(Widget w)
				{
					w.SetVisible(value);
				});
			}
		}

		public float? Smoothness => _smoothness;

		public float SmoothnessDefault { get; private set; }

		public float Value { get; private set; }

		private bool ColorModeRgb => _toggleRgb?.isOn ?? true;

		public event ColorPickerDialogDelegate ColorChanged;

		public event ColorPickerDialogDelegate MaterialPropertiesChanged;

		public void Initialize()
		{
			Flyout = GetComponentInParent<IFlyout>(includeInactive: true);
			Flyout.Show(show: true);
		}

		public void InitializeMaterialProperties(float? metallic, float metallicDefault, float? smoothness, float smoothnessDefault, float? emissionDay, float? emissionNight, float emissionDayDefault, float emissionNightDefault)
		{
			ShowMaterialProperties = true;
			_metallic = metallic;
			_smoothness = smoothness;
			_emissionDay = emissionDay;
			_emissionNight = emissionNight;
			_metallicOriginal = metallic;
			_smoothnessOriginal = smoothness;
			_emissionDayOriginal = emissionDay;
			_emissionNightOriginal = emissionNight;
			MetallicDefault = metallicDefault;
			SmoothnessDefault = smoothnessDefault;
			EmissionDayDefault = emissionDayDefault;
			EmissionNightDefault = emissionNightDefault;
			UpdateMaterialOverridesControls(raiseChangedEvent: false);
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_sliderRed = CreateSliderControl(widget.FindWidget("slider-red"));
			_sliderGreen = CreateSliderControl(widget.FindWidget("slider-green"));
			_sliderBlue = CreateSliderControl(widget.FindWidget("slider-blue"));
			_sliderAlpha = CreateSliderControl(widget.FindWidget("slider-alpha"));
			_sliderIntensity = CreateSliderControl(widget.FindWidget("slider-intensity"));
			_sliderIntensity.Slider.Slider.minValue = -10f;
			_sliderIntensity.Slider.Slider.maxValue = 10f;
			_sliderIntensity.Slider.Slider.wholeNumbers = false;
			_hexInput = widget.FindWidgetComponent<TMP_InputField>("hex-input");
			_hexInput.onEndEdit.AddListener(delegate(string s)
			{
				OnHexInputChanged(s);
			});
			_colorPreviewOld = widget.FindWidgetComponent<ButtonWidget>("color-preview-old");
			_colorPreviewNew = widget.FindWidgetComponent<ButtonWidget>("color-preview-new");
			_colorSelectorPoint = widget.FindWidgetComponent<RectTransform>("color-selector-point");
			_hueSelectorPoint = widget.FindWidgetComponent<RectTransform>("hue-selector-point");
			_hueSelector = widget.FindWidgetComponent<Image>("hue-selector");
			_colorSelector = widget.FindWidgetComponent<Image>("color-selector");
			_colorSelector.material = Object.Instantiate(Game.Instance.ResourceLoader.LoadMaterial("Ui/Materials/ColorPickerMaterial"));
			_colorSelector.material.SetColor("HueColor", UnityEngine.Color.red);
			_hueSelector.gameObject.AddComponent<ColorPickerInputHandlerScript>().OnInput = delegate(ColorPickerInputHandlerScript.InputData x)
			{
				OnHueChanged(x);
			};
			ColorPickerInputHandlerScript colorPickerInputHandlerScript = widget.FindWidget("color-selector-input").gameObject.AddComponent<ColorPickerInputHandlerScript>();
			colorPickerInputHandlerScript.Target = _colorSelector.rectTransform;
			colorPickerInputHandlerScript.OnInput = delegate(ColorPickerInputHandlerScript.InputData x)
			{
				OnSaturationValueChanged(x);
			};
			_toggleMaterialOverrides = widget.FindWidget<ToggleWidget>("toggle-material-properties");
			_toggleMaterialOverrides.Clicked += OnToggleMaterialOverridesClicked;
			_sliderMetallic = CreateMaterialPropertySliderControl(widget.FindWidget("slider-metallic"));
			_sliderSmoothness = CreateMaterialPropertySliderControl(widget.FindWidget("slider-smoothness"));
			_sliderDayEmission = CreateMaterialPropertySliderControl(widget.FindWidget("slider-emission-day"), 5f);
			_sliderNightEmission = CreateMaterialPropertySliderControl(widget.FindWidget("slider-emission-night"), 5f);
			UpdateMaterialOverridesControls(raiseChangedEvent: false);
		}

		protected async void Start()
		{
			_colorPreviewOld.Color.Base = AdjustedColor;
			await Task.Yield();
			await Task.Yield();
			await Task.Yield();
			UpdateColor(Color);
		}

		private SliderControl CreateMaterialPropertySliderControl(Widget widget, float maxValue = 1f)
		{
			SliderControl sliderControl = new SliderControl(widget);
			sliderControl.Slider.Slider.minValue = 0f;
			sliderControl.Slider.Slider.maxValue = maxValue;
			sliderControl.Slider.ValueChanged += OnMaterialPropertySliderChanged;
			sliderControl.ValueFormatter = SliderControl.PercentageFormatter;
			return sliderControl;
		}

		private SliderControl CreateSliderControl(Widget widget)
		{
			SliderControl sliderControl = new SliderControl(widget);
			sliderControl.Slider.Slider.minValue = 0f;
			sliderControl.Slider.Slider.maxValue = 255f;
			sliderControl.Slider.Slider.onValueChanged.AddListener(OnSliderChanged);
			return sliderControl;
		}

		private void OnColorModeChanged(bool value)
		{
			if (ColorModeRgb)
			{
				_sliderRed.LabelText = "Red";
				_sliderGreen.LabelText = "Green";
				_sliderBlue.LabelText = "Blue";
			}
			else
			{
				_sliderRed.LabelText = "Hue";
				_sliderGreen.LabelText = "Saturation";
				_sliderBlue.LabelText = "Value";
			}
			RefreshUI();
		}

		private void OnHexInputChanged(string s)
		{
			s = "#" + s.Trim(' ', '#');
			if (ColorUtility.TryParseHtmlString(s, out var color))
			{
				if (!AllowTransparency)
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

		private void OnMaterialPropertySliderChanged(float value)
		{
			if (SetMaterialProperties(_sliderMetallic.Slider.Value, _sliderSmoothness.Slider.Value, _sliderDayEmission.Slider.Value, _sliderNightEmission.Slider.Value))
			{
				this.MaterialPropertiesChanged?.Invoke(this);
			}
		}

		private void OnOldColorClicked(Widget widget)
		{
			AdjustedColor = _colorPreviewOld.Color.Base;
			UpdateColor(Color);
			bool raiseChangedEvent = SetMaterialProperties(_metallicOriginal, _smoothnessOriginal, _emissionDayOriginal, _emissionNightOriginal);
			UpdateMaterialOverridesControls(raiseChangedEvent);
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
				color = new Color32((byte)Mathf.Clamp(_sliderRed.Slider.Slider.value, 0f, 255f), (byte)Mathf.Clamp(_sliderGreen.Slider.Slider.value, 0f, 255f), (byte)Mathf.Clamp(_sliderBlue.Slider.Slider.value, 0f, 255f), (byte)Mathf.Clamp(_sliderAlpha.Slider.Slider.value, 0f, 255f));
				if (!AllowTransparency)
				{
					color.a = byte.MaxValue;
				}
				UpdateColor(color);
				return;
			}
			Hue = Mathf.Clamp01(_sliderRed.Slider.Slider.value / 255f);
			Saturation = Mathf.Clamp01(_sliderGreen.Slider.Slider.value / 255f);
			Value = Mathf.Clamp01(_sliderBlue.Slider.Slider.value / 255f);
			color = UnityEngine.Color.HSVToRGB(Hue, Saturation, Value);
			if (!AllowTransparency)
			{
				color.a = byte.MaxValue;
			}
			else
			{
				color.a = (byte)Mathf.Clamp(_sliderAlpha.Slider.Slider.value, 0f, 255f);
			}
			Color = color;
			RefreshUI();
		}

		private void OnToggleMaterialOverridesClicked(Widget widget)
		{
			bool raiseChangedEvent = (_hasMaterialOverrides ? SetMaterialProperties(null, null, null, null) : SetMaterialProperties(MetallicDefault, SmoothnessDefault, EmissionDayDefault, EmissionNightDefault));
			UpdateMaterialOverridesControls(raiseChangedEvent);
		}

		private void RefreshUI()
		{
			_colorPreviewNew.Color.Base = AdjustedColor;
			UpdateSlider(ColorModeRgb ? ((float)(int)Color.r) : (Hue * 255f), _sliderRed);
			UpdateSlider(ColorModeRgb ? ((float)(int)Color.g) : (Saturation * 255f), _sliderGreen);
			UpdateSlider(ColorModeRgb ? ((float)(int)Color.b) : (Value * 255f), _sliderBlue);
			if (AllowTransparency)
			{
				UpdateSlider((int)Color.a, _sliderAlpha);
			}
			else
			{
				_sliderAlpha.Visible = false;
			}
			if (AllowTransparency)
			{
				_hexInput.text = ColorUtility.ToHtmlStringRGBA(Color);
			}
			else
			{
				_hexInput.text = ColorUtility.ToHtmlStringRGB(Color);
			}
			if (_allowHDR)
			{
				_sliderIntensity.ValueText.Text = _sliderIntensity.Slider.Slider.value.ToString("F");
			}
			else
			{
				_sliderIntensity.Visible = false;
			}
			_colorSelectorPoint.anchorMin = new Vector2(Saturation, Value);
			_colorSelectorPoint.anchorMax = new Vector2(Saturation, Value);
			_hueSelectorPoint.localRotation = Quaternion.Euler(0f, 0f, Hue * 360f);
			Color value = UnityEngine.Color.HSVToRGB(Hue, 1f, 1f);
			_colorSelector.material.SetColor("_HueColor", value);
			_colorSelector.gameObject.SetActive(value: false);
			_colorSelector.gameObject.SetActive(value: true);
		}

		private bool SetMaterialProperties(float? metallic, float? smoothness, float? emissionDay, float? emissionNight)
		{
			bool result = _metallic != metallic || _smoothness != smoothness || _emissionDay != emissionDay || _emissionNight != emissionNight;
			_metallic = metallic;
			_smoothness = smoothness;
			_emissionDay = emissionDay;
			_emissionNight = emissionNight;
			return result;
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

		private void UpdateMaterialOverridesControls(bool raiseChangedEvent)
		{
			_hasMaterialOverrides = _metallic.HasValue || _smoothness.HasValue || _emissionDay.HasValue || _emissionNight.HasValue;
			_toggleMaterialOverrides.IsOn = _hasMaterialOverrides;
			if (_hasMaterialOverrides)
			{
				_sliderMetallic.Slider.Value = _metallic ?? MetallicDefault;
				_sliderSmoothness.Slider.Value = _smoothness ?? SmoothnessDefault;
				_sliderDayEmission.Slider.Value = _emissionDay ?? EmissionDayDefault;
				_sliderNightEmission.Slider.Value = _emissionNight ?? EmissionNightDefault;
				_sliderMetallic.Slider.Interactable = true;
				_sliderSmoothness.Slider.Interactable = true;
				_sliderDayEmission.Slider.Interactable = true;
				_sliderNightEmission.Slider.Interactable = true;
			}
			else
			{
				_sliderMetallic.Slider.Value = MetallicDefault;
				_sliderSmoothness.Slider.Value = SmoothnessDefault;
				_sliderDayEmission.Slider.Value = EmissionDayDefault;
				_sliderNightEmission.Slider.Value = EmissionNightDefault;
				_sliderMetallic.Slider.Interactable = false;
				_sliderSmoothness.Slider.Interactable = false;
				_sliderDayEmission.Slider.Interactable = false;
				_sliderNightEmission.Slider.Interactable = false;
			}
			if (raiseChangedEvent)
			{
				this.MaterialPropertiesChanged?.Invoke(this);
			}
		}

		private void UpdateSlider(float value, SliderControl slider)
		{
			slider.ValueText.Text = $"{(int)value}";
			slider.Slider.Slider.SetValueWithoutNotify((int)value);
		}
	}
}
