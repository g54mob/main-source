using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Settings;
using ModApi.Settings.Core;

namespace Assets.Scripts.Settings
{
	public class GameSettings : IGameSettings
	{
		public AudioSettings Audio { get; private set; }

		public IReadOnlyList<SettingsCategory> Categories { get; private set; }

		public DesignerSettings Designer { get; private set; }

		public FlightSettings Flight { get; private set; }

		public GeneralSettings General { get; private set; }

		public MouseInputSettingsDesigner MouseInputDesigner { get; private set; }

		public MouseInputSettingsFlight MouseInputFlight { get; private set; }

		public UserSettings User { get; private set; }

		public static GameSettings CreateFromXml(XElement xml)
		{
			GameSettings gameSettings = new GameSettings();
			gameSettings.Categories = SettingsCategory.InitializeCategoryProperties(gameSettings, xml?.Element("Game"));
			return gameSettings;
		}

		public void SaveToXml(XElement xml)
		{
			XElement xElement = new XElement("Game");
			foreach (SettingsCategory category in Categories)
			{
				category.SaveToXml(xElement);
			}
			xml.Add(xElement);
		}
	}
}
