using System.Xml.Linq;
using Assets.Dev.Philip.UiTesting.Scripts;
using Assets.Scripts.DebugScripts;
using Assets.Scripts.Flight.MapView.Automation;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits.Chain.FileIO;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.Sim;
using ModApi.Flight;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Flight.UI;
using ModApi.Ioc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class MapPlayerCraft : MapCraft
	{
		private ChainNodeIO _chainNodeIO;

		private InfoPanel _infoPanel;

		private ManeuverNodeManagerScript _maneuverNodeManager;

		private IMapView _mapView;

		private NodeNavigator _nodeNavigator;

		private OrbitInteractionScript _orbitInteractionScript;

		private bool _showNodeLines;

		public ChainNodeIO ChainNodeIO => _chainNodeIO;

		public bool IsInitialized { get; private set; }

		public ManeuverNodeManagerScript ManeuverNodeManager => _maneuverNodeManager;

		public NodeNavigator NodeNavigator => _nodeNavigator;

		public OrbitInteractionScript OrbitInteractionScript => _orbitInteractionScript;

		public override bool SupportsManeuverNodes => true;

		public override bool SupportsOrbitLinePulses => true;

		public event InitializedHandler<MapPlayerCraft> Initialized
		{
			add
			{
				if (IsInitialized)
				{
					value(this);
				}
				else
				{
					_initialized += value;
				}
			}
			remove
			{
				_initialized -= value;
			}
		}

		private event InitializedHandler<MapPlayerCraft> _initialized;

		public new static MapPlayerCraft Create(IIocContainer ioc, IMapViewContext mapViewContext, CraftNode craftNode, Camera mapCamera)
		{
			MapPlayerCraft mapPlayerCraft = MapCraft.Create<MapPlayerCraft>(ioc, mapViewContext, craftNode, mapCamera, "SpaceshipIcon");
			mapPlayerCraft.Initialize(craftNode);
			return mapPlayerCraft;
		}

		public override void AddContextMenuItem(IContextMenu contextMenu, PointerEventData eventData)
		{
			string text = ((ITargetableItem)this)?.Name ?? "Player Craft";
			contextMenu.AddContextMenuItem("Select " + text, base.ItemIcon.sprite, new Color32(0, 183, 237, byte.MaxValue), delegate
			{
				OnPointerClick(eventData);
			});
		}

		public override void OnAfterCameraPositioned(bool mapViewVisible)
		{
			base.OnAfterCameraPositioned(mapViewVisible);
			_maneuverNodeManager.OnAfterCameraPositioned();
			_nodeNavigator.Update(base.ChainNodeManager.FirstIncompleteManeuverNode, base.ChainNodeManager);
			RegisterInfoPanel();
		}

		public override void OnBeforeCameraPositioned(bool mapViewVisible)
		{
			base.OnBeforeCameraPositioned(mapViewVisible);
			if (mapViewVisible)
			{
				_maneuverNodeManager.OnBeforeCameraPositioned();
				_orbitInteractionScript.OnBeforeCameraPositioned();
				UpdateDebugUI();
			}
		}

		public void OnManeuverNodeLocked(ManeuverNodeScript maneuverNodeScript)
		{
			if (maneuverNodeScript == base.ChainNodeManager.FirstManeuverNode)
			{
				_nodeNavigator.OnNextManeuverNodeLocked(maneuverNodeScript);
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
		}

		public override void OnSwitchingToNewType()
		{
			base.OnSwitchingToNewType();
			SynchronizeManeuverNodeData();
		}

		public void SynchronizeManeuverNodeData()
		{
			((FlightSceneScript)Game.Instance.FlightScene).FlightState.MapView.UpdateManeuverNodeData(maneuverNodeData: ChainNodeIO.GenerateXml(), craftNode: base.OrbitInfo.OrbitNode as CraftNode);
		}

		protected override string GetClosestEncounterIcon()
		{
			return "SpaceshipIcon";
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			_maneuverNodeManager?.Dispose();
			_nodeNavigator?.Dispose();
			this._initialized = null;
			if (_infoPanel != null)
			{
				Object.Destroy(_infoPanel.gameObject);
			}
			Object.Destroy(_orbitInteractionScript.gameObject);
		}

		protected override bool ShouldDrawFullOrbit()
		{
			if (base.ShouldDrawFullOrbit())
			{
				return true;
			}
			ManeuverNodeScript firstIncompleteManeuverNode = base.ChainNodeManager.FirstIncompleteManeuverNode;
			if ((object)firstIncompleteManeuverNode != null && firstIncompleteManeuverNode.Locked)
			{
				return true;
			}
			if ((firstIncompleteManeuverNode?.ReferenceOrbitPeriod ?? 0) > 0)
			{
				return true;
			}
			return false;
		}

		protected override void Start()
		{
			base.Start();
			this._initialized?.Invoke(this);
			this._initialized = null;
			IsInitialized = true;
			RestoreManeuverNodes();
		}

		private void Initialize(CraftNode craftNode)
		{
			IIocContainer ioc = base.Ioc;
			_mapView = ioc.Resolve<IMapView>(base.MapViewContext);
			_orbitInteractionScript = OrbitInteractionScript.Create(base.Ioc, base.CraftContext);
			_maneuverNodeManager = ManeuverNodeManagerScript.Create(base.CraftContext, this);
			_nodeNavigator = new NodeNavigator(base.Ioc, base.CraftContext, FlightSceneScript.Instance.FlightSceneUI.NavSphere, FlightSceneScript.Instance.TimeManager);
			_chainNodeIO = new ChainNodeIO(base.Ioc, this, base.ChainNodeManager, _maneuverNodeManager);
		}

		private void RegisterInfoPanel()
		{
			if (_mapView.Visible && _infoPanel == null)
			{
				_infoPanel = InfoPanel.Create<InfoPanel>("Craft Options", delegate
				{
					Debug.Log("Craft header clicked");
				});
				_infoPanel.AddToggleButton("dsp node lines", initialValue: false, delegate(bool x)
				{
					_showNodeLines = x;
				}, rebuildUi: false);
				_infoPanel.RebuildUi();
			}
		}

		private void RestoreManeuverNodes()
		{
			XElement maneuverNodesElement = ((FlightSceneScript)Game.Instance.FlightScene).FlightState.MapView.GetManeuverNodesElement(base.OrbitInfo.OrbitNode as CraftNode);
			if (maneuverNodesElement != null)
			{
				ChainNodeIO.RestoreNodeChain(maneuverNodesElement);
			}
		}

		private void UpdateDebugUI()
		{
			if (_showNodeLines)
			{
				IPlanetNode parent = base.OrbitInfo.OrbitNode.Parent;
				Vector3 origin = (Vector3)base.CoordinateConverter.ConvertSolarToMapView(parent.SolarPosition);
				Vector3 direction = (Vector3)base.OrbitInfo.OrbitNode.Orbit.NodeLineVector;
				DebugGizmos.DrawRay("NodeLine", origin, direction, 50f, Color.yellow, base.gameObject.layer);
				direction = (Vector3)base.OrbitInfo.OrbitNode.Orbit.EccentricityVector;
				DebugGizmos.DrawRay("EccentricityVec", origin, direction, 50f, new Color(0.1f, 0.2f, 0.8f), base.gameObject.layer);
				direction = (Vector3)base.OrbitInfo.OrbitNode.Orbit.AngularMomentum;
				DebugGizmos.DrawRay("AngularMom", origin, direction, (float)((double)direction.magnitude * base.CoordinateConverter.MapScale * 0.01), new Color(0.1f, 0.8f, 0.2f), base.gameObject.layer);
				direction = (Vector3)base.OrbitInfo.OrbitNode.Orbit.OrbitalPlaneRight;
				DebugGizmos.DrawRay("Right", origin, direction, 50f, new Color(0.8f, 0.2f, 0.1f), base.gameObject.layer);
			}
		}
	}
}
