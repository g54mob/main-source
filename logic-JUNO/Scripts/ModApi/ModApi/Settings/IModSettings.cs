using System.Collections.Generic;
using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public interface IModSettings
	{
		IReadOnlyList<SettingsCategory> Categories { get; }

		T GetCategory<T>() where T : SettingsCategory<T>;

		SettingsCategory GetCategoryByName(string categoryName);

		void LoadSettings();

		void RegisterCategory(SettingsCategory category);

		void SaveSettings();
	}
}
