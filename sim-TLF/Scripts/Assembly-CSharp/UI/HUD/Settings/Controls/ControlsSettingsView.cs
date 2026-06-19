using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.Views;
using Michsky.DreamOS;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.HUD.Settings.Controls
{
	public class ControlsSettingsView : UIView
	{
		[Header("Mouse Sensitivity")]
		[SerializeField]
		private Slider _sensitivitySlider;

		[SerializeField]
		private TextMeshProUGUI _sensitivityValueText;

		[Header("Display")]
		[SerializeField]
		private TMP_Dropdown _resolutionDropdown;

		[SerializeField]
		private SwitchManager _windowedSwitch;

		[Header("Window")]
		[SerializeField]
		private Button _closeButton;

		[Inject]
		private DiContainer _container;

		private ControlsSettingsViewModel _viewModel;

		protected override void Start()
		{
			_viewModel = _container.Instantiate<ControlsSettingsViewModel>();
			_viewModel.Initialize();
			this.SetDataContext(_viewModel);
			if (_resolutionDropdown != null)
			{
				_resolutionDropdown.ClearOptions();
				_resolutionDropdown.AddOptions(_viewModel.GetResolutionLabels());
			}
			BindingSet<ControlsSettingsView, ControlsSettingsViewModel> bindingSet = this.CreateBindingSet<ControlsSettingsView, ControlsSettingsViewModel>();
			bindingSet.Bind(_sensitivitySlider).For((Slider v) => v.value, (Slider v) => v.onValueChanged).To((ControlsSettingsViewModel vm) => vm.MouseSensitivity)
				.TwoWay();
			bindingSet.Bind(_sensitivityValueText).For((TextMeshProUGUI v) => v.text).To((ControlsSettingsViewModel vm) => vm.SensitivityDisplay)
				.OneWay();
			if (_resolutionDropdown != null)
			{
				bindingSet.Bind(_resolutionDropdown).For((TMP_Dropdown v) => v.value, (TMP_Dropdown v) => v.onValueChanged).To((ControlsSettingsViewModel vm) => vm.SelectedResolutionIndex)
					.TwoWay();
			}
			if (_closeButton != null)
			{
				_closeButton.onClick.AddListener(Close);
			}
			bindingSet.Build();
			if (_windowedSwitch != null)
			{
				bool isWindowed = _viewModel.IsWindowed;
				_windowedSwitch.isOn = isWindowed;
				_windowedSwitch.UpdateUI();
				if (isWindowed)
				{
					_windowedSwitch.SetOn();
				}
				else
				{
					_windowedSwitch.SetOff();
				}
				_windowedSwitch.onValueChanged.AddListener(OnWindowedChanged);
			}
		}

		private void OnWindowedChanged(bool value)
		{
			_viewModel.IsWindowed = value;
		}

		public void Open()
		{
			base.gameObject.SetActive(value: true);
		}

		private void Close()
		{
			_viewModel?.SaveSettings();
			base.gameObject.SetActive(value: false);
		}
	}
}
