using UnityEngine;

namespace ModApi.Flight.Sim
{
	public interface IOrbitPoint
	{
		double EccentricAnomaly { get; }

		Vector3d Position { get; }

		double Time { get; }

		double TrueAnomaly { get; }

		Vector3d Velocity { get; }

		void Set(Vector3d p, Vector3d v, double nu, double ea, double t);

		void Set(IOrbitPoint point);

		bool VerifyPoint(double orbitalEccentricity);
	}
}
