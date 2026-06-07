using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Career.Contracts;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.State;
using ModApi;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.GameLoop;
using ModApi.Levels;
using ModApi.Planet;
using ModApi.State;
using UnityEngine;

namespace Assets.Scripts.Career
{
	public class FlightContext : IFlightContext
	{
		public const string ElementName = "Flight";

		private CareerState _career;

		private ICraftNode _craft;

		private bool _craftIsGrounded;

		private bool _craftIsHyperbolic;

		private List<int> _dockedCraftIDs = new List<int>();

		private FlightSceneScript _flightScene;

		private FuelMonitor _fuelMonitor;

		private bool _lastInWater;

		private Vector3d? _lastPosition;

		private Vector3d _lastSurfacePosition;

		private List<int> _launchedCraftIDs = new List<int>();

		private IEnumerable<LaunchLocation> _launchLocations;

		private Dictionary<string, LocationNode> _sharedLocationNodes = new Dictionary<string, LocationNode>();

		public double Acceleration => FlightData.AccelerationMagnitude;

		public double AltitudeAboveTerrain => FlightData.AltitudeAboveTerrain;

		public double AltitudeAGL => FlightData.AltitudeAboveGroundLevel;

		public double AltitudeASL => FlightData.AltitudeAboveSeaLevel;

		public double Apoapsis => FlightData.Orbit.ApoapsisAltitude;

		public double ApoapsisTime => FlightData.Orbit.ApoapsisTime;

		public double AtmosphereDensity => FlightData.AtmosphereSample.AirDensity;

		public double AtmosphereHeight => FlightData.AtmosphereSample.AtmosphereHeight;

		public double AtmosphereTemperature => FlightData.AtmosphereSample.Temperature;

		public PositionBiomeData CraftBiomeData => _flightScene.CraftBiomeData;

		public bool CraftIsOrbiting { get; private set; }

		public ICraftNode CraftNode => _craft;

		public double DeltaTime => _flightScene.TimeManager.DeltaTime;

		public double DeltaVStage => FlightData.Performance.DeltaVStage;

		public double DragAcceleration => CraftNode.CraftScript?.DragAcceleration.magnitude ?? 0f;

		public double Eccentricity => FlightData.Orbit.Eccentricity;

		public FlightState FlightState => _flightScene.FlightState;

		public IFlightTutorialPanel FlightTutorialPanel => _flightScene.FlightSceneUI.FlightTutorialPanel;

		public double FrameDistance { get; private set; }

		public double FrameDistanceSurface { get; private set; }

		public double FrameFuelUsed => _fuelMonitor.FrameFuelUsedKG;

		public double Fuel => FlightData.Performance.FuelAllStagesPercentage;

		public double FuelBattery => FlightData.RemainingBattery;

		public double FuelMono => FlightData.RemainingMonopropellant;

		public double FuelStage => FlightData.RemainingFuelInStage;

		public double Gravity => FlightData.GravityMagnitude;

		public bool Grounded => FlightData.Grounded;

		public double Inclination => FlightData.Orbit.Inclination * 57.29578;

		public bool InWater => FlightData.InWater;

		public bool IsDestroyed => CraftNode.IsDestroyed;

		public bool IsDrood { get; private set; }

		public bool IsNewLaunch { get; }

		public double Isp => FlightData.Performance.CurrentIsp;

		public double MachNumber => FlightData.MachNumber;

		public double Mass => FlightData.CurrentMassUnscaled;

		public float MaxActiveEngineThrust => FlightData.MaxActiveEngineThrustUnscaled;

		public double Money => _career.Money;

		public double MoneyReceived => _career.MoneyReceived;

		public double MoneyRecovered => _career.MoneyRecovered;

		public double MoneySpent => _career.MoneySpent;

		public int NumAstronauts => CraftNode.CraftScript?.NumAstronauts ?? 0;

		public int NumCompletedContracts { get; private set; }

		public int NumDockedCrafts => _dockedCraftIDs.Count;

		public int NumDroodsEnteredOrbit { get; private set; }

		public int NumExplosions { get; private set; }

		public int NumLaunches => _launchedCraftIDs.Count;

		public int NumOrbits { get; private set; }

		public int NumPlanetContacts => _career.Exploration.ActiveNode.NumContacts;

		public int NumPlanetFlyBys => _career.Exploration.ActiveNode.NumFlyBys;

		public int NumPlanetOrbits => _career.Exploration.ActiveNode.NumOrbits;

		public string Parent => FlightData.Orbit.Parent.Name;

		public double ParentRotationalPeriod
		{
			get
			{
				if (Planet.PlanetData.AngularVelocity != 0.0)
				{
					return Math.PI * 2.0 / Math.Abs(Planet.PlanetData.AngularVelocity);
				}
				return 0.0;
			}
		}

