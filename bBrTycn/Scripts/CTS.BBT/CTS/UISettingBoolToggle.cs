using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UISettingBoolToggle : UISetting<bool>
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		protected CTSToggle _toggle;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnToggleValueChanged);
			_setting.ValueChanged += OnSettingValueChanged;
			OnSettingValueChanged(_setting.GetValue());
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
			_setting.ValueChanged -= OnSettingValueChanged;
		}

		private void OnSettingValueChanged(bool isTrue)
		{
			_toggle.isOn = isTrue;
		}

		private void OnToggleValueChanged(bool isOn)
		{
			_setting.SetValue(isOn);
		}
	}
}
