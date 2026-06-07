using ModApi.Flight.Sim;
using UnityEngine;

namespace ModApi.Flight.UI
{
	public interface INavSphereTarget
	{
		bool IsDestroyed { get; }

		string Name { get; }

		IOrbitNode OrbitNode { get; }

		IPlanetNode Parent { get; }

		Vector3d Position { get; }

		Vector3d SolarPosition { get; }

		Vector3d Velocity { get; }
	}
}
