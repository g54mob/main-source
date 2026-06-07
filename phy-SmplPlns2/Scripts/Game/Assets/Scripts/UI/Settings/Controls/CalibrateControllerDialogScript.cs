using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Utils;
using Jundroo.Juicy.Widgets;
using Rewired;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Settings.Controls
{
	public class CalibrateControllerDialogScript : PanelDialogScript
	{
		private const string PrimaryButtonClass = "btn-primary";

		private List<ControllerAxis> _axes = new List<ControllerAxis>();

		private AxisVisualizationScript _axisVisualization;

		private Controller _controllerToCalibrate;

		private SliderControl _deadZoneSlider;

		private Toggle _invertToggle;

		private Widget _itemsParent;

		private ControllerAxis _selectedAxis;

		private SliderControl _sensitivitySlider;

		private SliderControl _zeroSlider;

		public static CalibrateControllerDialogScript Create(Controller controllerToCalibrate)
		{
			CalibrateControllerDialogScript calibrateControllerDialogScript = Game.Instance.UserInterface.CreateDialog<CalibrateControllerDialogScript>("Xml/Dialogs/Controls/CalibrateControllerDialog");
			calibrateControllerDialogScript._controllerToCalibrate = controllerToCalibrate;
			return calibrateControllerDialogScript;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_axisVisualization = widget.FindWidgetComponent<AxisVisualizationScript>("axis-visualization");
			_itemsParent = widget.FindWidget("items-parent");
			_deadZoneSlider = new SliderControl(widget.FindWidget("dead-zone-slider"));
			_deadZoneSlider.ValueFormatter = (float x) => Utilities.FormatPercentage(x);
			_deadZoneSlider.Slider.ValueChanged += delegate(float x)
			{
				OnDeadZoneSliderChanged(x);
			};
			_deadZoneSlider.Slider.MinValue = 0f;
			_deadZoneSlider.Slider.MaxValue = 1f;
			_deadZoneSlider.Slider.NumberOfSteps = 101;
			_zeroSlider = new SliderControl(widget.FindWidget("zero-slider"));
			_zeroSlider.ValueFormatter = (float x) => Utilities.FormatPercentage(x);
			_zeroSlider.Slider.ValueChanged += delegate(float x)
			{
				OnZeroSliderChanged(x);
			};
			_zeroSlider.Slider.MinValue = -1f;
			_zeroSlider.Slider.MaxValue = 1f;
			_zeroSlider.Slider.NumberOfSteps = 201;
			_sensitivitySlider = new SliderControl(widget.FindWidget("sensitivity-slider"));
			_sensitivitySlider.ValueFormatter = (float x) => Utilities.FormatPercentage(x);
			_sensitivitySlider.Slider.ValueChanged += delegate(float x)
			{
				OnSensitivitySliderChanged(x);
			};
			_sensitivitySlider.Slider.MinValue = 0f;
			_sensitivitySlider.Slider.MaxValue = 2f;
			_sensitivitySlider.Slider.NumberOfSteps = 201;
			_invertToggle = widget.FindWidget("invert-toggle").GetComponentInChildren<Toggle>();
			_invertToggle.onValueChanged.AddListener(OnInvertChanged);
		}

		protected override void Start()
		{
			base.Start();
			if (!(_controllerToCalibrate is ControllerWithAxes controllerWithAxes))
			{
				return;
			}
			for (int i = 0; i < controllerWithAxes.Axes.Count; i++)
			{
				ControllerAxis axis = new ControllerAxis
				{
					Controller = controllerWithAxes,
					Calibration = controllerWithAxes.calibrationMap.Axes[i],
					Name = controllerWithAxes.AxisElementIdentifiers[i].name,
					InputAxis = controllerWithAxes.Axes[i]
				};
				axis.Button = CreateAxisButton(axis.Name);
				axis.Button.Clicked += delegate
				{
					OnAxisClicked(axis);
				};
				_axes.Add(axis);
			}
			SetSelectedAxis(_axes[0]);
			StartCoroutine(UpdateUIInFrames(3));
		}

		protected void Update()
		{
			if (Game.Instance.UserInterface.ActiveDialog == this && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
			if (_selectedAxis != null)
			{
				_axisVisualization.SetInputValues(_selectedAxis.InputAxis.value, _selectedAxis.InputAxis.valueRaw);
			}
		}

		private Widget CreateAxisButton(string axisName)
		{
			Widget widget = base.Widget.Context.CreateWidgetFromTemplate("axis-button", _itemsParent);
			widget.FindWidget<TextWidget>("label-text").Text = axisName;
			return widget;
		}

		private void OnAxisClicked(ControllerAxis axis)
		{
			SetSelectedAxis(axis);
		}

		private void OnCalibrateClicked(Widget widget)
		{
			AxisCalibratorDialogScript.Create(base.transform.parent, _selectedAxis, UpdateUI);
		}

		private void OnDeadZoneSliderChanged(float value)
		{
			if (_selectedAxis != null)
			{
				value = (float)Math.Round(value, 2);
				SetDeadZone(_selectedAxis, value);
				SetCalibratedZero(_selectedAxis, _selectedAxis.Calibration.calibratedZero);
			}
		}

		private void OnInvertChanged(bool invert)
		{
			if (_selectedAxis != null)
			{
				_selectedAxis.Calibration.invert = invert;
			}
		}

		private void OnOkayButtonClicked(Widget widget)
		{
			Close();
		}

		private void OnRestoreDefaultsButtonClicked(Widget widget)
		{
			if (_selectedAxis != null)
			{
				_selectedAxis.Calibration.Reset();
				UpdateUI();
			}
		}

		private void OnSensitivitySliderChanged(float value)
		{
			if (_selectedAxis != null)
			{
				value = (float)Math.Round(value, 2);
				SetSensitivity(_selectedAxis, value);
			}
		}

		private void OnZeroSliderChanged(float value)
		{
			if (_selectedAxis != null)
			{
				value = (float)Math.Round(value, 2);
				SetCalibratedZero(_selectedAxis, value);
			}
		}

		private void SetCalibratedZero(ControllerAxis axis, float value)
		{
			axis.Calibration.calibratedZero = value;
			_zeroSlider.Slider.Value = value;
			_axisVisualization.SetCalibratedZero(axis.Calibration.calibratedZero, value);
		}

		private void SetDeadZone(ControllerAxis axis, float value)
		{
			axis.Calibration.deadZone = value;
			_axisVisualization.SetDeadZone(value);
			_deadZoneSlider.Slider.Value = value;
		}

		private void SetSelectedAxis(ControllerAxis axis)
		{
			if (_selectedAxis != axis)
			{
				if (_selectedAxis != null && _selectedAxis.Button.HasClass("btn-primary"))
				{
					_selectedAxis.Button.RemoveClass("btn-primary");
				}
				_selectedAxis = axis;
				_axisVisualization.AxisName = axis?.Name;
				axis.Button.AddClass("btn-primary");
				UpdateUI();
			}
		}

		private void SetSensitivity(ControllerAxis axis, float value)
		{
			axis.Calibration.sensitivity = value;
			_sensitivitySlider.Slider.Value = value;
		}

		private void UpdateUI()
		{
			SetDeadZone(_selectedAxis, _selectedAxis.Calibration.deadZone);
			SetCalibratedZero(_selectedAxis, _selectedAxis.Calibration.calibratedZero);
			SetSensitivity(_selectedAxis, _selectedAxis.Calibration.sensitivity);
			_invertToggle.isOn = _selectedAxis.Calibration.invert;
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
