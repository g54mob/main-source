using System;
using Assets.Scripts.Flight.Sim.Orbital.Interfaces;
using Assets.Scripts.Flight.Sim.Orbital.Pooling;
using Assets.Scripts.Flight.Sim.Orbital.Pooling.Interfaces;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Flight.Sim;
using ModApi.Math;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public static class OrbitMath
	{
		[Serializable]
		public class OrbitFailedConvergence : Exception
		{
		}

		public const int DefaultPointsCount = 400;

		public const double DefaultPointsResolution = Math.PI / 200.0;

		public const double EpsilonEquality = 4E-12;

		public const double EpsilonErrorTolerance = 1E-09;

		public const double EpsilonZero = 9E-07;

		public static IOrbitIteratorPool IteratorPool = new OrbitIteratorPool();

		public static IOrbitPointPool PointsPool = new OrbitPointPool();

		public static ISoiEnterInfoPool SoiEnterInfoPool = new SoiEnterInfoPool();

		public static ISoiExitInfoPool SoiExitInfoPool = new SoiExitInfoPool();

		private const double EpsilonEaConvergence = 4E-13;

		private static Matrix4x4d _orbitMatrixTransform = Matrix4x4d.identity;

		private static Matrix4x4d _tempInverseTransformPointMatrix1 = Matrix4x4d.identity;

		private static Matrix4x4d _tempInverseTransformPointMatrix2 = Matrix4x4d.identity;

		private static Matrix4x4d _tempInverseTransformPointMatrix3 = Matrix4x4d.identity;

		private static Matrix4x4d _tempInverseTransformPointMatrix4 = Matrix4x4d.identity;

		public static double AdvanceMeanAnomaly(double eccentricity, double originalAnomaly, double meanMotion, double elapsedTime)
		{
			double num = originalAnomaly + meanMotion * elapsedTime;
			if (!(eccentricity < 1.0))
			{
				return num;
			}
			return MathUtils.LimitAngle0to2PI(num);
		}

		public static double Atanh(double x)
		{
			return (Mathd.Log(1.0 + x) - Mathd.Log(1.0 - x)) / 2.0;
		}

		public static Vector3d CalculateAngularMomentum(Vector3d p, Vector3d v)
		{
			return Vector3d.Cross(p, v);
		}

		public static Vector3d CalculateEccentricityVector(Vector3d v, Vector3d p, double positionMag, double radialVelocity, double u)
		{
			Vector3d vector3d = 1.0 / u * ((v.sqrMagnitude - u / positionMag) * p - positionMag * radialVelocity * v);
			Utilities.IsNan(vector3d);
			return vector3d;
		}

		public static double CalculateInclination(Vector3d angularMomentum, double angularMomentumMag)
		{
			double result = 0.0;
			if (angularMomentumMag > 0.0)
			{
				result = Mathd.Acos(angularMomentum.z / angularMomentumMag);
			}
			return result;
		}

		public static Vector3d CalculateNodeLine(Vector3d angularMomentum)
		{
			return Vector3d.Cross(new Vector3d(0f, 0f, 1f), angularMomentum);
		}

		public static Vector3d CalculateOrbitPlaneNormal(Vector3d periapsis, Vector3d nodeLineVector)
		{
			return Vector3d.Cross(periapsis, nodeLineVector).normalized;
		}

		public static bool CalculatePrograde(Vector3d angularMomentum, double angularMomentumMag)
		{
			if (angularMomentum.z / angularMomentumMag > 0.0)
			{
				return true;
			}
			return false;
		}

		public static double CalculateRadialVelocity(Vector3d p, Vector3d v, double pMag)
		{
			return Vector3d.Dot(p, v) / pMag;
		}

		public static double CalculateSemiMajorAxis(double u, double specificMechanicalEnergy)
		{
			return (0.0 - u) / (2.0 * specificMechanicalEnergy);
		}

		public static double CalculateSpecificMechanicalEnergy(double velocitySquared, double u, double positionMag)
		{
			return velocitySquared / 2.0 - u / positionMag;
		}

		public static double ComputeNextEA(double Ek, double e, double M)
		{
			return Ek - (M - Ek + e * Mathd.Sin(Ek)) / (e * Mathd.Cos(Ek) - 1.0);
		}

		public static double ComputeNextHA(double Hk, double e, double M)
		{
			return Hk + (M - e * Math.Sinh(Hk) + Hk) / (e * Math.Cosh(Hk) - 1.0);
		}

		public static void ConvertKeplerToLocalStateVectors(double nu, double e, double angularMomentumMag, double gravitationalParameter, out Vector3d position, out Vector3d velocity)
		{
			double num = angularMomentumMag * angularMomentumMag / gravitationalParameter;
			double num2 = gravitationalParameter / angularMomentumMag;
			double num3 = Mathd.Cos(nu);
			double num4 = Mathd.Sin(nu);
			double num5 = num * (1.0 / (1.0 + e * num3));
			double num6 = num2;
			position = new Vector3d(num5 * num3, num5 * num4, 0.0);
			velocity = new Vector3d(num6 * (0.0 - num4), num6 * (e + num3), 0.0);
		}

		public static Vector3d ConvertOrbitToFromGameCoords(Vector3d coord)
		{
			return new Vector3d(coord.x, coord.z, coord.y);
		}

		public static double GetAngleBetween(double before, double after, double eccentricity, bool treatSameAsOnePeriod)
		{
			bool flag = eccentricity < 1.0;
			if (flag)
			{
				before = before.AsZeroTo2PI();
				after = after.AsZeroTo2PI();
			}
			if (Orbit.Equality.CompareOrbitalAngles(before, after, eccentricity))
			{
				if (treatSameAsOnePeriod && flag)
				{
					return Math.PI * 2.0;
				}
				return 0.0;
			}
			if (flag && before > after)
			{
				after += Math.PI * 2.0;
			}
			return after - before;
		}

		public static IOrbitPoint GetClosestPointOnOrbit(IOrbit orbit, Vector3d position, bool useAlternateMethod = false)
		{
			if (useAlternateMethod)
			{
				if (orbit.Eccentricity < 1.0)
				{
					double closestTrueAnomalyOnEllipticalOrbit = GetClosestTrueAnomalyOnEllipticalOrbit(orbit, position);
					return GetPointAtTrueAnomaly(orbit, closestTrueAnomalyOnEllipticalOrbit);
				}
				bool ascent = IsOnRightSideOfOrbit(orbit, position);
				double magnitude = position.magnitude;
				return GetPointAtDistance(orbit, magnitude, ascent);
			}
			bool rightSide = IsOnRightSideOfOrbit(orbit, position);
			double closestTrueAnomalyOnOrbit = GetClosestTrueAnomalyOnOrbit(orbit, position, rightSide);
			if (orbit.Eccentricity < 1.0 || IsTrueAnomalyValidForHyperbolic(orbit, closestTrueAnomalyOnOrbit))
			{
				return GetPointAtTrueAnomaly(orbit, closestTrueAnomalyOnOrbit);
			}
			return null;
		}

		public static double GetClosestTrueAnomalyOnEllipticalOrbit(IOrbit orbit, Vector3d position)
		{
			if (orbit.Eccentricity >= 1.0)
			{
				return 0.0;
			}
			Vector3d normalized = orbit.EccentricityVector.normalized;
			Vector3d vector3d = orbit.Apoapsis + normalized * orbit.SemiMajorAxis;
			Vector3d rhs = position - vector3d;
			Vector2d queryPoint = new Vector2d(Vector3d.Dot(normalized, rhs), Vector3d.Dot(orbit.OrbitalPlaneRight.normalized, rhs));
			double eccentricAnomalyForClosestPointOnEllipse = MathUtils.GetEccentricAnomalyForClosestPointOnEllipse(orbit.SemiMajorAxis, orbit.SemiMinorAxis, queryPoint);
			return GetTrueAnomalyFromEccentricAnomaly(orbit.Eccentricity, eccentricAnomalyForClosestPointOnEllipse);
		}

		public static double GetClosestTrueAnomalyOnOrbit(IOrbit orbit, Vector3d position, bool rightSide)
		{
			double num = (90.0 - Vector3d.Angle(position, orbit.EccentricityVector)) * 0.01745329 + Math.PI / 2.0;
			if (rightSide)
			{
				num = 0.0 - num;
			}
			num += Math.PI;
			if (num > Math.PI * 2.0)
			{
				num -= Math.PI * 2.0;
			}
			return num;
		}

		public static double GetDistanceAtTrueAnomaly(double eccentricity, double trueAnomaly, double semiMajorAxis)
		{
			return semiMajorAxis * ((1.0 - eccentricity * eccentricity) / (1.0 + eccentricity * Math.Cos(trueAnomaly)));
		}

		public static void GetEaIterators(IOrbit orbit, double startNu, double endNu, out double startEa, out double endEa)
		{
			double eccentricity = orbit.Eccentricity;
			startNu = MathUtils.LimitAngle0to2PI(startNu);
			startEa = GetEccentricAnomalyFromTrueAnomaly(eccentricity, startNu);
			double num = MathUtils.LimitAngle0to2PI(endNu);
			if (startNu > num)
			{
				num += Math.PI * 2.0;
			}
			if (eccentricity > 1.0 && startNu == num)
			{
				endEa = orbit.EccentricAnomalyAtApoapsis;
			}
			else if (eccentricity > 1.0 && startNu > endNu && startNu < Math.PI)
			{
				endEa = GetEccentricAnomalyFromTrueAnomaly(eccentricity, num);
			}
			else
			{
				endEa = GetEccentricAnomalyFromTrueAnomaly(eccentricity, num);
				if (endEa < startEa)
				{
					endEa += Math.PI * 2.0;
				}
			}
			if (Utilities.CompareDoubles(startEa, endEa, 4E-12))
			{
				endEa = startEa + Math.PI * 2.0;
			}
		}

		public static double GetEccentricAnomalyFromMeanAnomaly(double e, double ma, double lastE)
		{
			int? nextRetryType = 1;
			double num = GetInitalEccAnomalyGuess(lastE, ma, e, ref nextRetryType);
			int num2 = 0;
			int num3 = 0;
			if (e < 1.0)
			{
				ma = MathUtils.LimitAngle0to2PI(ma);
			}
			double num4 = 4E-13;
			if (Math.Abs(ma) > 1.0)
			{
				num4 *= Math.Abs(ma);
			}
			do
			{
				double num5 = GetMeanAnomalyFromEccentricAnomaly(e, num) - ma;
				if (Mathd.Abs(num5) < num4)
				{
					break;
				}
				double num6 = num - num5 / GetMeanAnomalyDerivativeFromEa(e, num);
				if (num == num6)
				{
					num3 = 250;
					num2 = 3;
				}
				else if (Math.Abs(num6 - num) > 10.0)
				{
					num6 = num + Math.Log10(Math.Abs(num6 - num)) * (double)Math.Sign(num6);
				}
				num = num6;
				if (++num3 >= 250 && num2 < 3)
				{
					num2++;
					num = GetInitalEccAnomalyGuess(lastE, ma, e, ref nextRetryType);
					num3 = 0;
				}
			}
			while (num3 < 250);
			_ = 250;
			if (!(e < 1.0))
			{
				return num;
			}
			return MathUtils.LimitAngle0to2PI(num);
		}

		public static double GetEccentricAnomalyFromMeanAnomaly(double e, double ma)
		{
			return GetEccentricAnomalyFromMeanAnomaly(e, ma, double.NaN);
		}

		public static double GetEccentricAnomalyFromTrueAnomaly(double eccentricity, double trueAnomaly)
		{
			if (eccentricity < 1.0)
			{
				return MathUtils.LimitAngle0to2PI(Mathd.Atan2(Mathd.Sqrt(1.0 - eccentricity * eccentricity) * Mathd.Sin(trueAnomaly), eccentricity + Mathd.Cos(trueAnomaly)));
			}
			double num = 2.0 * Atanh(Mathd.Sqrt((eccentricity - 1.0) / (eccentricity + 1.0)) * Mathd.Tan(trueAnomaly / 2.0));
			if (Debug.isDebugBuild && !Orbit.SuppressErrors)
			{
				double.IsNaN(num);
			}
			return num;
		}

		public static IOrbitPoint GetEscapePoint(IOrbit orbit, double sphereOfInfluence)
		{
			return GetPointAtDistance(orbit, sphereOfInfluence, ascent: true);
		}

		public static double GetHyperbolicExcessVelocity(Orbit orbit)
		{
			return Math.Sqrt((0.0 - orbit.U) / orbit.SemiMajorAxis);
		}

		public static double GetHyperbolicImpactParameter(Orbit orbit)
		{
			return (0.0 - orbit.SemiMajorAxis) * Math.Sqrt(orbit.Eccentricity * orbit.Eccentricity - 1.0);
		}

		public static double GetHyperbolicTrueAnomalyLimit(double eccentricity)
		{
			return Mathd.Acos(-1.0 / eccentricity);
		}

		public static double GetInitalEccAnomalyGuess(double lastE, double M, double e, ref int? nextRetryType)
		{
			if (!nextRetryType.HasValue)
			{
				if (!double.IsNaN(lastE))
				{
					nextRetryType = 0;
				}
				else if (e > 0.8)
				{
					nextRetryType = 1;
				}
				else
				{
					nextRetryType = 2;
				}
			}
			double num;
			switch (nextRetryType)
			{
			case 0:
				num = lastE * Mathd.Sign(M);
				nextRetryType = 1;
				break;
			case 1:
				num = Math.PI;
				nextRetryType = 2;
				break;
			case 2:
				num = -Math.PI;
				nextRetryType = 0;
				break;
			default:
				throw new ArgumentException($"NextRetry({nextRetryType}) not supported");
			}
			double.IsNaN(num);
			return num;
		}

		public static double GetMeanAnomalyDerivativeFromEa(double e, double ea)
		{
			if (e < 1.0)
			{
				return 1.0 - e * Mathd.Cos(ea);
			}
			return e * Math.Cosh(ea) - 1.0;
		}

		public static double GetMeanAnomalyFromEccentricAnomaly(double eccentricity, double eccentricAnomaly)
		{
			if (eccentricity < 1.0)
			{
				return MathUtils.LimitAngle0to2PI(eccentricAnomaly - eccentricity * Mathd.Sin(eccentricAnomaly));
			}
			double num = eccentricity * Math.Sinh(eccentricAnomaly) - eccentricAnomaly;
			if (Debug.isDebugBuild && !Orbit.SuppressErrors)
			{
				double.IsNaN(num);
			}
			return num;
		}

		public static double GetMeanAnomalyFromTrueAnomaly(double eccentricity, double nu)
		{
			double eccentricAnomalyFromTrueAnomaly = GetEccentricAnomalyFromTrueAnomaly(eccentricity, nu);
			return GetMeanAnomalyFromEccentricAnomaly(eccentricity, eccentricAnomalyFromTrueAnomaly);
		}

		public static bool GetPeriapsisCrossing(double lastNu, double currentNu, double deltaTime, double period)
		{
			if (!(lastNu.AsZeroTo2PI() > currentNu.AsZeroTo2PI()))
			{
				return deltaTime > period;
			}
			return true;
		}

		public static IOrbitPoint GetPointAtDistance(IOrbit orbit, double distance, bool ascent)
		{
			double? trueAnomalyAtDistance = GetTrueAnomalyAtDistance(orbit.Eccentricity, distance, orbit.SemiMajorAxis, orbit.TrueAnomalyAtApoapsis, orbit.ApoapsisDistance, orbit.PeriapsisDistance, ascent);
			if (trueAnomalyAtDistance.HasValue)
			{
				return GetPointAtTrueAnomaly(orbit, trueAnomalyAtDistance.Value);
			}
			return null;
		}

		public static IOrbitPoint GetPointAtEccentricAnomaly(IOrbit orbit, double eccentricAnomaly)
		{
			double num = 0.0;
			double eccentricity = orbit.Eccentricity;
			double meanAnomalyFromEccentricAnomaly = GetMeanAnomalyFromEccentricAnomaly(eccentricity, eccentricAnomaly);
			double num2 = GetAngleBetween(orbit.MeanAnomaly, meanAnomalyFromEccentricAnomaly, eccentricity, treatSameAsOnePeriod: false) / orbit.MeanMotion;
			num = orbit.Time + num2;
			if (Debug.isDebugBuild && !Orbit.SuppressErrors)
			{
				double.IsNaN(num);
			}
			double trueAnomalyFromEccentricAnomaly = GetTrueAnomalyFromEccentricAnomaly(eccentricity, eccentricAnomaly);
			GetStateVectorsFromTrueAnomaly(orbit, trueAnomalyFromEccentricAnomaly, out var position, out var velocity);
			position = ConvertOrbitToFromGameCoords(position);
			velocity = ConvertOrbitToFromGameCoords(velocity);
			IOrbitPoint orbitPoint = PointsPool.Get();
			orbitPoint.Set(position, velocity, trueAnomalyFromEccentricAnomaly, eccentricAnomaly, num);
			return orbitPoint;
		}

		public static IOrbitPoint GetPointAtTime(IOrbit orbit, double timeOfPoint)
		{
			IOrbitPoint orbitPoint = PointsPool.Get();
			double num = timeOfPoint - orbit.Time;
			if (num == 0.0)
			{
				orbitPoint.Set(orbit.Position, orbit.Velocity, orbit.TrueAnomaly, orbit.EccentricAnomaly, orbit.Time);
			}
			else
			{
				double eccentricity = orbit.Eccentricity;
				double num2 = orbit.MeanMotion * num;
				double meanAnomaly = orbit.MeanAnomaly + num2;
				double trueAnomalyFromMeanAnomaly = GetTrueAnomalyFromMeanAnomaly(eccentricity, meanAnomaly);
				GetStateVectorsFromTrueAnomaly(orbit, trueAnomalyFromMeanAnomaly, out var position, out var velocity);
				orbitPoint.Set(ConvertOrbitToFromGameCoords(position), ConvertOrbitToFromGameCoords(velocity), trueAnomalyFromMeanAnomaly, GetEccentricAnomalyFromTrueAnomaly(eccentricity, trueAnomalyFromMeanAnomaly), timeOfPoint);
			}
			return orbitPoint;
		}

		public static IOrbitPoint GetPointAtTrueAnomaly(IOrbit orbit, double trueAnomaly)
		{
			IOrbitPoint orbitPoint = PointsPool.Get();
			if (orbit.TrueAnomaly == trueAnomaly)
			{
				orbitPoint.Set(orbit.Position, orbit.Velocity, orbit.TrueAnomaly, orbit.EccentricAnomaly, orbit.Time);
			}
			else
			{
				double meanAnomalyFromTrueAnomaly = GetMeanAnomalyFromTrueAnomaly(orbit.Eccentricity, trueAnomaly);
				double t = GetTransitTime(GetAngleBetween(orbit.MeanAnomaly, meanAnomalyFromTrueAnomaly, orbit.Eccentricity, treatSameAsOnePeriod: false), orbit.MeanMotion) + orbit.Time;
				GetStateVectorsFromTrueAnomaly(orbit, trueAnomaly, out var position, out var velocity);
				orbitPoint.Set(ConvertOrbitToFromGameCoords(position), ConvertOrbitToFromGameCoords(velocity), trueAnomaly, GetEccentricAnomalyFromTrueAnomaly(orbit.Eccentricity, trueAnomaly), t);
			}
			return orbitPoint;
		}

		public static IOrbitPointSet GetPoints(IOrbit orbit, double startNu, double endNu, double minDistance, int pointCount, IOrbitPointSet orbitPointSet)
		{
			int num = pointCount + 3;
			int num2 = 0;
			double num3 = minDistance * minDistance;
			IOrbitPointSet orbitPointSet2 = orbitPointSet ?? new OrbitPointSet();
			orbitPointSet2.Initialize(orbit.Period);
			bool flag = startNu != endNu;
			GetEaIterators(orbit, startNu, endNu, out var startEa, out var endEa);
			double eaStep = GetAngleBetween(startEa, endEa, orbit.Eccentricity, treatSameAsOnePeriod: true) / (double)pointCount;
			IOrbitIterator iterator = IteratorPool.GetIterator(orbit, startEa, endEa, eaStep);
			IOrbitPoint point;
			while (iterator.TryGetNext(out point) && num2++ < num)
			{
				if (point.Position.sqrMagnitude >= 1.0000000000000003E+50)
				{
					IOrbitPoint pointAtDistance = GetPointAtDistance(orbit, 1E+25, ascent: true);
					if (pointAtDistance != null)
					{
						orbitPointSet2.AddPoint(pointAtDistance);
					}
					flag = true;
					break;
				}
				if (point.Position.sqrMagnitude <= num3)
				{
					IOrbitPoint pointAtDistance2 = GetPointAtDistance(orbit, minDistance, ascent: false);
					if (pointAtDistance2 != null)
					{
						orbitPointSet2.AddPoint(pointAtDistance2);
						orbitPointSet2.IntersectsPlanet = true;
					}
					flag = true;
					break;
				}
				orbitPointSet2.AddPoint(point);
			}
			orbitPointSet2.Closed = !flag;
			return orbitPointSet2;
		}

		public static void GetStateVectorsFromTrueAnomaly(IOrbit orbit, double nu, out Vector3d position, out Vector3d velocity)
		{
			ConvertKeplerToLocalStateVectors(nu, orbit.Eccentricity, orbit.AngularMomentumMag, orbit.U, out position, out velocity);
			position = InverseTransformPoint(position, orbit.RightAscensionOfAscendingNode, orbit.Inclination, orbit.PeriapsisAngle, rebuildMatrix: true);
			velocity = InverseTransformPoint(velocity, orbit.RightAscensionOfAscendingNode, orbit.Inclination, orbit.PeriapsisAngle, rebuildMatrix: false);
		}

		public static double GetTimeAtTrueAnomaly(IOrbit orbit, double trueAnomaly)
		{
			double meanAnomalyFromTrueAnomaly = GetMeanAnomalyFromTrueAnomaly(orbit.Eccentricity, trueAnomaly);
			double transitTime = GetTransitTime(GetAngleBetween(orbit.MeanAnomaly, meanAnomalyFromTrueAnomaly, orbit.Eccentricity, treatSameAsOnePeriod: false), orbit.MeanMotion);
			return orbit.Time + transitTime;
		}

		public static double GetTimeSinceEpoch(IOrbit orbit)
		{
			return orbit.MeanAnomaly / orbit.MeanMotion;
		}

		public static double GetTimeToPoint(double startM, double endM, double meanMotion)
		{
			if (startM > endM)
			{
				endM += Math.PI * 2.0;
			}
			double num = startM / meanMotion;
			return endM / meanMotion - num;
		}

		public static double GetTransitTime(double deltaMeanAnomaly, double meanMotion)
		{
			return deltaMeanAnomaly / meanMotion;
		}

		public static double? GetTrueAnomalyAtDistance(double eccentricity, double distance, double semiMajorAxis, double nuAtApoapsis, double apoapsisDistance, double periapsisDistance, bool ascent)
		{
			double? result;
			if ((periapsisDistance > distance && !Utilities.CompareDoubles(periapsisDistance, distance, 1E-07)) || (eccentricity < 1.0 && apoapsisDistance < distance))
			{
				result = null;
			}
			else
			{
				double num = distance * eccentricity;
				double num2;
				if (double.IsInfinity(num))
				{
					num2 = ((!(eccentricity > 1.0)) ? double.NaN : nuAtApoapsis);
				}
				else
				{
					double num3 = ((0.0 - eccentricity * eccentricity) * semiMajorAxis + semiMajorAxis - distance) / num;
					if (num3 > 1.0 && Utilities.CompareDoubles(num3, 1.0))
					{
						num3 = 1.0;
					}
					else if (num3 < -1.0 && Utilities.CompareDoubles(num3, -1.0))
					{
						num3 = -1.0;
					}
					num2 = Mathd.Acos(num3);
					double.IsNaN(num2);
					if (eccentricity > 1.0 && num2 > nuAtApoapsis)
					{
						num2 = nuAtApoapsis;
					}
				}
				result = ((!ascent) ? new double?(Math.PI * 2.0 - num2) : new double?(num2));
			}
			return result;
		}

		public static double GetTrueAnomalyFromEccentricAnomaly(double eccentricity, double eccentricAnomaly)
		{
			if (eccentricity < 1.0)
			{
				return MathUtils.LimitAngle0to2PI(2.0 * Mathd.Atan(Mathd.Sqrt((1.0 + eccentricity) / (1.0 - eccentricity)) * Mathd.Tan(eccentricAnomaly / 2.0)));
			}
			return MathUtils.LimitAngle0to2PI(2.0 * Mathd.Atan(Mathd.Sqrt((eccentricity + 1.0) / (eccentricity - 1.0)) * Math.Tanh(eccentricAnomaly / 2.0)));
		}

		public static double GetTrueAnomalyFromMeanAnomaly(double eccentricity, double meanAnomaly)
		{
			return GetTrueAnomalyFromEccentricAnomaly(eccentricity, GetEccentricAnomalyFromMeanAnomaly(eccentricity, meanAnomaly, 1E-09));
		}

		public static double HyperbolicAnomalyFromMeanAnomaly(double M, double e, double tol)
		{
			double num = ComputeNextHA(M, e, M);
			double num2 = M;
			int num3 = 0;
			while (Mathd.Abs(num - num2) > tol)
			{
				num = num2;
				num2 = ComputeNextHA(num, e, M);
				num3++;
				if (num3 > 250)
				{
					throw new OrbitFailedConvergence();
				}
			}
			return num2;
		}

		public static Vector3d InverseTransformPoint(Vector3d point, double rightAscension, double inclination, double periapsisAngle, bool rebuildMatrix)
		{
			if (rebuildMatrix)
			{
				double num = Mathd.Cos(rightAscension);
				double num2 = Mathd.Sin(rightAscension);
				Matrix4x4d tempInverseTransformPointMatrix = _tempInverseTransformPointMatrix1;
				tempInverseTransformPointMatrix.m00 = num;
				tempInverseTransformPointMatrix.m10 = num2;
				tempInverseTransformPointMatrix.m01 = 0.0 - num2;
				tempInverseTransformPointMatrix.m11 = num;
				double num3 = Mathd.Cos(inclination);
				double num4 = Mathd.Sin(inclination);
				Matrix4x4d tempInverseTransformPointMatrix2 = _tempInverseTransformPointMatrix2;
				tempInverseTransformPointMatrix2.m11 = num3;
				tempInverseTransformPointMatrix2.m21 = num4;
				tempInverseTransformPointMatrix2.m12 = 0.0 - num4;
				tempInverseTransformPointMatrix2.m22 = num3;
				double num5 = Mathd.Cos(periapsisAngle);
				double num6 = Mathd.Sin(periapsisAngle);
				Matrix4x4d tempInverseTransformPointMatrix3 = _tempInverseTransformPointMatrix3;
				tempInverseTransformPointMatrix3.m00 = num5;
				tempInverseTransformPointMatrix3.m10 = num6;
				tempInverseTransformPointMatrix3.m01 = 0.0 - num6;
				tempInverseTransformPointMatrix3.m11 = num5;
				Matrix4x4d tempInverseTransformPointMatrix4 = _tempInverseTransformPointMatrix4;
				tempInverseTransformPointMatrix.MultiplyMatrix(tempInverseTransformPointMatrix2, tempInverseTransformPointMatrix4);
				tempInverseTransformPointMatrix4.MultiplyMatrix(tempInverseTransformPointMatrix3, _orbitMatrixTransform);
			}
			return _orbitMatrixTransform.MultiplyVector(point);
		}

		public static bool IsOnRightSideOfOrbit(IOrbit orbit, Vector3d position)
		{
			Vector3d normalized = (position - orbit.EccentricityVector).normalized;
			return Vector3d.Dot(orbit.OrbitalPlaneRight, normalized) > 0.0;
		}

		public static bool IsTrueAnomalyValidForHyperbolic(IOrbit orbit, double trueAnomaly)
		{
			if (orbit.Eccentricity > 1.0)
			{
				return TrueAnomalyBetween(trueAnomaly.AsZeroTo2PI(), Math.PI * 2.0 - orbit.TrueAnomalyAtApoapsis, orbit.TrueAnomalyAtApoapsis, inclusive: false);
			}
			return false;
		}

		public static bool IsTrueAnomalyValidForOrbit(double trueAnomaly, double eccentricity)
		{
			return !double.IsNaN(GetEccentricAnomalyFromTrueAnomaly(eccentricity, trueAnomaly));
		}

		public static double MeanAnomaly(double E, double e)
		{
			return E - e * Mathd.Sin(E);
		}

		public static double OrbitAcosh(double x)
		{
			return Mathd.Log(x + Mathd.Sqrt(x * x - 1.0));
		}

		public static double OrbitAsinh(double z)
		{
			return Mathd.Log(z + Mathd.Sqrt(z * z + 1.0));
		}

		public static void ReturnAllPoolItems()
		{
			PointsPool.ReturnAll();
			SoiEnterInfoPool.ReturnAll();
			SoiExitInfoPool.ReturnAll();
			IteratorPool.ReturnAll();
		}

		public static double TimeToPoint(IOrbit orbit, double trueAnomaly)
		{
			return (GetMeanAnomalyFromTrueAnomaly(orbit.Eccentricity, trueAnomaly) - orbit.MeanAnomaly) / orbit.MeanMotion;
		}

		public static bool TrueAnomalyBetween(double trueAnomaly, double nuStart, double nuEnd, bool inclusive)
		{
			if (nuStart == nuEnd)
			{
				return true;
			}
			if (inclusive && (Utilities.CompareDoubles(trueAnomaly, nuStart, 4E-12) || Utilities.CompareDoubles(trueAnomaly, nuEnd, 4E-12)))
			{
				return true;
			}
			if (nuStart > nuEnd)
			{
				if (nuStart > trueAnomaly)
				{
					return Utilities.Between(trueAnomaly, nuStart - Math.PI * 2.0, nuEnd);
				}
				return Utilities.Between(trueAnomaly, nuStart, nuEnd + Math.PI * 2.0);
			}
			return Utilities.Between(trueAnomaly, nuStart, nuEnd);
		}

		public static void UpdateDependantOrbitalElements(Orbit orbit, out double periapsisDistance, out double apoapsisDistanceFriendly, out double period, out double semiMinorAxis, out double meanMotion, out double angularMomentumMag, out double trueAnomalyOfAscendingNode, out double trueAnomalyOfDescendingNode, out Vector3d periapsis, out Vector3d apoapsis, out double trueAnomalyAtApoapsis, out double hyperbolicTrueAnomalyLimit, out double eccentricAnomalyAtApoapsis, out double apoapsisDistanceEffective)
		{
			double eccentricity = orbit.Eccentricity;
			double semiMajorAxis = orbit.SemiMajorAxis;
			double u = orbit.U;
			double num = Mathd.Pow(semiMajorAxis, 3.0);
			period = Math.PI * 2.0 * Mathd.Sqrt(num / u);
			semiMinorAxis = semiMajorAxis * Mathd.Sqrt(1.0 - eccentricity * eccentricity);
			meanMotion = Mathd.Sqrt(u / Mathd.Abs(num));
			double num2 = semiMajorAxis * (1.0 - Mathd.Pow(eccentricity, 2.0));
			angularMomentumMag = Mathd.Sqrt(num2 * u);
			periapsisDistance = semiMajorAxis * (1.0 - eccentricity);
			double num3 = 2.0 * semiMajorAxis - periapsisDistance;
			apoapsisDistanceFriendly = ((eccentricity < 1.0) ? num3 : double.PositiveInfinity);
			trueAnomalyOfAscendingNode = Math.PI * 2.0 - orbit.PeriapsisAngle;
			trueAnomalyOfDescendingNode = trueAnomalyOfAscendingNode + Math.PI;
			Vector3d point = new Vector3d(Mathd.Cos(0.0) * periapsisDistance, Mathd.Sin(0.0) * periapsisDistance, 0.0);
			Vector3d point2 = new Vector3d(Mathd.Cos(Math.PI) * num3, Mathd.Sin(Math.PI) * num3, 0.0);
			periapsis = InverseTransformPoint(point, orbit.RightAscensionOfAscendingNode, orbit.Inclination, orbit.PeriapsisAngle, rebuildMatrix: true);
			apoapsis = InverseTransformPoint(point2, orbit.RightAscensionOfAscendingNode, orbit.Inclination, orbit.PeriapsisAngle, rebuildMatrix: false);
			if (eccentricity > 1.0)
			{
				hyperbolicTrueAnomalyLimit = GetHyperbolicTrueAnomalyLimit(eccentricity);
				trueAnomalyAtApoapsis = hyperbolicTrueAnomalyLimit * 0.9999999;
				eccentricAnomalyAtApoapsis = GetEccentricAnomalyFromTrueAnomaly(eccentricity, trueAnomalyAtApoapsis);
				apoapsisDistanceEffective = GetDistanceAtTrueAnomaly(eccentricity, trueAnomalyAtApoapsis, semiMajorAxis);
			}
			else
			{
				trueAnomalyAtApoapsis = (eccentricAnomalyAtApoapsis = Math.PI);
				apoapsisDistanceEffective = num3;
				hyperbolicTrueAnomalyLimit = double.NaN;
			}
		}

		public static void UpdateStateVectorDependentOribitalElements(Vector3d position, Vector3d velocity, double u, out Vector3d angularMomentum, out double radialVelocity, out Vector3d nodeLineVector, out double nodeLineVectorMag, out Vector3d orbitalPlaneNormal, out Vector3d eccentricityVector, out Vector3d orbitalPlaneRight)
		{
			if (Debug.isDebugBuild && Utilities.CompareVector3ds(position, Vector3d.zero))
			{
				Utilities.CompareVector3ds(velocity, Vector3d.zero);
			}
			double magnitude = position.magnitude;
			angularMomentum = CalculateAngularMomentum(position, velocity);
			radialVelocity = CalculateRadialVelocity(position, velocity, magnitude);
			nodeLineVector = CalculateNodeLine(angularMomentum);
			nodeLineVectorMag = nodeLineVector.magnitude;
			orbitalPlaneNormal = CalculateOrbitPlaneNormal(position, position + velocity);
			eccentricityVector = CalculateEccentricityVector(velocity, position, magnitude, radialVelocity, u);
			orbitalPlaneRight = Vector3d.Cross(orbitalPlaneNormal, eccentricityVector);
		}

		internal static void ResetPools()
		{
			SoiEnterInfoPool = new SoiEnterInfoPool();
			SoiExitInfoPool = new SoiExitInfoPool();
		}
	}
}
