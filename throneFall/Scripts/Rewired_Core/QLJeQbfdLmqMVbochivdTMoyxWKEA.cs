using System;
using Rewired;

internal static class QLJeQbfdLmqMVbochivdTMoyxWKEA
{
	public static ILKhcCJzrmtoMHIdzHgcKloPCkpIA iRETFsuAFEzCDUHYZJdFtcPTnoyo(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Mouse => ILKhcCJzrmtoMHIdzHgcKloPCkpIA.Mouse, 
			ControllerType.Keyboard => ILKhcCJzrmtoMHIdzHgcKloPCkpIA.Keyboard, 
			ControllerType.Joystick => ILKhcCJzrmtoMHIdzHgcKloPCkpIA.Joystick, 
			ControllerType.Custom => ILKhcCJzrmtoMHIdzHgcKloPCkpIA.CustomController, 
			_ => throw new NotImplementedException(), 
		};
	}
}
