using ModApi.Flight.Sim;
using UnityEngine;

namespace ModApi.Flight.GameView
{
	public interface ICameraTarget
	{
		Transform CameraTarget { get; }

		Vector3 CameraTargetPlanetPosition { get; }

		IOrbitNode OrbitNode { get; }
	}
}
