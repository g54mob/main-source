using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Flight.Sim;
using ModApi.Planet;

namespace ModApi.Flight
{
	public interface IFlightState
	{
		IReadOnlyList<ICraftNode> CraftNodes { get; }

		FlightStateLoadContext LoadContext { get; }

		IPlanetNode RootNode { get; }

		ISolarSystemData SolarSystemData { get; }

		double Time { get; }
	}
}
