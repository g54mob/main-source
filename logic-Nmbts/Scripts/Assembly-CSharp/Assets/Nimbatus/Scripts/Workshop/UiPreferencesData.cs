using System;

namespace Assets.Nimbatus.Scripts.Workshop
{
	[Serializable]
	public class UiPreferencesData
	{
		public bool TagsEnabled { get; set; }

		public bool ShowKeyBindings { get; set; }

		public bool OverlapDetectionEnabled { get; set; }

		public bool ShowCenterOfMass { get; set; }

		public bool EnableWireless { get; set; }
	}
}
