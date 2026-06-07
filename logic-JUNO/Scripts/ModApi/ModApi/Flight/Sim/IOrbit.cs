using UnityEngine;

namespace ModApi.Flight.Sim
{
	public interface IOrbit
	{
		Vector3d AngularMomentum { get; }

		double AngularMomentumMag { get; }

		Vector3d Apoapsis { get; }

		double ApoapsisDistance { get; }

		double ApoapsisDistanceEffective { get; }

		bool DebugEnabled { get; set; }

		double EccentricAnomaly { get; }

		double EccentricAnomalyAtApoapsis { get; }

		double Eccentricity { get; }

		Vector3d EccentricityVector { get; }

		double HyperbolicTrueAnomalyLimit { get; }

		double Inclination { get; }

		bool IsPrograde { get; }

		bool IsValid { get; }

		double MeanAnomaly { get; }

		double MeanMotion { get; }

		Vector3d NodeLineVector { get; }

		Vector3d OrbitalPlaneNormal { get; }

		Vector3d OrbitalPlaneRight { get; }

		OrbitType OrbitType { get; }

		Vector3d Periapsis { get; }

		double PeriapsisAngle { get; }

		double PeriapsisDistance { get; }

		double Period { get; }

		Vector3d Position { get; }

		double PrimaryMass { get; }

		double RightAscensionOfAscendingNode { get; }

		double SemiMajorAxis { get; }

		double SemiMinorAxis { get; }

		double Time { get; }

		double TrueAnomaly { get; }

		double TrueAnomalyAtApoapsis { get; }

		double TrueAnomalyOfAscendingNode { get; }

		double TrueAnomalyOfDescendingNode { get; }

		double U { get; }

		Vector3d Velocity { get; }

		event OrbitHandler UpdatedFromOrbitalElements;

		bool AdvanceTime(double elapsedTime, double newTime);

		OrbitData GenerateOrbitData();

		double GetElementsMagnitude();

		string GetOrbitInfo();

		double GetPeriodStartTime();

		double GetTimePastPeriapsis();

		double GetTimeToApoapsis();

		double GetTimeToPeriapsis();

		void SetTrueAnomaly(double trueAnomaly, double? time);

		void UpdateFromOrbitalElements(double time, double e, double a, double w, double nu, double inclination, double ra, double primaryMass, bool prograde);

		void UpdateFromStateVectors(Vector3d p, Vector3d v, double time, double primaryMass);
	}
}
