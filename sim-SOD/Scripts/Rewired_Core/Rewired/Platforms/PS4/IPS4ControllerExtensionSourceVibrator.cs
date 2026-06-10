namespace Rewired.Platforms.PS4
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	internal interface IPS4ControllerExtensionSourceVibrator
	{
		bool supportsVibration { get; }

		int vibrationMotorCount { get; }

		void SetVibration(int motorIndex, float value);

		float GetVibration(int motorIndex);

		void StopVibration();
	}
}
