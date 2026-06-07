using System;
using System.Collections.Generic;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/ColorPickerUGUIResolver")]
	[RequireComponent(typeof(ColorPickerUGUI))]
	public class ColorPickerUGUIResolver : SettingResolver, ISettingResolver
	{
		protected ColorPickerUGUI colorPickerUGUI;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[2]
		{
			SettingData.DataType.ColorOption,
			SettingData.DataType.Int
		};

		protected bool stopPropagation;

		public ColorPickerUGUI ColorPickerUGUI
		{
			get
			{
				if (colorPickerUGUI == null)
				{
					colorPickerUGUI = GetComponent<ColorPickerUGUI>();
				}
				return colorPickerUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			ColorPickerUGUI obj = ColorPickerUGUI;
			obj.OnSelectionChanged = (ColorPickerUGUI.OnSelectionChangedDelegate)Delegate.Combine(obj.OnSelectionChanged, new ColorPickerUGUI.OnSelectionChangedDelegate(onSelectionChanged));
			if (HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		private void onSelectionChanged(int selectedIndex)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingColorOption colorOption = SettingsProvider.Settings.GetColorOption(ID);
				if (colorOption != null)
				{
					colorOption.SetValue(selectedIndex);
				}
				else
				{
					SettingsProvider.Settings.GetInt(ID)?.SetValue(selectedIndex);
				}
			}
		}

		public override void Refresh()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
			{
				return;
			}
			SettingColorOption colorOption = SettingsProvider.Settings.GetColorOption(ID);
			if (colorOption != null)
			{
				stopPropagation = true;
				try
				{
					refreshOptions();
					ColorPickerUGUI.SelectedIndex = colorOption.GetValue();
					return;
				}
				finally
				{
					stopPropagation = false;
				}
			}
			SettingInt settingInt = SettingsProvider.Settings.GetInt(ID);
			if (settingInt == null)
			{
				return;
			}
			stopPropagation = true;
			try
			{
				settingInt.PullFromConnection();
				ColorPickerUGUI.SelectedIndex = settingInt.GetValue();
				stopPropagation = false;
			}
			finally
			{
				stopPropagation = false;
			}
		}

		private void refreshOptions()
		{
			if (!HasActiveSettingForID(ID))
			{
				return;
			}
			SettingColorOption colorOption = SettingsProvider.Settings.GetColorOption(ID);
			if (colorOption != null)
			{
				if (colorOption.HasOptions())
				{
					ColorPickerUGUI.SetColorOptions(colorOption.GetOptionLabels());
					return;
				}
				List<Color> colorOptions = ColorPickerUGUI.GetColorOptions();
				colorOption.SetOptionLabels(colorOptions);
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (ColorPickerUGUI != null)
			{
				ColorPickerUGUI obj = ColorPickerUGUI;
				obj.OnSelectionChanged = (ColorPickerUGUI.OnSelectionChangedDelegate)Delegate.Remove(obj.OnSelectionChanged, new ColorPickerUGUI.OnSelectionChangedDelegate(onSelectionChanged));
			}
		}
	}
}
