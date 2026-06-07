using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Paint;
using Assets.Scripts.Design.Tools;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Assets.Scripts.UI.Dialogs;
using Jundroo.Common.Collections;
using Jundroo.Common.DataTypes;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI.Paint
{
	public class PaintPanelScript : DesignerPanelScript
	{
		private class ColorPickerButton
		{
			public ButtonWidget Button { get; }

			public int Index { get; }

			public TextWidget Label { get; }

			public Widget RootWidget { get; }

			public ColorPickerButton(PaintPanelScript paintPanel, int buttonIndex)
			{
				ColorPickerButton colorPickerButton = this;
				RootWidget = paintPanel.Widget.FindWidget($"color-picker-button-{buttonIndex}");
				Label = RootWidget.FindWidget<TextWidget>("label");
				Button = RootWidget.FindWidget<ButtonWidget>("button");
				Index = buttonIndex;
				Button.Clicked += delegate(Widget w)
				{
					paintPanel.OnColorPickerButtonClicked(w, colorPickerButton.Index);
				};
			}
		}

		private static bool _materialPropertiesHeaderCollapsed = true;

		private static bool _textureSettingsHeaderCollapsed = true;

		private Widget _colorButtonPanel;

		private List<ColorButtonScript> _colorButtons;

		private ColorPickerButton[] _colorPickerButtons;

		private Widget _colorPickerPanel;

		private SliderControl _emissionDaySlider;

		private SliderControl _emissionNightSlider;

		private SpinnerControl _finishSpinner;

		private bool _initialized;

		private SliderControl _metallicSlider;

		private InputWidget _nameInput;

		private TexturePickerScript _picker;

		private ButtonWidget _presetResetButton;

		private EnumDictionary<PaintStyle, Dictionary<string, Dictionary<string, PaintTexturePreset>>> _presets;

		private string _previouslySelectedTexture;

		private EnumDictionary<PaintStyle, string> _previouslySelectedTexturePerStyle;

		private ColorButtonScript _selectedColorButton;

		private EnumDictionary<PaintStyle, Dictionary<string, string>> _selectedPresets;

		private SliderControl _smoothnessSlider;

		private EnumSpinnerControl<PaintStyle> _styleSpinner;

		private int _targetLevel = -2;

		private SpinnerControl _targetSpinner;

		private SliderControl _textureBlendSlider;

		private Widget _textureButton;

		private Widget _textureButtonRow;

		private (string Id, PaintColorData[] Colors) _textureChangePresetIdAndColor = (Id: null, Colors: new PaintColorData[4]);

		private VectorControl<Vector3> _textureOffsetInput;

		private SpinnerControl<PaintTexturePreset> _texturePresetSpinner;

		private TexturePreviewScript _texturePreviewImage;

		private VectorControl<Vector3> _textureRotationInput;

		private VectorControl<Vector3> _textureScaleInput;

		private Widget _textureSettingsHeader;

		private EnumSpinnerControl<PaintTextureWrapMode> _textureWrapXSpinner;

		private EnumSpinnerControl<PaintTextureWrapMode> _textureWrapYSpinner;

		private EnumSpinnerControl<PaintTextureWrapMode> _textureWrapZSpinner;

		private SpinnerControl _themeSpinner;

		public ColorButtonScript SelectedColorButton
		{
			get
			{
				return _selectedColorButton;
			}
			private set
			{
				if (_selectedColorButton != null)
				{
					_selectedColorButton.Selected = false;
				}
				_selectedColorButton = value;
				if (_selectedColorButton != null)
				{
					_selectedColorButton.Selected = true;
					StartColorTool(_selectedColorButton.MaterialId, _targetLevel);
					if (ThemeName == "Custom")
					{
						_colorPickerPanel.Visible = true;
					}
					else
					{
						_colorPickerPanel.Visible = false;
					}
				}
				else
				{
					_colorPickerPanel.Visible = false;
				}
			}
		}

		public string ThemeName
		{
			get
			{
				return _themeSpinner.Value;
			}
			set
			{
				_themeSpinner.Value = value;
			}
		}

		public void ColorButtonClicked(ColorButtonScript colorButton)
		{
			SelectedColorButton = colorButton;
			if (_colorPickerPanel.Visible)
			{
				ClearPreviouslySelectedTextures();
				RefreshUI(colorButton.PartMaterial);
			}
		}

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
			base.Designer.CraftLoaded += OnCraftLoaded;
		}

		public void StartColorTool(int partMaterialId, int partMaterialLevel)
		{
			base.Designer.Tools.ColorTool.PartMaterialId = partMaterialId;
			base.Designer.Tools.ColorTool.PartMaterialLevel = partMaterialLevel;
		}

		protected virtual void Start()
		{
			_colorPickerPanel = base.Widget.FindWidget("color-picker-panel");
			_colorPickerPanel.Visible = false;
			_colorButtonPanel = base.Widget.FindWidget("color-button-parent");
			_targetSpinner = new SpinnerControl(base.Widget.FindWidget("spinner-target"));
			_targetSpinner.OnValueChanged = delegate
			{
				OnTargetLevelChanged();
			};
			_themeSpinner = new SpinnerControl(base.Widget.FindWidget("spinner-theme"));
			_themeSpinner.OnValueChanged = delegate(string _, string s)
			{
				UpdateTheme(s, applyToAircraft: true);
			};
			_styleSpinner = new EnumSpinnerControl<PaintStyle>(base.Widget.FindWidget("spinner-style"));
			_styleSpinner.OnValueChanged = OnStyleChanged;
			_textureButtonRow = base.Widget.FindWidget("texture-button-row");
			_textureButton = base.Widget.FindWidget("texture-button");
			_textureButton.Clicked += OnTextureButtonClicked;
			RawImageWidget rawImageWidget = base.Widget.FindWidget<RawImageWidget>("texture-preview");
			_texturePreviewImage = rawImageWidget.gameObject.AddComponent<TexturePreviewScript>();
			_texturePreviewImage.InitializeMaterial(null);
			_texturePresetSpinner = new SpinnerControl<PaintTexturePreset>(base.Widget.FindWidget("spinner-texture-preset"), (PaintTexturePreset x) => x?.DisplayName, PaintTexturePreset.EqualityComparerById);
			_texturePresetSpinner.OnValueChanged = OnTexturePresetChanged;
			_presetResetButton = _texturePresetSpinner.Widget.FindWidget<ButtonWidget>("extra-button");
			_presetResetButton.Clicked += OnPresetResetButtonClicked;
			_colorPickerButtons = new ColorPickerButton[5];
			for (int num = 0; num < _colorPickerButtons.Length; num++)
			{
				_colorPickerButtons[num] = new ColorPickerButton(this, num);
			}
			_finishSpinner = new SpinnerControl(base.Widget.FindWidget("spinner-finish"));
			_finishSpinner.OnValueChanged = delegate(string _, string s)
			{
				OnFinishChanged(s);
			};
			_nameInput = base.Widget.FindWidget<InputWidget>("name-input");
			_metallicSlider = new SliderControl(base.Widget.FindWidget("slider-metallic"));
			_smoothnessSlider = new SliderControl(base.Widget.FindWidget("slider-smoothness"));
			_emissionDaySlider = new SliderControl(base.Widget.FindWidget("slider-emission-day"));
			_emissionNightSlider = new SliderControl(base.Widget.FindWidget("slider-emission-night"));
			_textureBlendSlider = new SliderControl(base.Widget.FindWidget("slider-texture-blend"));
			_nameInput.Input.onValueChanged.AddListener(delegate(string x)
			{
				OnNameChanged(x);
			});
			_metallicSlider.Slider.ValueChanged += delegate(float x)
			{
				OnMetallicChanged(x);
			};
			_smoothnessSlider.Slider.ValueChanged += delegate(float x)
			{
				OnSmoothnessChanged(x);
			};
			_emissionDaySlider.Slider.ValueChanged += delegate(float x)
			{
				OnEmissionDayChanged(x);
			};
			_emissionNightSlider.Slider.ValueChanged += delegate(float x)
			{
				OnEmissionNightChanged(x);
			};
			_textureBlendSlider.Slider.ValueChanged += delegate(float x)
			{
				OnTextureBlendChanged(x);
			};
			_metallicSlider.ValueFormatter = SliderControl.PercentageFormatter;
			_smoothnessSlider.ValueFormatter = SliderControl.PercentageFormatter;
			_emissionDaySlider.ValueFormatter = SliderControl.PercentageFormatter;
			_emissionNightSlider.ValueFormatter = SliderControl.PercentageFormatter;
			_textureBlendSlider.ValueFormatter = SliderControl.PercentageFormatter;
			_metallicSlider.SetRange(0f, 1f, 101);
			_smoothnessSlider.SetRange(0f, 1f, 101);
			_emissionDaySlider.SetRange(0f, 5f, 101);
			_emissionNightSlider.SetRange(0f, 5f, 101);
			_textureBlendSlider.SetRange(0f, 1f, 101);
			_textureSettingsHeader = base.Widget.FindWidget("header-texture-settings");
			_textureOffsetInput = new VectorControl<Vector3>(base.Widget.FindWidget("input-texture-offset"));
			_textureRotationInput = new VectorControl<Vector3>(base.Widget.FindWidget("input-texture-rotation"));
			_textureScaleInput = new VectorControl<Vector3>(base.Widget.FindWidget("input-texture-scale"));
			_textureOffsetInput.StepValue = 0.1m;
			_textureRotationInput.StepValue = 5m;
			_textureScaleInput.StepValue = 0.1m;
			VectorControl<Vector3> textureOffsetInput = _textureOffsetInput;
			textureOffsetInput.OnValueChanged = (Action<Vector3>)Delegate.Combine(textureOffsetInput.OnValueChanged, new Action<Vector3>(OnTextureOffsetChanged));
			VectorControl<Vector3> textureRotationInput = _textureRotationInput;
			textureRotationInput.OnValueChanged = (Action<Vector3>)Delegate.Combine(textureRotationInput.OnValueChanged, new Action<Vector3>(OnTextureRotationChanged));
			VectorControl<Vector3> textureScaleInput = _textureScaleInput;
			textureScaleInput.OnValueChanged = (Action<Vector3>)Delegate.Combine(textureScaleInput.OnValueChanged, new Action<Vector3>(OnTextureScaleChanged));
			_textureWrapXSpinner = new EnumSpinnerControl<PaintTextureWrapMode>(base.Widget.FindWidget("spinner-texture-wrap-x"));
			_textureWrapYSpinner = new EnumSpinnerControl<PaintTextureWrapMode>(base.Widget.FindWidget("spinner-texture-wrap-y"));
			_textureWrapZSpinner = new EnumSpinnerControl<PaintTextureWrapMode>(base.Widget.FindWidget("spinner-texture-wrap-z"));
			EnumSpinnerControl<PaintTextureWrapMode> textureWrapXSpinner = _textureWrapXSpinner;
			textureWrapXSpinner.OnValueChanged = (OnValueChanged<PaintTextureWrapMode>)Delegate.Combine(textureWrapXSpinner.OnValueChanged, (OnValueChanged<PaintTextureWrapMode>)delegate(PaintTextureWrapMode _, PaintTextureWrapMode x)
			{
				OnTextureWrapChanged(x, 0);
			});
			EnumSpinnerControl<PaintTextureWrapMode> textureWrapYSpinner = _textureWrapYSpinner;
			textureWrapYSpinner.OnValueChanged = (OnValueChanged<PaintTextureWrapMode>)Delegate.Combine(textureWrapYSpinner.OnValueChanged, (OnValueChanged<PaintTextureWrapMode>)delegate(PaintTextureWrapMode _, PaintTextureWrapMode x)
			{
				OnTextureWrapChanged(x, 1);
			});
			EnumSpinnerControl<PaintTextureWrapMode> textureWrapZSpinner = _textureWrapZSpinner;
			textureWrapZSpinner.OnValueChanged = (OnValueChanged<PaintTextureWrapMode>)Delegate.Combine(textureWrapZSpinner.OnValueChanged, (OnValueChanged<PaintTextureWrapMode>)delegate(PaintTextureWrapMode _, PaintTextureWrapMode x)
			{
				OnTextureWrapChanged(x, 2);
			});
			ToggleControl toggleControl = new ToggleControl(base.Widget.FindWidget("toggle-preview"));
			toggleControl.Toggle.IsOn = base.Designer.Tools.ColorTool.PreviewEnabled;
			toggleControl.Toggle.ValueChanged += delegate(bool x)
			{
				base.Designer.Tools.ColorTool.PreviewEnabled = x;
			};
			_colorButtons = new List<ColorButtonScript>();
			_previouslySelectedTexture = null;
			_previouslySelectedTexturePerStyle = new EnumDictionary<PaintStyle, string>();
			InitializeThemes();
			_initialized = true;
			if (base.Designer.Aircraft != null)
			{
				OnCraftLoaded();
			}
			base.Designer.Tools.SelectedToolChanged += OnSelectedToolChanged;
			InitializeHeaders();
		}

		private void ApplyChangesToCraft()
		{
			_texturePreviewImage?.UpdateMaterial();
			_selectedColorButton?.UpdateMaterial();
			base.DesignerUI.DesignerScript.Aircraft.Theme.UpdateMaterials();
			base.DesignerUI.DesignerScript.OnThemeUpdated();
		}

		private void ClearPreviouslySelectedTextures()
		{
			_previouslySelectedTexture = null;
			foreach (PaintStyle key in _previouslySelectedTexturePerStyle.Keys)
			{
				_previouslySelectedTexturePerStyle[key] = null;
			}
		}

		private void CloseTexturePicker()
		{
			_picker?.Flyout.Close();
		}

		private void CreateUndoStep(string text, PartMaterial mat)
		{
			base.Designer.CreateUndoStep(text, $"{text}-{mat?.Id}");
		}

		private void DestroyPicker()
		{
			if (_picker != null)
			{
				_picker.TextureSelected -= OnTextureSelected;
				_picker.Flyout.Closed -= OnTexturePickerClosed;
				_picker.Flyout.Widget.Destroy();
				_picker = null;
			}
		}

		private PaintTexturePreset GetActivePreset(PartMaterial partMaterial)
		{
			if (partMaterial.Texture != null && !string.IsNullOrEmpty(partMaterial.TexturePresetId) && _presets[partMaterial.Style].TryGetValue(partMaterial.Texture.Id, out var value) && value.TryGetValue(partMaterial.TexturePresetId, out var value2))
			{
				return value2;
			}
			return null;
		}

		private IPaintTexturePreset GetActivePresetOriginal(PartMaterial partMaterial)
		{
			if (partMaterial.Texture != null && partMaterial.TexturePresetId != null)
			{
				return partMaterial.Texture.FindPreset(partMaterial.TexturePresetId);
			}
			return null;
		}

		private string GetPreviouslySelectedTexture(PaintStyle style)
		{
			IReadOnlyCollection<string> textureIds = Game.Instance.PaintTextureManager.GetTextureIds(style);
			string previouslySelectedTexture = _previouslySelectedTexture;
			if (!string.IsNullOrEmpty(previouslySelectedTexture) && textureIds.Contains(previouslySelectedTexture))
			{
				return previouslySelectedTexture;
			}
			previouslySelectedTexture = _previouslySelectedTexturePerStyle[style];
			if (!string.IsNullOrEmpty(previouslySelectedTexture) && textureIds.Contains(previouslySelectedTexture))
			{
				return previouslySelectedTexture;
			}
			return textureIds.FirstOrDefault();
		}

		private void InitializeHeaders()
		{
			HeaderScript component = _textureSettingsHeader.GetComponent<HeaderScript>();
			component.Collapsed = _textureSettingsHeaderCollapsed;
			component.CollapsedStateChanged += delegate(object w, HeaderScript.CollapsedStateChangedEventArgs e)
			{
				_textureSettingsHeaderCollapsed = e.IsCollapsed;
			};
			HeaderScript component2 = base.Widget.FindWidget("header-material-properties").GetComponent<HeaderScript>();
			component2.Collapsed = _materialPropertiesHeaderCollapsed;
			component2.CollapsedStateChanged += delegate(object w, HeaderScript.CollapsedStateChangedEventArgs e)
			{
				_materialPropertiesHeaderCollapsed = e.IsCollapsed;
			};
		}

		private void InitializeThemes()
		{
			foreach (ThemeData theme in Game.Instance.AircraftThemes.Themes)
			{
				if (!theme.Hidden)
				{
					_themeSpinner.Values.Add(theme.Name);
				}
			}
			_finishSpinner.Values.Add("Flat");
			_finishSpinner.Values.Add("Semi-Gloss");
			_finishSpinner.Values.Add("Gloss");
			_targetSpinner.Values.Add("Auto");
			_targetSpinner.Values.Add("All");
			_targetSpinner.Values.Add("Primary");
			_targetSpinner.Values.Add("Trim 1");
			_targetSpinner.Values.Add("Trim 2");
			_targetSpinner.Values.Add("Trim 3");
			_targetSpinner.Values.Add("Trim 4");
			_targetSpinner.Values.Add("Trim 5");
			_targetSpinner.Values.Add("Trim 6");
			_targetSpinner.Values.Add("Trim 7");
			_targetSpinner.Values.Add("Trim 8");
			_targetSpinner.Values.Add("Trim 9");
			_targetSpinner.Values.Add("Trim 10");
			_targetSpinner.Value = "Auto";
			_presets = new EnumDictionary<PaintStyle, Dictionary<string, Dictionary<string, PaintTexturePreset>>>();
			_selectedPresets = new EnumDictionary<PaintStyle, Dictionary<string, string>>();
			PaintTextureManager paintTextureManager = Game.Instance.PaintTextureManager;
			foreach (PaintStyle key in _presets.Keys)
			{
				_presets[key] = new Dictionary<string, Dictionary<string, PaintTexturePreset>>();
				_selectedPresets[key] = new Dictionary<string, string>();
				foreach (PaintTextureData textureDatum in paintTextureManager.GetTextureData(key))
				{
					Dictionary<string, PaintTexturePreset> dictionary = new Dictionary<string, PaintTexturePreset>();
					_presets[key].Add(textureDatum.Id, dictionary);
					foreach (IPaintTexturePreset preset in textureDatum.Presets)
					{
						dictionary.Add(preset.Id, preset.Clone());
					}
				}
			}
		}

		private bool IsColorDataEqual(IReadOnlyList<IPaintColorData> a, IReadOnlyList<IPaintColorData> b, int? count)
		{
			int num = count ?? a.Count;
			if (a.Count < num || b.Count < num)
			{
				return false;
			}
			for (int i = 0; i < num; i++)
			{
				if (!a[i].IsEqual(b[i]))
				{
					return false;
				}
			}
			return true;
		}

		private void OnColorPickerButtonClicked(Widget widget, int buttonIndex)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				ColorPickerDialogScript colorPickerDialogScript = Game.Instance.UserInterface.CreateColorPickerDialog();
				PaintColorData paintColorData = partMaterial.ColorData[Math.Max(buttonIndex - 1, 0)];
				colorPickerDialogScript.AdjustedColor = paintColorData.Color;
				PaintTextureData texture = partMaterial.Texture;
				if (texture != null && texture.ColorCount > 1)
				{
					colorPickerDialogScript.ShowMaterialProperties = true;
					colorPickerDialogScript.InitializeMaterialProperties(paintColorData.Metallic, partMaterial.Metallic, paintColorData.Smoothness, partMaterial.Smoothness, paintColorData.EmissionDay, paintColorData.EmissionNight, partMaterial.EmissionDay, partMaterial.EmissionNight);
				}
				colorPickerDialogScript.ColorChanged += delegate(ColorPickerDialogScript x)
				{
					UpdateColorsFromColorPickerDialog(x, buttonIndex);
				};
				colorPickerDialogScript.MaterialPropertiesChanged += delegate(ColorPickerDialogScript x)
				{
					UpdateColorsFromColorPickerDialog(x, buttonIndex);
				};
			}
		}

		private void OnCraftLoaded()
		{
			if (_initialized)
			{
				UpdateTheme(base.Designer.Aircraft.Theme.Theme.Name, applyToAircraft: false);
			}
		}

		private void OnEmissionDayChanged(float value)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.EmissionDay = value;
				ApplyChangesToCraft();
			}
		}

		private void OnEmissionNightChanged(float value)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.EmissionNight = value;
				ApplyChangesToCraft();
			}
		}

		private void OnFinishChanged(string finishName)
		{
			if (SelectedColorButton != null)
			{
				PartMaterial partMaterial = SelectedColorButton.PartMaterial;
				partMaterial.Metallic = PaintFinishes.GetMetallicValue(finishName);
				partMaterial.Smoothness = PaintFinishes.GetSmoothnessValue(finishName);
				RefreshUI(partMaterial);
				ApplyChangesToCraft();
			}
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			CloseTexturePicker();
			SelectedColorButton = null;
			if (base.Designer.Tools.SelectedTool == base.Designer.Tools.ColorTool)
			{
				base.Designer.Tools.SelectTool(base.Designer.Tools.MovePartTool);
			}
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			if (base.Designer.Tools.SelectedTool != base.Designer.Tools.ColorTool)
			{
				base.Designer.Tools.SelectTool(base.Designer.Tools.ColorTool);
			}
		}

		private void OnMetallicChanged(float value)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.Metallic = value;
				UpdateFinishSpinner(partMaterial);
				ApplyChangesToCraft();
			}
		}

		private void OnNameChanged(string name)
		{
			SelectedColorButton.PartMaterial.Name = name;
		}

		private void OnPresetResetButtonClicked(Widget widget)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				IPaintTexturePreset paintTexturePreset = partMaterial.Texture?.FindPreset(partMaterial.TexturePresetId ?? string.Empty);
				if (paintTexturePreset == null)
				{
					Debug.LogError("Unable to find the original preset from which to restore color data.");
					return;
				}
				paintTexturePreset.ApplyPreset(partMaterial.ColorData);
				RefreshUI(partMaterial);
				ApplyChangesToCraft();
			}
		}

		private void OnSelectedToolChanged(object sender, ToolChangedEventArgs e)
		{
			if (base.Flyout.IsOpen && e.OldTool == base.Designer.Tools.ColorTool && e.NewTool != base.Designer.Tools.ColorTool)
			{
				base.Flyout.Close();
			}
		}

		private void OnSmoothnessChanged(float value)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.Smoothness = value;
				_finishSpinner.Value = PaintFinishes.GetFinishName(partMaterial.Metallic, partMaterial.Smoothness);
				ApplyChangesToCraft();
			}
		}

		private void OnStyleChanged(PaintStyle previousStyle, PaintStyle style)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				string previouslySelectedTexture = GetPreviouslySelectedTexture(style);
				OnStyleOrTextureChanged(partMaterial, style, previouslySelectedTexture);
				CreateUndoStep("Changed paint style", partMaterial);
			}
		}

		private void OnStyleOrTextureChanged(PartMaterial partMaterial, PaintStyle style, string textureId)
		{
			IPaintTexturePreset activePresetOriginal = GetActivePresetOriginal(partMaterial);
			_textureChangePresetIdAndColor.Id = activePresetOriginal?.Id;
			PaintColorData[] item = _textureChangePresetIdAndColor.Colors;
			if (activePresetOriginal != null && partMaterial.Texture != null)
			{
				for (int i = 0; i < partMaterial.Texture.ColorCount; i++)
				{
					item[i] = (partMaterial.ColorData[i].IsEqual(activePresetOriginal.Colors[i]) ? null : partMaterial.ColorData[i].Clone());
				}
			}
			else
			{
				item[0] = null;
				item[1] = null;
				item[2] = null;
				item[3] = null;
			}
			partMaterial.Style = style;
			partMaterial.Texture = Game.Instance.PaintTextureManager.GetTextureData(style, textureId);
			SelectAndApplyPreset(partMaterial, null);
			RefreshUI(partMaterial);
			ApplyChangesToCraft();
		}

		private void OnTargetLevelChanged()
		{
			int indexOfValue = _targetSpinner.Values.GetIndexOfValue(_targetSpinner.Value);
			if (indexOfValue == -1)
			{
				_targetLevel = -1;
			}
			else
			{
				_targetLevel = indexOfValue - 2;
			}
			if (_selectedColorButton != null)
			{
				StartColorTool(_selectedColorButton.MaterialId, _targetLevel);
			}
		}

		private void OnTextureBlendChanged(float value)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.TextureBlend = value;
				ApplyChangesToCraft();
			}
		}

		private void OnTextureButtonClicked(Widget widget)
		{
			PartMaterial mat = SelectedColorButton?.PartMaterial;
			PaintTextureManager ptm = Game.Instance.PaintTextureManager;
			IReadOnlyList<PaintTextureData> textureData = ptm.GetTextureData(mat.Style);
			List<TexturePickerItem> list = new List<TexturePickerItem>();
			foreach (PaintTextureData item in textureData)
			{
				list.Add(new TexturePickerItem(item.Id, () => (Texture2D)null, item.Category, item.DisplayName));
			}
			DestroyPicker();
			_picker = Game.Instance.UserInterface.CreateTexturePickerFlyout(list, mat.Texture?.Id);
			_picker.LargePreviews = true;
			_picker.OnTextureButtonCreated = delegate(TextureButtonScript button)
			{
				TexturePreviewScript texturePreviewScript = button.RawImage.gameObject.AddComponent<TexturePreviewScript>();
				PaintTextureData textureData2 = ptm.GetTextureData(mat.Style, button.TextureItem?.Id);
				texturePreviewScript.InitializeMaterial(mat);
				texturePreviewScript.Texture = textureData2;
			};
			_picker.Flyout.Show(show: true);
			_picker.TextureSelected += OnTextureSelected;
			_picker.Flyout.Closed += OnTexturePickerClosed;
		}

		private void OnTextureOffsetChanged(Vector3 vector)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.TextureOffset = vector;
				ApplyChangesToCraft();
			}
		}

		private void OnTexturePickerClosed(IFlyout flyout)
		{
			DestroyPicker();
		}

		private void OnTexturePresetChanged(PaintTexturePreset oldValue, PaintTexturePreset newValue)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				SelectAndApplyPreset(partMaterial, newValue);
				RefreshUI(partMaterial);
				ApplyChangesToCraft();
			}
		}

		private void OnTextureRotationChanged(Vector3 vector)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.TextureRotation = vector;
				ApplyChangesToCraft();
			}
		}

		private void OnTextureScaleChanged(Vector3 vector)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.TextureScale = vector;
				ApplyChangesToCraft();
			}
		}

		private void OnTextureSelected(object sender, TexturePickerScript.TextureSelectedEventArgs e)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				PaintStyle value = _styleSpinner.Value;
				SavePreviouslySelectedTexture(value, e.TextureItem.Id);
				OnStyleOrTextureChanged(partMaterial, value, e.TextureItem.Id);
				_texturePreviewImage.InitializeMaterial(partMaterial);
				_texturePreviewImage.UpdateMaterial();
				CreateUndoStep("Changed paint texture", partMaterial);
			}
		}

		private void OnTextureWrapChanged(PaintTextureWrapMode value, int axis)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial != null)
			{
				partMaterial.TextureWrapMode[axis] = value;
				ApplyChangesToCraft();
				CreateUndoStep("Changed paint texture wrap mode", partMaterial);
			}
		}

		private void RefreshPresetSpinner(PartMaterial partMaterial)
		{
			if (partMaterial.Style.UsesTextureAtlas() && partMaterial.Texture != null)
			{
				IPaintTexturePreset paintTexturePreset = partMaterial.Texture.FindPreset(partMaterial.TexturePresetId ?? string.Empty);
				_texturePresetSpinner.Visible = partMaterial.Texture.Presets.Count > 1;
				_presetResetButton.Visible = _texturePresetSpinner.Visible && paintTexturePreset != null && paintTexturePreset.Id != "custom" && !IsColorDataEqual(paintTexturePreset.Colors, partMaterial.ColorData, partMaterial.Texture.ColorCount);
			}
			else
			{
				_texturePresetSpinner.Visible = false;
				_presetResetButton.Visible = false;
			}
		}

		private void RefreshUI(PartMaterial selectedMaterial)
		{
			_styleSpinner.Value = selectedMaterial.Style;
			_texturePreviewImage.InitializeMaterial(selectedMaterial);
			_texturePreviewImage.UpdateMaterial();
			_textureButton.Tooltip = selectedMaterial.Texture?.DisplayName;
			_texturePresetSpinner.Values.Clear();
			_presets[selectedMaterial.Style].TryGetValue(selectedMaterial.Texture?.Id ?? string.Empty, out var value);
			Jundroo.Common.Collections.CircularList<PaintTexturePreset> values = _texturePresetSpinner.Values;
			IEnumerable<PaintTexturePreset> enumerable = value?.Values;
			values.AddRange(enumerable ?? new PaintTexturePreset[0]);
			PaintTexturePreset value2;
			PaintTexturePreset paintTexturePreset = ((value != null && value.TryGetValue(selectedMaterial.TexturePresetId ?? string.Empty, out value2)) ? value2 : value?.Values.LastOrDefault());
			_texturePresetSpinner.Value = paintTexturePreset;
			paintTexturePreset?.UpdatePreset(selectedMaterial.ColorData);
			if (selectedMaterial.Texture != null)
			{
				_selectedPresets[selectedMaterial.Style][selectedMaterial.Texture.Id] = paintTexturePreset.Id;
			}
			bool flag = selectedMaterial.Style.UsesTextureAtlas() && selectedMaterial.Texture != null;
			int num = selectedMaterial.Texture?.ColorCount ?? 0;
			_colorPickerButtons[0].RootWidget.Visible = !flag;
			_colorPickerButtons[0].Button.Color.Base = selectedMaterial.ColorData[0].Color;
			for (int i = 1; i <= 4; i++)
			{
				_colorPickerButtons[i].RootWidget.Visible = flag && i <= num;
				_colorPickerButtons[i].Button.Color.Base = selectedMaterial.ColorData[i - 1].Color;
			}
			_finishSpinner.Value = PaintFinishes.GetFinishName(selectedMaterial.Metallic, selectedMaterial.Smoothness);
			_nameInput.Input.text = selectedMaterial.Name;
			_metallicSlider.Slider.Value = selectedMaterial.Metallic;
			_smoothnessSlider.Slider.Value = selectedMaterial.Smoothness;
			_emissionDaySlider.Slider.Value = selectedMaterial.EmissionDay;
			_emissionNightSlider.Slider.Value = selectedMaterial.EmissionNight;
			_textureBlendSlider.Slider.Value = selectedMaterial.TextureBlend;
			_textureOffsetInput.Value = selectedMaterial.TextureOffset;
			_textureRotationInput.Value = selectedMaterial.TextureRotation;
			_textureScaleInput.Value = selectedMaterial.TextureScale;
			_textureWrapXSpinner.Value = selectedMaterial.TextureWrapMode[0];
			_textureWrapYSpinner.Value = selectedMaterial.TextureWrapMode[1];
			_textureWrapZSpinner.Value = selectedMaterial.TextureWrapMode[2];
			RefreshPresetSpinner(selectedMaterial);
			if (selectedMaterial.Style.UsesTextureAtlas())
			{
				_textureButtonRow.Visible = true;
				_textureSettingsHeader.Visible = true;
				_texturePresetSpinner.Visible = (selectedMaterial.Texture?.Presets.Count ?? 0) > 1;
				bool flag2 = selectedMaterial.Style == PaintStyle.TriPlaneTextureColorMask;
				_textureBlendSlider.Visible = flag2;
				_textureWrapXSpinner.Visible = !flag2;
				_textureWrapYSpinner.Visible = false;
				_textureWrapZSpinner.Visible = !flag2;
				_textureOffsetInput.Visible = true;
				_textureRotationInput.Visible = true;
				_textureScaleInput.Visible = true;
				_textureOffsetInput.SetComponentVisibility(1, flag2);
				_textureScaleInput.SetComponentVisibility(1, flag2);
			}
			else
			{
				_textureButtonRow.Visible = false;
				_textureSettingsHeader.Visible = false;
				_textureBlendSlider.Visible = false;
				_textureWrapXSpinner.Visible = false;
				_textureWrapYSpinner.Visible = false;
				_textureWrapZSpinner.Visible = false;
				_textureOffsetInput.Visible = false;
				_textureRotationInput.Visible = false;
				_textureScaleInput.Visible = false;
			}
		}

		private void SavePreviouslySelectedTexture(PaintStyle style, string textureId)
		{
			_previouslySelectedTexture = textureId;
			_previouslySelectedTexturePerStyle[style] = textureId;
		}

		private void SelectAndApplyPreset(PartMaterial partMaterial, PaintTexturePreset preset)
		{
			if (preset == null)
			{
				string text = partMaterial.Texture?.Id;
				if (text != null && _presets[partMaterial.Style].TryGetValue(text, out var value))
				{
					if (partMaterial.TexturePresetId != null && value.TryGetValue(partMaterial.TexturePresetId, out var value2))
					{
						preset = value2;
					}
					if (preset == null && _selectedPresets[partMaterial.Style].TryGetValue(text, out var value3))
					{
						preset = (value.TryGetValue(value3, out var value4) ? value4 : null);
					}
					if (preset == null)
					{
						preset = value.Values.LastOrDefault();
					}
					if (preset != null)
					{
						IPaintTexturePreset paintTexturePreset = partMaterial?.Texture.FindPreset(preset.Id);
						if (preset.Id == _textureChangePresetIdAndColor.Id && paintTexturePreset != null)
						{
							for (int i = 0; i < 4; i++)
							{
								IPaintColorData paintColorData2;
								if (_textureChangePresetIdAndColor.Colors[i] != null)
								{
									IPaintColorData paintColorData = _textureChangePresetIdAndColor.Colors[i];
									paintColorData2 = paintColorData;
								}
								else
								{
									paintColorData2 = paintTexturePreset.Colors[i];
								}
								paintColorData2.CopyTo(preset.Colors[i]);
							}
						}
					}
				}
			}
			partMaterial.TexturePresetId = preset?.Id;
			if (preset != null)
			{
				preset.ApplyPreset(partMaterial.ColorData);
				for (int j = 0; j < 4; j++)
				{
					_colorPickerButtons[j + 1].Button.Color.Base = partMaterial.ColorData[j].Color;
				}
			}
		}

		private void UpdateColorButtons(ThemeData theme)
		{
			int count = theme.Materials.Count;
			for (int num = _colorButtons.Count - 1; num >= count; num--)
			{
				_colorButtons[num].Widget.Destroy();
				_colorButtons.RemoveAt(num);
			}
			for (int i = _colorButtons.Count; i < count; i++)
			{
				ColorButtonScript component = base.Widget.Context.CreateWidgetFromTemplate("color-button", _colorButtonPanel).GetComponent<ColorButtonScript>();
				_colorButtons.Add(component);
			}
			for (int j = 0; j < count; j++)
			{
				ColorButtonScript colorButtonScript = _colorButtons[j];
				colorButtonScript.MaterialId = j;
				colorButtonScript.InitializeMaterial(theme.Materials[j], this);
			}
		}

		private void UpdateColorsFromColorPickerDialog(ColorPickerDialogScript d, int buttonIndex)
		{
			UpdateSelectedButtonColor(d.AdjustedColor, d.Metallic, d.Smoothness, d.EmissionDay, d.EmissionNight, buttonIndex);
			CreateUndoStep("Changed paint color", SelectedColorButton?.PartMaterial);
		}

		private void UpdateFinishSpinner(PartMaterial material)
		{
			_finishSpinner.Value = PaintFinishes.GetFinishName(material.Metallic, material.Smoothness);
		}

		private void UpdateSelectedButtonColor(Color color, float? metallic, float? smoothness, float? emissionDay, float? emissionNight, int buttonIndex)
		{
			PartMaterial partMaterial = SelectedColorButton?.PartMaterial;
			if (partMaterial == null)
			{
				return;
			}
			_colorPickerButtons[buttonIndex].Button.Color.Base = color;
			if (buttonIndex == 0)
			{
				PaintColorData obj = partMaterial.ColorData[0];
				obj.Color = color;
				obj.Metallic = null;
				obj.Smoothness = null;
				obj.EmissionDay = null;
				obj.EmissionNight = null;
			}
			else
			{
				PaintColorData paintColorData = partMaterial.ColorData[buttonIndex - 1];
				paintColorData.Color = color;
				paintColorData.Metallic = metallic;
				paintColorData.Smoothness = smoothness;
				paintColorData.EmissionDay = emissionDay;
				paintColorData.EmissionNight = emissionNight;
				PaintTexturePreset activePreset = GetActivePreset(partMaterial);
				if (activePreset != null)
				{
					paintColorData.CopyTo(activePreset.Colors[buttonIndex - 1]);
				}
			}
			RefreshPresetSpinner(partMaterial);
			ApplyChangesToCraft();
		}

		private void UpdateTheme(string themeName, bool applyToAircraft)
		{
			SelectedColorButton = null;
			ThemeName = themeName;
			ThemeData themeData = null;
			themeData = ((!(themeName == "Custom")) ? Game.Instance.AircraftThemes.GetTheme(themeName) : base.DesignerUI.DesignerScript.Aircraft.Aircraft.CustomTheme);
			UpdateColorButtons(themeData);
			if (applyToAircraft)
			{
				base.DesignerUI.DesignerScript.Aircraft.Aircraft.CurrentTheme = themeData;
				base.DesignerUI.DesignerScript.Aircraft.Theme.Theme = themeData;
				ApplyChangesToCraft();
			}
		}
	}
}
