using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Assets.Packages.SocialPlatforms.Achievements;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Sim;
using ModApi.CelestialData;
using ModApi.Craft;
using ModApi.Flight;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Mods;
using ModApi.Planet;
using ModApi.Scripts.State;
using ModApi.State;
using ModApi.State.MapView;
using UnityEngine;

namespace Assets.Scripts.State
{
	public class FlightState : IFlightState, IGameTime
	{
		public delegate void CraftNodeDelegate(CraftNode craftNode);

		private static bool _achievementUnlockedActiveCraftCount;

		private List<CraftNode> _craftNodes;

		private FlightStateData _data;

		private List<CraftNode> _deletedCraftsPending = new List<CraftNode>();

		private IGameView _gameView;

		private SolarSystemDataScript _solarSystemData;

		private double _timeBeforeWarpEntered;

		public IReadOnlyList<CraftNode> CraftNodes => _craftNodes;

		IReadOnlyList<ICraftNode> IFlightState.CraftNodes => _craftNodes;

		public RequiredModsData FlightStateRequiredMods => _data.FlightStateRequiredMods;

		public FlightStateLoadContext LoadContext { get; }

		public MapViewData MapView => _data.MapView;

		public string Path => _data.Path;

		public PlanetarySystemFileData PlanetarySystem => _data.PlanetarySystem;

		public int PlayerNodeId
		{
			get
			{
				return _data.PlayerNodeId;
			}
			set
			{
				_data.PlayerNodeId = value;
			}
		}

		public IPlanetNode RootNode { get; private set; }

		public ISolarSystemData SolarSystemData => _solarSystemData;

		public double Time
		{
			get
			{
				return _data.Time;
			}
			set
			{
				_data.Time = value;
				if (!Game.Instance.FlightScene.TimeManager.CurrentMode.WarpMode)
				{
					WaveTime = _gameView.Planet.PlanetData.GetWaveTime(value - _gameView.Planet.PlanetNode.WaterWaveOffsetTime);
				}
			}
		}

		public double TotalFlightTimeInRealtimeSeconds
		{
			get
			{
				return _data.TotalFlightTimeInRealtimeSeconds;
			}
			set
			{
				_data.TotalFlightTimeInRealtimeSeconds = value;
			}
		}

		public double WaveTime { get; private set; }

		public event CraftNodeDelegate CraftNodeAdded;

		public event CraftNodeDelegate CraftNodeRemoved;

		public FlightState(IFlightStateData flightStateData, FlightStateLoadContext loadContext = FlightStateLoadContext.Default)
			: this((FlightStateData)flightStateData, loadContext)
		{
			Game.Instance.FlightScene.IocContainer.Register((IGameTime)this);
			_gameView = Game.Instance.FlightScene.ViewManager.GameView;
		}

		public FlightState(FlightStateData flightStateData, FlightStateLoadContext loadContext = FlightStateLoadContext.Default)
		{
			LoadContext = loadContext;
			_craftNodes = new List<CraftNode>();
			_data = flightStateData;
			if (flightStateData.PlanetarySystem == null)
			{
				throw new Exception("Unable to find the planetary system specified in the flight state.");
			}
			CelestialFile file = Game.Instance.CelestialDatabase.GetFile(flightStateData.PlanetarySystemFileReference);
			_solarSystemData = SolarSystemDataScript.CreateFromFile(file, createTerrainData: false, applyScaleAndOverrides: true);
			bool includeLockedPlanets = LoadContext != FlightStateLoadContext.Flight;
			List<PlanetNode> list = LoadPlanetNodes(flightStateData, _solarSystemData, includeLockedPlanets);
			RootNode = list[0];
			List<(CraftNode, ICraftNodeData)> list2 = new List<(CraftNode, ICraftNodeData)>(flightStateData.CraftNodes.Count);
			foreach (ICraftNodeData item in new List<ICraftNodeData>(flightStateData.CraftNodes))
			{
				if (item.OrbitData == null || CraftNode.IsOrbitSuitableToRestore(item.OrbitData))
				{
					if (item.OrbitData != null && item.OrbitData.Time < 0.0)
					{
						item.OrbitData.Time = flightStateData.Time;
					}
					IPlanetNode planetNode = RootNode.FindPlanet(item.ParentName);
					if (planetNode != null)
					{
						CraftNode craftNode = new CraftNode(item, this, planetNode.PlanetData.Mass);
						_craftNodes.Add(craftNode);
						planetNode.AddChildNode(craftNode);
						list2.Add((craftNode, item));
					}
					else
					{
						Debug.LogError($"Craft '{item.Name}' (ID={item.NodeId}) was not loaded because its parent planet '{item.ParentName}' could not be found.");
					}
				}
				else
				{
					Debug.LogWarning(item.Name + " will not be restored b/c its orbit is too extreme to load (eccentricity, position, velocity, etc.)");
				}
			}
			if (flightStateData.ModelType == ModelType.Static)
			{
				flightStateData.SwitchModelType(ModelType.Dynamic, list2);
			}
			InitializeNodeHierarchy(RootNode);
			if (Game.Instance?.FlightScene != null)
			{
				Game.Instance.FlightScene.Initialized += OnFlightSceneInitialized;
			}
		}

