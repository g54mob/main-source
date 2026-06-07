using System;
using System.Text;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Flight.Sim;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	public class Orbit : IOrbit
	{
		public static class Equality
		{
			public static bool Compare(Orbit orbit1, Orbit orbit2, StringBuilder conditionErrors, double epsilon = 1E-09)
			{
				bool flag = true;
				flag = CompareStateElements(orbit1, orbit2, conditionErrors, epsilon);
				flag = ComparePrimaryOrbitalElements(orbit1, orbit2, conditionErrors, epsilon) && flag;
				return CaptureCompareError(() => CompareOrbitalAngles(orbit1.TrueAnomaly, orbit2.TrueAnomaly, orbit1.Eccentricity, epsilon), "TrueAnomaly", conditionErrors) && flag;
			}

			public static bool Compare(Orbit orbit1, Orbit orbit2, double epsilon = 1E-09)
			{
				return Compare(orbit1, orbit2, null, epsilon);
			}

			public static bool CompareAll(Orbit orbit1, Orbit orbit2, double epsilon = 1E-09)
			{
				return CompareAll(orbit1, orbit2, null, epsilon);
			}

			public static bool CompareAll(Orbit orbit1, Orbit source2, StringBuilder conditionErrors, double epsilon = 1E-09)
			{
				bool flag = true;
				flag = CompareStateElements(orbit1, source2, conditionErrors, epsilon) && flag;
				flag = ComparePrimaryOrbitalElements(orbit1, source2, conditionErrors, epsilon) && flag;
				flag = CompareDerivedElements(orbit1, source2, conditionErrors, epsilon) && flag;
				return CaptureCompareError(() => CompareOrbitalAngles(orbit1.TrueAnomaly, source2.TrueAnomaly, orbit1.Eccentricity, epsilon), "TrueAnomaly", conditionErrors) && flag;
			}

			public static bool CompareDerivedElements(Orbit orbit1, Orbit orbit2, double epsilon = 1E-09)
			{
				return CompareDerivedElements(orbit1, orbit2, null, epsilon);
			}

			public static bool CompareDerivedElements(Orbit orbit1, Orbit orbit2, StringBuilder conditionErrors, double epsilon = 1E-09)
			{
				bool flag = true;
				flag = CaptureCompareError(() => Utilities.CompareVector3ds(orbit1.AngularMomentum, orbit2.AngularMomentum, epsilon), "AngularMomentum", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareVector3dsNanEquiv(orbit1.Apoapsis, orbit2.Apoapsis, epsilon), "Apoapsis", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.ApoapsisDistance, orbit2.ApoapsisDistance, epsilon), "ApoapsisDistance", conditionErrors) && flag;
				flag = CaptureCompareError(() => CompareOrbitalAngles(orbit1._eccentricAnomaly, orbit2._eccentricAnomaly, orbit1.Eccentricity, epsilon), "_eccentricAnomaly", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareVector3ds(orbit1.EccentricityVector, orbit2.EccentricityVector, epsilon), "EccentricityVector", conditionErrors) && flag;
				flag = CaptureCompareError(() => orbit1.IsPrograde == orbit2.IsPrograde, "IsPrograde", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareDoubles(orbit1.MeanMotion, orbit2.MeanMotion, epsilon), "MeanMotion", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareVector3ds(orbit1.NodeLineVector, orbit2.NodeLineVector, epsilon), "NodeLineVector", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareVector3ds(orbit1.OrbitalPlaneNormal, orbit2.OrbitalPlaneNormal, epsilon), "OrbitalPlaneNormal", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareVector3ds(orbit1.OrbitalPlaneRight, orbit2.OrbitalPlaneRight, epsilon), "OrbitalPlaneRight", conditionErrors) && flag;
				flag = CaptureCompareError(() => orbit1.OrbitType == orbit2.OrbitType, "OrbitType", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareVector3ds(orbit1.Periapsis, orbit2.Periapsis, epsilon), "Periapsis", conditionErrors) && flag;
				flag = CaptureCompareError(() => CompareOrbitalAngles(orbit1.PeriapsisAngle, orbit2.PeriapsisAngle, orbit1.Eccentricity, epsilon), "PeriapsisAngle", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareDoubles(orbit1.PeriapsisDistance, orbit2.PeriapsisDistance, epsilon), "PeriapsisDistance", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.Period, orbit2.Period, epsilon), "Period", conditionErrors) && flag;
				return CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.SemiMinorAxis, orbit2.SemiMinorAxis, epsilon), "SemiMinorAxis", conditionErrors) && flag;
			}

			public static bool CompareOrbitalAngles(double angleA, double angleB, double eccentricity)
			{
				return CompareOrbitalAngles(angleA, angleB, eccentricity, 4E-12);
			}

			public static bool CompareOrbitalAngles(double angleA, double angleB, double eccentricity, double epsilon)
			{
				bool flag = angleA == angleB;
				if (!flag)
				{
					flag = Utilities.CompareDoubles(angleA, angleB, epsilon);
					if (!flag && eccentricity < 1.0)
					{
						double num = angleA.AsZeroTo2PI();
						double num2 = angleB.AsZeroTo2PI();
						flag = Utilities.CompareDoubles(num, num2, epsilon);
						if (!flag)
						{
							num = Math.Abs(num);
							num2 = Math.Abs(num2);
							bool num3 = Utilities.CompareDoubles(num, Math.PI * 2.0, epsilon);
							bool flag2 = Utilities.CompareDoubles(num2, 0.0, epsilon);
							if (num3 && flag2)
							{
								flag = true;
							}
							else
							{
								bool flag3 = Utilities.CompareDoubles(num2, Math.PI * 2.0, epsilon);
								if (Utilities.CompareDoubles(num, 0.0, epsilon) && flag3)
								{
									flag = true;
								}
							}
						}
					}
				}
				return flag;
			}

			public static bool ComparePrimaryOrbitalElements(Orbit orbit1, Orbit orbit2, double epsilon = 1E-09)
			{
				return ComparePrimaryOrbitalElements(orbit1, orbit2, null, epsilon);
			}

			public static bool ComparePrimaryOrbitalElements(Orbit orbit1, Orbit orbit2, StringBuilder conditionErrors, double epsilon = 1E-09)
			{
				bool flag = true;
				flag = CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.Eccentricity, orbit2.Eccentricity, epsilon), "Eccentricity", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.SemiMajorAxis, orbit2.SemiMajorAxis, epsilon), "SemiMajorAxis", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.PeriapsisAngle, orbit2.PeriapsisAngle, epsilon), "PeriapsisAngle", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.Inclination, orbit2.Inclination, epsilon), "Inclination", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.RightAscensionOfAscendingNode, orbit2.RightAscensionOfAscendingNode, epsilon), "RightAscensionOfAscendingNode", conditionErrors) && flag;
				return CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.PrimaryMass, orbit2.PrimaryMass, epsilon), "PrimaryMass", conditionErrors) && flag;
			}

			public static bool CompareStateElements(Orbit orbit1, Orbit orbit2, StringBuilder conditionErrors, double epsilon = 1E-09)
			{
				bool flag = true;
				flag = CaptureCompareError(() => Utilities.CompareVector3ds(orbit1.Position, orbit2.Position, epsilon), "Position", conditionErrors) && flag;
				flag = CaptureCompareError(() => Utilities.CompareVector3ds(orbit1.Velocity, orbit2.Velocity, epsilon), "Velocity", conditionErrors) && flag;
				return CaptureCompareError(() => Utilities.CompareDoublesNanEquiv(orbit1.Time, orbit2.Time, epsilon), "Time", conditionErrors) && flag;
			}

			public static bool CompareStateElements(Orbit orbit1, Orbit orbit2, double epsilon = 1E-09)
			{
				return CompareStateElements(orbit1, orbit2, null, epsilon);
			}

			private static bool CaptureCompareError(Func<bool> compareCondition, string name, StringBuilder errorList)
			{
				bool num = compareCondition();
				if (!num)
				{
					errorList?.AppendFormat((errorList.Length == 0) ? "{0}" : ", {0}", name);
				}
				return num;
			}
		}

		private Vector3d _angularMomentum;

		private double _angularMomentumMag;

		private Vector3d _apoapsis;

		private double _apoapsisDistanceEffective;

		private double _apoapsisDistanceFriendly;

		private bool _debug;

		private double _eccentricAnomaly;

		private double _eccentricAnomalyAtApoapsis;

		private double _eccentricity;

		private Vector3d _eccentricityVector;

		private double _hyperbolicTrueAnomalyLimit;

		private double _inclination;

		private double _meanAnomaly;

		private double _meanMotion;

		private Vector3d _nodeLineVector;

		private double _nodeLineVectorMag;

		private Vector3d _orbitalPlaneNormal;

		private Vector3d _orbitalPlaneRight;

		private Vector3d _periapsis;

		private double _periapsisAngle;

		private double _periapsisDistance;

		private double _period;

		private Vector3d _position;

		private double _primaryMass;

		private bool _prograde;

		private double _radialVelocity;

		private double _rightAscensionOfAscendingNode;

		private double _semiMajorAxis;

		private double _semiMinorAxis;

		private double _time;

		private double _trueAnomaly;

		private double _trueAnomalyAtApoapsis;

		private double _trueAnomalyOfAscendingNode;

		private double _trueAnomalyOfDesendingNode;

		private double _u;

		private bool _valid;

		private Vector3d _velocity;

		public static bool SuppressErrors { get; set; }

		public Vector3d AngularMomentum => OrbitMath.ConvertOrbitToFromGameCoords(_angularMomentum);

		public double AngularMomentumMag => _angularMomentumMag;

		public Vector3d Apoapsis => OrbitMath.ConvertOrbitToFromGameCoords(_apoapsis);

		public double ApoapsisDistance => _apoapsisDistanceFriendly;

		public double ApoapsisDistanceEffective => _apoapsisDistanceEffective;

		public bool DebugEnabled { get; set; }

		public double EccentricAnomaly => _eccentricAnomaly;

		public double EccentricAnomalyAtApoapsis => _eccentricAnomalyAtApoapsis;

		public double Eccentricity => _eccentricity;

		public Vector3d EccentricityVector => OrbitMath.ConvertOrbitToFromGameCoords(_eccentricityVector);

		public double HyperbolicTrueAnomalyLimit => _hyperbolicTrueAnomalyLimit;

		public double Inclination => _inclination;

		public bool IsPrograde => _prograde;

		public bool IsValid => _valid;

		public double MeanAnomaly => _meanAnomaly;

		public double MeanMotion => _meanMotion;

		public Vector3d NodeLineVector => OrbitMath.ConvertOrbitToFromGameCoords(_nodeLineVector);

		public Vector3d OrbitalPlaneNormal => OrbitMath.ConvertOrbitToFromGameCoords(_orbitalPlaneNormal);

		public Vector3d OrbitalPlaneRight => OrbitMath.ConvertOrbitToFromGameCoords(_orbitalPlaneRight);

		public OrbitType OrbitType
		{
			get
			{
				if (_eccentricity < 9E-07)
				{
					return OrbitType.Circular;
				}
				if (_eccentricity < 1.0)
				{
					return OrbitType.Elliptical;
				}
				if (_eccentricity == 1.0)
				{
					return OrbitType.Parabolic;
				}
				return OrbitType.Hyperbolic;
			}
		}

		public Vector3d Periapsis => OrbitMath.ConvertOrbitToFromGameCoords(_periapsis);

		public double PeriapsisAngle => _periapsisAngle;

		public double PeriapsisDistance => _periapsisDistance;

		public double Period => _period;

		public Vector3d Position => OrbitMath.ConvertOrbitToFromGameCoords(_position);

		public double PrimaryMass => _primaryMass;

		public double RightAscensionOfAscendingNode => _rightAscensionOfAscendingNode;

		public double SemiMajorAxis => _semiMajorAxis;

		public double SemiMinorAxis => _semiMinorAxis;

		public double Time => _time;

		public double TrueAnomaly => _trueAnomaly;

		public double TrueAnomalyAtApoapsis => _trueAnomalyAtApoapsis;

		public double TrueAnomalyOfAscendingNode => _trueAnomalyOfAscendingNode;

		public double TrueAnomalyOfDescendingNode => _trueAnomalyOfDesendingNode;

		public double U => _u;

		public Vector3d Velocity => OrbitMath.ConvertOrbitToFromGameCoords(_velocity);

		public event OrbitHandler UpdatedFromOrbitalElements;

		public Orbit()
		{
			_debug = false;
			_valid = false;
			_u = 0.0;
			_periapsisAngle = 0.0;
			_periapsisDistance = 0.0;
			_apoapsisDistanceFriendly = 0.0;
			_eccentricAnomaly = 0.0;
			_meanAnomaly = 0.0;
			_eccentricity = 0.0;
			_semiMajorAxis = 0.0;
			_semiMinorAxis = 0.0;
			_period = 0.0;
			_meanMotion = 0.0;
			_trueAnomaly = 0.0;
			_u = 0.0;
		}

		public Orbit(IOrbit source)
			: this(source.Position, source.Velocity, source.Time, source.PrimaryMass)
		{
		}

		public Orbit(double time, double e, double a, double w, double nu, double inclination, double ra, double primaryMass, bool prograde)
		{
			if (e > 1.0)
			{
				a = 0.0 - Math.Abs(a);
			}
			_debug = false;
			_valid = true;
			UpdateFromOrbitalElements(time, e, a, w, nu, inclination, ra, primaryMass, prograde);
		}

		public Orbit(IOrbit source, double futureTrueAnomaly)
			: this(0.0, source.Eccentricity, source.SemiMajorAxis, source.PeriapsisAngle, futureTrueAnomaly, source.Inclination, source.RightAscensionOfAscendingNode, source.PrimaryMass, source.IsPrograde)
		{
			_time = OrbitMath.GetTimeAtTrueAnomaly(source, futureTrueAnomaly);
			if (Debug.isDebugBuild && !SuppressErrors && futureTrueAnomaly != source.TrueAnomaly)
			{
				_ = _time;
				_ = source.Time;
			}
		}

		public Orbit(OrbitData data, double primaryMass)
			: this(data.Time, data.Eccentricity, data.SemiMajorAxis, data.ArgumentOfPeriapsis, data.TrueAnomaly, data.Inclination, data.RightAscensionOfAscendingNode, primaryMass, data.Prograde)
		{
		}

		public Orbit(Vector3d p, Vector3d v, double time, double primaryMass)
		{
			UpdateFromStateVectors(p, v, time, primaryMass);
		}

		public bool AdvanceTime(double elapsedTime, double newTime)
		{
			double trueAnomaly = _trueAnomaly;
			double eccentricity = _eccentricity;
			double meanMotion = _meanMotion;
			_time = newTime;
			bool flag = false;
			bool flag2 = false;
			double num = 1.0;
			try
			{
				if (eccentricity < 1.0)
				{
					_meanAnomaly = OrbitMath.AdvanceMeanAnomaly(eccentricity, _meanAnomaly, meanMotion, elapsedTime);
					_eccentricAnomaly = OrbitMath.GetEccentricAnomalyFromMeanAnomaly(eccentricity, _meanAnomaly, _eccentricAnomaly);
					if (!double.IsNaN(_eccentricAnomaly))
					{
						double.IsInfinity(_eccentricAnomaly);
					}
					_trueAnomaly = OrbitMath.GetTrueAnomalyFromEccentricAnomaly(eccentricity, _eccentricAnomaly);
				}
				else
				{
					double num2 = 118.12498692325627;
					if (Math.Abs(_meanAnomaly) < num2)
					{
						_meanAnomaly = OrbitMath.AdvanceMeanAnomaly(eccentricity, _meanAnomaly, meanMotion, elapsedTime);
						_eccentricAnomaly = OrbitMath.GetEccentricAnomalyFromMeanAnomaly(eccentricity, _meanAnomaly);
						_trueAnomaly = OrbitMath.GetTrueAnomalyFromEccentricAnomaly(eccentricity, _eccentricAnomaly);
					}
					else
					{
						num = 1.0;
						flag2 = true;
					}
				}
			}
			catch (OrbitMath.OrbitFailedConvergence)
			{
				num = 1.0;
				flag = true;
			}
			if (double.IsNaN(_trueAnomaly))
			{
				flag = true;
				num = 0.1;
			}
			if (flag2 || flag)
			{
				Vector3d coord = _position + _velocity * elapsedTime * num;
				UpdateFromStateVectors(OrbitMath.ConvertOrbitToFromGameCoords(coord), OrbitMath.ConvertOrbitToFromGameCoords(_velocity), _time, _primaryMass);
			}
			else
			{
				UpdateStateVectors();
			}
			return OrbitMath.GetPeriapsisCrossing(trueAnomaly, _trueAnomaly, elapsedTime, _period);
		}

		public OrbitData GenerateOrbitData()
		{
			return new OrbitData
			{
				ArgumentOfPeriapsis = PeriapsisAngle,
				Eccentricity = Eccentricity,
				Inclination = Inclination,
				Prograde = IsPrograde,
				RightAscensionOfAscendingNode = RightAscensionOfAscendingNode,
				SemiMajorAxis = SemiMajorAxis,
				Time = Time,
				TrueAnomaly = TrueAnomaly
			};
		}

		public double GetElementsMagnitude()
		{
			return Eccentricity + SemiMajorAxis + PeriapsisAngle + Inclination + RightAscensionOfAscendingNode + AngularMomentum.magnitude + EccentricityVector.magnitude + NodeLineVector.magnitude + _radialVelocity + OrbitalPlaneNormal.magnitude + Time;
		}

		public int GetHashInt()
		{
			return (int)((_eccentricity + _inclination + _periapsisAngle + _rightAscensionOfAscendingNode) * 1000.0 + _semiMajorAxis / 10000.0);
		}

		public string GetOrbitInfo()
		{
			return $"Primary mass: {_primaryMass:G17} ({_primaryMass * 6.67384E-11:G17})\neccentricity {Eccentricity:G17}\nsemiMajorAxis {SemiMajorAxis:G17}\ntrueAnomaly {TrueAnomaly:G17}\nperiapsisAngle {PeriapsisAngle:G17}\ninclination {Inclination:G17}\nrightAscention {RightAscensionOfAscendingNode:G17}\nprograde {IsPrograde}\nposition {Position}\nvelocity {Velocity}\nAngularMomentum {AngularMomentum}\nAngularMomentumMag {AngularMomentum.magnitude:G17}\nEccentricityVector {EccentricityVector}\nNodeLineVector {NodeLineVector}\nNodeLineVectorMag {_nodeLineVectorMag:G17}\nRadialVelocity {_radialVelocity}\nOrbitNormal {OrbitalPlaneNormal}\nTime {Time:G17}\n";
		}

		public double GetPeriodStartTime()
		{
			return Time - GetTimePastPeriapsis();
		}

		public double GetTimePastPeriapsis()
		{
			if (_eccentricity < 1.0)
			{
				return OrbitMath.GetTransitTime(_meanAnomaly.AsZeroTo2PI(), _meanMotion);
			}
			return 0.0;
		}

		public double GetTimeToApoapsis()
		{
			if (_eccentricity < 1.0)
			{
				return OrbitMath.GetTransitTime(Math.PI - _meanAnomaly.AsNegativePIToPI(), _meanMotion);
			}
			return double.PositiveInfinity;
		}

		public double GetTimeToPeriapsis()
		{
			if (_eccentricity < 1.0)
			{
				return OrbitMath.GetTransitTime(Math.PI * 2.0 - _meanAnomaly.AsZeroTo2PI(), _meanMotion);
			}
			if (TrueAnomaly.AsZeroTo2PI() > Math.PI)
			{
				return OrbitMath.GetTransitTime(Mathd.Abs(_meanAnomaly), _meanMotion);
			}
			return double.NaN;
		}

		public void SetTrueAnomaly(double trueAnomaly, double? time)
		{
			if (!time.HasValue)
			{
				time = OrbitMath.GetTimeAtTrueAnomaly(this, trueAnomaly);
			}
			UpdateFromOrbitalElements(time.Value, _eccentricity, _semiMajorAxis, _periapsisAngle, trueAnomaly, _inclination, _rightAscensionOfAscendingNode, _primaryMass, _prograde);
		}

		public override string ToString()
		{
			return GetOrbitInfo();
		}

		public void UpdateFromOrbitalElements(double time, double e, double a, double w, double nu, double inclination, double ra, double primaryMass, bool prograde)
		{
			if (Utilities.CompareDoubles(inclination, 0.0, 1E-09))
			{
				inclination = 1E-09;
			}
			SetOrbitalElements(time, e, a, w, nu, inclination, ra, primaryMass, prograde);
			UpdateStateVectors();
			OrbitMath.UpdateStateVectorDependentOribitalElements(_position, _velocity, _u, out _angularMomentum, out _radialVelocity, out _nodeLineVector, out _nodeLineVectorMag, out _orbitalPlaneNormal, out _eccentricityVector, out _orbitalPlaneRight);
			if (_debug)
			{
				Debug.Log(GetOrbitInfo());
			}
			this.UpdatedFromOrbitalElements?.Invoke(this);
		}

		public void UpdateFromStateVectors(Vector3d p, Vector3d v, double time, double primaryMass)
		{
			_primaryMass = primaryMass;
			_time = time;
			p = OrbitMath.ConvertOrbitToFromGameCoords(p);
			v = OrbitMath.ConvertOrbitToFromGameCoords(v);
			if (Utilities.CompareDoubles(v.z, 0.0, 1E-09))
			{
				v.z = 1E-09;
			}
			_debug = false;
			_position = p;
			_velocity = v;
			_valid = true;
			_u = _primaryMass * 6.67384E-11;
			double u = _u;
			OrbitMath.UpdateStateVectorDependentOribitalElements(_position, _velocity, _u, out _angularMomentum, out _radialVelocity, out _nodeLineVector, out _nodeLineVectorMag, out _orbitalPlaneNormal, out _eccentricityVector, out _orbitalPlaneRight);
			double magnitude = _angularMomentum.magnitude;
			_prograde = OrbitMath.CalculatePrograde(_angularMomentum, magnitude);
			double magnitude2 = p.magnitude;
			double num = _eccentricityVector.magnitude;
			if (Utilities.CompareDoubles(num, 0.0))
			{
				num = 1E-06;
				_eccentricityVector = _eccentricityVector.normalized * num;
			}
			else if (Utilities.CompareDoubles(num, 1.0))
			{
				num = 0.999999;
				_eccentricityVector = _eccentricityVector.normalized * num;
			}
			double specificMechanicalEnergy = OrbitMath.CalculateSpecificMechanicalEnergy(v.sqrMagnitude, u, magnitude2);
			double semiMajorAxis = OrbitMath.CalculateSemiMajorAxis(u, specificMechanicalEnergy);
			_inclination = OrbitMath.CalculateInclination(_angularMomentum, magnitude);
			_rightAscensionOfAscendingNode = 0.0;
			if (_nodeLineVectorMag != 0.0)
			{
				_rightAscensionOfAscendingNode = Mathd.Acos(_nodeLineVector.x / _nodeLineVectorMag);
				if (_nodeLineVector.y < 0.0)
				{
					_rightAscensionOfAscendingNode = Math.PI * 2.0 - _rightAscensionOfAscendingNode;
				}
			}
			double num2;
			if (num > 9E-07)
			{
				num2 = Mathd.Acos(Mathd.Clamp(Vector3d.Dot(_eccentricityVector, p) / num / magnitude2, -1.0, 1.0));
				if (_radialVelocity < 0.0)
				{
					num2 = Math.PI * 2.0 - num2;
				}
			}
			else
			{
				num2 = Mathd.Acos(Mathd.Clamp(Vector3d.Dot(_nodeLineVector, p) / _nodeLineVectorMag / magnitude2, -1.0, 1.0));
				if (Vector3d.Cross(_nodeLineVector, p).z < 0.0)
				{
					num2 = Math.PI * 2.0 - num2;
				}
			}
			double num3 = 0.0;
			if (_nodeLineVectorMag != 0.0 && num > 9E-07)
			{
				num3 = Mathd.Acos(Mathd.Clamp(Vector3d.Dot(_nodeLineVector, _eccentricityVector) / _nodeLineVectorMag / num, -1.0, 1.0));
				if (_eccentricityVector.z < 0.0)
				{
					num3 = Math.PI * 2.0 - num3;
				}
			}
			double num4 = Mathd.Atan2(_eccentricityVector.y, _eccentricityVector.x);
			if (_prograde)
			{
				num4 = Math.PI * 2.0 - num4;
			}
			_periapsisAngle = num3;
			_eccentricity = num;
			_semiMajorAxis = semiMajorAxis;
			_trueAnomaly = num2;
			_eccentricAnomaly = OrbitMath.GetEccentricAnomalyFromTrueAnomaly(num, num2);
			_meanAnomaly = OrbitMath.GetMeanAnomalyFromEccentricAnomaly(num, _eccentricAnomaly);
			OrbitMath.UpdateDependantOrbitalElements(this, out _periapsisDistance, out _apoapsisDistanceFriendly, out _period, out _semiMinorAxis, out _meanMotion, out _angularMomentumMag, out _trueAnomalyOfAscendingNode, out _trueAnomalyOfDesendingNode, out _periapsis, out _apoapsis, out _trueAnomalyAtApoapsis, out _hyperbolicTrueAnomalyLimit, out _eccentricAnomalyAtApoapsis, out _apoapsisDistanceEffective);
			if (_debug)
			{
				Debug.Log(GetOrbitInfo());
			}
		}

		private void SetOrbitalElements(double time, double e, double a, double w, double nu, double inclination, double ra, double primaryMass, bool prograde)
		{
			if (Utilities.CompareDoubles(e, 0.0))
			{
				e = 1E-06;
			}
			else if (Utilities.CompareDoubles(e, 1.0))
			{
				e = 0.999999;
			}
			_time = time;
			_eccentricity = e;
			_semiMajorAxis = a;
			_periapsisAngle = w;
			_inclination = inclination;
			_rightAscensionOfAscendingNode = ra;
			_trueAnomaly = nu;
			_eccentricAnomaly = OrbitMath.GetEccentricAnomalyFromTrueAnomaly(e, nu);
			_meanAnomaly = OrbitMath.GetMeanAnomalyFromEccentricAnomaly(e, _eccentricAnomaly);
			_prograde = prograde;
			_primaryMass = primaryMass;
			_u = primaryMass * 6.67384E-11;
			OrbitMath.UpdateDependantOrbitalElements(this, out _periapsisDistance, out _apoapsisDistanceFriendly, out _period, out _semiMinorAxis, out _meanMotion, out _angularMomentumMag, out _trueAnomalyOfAscendingNode, out _trueAnomalyOfDesendingNode, out _periapsis, out _apoapsis, out _trueAnomalyAtApoapsis, out _hyperbolicTrueAnomalyLimit, out _eccentricAnomalyAtApoapsis, out _apoapsisDistanceEffective);
		}

		private void UpdateStateVectors()
		{
			OrbitMath.GetStateVectorsFromTrueAnomaly(this, _trueAnomaly, out _position, out _velocity);
		}
	}
}
