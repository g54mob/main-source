using System;

namespace ScheduleOne.Core.Settings.Framework
{
	[Serializable]
	public class SettingsField<T> : SettingsObject
	{
		public bool Override;

		public T Value;

		public SettingsField(string name, T defaultValue)
			: base(null)
		{
		}

		public override void TryOverwriteWith(SettingsObject other)
		{
		}

		private void OverwriteWith(SettingsField<T> other)
		{
		}

		public override Type GetObjectType()
		{
			return null;
		}
	}
}
