using System;
using Rewired;
using Rewired.Platforms;
using Rewired.Utils.Classes.Utility;

internal static class lOimudEEADkCsfXveaIQPguQeEbk
{
	private const bool JUPBqVNmwzcFFCuBoEuKdqhkNUKLA = false;

	private static int dYYZDIAmjTCBjgaDUxxyfcOCnQoD;

	private static ThreadHelper sQQRwUIryVtfMCIABEYIoqrVbUFG;

	private static ThreadHelper qdDkjNhxJYAbxpxZYuTefqZGAAaDA;

	public static int UkYuObHPviBjKuyijpofFIgljEwT => dYYZDIAmjTCBjgaDUxxyfcOCnQoD;

	public static ThreadHelper HkzeblrqkKpCcaUftGNPYdVMeucs => sQQRwUIryVtfMCIABEYIoqrVbUFG;

	public static ThreadHelper BMJMnJRvwBRxfBmAjpUPxmTKRAXD => qdDkjNhxJYAbxpxZYuTefqZGAAaDA;

	public static ThreadHelper ANuGBWudliodGbGfCbfveIhMhBLIA => sQQRwUIryVtfMCIABEYIoqrVbUFG;

	public static ThreadHelper HJgXpVuyIspPItbPFVgKPnoPkhXP => qdDkjNhxJYAbxpxZYuTefqZGAAaDA;

	public static ThreadHelper uwpBexBWGWmpdfhOmmwCWhywMHuAA => sQQRwUIryVtfMCIABEYIoqrVbUFG;

	public static ThreadHelper UmAaklaBQboCkMtgoBKvedMgANJkB => sQQRwUIryVtfMCIABEYIoqrVbUFG;

	public static bool wHccCBcWswsWSESQyJtkMLjfZycq
	{
		get
		{
			if (sQQRwUIryVtfMCIABEYIoqrVbUFG != null)
			{
				return sQQRwUIryVtfMCIABEYIoqrVbUFG.isRunning;
			}
			return false;
		}
	}

	public static void wSehDJUGscGiTKfpCfwnpqOXPkfaA()
	{
		dYYZDIAmjTCBjgaDUxxyfcOCnQoD = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (sQQRwUIryVtfMCIABEYIoqrVbUFG != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		sQQRwUIryVtfMCIABEYIoqrVbUFG = ThreadHelper.CreateFixedTimeStep(dYYZDIAmjTCBjgaDUxxyfcOCnQoD);
		sQQRwUIryVtfMCIABEYIoqrVbUFG.Start(wait: true);
		if (ReInput.configVars.useXInput || ReInput.configuration.windowsStandalonePrimaryInputSource == WindowsStandalonePrimaryInputSource.XInput)
		{
			qdDkjNhxJYAbxpxZYuTefqZGAAaDA = ThreadHelper.CreateFixedTimeStep(100);
			qdDkjNhxJYAbxpxZYuTefqZGAAaDA.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += HErTgKCcwMiuzMWQxiuPSIeFDghV;
	}

	private static void HErTgKCcwMiuzMWQxiuPSIeFDghV(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (dYYZDIAmjTCBjgaDUxxyfcOCnQoD != platformVar_joystickRefreshRate)
			{
				dYYZDIAmjTCBjgaDUxxyfcOCnQoD = platformVar_joystickRefreshRate;
				sQQRwUIryVtfMCIABEYIoqrVbUFG.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void mTQDlluQGHiXnqIhSRvnemGJEsTM()
	{
		ReInput.UpdateStartedEvent -= HErTgKCcwMiuzMWQxiuPSIeFDghV;
		if (sQQRwUIryVtfMCIABEYIoqrVbUFG != null)
		{
			sQQRwUIryVtfMCIABEYIoqrVbUFG.WaitForActionQueueToFinish();
			sQQRwUIryVtfMCIABEYIoqrVbUFG.Dispose();
			sQQRwUIryVtfMCIABEYIoqrVbUFG = null;
		}
		if (qdDkjNhxJYAbxpxZYuTefqZGAAaDA != null)
		{
			qdDkjNhxJYAbxpxZYuTefqZGAAaDA.WaitForActionQueueToFinish();
			qdDkjNhxJYAbxpxZYuTefqZGAAaDA.Dispose();
			qdDkjNhxJYAbxpxZYuTefqZGAAaDA = null;
		}
	}
}
