using System;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class StationaryMapOrbitNode : IOrbitNode, INode, IStructureNode, IOrbit, INavSphereTarget
	{
		private IGameTime _gameTime;

		private IIocContainer _ioc;

		private IStationaryNode _node;

		private OrbitPoint _zeroPoint;

		Vector3d IOrbit.AngularMomentum => Vector3d.zero;

		double IOrbit.AngularMomentumMag => 0.0;

		public IOrbitPoint Apoapsis => _zeroPoint;

		Vector3d IOrbit.Apoapsis => Vector3d.zero;

		double IOrbit.ApoapsisDistance => 0.0;

		double IOrbit.ApoapsisDistanceEffective => 0.0;

		bool IOrbit.DebugEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		double IOrbit.EccentricAnomaly => 0.0;

		double IOrbit.EccentricAnomalyAtApoapsis => 0.0;

		double IOrbit.Eccentricity => 0.0;

		Vector3d IOrbit.EccentricityVector => Vector3d.zero;

		public float GameViewLoadDistance => 0f;

		public IGameViewObject GameViewObject => null;

		double IOrbit.HyperbolicTrueAnomalyLimit => 0.0;

		public Guid Id => _node.Id;

		double IOrbit.Inclination => 0.0;

		public bool IsDestroyed { get; private set; }

		bool IOrbit.IsPrograde => false;

		bool IOrbit.IsValid => true;

		public double MaxChildDistance => 0.0;

		double IOrbit.MeanAnomaly => 0.0;

		double IOrbit.MeanMotion => 0.0;

		public string Name => _node.Name;

		public int NestedDepth
		{
			get
			{
				if (Parent == null)
				{
					return 0;
				}
				return Parent.NestedDepth + 1;
			}
		}

		public bool NodeExitsSoi => false;

		Vector3d IOrbit.NodeLineVector => Vector3d.zero;

		public IOrbit Orbit => this;

		Vector3d IOrbit.OrbitalPlaneNormal => Vector3d.zero;

		Vector3d IOrbit.OrbitalPlaneRight => Vector3d.zero;

		public IOrbitNode OrbitNode => this;

		OrbitType IOrbit.OrbitType => OrbitType.Elliptical;

		public bool OrbitUpdated => false;

		bool IOrbitNode.OrbitUpdated
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public IPlanetNode Parent => _node.Parent;

		IPlanetNode INode.Parent
		{
			get
			{
				return _node.Parent;
			}
			set
			{
			}
		}

		public IOrbitPoint Periapsis => _zeroPoint;

		Vector3d IOrbit.Periapsis => Vector3d.zero;

		double IOrbit.PeriapsisAngle => 0.0;

		double IOrbit.PeriapsisDistance => 0.0;

		double IOrbit.Period => 0.0;

		public Vector3d Position => _node.Position;

		Vector3d IOrbit.Position => _node.Position;

		double IOrbit.PrimaryMass => 0.0;

		double IOrbit.RightAscensionOfAscendingNode => 0.0;

		double IOrbit.SemiMajorAxis => 0.0;

		double IOrbit.SemiMinorAxis => 0.0;

		public Vector3d SolarPosition => _node.SolarPosition;

		public Vector3d SolarVelocity => Vector3.zero;

		public double SphereOfInfluence => 0.0;

		double IOrbit.Time => _gameTime.Time;

		double IOrbit.TrueAnomaly => 0.0;

		double IOrbit.TrueAnomalyAtApoapsis => 0.0;

		double IOrbit.TrueAnomalyOfAscendingNode => 0.0;

		double IOrbit.TrueAnomalyOfDescendingNode => 0.0;

		double IOrbit.U => 0.0;

		public Vector3d Velocity
		{
			get
			{
				Vector3d surfaceVector = Parent.CalculateSurfaceVelocity(_node.SurfacePosition);
				return Parent.SurfaceVectorToPlanetVector(surfaceVector);
			}
		}

		Vector3d IOrbit.Velocity => Velocity;

		public event OrbitNodeHandler ChangedSoI;

		public event NodeDelegate Destroyed;

		public event NodeNameChangedHandler NameChanged;

		event OrbitHandler IOrbit.UpdatedFromOrbitalElements
		{
			add
			{
				throw new NotImplementedException();
			}
			remove
			{
				throw new NotImplementedException();
			}
		}

		public StationaryMapOrbitNode(IIocContainer ioc, IStationaryNode node)
		{
			_node = node;
			_ioc = ioc;
			_gameTime = _ioc.Resolve<IGameTime>();
			_zeroPoint = new OrbitPoint();
			this.ChangedSoI = null;
			this.Destroyed = null;
			this.NameChanged = null;
			node.Destroyed += OnNodeDestroyed;
		}

		bool IOrbit.AdvanceTime(double elapsedTime, double newTime)
		{
			return false;
		}

		public void FlightEnd()
		{
		}

		public void FlightLateUpdate(double elapsedTime)
		{
		}

		public void FlightStart()
		{
		}

		public void FlightUpdate(double elapsedTime, double currentTime)
		{
		}

		OrbitData IOrbit.GenerateOrbitData()
		{
			return new OrbitData();
		}

		public IOrbitPoint GetCurrentPoint()
		{
			return _zeroPoint;
		}

		double IOrbit.GetElementsMagnitude()
		{
			return 0.0;
		}

		public IOrbitNode GetNodeAtDepth(int depth)
		{
			if (depth > NestedDepth)
			{
				throw new ArgumentOutOfRangeException("Node depth cannot be greater than current depth (can't access children).");
			}
			if (depth < 0)
			{
				throw new ArgumentOutOfRangeException("Node depth must be >= 0");
			}
			if (depth == NestedDepth)
			{
				return this;
			}
			IOrbitNode orbitNode = this;
			do
			{
				orbitNode = orbitNode.Parent;
			}
			while (orbitNode.NestedDepth != depth);
			return orbitNode;
		}

		string IOrbit.GetOrbitInfo()
		{
			return string.Empty;
		}

		double IOrbit.GetPeriodStartTime()
		{
			return 0.0;
		}

		public IOrbitPoint GetPointAbovePlanetCenter(double height)
		{
			return _zeroPoint;
		}

		public IOrbitPoint GetPointAgl(double agl)
		{
			return _zeroPoint;
		}

		public IOrbitPoint GetPointAtmosphereEntry()
		{
			return _zeroPoint;
		}

		public IOrbitPoint GetPointAtTime(double time)
		{
			return _zeroPoint;
		}

		public Vector3d GetSolarPositionAtTime(double time)
		{
			return Vector3d.zero;
		}

		public Vector3d GetSolarVelocityAtTime(double time)
		{
			return Vector3d.zero;
		}

		double IOrbit.GetTimePastPeriapsis()
		{
			return 0.0;
		}

		double IOrbit.GetTimeToApoapsis()
		{
			return 0.0;
		}

		double IOrbit.GetTimeToPeriapsis()
		{
			return 0.0;
		}

		public void Initialize()
		{
		}

		public bool IsDescendantOf(IOrbitNode node, bool includeSelf)
		{
			IOrbitNode orbitNode;
			if (!includeSelf)
			{
				IOrbitNode parent = Parent;
				orbitNode = parent;
			}
			else
			{
				IOrbitNode parent = this;
				orbitNode = parent;
			}
			IOrbitNode orbitNode2 = orbitNode;
			bool result = false;
			while (orbitNode2 != null)
			{
				if (orbitNode2 == node)
				{
					result = true;
					break;
				}
				orbitNode2 = orbitNode2.Parent;
			}
			return result;
		}

		public void SetStateVectors(Vector3d position, Vector3d velocity, double time)
		{
		}

		public void SetStateVectorsAtDefaultTime(Vector3d position, Vector3d velocity)
		{
		}

		void IOrbit.SetTrueAnomaly(double trueAnomaly, double? time)
		{
		}

		public void SynchronizeData()
		{
		}

		void IOrbit.UpdateFromOrbitalElements(double time, double e, double a, double w, double nu, double inclination, double ra, double primaryMass, bool prograde)
		{
		}

		void IOrbit.UpdateFromStateVectors(Vector3d p, Vector3d v, double time, double primaryMass)
		{
		}

		private void OnNodeDestroyed(INode node)
		{
			node.Destroyed -= OnNodeDestroyed;
			IsDestroyed = true;
			this.Destroyed?.Invoke(this);
		}
	}
}
