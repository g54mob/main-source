namespace Rewired.Drivers.Interfaces
{
	[CustomClassObfuscation]
	[CustomObfuscation]
	internal interface IControllerDriver
	{
		int AxisCount { get; }

		int ButtonCount { get; }

		int HatCount { get; }

		int AccelerometerCount { get; }

		int GyroscopeCount { get; }

		int TouchpadCount { get; }

		int LightCount { get; }

		int VibrationMotorCount { get; }
	}
}
