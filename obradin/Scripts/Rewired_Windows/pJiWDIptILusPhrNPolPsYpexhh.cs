using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class pJiWDIptILusPhrNPolPsYpexhh
{
	private const bool LeVFJcgcsKdoaVabOrAZufPjDFxJ = false;

	private static int pXgvxFMUVyxAVfgdpHYIKyPGrcA;

	private static ThreadHelper uaPUetVQtpwlPZDizXkxyMfgYTi;

	public static ThreadHelper inputThread
	{
		get
		{
			return uaPUetVQtpwlPZDizXkxyMfgYTi;
		}
	}

	public static ThreadHelper outputThread
	{
		get
		{
			return uaPUetVQtpwlPZDizXkxyMfgYTi;
		}
	}

	public static ThreadHelper joystickInputThread
	{
		get
		{
			return uaPUetVQtpwlPZDizXkxyMfgYTi;
		}
	}

	public static ThreadHelper joystickOutputThread
	{
		get
		{
			return uaPUetVQtpwlPZDizXkxyMfgYTi;
		}
	}

	public static ThreadHelper mouseThread
	{
		get
		{
			return uaPUetVQtpwlPZDizXkxyMfgYTi;
		}
	}

	public static ThreadHelper keyboardThread
	{
		get
		{
			return uaPUetVQtpwlPZDizXkxyMfgYTi;
		}
	}

	public static bool isReady
	{
		get
		{
			if (uaPUetVQtpwlPZDizXkxyMfgYTi != null)
			{
				return uaPUetVQtpwlPZDizXkxyMfgYTi.isRunning;
			}
			return false;
		}
	}

	public static void OXxfSVQgpwyQzMSlFTkamYYmQrW()
	{
		pXgvxFMUVyxAVfgdpHYIKyPGrcA = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (uaPUetVQtpwlPZDizXkxyMfgYTi != null)
		{
			while (true)
			{
				switch (0x5BC499C1 ^ 0x5BC499C0)
				{
				case 2:
					continue;
				case 1:
					throw new Exception("Input Thread Manager is already initialized.");
				}
				break;
			}
		}
		uaPUetVQtpwlPZDizXkxyMfgYTi = ThreadHelper.CreateFixedTimeStep(pXgvxFMUVyxAVfgdpHYIKyPGrcA);
		uaPUetVQtpwlPZDizXkxyMfgYTi.Start(true);
		ReInput.UpdateStartedEvent += irrFqjEFTMrQEPggZulYanAHGIeQ;
	}

	private static void irrFqjEFTMrQEPggZulYanAHGIeQ(UpdateLoopType P_0)
	{
		if (P_0 != UpdateLoopType.Update)
		{
			goto IL_0003;
		}
		goto IL_0049;
		IL_0003:
		int num = -1092711225;
		goto IL_0008;
		IL_0008:
		int platformVar_joystickRefreshRate = default(int);
		while (true)
		{
			switch (num ^ -1092711226)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				pXgvxFMUVyxAVfgdpHYIKyPGrcA = platformVar_joystickRefreshRate;
				uaPUetVQtpwlPZDizXkxyMfgYTi.fixedTimeStepFPS = platformVar_joystickRefreshRate;
				num = -1092711230;
				continue;
			case 2:
				goto IL_0049;
			case 4:
				return;
			}
			break;
		}
		goto IL_0003;
		IL_0049:
		platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		int num2;
		if (pXgvxFMUVyxAVfgdpHYIKyPGrcA == platformVar_joystickRefreshRate)
		{
			num = -1092711230;
			num2 = num;
		}
		else
		{
			num = -1092711226;
			num2 = num;
		}
		goto IL_0008;
	}

	public static void JGfOaxGMMubjxaprhTWpWgtvAPZ()
	{
		ReInput.UpdateStartedEvent -= irrFqjEFTMrQEPggZulYanAHGIeQ;
		while (true)
		{
			int num = -1455690022;
			while (true)
			{
				switch (num ^ -1455690021)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (uaPUetVQtpwlPZDizXkxyMfgYTi != null)
					{
						goto IL_0036;
					}
					return;
				case 0:
					return;
				}
				break;
				IL_0036:
				uaPUetVQtpwlPZDizXkxyMfgYTi.WaitForActionQueueToFinish();
				uaPUetVQtpwlPZDizXkxyMfgYTi.Dispose();
				uaPUetVQtpwlPZDizXkxyMfgYTi = null;
				num = -1455690021;
			}
		}
	}
}
