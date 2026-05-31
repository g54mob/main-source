using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils.Classes.Utility;

internal static class oizETVRXykJREMrljZxCoqipUeW
{
	private const bool QkSBgtSgYjTZtyNDqWLKqKKoQMC = false;

	private static int uOxfWOopZXMChGFFLMBvWWTkvdy;

	private static ThreadHelper nSSAXezYXSJmYoRYHXIomjutRvP;

	private static ThreadHelper JhzrwTEAyljLpDziRAKFCGuKdCz;

	public static int joystickRefreshRate => uOxfWOopZXMChGFFLMBvWWTkvdy;

	public static ThreadHelper inputThread => nSSAXezYXSJmYoRYHXIomjutRvP;

	public static ThreadHelper outputThread => JhzrwTEAyljLpDziRAKFCGuKdCz;

	public static ThreadHelper joystickInputThread => nSSAXezYXSJmYoRYHXIomjutRvP;

	public static ThreadHelper joystickOutputThread => JhzrwTEAyljLpDziRAKFCGuKdCz;

	public static ThreadHelper mouseThread => nSSAXezYXSJmYoRYHXIomjutRvP;

	public static ThreadHelper keyboardThread => nSSAXezYXSJmYoRYHXIomjutRvP;

	public static bool isReady
	{
		get
		{
			if (nSSAXezYXSJmYoRYHXIomjutRvP != null)
			{
				return nSSAXezYXSJmYoRYHXIomjutRvP.isRunning;
			}
			return false;
		}
	}

	public static void BVmTKMsAVVqdkfwNjSwlgNFzTsh()
	{
		uOxfWOopZXMChGFFLMBvWWTkvdy = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (nSSAXezYXSJmYoRYHXIomjutRvP != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		nSSAXezYXSJmYoRYHXIomjutRvP = ThreadHelper.CreateFixedTimeStep(uOxfWOopZXMChGFFLMBvWWTkvdy);
		nSSAXezYXSJmYoRYHXIomjutRvP.Start(wait: true);
		if (ReInput.configVars.useXInput || ReInput.configuration.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
		{
			JhzrwTEAyljLpDziRAKFCGuKdCz = ThreadHelper.CreateFixedTimeStep(100);
			JhzrwTEAyljLpDziRAKFCGuKdCz.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += tjoqqidvzxdbPPtOdFxXhjTSJLV;
	}

	private static void tjoqqidvzxdbPPtOdFxXhjTSJLV(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (uOxfWOopZXMChGFFLMBvWWTkvdy != platformVar_joystickRefreshRate)
			{
				uOxfWOopZXMChGFFLMBvWWTkvdy = platformVar_joystickRefreshRate;
				nSSAXezYXSJmYoRYHXIomjutRvP.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void KRgasgBmyLeCeDGJhNGqwMeOqCwJ()
	{
		ReInput.UpdateStartedEvent -= tjoqqidvzxdbPPtOdFxXhjTSJLV;
		if (nSSAXezYXSJmYoRYHXIomjutRvP != null)
		{
			nSSAXezYXSJmYoRYHXIomjutRvP.WaitForActionQueueToFinish();
			nSSAXezYXSJmYoRYHXIomjutRvP.Dispose();
			nSSAXezYXSJmYoRYHXIomjutRvP = null;
		}
		if (JhzrwTEAyljLpDziRAKFCGuKdCz != null)
		{
			JhzrwTEAyljLpDziRAKFCGuKdCz.WaitForActionQueueToFinish();
			JhzrwTEAyljLpDziRAKFCGuKdCz.Dispose();
			JhzrwTEAyljLpDziRAKFCGuKdCz = null;
		}
	}
}
