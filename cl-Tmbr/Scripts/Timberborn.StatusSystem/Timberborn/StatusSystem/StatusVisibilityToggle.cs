using System;

namespace Timberborn.StatusSystem
{
	public class StatusVisibilityToggle
	{
		public bool Hidden { get; private set; }

		public event EventHandler StateChanged;

		public void Hide()
		{
			Hidden = true;
			this.StateChanged?.Invoke(this, EventArgs.Empty);
		}

		public void Show()
		{
			Hidden = false;
			this.StateChanged?.Invoke(this, EventArgs.Empty);
		}
	}
}
