using System;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/TextfieldUGUIResolver")]
	[RequireComponent(typeof(TextfieldUGUI))]
	public class TextfieldUGUIResolver : SettingResolver, ISettingResolver
	{
		protected TextfieldUGUI textfieldUGUI;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[1] { SettingData.DataType.String };

		protected bool stopPropagation;

		public TextfieldUGUI TextfieldUGUI
		{
			get
			{
				if (textfieldUGUI == null)
				{
					textfieldUGUI = GetComponent<TextfieldUGUI>();
				}
				return textfieldUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			TextfieldUGUI obj = TextfieldUGUI;
			obj.OnTextChanged = (TextfieldUGUI.OnTextChangedDelegate)Delegate.Combine(obj.OnTextChanged, new TextfieldUGUI.OnTextChangedDelegate(onTextChanged));
			if (HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (TextfieldUGUI != null)
			{
				TextfieldUGUI obj = TextfieldUGUI;
				obj.OnTextChanged = (TextfieldUGUI.OnTextChangedDelegate)Delegate.Remove(obj.OnTextChanged, new TextfieldUGUI.OnTextChangedDelegate(onTextChanged));
			}
		}

		private void onTextChanged(string text)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetString(ID)?.SetValue(text);
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
					TextfieldUGUI.Text = settingString.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
