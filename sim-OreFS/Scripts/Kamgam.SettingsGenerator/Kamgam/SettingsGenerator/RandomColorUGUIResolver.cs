using System;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	[AddComponentMenu("UI/Settings/RandomColorUGUIResolver")]
	[RequireComponent(typeof(RandomColorUGUI))]
	public class RandomColorUGUIResolver : SettingResolver, ISettingResolver
	{
		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[1] { SettingData.DataType.Color };

		protected RandomColorUGUI randomColorUGUI;

		protected bool stopPropagation;

		public RandomColorUGUI RandomColorUGUI
		{
			get
			{
				if (randomColorUGUI == null)
				{
					randomColorUGUI = GetComponent<RandomColorUGUI>();
				}
				return randomColorUGUI;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void Start()
		{
			base.Start();
			RandomColorUGUI obj = RandomColorUGUI;
			obj.OnColorChanged = (RandomColorUGUI.OnColorChangedDelegate)Delegate.Combine(obj.OnColorChanged, new RandomColorUGUI.OnColorChangedDelegate(onColorChanged));
			if (HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (RandomColorUGUI != null)
			{
				RandomColorUGUI obj = RandomColorUGUI;
				obj.OnColorChanged = (RandomColorUGUI.OnColorChangedDelegate)Delegate.Remove(obj.OnColorChanged, new RandomColorUGUI.OnColorChangedDelegate(onColorChanged));
			}
		}

		private void onColorChanged(Color color)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				SettingsProvider.Settings.GetColor(ID).SetValue(color);
			}
		}

		public override void Refresh()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
			{
				return;
			}
			SettingColor color = SettingsProvider.Settings.GetColor(ID);
			if (color == null)
			{
				return;
			}
			try
			{
				stopPropagation = true;
				RandomColorUGUI.Color = color.GetValue();
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
