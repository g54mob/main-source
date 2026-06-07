using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ModApi.Settings
{
	public interface IApplicationSettings
	{
		Version AppVersionLastRun { get; }

		int CurrentXmlVersion { get; }

		string DeviceId { get; }

		IReadOnlyList<EnabledMod> EnabledMods { get; }

		IGameSettings Game { get; }

		string GameStateId { get; }

		IModSettings ModSettings { get; }

		int NumberOfApplicationRuns { get; }

		IGameQualitySettings Quality { get; }

		bool ShowWhatsNew { get; set; }

		string UserName { get; }

		UserPreferences UserPrefs { get; }

		void Save();

		void SaveIfNecessary();

		XDocument SaveXml();
	}
}
