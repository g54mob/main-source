using System.Collections.Generic;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public interface IModSettings
	{
		IReadOnlyList<SettingsCategory> Categories { get; }

		T GetCategory<T>() where T : SettingsCategory<T>;

		SettingsCategory GetCategoryByName(string categoryName);

		bool HasAnyUnsavedChanges();

		void RegisterCategory(SettingsCategory category);

		void Save();

		void SaveIfNecessary();
	}
}
