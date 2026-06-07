using UnityEngine.UIElements;

namespace Kamgam.SettingsGenerator
{
	public class ToggleUIElementResolver : SettingResolverForVisualElement, ISettingResolver
	{
		protected Toggle _toggle;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[1] { SettingData.DataType.Bool };

		protected bool stopPropagation;

		public Toggle Toggle
		{
			get
			{
				if ((_toggle == null && base.VisualElement != null) || _toggle != base.VisualElement)
				{
					_toggle = base.VisualElement as Toggle;
					if (_toggle != null)
					{
						_toggle.RegisterValueChangedCallback(onValueChanged);
					}
				}
				return _toggle;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			if (HasValidSettingForID(ID, GetSupportedDataTypes()))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		public override void OnDisable()
		{
			_toggle = null;
			base.OnDisable();
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (Toggle != null)
			{
				Toggle.UnregisterValueChangedCallback(onValueChanged);
			}
		}

		protected void onValueChanged(ChangeEvent<bool> evt)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetBool(ID)?.SetValue(evt.newValue);
			}
		}

		public override void Refresh()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
			{
				return;
			}
			try
			{
				stopPropagation = true;
				SettingBool settingBool = SettingsProvider.Settings.GetBool(ID);
				if (settingBool != null)
				{
					Toggle.value = settingBool.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
