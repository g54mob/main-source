using System;

namespace Jundroo.Common.Settings.Events
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
