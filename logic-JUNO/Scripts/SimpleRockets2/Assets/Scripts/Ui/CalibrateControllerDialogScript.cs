using System;
using System.Collections;
using System.Collections.Generic;
using ModApi;
using ModApi.Ui;
using Rewired;
using UI.Xml;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui
{
	public class CalibrateControllerDialogScript : DialogScript
	{
		public class Axis
		{
			public XmlElement Button { get; set; }

			public AxisCalibration Calibration { get; set; }

			public Controller.Axis InputAxis { get; set; }

			public Joystick Joystick { get; set; }

			public string Name { get; set; }
		}

		private const string PrimaryButtonClass = "btn-primary";

		private List<Axis> _axes = new List<Axis>();

		private XmlElement _axisButtonTemplate;

		private XmlElement _calibratedZero;

		private Controller _controllerToCalibrate;

		private XmlElement _deadZone;

		private SliderControl _deadZoneSlider;

		private XmlElement _gameInputArrow;

		private XmlElement _inputArrowsParent;

		private Toggle _invertToggle;

		private XmlElement _itemsParent;

		private XmlElement _panel;

		private XmlElement _rawInputArrow;

		private Axis _selectedAxis;

		private SliderControl _sensitivitySlider;

		private SliderControl _zeroSlider;

		public static CalibrateControllerDialogScript Create(Transform parent, Controller controllerToCalibrate)
		{
			CalibrateControllerDialogScript calibrateControllerDialogScript = Game.Instance.UserInterface.CreateDialog("Ui/Xml/Settings/CalibrateControllerDialog", parent, delegate(CalibrateControllerDialogScript d, IXmlLayoutController c)
			{
				d.OnLayoutRebuilt((XmlLayout)c.XmlLayout);
			});
			calibrateControllerDialogScript._controllerToCalibrate = controllerToCalibrate;
			return calibrateControllerDialogScript;
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

		protected override void Start()
		{
			base.Start();
			_panel.Show();
			if (!(_controllerToCalibrate is Joystick joystick))
			{
				return;
			}
			for (int i = 0; i < joystick.Axes.Count; i++)
			{
				Axis axis = new Axis
				{
					Joystick = joystick,
					Calibration = joystick.calibrationMap.Axes[i],
					Name = joystick.AxisElementIdentifiers[i].name,
					InputAxis = joystick.Axes[i]
				};
				axis.Button = CreateAxisButton(axis.Name);
				axis.Button.AddOnClickEvent(delegate
				{
					OnAxisClicked(axis);
				});
				_axes.Add(axis);
			}
			SetSelectedAxis(_axes[0]);
			StartCoroutine(UpdateUIInFrames(1));
		}

		private XmlElement CreateAxisButton(string axisName)
		{
			XmlElement xmlElement = UiUtilities.CloneTemplate(_axisButtonTemplate, _itemsParent);
			xmlElement.childElements[0].SetAndApplyAttribute("text", axisName);
			return xmlElement;
		}

		private void OnAxisClicked(Axis axis)
		{
			SetSelectedAxis(axis);
		}

		private void OnCalibrateClicked()
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

		private void OnDoneButtonClicked()
		{
			Close();
		}

		private void OnInvertChanged(bool invert)
		{
			if (_selectedAxis != null)
			{
				_selectedAxis.Calibration.invert = invert;
			}
		}

		private void OnLayoutRebuilt(XmlLayout xmlLayout)
		{
			_panel = xmlLayout.GetElementById("panel");
			_itemsParent = xmlLayout.GetElementById("items-parent");
			_deadZone = xmlLayout.GetElementById("dead-zone");
			_gameInputArrow = xmlLayout.GetElementById("input-game");
			_rawInputArrow = xmlLayout.GetElementById("input-raw");
			_calibratedZero = xmlLayout.GetElementById("calibrated-zero");
			_inputArrowsParent = _gameInputArrow.parentElement;
			_deadZoneSlider = new SliderControl(xmlLayout.GetElementById("dead-zone-slider"));
			_deadZoneSlider.Slider.onValueChanged.AddListener(OnDeadZoneSliderChanged);
			_zeroSlider = new SliderControl(xmlLayout.GetElementById("zero-slider"));
			_zeroSlider.Slider.onValueChanged.AddListener(OnZeroSliderChanged);
			_sensitivitySlider = new SliderControl(xmlLayout.GetElementById("sensitivity-slider"));
			_sensitivitySlider.Slider.onValueChanged.AddListener(OnSensitivitySliderChanged);
			_invertToggle = xmlLayout.GetElementById("invert-toggle").GetComponentInChildren<Toggle>();
			_invertToggle.onValueChanged.AddListener(OnInvertChanged);
			_axisButtonTemplate = _itemsParent.childElements[0];
			_axisButtonTemplate.SetActive(active: false);
			foreach (XmlElement child in _itemsParent.childElements)
			{
				if (!(child != _axisButtonTemplate))
				{
					continue;
				}
				XmlLayoutTimer.AtEndOfFrame(delegate
				{
					XmlLayoutTimer.AtEndOfFrame(delegate
					{
						UnityEngine.Object.Destroy(child.gameObject);
					}, this, forceEvenIfObjectIsInactive: true);
				}, this, forceEvenIfObjectIsInactive: true);
			}
			_panel.SetAttribute("active", "false");
		}

		private void OnRestoreDefaultsButtonClicked()
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

		private void SetCalibratedZero(Axis axis, float value)
		{
			axis.Calibration.calibratedZero = value;
			_zeroSlider.Slider.value = value;
			_zeroSlider.ValueText.SetText(Utilities.FormatPercentage(value));
			Vector3 localPosition = _calibratedZero.rectTransform.localPosition;
			localPosition.x = _selectedAxis.Calibration.calibratedZero * _inputArrowsParent.rectTransform.rect.width * 0.5f;
			_calibratedZero.rectTransform.localPosition = localPosition;
			Vector3 localPosition2 = _deadZone.rectTransform.localPosition;
			localPosition2.x = localPosition.x;
			_deadZone.rectTransform.localPosition = localPosition2;
		}

		private void SetDeadZone(Axis axis, float value)
		{
			axis.Calibration.deadZone = value;
			_deadZone.SetAndApplyAttribute("width", Utilities.FormatPercentage(value));
			_deadZoneSlider.Slider.value = value;
			_deadZoneSlider.ValueText.SetText(Utilities.FormatPercentage(value));
		}

		private void SetSelectedAxis(Axis axis)
		{
			if (_selectedAxis != axis)
			{
				if (_selectedAxis != null && _selectedAxis.Button.HasClass("btn-primary"))
				{
					_selectedAxis.Button.RemoveClass("btn-primary");
					_selectedAxis.Button.ApplyAttributes();
				}
				_selectedAxis = axis;
				axis.Button.AddClass("btn-primary");
				axis.Button.ApplyAttributes();
				UpdateUI();
			}
		}

		private void SetSensitivity(Axis axis, float value)
		{
			axis.Calibration.sensitivity = value;
			_sensitivitySlider.Slider.value = value;
			_sensitivitySlider.ValueText.SetText(Utilities.FormatPercentage(value));
		}

		private void Update()
		{
			if (_selectedAxis != null)
			{
				Vector3 localPosition = _gameInputArrow.rectTransform.localPosition;
				localPosition.x = _selectedAxis.InputAxis.value * _inputArrowsParent.rectTransform.rect.width * 0.5f;
				_gameInputArrow.rectTransform.localPosition = localPosition;
				Vector3 localPosition2 = _rawInputArrow.rectTransform.localPosition;
				localPosition2.x = _selectedAxis.InputAxis.valueRaw * _inputArrowsParent.rectTransform.rect.width * 0.5f;
				_rawInputArrow.rectTransform.localPosition = localPosition2;
			}
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
