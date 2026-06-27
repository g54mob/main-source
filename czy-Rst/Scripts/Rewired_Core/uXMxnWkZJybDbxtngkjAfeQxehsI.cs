using System;
using Rewired;

internal static class uXMxnWkZJybDbxtngkjAfeQxehsI
{
	public static eXRjOdORfaNOqMSguWnRpnOIZGBy AXiHZzPnCjYlVPHOaegKxQAQNYc(ControllerType P_0)
	{
		return P_0 switch
		{
			ControllerType.Mouse => eXRjOdORfaNOqMSguWnRpnOIZGBy.Mouse, 
			ControllerType.Keyboard => eXRjOdORfaNOqMSguWnRpnOIZGBy.Keyboard, 
			ControllerType.Joystick => eXRjOdORfaNOqMSguWnRpnOIZGBy.Joystick, 
			ControllerType.Custom => eXRjOdORfaNOqMSguWnRpnOIZGBy.CustomController, 
			_ => throw new NotImplementedException(), 
		};
	}
}
