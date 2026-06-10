using System;
using System.Collections.Generic;
using Rewired.Integration.UnityUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Rewired.UI.ControlMapper
{
	[AddComponentMenu(null)]
	public class CalibrationWindow : Window
	{
		public enum ButtonIdentifier
		{
			Done = 0,
			Cancel = 1,
			Default = 2,
			Calibrate = 3
		}

		private const float minSensitivityOtherAxes = 0.1f;

		private const float maxDeadzone = 0.8f;

		[SerializeField]
		private RectTransform rightContentContainer;

		[SerializeField]
		private RectTransform valueDisplayGroup;

		[SerializeField]
		private RectTransform calibratedValueMarker;

		[SerializeField]
		private RectTransform rawValueMarker;

		[SerializeField]
		private RectTransform calibratedZeroMarker;

		[SerializeField]
		private RectTransform deadzoneArea;

		[SerializeField]
		private Slider deadzoneSlider;

		[SerializeField]
		private Slider zeroSlider;

		[SerializeField]
		private Slider sensitivitySlider;

		[SerializeField]
		private Toggle invertToggle;

		[SerializeField]
		private RectTransform axisScrollAreaContent;

		[SerializeField]
		private Button doneButton;

		[SerializeField]
		private Button calibrateButton;

		[SerializeField]
		private TMP_Text doneButtonLabel;

		[SerializeField]
		private TMP_Text cancelButtonLabel;

		[SerializeField]
		private TMP_Text defaultButtonLabel;

		[SerializeField]
		private TMP_Text deadzoneSliderLabel;

		[SerializeField]
		private TMP_Text zeroSliderLabel;

		[SerializeField]
		private TMP_Text sensitivitySliderLabel;

		[SerializeField]
		private TMP_Text invertToggleLabel;

		[SerializeField]
		private TMP_Text calibrateButtonLabel;

		[SerializeField]
		private GameObject axisButtonPrefab;

		private Joystick joystick;

		private string origCalibrationData;

		private int selectedAxis;

		private AxisCalibrationData origSelectedAxisCalibrationData;

		private float displayAreaWidth;

		private List<Button> axisButtons;

		private Dictionary<int, Action<int>> buttonCallbacks;

		private int playerId;

		private RewiredStandaloneInputModule rewiredStandaloneInputModule;

		private int menuHorizActionId;

		private int menuVertActionId;

		private float minSensitivity;

		private bool axisSelected => false;

		private AxisCalibration axisCalibration => null;

		public override void Initialize(int id, Func<int, bool> isFocusedCallback)
		{
		}

		public void SetJoystick(int playerId, Joystick joystick)
		{
		}

		public void SetButtonCallback(ButtonIdentifier buttonIdentifier, Action<int> callback)
		{
		}

		public override void Cancel()
		{
		}

		protected override void Update()
		{
		}

		public void OnDone()
		{
		}

		public void OnCancel()
		{
		}

		public void OnRestoreDefault()
		{
		}

		public void OnCalibrate()
		{
		}

		public void OnInvert(bool state)
		{
		}

		public void OnZeroValueChange(float value)
		{
		}

		public void OnZeroCancel()
		{
		}

		public void OnDeadzoneValueChange(float value)
		{
		}

		public void OnDeadzoneCancel()
		{
		}

		public void OnSensitivityValueChange(float value)
		{
		}

		public void OnSensitivityCancel(float value)
		{
		}

		public void OnAxisScrollRectScroll(Vector2 pos)
		{
		}

		private void OnAxisSelected(int axisIndex, Button button)
		{
		}

		private void UpdateDisplay()
		{
		}

		private void Redraw()
		{
		}

		private void RefreshControls()
		{
		}

		private void RedrawDeadzone()
		{
		}

		private void RedrawCalibratedZero()
		{
		}

		private void RedrawValueMarkers()
		{
		}

		private void SelectAxis(int index)
		{
		}

		public override void TakeInputFocus()
		{
		}

		private void SetMinSensitivity()
		{
		}

		private bool IsMenuAxis(int actionId, int axisIndex)
		{
			return false;
		}

		private void GetAxisButtonDeadZone(int playerId, int actionId, ref float value)
		{
		}

		private float GetSliderSensitivity(AxisCalibration axisCalibration)
		{
			return 0f;
		}

		public void SetSensitivity(AxisCalibration axisCalibration, float sliderValue)
		{
		}

		private static float ProcessPowerValue(float value, float minValue, float maxValue)
		{
			return 0f;
		}
	}
}
