using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class rdYCGoWOpFzeWopaszcDvgrUprf
{
	private const bool DqnrAIFpmOQdbAzZloEJfhDHwTx = false;

	private static int rpGEgphMNyKmMkEDYtGELeFkwqO;

	private static ThreadHelper cSdBVPkTnzFxCaUYSnFlFzrQjYeG;

	public static ThreadHelper inputThread
	{
		get
		{
			return cSdBVPkTnzFxCaUYSnFlFzrQjYeG;
		}
	}

	public static ThreadHelper outputThread
	{
		get
		{
			return cSdBVPkTnzFxCaUYSnFlFzrQjYeG;
		}
	}

	public static ThreadHelper joystickInputThread
	{
		get
		{
			return cSdBVPkTnzFxCaUYSnFlFzrQjYeG;
		}
	}

	public static ThreadHelper joystickOutputThread
	{
		get
		{
			return cSdBVPkTnzFxCaUYSnFlFzrQjYeG;
		}
	}

	public static ThreadHelper mouseThread
	{
		get
		{
			return cSdBVPkTnzFxCaUYSnFlFzrQjYeG;
		}
	}

	public static ThreadHelper keyboardThread
	{
		get
		{
			return cSdBVPkTnzFxCaUYSnFlFzrQjYeG;
		}
	}

	public static bool isReady
	{
		get
		{
			if (cSdBVPkTnzFxCaUYSnFlFzrQjYeG != null)
			{
				return cSdBVPkTnzFxCaUYSnFlFzrQjYeG.isRunning;
			}
			return false;
		}
	}

	public static void GVPNrpnUrcRcuBVNsoUmnQYWdWW()
	{
		rpGEgphMNyKmMkEDYtGELeFkwqO = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (cSdBVPkTnzFxCaUYSnFlFzrQjYeG != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		while (true)
		{
			cSdBVPkTnzFxCaUYSnFlFzrQjYeG = ThreadHelper.CreateFixedTimeStep(rpGEgphMNyKmMkEDYtGELeFkwqO);
			int num = -1629976926;
			while (true)
			{
				switch (num ^ -1629976928)
				{
				case 0:
					goto IL_0021;
				case 1:
					break;
				default:
					cSdBVPkTnzFxCaUYSnFlFzrQjYeG.Start(true);
					ReInput.UpdateStartedEvent += kIXzpFcVxARmVrIGcxFIqaYrGmq;
					return;
				}
				break;
				IL_0021:
				num = -1629976927;
			}
		}
	}

	private static void kIXzpFcVxARmVrIGcxFIqaYrGmq(UpdateLoopType P_0)
	{
		if (P_0 != UpdateLoopType.Update)
		{
			goto IL_0003;
		}
		goto IL_002d;
		IL_0003:
		int num = -1803671002;
		goto IL_0008;
		IL_0008:
		switch (num ^ -1803671003)
		{
		case 2:
			break;
		default:
			return;
		case 3:
			return;
		case 0:
			goto IL_002d;
		case 1:
			return;
		}
		goto IL_0003;
		IL_002d:
		int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (rpGEgphMNyKmMkEDYtGELeFkwqO != platformVar_joystickRefreshRate)
		{
			rpGEgphMNyKmMkEDYtGELeFkwqO = platformVar_joystickRefreshRate;
			cSdBVPkTnzFxCaUYSnFlFzrQjYeG.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			num = -1803671004;
			goto IL_0008;
		}
	}

	public static void HtJdxRxaGggkmaMTSWUpHqjZLDV()
	{
		ReInput.UpdateStartedEvent -= kIXzpFcVxARmVrIGcxFIqaYrGmq;
		if (cSdBVPkTnzFxCaUYSnFlFzrQjYeG == null)
		{
			return;
		}
		while (true)
		{
			int num = 1266225092;
			while (true)
			{
				switch (num ^ 0x4B790FC7)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					cSdBVPkTnzFxCaUYSnFlFzrQjYeG.WaitForActionQueueToFinish();
					num = 1266225094;
					continue;
				case 1:
					cSdBVPkTnzFxCaUYSnFlFzrQjYeG.Dispose();
					cSdBVPkTnzFxCaUYSnFlFzrQjYeG = null;
					num = 1266225093;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}
}
