using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.Design.UI
{
	public class EnvironmentPanelScript : DesignerPanelScript
	{
		private ColorButtonControl _ambientColorButton;

		private SliderControl _lightIntensitySlider;

		private SliderControl _lightRotationSlider;

		private ColorButtonControl _platformColorButton;

		private SpinnerControl _platformSpinner;

		private SliderControl _reflectionIntensitySlider;

		private ColorButtonControl _skyColorButton;

		private SpinnerControl _skySpinner;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
		}

		protected virtual void Start()
		{
			Widget widget = base.Widget.FindWidget("sky-spinner");
			_skySpinner = new SpinnerControl(widget);
			_skySpinner.Value = base.Designer.Environment.SkyName;
			_skySpinner.Values.Add("Solid Color");
			_skySpinner.Values.Add("Clouds");
			_skySpinner.Values.Add("Dusk");
			_skySpinner.Values.Add("Moon Shine");
			_skySpinner.Values.Add("Purple Haze");
			_skySpinner.Values.Add("Sunset");
			_skySpinner.OnValueChanged = delegate(string _, string x)
			{
				base.Designer.Environment.SkyName = x;
			};
			Widget widget2 = base.Widget.FindWidget("platform-spinner");
			_platformSpinner = new SpinnerControl(widget2);
			_platformSpinner.Value = base.Designer.Environment.PlatformName;
			_platformSpinner.Values.Add("Classic");
			_platformSpinner.Values.Add("Circle");
			_platformSpinner.Values.Add("Square");
			_platformSpinner.Values.Add("None");
			_platformSpinner.OnValueChanged = delegate(string _, string x)
			{
				base.Designer.Environment.PlatformName = x;
			};
			_platformColorButton = new ColorButtonControl(base.Widget.FindWidget("platform-color-button"));
			_platformColorButton.Color = base.Designer.Environment.PlatformColor;
			_platformColorButton.ColorChanged += OnPlatformColorChanged;
			_platformColorButton.DetermineVisibility = () => base.Designer.Environment.PlatformName == "Square" || base.Designer.Environment.PlatformName == "Circle";
			_lightIntensitySlider = new SliderControl(base.Widget.FindWidget("light-intensity-slider"));
			_lightIntensitySlider.ValueFormatter = (float x) => Utilities.FormatPercentage(x) ?? "";
			_lightIntensitySlider.Slider.MinValue = 0f;
			_lightIntensitySlider.Slider.MaxValue = 2f;
			_lightIntensitySlider.Slider.NumberOfSteps = 41;
			_lightIntensitySlider.Slider.Value = base.Designer.Environment.LightIntensity;
			_lightIntensitySlider.Slider.ValueChanged += delegate(float x)
			{
				base.Designer.Environment.LightIntensity = x;
			};
			_reflectionIntensitySlider = new SliderControl(base.Widget.FindWidget("reflection-intensity-slider"));
			_reflectionIntensitySlider.ValueFormatter = (float x) => Utilities.FormatPercentage(x) ?? "";
			_reflectionIntensitySlider.Slider.MinValue = 0f;
			_reflectionIntensitySlider.Slider.MaxValue = 2f;
			_reflectionIntensitySlider.Slider.NumberOfSteps = 41;
			_reflectionIntensitySlider.Slider.Value = base.Designer.Environment.ReflectionIntensity;
			_reflectionIntensitySlider.Slider.ValueChanged += delegate(float x)
			{
				base.Designer.Environment.ReflectionIntensity = x;
			};
			_lightRotationSlider = new SliderControl(base.Widget.FindWidget("light-rotation-slider"));
			_lightRotationSlider.ValueFormatter = (float x) => $"{Mathf.RoundToInt(x)}°";
			_lightRotationSlider.Slider.MinValue = -90f;
			_lightRotationSlider.Slider.MaxValue = 90f;
			_lightRotationSlider.Slider.Slider.wholeNumbers = true;
			_lightRotationSlider.Slider.Value = base.Designer.Environment.LightRotationY;
			_lightRotationSlider.Slider.ValueChanged += delegate(float x)
			{
				base.Designer.Environment.LightRotationY = x;
			};
			_skyColorButton = new ColorButtonControl(base.Widget.FindWidget("sky-color-button"));
			_skyColorButton.Color = base.Designer.Environment.SkyColor;
			_skyColorButton.ColorChanged += OnSkyColorChanged;
			_skyColorButton.DetermineVisibility = () => base.Designer.Environment.SkyName == "Solid Color";
			_ambientColorButton = new ColorButtonControl(base.Widget.FindWidget("ambient-color-button"));
			_ambientColorButton.Color = base.Designer.Environment.AmbientColor;
			_ambientColorButton.ColorChanged += OnAmbientColorChanged;
		}

		protected virtual void Update()
		{
			_skyColorButton.UpdateVisibility(parentsVisible: true);
			_platformColorButton.UpdateVisibility(parentsVisible: true);
		}

		private void OnAmbientColorChanged(object sender, ColorButtonControl.ColorChangedEventArgs e)
		{
			base.Designer.Environment.AmbientColor = e.Color;
		}

		private void OnCancelButtonClicked(Widget widget)
		{
			base.Flyout.Close();
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
		}

		private void OnPlatformColorChanged(object sender, ColorButtonControl.ColorChangedEventArgs e)
		{
			base.Designer.Environment.PlatformColor = e.Color;
		}

		private void OnSkyColorChanged(object sender, ColorButtonControl.ColorChangedEventArgs e)
		{
			base.Designer.Environment.SkyColor = e.Color;
		}
	}
}
