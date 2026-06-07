using System;
using System.Collections;
using Assets.Scripts.Input;
using Assets.Scripts.Settings;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Settings.Controls
{
	public class CalibrateMouseDialogScript : PanelDialogScript
	{
		private AxisVisualizationScript _axisVisualizationPitch;

		private AxisVisualizationScript _axisVisualizationRoll;

		private SliderControl _deadZoneSlider;

		private Toggle _invertToggle;

		private SliderControl _rangeSlider;

		private MouseJoystickSettings _settings;

		public static CalibrateMouseDialogScript Create()
		{
			return Game.Instance.UserInterface.CreateDialog<CalibrateMouseDialogScript>("Xml/Dialogs/Controls/CalibrateMouseDialog");
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_settings = Game.Instance.Settings.Gameplay.MouseJoystick;
			_axisVisualizationPitch = widget.FindWidgetComponent<AxisVisualizationScript>("axis-visualization-pitch");
			_axisVisualizationRoll = widget.FindWidgetComponent<AxisVisualizationScript>("axis-visualization-roll");
			_deadZoneSlider = new SliderControl(widget.FindWidget("dead-zone-slider"));
			_deadZoneSlider.ValueFormatter = (float x) => Utilities.FormatPercentage(x);
			_deadZoneSlider.Slider.ValueChanged += delegate(float x)
			{
				OnDeadZoneSliderChanged(x);
			};
			_rangeSlider = new SliderControl(widget.FindWidget("range-slider"));
			_rangeSlider.ValueFormatter = (float x) => Utilities.FormatPercentage(x);
			_rangeSlider.Slider.ValueChanged += delegate(float x)
			{
				OnRangeSliderChanged(x);
			};
			_invertToggle = widget.FindWidget("invert-toggle").GetComponentInChildren<Toggle>();
			_invertToggle.onValueChanged.AddListener(OnInvertChanged);
		}

		protected override void Start()
		{
			base.Start();
			StartCoroutine(UpdateUIInFrames(3));
		}

		protected void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
			InputWrapper.MouseAsJoystickSettingsChanged = true;
			Vector2 mouseAsJoystickAxis = InputWrapper.GetMouseAsJoystickAxis(overrideEnabled: true);
			float num = (float)Screen.width / 2f;
			float num2 = (float)Screen.height / 2f;
			Vector2 mouseScreenPosition = InputWrapper.MouseScreenPosition;
			mouseScreenPosition.x = (mouseScreenPosition.x - num) / num;
			mouseScreenPosition.y = (mouseScreenPosition.y - num2) / num2;
			_axisVisualizationPitch.SetInputValues(mouseAsJoystickAxis.y, mouseScreenPosition.y);
			_axisVisualizationRoll.SetInputValues(mouseAsJoystickAxis.x, mouseScreenPosition.x);
		}

		private void OnDeadZoneSliderChanged(float value)
		{
			value = (float)Math.Round(value, 2);
			_settings.MouseJoystickDeadzone.Value = value;
			_settings.MouseJoystickDeadzone.CommitChanges();
			_axisVisualizationPitch.SetDeadZone(value);
			_axisVisualizationRoll.SetDeadZone(value);
		}

		private void OnInvertChanged(bool invert)
		{
			_settings.MouseJoystickInvertPitch.Value = invert;
			_settings.MouseJoystickInvertPitch.CommitChanges();
		}

		private void OnOkayButtonClicked(Widget widget)
		{
			Close();
			Game.Instance.Settings.SaveIfNecessary();
		}

		private void OnRangeSliderChanged(float x)
		{
			_settings.MouseJoystickRange.Value = x;
			_settings.MouseJoystickRange.CommitChanges();
		}

		private void OnRestoreDefaultsButtonClicked(Widget widget)
		{
			_settings.RestoreDefaults();
			UpdateUI();
		}

		private void SetDeadZone(float value)
		{
			_deadZoneSlider.Slider.Value = value;
			_axisVisualizationPitch.SetDeadZone(value);
			_axisVisualizationRoll.SetDeadZone(value);
		}

		private void UpdateUI()
		{
			SetDeadZone(_settings.MouseJoystickDeadzone);
			_rangeSlider.SetValue(_settings.MouseJoystickRange.Value);
			_invertToggle.isOn = _settings.MouseJoystickInvertPitch.Value;
		}

		private IEnumerator UpdateUIInFrames(int framesToWait)
		{
			while (framesToWait > 0)
			{
				yield return new WaitForEndOfFrame();
				framesToWait--;
			}
			UpdateUI();
		}
	}
}