		public double Periapsis => FlightData.Orbit.PeriapsisAltitude;

		public double PeriapsisTime => FlightData.Orbit.PeriapsisTime;

		public double Period => FlightData.Orbit.Period;

		public IPlanetNode Planet => _flightScene.CraftNode.Parent;

		public double PlanetRotation => Planet.RotationAngle * 57.29578;

		public Vector3d Position => CraftNode.Position;

		public Vector3d SurfacePosition => _lastSurfacePosition;

		public double SurfaceVelocity => FlightData.SurfaceVelocityMagnitude;

		public double SurfaceVelocityLateral => FlightData.LateralSurfaceVelocity;

		public double SurfaceVelocityVertical => FlightData.VerticalSurfaceVelocity;

		public float Thrust => FlightData.CurrentEngineThrustUnscaled;

		public double Time => _flightScene.FlightState.Time;

		public double TimeEnginesInactive { get; private set; }

		public double TimeGrounded { get; private set; }

		public double Velocity => FlightData.VelocityMagnitude;

		private ICraftFlightData FlightData => _flightScene.CraftNode.CraftScript.FlightData;

		public event SimpleNotificationDelegate CraftChanged;

		public event SimpleNotificationDelegate CraftChangedSoi;

		public event CraftEventDelegate CraftContact;

		public event SimpleNotificationDelegate CraftDocked;

		public event CraftEventDelegate CraftHyperbolicOrbit;

		public event CraftEventDelegate CraftOrbit;

		public event SimpleNotificationDelegate CraftStructureChanged;

		public FlightContext(FlightSceneScript flightScene, CareerState career, XElement statusXml, bool isNewLaunch, IEnumerable<LaunchLocation> launchLocations)
		{
			_career = career;
			_flightScene = flightScene;
			IsNewLaunch = isNewLaunch;
			flightScene.ExplosionCreated += OnExplosionCreated;
			flightScene.ActiveCommandPodChanged += OnActiveCommandPodChanged;
			flightScene.CraftChanged += OnCraftChanged;
			flightScene.CraftStructureChanged += OnCraftStructureChanged;
			flightScene.PlayerChangedSoi += OnPlayerChangedSoi;
			if (statusXml != null)
			{
				NumExplosions = statusXml.GetIntAttribute("explosions");
				NumOrbits = statusXml.GetIntAttribute("orbits");
				NumDroodsEnteredOrbit = statusXml.GetIntAttribute("numDroodsEnteredOrbit");
				_launchedCraftIDs = Utilities.GetIntListAttribute(statusXml, "launchedCraftIDs");
				_dockedCraftIDs = Utilities.GetIntListAttribute(statusXml, "dockedCraftIDs");
			}
			if (isNewLaunch)
			{
				_launchedCraftIDs.Add(flightScene.CraftNode.NodeId);
			}
			_launchLocations = launchLocations;
			SetCraft(flightScene.CraftNode);
			NumCompletedContracts = career.Contracts.Completed.Count;
			_career.Contracts.ContractCompleted += OnContractCompleted;
		}

		public Vector3d CoordsToPci(double lat, double lon, double agl)
		{
			Vector3d surfacePosition = Planet.GetSurfacePosition(lat * 0.01745329, lon * 0.01745329, AltitudeType.AboveGroundLevel, agl);
			return Planet.SurfaceVectorToPlanetVector(surfacePosition);
		}

		public int CountCraftParts(string partTypeId, string payloadTrackingId, bool activated = false)
		{
			int num = 0;
			foreach (PartData part in CraftNode.CraftScript.Data.Assembly.Parts)
			{
				if (activated && !part.Activated)
				{
					continue;
				}
				if (!string.IsNullOrEmpty(payloadTrackingId))
				{
					if (part.Payload?.PayloadTrackingId == payloadTrackingId && !part.PartScript.Disconnected)
					{
						num++;
					}
				}
				else if (!string.IsNullOrEmpty(partTypeId) && part.PartType.Id == partTypeId && !part.PartScript.Disconnected)
				{
					num++;
				}
			}
			return num;
		}

		public LocationNode CreateLocationNode(ContractLocation contractLocation, string mapViewIcon)
		{
			LocationNode locationNode = null;
			if (contractLocation.Shared && !string.IsNullOrWhiteSpace(contractLocation.Id) && _sharedLocationNodes.ContainsKey(contractLocation.Id))
			{
				locationNode = _sharedLocationNodes[contractLocation.Id];
			}
			else
			{
				locationNode = new LocationNode(GetPlanet(contractLocation.PlanetName), contractLocation, mapViewIcon);
				locationNode.StructureTypeName = "Point of Interest";
				if (!string.IsNullOrWhiteSpace(contractLocation.Id))
				{
					_sharedLocationNodes[contractLocation.Id] = locationNode;
				}
			}
			return locationNode;
		}

