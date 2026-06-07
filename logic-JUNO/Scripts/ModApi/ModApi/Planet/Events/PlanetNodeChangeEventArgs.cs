using System;
using ModApi.Flight.Sim;

namespace ModApi.Planet.Events
{
	public class PlanetNodeChangeEventArgs : EventArgs
	{
		public IPlanetNode NewPlanetNode { get; private set; }

		public IPlanet Planet { get; private set; }

		public IPlanetNode PreviousPlanetNode { get; private set; }

		public PlanetNodeChangeEventArgs(IPlanet planet, IPlanetNode previousPlanetNode, IPlanetNode newPlanetNode)
		{
			Planet = planet;
			PreviousPlanetNode = previousPlanetNode;
			NewPlanetNode = newPlanetNode;
		}
	}
}
