using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class MROXnswaFDYJOaQMZFuqDWLdEBUH
{
	private const bool CspjhvHjemiKOwvjgwkvOazssVaV = false;

	private static int rhLAWgbrwuAqbLAMINBVnwOtYHJv;

	private static ThreadHelper wPeCmVyvhDOdHJgqccMGxXTjrHcE;

	private static ThreadHelper EtKALtZHWSyrlcFPLrfTnbaiaQCw;

	public static int QLOtUfyZkbAhGxDQNPvrDkbJpnUT => rhLAWgbrwuAqbLAMINBVnwOtYHJv;

	public static ThreadHelper dMQVLzSRnMCjGIJDKsGyPVuzqPuw => wPeCmVyvhDOdHJgqccMGxXTjrHcE;

	public static ThreadHelper AxdygsuEKTDCizOEsuUTRfLWQHwi => EtKALtZHWSyrlcFPLrfTnbaiaQCw;

	public static ThreadHelper qiyreAjcjPJuJWySIGEplISgOUlm => wPeCmVyvhDOdHJgqccMGxXTjrHcE;

	public static ThreadHelper vLuOaJcYwVMvlDPcDIdIOawkciegA => EtKALtZHWSyrlcFPLrfTnbaiaQCw;

	public static ThreadHelper XQSJlGhEiztJiQoHTjXEaPycXqKrA => wPeCmVyvhDOdHJgqccMGxXTjrHcE;

	public static ThreadHelper OPvQZExuYufisbpgOLIfqsGypdcX => wPeCmVyvhDOdHJgqccMGxXTjrHcE;

	public static bool xRhaZQkDwOglJkJYGkpVAwyOPuVtA
	{
		get
		{
			if (wPeCmVyvhDOdHJgqccMGxXTjrHcE != null)
			{
				return wPeCmVyvhDOdHJgqccMGxXTjrHcE.isRunning;
			}
			return false;
		}
	}

	public static void NvCKeSxLIwPZyGnKMmwXYjNNDbct(bool P_0)
	{
		rhLAWgbrwuAqbLAMINBVnwOtYHJv = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (wPeCmVyvhDOdHJgqccMGxXTjrHcE != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		wPeCmVyvhDOdHJgqccMGxXTjrHcE = ThreadHelper.CreateFixedTimeStep(rhLAWgbrwuAqbLAMINBVnwOtYHJv);
		wPeCmVyvhDOdHJgqccMGxXTjrHcE.Start(wait: true);
		if (P_0)
		{
			EtKALtZHWSyrlcFPLrfTnbaiaQCw = ThreadHelper.CreateFixedTimeStep(100);
			EtKALtZHWSyrlcFPLrfTnbaiaQCw.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += uOLYlUOwQFGFYMkkKJeaxMFGNVqX;
	}

	private static void uOLYlUOwQFGFYMkkKJeaxMFGNVqX(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (rhLAWgbrwuAqbLAMINBVnwOtYHJv != platformVar_joystickRefreshRate)
			{
				rhLAWgbrwuAqbLAMINBVnwOtYHJv = platformVar_joystickRefreshRate;
				wPeCmVyvhDOdHJgqccMGxXTjrHcE.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void dcLYGpkGcnAsxIOwHMuvaqFFkyemc()
	{
		ReInput.UpdateStartedEvent -= uOLYlUOwQFGFYMkkKJeaxMFGNVqX;
		if (wPeCmVyvhDOdHJgqccMGxXTjrHcE != null)
		{
			wPeCmVyvhDOdHJgqccMGxXTjrHcE.WaitForActionQueueToFinish();
			wPeCmVyvhDOdHJgqccMGxXTjrHcE.Dispose();
			wPeCmVyvhDOdHJgqccMGxXTjrHcE = null;
		}
		if (EtKALtZHWSyrlcFPLrfTnbaiaQCw != null)
		{
			EtKALtZHWSyrlcFPLrfTnbaiaQCw.WaitForActionQueueToFinish();
			EtKALtZHWSyrlcFPLrfTnbaiaQCw.Dispose();
			EtKALtZHWSyrlcFPLrfTnbaiaQCw = null;
		}
	}
}
