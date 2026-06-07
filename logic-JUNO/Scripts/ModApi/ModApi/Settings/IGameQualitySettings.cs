using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public interface IGameQualitySettings
	{
		IReadOnlyList<SettingsCategory> Categories { get; }

		CraftQualitySettings Crafts { get; }

		DisplayQualitySettings Display { get; }

		ImageEffectsQualitySettings ImageEffects { get; }

		MapQualitySettings Map { get; }

		PhysicsQualitySettings Physics { get; }

		ShadowQualitySettings Shadows { get; }

		TerrainQualitySettings Terrain { get; }

		VisualEffectsQualitySettings VisualEffects { get; }

		WaterQualitySettings Water { get; }

		void ApplySettings();

		void SaveToXml(XElement xml);
	}
}
