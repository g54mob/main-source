using UnityEngine;

namespace ModApi.Flight.Sim
{
	public interface IOrbitNode : INode
	{
		IOrbitPoint Apoapsis { get; }

		double MaxChildDistance { get; }

		string Name { get; }

		int NestedDepth { get; }

		bool NodeExitsSoi { get; }

		IOrbit Orbit { get; }

		bool OrbitUpdated { get; set; }

		IOrbitPoint Periapsis { get; }

		Vector3d SolarVelocity { get; }

		double SphereOfInfluence { get; }

		Vector3d Velocity { get; }

		event OrbitNodeHandler ChangedSoI;

		event NodeNameChangedHandler NameChanged;

		IOrbitPoint GetCurrentPoint();

		IOrbitNode GetNodeAtDepth(int depth);

		IOrbitPoint GetPointAbovePlanetCenter(double height);

		IOrbitPoint GetPointAgl(double agl);

		IOrbitPoint GetPointAtmosphereEntry();

		IOrbitPoint GetPointAtTime(double time);

		Vector3d GetSolarPositionAtTime(double time);

		Vector3d GetSolarVelocityAtTime(double time);

		bool IsDescendantOf(IOrbitNode node, bool includeSelf);

		void SetStateVectors(Vector3d position, Vector3d velocity, double time);

		void SetStateVectorsAtDefaultTime(Vector3d position, Vector3d velocity);
	}
}
