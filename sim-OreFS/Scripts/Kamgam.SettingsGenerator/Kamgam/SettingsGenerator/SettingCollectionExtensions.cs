using System.Collections.Generic;

namespace Kamgam.SettingsGenerator
{
	public static class SettingCollectionExtensions
	{
		public static IList<ISetting> PullFromConnection(this IList<ISetting> settings)
		{
			foreach (ISetting setting in settings)
			{
				setting.PullFromConnection();
			}
			return settings;
		}

		public static IList<ISetting> PushToConnection(this IList<ISetting> settings)
		{
			foreach (ISetting setting in settings)
			{
				setting.PullFromConnection();
			}
			return settings;
		}

		public static IList<ISetting> RefreshRegisteredResolvers(this IList<ISetting> settings, Settings settingsObj)
		{
			foreach (ISetting setting in settings)
			{
				settingsObj.RefreshRegisteredResolvers(setting.GetID());
			}
			return settings;
		}

		public static IList<ISetting> RefreshRegisteredResolvers(this IList<ISetting> settings, SettingsProvider provider)
		{
			if (!provider.HasSettings())
			{
				return settings;
			}
			foreach (ISetting setting in settings)
			{
				provider.Settings.RefreshRegisteredResolvers(setting.GetID());
			}
			return settings;
		}
	}
}
