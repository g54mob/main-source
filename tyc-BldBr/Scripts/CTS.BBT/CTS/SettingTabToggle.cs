using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class SettingTabToggle : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private Image _iconImage;

		[SerializeField]
		private SettingTabData _tab;

		protected override void OnAwake()
		{
			base.OnAwake();
			_toggle.group = GetComponentInParent<ToggleGroup>();
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_toggle.onValueChanged.AddListener(OnToggleValueChanged);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
		}

		public void SetOn()
		{
			_toggle.isOn = true;
		}

		private void OnToggleValueChanged(bool isOn)
		{
			if (isOn && CTSSingleton<SettingsInterface>.TryGetInstance(out var outInstance))
			{
				outInstance.SwitchToTab(_tab);
			}
		}

		public void Initialize(SettingTabData tab)
		{
			_tab = tab;
			_iconImage.sprite = _tab.ToggleIcon;
		}
	}
}
