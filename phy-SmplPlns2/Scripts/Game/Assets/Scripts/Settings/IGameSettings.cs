using System.Collections.Generic;
using Jundroo.Common.Settings;

namespace Assets.Scripts.Settings
{
	public interface IGameSettings
	{
		AudioSettings Audio { get; }

		CameraSettings Camera { get; }

		IReadOnlyList<SettingsCategory> Categories { get; }

		CraftFilterSettings CraftFilters { get; }

		DesignerSettings Designer { get; }

		FlightSettings Flight { get; }

		GeneralSettings General { get; }

		MouseJoystickSettings MouseJoystick { get; }

		bool HasAnyUnsavedChanges();

		void Save();

		void SaveIfNecessary();
	}
}
