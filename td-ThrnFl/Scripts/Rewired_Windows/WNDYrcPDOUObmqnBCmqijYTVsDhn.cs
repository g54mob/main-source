using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class WNDYrcPDOUObmqnBCmqijYTVsDhn
{
	private const bool KCqfFjymhzCvcBagbALjPqdMyQZRA = false;

	private static int lAYceABhtDTXIQRHfcLlHWHbKixA;

	private static ThreadHelper wllUmZRAwKxzxXnnlEJQHcHJfeNkA;

	private static ThreadHelper UMHzynuaJHPXJaDEGcCDJTkOqZjS;

	public static int CPLaRrFzUcOrwvDuUKrdhlDtwzfD => lAYceABhtDTXIQRHfcLlHWHbKixA;

	public static ThreadHelper pxHvRfxmQDEMqIUSXpfuzkxTYTHD => wllUmZRAwKxzxXnnlEJQHcHJfeNkA;

	public static ThreadHelper SkgyEqJhVQbyIlANlVNTxhVwJLTr => UMHzynuaJHPXJaDEGcCDJTkOqZjS;

	public static ThreadHelper stbFXYGdqGZahOUHVobnVZEOHNEX => wllUmZRAwKxzxXnnlEJQHcHJfeNkA;

	public static ThreadHelper nytSzNVIhUWoXZDzKGaUmjqGlQXF => UMHzynuaJHPXJaDEGcCDJTkOqZjS;

	public static ThreadHelper FYPcLCQKpmRyWIROScuQpIyGfqhm => wllUmZRAwKxzxXnnlEJQHcHJfeNkA;

	public static ThreadHelper GvwrzCEsPxPmYprhJxvxQNWAkyLJ => wllUmZRAwKxzxXnnlEJQHcHJfeNkA;

	public static bool tacJnAJMnHICfXDLFVCVMZwaCrur
	{
		get
		{
			if (wllUmZRAwKxzxXnnlEJQHcHJfeNkA != null)
			{
				return wllUmZRAwKxzxXnnlEJQHcHJfeNkA.isRunning;
			}
			return false;
		}
	}

	public static void XkFBMSYBBtgiSCQLXCPTmqNpFqTzA(bool P_0)
	{
		lAYceABhtDTXIQRHfcLlHWHbKixA = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (wllUmZRAwKxzxXnnlEJQHcHJfeNkA != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		wllUmZRAwKxzxXnnlEJQHcHJfeNkA = ThreadHelper.CreateFixedTimeStep(lAYceABhtDTXIQRHfcLlHWHbKixA);
		wllUmZRAwKxzxXnnlEJQHcHJfeNkA.Start(wait: true);
		if (P_0)
		{
			UMHzynuaJHPXJaDEGcCDJTkOqZjS = ThreadHelper.CreateFixedTimeStep(100);
			UMHzynuaJHPXJaDEGcCDJTkOqZjS.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += kVWNnYhHNUslcUZrBNGqNUVgWARL;
	}

	private static void kVWNnYhHNUslcUZrBNGqNUVgWARL(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (lAYceABhtDTXIQRHfcLlHWHbKixA != platformVar_joystickRefreshRate)
			{
				lAYceABhtDTXIQRHfcLlHWHbKixA = platformVar_joystickRefreshRate;
				wllUmZRAwKxzxXnnlEJQHcHJfeNkA.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void dQYgavNEvoJDZEMfULixAHPMzaFi()
	{
		ReInput.UpdateStartedEvent -= kVWNnYhHNUslcUZrBNGqNUVgWARL;
		if (wllUmZRAwKxzxXnnlEJQHcHJfeNkA != null)
		{
			wllUmZRAwKxzxXnnlEJQHcHJfeNkA.WaitForActionQueueToFinish();
			wllUmZRAwKxzxXnnlEJQHcHJfeNkA.Dispose();
			wllUmZRAwKxzxXnnlEJQHcHJfeNkA = null;
		}
		if (UMHzynuaJHPXJaDEGcCDJTkOqZjS != null)
		{
			UMHzynuaJHPXJaDEGcCDJTkOqZjS.WaitForActionQueueToFinish();
			UMHzynuaJHPXJaDEGcCDJTkOqZjS.Dispose();
			UMHzynuaJHPXJaDEGcCDJTkOqZjS = null;
		}
	}
}
