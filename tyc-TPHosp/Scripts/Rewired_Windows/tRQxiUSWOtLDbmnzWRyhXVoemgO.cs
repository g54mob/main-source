using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils.Classes.Utility;

internal static class tRQxiUSWOtLDbmnzWRyhXVoemgO
{
	private const bool RDpUtsNnkaePUJQJBKchMPvvaEUV = false;

	private static int hEOGLJjbDCwUfIwBugceZbpOYxpL;

	private static ThreadHelper sDnjchuxpNSXfYzOcztZZeTsfVB;

	private static ThreadHelper IYWeBWZvOeBbUtdmeuaydQPTQCb;

	public static int joystickRefreshRate => hEOGLJjbDCwUfIwBugceZbpOYxpL;

	public static ThreadHelper inputThread => sDnjchuxpNSXfYzOcztZZeTsfVB;

	public static ThreadHelper outputThread => IYWeBWZvOeBbUtdmeuaydQPTQCb;

	public static ThreadHelper joystickInputThread => sDnjchuxpNSXfYzOcztZZeTsfVB;

	public static ThreadHelper joystickOutputThread => IYWeBWZvOeBbUtdmeuaydQPTQCb;

	public static ThreadHelper mouseThread => sDnjchuxpNSXfYzOcztZZeTsfVB;

	public static ThreadHelper keyboardThread => sDnjchuxpNSXfYzOcztZZeTsfVB;

	public static bool isReady
	{
		get
		{
			if (sDnjchuxpNSXfYzOcztZZeTsfVB != null)
			{
				return sDnjchuxpNSXfYzOcztZZeTsfVB.isRunning;
			}
			return false;
		}
	}

	public static void EhDmNHbdNOhARNgJSMpMFgeqbsn()
	{
		hEOGLJjbDCwUfIwBugceZbpOYxpL = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (sDnjchuxpNSXfYzOcztZZeTsfVB != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		sDnjchuxpNSXfYzOcztZZeTsfVB = ThreadHelper.CreateFixedTimeStep(hEOGLJjbDCwUfIwBugceZbpOYxpL);
		sDnjchuxpNSXfYzOcztZZeTsfVB.Start(wait: true);
		if (ReInput.configVars.useXInput || ReInput.configuration.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
		{
			IYWeBWZvOeBbUtdmeuaydQPTQCb = ThreadHelper.CreateFixedTimeStep(100);
			IYWeBWZvOeBbUtdmeuaydQPTQCb.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += ywJMSnmqXyrqanBESFuiAOcJPKZ;
	}

	private static void ywJMSnmqXyrqanBESFuiAOcJPKZ(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (hEOGLJjbDCwUfIwBugceZbpOYxpL != platformVar_joystickRefreshRate)
			{
				hEOGLJjbDCwUfIwBugceZbpOYxpL = platformVar_joystickRefreshRate;
				sDnjchuxpNSXfYzOcztZZeTsfVB.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void LLOFbzNISIbRkZTwkaVnsPpYig()
	{
		ReInput.UpdateStartedEvent -= ywJMSnmqXyrqanBESFuiAOcJPKZ;
		if (sDnjchuxpNSXfYzOcztZZeTsfVB != null)
		{
			sDnjchuxpNSXfYzOcztZZeTsfVB.WaitForActionQueueToFinish();
			sDnjchuxpNSXfYzOcztZZeTsfVB.Dispose();
			sDnjchuxpNSXfYzOcztZZeTsfVB = null;
		}
		if (IYWeBWZvOeBbUtdmeuaydQPTQCb != null)
		{
			IYWeBWZvOeBbUtdmeuaydQPTQCb.WaitForActionQueueToFinish();
			IYWeBWZvOeBbUtdmeuaydQPTQCb.Dispose();
			IYWeBWZvOeBbUtdmeuaydQPTQCb = null;
		}
	}
}
