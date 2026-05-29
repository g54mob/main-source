namespace Rewired.Interfaces
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[CustomObfuscation(rename = false)]
	public interface IControllerVibrator
	{
		int vibrationMotorCount { get; }

		void SetVibration(int motorIndex, float motorLevel);

		void SetVibration(int motorIndex, float motorLevel, float duration);

		void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors);

		void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors);

		float GetVibration(int motorIndex);

		void StopVibration();
	}
}