		public XElement GenerateStatusXml()
		{
			XElement xElement = new XElement("Flight");
			xElement.SetAttributeValue("explosions", NumExplosions);
			xElement.SetAttributeValue("orbits", NumOrbits);
			xElement.SetAttributeValue("numDroodsEnteredOrbit", NumDroodsEnteredOrbit);
			Utilities.SetIntListAttribute(xElement, "launchedCraftIDs", _launchedCraftIDs);
			Utilities.SetIntListAttribute(xElement, "dockedCraftIDs", _dockedCraftIDs);
			return xElement;
		}

		public IPlanetNode GetPlanet(string name)
		{
			return _flightScene.FlightState.RootNode.FindPlanet(name);
		}

		public bool IsLaunchedCraft(int craftNodeId)
		{
			return _launchedCraftIDs.Contains(craftNodeId);
		}

		public void OnFlightEnd()
		{
			_career.Contracts.ContractCompleted -= OnContractCompleted;
		}

		public void OnFlightUpdate(in FlightFrameData frame)
		{
			ICraftNode craftNode = _flightScene.CraftNode;
			if (craftNode == null)
			{
				return;
			}
			double apoapsisDistance = craftNode.Orbit.ApoapsisDistance;
			bool flag = Periapsis > Mathd.Max(AtmosphereHeight, Planet.PlanetData.MaxEstimatedTerrainElevation) && Eccentricity < 1.0 && apoapsisDistance < Planet.SphereOfInfluence;
			if (CraftIsOrbiting != flag)
			{
				CraftIsOrbiting = flag;
				if (flag && _career.Exploration.ActiveNode != null)
				{
					foreach (int initialCraftNodeId in craftNode.InitialCraftNodeIds)
					{
						if (!_career.Exploration.ActiveNode.HasCraftOrbited(initialCraftNodeId))
						{
							OnCraftFirstOrbit(craftNode);
						}
					}
				}
			}
			bool flag2 = Eccentricity > 1.0 || apoapsisDistance > Planet.SphereOfInfluence;
			if (_craftIsHyperbolic != flag2)
			{
				_craftIsHyperbolic = flag2;
				if (flag2 && _career.Exploration.ActiveNode != null)
				{
					foreach (int initialCraftNodeId2 in craftNode.InitialCraftNodeIds)
					{
						if (!_career.Exploration.ActiveNode.HasCraftFlyBy(initialCraftNodeId2))
						{
							OnCraftFirstHyperbolicOrbit(craftNode);
						}
					}
				}
			}
			bool grounded = Grounded;
			if (_craftIsGrounded != grounded)
			{
				_craftIsGrounded = grounded;
				if (grounded && _career.Exploration.ActiveNode != null)
				{
					foreach (int initialCraftNodeId3 in craftNode.InitialCraftNodeIds)
					{
						if (!_career.Exploration.ActiveNode.HasCraftContacted(initialCraftNodeId3))
						{
							OnCraftFirstContact(craftNode);
						}
					}
				}
			}
			Vector3d vector3d = Planet.PlanetVectorToSurfaceVector(craftNode.Position);
			if (_lastPosition.HasValue)
			{
				FrameDistance += (craftNode.Position - _lastPosition.Value).magnitude;
				FrameDistanceSurface += (vector3d - _lastSurfacePosition).magnitude;
			}
			_lastPosition = craftNode.Position;
			_lastSurfacePosition = vector3d;
			if (FlightData.CurrentEngineThrust > 0f)
			{
				TimeEnginesInactive = 0.0;
			}
			else
			{
				TimeEnginesInactive += frame.DeltaTime;
			}
			if (InWater ^ _lastInWater)
			{
				TimeGrounded = 0.0;
				_lastInWater = InWater;
			}
			if (FlightData.Grounded)
			{
				if (TimeGrounded < 0.0)
				{
					TimeGrounded = 0.0;
				}
				TimeGrounded += frame.DeltaTime;
			}
			else
			{
				if (TimeGrounded > 0.0)
				{
					TimeGrounded = 0.0;
				}
				TimeGrounded -= frame.DeltaTime;
			}
		}

		public void OnFlightUpdateComplete()
		{
			FrameDistance = 0.0;
			FrameDistanceSurface = 0.0;
		}

