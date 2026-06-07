using ModApi.Flight.Sim;

namespace ModApi.Craft
{
	public interface ICraftOrbitData
	{
		double ApoapsisAltitude { get; }

		double ApoapsisTime { get; }

		double Eccentricity { get; }

		double Inclination { get; }

		IPlanetNode Parent { get; }

		double PeriapsisAltitude { get; }

		double PeriapsisTime { get; }

		double Period { get; }
	}
}
