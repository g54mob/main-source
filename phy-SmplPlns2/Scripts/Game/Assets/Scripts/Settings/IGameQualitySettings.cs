using System.Collections.Generic;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public interface IGameQualitySettings
	{
		IReadOnlyList<SettingsCategory> Categories { get; }

		CraftQualitySettings Craft { get; }

		DisplayQualitySettings Display { get; }

		EnvironmentQualitySettings Environment { get; }

		GeneralQualitySettings General { get; }

		OverallQualitySetting OverallQuality { get; }

		PhysicsQualitySettings Physics { get; }

		PostProcessingQualitySettings PostProcessing { get; }

		ShadowQualitySettings Shadow { get; }

		WaterQualitySettings Water { get; }

		void ApplySettings();

		bool HasAnyUnsavedChanges();

		void Save();

		void SaveIfNecessary();
	}
}
