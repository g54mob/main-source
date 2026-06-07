using System;
using Jundroo.Common.Platform;

namespace Jundroo.Common.Settings
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class EnumOptionAttribute : Attribute
	{
		public int AttributePriority { get; private set; }

		public string Description { get; set; }

		public DeviceFlags Devices { get; private set; }

		public string DisplayName { get; set; }

		public int DisplayOrder { get; set; }

		public SettingState State { get; set; }

		public string Warning { get; set; }

		public EnumOptionAttribute()
		{
			Devices = DeviceFlags.All;
			AttributePriority = -1;
			DisplayOrder = int.MaxValue;
		}

		public EnumOptionAttribute(string description)
		{
			Devices = DeviceFlags.All;
			AttributePriority = -1;
			DisplayOrder = int.MaxValue;
			Description = description;
		}

		public EnumOptionAttribute(string displayName, string description)
		{
			Devices = DeviceFlags.All;
			AttributePriority = -1;
			DisplayOrder = int.MaxValue;
			DisplayName = displayName;
			Description = description;
		}

		public EnumOptionAttribute(uint priority, DeviceFlags devices)
		{
			Devices = devices;
			AttributePriority = (int)priority;
		}
	}
}
