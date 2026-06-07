using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils.Classes.Utility;

internal static class FAsHqxeBatkZAlvOYNBwGTMPNyEq
{
	private const bool zaJgVXfpKguFlMXuTookGGqKkOKZ = false;

	private static int FMuvrqZJbEuGYvfakGqhgigjHnzHb;

	private static ThreadHelper WiLPSUWsFTNNUBMdoqtWAIUXEBVz;

	private static ThreadHelper oVqPrnlawkSdzsPTwDmjguQotSnGA;

	public static int JtkmrSfvKeyVdzOmZkiZGQIKPRUi => FMuvrqZJbEuGYvfakGqhgigjHnzHb;

	public static ThreadHelper ZZCSNUMjghhgIhMMfbevoedWiEvz => WiLPSUWsFTNNUBMdoqtWAIUXEBVz;

	public static ThreadHelper HwJOTRnCTifKuSMWMDHSQPOuaSPL => oVqPrnlawkSdzsPTwDmjguQotSnGA;

	public static ThreadHelper BMQiaDhybxWjplrhGBweujjxXQSA => WiLPSUWsFTNNUBMdoqtWAIUXEBVz;

	public static ThreadHelper svZOfWRkbIfRnkonNMcLizvfKloK => oVqPrnlawkSdzsPTwDmjguQotSnGA;

	public static ThreadHelper UvZnLxxVNcBJodfUNsThZpQLrQss => WiLPSUWsFTNNUBMdoqtWAIUXEBVz;

	public static ThreadHelper RbxGGYiTQZKxrLGMLwMITZePxqzg => WiLPSUWsFTNNUBMdoqtWAIUXEBVz;

	public static bool eIyVmoUwRpyHbzJqmKMUWVDGpJwH
	{
		get
		{
			if (WiLPSUWsFTNNUBMdoqtWAIUXEBVz != null)
			{
				return WiLPSUWsFTNNUBMdoqtWAIUXEBVz.isRunning;
			}
			return false;
		}
	}

	public static void qPhGjuHRNEfrkMynCGIBKdbFaOxF()
	{
		FMuvrqZJbEuGYvfakGqhgigjHnzHb = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (WiLPSUWsFTNNUBMdoqtWAIUXEBVz != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		WiLPSUWsFTNNUBMdoqtWAIUXEBVz = ThreadHelper.CreateFixedTimeStep(FMuvrqZJbEuGYvfakGqhgigjHnzHb);
		WiLPSUWsFTNNUBMdoqtWAIUXEBVz.Start(wait: true);
		if (ReInput.configVars.useXInput || ReInput.configuration.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
		{
			oVqPrnlawkSdzsPTwDmjguQotSnGA = ThreadHelper.CreateFixedTimeStep(100);
			oVqPrnlawkSdzsPTwDmjguQotSnGA.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += CbbyVMEHnkHpZyjpGIDxXOhsCFTq;
	}

	private static void CbbyVMEHnkHpZyjpGIDxXOhsCFTq(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (FMuvrqZJbEuGYvfakGqhgigjHnzHb != platformVar_joystickRefreshRate)
			{
				FMuvrqZJbEuGYvfakGqhgigjHnzHb = platformVar_joystickRefreshRate;
				WiLPSUWsFTNNUBMdoqtWAIUXEBVz.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void hIlanWXkrCYfgvCyascUuCUOCBcL()
	{
		ReInput.UpdateStartedEvent -= CbbyVMEHnkHpZyjpGIDxXOhsCFTq;
		if (WiLPSUWsFTNNUBMdoqtWAIUXEBVz != null)
		{
			WiLPSUWsFTNNUBMdoqtWAIUXEBVz.WaitForActionQueueToFinish();
			WiLPSUWsFTNNUBMdoqtWAIUXEBVz.Dispose();
			WiLPSUWsFTNNUBMdoqtWAIUXEBVz = null;
		}
		if (oVqPrnlawkSdzsPTwDmjguQotSnGA != null)
		{
			oVqPrnlawkSdzsPTwDmjguQotSnGA.WaitForActionQueueToFinish();
			oVqPrnlawkSdzsPTwDmjguQotSnGA.Dispose();
			oVqPrnlawkSdzsPTwDmjguQotSnGA = null;
		}
	}
}
