using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Scripts.PlanetStudio;
using ModApi;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Flight.Sim.Events;
using ModApi.Flight.UI;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Flight.Sim
{
	[Obfuscation(Exclude = true)]
	public class PlanetNode : OrbitNode, IPlanetNode, IOrbitNode, INode, INavSphereTarget
	{
		public delegate void SoiChangedHandler(double newSoi, double oldSoi);

		public const double SunSoi = 1.5280391646329683E+308;

		private List<IPlanetNode> _childPlanets = new List<IPlanetNode>();

		private PlanetNodeData _data;

		private List<INode> _dynamicNodes = new List<INode>();

		private double _maxChildDistance;

		private bool _recalculateInverse = true;

		private double _rotationAngle;

		private Quaterniond _rotationInverse;

		private double _sphereOfInfluence;

		public IReadOnlyList<IPlanetNode> ChildPlanets => _childPlanets;

		public IReadOnlyList<INode> DynamicNodes => _dynamicNodes;

		public bool IsTerrainDataLoaded => TerrainGenerator != null;

		public override double MaxChildDistance => _maxChildDistance;

		public override string Name
		{
			get
			{
				object obj = PlanetData?.Name;
				if (obj == null)
				{
					PlanetNodeData data = _data;
					if (data == null)
					{
						return null;
					}
					obj = data.Name;
				}
				return (string)obj;
			}
		}

		IOrbitNode INavSphereTarget.OrbitNode => this;

		public IPlanetData PlanetData { get; private set; }

		public Quaterniond Rotation { get; private set; }

		public double RotationAngle
		{
			get
			{
				return _rotationAngle;
			}
			set
			{
				_rotationAngle = value % (Math.PI * 2.0);
				Rotation = Quaterniond.Euler(0.0, RotationAngle * 57.29578, 0.0);
				_recalculateInverse = true;
			}
		}

		public Quaterniond RotationInverse
		{
			get
			{
				if (_recalculateInverse)
				{
					_recalculateInverse = false;
					_rotationInverse = Quaterniond.Euler(0.0, (0.0 - RotationAngle) * 57.29578, 0.0);
				}
				return _rotationInverse;
			}
		}

		public override double SphereOfInfluence => _sphereOfInfluence;

		public double SphereOfInfluenceExitDistance => SphereOfInfluence * 1.000000004;

		public ITerrainGenerator TerrainGenerator { get; private set; }

		public double WaterWaveOffsetTime { get; set; }

		public event NodeDelegate DynamicChildAdded;

		public event SoiChangedHandler OnSoiChanged;

		public event EventHandler<PlanetNodeTerrainDataEventArgs> TerrainDataLoaded;

		public event EventHandler<PlanetNodeTerrainDataEventArgs> TerrainDataLoading;

		public event EventHandler<PlanetNodeTerrainDataEventArgs> TerrainDataUnloaded;

		public event EventHandler<PlanetNodeTerrainDataEventArgs> TerrainDataUnloading;

		public PlanetNode(PlanetNodeData data, IPlanetData planetData, IOrbit orbit)
		{
			PlanetData = planetData;
			base.Orbit = orbit;
			if (data != null)
			{
				_data = data;
				RotationAngle = data.RotationAngle;
				if (base.Orbit != null)
				{
					base.Orbit.SetTrueAnomaly(data.TrueAnomaly, planetData.OrbitData.Time);
				}
			}
			if (planetData.SphereOfInfluence.HasValue)
			{
				SetSoi(planetData.SphereOfInfluence.Value);
			}
			else
			{
				AutoCalculateSphereOfInfluence();
			}
			foreach (StructureNodeData structureNode in planetData.StructureNodes)
			{
				StructureNode node = new StructureNode(structureNode, this);
				AddChildNode(node);
			}
		}

		public void AddChildNode(INode node)
		{
			node.Parent = this;
			if (node is IGameViewObject)
			{
				_dynamicNodes.Add(node);
				this.DynamicChildAdded?.Invoke(node);
			}
			else if (node is IPlanetNode)
			{
				_childPlanets.Add(node as IPlanetNode);
			}
		}

		public void AutoCalculateSphereOfInfluence()
		{
			double soi = ((base.Orbit != null) ? (base.Orbit.SemiMajorAxis * Mathd.Pow(PlanetData.Mass / base.Orbit.PrimaryMass, 0.4)) : 1.5280391646329683E+308);
			SetSoi(soi);
		}

		public Vector3d CalculateGravityVector(Vector3d position, double mass)
		{
			double num = 6.67384E-11 * PlanetData.Mass * mass / position.sqrMagnitude;
			Vector3d vector3d = position.normalized * (0.0 - num);
			return new Vector3d(vector3d.x, vector3d.y, vector3d.z);
		}

		public Vector3d CalculateSurfaceVelocity(Vector3d surfacePoint)
		{
			double num = Mathd.Sqrt(surfacePoint.x * surfacePoint.x + surfacePoint.z * surfacePoint.z);
			if (num > 0.0)
			{
				double num2 = PlanetData.AngularVelocity * num;
				Vector3d normalized = new Vector3d(surfacePoint.z, 0.0, 0.0 - surfacePoint.x).normalized;
				return num2 * normalized;
			}
			return Vector3d.zero;
		}

		public IPlanetNode FindPlanet(string name)
		{
			if (PlanetData.Name == name)
			{
				return this;
			}
			foreach (IPlanetNode childPlanet in ChildPlanets)
			{
				IPlanetNode planetNode = childPlanet.FindPlanet(name);
				if (planetNode != null)
				{
					return planetNode;
				}
			}
			return null;
		}

		public override void FlightEnd()
		{
			UnloadTerrainData();
			foreach (IPlanetNode childPlanet in ChildPlanets)
			{
				childPlanet.FlightEnd();
			}
			foreach (INode dynamicNode in _dynamicNodes)
			{
				dynamicNode.FlightEnd();
			}
		}

		public override void FlightUpdate(double elapsedTime, double currentTime)
		{
			if (base.Orbit != null)
			{
				base.Orbit.AdvanceTime(elapsedTime, currentTime);
			}
		}

		public void GetSurfaceCoordinates(Vector3d surfacePosition, out double latitude, out double longitude)
		{
			longitude = 0.0 - Mathd.Atan2(surfacePosition.x, surfacePosition.z);
			latitude = Mathd.Atan2(surfacePosition.y, Mathd.Sqrt(surfacePosition.x * surfacePosition.x + surfacePosition.z * surfacePosition.z));
		}

		public Vector3d GetSurfacePosition(double latitude, double longitude, AltitudeType altitudeType, double altitude, float? craftHeight = null)
		{
			Vector3d vector3d = default(Vector3d);
			vector3d.x = PlanetData.Radius * Mathd.Cos(latitude) * Mathd.Sin(0.0 - longitude);
			vector3d.z = PlanetData.Radius * Mathd.Cos(latitude) * Mathd.Cos(0.0 - longitude);
			vector3d.y = PlanetData.Radius * Mathd.Sin(latitude);
			Vector3d normalized = vector3d.normalized;
			double num;
			if (altitudeType == AltitudeType.AboveSeaLevel)
			{
				num = (double)PlanetData.SeaLevel + altitude;
			}
			else
			{
				double num2 = TerrainGenerator.GetHeight(vector3d.normalized);
				if (craftHeight.HasValue)
				{
					num = num2 + altitude + (double)craftHeight.Value;
					if (altitudeType == AltitudeType.AboveGroundLevel && PlanetData.HasWater)
					{
						num = Math.Max(num, PlanetData.SeaLevel);
					}
				}
				else
				{
					if (altitudeType == AltitudeType.AboveGroundLevel && PlanetData.HasWater && num2 < (double)PlanetData.SeaLevel)
					{
						num2 = PlanetData.SeaLevel;
					}
					num = num2 + altitude;
				}
			}
			return vector3d + normalized * num;
		}

		public double GetTerrainHeight(Vector3d planetPosition)
		{
			Vector3d vector3d = PlanetVectorToSurfaceVector(planetPosition);
			return TerrainGenerator.GetHeight(vector3d.normalized);
		}

		public PlanetVertexData GetTerrainVertexData(VertexDataRequestType type, Vector3d planetPosition, Vector3d planetNormal, bool isMainThread = true)
		{
			Vector3d vector3d = PlanetVectorToSurfaceVector(planetPosition);
			Vector3d value = PlanetVectorToSurfaceVector(planetNormal);
			TerrainGeneratorCacheData terrainGeneratorCacheData = (isMainThread ? null : TerrainGenerator.GetCacheData());
			try
			{
				return TerrainGenerator.GetVertexData(type, vector3d.normalized, value, terrainGeneratorCacheData);
			}
			finally
			{
				terrainGeneratorCacheData?.ReturnToPool();
			}
		}

		public void LoadTerrainData()
		{
			if (IsTerrainDataLoaded)
			{
				return;
			}
			RaiseTerrainDataEvent(this.TerrainDataLoading);
			IPlanetTerrainData planetTerrainData = PlanetData.LoadTerrainData();
			planetTerrainData.Initialize();
			TerrainGenerator = new TerrainGenerator(planetTerrainData);
			if (Game.InPlanetStudioScene)
			{
				TerrainGenerator = new PlanetStudioTerrainGenerator((TerrainGenerator)TerrainGenerator);
			}
			foreach (INode dynamicNode in _dynamicNodes)
			{
				if (dynamicNode is StructureNode structureNode)
				{
					structureNode.OnTerrainDataLoaded();
				}
			}
			RaiseTerrainDataEvent(this.TerrainDataLoaded);
		}

		public Vector3d PlanetVectorToSurfaceVector(Vector3d planetVector)
		{
			return Utilities.RotateVectorAroundYAxis(planetVector, 0.0 - RotationAngle);
		}

		public Vector3d PlanetVectorToSurfaceVectorAtTime(Vector3d planetVector, double time)
		{
			double num = ((base.Orbit != null) ? base.Orbit.Time : FlightSceneScript.Instance.FlightState.Time);
			double num2 = RotationAngle + PlanetData.AngularVelocity * (time - num);
			num2 %= Math.PI * 2.0;
			return Utilities.RotateVectorAroundYAxis(planetVector, 0.0 - num2);
		}

		public void RemoveChildNode(INode node)
		{
			node.Parent = null;
			if (node is IGameViewObject)
			{
				_dynamicNodes.Remove(node);
				return;
			}
			if (Game.InPlanetStudioScene && node is IPlanetNode item)
			{
				_childPlanets.Remove(item);
				return;
			}
			throw new InvalidOperationException("Only nodes implementing IGameViewObject (Dynamic Nodes) can currently be removed from the hierarchy after being added.");
		}

		public void SetPlanetData(IPlanetData planetData)
		{
			PlanetData = planetData;
		}

		public void SetSoi(double newSoi)
		{
			_ = _sphereOfInfluence;
			_sphereOfInfluence = newSoi;
			if (SphereOfInfluence == 1.5280391646329683E+308)
			{
				_maxChildDistance = 1000000000000.0;
			}
			else
			{
				_maxChildDistance = SphereOfInfluence;
			}
			this.OnSoiChanged?.Invoke(_sphereOfInfluence, newSoi);
		}

		public Vector3d SurfaceVectorToPlanetVector(Vector3d surfaceVector)
		{
			return Utilities.RotateVectorAroundYAxis(surfaceVector, RotationAngle);
		}

		public override void SynchronizeData()
		{
			if (base.Orbit != null)
			{
				_data.TrueAnomaly = base.Orbit.TrueAnomaly;
			}
			_data.RotationAngle = RotationAngle;
			_data.Name = PlanetData.Name;
			_data.WaterWaveOffsetTime = WaterWaveOffsetTime;
		}

		public void UnloadTerrainData()
		{
			RaiseTerrainDataEvent(this.TerrainDataUnloading);
			TerrainGenerator?.Dispose();
			TerrainGenerator = null;
			PlanetData.UnloadTerrainData();
			foreach (INode dynamicNode in _dynamicNodes)
			{
				if (dynamicNode is StructureNode structureNode)
				{
					structureNode.OnTerrainDataUnloaded();
				}
			}
			RaiseTerrainDataEvent(this.TerrainDataUnloaded);
		}

		public void UpdateRotation(double elapsedTime)
		{
			RotationAngle += PlanetData.AngularVelocity * elapsedTime;
			for (int i = 0; i < ChildPlanets.Count; i++)
			{
				ChildPlanets[i].UpdateRotation(elapsedTime);
			}
		}

		private void RaiseTerrainDataEvent(EventHandler<PlanetNodeTerrainDataEventArgs> eventToRaise)
		{
			try
			{
				eventToRaise?.Invoke(this, new PlanetNodeTerrainDataEventArgs(this));
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
