using System;
using System.Reflection;
using ModApi.Flight.Sim;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public abstract class OrbitNode : Node, IOrbitNode, INode
	{
		private FlightSceneScript _flightSceneScript;

		private string _name;

		private IOrbit _orbit;

		public static Vector3d MinimumOrbitVelocity => new Vector3d(0.0001, 0.0001, 0.0001);

		public IOrbitPoint Apoapsis => OrbitMath.GetPointAtTrueAnomaly(Orbit, Math.PI);

		public virtual double MaxChildDistance => SphereOfInfluence;

		public virtual string Name
		{
			get
			{
				return _name;
			}
			set
			{
				string name = _name;
				_name = value;
				if (name != _name)
				{
					this.NameChanged?.Invoke(_name, name);
				}
			}
		}

		public int NestedDepth
		{
			get
			{
				if (base.Parent == null)
				{
					return 0;
				}
				return base.Parent.NestedDepth + 1;
			}
		}

		public bool NodeExitsSoi
		{
			get
			{
				if (!(Orbit.Eccentricity > 1.0))
				{
					return Orbit.ApoapsisDistance >= base.Parent.SphereOfInfluenceExitDistance;
				}
				return true;
			}
		}

		public IOrbit Orbit
		{
			get
			{
				return _orbit;
			}
			protected set
			{
				_orbit = value;
				if (Debug.isDebugBuild && _orbit != null && base.Parent != null)
				{
					_ = Position.magnitude;
					_ = base.Parent.SphereOfInfluenceExitDistance;
				}
			}
		}

		public bool OrbitUpdated { get; set; }

		public IOrbitPoint Periapsis => OrbitMath.GetPointAtTrueAnomaly(Orbit, 0.0);

		public override Vector3d Position
		{
			get
			{
				if (Orbit != null)
				{
					return Orbit.Position;
				}
				return Vector3d.zero;
			}
		}

		public override Vector3d SolarPosition
		{
			get
			{
				if (base.Parent == null)
				{
					return Position;
				}
				return Position + base.Parent.GetSolarPositionAtTime(Orbit.Time);
			}
		}

		public Vector3d SolarVelocity
		{
			get
			{
				if (base.Parent == null)
				{
					return Velocity;
				}
				return Velocity + base.Parent.SolarVelocity;
			}
		}

		public virtual double SphereOfInfluence => 0.0;

		public virtual Vector3d Velocity
		{
			get
			{
				if (Orbit != null)
				{
					return Orbit.Velocity;
				}
				return Vector3d.zero;
			}
		}

		public event OrbitNodeHandler ChangedSoI;

		public event NodeNameChangedHandler NameChanged;

		public IOrbitPoint GetCurrentPoint()
		{
			IOrbitPoint orbitPoint = OrbitMath.PointsPool.Get();
			IOrbit orbit = Orbit;
			orbitPoint.Set(orbit.Position, orbit.Velocity, orbit.TrueAnomaly, orbit.EccentricAnomaly, orbit.Time);
			return orbitPoint;
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

		public IOrbitPoint GetPointAbovePlanetCenter(double height)
		{
			bool num = Orbit.TrueAnomaly > Math.PI;
			IOrbitPoint result = null;
			if (num || Orbit.Eccentricity < 1.0)
			{
				result = OrbitMath.GetPointAtDistance(Orbit, height, ascent: false);
			}
			return result;
		}

		public IOrbitPoint GetPointAgl(double agl)
		{
			return GetPointAbovePlanetCenter(base.Parent.PlanetData.Radius + agl);
		}

		public IOrbitPoint GetPointAtmosphereEntry()
		{
			IPlanetData planetData = base.Parent.PlanetData;
			double agl = ((planetData.AtmosphereData != null) ? planetData.AtmosphereData.Height : 0.0);
			return GetPointAgl(agl);
		}

		public IOrbitPoint GetPointAtTime(double time)
		{
			if (Orbit != null)
			{
				IOrbitPoint orbitPoint;
				if (Orbit.Time == time)
				{
					orbitPoint = OrbitMath.PointsPool.Get();
					orbitPoint.Set(Orbit.Position, Orbit.Velocity, Orbit.TrueAnomaly, Orbit.EccentricAnomaly, Orbit.Time);
				}
				else
				{
					orbitPoint = OrbitMath.GetPointAtTime(Orbit, time);
				}
				return orbitPoint;
			}
			return null;
		}

		public Vector3d GetSolarPositionAtTime(double time)
		{
			if (Orbit != null)
			{
				Vector3d vector3d = ((Orbit.Time != time) ? OrbitMath.GetPointAtTime(Orbit, time).Position : Position);
				Vector3d zero = Vector3d.zero;
				IPlanetNode parent = base.Parent;
				for (IOrbit orbit = parent?.Orbit; orbit != null; orbit = parent?.Orbit)
				{
					zero += OrbitMath.GetPointAtTime(orbit, time).Position;
					parent = parent.Parent;
				}
				return vector3d + zero;
			}
			return Vector3d.zero;
		}

		public Vector3d GetSolarVelocityAtTime(double time)
		{
			if (Orbit != null)
			{
				Vector3d velocity = OrbitMath.GetPointAtTime(Orbit, time).Velocity;
				Vector3d vector3d = ((base.Parent?.Orbit != null) ? OrbitMath.GetPointAtTime(base.Parent.Orbit, time).Velocity : Vector3d.zero);
				return velocity + vector3d;
			}
			return Vector3d.zero;
		}

		public override void Initialize()
		{
			_flightSceneScript = FlightSceneScript.Instance;
		}

		public bool IsDescendantOf(IOrbitNode node, bool includeSelf)
		{
			IOrbitNode orbitNode;
			if (!includeSelf)
			{
				IOrbitNode parent = base.Parent;
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

		public virtual void SetStateVectors(Vector3d position, Vector3d velocity, double time)
		{
			if (base.Parent != null)
			{
				Orbit.UpdateFromStateVectors(position, velocity, time, base.Parent.PlanetData.Mass);
				OrbitUpdated = true;
			}
		}

		public virtual void SetStateVectorsAtDefaultTime(Vector3d position, Vector3d velocity)
		{
			if (velocity == Vector3d.zero)
			{
				velocity = new Vector3d(0.0001, 0.0001, 0.0001);
			}
			SetStateVectors(position, velocity, _flightSceneScript.FlightState.Time);
		}

		public virtual void TransitionToNewSoi(IPlanetNode newParent, Vector3d newPosition, Vector3d newVelocity)
		{
			Vector3d velocity = Velocity;
			Vector3d position = Position;
			string name = base.Parent.PlanetData.Name;
			Vector3d solarVelocity = SolarVelocity;
			Vector3d solarPosition = SolarPosition;
			base.Parent.RemoveChildNode(this);
			newParent.AddChildNode(this);
			SetStateVectorsAtDefaultTime(newPosition, newVelocity);
			this.ChangedSoI?.Invoke(this);
			if (Debug.isDebugBuild)
			{
				Debug.Log("Transition (" + (GameViewObject.IsLoadedInGameView ? GameViewObject.GameObject.name : "game object not loaded") + ") from " + name + " SOI to " + newParent.PlanetData.Name + "\n" + $"Frame: {Time.frameCount}\n" + $"OldP:\t{position}, OldV:\t{velocity}\n" + $"NewP:\t{newPosition}, NewV:\t{newVelocity}\n" + $"OldSolarP: \t{solarPosition}, OldSolarV:\t{solarVelocity}\n" + $"NewSolarP: \t{SolarPosition}, NewSolarV:\t{SolarVelocity}\n" + $"NewOrbit - ecc: {Orbit.Eccentricity}");
			}
		}
	}
}
