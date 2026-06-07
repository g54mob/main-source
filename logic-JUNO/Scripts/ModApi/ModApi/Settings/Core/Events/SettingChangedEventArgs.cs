using System;

namespace ModApi.Settings.Core.Events
{
	public class SettingChangedEventArgs<T> : EventArgs where T : struct
	{
		public Setting<T> Setting { get; private set; }

		public SettingChangedEventArgs(Setting<T> setting)
		{
			Setting = setting;
		}
	}
}
