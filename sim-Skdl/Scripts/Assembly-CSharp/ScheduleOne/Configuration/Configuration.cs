using ScheduleOne.Core.Settings.Framework;

namespace ScheduleOne.Configuration
{
	public abstract class Configuration<T> : BaseConfiguration where T : Settings
	{
		public T Settings { get; private set; }

		private T DefaultSettings { get; set; }

		public override void ValidateConfiguration()
		{
		}

		public override void ResetConfigurationToDefault()
		{
		}

		public override Settings GetSettings()
		{
			return null;
		}

		public void ApplySettings(T newSettings)
		{
		}

		private static void ApplyOverwrites(T from, T to)
		{
		}
	}
}
