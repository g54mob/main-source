using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class rGfCWQcoVBNNMLBCPGciUTleuQNNA
{
	private const bool pfAwkZBsewZPOBvnsVcdSDTveVrX = false;

	private static int GHgZKCdhemxhpxVYIgsPdeugJhKI;

	private static ThreadHelper RvDdNpEqlHuHTfkkgyBAVbtsMlpRA;

	private static ThreadHelper jifdVFXXEIjzjeHPVaGJyfQljKPjb;

	public static int jBtHaTgeNpmGYIOhRQexVaFAnUZE => GHgZKCdhemxhpxVYIgsPdeugJhKI;

	public static ThreadHelper MopQALEjZYmFMrFOQneoXdYyVTzh => RvDdNpEqlHuHTfkkgyBAVbtsMlpRA;

	public static ThreadHelper brEcbGBmGBbIiYCSofFFIRzHJAvGB => jifdVFXXEIjzjeHPVaGJyfQljKPjb;

	public static ThreadHelper ReTQukjOlRfIJKzAIFnxdbenkGseb => RvDdNpEqlHuHTfkkgyBAVbtsMlpRA;

	public static ThreadHelper IQHdtlmEcHWkbcxkRQYEKZGhVkzr => jifdVFXXEIjzjeHPVaGJyfQljKPjb;

	public static ThreadHelper kJrmrwzOuvAZgjRxFoCQVfUzcTVI => RvDdNpEqlHuHTfkkgyBAVbtsMlpRA;

	public static ThreadHelper tMYCSyfyGknRwGpkOxVtsjyhxejg => RvDdNpEqlHuHTfkkgyBAVbtsMlpRA;

	public static bool AxYMUusowKqMZkAEUSTDojAJGiEx
	{
		get
		{
			if (RvDdNpEqlHuHTfkkgyBAVbtsMlpRA != null)
			{
				return RvDdNpEqlHuHTfkkgyBAVbtsMlpRA.isRunning;
			}
			return false;
		}
	}

	public static void iehvoyhuSqWtalEEWLqXMJtUrvdj(bool P_0)
	{
		GHgZKCdhemxhpxVYIgsPdeugJhKI = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (RvDdNpEqlHuHTfkkgyBAVbtsMlpRA != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		RvDdNpEqlHuHTfkkgyBAVbtsMlpRA = ThreadHelper.CreateFixedTimeStep(GHgZKCdhemxhpxVYIgsPdeugJhKI);
		RvDdNpEqlHuHTfkkgyBAVbtsMlpRA.Start(wait: true);
		if (P_0)
		{
			jifdVFXXEIjzjeHPVaGJyfQljKPjb = ThreadHelper.CreateFixedTimeStep(100);
			jifdVFXXEIjzjeHPVaGJyfQljKPjb.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += BJyuiBEAXXMKPxuaMJifllcFBdpe;
	}

	private static void BJyuiBEAXXMKPxuaMJifllcFBdpe(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (GHgZKCdhemxhpxVYIgsPdeugJhKI != platformVar_joystickRefreshRate)
			{
				GHgZKCdhemxhpxVYIgsPdeugJhKI = platformVar_joystickRefreshRate;
				RvDdNpEqlHuHTfkkgyBAVbtsMlpRA.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void UwMNTwqqzexhdhiVULxqLvpfopR()
	{
		ReInput.UpdateStartedEvent -= BJyuiBEAXXMKPxuaMJifllcFBdpe;
		if (RvDdNpEqlHuHTfkkgyBAVbtsMlpRA != null)
		{
			RvDdNpEqlHuHTfkkgyBAVbtsMlpRA.WaitForActionQueueToFinish();
			RvDdNpEqlHuHTfkkgyBAVbtsMlpRA.Dispose();
			RvDdNpEqlHuHTfkkgyBAVbtsMlpRA = null;
		}
		if (jifdVFXXEIjzjeHPVaGJyfQljKPjb != null)
		{
			jifdVFXXEIjzjeHPVaGJyfQljKPjb.WaitForActionQueueToFinish();
			jifdVFXXEIjzjeHPVaGJyfQljKPjb.Dispose();
			jifdVFXXEIjzjeHPVaGJyfQljKPjb = null;
		}
	}
}
