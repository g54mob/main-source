using System;
using Rewired;
using Rewired.Utils.Classes.Utility;

internal static class YMIsqNPkWjrdLcJvEeLWjHNzddLY
{
	private const bool hizMoRNIENaqLzkkAZOqGqVJxWKp = false;

	private static int JcWlYkdvlzHzkXIqrkQnmmTwWnlT;

	private static ThreadHelper CDtihCFcHyYumCfjjIRKUYzMEFBNA;

	private static ThreadHelper wnAbEbkBcDpUFXYPjgOrfortOIrcb;

	public static int BKENsSJCwPFOTXkHKUNFIlpBJfYC => JcWlYkdvlzHzkXIqrkQnmmTwWnlT;

	public static ThreadHelper DPaJcIieuIcNqJPIcEQvCmIAXEhmb => CDtihCFcHyYumCfjjIRKUYzMEFBNA;

	public static ThreadHelper PAhlPTLHxDtKCwODZfvCElmzqEVD => wnAbEbkBcDpUFXYPjgOrfortOIrcb;

	public static ThreadHelper RiiNBuDyqUdVNZGxijqmyUOsLcUi => CDtihCFcHyYumCfjjIRKUYzMEFBNA;

	public static ThreadHelper unrfEQlddjGfPMFnGuoLscUgiQqR => wnAbEbkBcDpUFXYPjgOrfortOIrcb;

	public static ThreadHelper KnvAolJLZLkcCgFMEtzfeRvWOUugA => CDtihCFcHyYumCfjjIRKUYzMEFBNA;

	public static ThreadHelper PjTjdMQIpahcHlIvKKHUHNOKfYvE => CDtihCFcHyYumCfjjIRKUYzMEFBNA;

	public static bool wCMasakhuSEPRXswjRqWScaROlgx
	{
		get
		{
			if (CDtihCFcHyYumCfjjIRKUYzMEFBNA != null)
			{
				return CDtihCFcHyYumCfjjIRKUYzMEFBNA.isRunning;
			}
			return false;
		}
	}

	public static void sXJldihOTtQuAobmFasPIcWImTtk(bool P_0)
	{
		JcWlYkdvlzHzkXIqrkQnmmTwWnlT = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
		if (CDtihCFcHyYumCfjjIRKUYzMEFBNA != null)
		{
			throw new Exception("Input Thread Manager is already initialized.");
		}
		CDtihCFcHyYumCfjjIRKUYzMEFBNA = ThreadHelper.CreateFixedTimeStep(JcWlYkdvlzHzkXIqrkQnmmTwWnlT);
		CDtihCFcHyYumCfjjIRKUYzMEFBNA.Start(wait: true);
		if (P_0)
		{
			wnAbEbkBcDpUFXYPjgOrfortOIrcb = ThreadHelper.CreateFixedTimeStep(100);
			wnAbEbkBcDpUFXYPjgOrfortOIrcb.Start(wait: true);
		}
		ReInput.UpdateStartedEvent += MjLZKAwbhFKDnQfzHDbpJVEfDZNm;
	}

	private static void MjLZKAwbhFKDnQfzHDbpJVEfDZNm(UpdateLoopType P_0)
	{
		if (P_0 == UpdateLoopType.Update)
		{
			int platformVar_joystickRefreshRate = ReInput.configVars.GetPlatformVar_joystickRefreshRate();
			if (JcWlYkdvlzHzkXIqrkQnmmTwWnlT != platformVar_joystickRefreshRate)
			{
				JcWlYkdvlzHzkXIqrkQnmmTwWnlT = platformVar_joystickRefreshRate;
				CDtihCFcHyYumCfjjIRKUYzMEFBNA.fixedTimeStepFPS = platformVar_joystickRefreshRate;
			}
		}
	}

	public static void vCBFvIdHsbAnKBZkroQOsRrLIAyV()
	{
		ReInput.UpdateStartedEvent -= MjLZKAwbhFKDnQfzHDbpJVEfDZNm;
		if (CDtihCFcHyYumCfjjIRKUYzMEFBNA != null)
		{
			CDtihCFcHyYumCfjjIRKUYzMEFBNA.WaitForActionQueueToFinish();
			CDtihCFcHyYumCfjjIRKUYzMEFBNA.Dispose();
			CDtihCFcHyYumCfjjIRKUYzMEFBNA = null;
		}
		if (wnAbEbkBcDpUFXYPjgOrfortOIrcb != null)
		{
			wnAbEbkBcDpUFXYPjgOrfortOIrcb.WaitForActionQueueToFinish();
			wnAbEbkBcDpUFXYPjgOrfortOIrcb.Dispose();
			wnAbEbkBcDpUFXYPjgOrfortOIrcb = null;
		}
	}
}
