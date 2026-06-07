namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal interface IXboxOneInputSource
	{
		int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId);

		bool SetXboxOneVibration(ulong xboxOneJoystickId, oZISafBoibILjjNTfBebbZKKoxsR vibration);

		void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration);
	}
}
