using System.Collections.Generic;

namespace ModApi.Flight
{
	public interface ITimeManager
	{
		ITimeMultiplierMode CurrentMode { get; }

		double DeltaTime { get; }

		int ModeIndex { get; }

		IReadOnlyCollection<ITimeMultiplierMode> Modes { get; }

		bool Paused { get; }

		ITimeMultiplierMode RealTime { get; }

		ITimeMultiplierMode SlowMotion { get; }

		event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanged;

		event TimeMultiplierModeChangedDelegate TimeMultiplierModeChanging;

		bool CanSetTimeMultiplierMode(int modeIndex, out string failReason);

		void DecreaseTimeMultiplier();

		void IncreaseTimeMultiplier();

		void RequestPauseChange(bool paused, bool userInitiated);

		void SetFastForwardMode();

		void SetMode(int modeIndex, bool forceChange = false);

		void SetMode(ITimeMultiplierMode mode, bool forceChange = false);

		void SetNormalSpeedMode();

		void SetSlowMotionMode();
	}
}
