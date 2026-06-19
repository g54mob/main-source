using System;

namespace Services.Save.Settings
{
	[Serializable]
	public class ControlsSettingsData
	{
		public float MouseSensitivity = 1f;

		public int ResolutionWidth;

		public int ResolutionHeight;

		public bool Windowed;
	}
}
