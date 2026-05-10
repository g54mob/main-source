using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UISettingBoolToggleGraphics : UISetting<FullScreenMode>
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

		private void OnSettingValueChanged(FullScreenMode ScreenValue)
		{
			if (ScreenValue == FullScreenMode.FullScreenWindow)
			{
				_toggle.isOn = true;
			}
			else
			{
				_toggle.isOn = false;
			}
		}

		private void OnToggleValueChanged(bool isOn)
		{
			if (isOn)
			{
				_setting.SetValue(FullScreenMode.FullScreenWindow);
			}
			else
			{
				_setting.SetValue(FullScreenMode.Windowed);
			}
		}
	}
}
