using System;

namespace ModApi.Planet.Events
{
	public class PlanetQuadSphereEventArgs : EventArgs
	{
		public IPlanet Planet { get; private set; }

		public IQuadSphere QuadSphere { get; private set; }

		public PlanetQuadSphereEventArgs(IPlanet planet, IQuadSphere quadSphere)
		{
			Planet = planet;
			QuadSphere = quadSphere;
		}
	}
}
