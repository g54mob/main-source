using System;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Cheats
{
	public class CheatPanelView : UIView
	{
		[Header("Position")]
		[SerializeField]
		private TMP_InputField _posXField;

		[SerializeField]
		private TMP_InputField _posYField;

		[SerializeField]
		private TMP_InputField _posZField;

		[SerializeField]
		private Button _setPositionButton;

		[Header("Plane Teleport")]
		[SerializeField]
		private TMP_InputField _planePosXField;

		[SerializeField]
		private TMP_InputField _planePosYField;

		[SerializeField]
		private TMP_InputField _planePosZField;

		[SerializeField]
		private Button _setPlanePositionButton;

		[Header("Save / Load")]
		[SerializeField]
		private Button _saveButton;

		[SerializeField]
		private Button _loadButton;

		[Header("Spawn")]
		[SerializeField]
		private TMP_Dropdown _spawnTMP_Dropdown;

		[SerializeField]
		private Button _spawnButton;

		[Header("Addiction")]
		[SerializeField]
		private Slider _drainSlider;

		[SerializeField]
		private TextMeshProUGUI _drainValueText;

		[SerializeField]
		private TMP_InputField _drainTMP_InputField;

		[SerializeField]
		private TextMeshProUGUI _alcoholText;

		[SerializeField]
		private TextMeshProUGUI _nicotineText;

		[SerializeField]
		private Button _setAddictionButton;

		[Header("Enemy Plane")]
		[SerializeField]
		private Button _spawnEnemyPlaneButton;

		[Header("Assembly")]
		[SerializeField]
		private Button _assembleEngineButton;

		[SerializeField]
		private Button _assemblePlaneButton;

		[SerializeField]
		private Button _disassembleEngineButton;

		[SerializeField]
		private Button _disassemblePlaneButton;

		[Header("Fly / Noclip")]
		[SerializeField]
		private Toggle _flyToggle;

		[SerializeField]
		private Toggle _noclipToggle;

		[SerializeField]
		private Slider _flySpeedSlider;

		[SerializeField]
		private TextMeshProUGUI _flySpeedValueText;

		[SerializeField]
		private TMP_InputField _flySpeedInput;

		[Header("Time Scale")]
		[SerializeField]
		private Slider _timeScaleSlider;

		[SerializeField]
		private TextMeshProUGUI _timeScaleValueText;

		[SerializeField]
		private Button _resetTimeScaleButton;

		[Header("Player Info")]
		[SerializeField]
		private TextMeshProUGUI _playerInfoText;

		[Header("Root panel to show/hide (child of this GameObject)")]
		[SerializeField]
		private GameObject _panel;

		[Inject]
		private CheatPanelViewModel _vm;

		[Inject]
		private CheatSettings _settings;

		private string _codeBuffer = string.Empty;

		protected override void Awake()
		{
			base.Awake();
		}

		protected override void Start()
		{
			_vm.Initialize();
			this.SetDataContext(_vm);
			if (_drainSlider != null)
			{
				_drainSlider.minValue = _settings.DrainMin;
				_drainSlider.maxValue = _settings.DrainMax;
			}
			if (_flySpeedSlider != null)
			{
				_flySpeedSlider.minValue = _settings.FlySpeedMin;
				_flySpeedSlider.maxValue = _settings.FlySpeedMax;
			}
			if (_timeScaleSlider != null)
			{
				_timeScaleSlider.minValue = _settings.TimeScaleMin;
				_timeScaleSlider.maxValue = _settings.TimeScaleMax;
			}
			if (_spawnTMP_Dropdown != null)
			{
				_spawnTMP_Dropdown.ClearOptions();
				_spawnTMP_Dropdown.AddOptions(_vm.GetSpawnableLabels());
			}
			BindingSet<CheatPanelView, CheatPanelViewModel> bindingSet = this.CreateBindingSet<CheatPanelView, CheatPanelViewModel>();
			if (_posXField != null)
			{
				bindingSet.Bind(_posXField).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((CheatPanelViewModel vm) => vm.PositionX)
					.TwoWay();
			}
			if (_posYField != null)
			{
				bindingSet.Bind(_posYField).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((CheatPanelViewModel vm) => vm.PositionY)
					.TwoWay();
			}
			if (_posZField != null)
			{
				bindingSet.Bind(_posZField).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((CheatPanelViewModel vm) => vm.PositionZ)
					.TwoWay();
			}
			if (_setPositionButton != null)
			{
				bindingSet.Bind(_setPositionButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.SetPositionCommand)
					.OneWay();
			}
			if (_planePosXField != null)
			{
				bindingSet.Bind(_planePosXField).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((CheatPanelViewModel vm) => vm.PlanePositionX)
					.TwoWay();
			}
			if (_planePosYField != null)
			{
				bindingSet.Bind(_planePosYField).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((CheatPanelViewModel vm) => vm.PlanePositionY)
					.TwoWay();
			}
			if (_planePosZField != null)
			{
				bindingSet.Bind(_planePosZField).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((CheatPanelViewModel vm) => vm.PlanePositionZ)
					.TwoWay();
			}
			if (_setPlanePositionButton != null)
			{
				bindingSet.Bind(_setPlanePositionButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.SetPlanePositionCommand)
					.OneWay();
			}
			if (_saveButton != null)
			{
				bindingSet.Bind(_saveButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.SaveCommand)
					.OneWay();
			}
			if (_loadButton != null)
			{
				bindingSet.Bind(_loadButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.LoadCommand)
					.OneWay();
			}
			if (_spawnTMP_Dropdown != null)
			{
				bindingSet.Bind(_spawnTMP_Dropdown).For((TMP_Dropdown v) => v.value, (TMP_Dropdown v) => v.onValueChanged).To((CheatPanelViewModel vm) => vm.SelectedSpawnIndex)
					.TwoWay();
			}
			if (_spawnButton != null)
			{
				bindingSet.Bind(_spawnButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.SpawnObjectCommand)
					.OneWay();
			}
			if (_drainSlider != null)
			{
				bindingSet.Bind(_drainSlider).For((Slider v) => v.value, (Slider v) => v.onValueChanged).To((CheatPanelViewModel vm) => vm.DrainMultiplier)
					.TwoWay();
			}
			if (_drainValueText != null)
			{
				bindingSet.Bind(_drainValueText).For((TextMeshProUGUI v) => v.text).To((CheatPanelViewModel vm) => vm.DrainDisplay)
					.OneWay();
			}
			if (_drainTMP_InputField != null)
			{
				bindingSet.Bind(_drainTMP_InputField).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((CheatPanelViewModel vm) => vm.DrainMultiplier)
					.TwoWay();
			}
			if (_alcoholText != null)
			{
				bindingSet.Bind(_alcoholText).For((TextMeshProUGUI v) => v.text).To((CheatPanelViewModel vm) => vm.AlcoholDisplay)
					.OneWay();
			}
			if (_nicotineText != null)
			{
				bindingSet.Bind(_nicotineText).For((TextMeshProUGUI v) => v.text).To((CheatPanelViewModel vm) => vm.NicotineDisplay)
					.OneWay();
			}
			if (_setAddictionButton != null)
			{
				bindingSet.Bind(_setAddictionButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.SetAddictionCommand)
					.OneWay();
			}
			if (_spawnEnemyPlaneButton != null)
			{
				bindingSet.Bind(_spawnEnemyPlaneButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.SpawnEnemyPlaneCommand)
					.OneWay();
			}
			if (_assembleEngineButton != null)
			{
				bindingSet.Bind(_assembleEngineButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.AssembleEngineCommand)
					.OneWay();
			}
			if (_assemblePlaneButton != null)
			{
				bindingSet.Bind(_assemblePlaneButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.AssemblePlaneCommand)
					.OneWay();
			}
			if (_disassembleEngineButton != null)
			{
				bindingSet.Bind(_disassembleEngineButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.DisassembleEngineCommand)
					.OneWay();
			}
			if (_disassemblePlaneButton != null)
			{
				bindingSet.Bind(_disassemblePlaneButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.DisassemblePlaneCommand)
					.OneWay();
			}
			if (_flyToggle != null)
			{
				bindingSet.Bind(_flyToggle).For((Toggle v) => v.isOn, (Toggle v) => v.onValueChanged).To((CheatPanelViewModel vm) => vm.FlyModeEnabled)
					.TwoWay();
			}
			if (_noclipToggle != null)
			{
				bindingSet.Bind(_noclipToggle).For((Toggle v) => v.isOn, (Toggle v) => v.onValueChanged).To((CheatPanelViewModel vm) => vm.NoclipEnabled)
					.TwoWay();
			}
			if (_flySpeedSlider != null)
			{
				bindingSet.Bind(_flySpeedSlider).For((Slider v) => v.value, (Slider v) => v.onValueChanged).To((CheatPanelViewModel vm) => vm.FlySpeed)
					.TwoWay();
			}
			if (_flySpeedValueText != null)
			{
				bindingSet.Bind(_flySpeedValueText).For((TextMeshProUGUI v) => v.text).To((CheatPanelViewModel vm) => vm.FlySpeedDisplay)
					.OneWay();
			}
			if (_flySpeedInput != null)
			{
				bindingSet.Bind(_flySpeedInput).For((TMP_InputField v) => v.text, (TMP_InputField v) => v.onEndEdit).To((CheatPanelViewModel vm) => vm.FlySpeed)
					.TwoWay();
			}
			if (_timeScaleSlider != null)
			{
				bindingSet.Bind(_timeScaleSlider).For((Slider v) => v.value, (Slider v) => v.onValueChanged).To((CheatPanelViewModel vm) => vm.TimeScale)
					.TwoWay();
			}
			if (_timeScaleValueText != null)
			{
				bindingSet.Bind(_timeScaleValueText).For((TextMeshProUGUI v) => v.text).To((CheatPanelViewModel vm) => vm.TimeScaleDisplay)
					.OneWay();
			}
			if (_resetTimeScaleButton != null)
			{
				bindingSet.Bind(_resetTimeScaleButton).For((Button v) => v.onClick).To((CheatPanelViewModel vm) => vm.ResetTimeScaleCommand)
					.OneWay();
			}
			if (_playerInfoText != null)
			{
				bindingSet.Bind(_playerInfoText).For((TextMeshProUGUI v) => v.text).To((CheatPanelViewModel vm) => vm.PlayerInfoDisplay)
					.OneWay();
			}
			bindingSet.Build();
			if (_panel != null)
			{
				_panel.SetActive(value: false);
			}
		}

		private void Update()
		{
			if (!TesterMode.IsTester)
			{
				DetectTesterCode();
			}
			if (TesterMode.IsTester && Input.GetKeyDown(_settings.ToggleKey))
			{
				bool flag = _panel != null && !_panel.activeSelf;
				if (_panel != null)
				{
					_panel.SetActive(flag);
				}
				CursorLockKeeper.Apply((!flag) ? CursorLockMode.Locked : CursorLockMode.None, flag);
				_vm.SetCameraRotation(!flag);
			}
			if (_panel != null && _panel.activeSelf)
			{
				_vm.RefreshPlayerInfo();
			}
		}

		private void DetectTesterCode()
		{
			string inputString = Input.inputString;
			if (string.IsNullOrEmpty(inputString))
			{
				return;
			}
			for (int i = 0; i < inputString.Length; i++)
			{
				char c = inputString[i];
				if (!char.IsLetter(c))
				{
					_codeBuffer = string.Empty;
					continue;
				}
				_codeBuffer += c;
				if (_codeBuffer.Length > "Wannabetester".Length)
				{
					_codeBuffer = _codeBuffer.Substring(_codeBuffer.Length - "Wannabetester".Length);
				}
				if (string.Equals(_codeBuffer, "Wannabetester", StringComparison.OrdinalIgnoreCase))
				{
					TesterMode.Enable();
					_codeBuffer = string.Empty;
					break;
				}
			}
		}
	}
}
