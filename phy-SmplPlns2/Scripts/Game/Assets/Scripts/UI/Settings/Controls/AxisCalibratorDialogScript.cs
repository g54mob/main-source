using System;
using System.Collections;
using Jundroo.Juicy.Widgets;
using Rewired;
using UnityEngine;

namespace Assets.Scripts.UI.Settings.Controls
{
	public class AxisCalibratorDialogScript : PanelDialogScript
	{
		private ControllerAxis _axis;

		private Widget _centerStickImage;

		private Widget _centerStickPanel;

		private Coroutine _currentCoroutine;

		private AxisCalibrationData _data;

		private bool _firstRun = true;

		private TextWidget _label;

		private Widget _moveStickImage;

		private Action _onFinishCalibrating;

		private bool _recording;

		private TextWidget _timerText;

		public string MessageText
		{
			get
			{
				return _label.Text;
			}
			set
			{
				_label.Text = value;
			}
		}

		public float WaitTime { get; set; }

		public static AxisCalibratorDialogScript Create(Transform parent, ControllerAxis axis, Action onFinishCalibrating = null)
		{
			AxisCalibratorDialogScript axisCalibratorDialogScript = Game.Instance.UserInterface.CreateDialog<AxisCalibratorDialogScript>("Xml/Dialogs/Controls/AxisCalibratorDialog");
			axisCalibratorDialogScript._axis = axis;
			axisCalibratorDialogScript._onFinishCalibrating = onFinishCalibrating;
			axisCalibratorDialogScript._data = axis.Calibration.GetData();
			return axisCalibratorDialogScript;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_label = widget.FindWidget<TextWidget>("label-text");
			_timerText = widget.FindWidget<TextWidget>("timer-text");
			_centerStickPanel = widget.FindWidget("stick-panel");
			_centerStickImage = _centerStickPanel.FindWidget("center-stick-image");
			_moveStickImage = _centerStickPanel.FindWidget("move-stick-image");
		}

		public void WaitFor(float time, Action onComplete, bool skipWaitOnButtonUp)
		{
			WaitTime = time;
			if (_currentCoroutine != null)
			{
				StopCoroutine(_currentCoroutine);
			}
			_currentCoroutine = StartCoroutine(Wait(onComplete, skipWaitOnButtonUp));
		}

		protected override void Start()
		{
			base.Start();
			base.Title = "Calibrate Zero";
			MessageText = $"Center or zero {_axis.Name} and press any button or wait for the timer to finish.";
			WaitFor(5f, BeingRecording, skipWaitOnButtonUp: true);
		}

		protected void Update()
		{
			if (_recording)
			{
				RecordMinMax();
			}
			if (Game.Instance.UserInterface.ActiveDialog == this && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
			{
				Close();
			}
		}

		private void BeingRecording()
		{
			RecordZero();
			base.Title = "Calibrate Range";
			MessageText = $"Move {_axis.Name} through it's entire range then press any button or wait for the timer to finish.";
			_centerStickImage.Visible = false;
			_moveStickImage.Visible = true;
			_recording = true;
			WaitFor(5f, FinishRecording, skipWaitOnButtonUp: true);
		}

		private void Commit()
		{
			if (_axis != null && !((double)Mathf.Abs(_data.max - _data.min) < 0.1))
			{
				_axis.Calibration.SetData(_data);
			}
		}

		private void FinishRecording()
		{
			_recording = false;
			Commit();
			_onFinishCalibrating?.Invoke();
			Close();
		}

		private void RecordMinMax()
		{
			if (_axis != null)
			{
				float valueRaw = _axis.InputAxis.valueRaw;
				if (_firstRun || valueRaw < _data.min)
				{
					_data.min = valueRaw;
				}
				if (_firstRun || valueRaw > _data.max)
				{
					_data.max = valueRaw;
				}
				_firstRun = false;
			}
		}

		private void RecordZero()
		{
			if (_axis != null)
			{
				_data.zero = _axis.InputAxis.valueRaw;
			}
		}

		private IEnumerator Wait(Action onComplete, bool skipWaitOnButtonUp = false)
		{
			while (WaitTime > 0f)
			{
				yield return new WaitForEndOfFrame();
				WaitTime -= Time.unscaledDeltaTime;
				WaitTime = Mathf.Clamp(WaitTime, 0f, float.PositiveInfinity);
				_timerText.Text = $"{WaitTime:0.0}";
				if (skipWaitOnButtonUp && _axis.Controller.GetAnyButtonUp())
				{
					break;
				}
			}
			onComplete?.Invoke();
		}
	}
}
