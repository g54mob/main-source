using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class GGlKyqwtSRgaaWuZtxjwSYfoOckk
{
	private const bool IsWUGnJlVekhgQBmCWGhXuDhBaCj = false;

	private static int dbwzQqfnhwAIHaBFgdqBcAssiBzx;

	private static ThreadHelper wiZhpPqhuZqsvdVjGEWCoAbaxtGV;

	private static ThreadHelper OfdkxzDsPEFKDUuGtoDRebGbJKkiA;

	public static int IxvjPdsczxfVuHMZdgPbDANUNliEb => dbwzQqfnhwAIHaBFgdqBcAssiBzx;

	public static ThreadHelper xursqpKGiGkTeiYOmTuiMcCgqPQr => wiZhpPqhuZqsvdVjGEWCoAbaxtGV;

	public static ThreadHelper MMCjDemDLTwzKFYVIAkJQbvPBCUU => OfdkxzDsPEFKDUuGtoDRebGbJKkiA;

	public static ThreadHelper aAXwUWdIwRCtrGoXoWkdjmgtCORGb => wiZhpPqhuZqsvdVjGEWCoAbaxtGV;

	public static ThreadHelper tRiPHogfXqTNFrlrzXWBLUlWuMgA => OfdkxzDsPEFKDUuGtoDRebGbJKkiA;

	public static ThreadHelper ZOhWYKdrGbddAcGMhjdMCpUdgywg => wiZhpPqhuZqsvdVjGEWCoAbaxtGV;

	public static ThreadHelper QVGeCqvVEoUHERnPuwYzpillffKD => wiZhpPqhuZqsvdVjGEWCoAbaxtGV;

	public static bool rRUxuIcUvMCPjrDPiVLFfiYXvehU
	{
		get
		{
			if (wiZhpPqhuZqsvdVjGEWCoAbaxtGV != null)
			{
				return wiZhpPqhuZqsvdVjGEWCoAbaxtGV.isRunning;
			}
			return false;
		}
	}

	public static void HdhRnQdBBsnTOwgZyYRTDUbWtiCj(bool P_0)
	{
		dbwzQqfnhwAIHaBFgdqBcAssiBzx = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (wiZhpPqhuZqsvdVjGEWCoAbaxtGV != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		wiZhpPqhuZqsvdVjGEWCoAbaxtGV = ThreadHelper.CreateFixedTimeStep(dbwzQqfnhwAIHaBFgdqBcAssiBzx);
		wiZhpPqhuZqsvdVjGEWCoAbaxtGV.Start(wait: true);
		if (P_0)
		{
			OfdkxzDsPEFKDUuGtoDRebGbJKkiA = ThreadHelper.CreateFixedTimeStep(100);
			OfdkxzDsPEFKDUuGtoDRebGbJKkiA.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += izqQsSGbFHeliuvjcPMecBbPfLSfA;
	}

	private static void izqQsSGbFHeliuvjcPMecBbPfLSfA(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (dbwzQqfnhwAIHaBFgdqBcAssiBzx != platformVar_joystickRefreshRate)
			{
				dbwzQqfnhwAIHaBFgdqBcAssiBzx = platformVar_joystickRefreshRate;
				wiZhpPqhuZqsvdVjGEWCoAbaxtGV.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void vzobnjikpbJGXwXzjSFjvdvtasMu()
	{
		ReInput.UpdateStartedEvent -= izqQsSGbFHeliuvjcPMecBbPfLSfA;
		if (wiZhpPqhuZqsvdVjGEWCoAbaxtGV != null)
		{
			wiZhpPqhuZqsvdVjGEWCoAbaxtGV.WaitForActionQueueToFinish();
			wiZhpPqhuZqsvdVjGEWCoAbaxtGV.Dispose();
			wiZhpPqhuZqsvdVjGEWCoAbaxtGV = null;
		}
		if (OfdkxzDsPEFKDUuGtoDRebGbJKkiA != null)
		{
			OfdkxzDsPEFKDUuGtoDRebGbJKkiA.WaitForActionQueueToFinish();
			OfdkxzDsPEFKDUuGtoDRebGbJKkiA.Dispose();
			OfdkxzDsPEFKDUuGtoDRebGbJKkiA = null;
		}
	}
}
