using System;
using ModApi.Flight.Sim;
using ModApi.Planet.Events;

namespace ModApi.Planet
{
	public interface IPlanet
	{
		bool IsHidden { get; }

		IPlanetData PlanetData { get; }

		IPlanetNode PlanetNode { get; }

		IQuadSphere QuadSphere { get; }

		bool QuadSphereEnabled { get; }

		float QuadSphereTransitionStrength { get; }

		event EventHandler<PlanetNodeChangeEventArgs> PlanetNodeChanged;

		event EventHandler<PlanetNodeChangeEventArgs> PlanetNodeChanging;

		event EventHandler<PlanetQuadSphereEventArgs> QuadSphereEnabledStateChanged;

		event EventHandler<PlanetQuadSphereEventArgs> QuadSphereLoaded;

		event EventHandler<PlanetQuadSphereEventArgs> QuadSphereLoading;

		event EventHandler<PlanetQuadSphereEventArgs> QuadSphereUnloaded;

		event EventHandler<PlanetQuadSphereEventArgs> QuadSphereUnloading;
	}
}
