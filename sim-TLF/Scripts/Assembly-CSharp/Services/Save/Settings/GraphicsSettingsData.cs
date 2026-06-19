using System;

namespace Services.Save.Settings
{
	[Serializable]
	public class GraphicsSettingsData
	{
		public bool VsyncEnabled = true;

		public bool VignetteEnabled = true;

		public bool MotionBlurEnabled = true;

		public bool CloudsEnabled = true;

		public int TargetFPS = 60;
	}
}
