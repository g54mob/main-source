using System.Reflection;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public class OrbitPoint : IOrbitPoint
	{
		private double _eccentricAnomaly;

		private Vector3d _position;

		private double _time;

		private double _trueAnomaly;

		private Vector3d _velocity;

		public double EccentricAnomaly => _eccentricAnomaly;

		public Vector3d Position => _position;

		public double Time => _time;

		public double TrueAnomaly => _trueAnomaly;

		public Vector3d Velocity => _velocity;

		public OrbitPoint()
		{
		}

		public OrbitPoint(IOrbitPoint point)
		{
			OrbitPoint orbitPoint = point as OrbitPoint;
			Set(orbitPoint._position, orbitPoint._velocity, orbitPoint._trueAnomaly, orbitPoint._eccentricAnomaly, orbitPoint._time);
		}

		public void Set(Vector3d p, Vector3d v, double nu, double ea, double t)
		{
			_position = p;
			_velocity = v;
			_time = t;
			_trueAnomaly = nu;
			_eccentricAnomaly = ea;
		}

		public void Set(IOrbitPoint point)
		{
			OrbitPoint orbitPoint = point as OrbitPoint;
			Set(orbitPoint._position, orbitPoint._velocity, orbitPoint._trueAnomaly, orbitPoint._eccentricAnomaly, orbitPoint._time);
		}

		public bool VerifyPoint(double eccentricity)
		{
			bool suppressErrors = Orbit.SuppressErrors;
			Orbit.SuppressErrors = true;
			double eccentricAnomalyFromTrueAnomaly = OrbitMath.GetEccentricAnomalyFromTrueAnomaly(eccentricity, TrueAnomaly);
			bool flag = !double.IsNaN(eccentricAnomalyFromTrueAnomaly);
			if (flag)
			{
				flag = !double.IsNaN(OrbitMath.GetMeanAnomalyFromEccentricAnomaly(eccentricity, eccentricAnomalyFromTrueAnomaly));
			}
			Orbit.SuppressErrors = suppressErrors;
			return flag;
		}
	}
}
