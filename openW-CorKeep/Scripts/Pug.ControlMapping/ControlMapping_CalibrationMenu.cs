using System;
using System.Collections.Generic;
using Rewired;
using Rewired.UI.ControlMapper;
using UnityEngine;

public class ControlMapping_CalibrationMenu : RadicalMenu
{
	[SerializeField]
	private LinearLayoutUIComponent _axisSelectionContainer;

	[SerializeField]
	private ControlMapping_AxisCalibrationSelector _axisSelectionPrefab;

	[SerializeField]
	private ControlMapper_CalibrationPreview _calibrationPreview;

	[SerializeField]
	private RadicalOptionsMenuOption_Slider _deadZone;

	[SerializeField]
	private RadicalOptionsMenuOption_Slider _zero;

	[SerializeField]
	private RadicalOptionsMenuOption_Slider _sensitivity;

	[SerializeField]
	private RadicalOptionsMenuOption_TextToggle _invert;

	[SerializeField]
	private List<MenuHelperButtons.HelpButtonTypes> _helpButtons;

	[SerializeField]
	private bool _useControllerIconsForAxes;

	private ControlMapperLanguageData _languageData;

	private ControlMapping_MappingController _mappingController;

	private List<ControlMapping_AxisCalibrationSelector> _axisSelectors = new List<ControlMapping_AxisCalibrationSelector>();

	private Joystick _activeJoystick;

	private int _currentAxisIndex;

	private AxisCalibrationData[] _modifiedData;

	private bool _inputEnabled;

	private Player _systemPlayer;

	private bool AxisSelected
	{
		get
		{
			if (_activeJoystick != null && _currentAxisIndex >= 0)
			{
				return _currentAxisIndex < _activeJoystick.calibrationMap.axisCount;
			}
			return false;
		}
	}

	private AxisCalibration AxisCalibration
	{
		get
		{
			if (!AxisSelected)
			{
				return null;
			}
			return _activeJoystick.calibrationMap.GetAxis(_currentAxisIndex);
		}
	}

	public event Action MenuClosed;

	private void Update()
	{
		PollForInput();
	}

	private void PollForInput()
	{
		if (_inputEnabled && !_mappingController.IsBusy)
		{
			if (_systemPlayer.GetButtonDown(301))
			{
				StartGuidedCalibrationFlow();
			}
			if (_systemPlayer.GetButtonDown(300))
			{
				ResetModifications();
			}
		}
	}

	public void Initialize(ControlMapping_MappingController controller, ControlMapperLanguageData languageData, Player systemPlayer)
	{
		_languageData = languageData;
		_mappingController = controller;
		_systemPlayer = systemPlayer;
		_deadZone.ValueChanged += OnDeadZoneValueChanged;
		_zero.ValueChanged += OnZeroValueChanged;
		_sensitivity.ValueChanged += OnSensitivityValueChanged;
		_invert.ValueChanged += OnInvertValueChanged;
		_mappingController.CalibrationCompleted += OnGuidedCalibrationComplete;
	}

	public void Setup(Joystick joystick)
	{
		_activeJoystick = joystick;
		int axisCount = joystick.calibrationMap.axisCount;
		if (_modifiedData == null || _modifiedData.Length < axisCount)
		{
			_modifiedData = new AxisCalibrationData[axisCount];
		}
		for (int i = 0; i < axisCount; i++)
		{
			_modifiedData[i] = _activeJoystick.calibrationMap.GetAxisData(i);
		}
		for (int j = 0; j < axisCount; j++)
		{
			string text = _languageData.GetElementIdentifierName(_activeJoystick, joystick.AxisElementIdentifiers[j].id, AxisRange.Full);
			if (_useControllerIconsForAxes)
			{
				text = Manager.ui.controllerButtonToCharTable.GetControllerButtonCharacter(_activeJoystick.type, _activeJoystick.name, text);
			}
			ControlMapping_AxisCalibrationSelector orCreateAxisSelectionEntry = GetOrCreateAxisSelectionEntry(text, j);
			orCreateAxisSelectionEntry.gameObject.name = text;
			_axisSelectors.Add(orCreateAxisSelectionEntry);
		}
		_axisSelectionContainer.RenderUIComponent(force: true);
		menuOptions.Clear();
		menuOptions.AddRange(_axisSelectors);
		menuOptions.Add(_deadZone);
		menuOptions.Add(_zero);
		menuOptions.Add(_sensitivity);
		menuOptions.Add(_invert);
		SetupNavigationForAxisSelectors();
		SelectOptionIndex(0);
		if (_axisSelectors.Count > 0)
		{
			_axisSelectors[0].SetActive(active: true);
		}
		_inputEnabled = true;
	}

	public void SelectAxis(int axisIndex)
	{
		if (axisIndex >= 0 && axisIndex < _activeJoystick.calibrationMap.axisCount)
		{
			if (_currentAxisIndex >= 0)
			{
				_axisSelectors[_currentAxisIndex].Clear();
			}
			_deadZone.topUIElements.Clear();
			_deadZone.topUIElements.Add(_axisSelectors[axisIndex]);
			_currentAxisIndex = axisIndex;
			_calibrationPreview.Setup(_activeJoystick, axisIndex);
			_calibrationPreview.UpdatePreview(_modifiedData[axisIndex]);
			RefreshUi();
		}
	}

	public void Close()
	{
		Manager.menu.PopMenu();
	}

