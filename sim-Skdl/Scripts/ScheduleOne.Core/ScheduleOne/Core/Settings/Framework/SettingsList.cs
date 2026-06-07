using System;
using System.Collections.Generic;

namespace ScheduleOne.Core.Settings.Framework
{
	public abstract class SettingsList<T> : SettingsObject
	{
		public List<T> Items;

		public SettingsList(string name)
			: base(null)
		{
		}

		public override Type GetObjectType()
		{
			return null;
		}
	}
}
