using System;
using System.Collections.Generic;
using System.Text;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain
{
	public abstract class OrbitChainNodeScript : MonoBehaviour, IChainableOrbit, ICameraFocusable
	{
		private CameraFocusableItemDestroyedHandler _cameraFocusableDestroyed;

		private double? _cameraFocusableLockPositionNu;

		private IChainNodeOptions _chainNodeOptions;

		private ICraftContext _craftContext;

		private ICraftInfo _craftInfo;

		private IDrawModeProvider _drawModeProvider;

		private LinkedListNode<IChainableOrbit> _listNode;

		private bool _locked;

		private IMapOptions _options;

		private MapOrbitLine _orbitLine;

		private bool _orbitLineDirty;

		private ICameraFocusable _parentCameraFocusable;

		private bool _selected;

		private bool _trueAnomalyOnPreviousChanged;

		private double _trueAnomalyOnPreviousOrbit;

		public static bool ShowDebug { get; set; }

		IPlanetNode ICameraFocusable.AssociatedPlanet => OrbitInfo.OrbitNode.Parent;

		bool ICameraFocusable.FocusByClick => false;

		ICameraFocusable ICameraFocusable.ItemToFocusOnWhenDeleted => null;

		public LinkedListNode<IChainableOrbit> ListNode => _listNode;

		public bool Locked
		{
			get
			{
				return _locked;
			}
			private set
			{
				_locked = value;
			}
		}

		float ICameraFocusable.MinZoomDistance => _parentCameraFocusable.MinZoomDistance;

		public string Name { get; private set; }

		public MapOrbitInfo OrbitInfo { get; private set; }

		IOrbitNode ICameraFocusable.OrbitNode => OrbitInfo.OrbitNode;

		Vector3 ICameraFocusable.Position
		{
			get
			{
				Vector3d solarPosition = ((!_cameraFocusableLockPositionNu.HasValue) ? _drawModeProvider.DrawMode.GetSolarPositionAtCurrent(OrbitInfo) : _drawModeProvider.DrawMode.GetSolarPositionFromNu(ListNode.Previous.Value.OrbitInfo, _cameraFocusableLockPositionNu.Value));
				return (Vector3)OrbitInfo.CoordinateConverter.ConvertSolarToMapView(solarPosition);
			}
		}

		public bool PropagateChanges { get; set; } = true;

		public bool Selected => _selected;

		public double? TimeToNode
		{
			get
			{
				LinkedListNode<IChainableOrbit> previous = ListNode.Previous;
				if (previous != null)
				{
					double time = previous.Value.OrbitInfo.OrbitNode.Orbit.Time;
					double num = OrbitInfo.OrbitNode.Orbit.Time - time;
					double? timeToNode = previous.Value.TimeToNode;
					if (timeToNode.HasValue)
					{
						return timeToNode + num;
					}
					return num;
				}
				return null;
			}
		}

		public double TrueAnomalyOnPreviousOrbit
		{
			get
			{
				return _trueAnomalyOnPreviousOrbit;
			}
			private set
			{
				_trueAnomalyOnPreviousOrbit = value;
			}
		}

		event CameraFocusableItemDestroyedHandler ICameraFocusable.Destroyed
		{
			add
			{
				_cameraFocusableDestroyed = (CameraFocusableItemDestroyedHandler)Delegate.Combine(_cameraFocusableDestroyed, value);
			}
			remove
			{
				_cameraFocusableDestroyed = (CameraFocusableItemDestroyedHandler)Delegate.Remove(_cameraFocusableDestroyed, value);
			}
		}

		public static SoiEncounterNodeScript CheckAndCreateEncounter(IIocContainer ioc, ICraftContext craftContext, double localMinimaModifier, MapOrbitInfo orbitInfo, Color color)
		{
			SoiEncounterNodeScript soiEncounterNodeScript = null;
			IChainNodeList chainNodeList = ioc.Resolve<IChainNodeList>(craftContext);
			IChainableOrbit chainableOrbit = null;
			LinkedListNode<IChainableOrbit> next = orbitInfo.ChainNode.ListNode.Next;
			ManeuverNodeScript maneuverNodeScript = next?.Value as ManeuverNodeScript;
			double endNu = ((maneuverNodeScript != null && maneuverNodeScript.ReferenceOrbitPeriod == 0) ? next.Value.TrueAnomalyOnPreviousOrbit : orbitInfo.ValidTrueAnomalyStart);
			IChainNodeSelection selectionManager = ioc.Resolve<IChainNodeSelection>(craftContext);
			OrbitAnalyser.SoiEnterInfo soiEnterInfo = OrbitAnalyser.GetSoiEnterInfo(ioc, orbitInfo.OrbitNode, endNu, localMinimaModifier, ShouldShowDebug(selectionManager, orbitInfo.ChainNode) ? "CheckAndCreateEncounter" : null);
			if (chainNodeList.AllowEncounterNodeCreation && soiEnterInfo != null && soiEnterInfo.EncounterOccurred && (orbitInfo.PlanetIntersection == null || orbitInfo.PlanetIntersection.Time > soiEnterInfo.PointA.Time))
			{
				PlanetNode planet = soiEnterInfo.NodeB as PlanetNode;
				if (!DoesNodeOrbit(next?.Value, planet))
				{
					bool num = (maneuverNodeScript?.ReferenceOrbitPeriod ?? 0) > 0;
					if (num)
					{
						chainNodeList.SetOrphaned(maneuverNodeScript);
					}
					if (num || OrbitMath.TrueAnomalyBetween(soiEnterInfo.PointA.TrueAnomaly, orbitInfo.ValidTrueAnomalyStart, orbitInfo.ValidTrueAnomalyEnd, inclusive: true))
					{
						chainableOrbit = CreateSoiEnterNode(ioc, craftContext, orbitInfo.ChainNode?.ListNode, soiEnterInfo, color);
						soiEncounterNodeScript = chainableOrbit as SoiEnterNodeScript;
						if (Debug.isDebugBuild && MapUtils.SamePlanet(chainableOrbit.OrbitInfo.OrbitNode.Parent, (IPlanetNode)soiEnterInfo.NodeB))
						{
						}
					}
				}
				else
				{
					chainableOrbit = next?.Value;
				}
			}
			if (chainableOrbit == null && orbitInfo.OrbitNode.NodeExitsSoi)
			{
				IPlanetNode parent = orbitInfo.OrbitNode.Parent.Parent;
				if (parent != null && !DoesNodeOrbit(next?.Value, parent))
				{
					OrbitAnalyser.SoiExitInfo soiExitInfo = OrbitAnalyser.GetSoiExitInfo(orbitInfo);
					if (soiExitInfo != null)
					{
						if (Utilities.CompareDoubles(soiExitInfo.PointA.Time, orbitInfo.EndTime) || Utilities.Between(soiExitInfo.PointA.Time, orbitInfo.StartTime, orbitInfo.EndTime))
						{
							SoiExitNodeScript soiExitNodeScript = CreateSoiExitNode(ioc, craftContext, orbitInfo.ChainNode?.ListNode, soiExitInfo, color);
							soiEncounterNodeScript = soiExitNodeScript;
							if (Debug.isDebugBuild)
							{
								MapUtils.SamePlanet(soiExitNodeScript.OrbitInfo.OrbitNode.Parent, (IPlanetNode)soiExitInfo.NodeB);
							}
						}
						if (Debug.isDebugBuild && (bool)soiEncounterNodeScript)
						{
						}
					}
				}
			}
			return soiEncounterNodeScript;
		}

		public static IOrbit CreatePredictedExitSoiOrbit(OrbitAnalyser.SoiExitInfo encounterInfo)
		{
			PlanetNode planetNode = encounterInfo.NodeB as PlanetNode;
			PlanetNode planetNode2;
			if (false)
			{
				IOrbitPoint pointB = encounterInfo.PointB;
				Orbit orbit = new Orbit(pointB.Position, pointB.Velocity, encounterInfo.Time, planetNode.Parent.PlanetData.Mass);
				planetNode2 = new SoiEncounterPlanetSimNode(planetNode.PlanetData, orbit, planetNode.Parent, planetNode);
			}
			else
			{
				planetNode2 = planetNode;
			}
			IOrbitPoint pointA = encounterInfo.PointA;
			_ = encounterInfo.NodeA;
			IPlanetNode parent = encounterInfo.NodeA.Parent;
			Vector3d vector3d = pointA.Position + parent.GetSolarPositionAtTime(pointA.Time);
			Vector3d vector3d2 = pointA.Velocity + parent.GetSolarVelocityAtTime(pointA.Time);
			Vector3d p = vector3d - planetNode2.GetSolarPositionAtTime(pointA.Time);
			Vector3d v = vector3d2 - planetNode2.GetSolarVelocityAtTime(pointA.Time);
			return new Orbit(p, v, encounterInfo.Time, planetNode2.PlanetData.Mass);
		}

		public static int GetNodeIndex(OrbitChainNodeScript chainNode)
		{
			int num = 0;
			LinkedListNode<IChainableOrbit> linkedListNode = chainNode.ListNode;
			while (linkedListNode.Previous != null)
			{
				linkedListNode = linkedListNode.Previous;
				num++;
			}
			return num;
		}

		public static bool ShouldShowDebug(IChainNodeSelection selectionManager, IChainableOrbit chainableOrbit)
		{
			if (selectionManager.Selected == chainableOrbit)
			{
				return ShowDebug;
			}
			return false;
		}

		public SoiEncounterNodeScript CheckAndCreateEncounter()
		{
			return CheckAndCreateEncounter(_craftInfo.Ioc, _craftContext, _options.Targeting.SoiEntryLocalMinimaModifier, OrbitInfo, UiUtils.GetSortedOrbitLineColor((OrbitInfo.ChainNode?.ListNode?.List.Count).GetValueOrDefault()));
		}

		public virtual void CheckForIncompatibleState()
		{
		}

		public virtual void Dispose()
		{
			_cameraFocusableDestroyed?.Invoke(this);
		}

		public double GetTimeToNode(bool fullTime, bool absoluteTime)
		{
			double time = _craftInfo.OrbitInfo.OrbitNode.Orbit.Time;
			double time2 = OrbitInfo.OrbitNode.Orbit.Time;
			if (fullTime)
			{
				if (absoluteTime)
				{
					return time2;
				}
				return time2 - time;
			}
			if (!absoluteTime)
			{
				return time2 - _listNode.Previous.Value.OrbitInfo.OrbitNode.Orbit.Time;
			}
			throw new InvalidOperationException("absoluteTime doesn't make sense unless you're also getting the full time to the node.");
		}

		public virtual void LockNode()
		{
			Locked = true;
		}

		public virtual void OnAfterCameraPositioned()
		{
			CheckAndCreateEncounter();
			UpdateUi(this);
		}

		public virtual void OnDeselected()
		{
			_selected = false;
		}

		public virtual void OnSelected()
		{
			_selected = true;
		}

		public virtual void OnTrueAnomalyOnPreviousOrbitChanged(double nu)
		{
			SetTrueAnomalyOnPrevious(nu);
			_trueAnomalyOnPreviousChanged = true;
		}

		public void SendPreviousNodeOrbitChanged(IOrbit previousOrbit)
		{
			if (OnBeforeNodeUpdated())
			{
				LinkedListNode<IChainableOrbit> next = _listNode.Next;
				if (!Locked)
				{
					OnPreviousNodeOrbitChanged(previousOrbit);
				}
				if (PropagateChanges)
				{
					next?.Value.SendPreviousNodeOrbitChanged(OrbitInfo.OrbitNode.Orbit);
				}
				OnAfterNodeUpdated(previousOrbit, PropagateChanges);
			}
		}

		public void SetListNode(LinkedListNode<IChainableOrbit> listNode)
		{
			_listNode = listNode;
		}

		public void SetOrbitLineDirty()
		{
			_orbitLineDirty = true;
		}

		public void SetTrueAnomalyOnPrevious(double nu)
		{
			TrueAnomalyOnPreviousOrbit = nu;
		}

		public virtual void UnlockNode(bool userRequested)
		{
			Locked = false;
		}

		protected static T Create<T>(ICraftContext craftContext, string name, LinkedListNode<IChainableOrbit> listNode, MapOrbitLine orbitLine, double trueAnomalyOnPrevious) where T : OrbitChainNodeScript
		{
			_ = orbitLine.OrbitInfo;
			IIocContainer ioc = orbitLine.Ioc;
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			Transform canvasesRoot = ioc.Resolve<IObjectContainerProvider>(context).CanvasesRoot;
			T val = new GameObject().AddComponent<T>();
			val.name = $"{name} ({val.GetInstanceID()})";
			val.transform.SetParent(canvasesRoot);
			val.transform.localScale = Vector3.one;
			val.gameObject.layer = canvasesRoot.gameObject.layer;
			val.Initialize(craftContext, name, listNode, orbitLine, trueAnomalyOnPrevious);
			return val;
		}

		protected virtual void OnAfterNodeUpdated(IOrbit previousOrbit, bool changesPropagated)
		{
			if (_trueAnomalyOnPreviousChanged || _orbitLineDirty)
			{
				_orbitLine.UpdateLine();
			}
			_trueAnomalyOnPreviousChanged = false;
			_orbitLineDirty = false;
		}

		protected virtual bool OnBeforeNodeUpdated()
		{
			return true;
		}

		protected virtual void OnDestroy()
		{
			Dispose();
		}

		protected virtual bool OnPreviousNodeOrbitChanged(IOrbit precedingOrbit)
		{
			return true;
		}

		protected void SetCameraPositionLocked(bool locked)
		{
			if (locked)
			{
				_cameraFocusableLockPositionNu = TrueAnomalyOnPreviousOrbit;
			}
			else
			{
				_cameraFocusableLockPositionNu = null;
			}
		}

		protected virtual void Update()
		{
		}

		private static SoiEnterNodeScript CreateSoiEnterNode(IIocContainer ioc, ICraftContext craftContext, LinkedListNode<IChainableOrbit> nodeBranchedFrom, OrbitAnalyser.SoiEnterInfo encounterInfo, Color color)
		{
			PlanetNode planetNode = encounterInfo.NodeB as PlanetNode;
			IOrbitPoint craftCapturePoint = encounterInfo.PointA;
			IOrbitPoint pointB = encounterInfo.PointB;
			Orbit orbit = new Orbit(pointB.Position, pointB.Velocity, encounterInfo.Time, planetNode.Parent.PlanetData.Mass);
			PlanetNode planetNode2 = new SoiEncounterPlanetSimNode(planetNode.PlanetData, orbit, planetNode.Parent, planetNode);
			Vector3d p = craftCapturePoint.Position - pointB.Position;
			Vector3d v = craftCapturePoint.Velocity - pointB.Velocity;
			Orbit orbit2 = new Orbit(p, v, encounterInfo.Time, planetNode2.PlanetData.Mass);
			ICraftInfo craftInfo = ioc.Resolve<ICraftInfo>(craftContext);
			IChainNodeList chainNodeList = ioc.Resolve<IChainNodeList>(craftContext);
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			IMapView mapView = ioc.Resolve<IMapView>(context);
			SoiEncounterOrbitSimNode soiEncounterOrbitSimNode = new SoiEncounterOrbitSimNode(orbit2, planetNode2);
			string text = $"{craftInfo.ItemName}EnterSoi->{soiEncounterOrbitSimNode.Parent.PlanetData.Name}";
			Material lineMaterial = UnityEngine.Object.Instantiate(craftInfo.LineMaterial);
			MapCraftOrbitLine orbitLine = MapCraftOrbitLine.Create(craftInfo.Ioc, craftInfo.MapViewContext, soiEncounterOrbitSimNode, craftInfo.Data, color, text, mapView.MapCamera, lineMaterial);
			chainNodeList.RemoveAfter<SoiEncounterNodeScript>(nodeBranchedFrom, consecutiveOccurrencesOnly: false, NodeListChangeCategory.Normal);
			LinkedListNode<IChainableOrbit> linkedListNode = chainNodeList.AddAfter(nodeBranchedFrom, (LinkedListNode<IChainableOrbit> x) => SoiEnterNodeScript.Create(craftContext, x, orbitLine, encounterInfo, craftCapturePoint.TrueAnomaly), NodeListChangeCategory.Normal);
			_ = linkedListNode.Previous;
			return (SoiEnterNodeScript)linkedListNode.Value;
		}

		private static SoiExitNodeScript CreateSoiExitNode(IIocContainer ioc, ICraftContext craftContext, LinkedListNode<IChainableOrbit> nodeBranchedFrom, OrbitAnalyser.SoiExitInfo encounterInfo, Color color)
		{
			IOrbitPoint craftAtSoiExit = encounterInfo.PointA;
			IOrbit orbit = CreatePredictedExitSoiOrbit(encounterInfo);
			ICraftInfo craftInfo = ioc.Resolve<ICraftInfo>(craftContext);
			IChainNodeList chainNodeList = ioc.Resolve<IChainNodeList>(craftContext);
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			IMapView mapView = ioc.Resolve<IMapView>(context);
			SoiEncounterOrbitSimNode soiEncounterOrbitSimNode = new SoiEncounterOrbitSimNode(orbit, encounterInfo.NodeB as PlanetNode);
			string text = $"{craftInfo.ItemName}ExitSoi->{soiEncounterOrbitSimNode.Parent.PlanetData.Name}";
			Material lineMaterial = UnityEngine.Object.Instantiate(craftInfo.LineMaterial);
			MapCraftOrbitLine orbitLine = MapCraftOrbitLine.Create(craftInfo.Ioc, craftInfo.MapViewContext, soiEncounterOrbitSimNode, craftInfo.Data, color, text, mapView.MapCamera, lineMaterial);
			chainNodeList.RemoveAfter<SoiEncounterNodeScript>(nodeBranchedFrom, consecutiveOccurrencesOnly: false, NodeListChangeCategory.Normal);
			LinkedListNode<IChainableOrbit> linkedListNode = chainNodeList.AddAfter(nodeBranchedFrom, (LinkedListNode<IChainableOrbit> x) => SoiExitNodeScript.Create(craftContext, x, orbitLine, craftAtSoiExit.TrueAnomaly), NodeListChangeCategory.Normal);
			_ = linkedListNode.Previous;
			return (SoiExitNodeScript)linkedListNode.Value;
		}

		private static bool DoesNodeOrbit(IChainableOrbit node, IPlanetNode planet)
		{
			if (node != null)
			{
				return MapUtils.SamePlanet(node.OrbitInfo.OrbitNode.Parent, planet);
			}
			return false;
		}

		private static bool HasEncounterBeenCreated<T>(IChainableOrbit startNode, IPlanetNode planet) where T : SoiEncounterNodeScript
		{
			bool result = false;
			for (IChainableOrbit chainableOrbit = startNode; chainableOrbit != null; chainableOrbit = chainableOrbit.ListNode.Next?.Value)
			{
				if (chainableOrbit is T)
				{
					if (DoesNodeOrbit(chainableOrbit, planet))
					{
						result = true;
					}
					break;
				}
			}
			return result;
		}

		private static void UpdateUi(OrbitChainNodeScript chainNode)
		{
			if (chainNode._chainNodeOptions.ShowNodeInfo)
			{
				StringBuilder stringBuilder = new StringBuilder(GetNodeIndex(chainNode).ToString());
				if (chainNode is ManeuverNodeScript)
				{
					ManeuverNodeScript maneuverNodeScript = chainNode as ManeuverNodeScript;
					stringBuilder.AppendFormat("\nmn: {0:0.00}m/s\n", maneuverNodeScript.DeltaV.magnitude);
				}
				else if (chainNode is SoiEncounterNodeScript)
				{
					if (chainNode is SoiExitNodeScript)
					{
						stringBuilder.Append("\nexit\n");
					}
					else if (chainNode is SoiEnterNodeScript)
					{
						stringBuilder.Append("\nenter\n");
					}
				}
				stringBuilder.AppendFormat("start:{0:0.000}\nend:{1:0.000}\n", chainNode.OrbitInfo.ValidTrueAnomalyStart, chainNode.OrbitInfo.ValidTrueAnomalyEnd);
				stringBuilder.AppendFormat("{0:0.0}s\n", chainNode.OrbitInfo.OrbitNode.Orbit.Time);
				stringBuilder.AppendFormat("ecc: {0:0.000}\n", chainNode.OrbitInfo.OrbitNode.Orbit.Eccentricity);
				chainNode.OrbitInfo.Text = stringBuilder.ToString();
			}
			else
			{
				chainNode.OrbitInfo.Text = null;
			}
		}

		private void Initialize(ICraftContext craftContext, string name, LinkedListNode<IChainableOrbit> listNode, MapOrbitLine orbitLine, double trueAnomalyOnPrevious)
		{
			IIocContainer ioc = orbitLine.Ioc;
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			_craftContext = craftContext;
			_chainNodeOptions = ioc.Resolve<IChainNodeOptions>(craftContext);
			_drawModeProvider = ioc.Resolve<IDrawModeProvider>(context);
			_craftInfo = ioc.Resolve<ICraftInfo>(craftContext);
			_options = ioc.Resolve<IMapOptions>();
			_orbitLine = orbitLine;
			OrbitInfo = orbitLine.OrbitInfo;
			OrbitInfo.SetChainNodeInfo(craftContext, this);
			TrueAnomalyOnPreviousOrbit = trueAnomalyOnPrevious;
			Name = name;
			_listNode = listNode;
			IItemRegistry itemRegistry = ioc.Resolve<IItemRegistry>(context);
			_parentCameraFocusable = itemRegistry.GetPlanet(OrbitInfo.OrbitNode.Parent);
			((ICameraFocusable)orbitLine).Destroyed += OnOrbitLineDestroyed;
		}

		private void OnOrbitLineDestroyed(ICameraFocusable source)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}

		public void PerformValidityCheck()
		{
			PerformValidityChecksWhichMayTemporarilyOccur();
		}

		private void PerformValidityChecksWhichMayTemporarilyOccur()
		{
			MapOrbitInfo orbitInfo = _listNode.Value.OrbitInfo;
			MapOrbitInfo orbitInfo2 = _listNode.Previous.Value.OrbitInfo;
			IOrbitNode orbitNode = orbitInfo.OrbitNode;
			_ = orbitInfo2.OrbitNode.Orbit.Time;
			_ = orbitInfo.OrbitNode.Orbit.Time;
			_ = orbitNode.Position.magnitude;
			_ = orbitNode.Parent.SphereOfInfluenceExitDistance;
		}
	}
}