	public void ResetModifications()
	{
		ResetModifications(_currentAxisIndex);
		RefreshUi();
	}

	public void StartGuidedCalibrationFlow()
	{
		if (AxisSelected)
		{
			_inputEnabled = false;
			_calibrationPreview.enabled = false;
			_mappingController.StartCalibration(_activeJoystick, AxisCalibration, _activeJoystick.AxisElementIdentifiers[_currentAxisIndex].id);
		}
	}

	private ControlMapping_AxisCalibrationSelector GetOrCreateAxisSelectionEntry(string axisName, int index)
	{
		ControlMapping_AxisCalibrationSelector controlMapping_AxisCalibrationSelector;
		if (_axisSelectors.Count <= index)
		{
			controlMapping_AxisCalibrationSelector = UnityEngine.Object.Instantiate(_axisSelectionPrefab.gameObject, _axisSelectionContainer.transform).GetComponent<ControlMapping_AxisCalibrationSelector>();
		}
		else
		{
			controlMapping_AxisCalibrationSelector = _axisSelectors[index];
			controlMapping_AxisCalibrationSelector.gameObject.SetActive(value: true);
		}
		if (controlMapping_AxisCalibrationSelector == null)
		{
			return null;
		}
		controlMapping_AxisCalibrationSelector.Setup(axisName, index, _useControllerIconsForAxes);
		controlMapping_AxisCalibrationSelector.Activated += AxisSelectorOnActivated;
		controlMapping_AxisCalibrationSelector.Selected += AxisSelectorOnSelected;
		return controlMapping_AxisCalibrationSelector;
	}

	private void SetupNavigationForAxisSelectors()
	{
		for (int i = 0; i < _axisSelectors.Count; i++)
		{
			ControlMapping_AxisCalibrationSelector controlMapping_AxisCalibrationSelector = _axisSelectors[i];
			controlMapping_AxisCalibrationSelector.leftUIElements.Clear();
			controlMapping_AxisCalibrationSelector.rightUIElements.Clear();
			controlMapping_AxisCalibrationSelector.bottomUIElements.Clear();
			if (i > 0)
			{
				controlMapping_AxisCalibrationSelector.leftUIElements.Add(_axisSelectors[i - 1]);
			}
			if (i < _axisSelectors.Count - 1)
			{
				controlMapping_AxisCalibrationSelector.rightUIElements.Add(_axisSelectors[i + 1]);
			}
			controlMapping_AxisCalibrationSelector.bottomUIElements.Add(_deadZone);
		}
	}

	private void AxisSelectorOnActivated(int index)
	{
		SelectAxis(index);
	}

	private void AxisSelectorOnSelected(int index)
	{
	}

	private void RefreshUi()
	{
		_deadZone.SetValue(_modifiedData[_currentAxisIndex].deadZone);
		_zero.SetValue(_modifiedData[_currentAxisIndex].zero);
		_sensitivity.SetValue(_modifiedData[_currentAxisIndex].sensitivity);
		_invert.Initialize(_modifiedData[_currentAxisIndex].invert);
		_calibrationPreview.UpdatePreview(_modifiedData[_currentAxisIndex]);
	}

	private void OnDeadZoneValueChanged(float value, int step)
	{
		_modifiedData[_currentAxisIndex].deadZone = value;
		OnCalibrationValueChanged();
	}

	private void OnZeroValueChanged(float value, int step)
	{
		_modifiedData[_currentAxisIndex].zero = value;
		OnCalibrationValueChanged();
	}

	private void OnSensitivityValueChanged(float value, int step)
	{
		_modifiedData[_currentAxisIndex].sensitivity = value;
		OnCalibrationValueChanged();
	}

	private void OnInvertValueChanged(bool value)
	{
		_modifiedData[_currentAxisIndex].invert = value;
		OnCalibrationValueChanged();
	}

	private void OnCalibrationValueChanged()
	{
		_calibrationPreview.UpdatePreview(_modifiedData[_currentAxisIndex]);
		ApplyModifications(_currentAxisIndex);
	}

	private void OnGuidedCalibrationComplete()
	{
		_inputEnabled = true;
		_calibrationPreview.enabled = true;
		RefreshUi();
	}

	private void ApplyModifications(int axisIndex)
	{
		if (AxisCalibration == null)
		{
			Debug.LogWarning("ApplyModifications: no axis calibration target selected!");
		}
		else
		{
			AxisCalibration.SetData(_modifiedData[axisIndex]);
		}
	}

	private void ResetModifications(int axisIndex)
	{
		if (_activeJoystick == null)
		{
			Debug.LogWarning("ResetModifications: no valid joystick!");
			return;
		}
		_activeJoystick.calibrationMap.Reset();
		_modifiedData[axisIndex] = _activeJoystick.calibrationMap.GetAxisData(axisIndex);
	}

	private void Cleanup()
	{
		_currentAxisIndex = -1;
		_inputEnabled = false;
		_deadZone.topUIElements.Clear();
		foreach (ControlMapping_AxisCalibrationSelector axisSelector in _axisSelectors)
		{
			axisSelector.gameObject.SetActive(value: false);
		}
		_axisSelectors.Clear();
		menuOptions.Clear();
	}

	public override List<MenuHelperButtons.HelpButtonTypes> GetHelpButtonsToShow()
	{
		return _helpButtons;
	}

	public override void Deactivate(bool pop)
	{
		Cleanup();
		base.Deactivate(pop);
		this.MenuClosed?.Invoke();
	}
}
