using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using UnityEngine;

namespace Assets.Scripts.Vizzy.Craft
{
	public class PositionTarget : INavSphereTarget
	{
		public bool IsDestroyed => false;

		public string Name => "Target";

		public IOrbitNode OrbitNode => null;

		public IPlanetNode Parent { get; set; }

		public Vector3d Position { get; set; }

		public Vector3d SolarPosition => (Parent?.SolarPosition ?? ((Vector3d)Vector3.zero)) + Position;

		public Vector3d Velocity => Vector3d.zero;
	}
}
