using System;
using System.Collections.Generic;
using Assets.Scripts.Ui;
using ModApi.Craft;
using ModApi.Craft.Parts;
using TMPro;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Design.Paint
{
	public class EditColorPanelScript
	{
		public delegate void ColorUpdatedDelegate(ColorButtonScript colorButton, bool transparencyChanged);

		private TMP_InputField _colorNameInput;

		private Slider _detailSlider;

		private TextMeshProUGUI _detailSliderLabel;

		private XmlElement _element;

		private Slider _emissionSlider;

		private TextMeshProUGUI _emissionSliderLabel;

		private ColorPickerScript _hueColorPicker;

		private List<char> _invalidCharacters = new List<char>();

		private Slider _metallicSlider;

		private TextMeshProUGUI _metallicSliderLabel;

		private ColorButtonScript _selectedColor;

		private ColorPickerScript _shadeColorPicker;

		private Slider _smoothnessSlider;

		private TextMeshProUGUI _smoothnessSliderLabel;

		private SpinnerScript _styleSpinner;

		private Slider _transparencySlider;

		private TextMeshProUGUI _transparencySliderLabel;

		private XmlElement _unlockTransparencyButton;

		public bool Visible
		{
			get
			{
				return _element.gameObject.activeInHierarchy;
			}
			set
			{
				_element.gameObject.SetActive(value);
			}
		}

		public event ColorUpdatedDelegate ColorUpdated;

		public void Cleanup()
		{
			_hueColorPicker?.Cleanup();
			_shadeColorPicker?.Cleanup();
		}

		public void ColorPicker()
		{
			Game.Instance.UserInterface.CreateColorPicker(allowTransparency: false, _selectedColor.Color, Callback, Callback);
			void Callback(Color c)
			{
				UpdateSelectedButtonColor(c);
				RefreshColorPickers(c);
			}
		}

		public void OnColorSelected(ColorButtonScript selectedColor)
		{
			_selectedColor = selectedColor;
			if (Visible)
			{
				PartMaterial partMaterial = selectedColor.PartMaterial;
				RefreshColorPickers(partMaterial.Color);
				RefreshStyle(ColorStyles.GetStyleName(partMaterial.Metallic, partMaterial.Smoothness, partMaterial.DetailStrength, partMaterial.EmissionStrength, partMaterial.TransparencyStrength));
			}
		}

		public void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			if (_invalidCharacters.Count == 0)
			{
				_invalidCharacters.Add(',');
				_invalidCharacters.Add('"');
				_invalidCharacters.Add('\'');
				_invalidCharacters.Add('<');
				_invalidCharacters.Add('>');
			}
			_element = xmlLayout.GetElementById("edit-color-panel");
			_styleSpinner = xmlLayout.GetElementById<SpinnerScript>("style-spinner");
			_colorNameInput = xmlLayout.GetElementById("color-name-input").GetComponent<TMP_InputField>();
			_metallicSlider = xmlLayout.GetElementById<Slider>("metallic-slider");
			_metallicSliderLabel = xmlLayout.GetElementById<TextMeshProUGUI>("metallic-slider-text");
			_smoothnessSlider = xmlLayout.GetElementById<Slider>("smoothness-slider");
			_smoothnessSliderLabel = xmlLayout.GetElementById<TextMeshProUGUI>("smoothness-slider-text");
			_emissionSlider = xmlLayout.GetElementById<Slider>("emission-slider");
			_emissionSliderLabel = xmlLayout.GetElementById<TextMeshProUGUI>("emission-slider-text");
			_detailSlider = xmlLayout.GetElementById<Slider>("detail-slider");
			_detailSliderLabel = xmlLayout.GetElementById<TextMeshProUGUI>("detail-slider-text");
			_transparencySlider = xmlLayout.GetElementById<Slider>("transparency-slider");
			_transparencySliderLabel = xmlLayout.GetElementById<TextMeshProUGUI>("transparency-slider-text");
			_unlockTransparencyButton = xmlLayout.GetElementById("unlock-transparency");
			InitializeStyles();
			InitializeHueColorPicker(xmlLayout);
			InitializeShadeColorPicker(xmlLayout);
		}

		public void Refresh()
		{
			if (_selectedColor != null)
			{
				OnColorSelected(_selectedColor);
			}
		}

		private void HueSelected(ColorPickerScript colorPickerScript, ColorGradient.Shade shade)
		{
			_shadeColorPicker.SetColorGradient(shade.ColorGradient);
			_shadeColorPicker.SelectClosestShade(shade.Color);
			UpdateSelectedButtonColor(shade.Color);
		}

		private void InitializeHueColorPicker(XmlLayout xmlLayout)
		{
			XmlElement elementById = xmlLayout.GetElementById("hue-color-picker");
			_hueColorPicker = elementById.gameObject.AddComponent<ColorPickerScript>();
			_hueColorPicker.Initialize(elementById);
			ColorGradient colorGradient = new ColorGradient();
			colorGradient.Colors.Add(new Vector3(1f, 0f, 0f));
			colorGradient.Colors.Add(new Vector3(1f, 1f, 0f));
			colorGradient.Colors.Add(new Vector3(0f, 1f, 0f));
			colorGradient.Colors.Add(new Vector3(0f, 1f, 1f));
			colorGradient.Colors.Add(new Vector3(0f, 0f, 1f));
			colorGradient.Colors.Add(new Vector3(1f, 0f, 1f));
			colorGradient.Colors.Add(new Vector3(1f, 0f, 0f));
			colorGradient.ShadesBetweenColors = 3;
			Vector3 color = new Vector3(0.5f, 0.5f, 0.5f);
			colorGradient.Shades.Add(new ColorGradient.Shade(color));
			colorGradient.CalculateShades();
			_hueColorPicker.SetColorGradient(colorGradient);
			foreach (ColorGradient.Shade shade in colorGradient.Shades)
			{
				ColorGradient colorGradient2 = new ColorGradient();
				colorGradient2.Colors.Add(new Vector3(0f, 0f, 0f));
				colorGradient2.Colors.Add(new Vector3(shade.Color.r, shade.Color.g, shade.Color.b));
				colorGradient2.Colors.Add(new Vector3(1f, 1f, 1f));
				colorGradient2.ShadesBetweenColors = 10;
				colorGradient2.CalculateShades();
				shade.ColorGradient = colorGradient2;
			}
			_hueColorPicker.UserSelectedColor += HueSelected;
		}

		private void InitializeShadeColorPicker(XmlLayout xmlLayout)
		{
			XmlElement elementById = xmlLayout.GetElementById("shade-color-picker");
			_shadeColorPicker = elementById.gameObject.AddComponent<ColorPickerScript>();
			_shadeColorPicker.Initialize(elementById);
			_shadeColorPicker.UserSelectedColor += ShadeSelected;
		}

		private void InitializeStyles()
		{
			_styleSpinner.Values.Add("Gloss");
			_styleSpinner.Values.Add("Semi-Gloss");
			_styleSpinner.Values.Add("Flat");
			_styleSpinner.Values.Add("Custom");
			SpinnerScript styleSpinner = _styleSpinner;
			styleSpinner.OnValueChanged = (Action<string>)Delegate.Combine(styleSpinner.OnValueChanged, (Action<string>)delegate(string x)
			{
				OnStyleChanged(x);
			});
			_colorNameInput.characterLimit = 20;
			TMP_InputField colorNameInput = _colorNameInput;
			colorNameInput.onValidateInput = (TMP_InputField.OnValidateInput)Delegate.Combine(colorNameInput.onValidateInput, new TMP_InputField.OnValidateInput(OnValidateInput));
			_colorNameInput.onEndEdit.AddListener(OnNameChanged);
			_smoothnessSlider.minValue = 0f;
			_smoothnessSlider.maxValue = 100f;
			_smoothnessSlider.wholeNumbers = true;
			_smoothnessSlider.onValueChanged.AddListener(OnSmoothnessChanged);
			_metallicSlider.minValue = 0f;
			_metallicSlider.maxValue = 100f;
			_metallicSlider.wholeNumbers = true;
			_metallicSlider.onValueChanged.AddListener(OnMetallicChanged);
			_emissionSlider.minValue = 0f;
			_emissionSlider.maxValue = 250f;
			_emissionSlider.wholeNumbers = true;
			_emissionSlider.onValueChanged.AddListener(OnEmissionChanged);
			_detailSlider.minValue = 0f;
			_detailSlider.maxValue = 25f;
			_detailSlider.wholeNumbers = true;
			_detailSlider.onValueChanged.AddListener(OnDetailChanged);
			_transparencySlider.minValue = 0f;
			_transparencySlider.maxValue = 100f;
			_transparencySlider.wholeNumbers = true;
			_transparencySlider.onValueChanged.AddListener(OnTransparencyChanged);
		}

		private void OnDetailChanged(float value)
		{
			if (_selectedColor != null)
			{
				_styleSpinner.Value = "Custom";
				_selectedColor.PartMaterial.DetailStrength = value * 0.1f;
				_detailSliderLabel.text = $"{value * 10f:N0}%";
				UpdateSelectedButton(transparencyChanged: false);
			}
		}

		private void OnEmissionChanged(float value)
		{
			if (_selectedColor != null)
			{
				_styleSpinner.Value = "Custom";
				_selectedColor.PartMaterial.EmissionStrength = value * 0.01f;
				_emissionSliderLabel.text = $"{value:N0}%";
				UpdateSelectedButton(transparencyChanged: false);
			}
		}

		private void OnNameChanged(string name)
		{
			if (_selectedColor != null)
			{
				_styleSpinner.Value = "Custom";
				_selectedColor.PartMaterial.Name = name;
				UpdateSelectedButton(transparencyChanged: false);
			}
		}

		private void OnMetallicChanged(float value)
		{
			if (_selectedColor != null)
			{
				_styleSpinner.Value = "Custom";
				_selectedColor.PartMaterial.Metallic = value / 100f;
				_metallicSliderLabel.text = $"{value:N0}%";
				UpdateSelectedButton(transparencyChanged: false);
			}
		}

		private void OnSmoothnessChanged(float value)
		{
			if (_selectedColor != null)
			{
				_styleSpinner.Value = "Custom";
				_selectedColor.PartMaterial.Smoothness = value / 100f;
				_smoothnessSliderLabel.text = $"{value:N0}%";
				UpdateSelectedButton(transparencyChanged: false);
			}
		}

		private void OnStyleChanged(string styleName)
		{
			bool transparencyChanged = false;
			if (styleName != "Custom")
			{
				PartMaterial partMaterial = _selectedColor.PartMaterial;
				partMaterial.Smoothness = ColorStyles.GetSmoothnessValue(styleName);
				partMaterial.Metallic = ColorStyles.GetMetallicValue(styleName);
				partMaterial.EmissionStrength = 0f;
				partMaterial.DetailStrength = 1f;
				transparencyChanged = partMaterial.TransparencyStrength != 0f;
				partMaterial.TransparencyStrength = 0f;
			}
			RefreshStyle(styleName);
			UpdateSelectedButton(transparencyChanged);
		}

		private void OnTransparencyChanged(float value)
		{
			if (_selectedColor != null)
			{
				float num = value / 100f;
				float transparencyStrength = _selectedColor.PartMaterial.TransparencyStrength;
				bool transparencyChanged = num != transparencyStrength && (transparencyStrength == 0f || num == 0f);
				_styleSpinner.Value = "Custom";
				_selectedColor.PartMaterial.TransparencyStrength = num;
				_transparencySliderLabel.text = $"{value:N0}%";
				UpdateSelectedButton(transparencyChanged);
			}
		}

		private void RefreshColorPickers(Color color)
		{
			ColorGradient.Shade shade = _hueColorPicker.SelectClosestShade(color);
			_shadeColorPicker.SetColorGradient(shade.ColorGradient);
			_shadeColorPicker.SelectClosestShade(color);
		}

		private void RefreshStyle(string styleName)
		{
			_styleSpinner.Value = styleName;
			bool flag = styleName == "Custom";
			_smoothnessSlider.transform.parent.gameObject.SetActive(flag);
			_metallicSlider.transform.parent.gameObject.SetActive(flag);
			_emissionSlider.transform.parent.gameObject.SetActive(flag);
			_detailSlider.transform.parent.gameObject.SetActive(flag);
			bool value = Game.Instance.Settings.Game.Designer.UnlockTransparencySlider.Value;
			_unlockTransparencyButton.SetActive(flag && !value);
			_transparencySlider.transform.parent.gameObject.SetActive(flag && value);
			PartMaterial partMaterial = _selectedColor.PartMaterial;
			_colorNameInput.text = partMaterial.Name;
			if (flag)
			{
				_smoothnessSlider.value = partMaterial.Smoothness * 100f;
				_metallicSlider.value = partMaterial.Metallic * 100f;
				_emissionSlider.value = partMaterial.EmissionStrength * 100f;
				_detailSlider.value = partMaterial.DetailStrength * 10f;
				_transparencySlider.value = partMaterial.TransparencyStrength * 100f;
			}
		}

		private void ShadeSelected(ColorPickerScript colorPickerScript, ColorGradient.Shade shade)
		{
			UpdateSelectedButtonColor(shade.Color);
		}

		private void UpdateSelectedButton(bool transparencyChanged)
		{
			_selectedColor.Refresh();
			this.ColorUpdated?.Invoke(_selectedColor, transparencyChanged);
		}

		private void UpdateSelectedButtonColor(Color color)
		{
			if (_selectedColor != null)
			{
				_selectedColor.PartMaterial.Color = color;
				UpdateSelectedButton(transparencyChanged: false);
			}
		}

		private char OnValidateInput(string text, int charIndex, char addedChar)
		{
			if (_invalidCharacters.Contains(addedChar))
			{
				return '\0';
			}
			return addedChar;
		}
	}
}
