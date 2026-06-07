namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IXboxOneInputSource
	{
		int GetXboxOneUserIdFromUnityJoystick(int unityJoystickId);

		bool SetXboxOneVibration(ulong xboxOneJoystickId, UaxwQGXMeryxvUqRPjBsAQxhpCj vibration);

		void PulseVibrateMotor(ulong xboxOneJoystickId, XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration);
	}
}
