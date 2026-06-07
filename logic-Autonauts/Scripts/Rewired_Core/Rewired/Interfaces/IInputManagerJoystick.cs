namespace Rewired.Interfaces
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IInputManagerJoystick : IInputManagerJoystickPublic
	{
		void Update();

		void FillData(ControllerDataUpdater dataUpdater);

		BridgedController ToBridgedController();

		ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs();
	}
}
