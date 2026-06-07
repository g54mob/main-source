namespace Rewired.Interfaces
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal interface IInputManagerJoystick : IInputManagerJoystickPublic
	{
		void Update();

		void FillData(ControllerDataUpdater dataUpdater);

		BridgedController ToBridgedController();

		ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs();
	}
}
