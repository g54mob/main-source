using System;

namespace ModApi.Settings.Core.Events
{
	public class SettingsChangedEventArgs<T> : EventArgs where T : SettingsCategory<T>
	{
		public T Category { get; private set; }

		public SettingsChangedEventArgs(T category)
		{
			Category = category;
		}
	}
}
