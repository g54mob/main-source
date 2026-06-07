namespace Ezereal
{
	public interface IEzerealVehicleInputSource
	{
		bool WantsEngineOn { get; }

		bool WantsReverse { get; }

		float Throttle { get; }

		float Brake { get; }

		float Handbrake { get; }

		float Steering { get; }
	}
}
