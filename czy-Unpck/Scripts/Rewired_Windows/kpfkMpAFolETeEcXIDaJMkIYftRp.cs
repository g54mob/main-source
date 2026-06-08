using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils.Classes.Utility;

internal static class kpfkMpAFolETeEcXIDaJMkIYftRp
{
	private const bool SDEIvLDgGyTHPEjxVVCDwjcPhTP = false;

	private static int cbZcwSbfCsAchybizZQOAcqTqw;

	private static ThreadHelper vYYVNSgbPBDRkKwouSOlygECPAY;

	private static ThreadHelper BbpCgzVGoaUzDvrKcMHGSSIfBTq;

	public static int joystickRefreshRate => cbZcwSbfCsAchybizZQOAcqTqw;

	public static ThreadHelper inputThread => vYYVNSgbPBDRkKwouSOlygECPAY;

	public static ThreadHelper outputThread => BbpCgzVGoaUzDvrKcMHGSSIfBTq;

	public static ThreadHelper joystickInputThread => vYYVNSgbPBDRkKwouSOlygECPAY;

	public static ThreadHelper joystickOutputThread => BbpCgzVGoaUzDvrKcMHGSSIfBTq;

	public static ThreadHelper mouseThread => vYYVNSgbPBDRkKwouSOlygECPAY;

	public static ThreadHelper keyboardThread => vYYVNSgbPBDRkKwouSOlygECPAY;

	public static bool isReady
	{
		get
		{
			if (vYYVNSgbPBDRkKwouSOlygECPAY != null)
			{
				return vYYVNSgbPBDRkKwouSOlygECPAY.isRunning;
			}
			return false;
		}
	}

	public static void XcqbVqdtLKNrEHBlIGziwanWbzsI()
	{
		cbZcwSbfCsAchybizZQOAcqTqw = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (vYYVNSgbPBDRkKwouSOlygECPAY != null)
		{
			goto IL_0016;
		}
		goto IL_004e;
		IL_0016:
		int num = -431097877;
		goto IL_001b;
		IL_001b:
		switch (num ^ -431097880)
		{
		case 0:
			break;
		case 3:
			throw new Exception("Input Thread Manager is already initialized.");
		case 4:
			goto IL_004e;
		case 2:
			goto IL_0095;
		default:
			ReInput.UpdateStartedEvent += bPcNfEqPfkhxjhZgEbcMduxztKY;
			return;
		}
		goto IL_0016;
		IL_0095:
		BbpCgzVGoaUzDvrKcMHGSSIfBTq = ThreadHelper.CreateFixedTimeStep(100);
		BbpCgzVGoaUzDvrKcMHGSSIfBTq.Start(wait: true);
		num = -431097879;
		goto IL_001b;
		IL_004e:
		vYYVNSgbPBDRkKwouSOlygECPAY = ThreadHelper.CreateFixedTimeStep(cbZcwSbfCsAchybizZQOAcqTqw);
		vYYVNSgbPBDRkKwouSOlygECPAY.Start(wait: true);
		if (!ReInput.configVars.useXInput)
		{
			int num2;
			if (ReInput.configuration.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
			{
				num = -431097878;
				num2 = num;
			}
			else
			{
				num = -431097879;
				num2 = num;
			}
			goto IL_001b;
		}
		goto IL_0095;
	}

	private static void bPcNfEqPfkhxjhZgEbcMduxztKY(UpdateLoopType P_0)
	{
		if (P_0 != UpdateLoopType.Update)
		{
			goto IL_0003;
		}
		goto IL_0064;
		IL_0003:
		int num = -966462497;
		goto IL_0008;
		IL_0008:
		int platformVar_joystickRefreshRate = default(int);
		while (true)
		{
			switch (num ^ -966462498)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 5:
				vYYVNSgbPBDRkKwouSOlygECPAY.fixedTimeStepFPS = platformVar_joystickRefreshRate;
				num = -966462500;
				continue;
			case 6:
				goto IL_004b;
			case 4:
				goto IL_0064;
			case 0:
				cbZcwSbfCsAchybizZQOAcqTqw = platformVar_joystickRefreshRate;
				num = -966462501;
				continue;
			case 2:
				return;
			}
			break;
			IL_004b:
			int num2;
			if (cbZcwSbfCsAchybizZQOAcqTqw != platformVar_joystickRefreshRate)
			{
				num = -966462498;
				num2 = num;
			}
			else
			{
				num = -966462500;
				num2 = num;
			}
		}
		goto IL_0003;
		IL_0064:
		platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		num = -966462504;
		goto IL_0008;
	}

	public static void WYoEhOBxiSjIYKwbsCHdGOUBXDbi()
	{
		ReInput.UpdateStartedEvent -= bPcNfEqPfkhxjhZgEbcMduxztKY;
		if (vYYVNSgbPBDRkKwouSOlygECPAY != null)
		{
			vYYVNSgbPBDRkKwouSOlygECPAY.WaitForActionQueueToFinish();
			goto IL_0022;
		}
		goto IL_006a;
		IL_006a:
		int num;
		int num2;
		if (BbpCgzVGoaUzDvrKcMHGSSIfBTq != null)
		{
			num = 1732621333;
			num2 = num;
		}
		else
		{
			num = 1732621334;
			num2 = num;
		}
		goto IL_0027;
		IL_0022:
		num = 1732621330;
		goto IL_0027;
		IL_0027:
		while (true)
		{
			switch (num ^ 0x6745B417)
			{
			case 3:
				break;
			default:
				return;
			case 5:
				vYYVNSgbPBDRkKwouSOlygECPAY.Dispose();
				num = 1732621335;
				continue;
			case 0:
				vYYVNSgbPBDRkKwouSOlygECPAY = null;
				num = 1732621331;
				continue;
			case 4:
				goto IL_006a;
			case 2:
				BbpCgzVGoaUzDvrKcMHGSSIfBTq.WaitForActionQueueToFinish();
				BbpCgzVGoaUzDvrKcMHGSSIfBTq.Dispose();
				BbpCgzVGoaUzDvrKcMHGSSIfBTq = null;
				num = 1732621334;
				continue;
			case 1:
				return;
			}
			break;
		}
		goto IL_0022;
	}
}