		public Vector3d PciToCoords(Vector3d position)
		{
			IPlanetNode planet = Planet;
			Vector3d surfacePosition = planet.PlanetVectorToSurfaceVector(position);
			planet.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
			double num = planet.GetTerrainHeight(position);
			if (planet.PlanetData.HasWater && num < (double)planet.PlanetData.SeaLevel)
			{
				num = planet.PlanetData.SeaLevel;
			}
			return new Vector3d(latitude * 57.29578, longitude * 57.29578, position.magnitude - (planet.PlanetData.Radius + num));
		}

		public Vector3d PciToCoordsASL(Vector3d position)
		{
			IPlanetNode planet = Planet;
			Vector3d surfacePosition = planet.PlanetVectorToSurfaceVector(position);
			planet.GetSurfaceCoordinates(surfacePosition, out var latitude, out var longitude);
			return new Vector3d(latitude * 57.29578, longitude * 57.29578, position.magnitude - planet.PlanetData.Radius);
		}

		public void ShowMessage(string message)
		{
			_flightScene.FlightSceneUI.ShowMessage(message);
		}

		public void ShowRewardMessage(string text, long money, int techPoints, RewardMessageSoundType sound)
		{
			_flightScene.FlightSceneUI.ShowRewardMessage(text, money, techPoints, sound);
		}

		public CraftNode SpawnCraft(string craftNodeName, CraftData craftData, LaunchLocation launchLocation, XElement pendingXml)
		{
			return _flightScene.SpawnCraft(craftNodeName, craftData, launchLocation, pendingXml);
		}

		private static int GetNumDroodsInCraftNode(ICraftNode node)
		{
			int num = 0;
			foreach (PartData part in node.CraftScript.Data.Assembly.Parts)
			{
				if (part.GetModifier<EvaData>() != null && !part.IsSpawned)
				{
					num++;
				}
			}
			return num;
		}

		private void OnActiveCommandPodChanged(ICraftNode craftNode)
		{
			SetCraft(craftNode);
			this.CraftChanged?.Invoke();
		}

		private void OnContractCompleted(Contract contract)
		{
			if (contract.IsComplete)
			{
				NumCompletedContracts++;
			}
		}

		private void OnCraftChanged(ICraftNode craftNode)
		{
			SetCraft(craftNode);
		}

		private void OnCraftDockComplete(string playerCraftName, int playerNodeId, string otherCraftName, int otherNodeId)
		{
			if (_launchedCraftIDs.Contains(playerNodeId) && !_dockedCraftIDs.Contains(playerNodeId))
			{
				_dockedCraftIDs.Add(playerNodeId);
			}
			if (_launchedCraftIDs.Contains(otherNodeId) && !_dockedCraftIDs.Contains(otherNodeId))
			{
				_dockedCraftIDs.Add(otherNodeId);
			}
			if (playerNodeId != otherNodeId)
			{
				this.CraftDocked?.Invoke();
			}
		}

		private void OnCraftFirstContact(ICraftNode node)
		{
			int numDroodsInCraftNode = GetNumDroodsInCraftNode(node);
			this.CraftContact?.Invoke(node, numDroodsInCraftNode);
		}

		private void OnCraftFirstHyperbolicOrbit(ICraftNode node)
		{
			int numDroodsInCraftNode = GetNumDroodsInCraftNode(node);
			this.CraftHyperbolicOrbit?.Invoke(node, numDroodsInCraftNode);
		}

		private void OnCraftFirstOrbit(ICraftNode node)
		{
			NumOrbits++;
			int numDroodsInCraftNode = GetNumDroodsInCraftNode(node);
			NumDroodsEnteredOrbit += numDroodsInCraftNode;
			this.CraftOrbit?.Invoke(node, numDroodsInCraftNode);
		}

		private void OnCraftStructureChanged()
		{
			this.CraftStructureChanged?.Invoke();
		}

		private void OnExplosionCreated(object sender, EventArgs e)
		{
			NumExplosions++;
		}

		private void OnPlayerChangedSoi(ICraftNode playerCraftNode, IPlanetNode newParent)
		{
			_lastPosition = null;
			CraftIsOrbiting = false;
			_craftIsGrounded = false;
			_craftIsHyperbolic = false;
			this.CraftChangedSoi?.Invoke();
		}

		private void SetCraft(ICraftNode craftNode)
		{
			_lastPosition = null;
			if (_craft != null)
			{
				_craft.CraftScript.DockComplete -= OnCraftDockComplete;
			}
			_craft = craftNode;
			if (_craft != null)
			{
				IsDrood = _craft.CraftScript.RootPart?.CommandPod?.IsEva == true;
				_craft.CraftScript.DockComplete += OnCraftDockComplete;
				_fuelMonitor = _craft.CraftScript.GetOrCreateFuelMonitor();
			}
		}
	}
}
