using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits;
using Assets.Scripts.Flight.MapView.Orbits.Chain;
using Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using Assets.Scripts.Input;
using ModApi;
using ModApi.Common.Events;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Flight.GameView;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.MapView.Items
{
	public class MapCraft : MapOrbitNode, ITargetableItem, ICameraFocusable, IChainableOrbit, ICraftContext, IContext, ICraftInfo
	{
		private struct OrbitalParamatersAtLastChange
		{
			public double Eccentricity { get; set; }

			public double Inclination { get; set; }

			public double PeriapsisAngle { get; set; }

			public double SemiMajorAxis { get; set; }

			public bool CheckForChange(IOrbit currentOrbit)
			{
				int num;
				if (Utilities.CompareDoubles(currentOrbit.SemiMajorAxis, SemiMajorAxis, Math.Abs(SemiMajorAxis) * 0.0001) && Utilities.CompareDoubles(currentOrbit.Eccentricity, Eccentricity, (Eccentricity < 1.0) ? 0.01 : (Eccentricity * 0.01)) && Utilities.CompareDoubles(currentOrbit.PeriapsisAngle, PeriapsisAngle, Math.PI / 200.0))
				{
					num = ((!Utilities.CompareDoubles(currentOrbit.Inclination, Inclination, Math.PI / 200.0)) ? 1 : 0);
					if (num == 0)
					{
						goto IL_00d6;
					}
				}
				else
				{
					num = 1;
				}
				SemiMajorAxis = currentOrbit.SemiMajorAxis;
				Eccentricity = currentOrbit.Eccentricity;
				PeriapsisAngle = currentOrbit.PeriapsisAngle;
				Inclination = currentOrbit.Inclination;
				goto IL_00d6;
				IL_00d6:
				return (byte)num != 0;
			}
		}

		private CameraFocusableItemDestroyedHandler _cameraFocusableDestroyed;

		private ChainNodeManager _chainNodeManager;

		private IChainNodeSelection _chainSelection;

		private bool _chainSelectionChanged;

		private GameObject _craftMapMesh;

		private CraftNode _craftNode;

		private double _lastEndNu;

		private LinkedListNode<IChainableOrbit> _listNode;

		private IMapView _mapView;

		private bool _nodeListChanged;

		private IMapOptions _options;

		private OrbitalParamatersAtLastChange _orbitAtLastChange;

		private bool _orbitLineDirty;

		private Material _orbitLineMaterial;

		private Shader _orbitLineShader;

		private bool _pointerHoveringOverCraft;

		private bool _selected;

		private bool _updateEncounters;

		private bool _updatingChain;

		public static bool StopUpdatingChain { get; set; }

		IPlanetNode ICameraFocusable.AssociatedPlanet => base.OrbitInfo.OrbitNode.Parent;

		public ChainNodeManager ChainNodeManager => _chainNodeManager;

		public IChainNodeSelection ChainNodeSelection => _chainSelection;

		string ITargetableItem.ClosestEncounterIcon => GetClosestEncounterIcon();

		public ICraftContext CraftContext => this;

		bool ICameraFocusable.FocusByClick => true;

		ICameraFocusable ICameraFocusable.ItemToFocusOnWhenDeleted => base.ItemRegistry.GetPlanet(((ICameraFocusable)this).AssociatedPlanet);

		public Material LineMaterial => _orbitLineMaterial;

		LinkedListNode<IChainableOrbit> IChainableOrbit.ListNode => _listNode;

		bool IChainableOrbit.Locked { get; }

		float ICameraFocusable.MinZoomDistance => AssociatedPlanetCameraFocusable.MinZoomDistance * 0.5f;

		string ITargetableItem.Name => base.OrbitInfo.OrbitNode.Name;

		string IChainableOrbit.Name => base.gameObject.name;

		MapOrbitInfo IChainableOrbit.OrbitInfo => base.OrbitInfo;

		IOrbitNode ICameraFocusable.OrbitNode => base.OrbitInfo.OrbitNode;

		Vector3 ICameraFocusable.Position => base.transform.position;

		bool IChainableOrbit.PropagateChanges { get; set; }

		public IRenderTextureProvider RenderTextureProvider { get; private set; }

		public bool Selected => _selected;

		public bool ShowTargetAscendingDescNodeIcons { get; private set; }

		public virtual bool SupportsManeuverNodes => false;

		public virtual bool SupportsOrbitLinePulses => false;

		public double? TimeToNode => null;

		double IChainableOrbit.TrueAnomalyOnPreviousOrbit
		{
			get
			{
				throw new InvalidOperationException("The craft doesn't have a previous orbit");
			}
		}

		protected override bool ShowTooltipOnHover => true;

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

		public static MapCraft Create(IIocContainer ioc, IMapViewContext mapViewContext, CraftNode craftNode, Camera mapCamera)
		{
			return Create<MapCraft>(ioc, mapViewContext, craftNode, mapCamera, "NonPlayerCraft");
		}

		public SoiEncounterNodeScript CheckAndCreateEncounter()
		{
			return OrbitChainNodeScript.CheckAndCreateEncounter(base.Ioc, CraftContext, _options.Targeting.SoiEntryLocalMinimaModifier, base.OrbitInfo, UiUtils.GetSortedOrbitLineColor((base.OrbitInfo.ChainNode?.ListNode?.List.Count).GetValueOrDefault()));
		}

		void IChainableOrbit.CheckForIncompatibleState()
		{
		}

		public override void Destroy()
		{
			base.Destroy();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
		}

		double ITargetableItem.GetSphereOfInfluence(MapOrbitInfo other)
		{
			if (other.OrbitNode is PlanetNode)
			{
				return 0.0;
			}
			return _options.Targeting.CraftSoiDistance;
		}

		public virtual void OnAfterCameraPositioned(bool mapViewVisible)
		{
			if (mapViewVisible)
			{
				UpdateUiAfterCameraPositioned();
			}
			_chainNodeManager.OnAfterCameraPositioned(mapViewVisible);
		}

		public override void OnAfterCameraPositioned()
		{
			base.OnAfterCameraPositioned();
			OnAfterCameraPositioned(mapViewVisible: true);
		}

		void IChainableOrbit.OnAfterCameraPositioned()
		{
		}

		public virtual void OnBeforeCameraPositioned(bool mapViewVisible)
		{
			_ = base.OrbitInfo;
			_ = base.OrbitLine.OrbitInfo;
			bool flag = false;
			if (mapViewVisible)
			{
				UpdateUiBeforeCameraPositioned();
				flag = DebugInput.GetKeyDown(KeyCode.Keypad0) | _options.Craft.ContinuouslyUpdateChain;
			}
			bool nodeListChanged = _nodeListChanged;
			_nodeListChanged = false;
			IChainableOrbit firstNonCraftNode = ChainNodeManager.FirstNonCraftNode;
			bool flag2 = firstNonCraftNode?.Locked ?? false;
			bool num = _lastEndNu != base.OrbitInfo.ValidTrueAnomalyEnd;
			bool flag3 = CheckOrbitChangedAndReset();
			bool drawFullOrbit = base.OrbitLine.DrawFullOrbit;
			base.OrbitLine.DrawFullOrbit = ShouldDrawFullOrbit();
			bool flag4 = drawFullOrbit != base.OrbitLine.DrawFullOrbit;
			bool flag5 = false;
			bool flag6 = OrbitChainNodeScript.ShouldShowDebug(_chainSelection, this);
			if (((num || flag3 || _updateEncounters) && !flag2) || flag || flag6)
			{
				RemoveIncompatibleEncounters();
				flag5 = CheckAndCreateEncounter();
			}
			bool flag7 = flag5 || flag3 || nodeListChanged || _chainSelectionChanged;
			flag7 = flag7 || flag;
			flag7 &= !StopUpdatingChain;
			if (flag7)
			{
				UpdateChainFromCraft();
			}
			bool num2 = _lastEndNu != base.OrbitInfo.ValidTrueAnomalyEnd;
			bool flag8 = firstNonCraftNode != null;
			bool flag9 = (num2 && flag8) || flag3 || flag4 || flag7 || _orbitLineDirty;
			if (mapViewVisible && (flag9 || flag))
			{
				base.OrbitLine.UpdateLine();
			}
			_lastEndNu = base.OrbitInfo.ValidTrueAnomalyEnd;
			_chainSelectionChanged = false;
			_updateEncounters = false;
			_orbitLineDirty = false;
			_chainNodeManager.OnBeforeCameraPositioned(mapViewVisible);
		}

		public override void OnBeforeCameraPositioned()
		{
			base.OnBeforeCameraPositioned();
			OnBeforeCameraPositioned(mapViewVisible: true);
		}

		void IChainableOrbit.OnDeselected()
		{
			_selected = false;
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			base.OnPointerClick(eventData);
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			_pointerHoveringOverCraft = true;
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			_pointerHoveringOverCraft = false;
		}

		void IChainableOrbit.OnSelected()
		{
			_selected = true;
		}

		void IChainableOrbit.PerformValidityCheck()
		{
		}

		public override void PerformValidityChecks()
		{
			_chainNodeManager.PerformValidityChecks();
		}

		public void ScheduleChainUpdate()
		{
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate
			{
				UpdateChainFromCraft();
			}, 3);
		}

		void IChainableOrbit.SendPreviousNodeOrbitChanged(IOrbit previousOrbit)
		{
		}

		public void SetListNode(LinkedListNode<IChainableOrbit> linkedListNode)
		{
			_listNode = linkedListNode;
			base.OrbitInfo.SetChainNodeInfo(CraftContext, this);
		}

		public void SetOrbitLineDirty()
		{
			_orbitLineDirty = true;
		}

		public void UpdateChainFromCraft()
		{
			IChainableOrbit chainableOrbit = _listNode.Next?.Value;
			if (!_updatingChain && chainableOrbit != null)
			{
				_updatingChain = true;
				chainableOrbit.SendPreviousNodeOrbitChanged(base.OrbitInfo.OrbitNode.Orbit);
				_updatingChain = false;
			}
		}

		protected static T Create<T>(IIocContainer ioc, IMapViewContext mapViewContext, CraftNode craftNode, Camera mapCamera, string iconName) where T : MapCraft
		{
			Sprite distanceIcon = UiUtils.LoadIconSprite(iconName);
			string text = string.Format("{0}PlayerCraft", craftNode.IsPlayer ? string.Empty : "Non-");
			IObjectContainerProvider objectContainerProvider = ioc.Resolve<IObjectContainerProvider>(mapViewContext);
			T val = MapItem.Create<T>(ioc, mapViewContext, craftNode, text, objectContainerProvider.CraftCanvases, mapCamera, objectContainerProvider.Crafts, distanceIcon);
			val.Initialize(craftNode);
			return val;
		}

		protected static bool IgnorePhysicsChange(PhysicsChangeReason reason)
		{
			switch (reason)
			{
			case PhysicsChangeReason.LoadedIntoGameView:
			case PhysicsChangeReason.LoadPhysics:
			case PhysicsChangeReason.UnloadedFromGameView:
			case PhysicsChangeReason.UnloadPhysics:
				return false;
			case PhysicsChangeReason.FlightEnd:
			case PhysicsChangeReason.Warp:
				return true;
			default:
				Debug.LogError($"Unsupported physics change reason: {reason}");
				return false;
			}
		}

		protected override void Awake()
		{
			base.Awake();
			base.gameObject.AddComponent<ClickableGameObjectScript>();
		}

		protected virtual string GetClosestEncounterIcon()
		{
			return "NonPlayerCraftAlternative";
		}

		protected override void LateUpdate()
		{
			base.LateUpdate();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			DestroyChainNodes();
			_cameraFocusableDestroyed?.Invoke(this);
			_cameraFocusableDestroyed = null;
			if (_craftNode != null)
			{
				_craftNode.ChangedSoI -= OnChangedSoi;
			}
			if (_mapView != null)
			{
				_mapView.Initialized -= OnMapViewInitialized;
			}
			if (_chainSelection != null)
			{
				_chainSelection.ChainNodeSelectionChanged -= OnChainNodeSelectionChanged;
				_chainSelection.Dispose();
			}
			if (_chainNodeManager != null)
			{
				_chainNodeManager.NodeListChanged -= OnNodeListChanged;
				_chainNodeManager.Dispose();
			}
			if (base.OrbitInfo.OrbitNode is CraftNode)
			{
				(base.OrbitInfo.OrbitNode as CraftNode).PhysicsDisabled -= OnCraftNodePhysicsDisabled;
			}
			IIocContainer ioc = base.Ioc;
			ioc.UnregisterContext(this);
			IMapViewManager mapViewManager = ioc.Resolve<IMapViewManager>();
			if (mapViewManager != null)
			{
				mapViewManager.ForegroundStateChanging -= OnMapViewForegroundStateChanging;
			}
		}

		protected virtual bool ShouldDrawFullOrbit()
		{
			if (!_pointerHoveringOverCraft)
			{
				return IsApplyingThrust();
			}
			return true;
		}

		protected override void Start()
		{
			base.Start();
			_chainNodeManager.NodeListChanged += OnNodeListChanged;
		}

		private bool CheckOrbitChangedAndReset()
		{
			if (!_orbitAtLastChange.CheckForChange(_craftNode.Orbit))
			{
				return IsApplyingThrust();
			}
			return true;
		}

		private void CreateOrbitLine()
		{
			_orbitLineShader = Shader.Find("Jundroo/MapView/CraftOrbitLine");
			_orbitLineMaterial = new Material(_orbitLineShader);
			Material lineMaterial = UnityEngine.Object.Instantiate(_orbitLineMaterial);
			SetOrbitLine(MapCraftOrbitLine.Create(base.Ioc, base.MapViewContext, base.OrbitInfo.OrbitNode, base.Data, UiUtils.GetSortedOrbitLineColor(0), "PlayerOrbit", base.Camera, lineMaterial));
		}

		private void DelFirst()
		{
			if (ChainNodeManager.FirstManeuverNode != null)
			{
				ChainNodeManager.FirstManeuverNode.Delete();
			}
		}

		private void DestroyChainNodes()
		{
			if (_listNode.Next != null)
			{
				_chainNodeManager.Remove(_listNode.Next, deleteChildren: true, destroy: true, NodeListChangeCategory.Normal);
			}
		}

		private void Initialize(CraftNode craftNode)
		{
			base.Selectable = true;
			IIocContainer ioc = base.Ioc;
			ioc.RegisterContext(CraftContext);
			ioc.Register(base.MapViewContext, CraftContext);
			ioc.Register((ICraftInfo)this, (IContext)CraftContext);
			RenderTextureProvider = ioc.Resolve<IRenderTextureProvider>(base.MapViewContext);
			_mapView = ioc.Resolve<IMapView>(base.MapViewContext);
			_options = ioc.Resolve<IMapOptions>();
			_craftNode = craftNode;
			_craftNode.ChangedSoI += OnChangedSoi;
			_craftNode.PhysicsDisabled += OnCraftNodePhysicsDisabled;
			_mapView.Initialized += OnMapViewInitialized;
			GameObject gameObject = Game.Instance.ResourceLoader.InstantiatePrefab("Flight/MapView/MapCraft");
			gameObject.transform.SetParent(base.transform, worldPositionStays: false);
			gameObject.SetLayer(base.gameObject.layer);
			_craftMapMesh = gameObject;
			_chainNodeManager = new ChainNodeManager(CraftContext, this);
			_chainSelection = new ChainNodeSelection(base.Ioc, CraftContext);
			_chainSelection.ChainNodeSelectionChanged += OnChainNodeSelectionChanged;
			CreateOrbitLine();
		}

		private bool IsApplyingThrust()
		{
			ICraftScript craftScript = _craftNode?.CraftScript;
			if (craftScript != null)
			{
				if (craftScript.FlightData.CurrentEngineThrust == 0f)
				{
					return craftScript.FlightData.CurrentReactionControlNozzleThrust != 0f;
				}
				return true;
			}
			return false;
		}

		private void OnChainNodeSelectionChanged(LinkedListNode<IChainableOrbit> chainNode)
		{
			_chainSelectionChanged = true;
		}

		private void OnChangedSoi(IOrbitNode source)
		{
			_nodeListChanged = true;
			RemoveManeuverNodesLeadingUpToFirstSoiEncounter();
			UnlockChainFromCraft();
			UpdateChainFromCraft();
		}

		private void OnCraftNodePhysicsDisabled(ICraftNode source, PhysicsChangeReason reason)
		{
			if (!IgnorePhysicsChange(reason))
			{
				MapItem.SwitchType<MapStaticOrbitItem>(this);
			}
		}

		private void OnMapViewForegroundStateChanging(bool foreground)
		{
			if (foreground)
			{
				UpdateChainFromCraft();
			}
		}

		private void OnMapViewInitialized(IMapView source)
		{
			_updateEncounters = true;
			base.Ioc.Resolve<IMapViewManager>().ForegroundStateChanging += OnMapViewForegroundStateChanging;
		}

		private void OnNodeListChanged(IChainNodeList source, LinkedListNode<IChainableOrbit> node, NodeListChangeCategory category)
		{
			_nodeListChanged = true;
		}

		private void RemoveIncompatibleEncounters()
		{
			LinkedListNode<IChainableOrbit> linkedListNode = _chainNodeManager.ChainNodes.First;
			while (linkedListNode != null)
			{
				LinkedListNode<IChainableOrbit> next = linkedListNode.Next;
				linkedListNode.Value.CheckForIncompatibleState();
				linkedListNode = next;
			}
		}

		private void RemoveManeuverNodesLeadingUpToFirstSoiEncounter()
		{
			LinkedListNode<IChainableOrbit> next = _listNode.Next;
			while (next != null)
			{
				LinkedListNode<IChainableOrbit> linkedListNode = next;
				next = next.Next;
				if (!(linkedListNode?.Value as SoiEncounterNodeScript != null))
				{
					ManeuverNodeScript maneuverNodeScript = linkedListNode?.Value as ManeuverNodeScript;
					if (maneuverNodeScript != null)
					{
						Debug.Log("Removing Node: " + maneuverNodeScript.name, maneuverNodeScript);
						ChainNodeManager.Remove(linkedListNode, deleteChildren: false, destroy: true, NodeListChangeCategory.Normal);
					}
					continue;
				}
				break;
			}
		}

		private void UnlockChainFromCraft()
		{
			for (IChainableOrbit chainableOrbit = _listNode.Next?.Value; chainableOrbit != null; chainableOrbit = chainableOrbit.ListNode.Next?.Value)
			{
				if (chainableOrbit is OrbitChainNodeScript orbitChainNodeScript)
				{
					orbitChainNodeScript.UnlockNode(userRequested: false);
				}
			}
		}

		private void UpdateUiAfterCameraPositioned()
		{
			if (_craftNode.IsPlayer)
			{
				float num = Vector3.Distance(base.Camera.transform.position, base.transform.position);
				float fieldOfView = base.Camera.fieldOfView;
				_craftMapMesh.transform.localScale = 0.03f * num * fieldOfView * 0.02f * Vector3.one;
				_craftMapMesh.SetActive(value: true);
				base.ItemIcon.enabled = false;
			}
			else
			{
				_craftMapMesh.SetActive(value: false);
				if (base.ItemIcon.enabled != base.Data.ShowIcons)
				{
					base.ItemIcon.enabled = base.Data.ShowIcons;
				}
			}
			if (base.ItemIcon.enabled || base.IsTooltipVisible)
			{
				UpdateIconPosition();
				UpdateTooltip();
			}
		}

		private void UpdateUiBeforeCameraPositioned()
		{
			base.transform.rotation = _craftNode.Heading.ToQuaternion();
			base.transform.position = (Vector3)base.CoordinateConverter.ConvertSolarToMapView(base.OrbitInfo.OrbitNode.SolarPosition);
		}
	}
}
