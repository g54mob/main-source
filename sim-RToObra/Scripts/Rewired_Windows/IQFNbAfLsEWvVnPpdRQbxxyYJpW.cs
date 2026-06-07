using System;
using Rewired;

internal interface IQFNbAfLsEWvVnPpdRQbxxyYJpW : IDisposable, CRXrBgggAdrpYwIPGGrSdEyGnoQt
{
	int JoystickId { get; }

	iGRvmBZykBTTuGmotZKeBVybDl JoystickSourceType { get; }

	IntPtr JoystickSourceHandle { get; }

	bool[] Buttons { get; }

	int[] HatValues { get; }

	int ButtonCount { get; }

	int AxisCount { get; }

	int HatCount { get; }

	bool HasElements { get; }

	bool SupportsVibration { get; }

	int VibrationMotorCount { get; }

	tDbEfRBvKQKUUajRFFcUkaQZPWTt AxesState { get; }

	InputSource InputSource { get; }

	void UpdateValue(IntPtr P_0, int P_1, int P_2, int P_3, float P_4);

	void SetJoystickId(int P_0);

	void SetJoystickSourceHandle(IntPtr P_0);
}
