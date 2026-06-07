using System.Collections.Generic;
using System.Xml.Linq;
using ModApi.Settings.Core;

namespace ModApi.Settings
{
	public interface IGameSettings
	{
		AudioSettings Audio { get; }

		IReadOnlyList<SettingsCategory> Categories { get; }

		DesignerSettings Designer { get; }

		FlightSettings Flight { get; }

		GeneralSettings General { get; }

		MouseInputSettingsDesigner MouseInputDesigner { get; }

		MouseInputSettingsFlight MouseInputFlight { get; }

		void SaveToXml(XElement xml);
	}
}
