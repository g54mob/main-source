using System;

namespace ScheduleOne.Core.Settings.Framework
{
	[Serializable]
	public class ExtendibleSettingsList<T> : SettingsList<T>
	{
		public ExtendibleSettingsList(string name)
			: base((string)null)
		{
		}

		public virtual void OverwriteWith(ExtendibleSettingsList<T> other)
		{
		}

		public override void TryOverwriteWith(SettingsObject other)
		{
		}
	}
}
