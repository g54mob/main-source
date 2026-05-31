namespace PG
{
	public interface ICarControl
	{
		float Acceleration { get; }

		float BrakeReverse { get; }

		float Horizontal { get; }

		float Pitch { get; }

		bool HandBrake { get; }

		bool Boost { get; }
	}
}