		public static IPlanetNode GetChildPlanet(IPlanetNode parent, string name)
		{
			foreach (IPlanetNode childPlanet2 in parent.ChildPlanets)
			{
				if (childPlanet2.Name == name)
				{
					return childPlanet2;
				}
				IPlanetNode childPlanet = GetChildPlanet(childPlanet2, name);
				if (childPlanet != null)
				{
					return childPlanet;
				}
			}
			return null;
		}

		public static List<PlanetNode> LoadPlanetNodes(FlightStateData flightStateData, SolarSystemDataScript solarSystemData, bool includeLockedPlanets)
		{
			List<PlanetNode> list = new List<PlanetNode>();
			foreach (PlanetDataScript planet in solarSystemData.Planets)
			{
				if (!includeLockedPlanets && !Game.Instance.InAppPurchases.Features.Planet(planet.name, Game.Instance.GameState.Mode).Unlocked)
				{
					flightStateData.RemovePlanetNode(planet.name);
					continue;
				}
				Orbit orbit = null;
				if (planet.Parent != null)
				{
					if (planet.OrbitData.Time < 0.0)
					{
						planet.OrbitData.Time = flightStateData.Time;
					}
					orbit = new Orbit(planet.OrbitData.Time, planet.OrbitData.Eccentricity, planet.OrbitData.SemiMajorAxis, planet.OrbitData.ArgumentOfPeriapsis, planet.OrbitData.TrueAnomaly, planet.OrbitData.Inclination, planet.OrbitData.RightAscensionOfAscendingNode, planet.Parent.Mass, planet.OrbitData.Prograde);
				}
				PlanetNodeData planetNodeData = flightStateData.GetPlanetNodeData(planet.Name);
				if (planetNodeData == null)
				{
					orbit?.AdvanceTime(flightStateData.Time, flightStateData.Time);
					planetNodeData = new PlanetNodeData();
					planetNodeData.Name = planet.Name;
					planetNodeData.RotationAngle = planet.PlanetarySystemDefinedData.InitialRotation + planet.AngularVelocity * flightStateData.Time;
					planetNodeData.TrueAnomaly = orbit?.TrueAnomaly ?? 0.0;
					flightStateData.AddPlanetNodeData(planetNodeData);
				}
				list.Add(new PlanetNode(planetNodeData, planet, orbit));
			}
			foreach (PlanetNode item in list)
			{
				foreach (PlanetNode item2 in list)
				{
					if (item2.PlanetData.Parent == item.PlanetData)
					{
						item.AddChildNode(item2);
					}
				}
			}
			return list;
		}

		public void AddCraft(CraftNode craftNode, CraftNode originalNode)
		{
			int nextNodeId = _data.GetNextNodeId();
			if (string.IsNullOrEmpty(craftNode.Name))
			{
				string text = craftNode.CraftScript?.RootPart.Data.PreferredNodeName;
				if (!string.IsNullOrEmpty(text))
				{
					craftNode.Name = text;
				}
				else if (originalNode != null)
				{
					craftNode.Name = $"{originalNode.Name}-{nextNodeId}";
				}
				else
				{
					craftNode.Name = "Craft-" + nextNodeId;
				}
			}
			craftNode.NodeId = nextNodeId;
			_data.AddCraftNode(new CraftNodeDataDynamic(craftNode));
			_craftNodes.Add(craftNode);
			this.CraftNodeAdded?.Invoke(craftNode);
			if (!_achievementUnlockedActiveCraftCount && _craftNodes.Count((CraftNode x) => x.HasCommandPod && x.AllowPlayerControl && !x.IsDestroyed) >= 20)
			{
				_achievementUnlockedActiveCraftCount = true;
				Game.Instance.AchievementManager.UnlockAchievement(AchievementKey.ActiveCraftCount);
			}
		}

		public bool CheckCraftXmlExists(int nodeId)
		{
			return _data.CheckCraftXmlExists(nodeId);
		}

