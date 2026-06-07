using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils.Classes.Utility;

internal static class TOahviIJXSwhIkcLgNJHhAnDExwT
{
	private static int BOYbQOzFEIXZdebESgbXAnJiFfl;

	private static ThreadHelper OLCIXXYGlWdBoFQOPzBBAyuWeNAG;

	private static ThreadHelper UcViyAzpMXcpToCNIFozBLKNsJhxA;

	public static int msYvraZKixRWczNsdUKcrerceHvr => BOYbQOzFEIXZdebESgbXAnJiFfl;

	public static ThreadHelper gqqZYRewLjqhcutjWUAaQkwNKKCH => OLCIXXYGlWdBoFQOPzBBAyuWeNAG;

	public static ThreadHelper jzwtqIeVJjMJesGFTWJHnefCesGEA => UcViyAzpMXcpToCNIFozBLKNsJhxA;

	public static void GMwgCSEzvdRqhmLrEfVqGQDSHtkTA()
	{
		BOYbQOzFEIXZdebESgbXAnJiFfl = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (OLCIXXYGlWdBoFQOPzBBAyuWeNAG != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		OLCIXXYGlWdBoFQOPzBBAyuWeNAG = ThreadHelper.CreateFixedTimeStep(BOYbQOzFEIXZdebESgbXAnJiFfl);
		OLCIXXYGlWdBoFQOPzBBAyuWeNAG.Start(wait: true);
		if (ReInput.configVars.useXInput || ReInput.configuration.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
		{
			UcViyAzpMXcpToCNIFozBLKNsJhxA = ThreadHelper.CreateFixedTimeStep(100);
			UcViyAzpMXcpToCNIFozBLKNsJhxA.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += tBpeEVMsvNriHViUbnZKqYbGmjet;
	}

	private static void tBpeEVMsvNriHViUbnZKqYbGmjet(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (BOYbQOzFEIXZdebESgbXAnJiFfl != platformVar_joystickRefreshRate)
			{
				BOYbQOzFEIXZdebESgbXAnJiFfl = platformVar_joystickRefreshRate;
				OLCIXXYGlWdBoFQOPzBBAyuWeNAG.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void SoEjwuudRSwNDhKvMQQeGtZEItGW()
	{
		ReInput.UpdateStartedEvent -= tBpeEVMsvNriHViUbnZKqYbGmjet;
		if (OLCIXXYGlWdBoFQOPzBBAyuWeNAG != null)
		{
			OLCIXXYGlWdBoFQOPzBBAyuWeNAG.WaitForActionQueueToFinish();
			OLCIXXYGlWdBoFQOPzBBAyuWeNAG.Dispose();
			OLCIXXYGlWdBoFQOPzBBAyuWeNAG = null;
		}
		if (UcViyAzpMXcpToCNIFozBLKNsJhxA != null)
		{
			UcViyAzpMXcpToCNIFozBLKNsJhxA.WaitForActionQueueToFinish();
			UcViyAzpMXcpToCNIFozBLKNsJhxA.Dispose();
			UcViyAzpMXcpToCNIFozBLKNsJhxA = null;
		}
	}
}
