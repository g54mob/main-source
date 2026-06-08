using System;

namespace Timberborn.GoodConsumingBuildingSystem
{
	public class GoodConsumingToggle
	{
		public bool Paused { get; private set; }

		public event EventHandler StateChanged;

		public void ResumeConsumption()
		{
			if (Paused)
			{
				Paused = false;
				this.StateChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		public void PauseConsumption()
		{
			if (!Paused)
			{
				Paused = true;
				this.StateChanged?.Invoke(this, EventArgs.Empty);
			}
		}
	}
}