		public void Destroy()
		{
			UnityEngine.Object.Destroy(_solarSystemData.gameObject);
			_craftNodes.Clear();
			RootNode = null;
			if (Game.Instance?.FlightScene != null)
			{
				Game.Instance.FlightScene.ActiveCommandPodChanged -= OnPlayerCraftActiveCommandPodChanged;
				Game.Instance.FlightScene.TimeManager.TimeMultiplierModeChanged -= OnTimeMultiplierModeChanged;
				Game.Instance.FlightScene.Initialized -= OnFlightSceneInitialized;
			}
		}

		public XDocument GenerateXml()
		{
			XDocument result = null;
			if (!_data.PreventSave)
			{
				SynchronizeData();
				result = _data.GenerateXml();
			}
			return result;
		}

		public CraftNode GetCraftNode(int nodeId)
		{
			return GetCraftNode((CraftNode node) => node.NodeId == nodeId);
		}

		public CraftNode GetCraftNode(Func<CraftNode, bool> condition)
		{
			return GetCraftNode(condition, RootNode);
		}

		public XElement LoadCraftXml(int nodeId)
		{
			return _data.LoadCraftXml(nodeId);
		}

		public void OnInitialLaunch(CraftScript craftScript)
		{
		}

		public void ProcessDestroyedCraftNodes()
		{
			for (int i = 0; i < CraftNodes.Count; i++)
			{
				CraftNode craftNode = CraftNodes[i];
				if (craftNode.IsDestroyed)
				{
					_deletedCraftsPending.Add(craftNode);
				}
			}
			foreach (CraftNode item in _deletedCraftsPending)
			{
				if (!item.IsLoadedInGameView)
				{
					item.Parent.RemoveChildNode(item);
				}
				_craftNodes.Remove(item);
				_data.RemoveCraftNode(_data.GetCraftNodeData(item.NodeId));
				this.CraftNodeRemoved?.Invoke(item);
			}
			_deletedCraftsPending.Clear();
		}

		public void ProcessNodeTree(Action<INode> nodeAction)
		{
			ProcessNodeTree(RootNode, nodeAction);
		}

		public void Save(bool overridePreventSave = false)
		{
			if (!_data.PreventSave || overridePreventSave)
			{
				SynchronizeData();
				_data.Save();
			}
		}

		public void SaveCraftXml(int nodeId, XElement craftXml)
		{
			_data.SaveCraftXml(nodeId, craftXml);
		}

		private CraftNode GetCraftNode(Func<CraftNode, bool> condition, IPlanetNode planetNode)
		{
			foreach (INode dynamicNode in planetNode.DynamicNodes)
			{
				if (dynamicNode is CraftNode craftNode && condition(craftNode))
				{
					return craftNode;
				}
			}
			foreach (IPlanetNode childPlanet in planetNode.ChildPlanets)
			{
				CraftNode craftNode2 = GetCraftNode(condition, childPlanet);
				if (craftNode2 != null)
				{
					return craftNode2;
				}
			}
			return null;
		}

		private void InitializeNodeHierarchy(IPlanetNode node)
		{
			node.Initialize();
			foreach (INode dynamicNode in node.DynamicNodes)
			{
				dynamicNode.Initialize();
			}
			foreach (IPlanetNode childPlanet in node.ChildPlanets)
			{
				InitializeNodeHierarchy(childPlanet);
			}
		}

		private void OnFlightSceneInitialized(IFlightScene initializedObject)
		{
			Game.Instance.FlightScene.ActiveCommandPodChanged += OnPlayerCraftActiveCommandPodChanged;
			Game.Instance.FlightScene.TimeManager.TimeMultiplierModeChanged += OnTimeMultiplierModeChanged;
		}

		private void OnPlayerCraftActiveCommandPodChanged(ICraftNode craftNode)
		{
			PlayerNodeId = craftNode.NodeId;
		}

		private void OnTimeMultiplierModeChanged(TimeMultiplierModeChangedEvent e)
		{
			if (e.EnteredWarpMode)
			{
				_timeBeforeWarpEntered = Time;
			}
			else if (e.ExitedWarpMode)
			{
				_gameView.Planet.PlanetNode.WaterWaveOffsetTime += Time - _timeBeforeWarpEntered;
			}
		}

		private void ProcessNodeTree(IPlanetNode node, Action<INode> nodeAction)
		{
			nodeAction(node);
			IReadOnlyList<INode> dynamicNodes = node.DynamicNodes;
			for (int i = 0; i < dynamicNodes.Count; i++)
			{
				nodeAction(dynamicNodes[i]);
			}
			IReadOnlyList<IPlanetNode> childPlanets = node.ChildPlanets;
			for (int j = 0; j < childPlanets.Count; j++)
			{
				ProcessNodeTree(childPlanets[j], nodeAction);
			}
		}

		private void SynchronizeData()
		{
			ProcessNodeTree(delegate(INode n)
			{
				n.SynchronizeData();
			});
		}
	}
}
