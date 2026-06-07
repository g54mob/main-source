namespace ModApi.Flight
{
	public class TimeMultiplierModeChangedEvent
	{
		public ITimeMultiplierMode CurrentMode { get; private set; }

		public bool EnteredWarpMode { get; private set; }

		public bool ExitedWarpMode { get; private set; }

		public ITimeMultiplierMode PreviousMode { get; private set; }

		public TimeMultiplierModeChangedEvent(ITimeMultiplierMode currentMode, ITimeMultiplierMode previousMode, bool enteredWarp, bool exitedWarp)
		{
			CurrentMode = currentMode;
			PreviousMode = previousMode;
			EnteredWarpMode = enteredWarp;
			ExitedWarpMode = exitedWarp;
		}
	}
}
