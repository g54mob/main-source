using System;

namespace Timberborn.WaterSystemRendering
{
	public class WaterOpacityToggle
	{
		public bool Hidden { get; private set; }

		public event EventHandler StateChanged;

		public void HideWater()
		{
			Hidden = true;
			this.StateChanged?.Invoke(this, EventArgs.Empty);
		}

		public void ShowWater()
		{
			Hidden = false;
			this.StateChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
