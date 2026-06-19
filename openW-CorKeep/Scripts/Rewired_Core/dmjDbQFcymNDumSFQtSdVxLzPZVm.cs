using System;
using Rewired;

internal static class dmjDbQFcymNDumSFQtSdVxLzPZVm
{
	public static hhwQItrOtauBvPHQAFLgRDRQAhcP RGmoyPWcqSjXoOejoZSFuNsUephS(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Mouse => hhwQItrOtauBvPHQAFLgRDRQAhcP.Mouse, 
			ControllerType.Keyboard => hhwQItrOtauBvPHQAFLgRDRQAhcP.Keyboard, 
			ControllerType.Joystick => hhwQItrOtauBvPHQAFLgRDRQAhcP.Joystick, 
			ControllerType.Custom => hhwQItrOtauBvPHQAFLgRDRQAhcP.CustomController, 
			_ => throw new NotImplementedException(), 
		};
	}
}
