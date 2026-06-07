using System.Collections.Generic;

namespace ModApi.Settings.Core
{
	public static class SettingsExtensions
	{
		public static bool HasUnsavedChanges<T>(this IEnumerable<T> categories) where T : SettingsCategory
		{
			foreach (T category in categories)
			{
				if (category.HasUnsavedChanges)
				{
					return true;
				}
			}
			return false;
		}
	}
}
