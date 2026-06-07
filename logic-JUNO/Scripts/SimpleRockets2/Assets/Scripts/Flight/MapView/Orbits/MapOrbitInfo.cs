using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items;
using Assets.Scripts.Flight.MapView.Orbits.Chain;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.Sim;
using ModApi.Common.Events;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.Orbits
{
	public class MapOrbitInfo
	{
		public delegate MapOrbitInfo OrbitInfoCreator(IOrbitNode orbitNode, Camera mapCamera, MapOrbitLine orbitLine, OrbitChainNodeScript chainNodeScript);

		private IChainNodeList _chainNodeList;

		private IChainableOrbit _chainNodeScript;

		private CraftNode _craftnode;

		private IDrawModeProvider _drawModeProvider;

		private IIocContainer _ioc;

		private ManeuverNodeScript _maneuverNodeScript;

		private MapItem _mapItem;

		private IMapViewContext _mapViewContext;

		private MapOrbitLine _orbitLine;

		private IOrbitPoint _planetIntersectionPointCache = new OrbitPoint();

		private IPlayerCraftProvider _playerCraftProvider;

		public bool ApoapsisOnVisibleOrbit => _orbitLine.ApoapsisOnVisibleOrbit;

		public bool AscendingNodeOnVisibleOrbit => _orbitLine.AscendingNodeOnVisibleOrbit;

		public Camera Camera { get; private set; }

		public IChainableOrbit ChainNode => _chainNodeScript;

		public IMapViewCoordinateConverter CoordinateConverter { get; internal set; }

		public bool DescendingNodeOnVisibleOrbit => _orbitLine.DescendingNodeOnVisibleOrbit;

		public IDrawModeProvider DrawModeProvider => _drawModeProvider;

		public double EndTime
		{
			get
			{
				if (Debug.isDebugBuild && ChainNode?.ListNode.Next != null && ChainNode.ListNode.Next.Value.Locked)
				{
					Debug.LogWarning("Accessing EndTime while next node is locked.  This can cause errors if a burn has occurred which makes the next node invalid.");
				}
				if (ValidTrueAnomalyEnd == ValidTrueAnomalyStart)
				{
					if (OrbitNode.Orbit.Eccentricity < 1.0)
					{
						return StartTime + OrbitNode.Orbit.Period;
					}
					return double.PositiveInfinity;
				}
				return OrbitMath.GetTimeAtTrueAnomaly(OrbitNode.Orbit, ValidTrueAnomalyEnd);
			}
		}

		public double EndTimeExcludingPlanetIntersection => OrbitMath.GetTimeAtTrueAnomaly(OrbitNode.Orbit, ValidTrueAnomalyEndExcludingPlanetIntersection);

		public int Id => _orbitLine.Id;

		public bool InContactWithPlanet
		{
			get
			{
				if (_craftnode == null)
				{
					return false;
				}
				return _craftnode.InContactWithPlanet;
			}
		}

		public bool IsCurrentPlayer
		{
			get
			{
				if (_playerCraftProvider != null)
				{
					return _playerCraftProvider.PlayerCraft.OrbitInfo == this;
				}
				return false;
			}
		}

		public bool IsPartOfPlayerChain
		{
			get
			{
				MapPlayerCraft playerCraft = _playerCraftProvider.PlayerCraft;
				if ((object)playerCraft != null)
				{
					return playerCraft == _chainNodeList?.ChainNodes.First.Value as MapPlayerCraft;
				}
				return false;
			}
		}

		public ManeuverNodeScript ManeuverNode => _maneuverNodeScript;

		public Color OrbitColor => _orbitLine.Color;

		public IOrbitInteractionEventRecipient OrbitInteractionEventRecipient => _orbitLine;

		public IOrbitNode OrbitNode { get; private set; }

		public bool PeriapsisOnVisibleOrbit => _orbitLine.PeriapsisOnVisibleOrbit;

		public IOrbitPoint PlanetIntersection { get; private set; }

		public bool PlanetIntersectionOnVisibleOrbit => _orbitLine.PlanetIntersectionOnVisibleOrbit;

		public Transform RootTransform => _orbitLine.transform;

		public bool Selected
		{
			get
			{
				if (!(_maneuverNodeScript != null))
				{
					return false;
				}
				return _maneuverNodeScript.Selected;
			}
		}

		public double StartTime => OrbitNode.Orbit.Time;

		public string Text
		{
			get
			{
				return _orbitLine.Text;
			}
			set
			{
				_orbitLine.Text = value;
			}
		}

		public Vector2 UiCeterOffset
		{
			get
			{
				if (!(_maneuverNodeScript != null))
				{
					return Vector2.zero;
				}
				return new Vector2(_maneuverNodeScript.SelectionIconSize.x, 0f - _maneuverNodeScript.SelectionIconSize.y);
			}
		}

		public double ValidTrueAnomalyEnd
		{
			get
			{
				if (!PlanetIntersectionOnVisibleOrbit)
				{
					return ValidTrueAnomalyEndExcludingPlanetIntersection;
				}
				return PlanetIntersection.TrueAnomaly;
			}
		}

		public virtual double ValidTrueAnomalyEndExcludingPlanetIntersection
		{
			get
			{
				if (ChainNode?.ListNode.Next == null)
				{
					if (OrbitNode.Orbit.Eccentricity < 1.0)
					{
						return ValidTrueAnomalyStart;
					}
					return OrbitNode.Orbit.TrueAnomalyAtApoapsis;
				}
				return ChainNode.ListNode.Next.Value.TrueAnomalyOnPreviousOrbit;
			}
		}

		public double ValidTrueAnomalyStart => OrbitNode.Orbit.TrueAnomaly;

		public MapOrbitInfo(IIocContainer ioc, IMapViewContext mapViewContext, IOrbitNode orbitNode, Camera mapCamera, MapOrbitLine orbitLine)
		{
			MapOrbitInfo mapOrbitInfo = this;
			Camera = mapCamera;
			OrbitNode = orbitNode;
			_craftnode = orbitNode as CraftNode;
			_orbitLine = orbitLine;
			_ioc = ioc;
			_mapViewContext = mapViewContext;
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				IItemRegistry itemRegistry = ioc.Resolve<IItemRegistry>(mapOrbitInfo._mapViewContext);
				mapOrbitInfo._mapItem = itemRegistry.GetItem(orbitNode);
			});
			_drawModeProvider = ioc.Resolve<IDrawModeProvider>(_mapViewContext);
			_playerCraftProvider = ioc.Resolve<IPlayerCraftProvider>(_mapViewContext);
			CoordinateConverter = ioc.Resolve<IMapViewCoordinateConverter>(_mapViewContext);
		}

		public void DestroyOrbitLine()
		{
			_orbitLine.Destroy();
		}

		public void DisableOrbitLine()
		{
			_orbitLine.Disable();
		}

		public void EnableOrbitLine()
		{
			_orbitLine.Enable();
		}

		public void ForceOrbitLineUpdate()
		{
			_orbitLine.ForceUpdate();
		}

		public void GetAscendingDescendingNodesToTarget(out double? ascendingNodeToTarget, out double? descendingNodeToTarget)
		{
			_orbitLine.GetAscendingDescendingNodesToTarget(out ascendingNodeToTarget, out descendingNodeToTarget);
		}

		public bool IsAssociatedWith(MapOrbitLine orbitLine)
		{
			return _orbitLine == orbitLine;
		}

		public bool IsAssociatedWith(ICameraFocusable cameraFocusable)
		{
			MapOrbitInfo mapOrbitInfo = null;
			if (cameraFocusable is OrbitChainNodeScript)
			{
				mapOrbitInfo = (cameraFocusable as OrbitChainNodeScript).OrbitInfo;
			}
			else if (cameraFocusable is MapItem)
			{
				mapOrbitInfo = (cameraFocusable as MapItem).OrbitInfo;
			}
			return this == mapOrbitInfo;
		}

		public void RemoveIcon(Image icon)
		{
			_orbitLine.RemoveIcon(icon);
		}

		public void SetChainNodeInfo(ICraftContext craftContext, IChainableOrbit orbitChainNodeScript)
		{
			_chainNodeScript = orbitChainNodeScript;
			_maneuverNodeScript = _chainNodeScript as ManeuverNodeScript;
			_chainNodeList = _ioc.Resolve<IChainNodeList>(craftContext);
		}

		public void SetPlanetIntersection(IOrbitPoint planetIntersection)
		{
			if (planetIntersection != null)
			{
				PlanetIntersection = _planetIntersectionPointCache;
				PlanetIntersection.Set(planetIntersection);
			}
			else
			{
				PlanetIntersection = null;
			}
		}

		public void UpdateOrbit(IOrbit newOrbit)
		{
			OrbitNode.SetStateVectors(newOrbit.Position, newOrbit.Velocity, newOrbit.Time);
		}

		public void UpdateUiComponentFromPoint(Component component, Canvas canvas, IOrbitPoint point, bool autoDisable = true)
		{
			_orbitLine.UpdateUiComponentFromPoint(component, canvas, point);
		}

		internal void OnNewNextNode()
		{
			_orbitLine.OnNewNextNode();
		}

		internal void SetOrbitLine(MapOrbitLine mapOrbitLine)
		{
			_orbitLine = mapOrbitLine;
		}

		internal void SetOrbitLineColor(Color orbitColor)
		{
			_orbitLine.SetColor(orbitColor);
		}

		internal void UpdateUiComponentFromCurrentPosition(Component component, Canvas canvas, bool fadeOutWithDistance = true)
		{
			_mapItem.UpdateUiComponentFromCurrentPosition(component, canvas, this, fadeOutWithDistance);
		}
	}
}
