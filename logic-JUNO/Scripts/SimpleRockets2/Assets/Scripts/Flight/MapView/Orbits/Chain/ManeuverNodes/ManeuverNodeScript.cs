using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Items.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.SoiEncounters;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Flight.Sim;
using ModApi;
using ModApi.Common.UI;
using ModApi.Craft;
using ModApi.Flight.MapView;
using ModApi.Flight.Sim;
using ModApi.Ioc;
using ModApi.Math;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes
{
	public class ManeuverNodeScript : OrbitChainNodeScript, IManeuverNode, IManeuverNodePositionProvider, IManeuverNodeEventsProvider, IOrbitInfoProvider, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IEndDragHandler, IBeginDragHandler, IDisposable, IPointerDownHandler, IPointerUpHandler
	{
		public delegate void ManeuverNodeAdjustmentChangeDelegate(ManeuverNodeScript source, IOrbit newOrbit);

		public delegate void ManeuverNodeHandler(ManeuverNodeScript source);

		private enum GizmoState
		{
			Extended = 0,
			Retracted = 1
		}

		private class DataIoConstants
		{
			public const string DeltaV = "deltaV";
		}

		private Camera _camera;

		private double _cameraDistance;

		private ICurrentCameraTarget _cameraTarget;

		private IChainNodeList _chainList;

		private IChainNodeSelection _chainSelection;

		private ICraftInfo _craftInfo;

		private Image _deleteNodeIcon;

		private Vector3d _deltaV = Vector3d.zero;

		private float _deltaVAdjustmentSensitivityExpo = 1f;

		private float _deltaVAdjustmentSensitivityLinear = 1f;

		private bool _draggingManeuverNode;

		private IDrawModeProvider _drawModeProvider;

		private bool _dvChangeBegin;

		private bool _dvChanged;

		private bool _dvChangeEnd;

		private bool _dvChanging;

		private GizmoState _gizmoState;

		private Canvas _infoCanvas;

		private IIocContainer _ioc;

		private Image _lockedNodeIcon;

		private NodeAdjustorScript _maneuverNodeAdjustorBeingDragged;

		private Transform _maneuverNodeAdjustorContainer;

		private NodeDeltaVAdjustorScript[] _maneuverNodeAdjustors = new NodeDeltaVAdjustorScript[6];

		private IMapView _mapView;

		private NodeAdjustorScript _movementAidGizmo;

		private bool _movementAidGizmoWasSelectedOnPointerDown;

		private float _nextAutoLockAvailability;

		private Vector3 _nodeScreenPosition;

		private Vector3d _nodeWorldPosition;

		private Vector3d _normalReferenceVec;

		private Vector3d _normalVec;

		private IMapOptions _options;

		private MapOrbitLine _orbitLine;

		private IPlayerCraftProvider _playerCraftProvider;

		private float _pointerDownStartTime = float.PositiveInfinity;

		private Vector3d _prevDeltaV;

		private int _previousNodeDepthBeforeOrphan;

		private Vector3d _progradeReferenceVec;

		private Vector3d _progradeVec;

		private Vector3d _radialReferenceVec;

		private Vector3d _radialVec;

		private IOrbit _referenceOrbit;

		private bool _referenceOrbitChanged;

		private int _referenceOrbitPeriod;

		private Image _selectNodeIcon;

		private Vector2 _selectNodeIconSize;

		private bool _supportsVariableReferenceOrbitPeriod;

		public NodeDeltaVAdjustorScript AdjustorAntiNormal { get; private set; }

		public NodeDeltaVAdjustorScript AdjustorNormal { get; private set; }

		public NodeDeltaVAdjustorScript AdjustorPrograde { get; private set; }

		public NodeDeltaVAdjustorScript AdjustorRadialIn { get; private set; }

		public NodeDeltaVAdjustorScript AdjustorRadialOut { get; private set; }

		public NodeDeltaVAdjustorScript AdjustorRetrograde { get; private set; }

		public BurnData BurnData { get; private set; }

		double IManeuverNodePositionProvider.CameraDistance => _cameraDistance;

		public bool CanStartAutoBurn => !_draggingManeuverNode;

		public Vector3d DeltaV => _deltaV;

		public float DeltaVAdjustmentSensitivityExpo => _deltaVAdjustmentSensitivityExpo;

		public float DeltaVAdjustmentSensitivityLinear
		{
			get
			{
				return _deltaVAdjustmentSensitivityLinear;
			}
			set
			{
				_deltaVAdjustmentSensitivityExpo = Mathf.Pow(_deltaVAdjustmentSensitivityLinear = Mathf.Clamp(value, 0.01f, 2f), 1.5f);
			}
		}

		public double DeltaVMag { get; private set; }

		public double DeltaVNormal { get; private set; }

		public double DeltaVPrograde { get; private set; }

		public double DeltaVRadial { get; private set; }

		public bool ExecutionComplete { get; private set; }

		double IManeuverNodePositionProvider.ExtensionPercent
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool Hovered { get; private set; }

		Vector3 IManeuverNodePositionProvider.NodeScreenPosition => _nodeScreenPosition;

		Vector3d IManeuverNodePositionProvider.NodeWorldPosition => _nodeWorldPosition;

		public bool Orphaned => base.ListNode.Previous == null;

		public float? OrphanedTime { get; private set; }

		public int ReferenceOrbitPeriod
		{
			get
			{
				return _referenceOrbitPeriod;
			}
			set
			{
				if (_referenceOrbitPeriod != value)
				{
					_referenceOrbitPeriod = value;
					IOrbit orbit = base.ListNode.Previous.Value.OrbitNode.Orbit;
					OnReferenceOrbitChanged(orbit, base.TrueAnomalyOnPreviousOrbit);
				}
			}
		}

		public Vector2 SelectionIconSize => _selectNodeIconSize;

		public bool SupportsVariableReferenceOrbitPeriod => _supportsVariableReferenceOrbitPeriod;

		protected IOrbit ReferenceOrbit => _referenceOrbit;

		private ICraftNode CraftNode => _craftInfo.OrbitInfo.OrbitNode as ICraftNode;

		public event ManeuverNodeHandler Deleted;

		public event ManeuverNodeHandler ExecutionCompleted;

		public event ManeuverNodeAdjustmentChangeDelegate ManeuverNodeAdjustmentChangeBeginEvent;

		public event ManeuverNodeAdjustmentChangeDelegate ManeuverNodeAdjustmentChangeEndEvent;

		public event ManeuverNodeAdjustmentChangeDelegate ManeuverNodeAdjustmentChangingEvent;

		public event ManeuverNodeHandler NodeDraggingEvent;

		public static bool CanManeuverNodeMove(MapOrbitInfo maneuverNodeOrbitInfo, double newProposedTime, MapOrbitInfo prevOrbitInfo, MapOrbitInfo nextOrbitInfo)
		{
			IOrbit orbit = prevOrbitInfo.OrbitNode.Orbit;
			double num;
			if (nextOrbitInfo != null)
			{
				num = nextOrbitInfo.StartTime;
				int num2 = nextOrbitInfo.ManeuverNode?.ReferenceOrbitPeriod ?? 0;
				if (num2 > 0)
				{
					num -= (double)num2 * maneuverNodeOrbitInfo.OrbitNode.Orbit.Period;
				}
				num2 = maneuverNodeOrbitInfo.ManeuverNode?.ReferenceOrbitPeriod ?? 0;
				if (num2 > 0)
				{
					num -= (double)num2 * prevOrbitInfo.OrbitNode.Orbit.Period;
				}
			}
			else
			{
				num = ((orbit.Eccentricity > 1.0) ? double.MaxValue : (orbit.Time + orbit.Period));
			}
			IOrbitPoint pointAtTrueAnomaly = OrbitMath.GetPointAtTrueAnomaly(prevOrbitInfo.OrbitNode.Orbit, 0.0);
			if (pointAtTrueAnomaly.Position.magnitude < prevOrbitInfo.OrbitNode.Parent.PlanetData.Radius)
			{
				num = Math.Min(pointAtTrueAnomaly.Time, num);
			}
			if (maneuverNodeOrbitInfo.PlanetIntersection != null)
			{
				num = Math.Min(maneuverNodeOrbitInfo.PlanetIntersection.Time - 60.0, num);
			}
			return Utilities.Between(newProposedTime, prevOrbitInfo.StartTime, num);
		}

		public static ManeuverNodeScript Create(ICraftContext craftContext, LinkedListNode<IChainableOrbit> listNode, MapOrbitLine orbitLine, double trueAnomalyOnPrevious, Vector3d deltaV, NodeListChangeCategory changeCategory)
		{
			ManeuverNodeScript maneuverNodeScript = OrbitChainNodeScript.Create<ManeuverNodeScript>(craftContext, "BurnNode", listNode, orbitLine, trueAnomalyOnPrevious);
			maneuverNodeScript.Initialize(craftContext, orbitLine, deltaV, changeCategory);
			return maneuverNodeScript;
		}

		public void AdjustDeltaV(Vector3 input)
		{
			if (input.x != 0f)
			{
				((input.x > 0f) ? AdjustorPrograde : AdjustorRetrograde).AdjustDeltaV(Mathf.Abs(input.x));
			}
			if (input.y != 0f)
			{
				((input.y > 0f) ? AdjustorNormal : AdjustorAntiNormal).AdjustDeltaV(Mathf.Abs(input.y));
			}
			if (input.z != 0f)
			{
				((input.z > 0f) ? AdjustorRadialOut : AdjustorRadialIn).AdjustDeltaV(Mathf.Abs(input.z));
			}
			ApplyDeltaVChangesFromAdjustors();
		}

		public void CompleteGizmoAnimations()
		{
			_movementAidGizmo.CompletePendingAnimations();
			NodeDeltaVAdjustorScript[] maneuverNodeAdjustors = _maneuverNodeAdjustors;
			for (int i = 0; i < maneuverNodeAdjustors.Length; i++)
			{
				maneuverNodeAdjustors[i].CompletePendingAnimations();
			}
		}

		public void Delete()
		{
			this.Deleted?.Invoke(this);
			_chainList.Remove(base.ListNode, deleteChildren: false, destroy: true, NodeListChangeCategory.Normal);
		}

		public override void Dispose()
		{
			base.Dispose();
			NodeDeltaVAdjustorScript[] maneuverNodeAdjustors = _maneuverNodeAdjustors;
			foreach (NodeDeltaVAdjustorScript nodeDeltaVAdjustorScript in maneuverNodeAdjustors)
			{
				if (nodeDeltaVAdjustorScript != null)
				{
					nodeDeltaVAdjustorScript.ManeuverNodeAdjustmentChangeBeginEvent -= OnAdjustorChangeBegin;
					nodeDeltaVAdjustorScript.ManeuverNodeAdjustmentChangingEvent -= OnAdjustorChanging;
					nodeDeltaVAdjustorScript.ManeuverNodeAdjustmentChangeEndEvent -= OnAdjustorChangeEnd;
				}
			}
			if (_chainList != null)
			{
				_chainList.NodeListChanged -= OnNodeListChanged;
			}
		}

		public Vector3d GetDeltaVToCompleteManeuver()
		{
			Vector3d result;
			if (base.Locked)
			{
				IOrbitPoint pointAtTime = OrbitMath.GetPointAtTime(_craftInfo.OrbitInfo.OrbitNode.Orbit, _referenceOrbit.Time);
				Vector3d velocity = pointAtTime.Velocity;
				result = _referenceOrbit.Velocity + DeltaV - velocity;
				if (_options.ManeuverNodes.ShowBurnAccuracyDebugGizmos)
				{
					MapUtils.DrawDebugBall(_craftInfo.OrbitInfo.OrbitNode.Parent, pointAtTime, "CraftAtBurnNode", Color.green);
				}
			}
			else
			{
				result = DeltaV;
			}
			return result;
		}

		public bool IsAutoLockAvailable()
		{
			if (Time.time > _nextAutoLockAvailability && !_draggingManeuverNode)
			{
				return _chainList.FirstIncompleteManeuverNode == this;
			}
			return false;
		}

		public bool IsSuitableForAdoption(LinkedListNode<IChainableOrbit> previous, LinkedListNode<IChainableOrbit> next)
		{
			bool num = IsValidPreviousNode(previous);
			bool flag = _previousNodeDepthBeforeOrphan == GetNodeDepth(previous);
			bool flag2 = OrbitMath.TrueAnomalyBetween(base.TrueAnomalyOnPreviousOrbit, previous.Value.OrbitInfo.ValidTrueAnomalyStart, previous.Value.OrbitInfo.ValidTrueAnomalyEnd, inclusive: true);
			bool flag3 = ReferenceOrbitPeriod > 0 && (next != null || !CanSupportVariableReferenceOrbitPeriod(previous.Value, next?.Value));
			if (num && flag && flag2)
			{
				return !flag3;
			}
			return false;
		}

		public bool IsValidPreviousNode(LinkedListNode<IChainableOrbit> previous)
		{
			MapOrbitInfo orbitInfo = previous.Value.OrbitInfo;
			IOrbitNode orbitNode = orbitInfo.OrbitNode;
			bool num = MapUtils.SamePlanet(base.OrbitInfo.OrbitNode.Parent, orbitNode.Parent);
			bool flag = false;
			IOrbitPoint planetIntersection = previous.Value.OrbitInfo.PlanetIntersection;
			if (planetIntersection != null)
			{
				flag = !OrbitMath.TrueAnomalyBetween(base.TrueAnomalyOnPreviousOrbit, orbitInfo.ValidTrueAnomalyStart, planetIntersection.TrueAnomaly, inclusive: true);
			}
			bool flag2 = false;
			if (orbitNode.Orbit.Eccentricity > 1.0 && !OrbitMath.IsTrueAnomalyValidForHyperbolic(orbitNode.Orbit, base.TrueAnomalyOnPreviousOrbit))
			{
				flag2 = true;
			}
			return !(!num || flag || flag2);
		}

		public override void LockNode()
		{
			Debug.Log("Burn node locked.");
			base.LockNode();
			SetGizmoState(GizmoState.Retracted);
			SetMoveAidVisible(visible: false);
			_playerCraftProvider.PlayerCraft?.OnManeuverNodeLocked(this);
		}

		public override void OnAfterCameraPositioned()
		{
			base.OnAfterCameraPositioned();
			UpdateReferenceOrbitPeriod();
			OrderIndependentUpdate();
			if (_dvChanged || _referenceOrbitChanged)
			{
				UpdateOrbit(base.PropagateChanges);
				UpdateManeuverVectors();
			}
			if (_dvChanging)
			{
				this.ManeuverNodeAdjustmentChangingEvent?.Invoke(this, base.OrbitInfo.OrbitNode.Orbit);
			}
			if (_dvChangeBegin)
			{
				this.ManeuverNodeAdjustmentChangeBeginEvent?.Invoke(this, base.OrbitInfo.OrbitNode.Orbit);
			}
			if (_dvChangeEnd)
			{
				this.ManeuverNodeAdjustmentChangeEndEvent?.Invoke(this, base.OrbitInfo.OrbitNode.Orbit);
			}
			_dvChanged = (_dvChanging = (_dvChangeBegin = (_dvChangeEnd = (_referenceOrbitChanged = false))));
			UpdatePositions();
			UpdateUi();
			if (UnityEngine.Input.GetMouseButtonUp(1) && !UnityEngine.Input.anyKey && base.Selected)
			{
				if (!_movementAidGizmo.IsSelected)
				{
					ToggleGizmoState();
				}
				else
				{
					_movementAidGizmo.OnDeselected();
				}
			}
			if (_movementAidGizmo.IsSelected)
			{
				_movementAidGizmo.UpdateVector();
				if (_movementAidGizmo.IsDragging)
				{
					OnDraggingManeuverNode(_movementAidGizmo.CurrentDragPos);
				}
			}
			else if (!_draggingManeuverNode && !base.Locked && Time.unscaledTime - _pointerDownStartTime > 0.25f)
			{
				if (!base.Selected)
				{
					_chainSelection.SetSelected(base.ListNode, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
				}
				SetMoveAidVisible(visible: true);
			}
		}

		public void OnAfterInitialized()
		{
			UpdateOrbit(propagateChanges: false);
			UpdateManeuverVectors();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			GameObject gameObject = eventData.pointerPressRaycast.gameObject;
			if (_draggingManeuverNode)
			{
				return;
			}
			if (gameObject == _selectNodeIcon.gameObject)
			{
				if (!base.Locked)
				{
					OnStartDraggingManeuverNode();
				}
			}
			else
			{
				Debug.LogFormat("BurnNode detected a drag start, but it wasn't associated with the select icon: {0}", gameObject.name);
			}
		}

		public void OnBurnGizmoAlignmentChanged()
		{
			UpdateManeuverVectors();
		}

		public override void OnDeselected()
		{
			base.OnDeselected();
			SetGizmoState(GizmoState.Retracted);
			if (_movementAidGizmo.IsSelected)
			{
				_movementAidGizmo.OnDeselected();
			}
		}

		public void OnDrag(PointerEventData eventData)
		{
			if (_draggingManeuverNode)
			{
				OnDraggingManeuverNode(eventData.position);
			}
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (_draggingManeuverNode)
			{
				OnStopDraggingManeuverNode();
			}
		}

		public void OnManeuverNodeExecutionComplete()
		{
			ExecutionComplete = true;
			this.ExecutionCompleted?.Invoke(this);
		}

		public void OnOrphanedStateChanged(bool orphaned)
		{
			if (orphaned)
			{
				OrphanedTime = Time.realtimeSinceStartup;
				base.OrbitInfo.DisableOrbitLine();
				_infoCanvas.enabled = false;
				SetGizmoState(GizmoState.Retracted);
				CompleteGizmoAnimations();
			}
			else
			{
				OrphanedTime = null;
				base.OrbitInfo.EnableOrbitLine();
				_infoCanvas.enabled = true;
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (eventData.dragging)
			{
				return;
			}
			GameObject gameObject = eventData.pointerCurrentRaycast.gameObject;
			if (gameObject == _selectNodeIcon.gameObject)
			{
				if (!_movementAidGizmo.IsSelected)
				{
					if (!base.Selected)
					{
						OnSelectClicked();
					}
					else if (_gizmoState == GizmoState.Retracted)
					{
						SetGizmoState(GizmoState.Extended);
						if (_mapView.MapViewInspector.SelectedItem != this)
						{
							_mapView.SetInspectorFocus(this, CameraTransitionSpeed.Default, repositionCamDuringTransition: true);
						}
					}
					else
					{
						SetGizmoState(GizmoState.Retracted);
					}
				}
				else if (_movementAidGizmoWasSelectedOnPointerDown)
				{
					SetMoveAidVisible(visible: false);
				}
			}
			else if (gameObject == _deleteNodeIcon.gameObject)
			{
				OnDeleteClicked();
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			if (eventData.pointerCurrentRaycast.gameObject == _selectNodeIcon.gameObject)
			{
				_pointerDownStartTime = Time.unscaledTime;
				_movementAidGizmoWasSelectedOnPointerDown = _movementAidGizmo.IsSelected;
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			Hovered = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			Hovered = false;
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			_pointerDownStartTime = float.PositiveInfinity;
		}

		public override void OnSelected()
		{
			base.OnSelected();
		}

		public void SetDeltaV(Vector3d deltaV)
		{
			AdjustorPrograde.SetDeltaV((deltaV.x > 0.0) ? deltaV.x : 0.0);
			AdjustorRetrograde.SetDeltaV((deltaV.x < 0.0) ? (0.0 - deltaV.x) : 0.0);
			AdjustorNormal.SetDeltaV((deltaV.y > 0.0) ? deltaV.y : 0.0);
			AdjustorAntiNormal.SetDeltaV((deltaV.y < 0.0) ? (0.0 - deltaV.y) : 0.0);
			AdjustorRadialOut.SetDeltaV((deltaV.z > 0.0) ? deltaV.z : 0.0);
			AdjustorRadialIn.SetDeltaV((deltaV.z < 0.0) ? (0.0 - deltaV.z) : 0.0);
			ApplyDeltaVChangesFromAdjustors();
		}

		public override void UnlockNode(bool userRequested)
		{
			base.UnlockNode(userRequested);
			if (userRequested)
			{
				_craftInfo.ScheduleChainUpdate();
				ActivateAutolockCooldown();
			}
		}

		public void UpdateBurnInfo()
		{
			BurnData.Update(base.Locked);
			if (!base.Locked && BurnData.ShouldLockNode() && IsAutoLockAvailable())
			{
				LockNode();
			}
		}

		protected void Initialize(ICraftContext craftContext, MapOrbitLine orbitLine, Vector3d deltaV, NodeListChangeCategory changeCategory)
		{
			_ioc = orbitLine.Ioc;
			IIocContainer ioc = _ioc;
			IMapViewContext context = ioc.Resolve<IMapViewContext>(craftContext);
			_mapView = ioc.Resolve<IMapView>(context);
			_options = ioc.Resolve<IMapOptions>();
			_chainSelection = ioc.Resolve<IChainNodeSelection>(craftContext);
			_craftInfo = ioc.Resolve<ICraftInfo>(craftContext);
			_cameraTarget = ioc.Resolve<ICurrentCameraTarget>(context);
			_chainList = ioc.Resolve<IChainNodeList>(craftContext);
			_playerCraftProvider = ioc.Resolve<IPlayerCraftProvider>(context);
			_chainList.NodeListChanged += OnNodeListChanged;
			_orbitLine = orbitLine;
			_camera = ioc.Resolve<IMapView>(context).MapCamera;
			BurnData = new BurnData(ioc, this, CraftNode.CraftScript);
			_referenceOrbit = new Orbit(base.OrbitInfo.OrbitNode.Orbit);
			UpdateReferenceOrbitVectors();
			InitializeUi(ioc.Resolve<IDrawModeProvider>(context));
			UpdateUi();
			if (changeCategory == NodeListChangeCategory.Normal)
			{
				SetGizmoState(GizmoState.Extended);
			}
			SetDeltaV(deltaV, updateAdjustors: true);
			DeltaVAdjustmentSensitivityLinear = 1f;
		}

		protected override void OnAfterNodeUpdated(IOrbit previousOrbit, bool changesPropagated)
		{
			base.OnAfterNodeUpdated(previousOrbit, changesPropagated);
			if (!base.Locked)
			{
				OrphanIfNecessary();
			}
		}

		protected override bool OnBeforeNodeUpdated()
		{
			bool flag = base.OnBeforeNodeUpdated();
			if (flag && !base.Locked)
			{
				flag = !OrphanIfNecessary();
			}
			return flag;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
		}

		protected override bool OnPreviousNodeOrbitChanged(IOrbit previousOrbit)
		{
			bool num = base.OnPreviousNodeOrbitChanged(previousOrbit);
			if (num)
			{
				OnReferenceOrbitChanged(previousOrbit, base.TrueAnomalyOnPreviousOrbit);
			}
			return num;
		}

		private static bool CanSupportVariableReferenceOrbitPeriod(IChainableOrbit previousOrbit, IChainableOrbit nextOrbit)
		{
			bool result = true;
			IOrbit orbit = previousOrbit.OrbitNode.Orbit;
			if (orbit.Eccentricity >= 1.0)
			{
				result = false;
			}
			else if (orbit.PeriapsisDistance - previousOrbit.OrbitNode.Parent.PlanetData.Radius <= 0.0)
			{
				result = false;
			}
			else if (((nextOrbit as SoiEncounterNodeScript)?.OrbitInfo.OrbitNode.Orbit.Time ?? double.MaxValue) < orbit.Time + orbit.Period)
			{
				result = false;
			}
			return result;
		}

		private void ActivateAutolockCooldown()
		{
			_nextAutoLockAvailability = Time.time + 5f;
		}

		private void ApplyDeltaVChangesFromAdjustors()
		{
			_dvChanged = true;
			IOrbit orbit = base.OrbitInfo.OrbitNode.Orbit;
			this.ManeuverNodeAdjustmentChangeBeginEvent?.Invoke(this, orbit);
			SetDeltaV(CalculateDeltaV(), updateAdjustors: false);
			ActivateAutolockCooldown();
			this.ManeuverNodeAdjustmentChangingEvent?.Invoke(this, orbit);
			this.ManeuverNodeAdjustmentChangeEndEvent?.Invoke(this, orbit);
		}

		private Vector3d CalculateDeltaV()
		{
			Vector3d zero = Vector3d.zero;
			for (int i = 0; i < _maneuverNodeAdjustors.Length; i++)
			{
				zero += _maneuverNodeAdjustors[i].DeltaV;
			}
			return zero;
		}

		private NodeDeltaVAdjustorScript CreateAdjustor(Func<Vector3d> maneuverVec, string iconName, Color color, bool subscribeToEvents = true, string name = null)
		{
			NodeDeltaVAdjustorScript nodeDeltaVAdjustorScript = NodeDeltaVAdjustorScript.Create(_ioc, _infoCanvas, _maneuverNodeAdjustorContainer, maneuverVec, this, this, this, _drawModeProvider, string.IsNullOrEmpty(name) ? iconName : name, iconName, color);
			if (subscribeToEvents)
			{
				nodeDeltaVAdjustorScript.ManeuverNodeAdjustmentChangeBeginEvent += OnAdjustorChangeBegin;
				nodeDeltaVAdjustorScript.ManeuverNodeAdjustmentChangingEvent += OnAdjustorChanging;
				nodeDeltaVAdjustorScript.ManeuverNodeAdjustmentChangeEndEvent += OnAdjustorChangeEnd;
			}
			return nodeDeltaVAdjustorScript;
		}

		private int GetNodeDepth(LinkedListNode<IChainableOrbit> node)
		{
			int num = 0;
			for (LinkedListNode<IChainableOrbit> linkedListNode = node; linkedListNode != null; linkedListNode = linkedListNode.Previous)
			{
				num++;
			}
			return num;
		}

		private void InitializeUi(IDrawModeProvider drawModeProvider)
		{
			Hovered = false;
			GameObject gameObject = base.gameObject;
			_infoCanvas = gameObject.AddComponent<Canvas>();
			_infoCanvas.gameObject.AddComponent<GraphicRaycaster>();
			_infoCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
			_infoCanvas.worldCamera = _camera;
			_infoCanvas.overrideSorting = true;
			_infoCanvas.sortingOrder = -1;
			_maneuverNodeAdjustorContainer = new GameObject("BurnNodeAdjustorContainer").transform;
			_maneuverNodeAdjustorContainer.SetParent(gameObject.transform);
			_maneuverNodeAdjustorContainer.localScale = Vector3.one;
			_maneuverNodeAdjustorContainer.gameObject.layer = base.gameObject.layer;
			Color.RGBToHSV(new Color(0.96f, 0.36f, 0.42f), out var H, out var S, out var V);
			Color color = Color.HSVToRGB(H, S * 0.6f, V);
			Color.RGBToHSV(new Color(0.01f, 0.9f, 0.25f), out H, out S, out V);
			Color color2 = Color.HSVToRGB(H, S * 0.6f, V);
			Color.RGBToHSV(new Color(0.28f, 0.38f, 0.91f), out H, out S, out V);
			Color color3 = Color.HSVToRGB(H, S * 0.6f, V);
			_maneuverNodeAdjustors[0] = CreateAdjustor(() => _progradeVec, "Prograde", color2);
			_maneuverNodeAdjustors[1] = CreateAdjustor(() => -_progradeVec, "Retrograde", color2);
			_maneuverNodeAdjustors[2] = CreateAdjustor(() => _radialVec, "Radial-out", color3);
			_maneuverNodeAdjustors[3] = CreateAdjustor(() => -_radialVec, "Radial-in", color3);
			_maneuverNodeAdjustors[4] = CreateAdjustor(() => _normalVec, "Normal", color);
			_maneuverNodeAdjustors[5] = CreateAdjustor(() => -_normalVec, "Anti-normal", color);
			AdjustorPrograde = _maneuverNodeAdjustors[0];
			AdjustorRetrograde = _maneuverNodeAdjustors[1];
			AdjustorRadialOut = _maneuverNodeAdjustors[2];
			AdjustorRadialIn = _maneuverNodeAdjustors[3];
			AdjustorNormal = _maneuverNodeAdjustors[4];
			AdjustorAntiNormal = _maneuverNodeAdjustors[5];
			_maneuverNodeAdjustors[1].transform.SetSiblingIndex(_maneuverNodeAdjustors[1].transform.parent.childCount);
			_maneuverNodeAdjustors[0].transform.SetSiblingIndex(_maneuverNodeAdjustors[0].transform.parent.childCount);
			_movementAidGizmo = CreateAdjustor(() => _radialVec, "MovementTool", new Color(0.3f, 0.3f, 0.3f), subscribeToEvents: false, "MovementAidGizmo");
			_movementAidGizmo.ExtensionEnabled = false;
			_movementAidGizmo.DisableDraggingWhenFacingCamera = false;
			_movementAidGizmo.ManeuverNodeAdjustmentChangeBeginEvent += OnMovementAidDragStart;
			_movementAidGizmo.ManeuverNodeAdjustmentChangeEndEvent += OnMovementAidDragEnd;
			GameObject gameObject2 = new GameObject("BurnNodeSelection");
			gameObject2.transform.SetParent(_infoCanvas.transform);
			_selectNodeIcon = gameObject2.AddComponent<Image>();
			_selectNodeIcon.gameObject.layer = _infoCanvas.gameObject.layer;
			_selectNodeIcon.transform.localScale = Vector3.one;
			_selectNodeIcon.sprite = UiUtils.LoadIconSprite("Sphere");
			Color orbitColor = base.OrbitInfo.OrbitColor;
			_selectNodeIcon.color = new Color(orbitColor.r, orbitColor.g, orbitColor.b, 1f);
			_selectNodeIcon.rectTransform.sizeDelta = new Vector2(20f, 20f);
			_selectNodeIcon.enabled = true;
			GameObject gameObject3 = new GameObject("BurnLocked");
			gameObject3.transform.SetParent(_infoCanvas.transform);
			_lockedNodeIcon = gameObject3.AddComponent<Image>();
			_lockedNodeIcon.gameObject.layer = _infoCanvas.gameObject.layer;
			_lockedNodeIcon.transform.localScale = Vector3.one;
			_lockedNodeIcon.sprite = UiUtils.LoadIconSprite("ManeuverLocked");
			_lockedNodeIcon.rectTransform.sizeDelta = new Vector2(25f, 25f);
			_lockedNodeIcon.enabled = false;
			_selectNodeIconSize = new Vector2(_selectNodeIcon.rectTransform.sizeDelta.x * _selectNodeIcon.transform.localScale.x, _selectNodeIcon.rectTransform.sizeDelta.y * _selectNodeIcon.transform.localScale.y);
			GameObject gameObject4 = new GameObject("BurnNodeDeletion");
			gameObject4.transform.SetParent(_infoCanvas.transform);
			_deleteNodeIcon = gameObject4.AddComponent<Image>();
			_deleteNodeIcon.gameObject.layer = _infoCanvas.gameObject.layer;
			_deleteNodeIcon.transform.localScale = Vector3.one;
			_deleteNodeIcon.sprite = UiUtils.LoadIconSprite("Delete");
			_deleteNodeIcon.rectTransform.sizeDelta = new Vector2(15f, 15f);
			_deleteNodeIcon.enabled = false;
			_drawModeProvider = drawModeProvider;
			UpdateManeuverVectors();
			_infoCanvas.gameObject.AddComponent<OverrideSortingOnStart>();
			Utilities.FixUnityCanvasSortingBug(_infoCanvas);
			_orbitLine.AddPointerNotifications(_infoCanvas);
			SetGizmoState(GizmoState.Retracted);
			_movementAidGizmo.OnDeselected();
			_movementAidGizmo.CompletePendingAnimations();
		}

		private void OnAdjustorChangeBegin(NodeAdjustorScript source)
		{
			_maneuverNodeAdjustorBeingDragged = source;
			_dvChanged = true;
			_dvChangeBegin = true;
		}

		private void OnAdjustorChangeEnd(NodeAdjustorScript source)
		{
			_maneuverNodeAdjustorBeingDragged = null;
			_dvChanged = true;
			_dvChangeEnd = true;
		}

		private void OnAdjustorChanging(NodeAdjustorScript source)
		{
			_dvChanged = true;
			_dvChanging = true;
			SetDeltaV(CalculateDeltaV(), updateAdjustors: false);
			UpdateDeltaVAxisContributions();
			ActivateAutolockCooldown();
			Game.Instance.FlightScene.FlightSceneUI.ShowMessage($"Delta V: {Units.GetVelocityString((float)DeltaVMag, Units.UnitPrecisionMode.High)}", devlog: false, 3f);
		}

		private void OnDeleteClicked()
		{
			Delete();
		}

		private void OnDraggingManeuverNode(Vector2 screenPos)
		{
			MapOrbitInfo orbitInfo = base.OrbitInfo.ChainNode.ListNode.Previous.Value.OrbitInfo;
			IOrbitPoint orbitPointFromScreenPosition = OrbitInteractionScript.GetOrbitPointFromScreenPosition(base.OrbitInfo.CoordinateConverter, _camera, orbitInfo, screenPos);
			if (orbitPointFromScreenPosition != null && CanManeuverNodeMove(base.OrbitInfo, orbitPointFromScreenPosition.Time, orbitInfo, base.OrbitInfo.ChainNode.ListNode.Next?.Value.OrbitInfo))
			{
				SetTrueAnomalyOnPrevious(orbitPointFromScreenPosition.TrueAnomaly);
				(base.OrbitInfo.ChainNode.ListNode.Previous?.Value)?.SetOrbitLineDirty();
				this?.NodeDraggingEvent(this);
			}
		}

		private void OnMovementAidDragEnd(NodeAdjustorScript source)
		{
			SetCameraPositionLocked(locked: false);
		}

		private void OnMovementAidDragStart(NodeAdjustorScript source)
		{
			SetCameraPositionLocked(locked: true);
		}

		private void OnNodeListChanged(IChainNodeList source, LinkedListNode<IChainableOrbit> node, NodeListChangeCategory category)
		{
		}

		private void OnReferenceOrbitChanged(IOrbit orbit, double nu)
		{
			double num = 0.0;
			if (orbit.Eccentricity < 1.0 && ReferenceOrbitPeriod > 0)
			{
				num = (double)ReferenceOrbitPeriod * orbit.Period;
			}
			_referenceOrbit.UpdateFromOrbitalElements(OrbitMath.GetTimeAtTrueAnomaly(orbit, nu) + num, orbit.Eccentricity, orbit.SemiMajorAxis, orbit.PeriapsisAngle, nu, orbit.Inclination, orbit.RightAscensionOfAscendingNode, orbit.PrimaryMass, orbit.IsPrograde);
			UpdateReferenceOrbitVectors();
			if (_options.NodeAdjustmentSpace == AdjustmentSpaceType.Relative)
			{
				SetDeltaV(_progradeReferenceVec * DeltaVPrograde + _normalReferenceVec * DeltaVNormal + _radialReferenceVec * DeltaVRadial, updateAdjustors: true);
			}
			_referenceOrbitChanged = true;
		}

		private void OnSelectClicked()
		{
			_chainSelection.SetSelected(base.ListNode, CameraTransitionSpeed.Medium, repositionCamDuringTransition: false);
			SetGizmoState(GizmoState.Extended);
		}

		private void OnStartDraggingManeuverNode()
		{
			SetCameraPositionLocked(locked: true);
			_draggingManeuverNode = true;
		}

		private void OnStopDraggingManeuverNode()
		{
			SetCameraPositionLocked(locked: false);
			_draggingManeuverNode = false;
		}

		private void OrderIndependentUpdate()
		{
			UpdateBurnInfo();
		}

		private bool OrphanIfNecessary()
		{
			bool result = false;
			if (!IsValidPreviousNode(base.ListNode.Previous) || (ReferenceOrbitPeriod > 0 && !CanSupportVariableReferenceOrbitPeriod(base.ListNode.Previous.Value, base.ListNode.Next?.Value)))
			{
				result = true;
				_chainList.SetOrphaned(this);
			}
			else
			{
				_previousNodeDepthBeforeOrphan = GetNodeDepth(base.OrbitInfo.ChainNode.ListNode.Previous);
			}
			return result;
		}

		private void SetDeltaV(Vector3d deltaV, bool updateAdjustors)
		{
			new Orbit(ReferenceOrbit.Position, ReferenceOrbit.Velocity + deltaV, ReferenceOrbit.Time, ReferenceOrbit.PrimaryMass);
			double num = ReferenceOrbit.Velocity.magnitude / 250000.0;
			if (Utilities.CompareDoubles((deltaV + ReferenceOrbit.Velocity).magnitude, 0.0, num))
			{
				Vector3d vector3d = _deltaV - _prevDeltaV;
				Vector3d vector3d2 = vector3d / vector3d.magnitude * num;
				SetDeltaV(deltaV + vector3d2, updateAdjustors: true);
				_maneuverNodeAdjustorBeingDragged?.ForceStopDrag();
				return;
			}
			if (updateAdjustors)
			{
				for (int i = 0; i < _maneuverNodeAdjustors.Length; i++)
				{
					_maneuverNodeAdjustors[i].SetDeltaV(Vector3.zero);
				}
				_maneuverNodeAdjustors[0].SetDeltaV(deltaV);
			}
			_prevDeltaV = _deltaV;
			_deltaV = deltaV;
			DeltaVMag = deltaV.magnitude;
			UpdateDeltaVAxisContributions();
			UpdateBurnInfo();
		}

		private void SetGizmoState(GizmoState state)
		{
			switch (state)
			{
			case GizmoState.Retracted:
			{
				for (int j = 0; j < _maneuverNodeAdjustors.Length; j++)
				{
					_maneuverNodeAdjustors[j].OnDeselected();
				}
				break;
			}
			case GizmoState.Extended:
				if (!base.Locked)
				{
					for (int i = 0; i < _maneuverNodeAdjustors.Length; i++)
					{
						_maneuverNodeAdjustors[i].OnSelected();
					}
				}
				break;
			default:
				Debug.Log($"Unsupported gizmo state {state}");
				break;
			}
			_gizmoState = state;
		}

		private void SetMoveAidVisible(bool visible)
		{
			if (visible)
			{
				if (_gizmoState != GizmoState.Retracted)
				{
					SetGizmoState(GizmoState.Retracted);
				}
				_movementAidGizmo.OnSelected();
			}
			else
			{
				_movementAidGizmo.OnDeselected();
				SetGizmoState(GizmoState.Extended);
			}
		}

		private GizmoState ToggleGizmoState()
		{
			GizmoState gizmoState;
			switch (_gizmoState)
			{
			case GizmoState.Extended:
				gizmoState = GizmoState.Retracted;
				break;
			case GizmoState.Retracted:
				gizmoState = GizmoState.Extended;
				break;
			default:
				Debug.LogError($"Unsupported maneuver node gizmo state: {_gizmoState}");
				gizmoState = GizmoState.Extended;
				break;
			}
			SetGizmoState(gizmoState);
			return gizmoState;
		}

		private void UpdateDeltaVAxisContributions()
		{
			Vector3d deltaV = _deltaV;
			DeltaVPrograde = Vector3d.Dot(deltaV, _progradeReferenceVec);
			DeltaVRadial = Vector3d.Dot(deltaV, _radialReferenceVec);
			DeltaVNormal = Vector3d.Dot(deltaV, _normalReferenceVec);
		}

		private void UpdateManeuverVectors()
		{
			IOrbit orbit;
			switch (_options.BurnGizmoAlignment)
			{
			case GizmoAlignmentType.ReferenceOrbit:
				orbit = _referenceOrbit;
				break;
			case GizmoAlignmentType.NewOrbit:
				orbit = base.OrbitInfo.OrbitNode.Orbit;
				break;
			default:
				Debug.LogError($"Unexpected gizmo alignment type: {_options.BurnGizmoAlignment}");
				orbit = _referenceOrbit;
				break;
			}
			_progradeVec = orbit.Velocity.normalized;
			_normalVec = orbit.OrbitalPlaneNormal;
			_radialVec = Vector3d.Cross(_normalVec, _progradeVec).normalized;
			for (int i = 0; i < _maneuverNodeAdjustors.Length; i++)
			{
				_maneuverNodeAdjustors[i].UpdateVector();
			}
		}

		private void UpdateOrbit(bool propagateChanges)
		{
			Vector3d v = ReferenceOrbit.Velocity + DeltaV;
			_ = base.OrbitInfo.OrbitNode;
			Orbit newOrbit = new Orbit(ReferenceOrbit.Position, v, ReferenceOrbit.Time, ReferenceOrbit.PrimaryMass);
			base.OrbitInfo.UpdateOrbit(newOrbit);
			if (!OrphanIfNecessary())
			{
				if (propagateChanges)
				{
					(base.ListNode.Next?.Value)?.SendPreviousNodeOrbitChanged(base.OrbitInfo.OrbitNode.Orbit);
				}
				_orbitLine.UpdateLine();
			}
		}

		private void UpdatePositions()
		{
			Vector3d solarPositionAtCurrent = _drawModeProvider.DrawMode.GetSolarPositionAtCurrent(base.OrbitInfo);
			Vector3d nodeWorldPosition = base.OrbitInfo.CoordinateConverter.ConvertSolarToMapView(solarPositionAtCurrent);
			_nodeWorldPosition = nodeWorldPosition;
			if (_infoCanvas.worldCamera != null)
			{
				_nodeScreenPosition = Utilities.GameWorldToScreenPoint(_infoCanvas.worldCamera, (Vector3)_nodeWorldPosition);
				_cameraDistance = Vector3d.Distance(_nodeWorldPosition, _infoCanvas.worldCamera.transform.position);
			}
		}

		private void UpdateReferenceOrbitPeriod()
		{
			IChainableOrbit value = base.ListNode.Previous.Value;
			IOrbit orbit = value.OrbitNode.Orbit;
			_supportsVariableReferenceOrbitPeriod = CanSupportVariableReferenceOrbitPeriod(value, base.ListNode?.Next?.Value);
			if (!_supportsVariableReferenceOrbitPeriod)
			{
				ReferenceOrbitPeriod = 0;
				return;
			}
			int num = (int)((_referenceOrbit.Time - orbit.Time) / orbit.Period);
			if (num < ReferenceOrbitPeriod)
			{
				ReferenceOrbitPeriod = Mathf.Max(num, 0);
			}
		}

		private void UpdateReferenceOrbitVectors()
		{
			_progradeReferenceVec = _referenceOrbit.Velocity.normalized;
			_normalReferenceVec = _referenceOrbit.OrbitalPlaneNormal;
			_radialReferenceVec = Vector3d.Cross(_normalReferenceVec, _progradeReferenceVec).normalized;
		}

		private void UpdateUi()
		{
			if (_craftInfo.Data.ShowOrbitLine)
			{
				if (_nodeScreenPosition.z > 0f)
				{
					_maneuverNodeAdjustorContainer.gameObject.SetActive(value: true);
					_selectNodeIcon.transform.position = (Vector2)_nodeScreenPosition;
					_lockedNodeIcon.transform.position = _selectNodeIcon.transform.position;
					double num = Mathd.Tan(0.01745329 * (double)(4 * (Game.Instance.Device.IsMobileBuild ? 3 : 2))) * _cameraDistance * (double)Game.UiScale;
					Vector3d vector3d = (_camera.transform.up + _camera.transform.right).normalized;
					Vector3d vector3d2 = _nodeWorldPosition + vector3d * num;
					if (_infoCanvas.isActiveAndEnabled)
					{
						_deleteNodeIcon.transform.position = (Vector2)Utilities.GameWorldToScreenPoint(_infoCanvas.worldCamera, (Vector3)vector3d2);
					}
					_selectNodeIcon.enabled = true;
					switch (_gizmoState)
					{
					case GizmoState.Retracted:
						_lockedNodeIcon.enabled = false;
						_deleteNodeIcon.enabled = false;
						break;
					case GizmoState.Extended:
						_lockedNodeIcon.enabled = base.Locked;
						_deleteNodeIcon.enabled = true;
						break;
					default:
						Debug.Log($"Unsupported gizmo state {_gizmoState}");
						break;
					}
				}
				else
				{
					_maneuverNodeAdjustorContainer.gameObject.SetActive(value: false);
					CompleteGizmoAnimations();
					_lockedNodeIcon.enabled = false;
					_selectNodeIcon.enabled = false;
					_deleteNodeIcon.enabled = false;
				}
			}
			else
			{
				if (_gizmoState == GizmoState.Extended)
				{
					SetGizmoState(GizmoState.Retracted);
				}
				_lockedNodeIcon.enabled = false;
				_selectNodeIcon.enabled = false;
				_deleteNodeIcon.enabled = false;
			}
		}
	}
}
