using ModApi.Flight.Sim;
using UnityEngine;

namespace ModApi.Flight.MapView
{
	public interface ICameraFocusable
	{
		IPlanetNode AssociatedPlanet { get; }

		bool FocusByClick { get; }

		ICameraFocusable ItemToFocusOnWhenDeleted { get; }

		float MinZoomDistance { get; }

		IOrbitNode OrbitNode { get; }

		Vector3 Position { get; }

		event CameraFocusableItemDestroyedHandler Destroyed;
	}
}
