using System;
using Rewired;

internal static class rmdgdLCvSmiZKUTxFZTIrYFIDSFMA
{
	public static flkMCmNLqqynNeuvLSYPGZFpwSqE RecBeCfyOKFHAGfBnLBerzonomtqA(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Mouse => flkMCmNLqqynNeuvLSYPGZFpwSqE.Mouse, 
			ControllerType.Keyboard => flkMCmNLqqynNeuvLSYPGZFpwSqE.Keyboard, 
			ControllerType.Joystick => flkMCmNLqqynNeuvLSYPGZFpwSqE.Joystick, 
			ControllerType.Custom => flkMCmNLqqynNeuvLSYPGZFpwSqE.CustomController, 
			_ => throw new NotImplementedException(), 
		};
	}
}
