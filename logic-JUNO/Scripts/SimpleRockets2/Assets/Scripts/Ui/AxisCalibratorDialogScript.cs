using System;
using System.Collections;
using ModApi.Ui;
using Rewired;
using TMPro;
using UI.Xml;
using UnityEngine;

namespace Assets.Scripts.Ui
{
	public class AxisCalibratorDialogScript : DialogScript
	{
		private CalibrateControllerDialogScript.Axis _axis;

		private XmlElement _centerStickImage;

		private XmlElement _centerStickPanel;

		private Coroutine _currentCoroutine;

		private AxisCalibrationData _data;

		private bool _firstRun = true;

		private TextMeshProUGUI _label;

		private XmlElement _moveStickImage;

		private Action _onFinishCalibrating;

		private XmlElement _panel;

		private bool _recording;

		private TextMeshProUGUI _timerText;

		private TextMeshProUGUI _title;

		public string MessageText
		{
			get
			{
				return _label.text;
			}
			set
			{
				_label.SetText(value);
			}
		}

		public float WaitTime { get; set; }

		public static AxisCalibratorDialogScript Create(Transform parent, CalibrateControllerDialogScript.Axis axis, Action onFinishCalibrating = null)
		{
			AxisCalibratorDialogScript axisCalibratorDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/Settings/AxisCalibratorDialog", parent, delegate(AxisCalibratorDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
			axisCalibratorDialogScript._axis = axis;
			axisCalibratorDialogScript._onFinishCalibrating = onFinishCalibrating;
			axisCalibratorDialogScript._data = axis.Calibration.GetData();
			return axisCalibratorDialogScript;
		}

		public override void Close()
		{
			base.Close();
			_panel.Hide(recursiveCall: false, delegate
			{
				base.gameObject.SetActive(value: false);
				UnityEngine.Object.Destroy(base.gameObject);
			});
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
			_panel.Show();
			_title.SetText("Calibrate Zero");
			MessageText = $"Center or zero {_axis.Name} and press any button or wait for the timer to finish.";
			WaitFor(5f, BeingRecording, skipWaitOnButtonUp: true);
		}

		private void BeingRecording()
		{
			RecordZero();
			_title.SetText("Calibrate Range");
			MessageText = $"Move {_axis.Name} through it's entire range then press any button or wait for the timer to finish.";
			_centerStickImage.Hide();
			_moveStickImage.Show();
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

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_title = xmlLayout.GetElementById<TextMeshProUGUI>("label-title");
			_label = xmlLayout.GetElementById<TextMeshProUGUI>("label-text");
			_timerText = xmlLayout.GetElementById<TextMeshProUGUI>("timer-text");
			_centerStickPanel = xmlLayout.GetElementById("stick-panel");
			_centerStickImage = _centerStickPanel.GetElementByInternalId("center-stick-image");
			_moveStickImage = _centerStickPanel.GetElementByInternalId("move-stick-image");
			_panel.SetAttribute("active", "false");
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

		private void Update()
		{
			if (_recording)
			{
				RecordMinMax();
			}
		}

		private IEnumerator Wait(Action onComplete, bool skipWaitOnButtonUp = false)
		{
			while (WaitTime > 0f)
			{
				yield return new WaitForEndOfFrame();
				WaitTime -= Time.unscaledDeltaTime;
				WaitTime = Mathf.Clamp(WaitTime, 0f, float.PositiveInfinity);
				_timerText.SetText(WaitTime.ToString("0.0"));
				if (skipWaitOnButtonUp && _axis.Joystick.GetAnyButtonUp())
				{
					break;
				}
			}
			onComplete?.Invoke();
		}
	}
}
