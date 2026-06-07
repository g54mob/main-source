using UnityEngine.UIElements;

namespace Kamgam.SettingsGenerator
{
	public class TextFieldUIElementResolver : SettingResolverForVisualElement, ISettingResolver
	{
		protected TextField _textfield;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[1] { SettingData.DataType.String };

		protected bool stopPropagation;

		public TextField Textfield
		{
			get
			{
				if ((_textfield == null && base.VisualElement != null) || _textfield != base.VisualElement)
				{
					_textfield = base.VisualElement as TextField;
					if (_textfield != null)
					{
						_textfield.RegisterValueChangedCallback(onValueChanged);
					}
				}
				return _textfield;
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
			_textfield = null;
			base.OnDisable();
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (Textfield != null)
			{
				Textfield.UnregisterValueChangedCallback(onValueChanged);
			}
		}

		protected void onValueChanged(ChangeEvent<string> evt)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetString(ID)?.SetValue(evt.newValue);
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
				SettingString settingString = SettingsProvider.Settings.GetString(ID);
				if (settingString != null)
				{
					Textfield.value = settingString.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
