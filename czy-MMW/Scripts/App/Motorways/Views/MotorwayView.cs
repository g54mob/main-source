using System;
using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Constants;
using Motorways.Models;
using Motorways.Themes;
using Motorways.Utility;
using Rendering.RenderFeatures;
using UnityEngine;

namespace Motorways.Views
{
	public class MotorwayView : MonoBehaviour, IView, Motorway.IObserver, TileView.IObserver, IThemeComponent, ICreatedInScopeHandler, IReleasedFromScopeHandler, IReusable
	{
		public enum MotorwayComponentSortOrder
		{
			MountainBase = 0,
			MountainDots = 1,
			Shadow = 2,
			Outline = 3,
			Road = 4,
			CarShadow = 5,
			CarBody = 6,
			CarDetails = 7,
			CarHeadlightBeams = 8,
			CarHeadlights = 9,
			CarWindows = 10,
			Count = 11
		}

		private enum MotorwaySplineType
		{
			Mesh = 0,
			Lane = 1,
			Shadow = 2
		}

		private struct MotorwayViewColors
		{
			public Color mothballedRoad;

			public Color roadInner;

			public Color roadInnerNonPermanent;

			public Color roadOutline;

			public Color motorwayInner;

			public Color motorwayOuter;

			public Color shadow;
		}

		private static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("View.Motorway");

		[Dependency]
		private IScope _scope;

		[Dependency]
		private MotorwayVisualParameters _visualParameters;

		[Dependency]
		private TilemapView _tilemap;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private ClientUpgradeDatabase _clientUpgradeDatabase;

		[Dependency]
		private VisualConstantsData _visualConstants;

		private Motorway _clientMotorway;

		private MotorwayModel _model;

		private MotorwaySpline _spline;

		private readonly List<ClientTileEdit> _clientTileEdits = new List<ClientTileEdit>();

		private bool _rebuildMotorway = true;

		private bool _rebuildSplines = true;

		private bool _rebuildGeometry = true;

		private bool _reapplyPermanence = true;

		private bool _rebuildHazardStripes = true;

		private MotorwayViewColors _motorwayViewColors;

		public MotorwayHandleView handleView;

		[SerializeField]
		private InteractionCircleView _interactionCircleViewStart;

		[SerializeField]
		private InteractionCircleView _interactionCircleViewEnd;

		public GameObject shadowObject;

		private Vector2 _naturalMidpoint;

		private Vector2 _naturalTangent;

		private float _naturalStartHandleLength;

		private float _naturalEndHandleLength;

		public float HandleToleranceFactor = 0.1f;

		private readonly InertialFloat _handleDistanceFromMidpoint = new InertialFloat(0.7f, Easings.Functions.ElasticEaseOut);

		private Vector2 _handleDirectionFromMidpoint;

		private Vector2 _splineMidpoint;

		private float _referenceMidpointAngle;

		private float _referenceMidpointDistance;

		private Vector2 _referenceMotorwayDirection;

		private bool _hasCheckedReferenceMotorwayDirection;

		public float SplineHandleLengthFactor = 0.3f;

		public float RampExtrusion = 0.5f;

		public int SplineResolution = 20;

		public float ShadowOffsetFactor = 0.1f;

		public float MaxShadowOffset = 2f;

		private float _shadowOffset;

		private List<Vector2> _startToEndPath;

		private float _startToEndPathLength;

		private List<Vector2> _endToStartPath;

		private float _endToStartPathLength;

		private readonly TweenFloat _hazardStripeWidth = new TweenFloat();

		private readonly TweenFloat _hazardStripePermanenceOpacityFactor = new TweenFloat();

		private RoadState _visualRoadState;

		private static Mesh motorwayMesh = null;

		private const int LinearDistanceSampleCount = 10;

		private readonly float[] _linearDistanceTable = new float[10];

		private const int FloatsPerDepthSegment = 3;

		private const int MaxDepthSegments = 20;

		private const int DepthBufferSampleCount = 60;

		private float[] _depthBufferData = new float[60];

		private static readonly int ShadowTypeCount = Enum.GetNames(typeof(ShadowTypeRenderPass.ShadowType)).Length;

		private readonly float[] _shadowFadeouts = new float[2 * (ShadowTypeCount + 1)];

		private const int HazardTapeMaxSamples = 200;

		private MotorwayModel _visualMotorwayModel;

		private LaneModel _visualStartToEndLane;

		private LaneModel _visualEndToStartLane;

		private Vector2Int _visualStartCoordinates;

		private Vector2Int _visualEndCoordinates;

		private Vector2 _visualSplineMidpoint;

		private TileView _startTileView;

		private TileView _endTileView;

		private Motorway _replacedMotorway;

		[SerializeField]
		private MeshRenderer _motorwayMeshRenderer;

		[SerializeField]
		private MeshRenderer _shadowMeshRenderer;

		private MaterialPropertyBlock _materialPropertyBlock;

		private MaterialPropertyBlock _shadowMaterialPropertyBlock;

		private readonly TweenVector3 _startInteractionCirclePositionTween = new TweenVector3();

		private readonly TweenVector3 _endInteractionCirclePositionTween = new TweenVector3();

		private bool _isDraggingHandle;

		private bool _isBeingEdited;

		private bool _isMotorwayOnTop;

		private bool _resortMotorwaysWhenSpringingIsComplete;

		private bool skipModelPoints;

		private const int LanePathResolution = 20;

		[Dependency]
		public City City { get; private set; }

		public TilemapView Tilemap => _tilemap;

		public MotorwaySpline Spline => _spline;

		public Motorway Motorway => _clientMotorway;

		public MotorwayModel Model => _model;

		public bool IsBeingEdited
		{
			get
			{
				return _isBeingEdited;
			}
			set
			{
				if (!_isBeingEdited && value)
				{
					BringToTop();
				}
				if (_isBeingEdited && !value)
				{
					_isMotorwayOnTop = false;
					_tilemap.RecalculateDefaultMotorwaySortOrder();
					_tilemap.ResortMotorwaysOnNextTick();
				}
				_isBeingEdited = value;
			}
		}

		public bool IsDraggingHandle
		{
			set
			{
				if (_isDraggingHandle != value)
				{
					_isDraggingHandle = value;
					if (_isDraggingHandle)
					{
						BringToTop();
						_handleDistanceFromMidpoint.Hold();
					}
					else
					{
						_resortMotorwaysWhenSpringingIsComplete = true;
						_handleDistanceFromMidpoint.SpringBackToExtents();
					}
				}
			}
		}

		public Vector2 RawHandlePosition
		{
			get
			{
				return _naturalMidpoint + _handleDirectionFromMidpoint * _handleDistanceFromMidpoint.RawValue;
			}
			set
			{
				Vector2 vector = value - _naturalMidpoint;
				_handleDistanceFromMidpoint.RawValue = vector.magnitude;
				if (_handleDistanceFromMidpoint.RawValue > 0f)
				{
					_handleDirectionFromMidpoint = vector / _handleDistanceFromMidpoint.RawValue;
				}
				else
				{
					_handleDirectionFromMidpoint = Vector3.zero;
				}
			}
		}

		public Vector2 HandlePosition => _naturalMidpoint + _handleDirectionFromMidpoint * _handleDistanceFromMidpoint.ConstrainedValue;

		public float HandleTension
		{
			get
			{
				if (_handleDistanceFromMidpoint.IsWithinConstraints)
				{
					return 0f;
				}
				return (_handleDistanceFromMidpoint.RawValue - _handleDistanceFromMidpoint.ConstrainedValue) / _handleDistanceFromMidpoint.Max;
			}
		}

		private Vector2Int StartCoordinates => _clientMotorway.StartCoordinates;

		private TileDirection StartDirection => _clientMotorway.StartDirection;

		private Vector2Int EndCoordinates => _clientMotorway.EndCoordinates;

		private TileDirection EndDirection => _clientMotorway.EndDirection;

		private bool IsMotorwayMothballed
		{
			get
			{
				if (_visualRoadState != RoadState.Mothballed)
				{
					return _visualRoadState == RoadState.None;
				}
				return true;
			}
		}

		public void Initialize(TilemapView tilemap, int id, int number, RoadState visualRoadState, MotorwayView replacedMotorwayView = null)
		{
			Log.Info("Creating MotorwayView, id {0}.", id);
			ImmediatelyTransitionVisualRoadStateTo(visualRoadState);
			_clientMotorway = new Motorway();
			_clientMotorway.Initialize(tilemap, id, number);
			_clientMotorway.Subscribe(this);
			tilemap.ResortMotorwaysOnNextTick();
			if (Diagnostics.Verify(handleView != null, "MotorwayHandleView is not set on MotorwayView prefab"))
			{
				handleView.Initialize(_scope, this, number);
			}
			_visualParameters.OnParameterChanged += OnVisualParameterChanged;
			_shadowMeshRenderer.enabled = true;
			_materialPropertyBlock.Clear();
			_materialPropertyBlock.SetInt(ShaderConstants.LinearDistanceTableLength, 10);
			_materialPropertyBlock.SetInt(ShaderConstants.HazardStripeLastIndex, 199);
			_referenceMidpointAngle = 0f;
			_referenceMidpointDistance = 0f;
			if (replacedMotorwayView != null)
			{
				Vector2 vector = replacedMotorwayView._splineMidpoint - replacedMotorwayView._naturalMidpoint;
				float magnitude = vector.magnitude;
				if (magnitude > 0.1f)
				{
					Vector2 vector2 = TilemapView.GetWorldPositionForCoordinates(replacedMotorwayView.EndCoordinates) - TilemapView.GetWorldPositionForCoordinates(replacedMotorwayView.StartCoordinates);
					float magnitude2 = vector2.magnitude;
					vector2 /= magnitude2;
					Vector2 rhs = vector / magnitude;
					float num = Mathf.Acos(Vector2.Dot(vector2, rhs));
					_referenceMidpointAngle = num * Mathf.Sign(Vector2.Dot(vector2.GetTangent(), rhs));
					_referenceMidpointDistance = magnitude / magnitude2;
					_referenceMotorwayDirection = vector2;
					_hasCheckedReferenceMotorwayDirection = false;
				}
				_replacedMotorway = replacedMotorwayView.Motorway;
				_replacedMotorway.Subscribe(this);
			}
		}

		private void OnVisualParameterChanged()
		{
			_rebuildGeometry = true;
			_reapplyPermanence = true;
			RebuildMotorwayView();
		}

		public void SetModel(MotorwayModel motorwayModel)
		{
			_model = motorwayModel;
			_model.Subscribe(this);
		}

		public void AddEdit(ClientTileEdit edit)
		{
			_clientTileEdits.Add(edit);
			_rebuildMotorway = true;
		}

		public void RemoveEdit(ClientTileEdit edit)
		{
			_clientTileEdits.Remove(edit);
			_rebuildMotorway = true;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_replacedMotorway != null)
			{
				Fix64 permanenceProgress = _replacedMotorway.PermanenceProgress;
				_clientMotorway.SetPermanence(permanenceProgress);
			}
			if (_rebuildMotorway)
			{
				RebuildMotorway();
			}
			if (_startInteractionCirclePositionTween.IsActive)
			{
				_interactionCircleViewStart.transform.position = _startInteractionCirclePositionTween.Tick(timeInterval.Delta);
			}
			if (_endInteractionCirclePositionTween.IsActive)
			{
				_interactionCircleViewEnd.transform.position = _endInteractionCirclePositionTween.Tick(timeInterval.Delta);
			}
			_handleDistanceFromMidpoint.Tick(timeInterval.Delta);
			if (_splineMidpoint != HandlePosition)
			{
				_splineMidpoint = HandlePosition;
				_rebuildGeometry = true;
			}
			if (_resortMotorwaysWhenSpringingIsComplete && !_handleDistanceFromMidpoint.IsSpringing)
			{
				_isMotorwayOnTop = false;
				_resortMotorwaysWhenSpringingIsComplete = false;
				_tilemap.ResortMotorwaysOnNextTick();
			}
			RebuildMotorwayView();
			if (_reapplyPermanence)
			{
				SetPermanenceProgress(City.Rules.RoadsBecomePermanentOverTime ? _clientMotorway.PermanenceProgress : Fix64.Zero);
				RecalculateHazardStripeVisibility();
				_reapplyPermanence = false;
			}
			bool flag = false;
			if (_hazardStripeWidth.IsActive)
			{
				_hazardStripeWidth.Tick(timeInterval.Delta);
				flag = true;
			}
			if (_hazardStripePermanenceOpacityFactor.IsActive)
			{
				_hazardStripePermanenceOpacityFactor.Tick(timeInterval.Delta);
			}
			if (_hazardStripeWidth.Value > 0f || flag)
			{
				if (_rebuildHazardStripes)
				{
					RebuildHazardStripes();
				}
				UpdateHazardStripesShaderParameters();
			}
			_motorwayMeshRenderer.SetPropertyBlock(_materialPropertyBlock);
			if (_clientMotorway.State == RoadState.None && _model == null)
			{
				Log.Info("Closing MotorwayView {0}.", _clientMotorway.Id);
				return TickResult.Destroy;
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void TransitionTo(RoadState toState)
		{
			if (toState == RoadState.Mothballed || _visualRoadState == RoadState.Mothballed)
			{
				_tilemap.RecalculateDefaultMotorwaySortOrder();
				_tilemap.ResortMotorwaysOnNextTick();
			}
			_visualRoadState = toState;
			RecalculateHazardStripeVisibility();
		}

		private void RecalculateHazardStripeVisibility()
		{
			bool flag = City.Rules.RoadsBecomePermanentOverTime && !_clientMotorway.IsPermanent;
			bool flag2 = false;
			bool flag3 = true;
			bool flag4 = true;
			switch (_visualRoadState)
			{
			case RoadState.Mothballed:
				flag2 = true;
				break;
			case RoadState.Planned:
				flag2 = true;
				flag3 = false;
				break;
			case RoadState.Active:
				flag2 = flag;
				flag4 = !flag;
				break;
			}
			bool flag5 = _hazardStripeWidth.End > 0f;
			if (flag5 != flag2)
			{
				float num = Mathf.Clamp01(_hazardStripeWidth.Value / _visualParameters.maxHazardStripeWidth);
				if (flag3 && !_viewClient.OnFirstFrame)
				{
					if (flag2)
					{
						_hazardStripeWidth.Start(_hazardStripeWidth.Value, _visualParameters.maxHazardStripeWidth, (1f - num) * _visualParameters.hazardStripeInDuration, _visualParameters.hazardStripeAnimationFunction);
					}
					else
					{
						_hazardStripeWidth.Start(_hazardStripeWidth.Value, 0f, num * _visualParameters.hazardStripeOutDuration, _visualParameters.hazardStripeAnimationFunction);
					}
				}
				else
				{
					_hazardStripeWidth.Set(flag2 ? _visualParameters.maxHazardStripeWidth : 0f);
				}
			}
			if ((!City.Rules.RoadsBecomePermanentOverTime || _hazardStripePermanenceOpacityFactor.End <= 0f) != flag4)
			{
				float num2 = ((!flag4) ? 1 : 0);
				if (!flag5 || _viewClient.OnFirstFrame)
				{
					_hazardStripePermanenceOpacityFactor.Set(num2);
				}
				else
				{
					_hazardStripePermanenceOpacityFactor.Start(_hazardStripePermanenceOpacityFactor.Value, num2, _visualParameters.hazardStripeOpacityFactorFadeDuration, Easings.Functions.SineEaseInOut);
				}
			}
		}

		private void ImmediatelyTransitionVisualRoadStateTo(RoadState roadState)
		{
			switch (roadState)
			{
			case RoadState.Planned:
			case RoadState.Mothballed:
				_hazardStripeWidth.Set(_visualParameters.maxHazardStripeWidth);
				break;
			case RoadState.None:
			case RoadState.Active:
				_hazardStripeWidth.Set(0f);
				break;
			}
			_visualRoadState = roadState;
		}

		public void OnMotorwayChanged(Motorway motorway, Motorway.ChangeFlags changes)
		{
			if (motorway == _model)
			{
				if (!_rebuildMotorway)
				{
					Log.Info("Simulation-side version of motorway {0} changed, client version scheduled for rebuild.", _model.Id);
					_rebuildMotorway = true;
				}
				int num = 0;
				while (num < _clientTileEdits.Count)
				{
					if (_clientTileEdits[num].isScheduledOnSimulation)
					{
						_clientUpgradeDatabase.RemoveTileEdit(_clientTileEdits[num]);
						_clientTileEdits.RemoveAt(num);
					}
					else
					{
						num++;
					}
				}
				if (motorway.State == RoadState.Active && _replacedMotorway != null)
				{
					_replacedMotorway.Unsubscribe(this);
					_replacedMotorway = null;
				}
				if (motorway.State == RoadState.None)
				{
					RebuildMotorway();
					_model = null;
				}
			}
			if (motorway == _clientMotorway)
			{
				if (changes.HasFlag(Motorway.ChangeFlags.State))
				{
					_rebuildGeometry = true;
				}
				if ((changes & (Motorway.ChangeFlags.StartTile | Motorway.ChangeFlags.EndTile)) != 0)
				{
					_rebuildGeometry = true;
					_rebuildSplines = true;
				}
				if (changes.HasFlag(Motorway.ChangeFlags.Permanence))
				{
					_reapplyPermanence = true;
				}
			}
			if (motorway == _replacedMotorway && changes.HasFlag(Motorway.ChangeFlags.State) && motorway.State == RoadState.None)
			{
				_replacedMotorway.Unsubscribe(this);
				_replacedMotorway = null;
			}
		}

		public void OnTileViewChanged(TileView changedTileView)
		{
			if (_startTileView != null && _endTileView != null)
			{
				if (changedTileView.Tile == _startTileView.Tile)
				{
					_startInteractionCirclePositionTween.Start(_interactionCircleViewStart.transform.position, TilemapView.GetWorldPositionForCoordinates(_visualStartCoordinates) + (Vector3)_startTileView.InteractionCircleOffset, _visualConstants.InteractionCircleOffsetAdjustmentDuration, _visualConstants.InteractionCircleAndTrafficLightAdjustmentEasingFunction);
					return;
				}
				if (changedTileView.Tile == _endTileView.Tile)
				{
					_endInteractionCirclePositionTween.Start(_interactionCircleViewEnd.transform.position, TilemapView.GetWorldPositionForCoordinates(_visualEndCoordinates) + (Vector3)_endTileView.InteractionCircleOffset, _visualConstants.InteractionCircleOffsetAdjustmentDuration, _visualConstants.InteractionCircleAndTrafficLightAdjustmentEasingFunction);
					return;
				}
				Diagnostics.FailAssert("MotorwayView.OnTileViewChanged called for tile {0} which is neither the start tile {1} or the end tile {2}", changedTileView, _startTileView.Tile, _endTileView.Tile);
			}
		}

		private void SetPermanenceProgress(Fix64 modelProgress)
		{
			float permanenceProgress = _visualConstants.DryingInteractionCircleFalloff.Evaluate((float)modelProgress);
			_interactionCircleViewStart.SetPermanenceProgress(permanenceProgress);
			_interactionCircleViewEnd.SetPermanenceProgress(permanenceProgress);
			UpdateRoadColorShaderParameter();
		}

		public void ReconfigurePermanenceVisibility()
		{
			SetPermanenceProgress(Fix64.Zero);
			RecalculateHazardStripeVisibility();
		}

		public void OnCreatedInScope(IScope scope)
		{
			if (motorwayMesh == null)
			{
				ConstructMotorwayMesh(_visualParameters.splineSegmentCount);
			}
			MeshFilter component = _motorwayMeshRenderer.GetComponent<MeshFilter>();
			if (Diagnostics.Verify(component != null, "Could not find MeshFilter component for motorway"))
			{
				component.sharedMesh = motorwayMesh;
			}
			MeshFilter component2 = _shadowMeshRenderer.GetComponent<MeshFilter>();
			if (Diagnostics.Verify(component2 != null, "Could not MeshFilter component for shadow motorway shadow."))
			{
				component2.sharedMesh = motorwayMesh;
			}
			_materialPropertyBlock = new MaterialPropertyBlock();
			_shadowMaterialPropertyBlock = new MaterialPropertyBlock();
			_spline = new MotorwaySpline();
		}

		private void BringToTop()
		{
			if (FeatureToggle.IsFeatureEnabled(Feature.BringMotorwaysToTopWhenEdited))
			{
				Diagnostics.Log.Info("MotorwayView", "Bring to top {0}", Motorway?.Number);
				if (_spline?.spline != null)
				{
					_depthBufferData[0] = 0f;
					_depthBufferData[1] = 100000000f;
					_depthBufferData[2] = -6.1f;
					_materialPropertyBlock.SetFloatArray(ShaderConstants.DepthSegmentBuffer, _depthBufferData);
					_materialPropertyBlock.SetInt(ShaderConstants.DepthSegmentBufferLength, 3);
					_isMotorwayOnTop = true;
				}
			}
		}

		public void SetMotorwayDepth(MotorwaySorter.MotorwayDepth motorwayDepth)
		{
			if (_isMotorwayOnTop)
			{
				return;
			}
			List<float> list = new List<float>();
			float item = 0f;
			foreach (MotorwaySorter.MotorwayDepthSegment depthSegment in motorwayDepth.DepthSegments)
			{
				list.Add(item);
				list.Add(depthSegment.endDistance);
				list.Add(depthSegment.depth);
				item = depthSegment.endDistance;
			}
			float item2 = _spline.spline.Length();
			if (motorwayDepth.DepthSegments.Count == 0)
			{
				list.Add(0f);
				list.Add(item2);
				float worldHeightForMotorway = GetWorldHeightForMotorway(Motorway);
				list.Add(worldHeightForMotorway);
			}
			else
			{
				list.Add(item);
				list.Add(item2);
				list.Add(motorwayDepth.DepthSegments[motorwayDepth.DepthSegments.Count - 1].depth);
			}
			for (int i = 0; i < list.Count; i++)
			{
				_depthBufferData[i] = list[i];
			}
			_materialPropertyBlock.SetFloatArray(ShaderConstants.DepthSegmentBuffer, _depthBufferData);
			_materialPropertyBlock.SetInt(ShaderConstants.DepthSegmentBufferLength, list.Count);
		}

		private float GetWorldHeightForMotorway(Motorway motorway)
		{
			return -3f + -1.1999998f * ((float)_tilemap.GetDefaultSortOrderForMotorway(motorway) / (float)_tilemap.MotorwayCount);
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_clientMotorway != null)
			{
				_clientMotorway.Unsubscribe(this);
				_clientMotorway = null;
			}
			if (_replacedMotorway != null)
			{
				_replacedMotorway.Unsubscribe(this);
				_replacedMotorway = null;
			}
			if (_model != null)
			{
				_model.Unsubscribe(this);
				_model = null;
			}
			if (_startTileView != null)
			{
				_startTileView.Unsubscribe(this);
			}
			if (_endTileView != null)
			{
				_endTileView.Unsubscribe(this);
			}
		}

		public void Reset()
		{
			_clientTileEdits.Clear();
			_rebuildMotorway = true;
			_rebuildSplines = true;
			_rebuildGeometry = true;
			_reapplyPermanence = true;
			_rebuildHazardStripes = true;
			_clientMotorway = null;
			_model = null;
			_naturalMidpoint = default(Vector2);
			_naturalTangent = default(Vector2);
			_naturalStartHandleLength = 0f;
			_naturalEndHandleLength = 0f;
			_handleDistanceFromMidpoint.Reset();
			_handleDirectionFromMidpoint = default(Vector2);
			_splineMidpoint = default(Vector2);
			_referenceMidpointAngle = 0f;
			_referenceMidpointDistance = 0f;
			_referenceMotorwayDirection = default(Vector2);
			_hasCheckedReferenceMotorwayDirection = false;
			_shadowOffset = 0f;
			_startToEndPath = null;
			_startToEndPathLength = 0f;
			_endToStartPath = null;
			_endToStartPathLength = 0f;
			_visualRoadState = RoadState.None;
			_hazardStripeWidth.Reset();
			_hazardStripePermanenceOpacityFactor.Reset();
			_visualStartCoordinates = default(Vector2Int);
			_visualEndCoordinates = default(Vector2Int);
			_visualSplineMidpoint = default(Vector2);
			_motorwayViewColors = default(MotorwayViewColors);
			_depthBufferData = new float[60];
			_isBeingEdited = false;
			_isMotorwayOnTop = false;
			_resortMotorwaysWhenSpringingIsComplete = false;
			_startInteractionCirclePositionTween.Reset();
			_endInteractionCirclePositionTween.Reset();
			_materialPropertyBlock.Clear();
			_visualParameters.OnParameterChanged -= OnVisualParameterChanged;
			_shadowMeshRenderer.enabled = false;
			_replacedMotorway = null;
		}

		private void RebuildMotorway()
		{
			_rebuildMotorway = false;
			if (_model != null)
			{
				_model.CloneInto(_clientMotorway);
			}
			else
			{
				_clientMotorway.Clear();
			}
			foreach (ClientTileEdit clientTileEdit in _clientTileEdits)
			{
				clientTileEdit.edit.ApplyToAffectedMotorway(_clientMotorway);
			}
			if (!_rebuildSplines)
			{
				return;
			}
			Vector2 vector = TilemapView.GetWorldPositionForCoordinates(StartCoordinates);
			Vector2 vectorForDirection = TileUtilities.GetVectorForDirection(StartDirection);
			Vector2 vector2 = TilemapView.GetWorldPositionForCoordinates(EndCoordinates);
			Vector2 vectorForDirection2 = TileUtilities.GetVectorForDirection(EndDirection);
			Vector2 vector3 = vector2 - vector;
			float magnitude = vector3.magnitude;
			vector3 /= magnitude;
			Vector3 vector4 = (vector2 - vector) * 0.5f + vector;
			_naturalMidpoint = vector4;
			_naturalTangent = vector3;
			float num = Vector2.Dot(vector3, vectorForDirection);
			float num2 = Vector2.Dot(-vector3, vectorForDirection2);
			if (num >= 0f && num2 >= 0f)
			{
				float num3 = (float)TilemapModel.HalfTileWidth;
				float num4 = Mathf.Lerp(0.3f, 1f, num) * SplineHandleLengthFactor * magnitude;
				float num5 = Mathf.Lerp(0.3f, 1f, num2) * SplineHandleLengthFactor * magnitude;
				Spline.RasterizedSpline rasterizedSpline = new Spline.BezierSpline(vector + vectorForDirection * num3, vector + vectorForDirection * (num3 + num4), vector2 + vectorForDirection2 * (num3 + num5), vector2 + vectorForDirection2 * num3).Rasterize(SplineResolution);
				List<LineSegment> list = new List<LineSegment>(rasterizedSpline.Resolution - 1);
				for (int i = 0; i < rasterizedSpline.Resolution - 1; i++)
				{
					list.Add(new LineSegment(rasterizedSpline.Positions[i], rasterizedSpline.Positions[i + 1]));
				}
				float num6 = 0f;
				foreach (LineSegment item in list)
				{
					num6 += item.Length;
				}
				float num7 = num6 * 0.5f;
				for (int j = 0; j < list.Count; j++)
				{
					LineSegment lineSegment = list[j];
					if (num7 < lineSegment.Length)
					{
						float t = num7 / lineSegment.Length;
						_naturalMidpoint = lineSegment.GetPosition(t);
						Vector2 direction = lineSegment.Direction;
						Vector2 vector5 = ((j <= 0) ? direction : list[j - 1].Direction);
						Vector2 vector6 = ((j >= list.Count - 1) ? direction : list[j + 1].Direction);
						_naturalTangent = Vector2.Lerp((vector5 + direction) * 0.5f, (direction + vector6) * 0.5f, t);
						break;
					}
					num7 -= lineSegment.Length;
				}
				_naturalStartHandleLength = num4;
				_naturalEndHandleLength = num5;
			}
			float num8 = magnitude * HandleToleranceFactor;
			_handleDistanceFromMidpoint.Min = 0f - num8;
			_handleDistanceFromMidpoint.Max = num8;
			_handleDistanceFromMidpoint.Hold();
			if (_referenceMidpointDistance > 0f)
			{
				if (!_hasCheckedReferenceMotorwayDirection)
				{
					_hasCheckedReferenceMotorwayDirection = true;
					if (Vector2.Dot(_referenceMotorwayDirection, vector3) < 0f)
					{
						if (_referenceMidpointAngle < 0f)
						{
							_referenceMidpointAngle += (float)Math.PI;
						}
						else
						{
							_referenceMidpointAngle -= (float)Math.PI;
						}
					}
				}
				Vector2 vector7 = (_handleDirectionFromMidpoint = vector3.Rotated(0f - _referenceMidpointAngle));
				float num9 = Mathf.Clamp(_referenceMidpointDistance * magnitude, 0f, num8);
				_handleDistanceFromMidpoint.RawValue = num9;
				_splineMidpoint = _naturalMidpoint + vector7 * num9;
			}
			else
			{
				_splineMidpoint = _naturalMidpoint;
				_handleDistanceFromMidpoint.RawValue = 0f;
			}
			_shadowOffset = Mathf.Min(magnitude * ShadowOffsetFactor, MaxShadowOffset);
			_rebuildSplines = false;
		}

		private void UpdateShaderParametersAndKeywords()
		{
			UpdateMotorwayOpacity();
			_materialPropertyBlock.SetFloat(ShaderConstants.MinMotorwayWorldHeight, -3f);
			if (_clientMotorway != null)
			{
				_materialPropertyBlock.SetInt(ShaderConstants.MotorwayId, _clientMotorway.Id);
			}
			_materialPropertyBlock.SetFloat(ShaderConstants.RoadWidth, _visualParameters.roadWidth);
			_materialPropertyBlock.SetFloat(ShaderConstants.RoadOutlineWidth, _visualParameters.roadOutlineWidth);
			_materialPropertyBlock.SetFloat(ShaderConstants.BlendingSize, _visualParameters.blendingSize);
			_materialPropertyBlock.SetFloat(ShaderConstants.HazardFadeoutOffset, _visualParameters.hazardStripeFadeoutOffset);
			_materialPropertyBlock.SetFloat(ShaderConstants.HazardFadeoutDistance, _visualParameters.hazardFadeoutDistance);
			_materialPropertyBlock.SetFloat(ShaderConstants.FadeoutDistance, _visualParameters.splineEndFadeoutDistance);
			UpdateHazardStripesShaderParameters();
			UpdateRoadColorShaderParameter();
			if (!IsMotorwayMothballed)
			{
				_shadowMaterialPropertyBlock.SetFloat(ShaderConstants.RoadWidth, _visualParameters.roadWidth);
				_shadowMaterialPropertyBlock.SetFloat(ShaderConstants.RoadOutlineWidth, _visualParameters.roadOutlineWidth);
				_shadowMaterialPropertyBlock.SetFloat(ShaderConstants.BlendingSize, _visualParameters.blendingSize);
			}
		}

		private void UpdateRoadColorShaderParameter()
		{
			if (City.Rules.RoadsBecomePermanentOverTime && (_visualRoadState == RoadState.Active || _visualRoadState == RoadState.Planned))
			{
				float time = (float)_clientMotorway.PermanenceProgress;
				float t = _visualConstants.DryingRoadFalloff.Evaluate(time);
				Color value = Color.Lerp(_motorwayViewColors.roadInnerNonPermanent, _motorwayViewColors.roadInner, t);
				_materialPropertyBlock.SetColor(ShaderConstants.RoadColor, value);
			}
			else
			{
				_materialPropertyBlock.SetColor(ShaderConstants.RoadColor, (_visualRoadState == RoadState.Mothballed) ? _motorwayViewColors.mothballedRoad : _motorwayViewColors.roadInner);
			}
		}

		public void UpdateMotorwayOpacity()
		{
			float num = (IsMotorwayMothballed ? _visualParameters.mothballedOpacity : 1f);
			_materialPropertyBlock.SetFloat(ShaderConstants.MotorwayInnerOpacity, num * _tilemap.ViewModeOpacity);
			_materialPropertyBlock.SetFloat(ShaderConstants.MotorwayOuterOpacity, _tilemap.ViewModeOpacity);
		}

		private void UpdateHazardStripesShaderParameters()
		{
			float value = _hazardStripeWidth.Value;
			_materialPropertyBlock.SetFloat(ShaderConstants.HazardStripeWidth, value);
			_materialPropertyBlock.SetFloat(ShaderConstants.HalfHazardStripeWidth, value * 0.5f);
			_materialPropertyBlock.SetFloat(ShaderConstants.DistanceBetweenHazardStripes, _visualParameters.splineDistanceBetweenStripes);
			if (City.Rules.RoadsBecomePermanentOverTime)
			{
				float num = _visualConstants.DryingMotorwayHazardStripesFalloff.Evaluate((float)_clientMotorway.PermanenceProgress);
				_materialPropertyBlock.SetFloat(ShaderConstants.HazardStripeOpacity, Mathf.Lerp(1f, 1f - num, _hazardStripePermanenceOpacityFactor.Value));
			}
			else
			{
				_materialPropertyBlock.SetFloat(ShaderConstants.HazardStripeOpacity, 1f);
			}
		}

		public void RebuildMotorwayView()
		{
			if (!_rebuildGeometry || _clientMotorway == null || _clientMotorway.StartCoordinates == _clientMotorway.EndCoordinates)
			{
				return;
			}
			if (_visualRoadState != _clientMotorway.State)
			{
				TransitionTo(_clientMotorway.State);
			}
			bool flag = _visualRoadState != RoadState.None;
			_motorwayMeshRenderer.enabled = flag;
			bool flag2 = _visualRoadState == RoadState.Mothballed || _visualRoadState == RoadState.None;
			_shadowMeshRenderer.enabled = !flag2;
			if (handleView != null)
			{
				handleView.gameObject.SetActive(!flag2);
			}
			if (_interactionCircleViewStart != null)
			{
				_interactionCircleViewStart.gameObject.SetActive(!flag2);
			}
			if (_interactionCircleViewEnd != null)
			{
				_interactionCircleViewEnd.gameObject.SetActive(!flag2);
			}
			if (!flag || !_rebuildGeometry)
			{
				return;
			}
			UpdateShaderParametersAndKeywords();
			_materialPropertyBlock.SetColor(ShaderConstants.MotorwayColor, _motorwayViewColors.motorwayInner);
			_materialPropertyBlock.SetColor(ShaderConstants.OutlineColor, _motorwayViewColors.roadOutline);
			_materialPropertyBlock.SetColor(ShaderConstants.MotorwayOutlineColor, _motorwayViewColors.motorwayOuter);
			_materialPropertyBlock.SetColor(ShaderConstants.ShadowColor, _motorwayViewColors.shadow);
			_shadowMaterialPropertyBlock.SetColor(ShaderConstants.ShadowColor, _motorwayViewColors.shadow);
			_motorwayMeshRenderer.sortingOrder = GetSortOrderIndexForMotorwayComponent(MotorwayComponentSortOrder.Road);
			_shadowFadeouts[0] = 0f;
			_shadowFadeouts[1] = 0f;
			for (int i = 0; i < _visualParameters.shadowFadeouts.Length; i++)
			{
				ShadowTypeFadeouts shadowTypeFadeouts = _visualParameters.shadowFadeouts[i];
				int num = 2 * (i + 1);
				_shadowFadeouts[num] = shadowTypeFadeouts.startDistance;
				_shadowFadeouts[num + 1] = shadowTypeFadeouts.endDistance;
			}
			_materialPropertyBlock.SetFloatArray(ShaderConstants.ShadowFadeoutBuffer, _shadowFadeouts);
			bool flag3 = _visualStartCoordinates != _clientMotorway.StartCoordinates || _visualEndCoordinates != _clientMotorway.EndCoordinates || _visualSplineMidpoint != _splineMidpoint;
			if (_visualMotorwayModel != Model || (Model != null && (_visualStartToEndLane != Model.startToEndLane || _visualEndToStartLane != Model.endToStartLane)) || flag3)
			{
				_visualMotorwayModel = Model;
				if (Model != null)
				{
					_visualStartToEndLane = Model.startToEndLane;
					_visualEndToStartLane = Model.endToStartLane;
				}
				else
				{
					_visualStartToEndLane = null;
					_visualEndToStartLane = null;
				}
				RebuildLanePaths();
			}
			if (flag3)
			{
				_visualStartCoordinates = _clientMotorway.StartCoordinates;
				_visualEndCoordinates = _clientMotorway.EndCoordinates;
				_visualSplineMidpoint = _splineMidpoint;
				Vector4[] array = _spline.PackSplineSegments();
				_materialPropertyBlock.SetVectorArray(ShaderConstants.SplineSegments, array);
				_spline.CalculateLinearDistanceLookupTable(_linearDistanceTable);
				_materialPropertyBlock.SetFloatArray(ShaderConstants.LinearDistanceTable, _linearDistanceTable);
				_rebuildHazardStripes = true;
				if (handleView != null)
				{
					handleView.SetHandlePosition(_visualSplineMidpoint);
				}
				if (_interactionCircleViewStart != null)
				{
					if (_startTileView != null)
					{
						_startTileView.Unsubscribe(this);
					}
					_startTileView = _tilemap.GetTileView(_visualStartCoordinates);
					_startTileView.Subscribe(this);
					_interactionCircleViewStart.transform.position = TilemapView.GetWorldPositionForCoordinates(_visualStartCoordinates) + (Vector3)_startTileView.InteractionCircleOffset;
					_startInteractionCirclePositionTween.Stop();
				}
				if (_interactionCircleViewEnd != null)
				{
					if (_endTileView != null)
					{
						_endTileView.Unsubscribe(this);
					}
					_endTileView = _tilemap.GetTileView(_visualEndCoordinates);
					_endTileView.Subscribe(this);
					_interactionCircleViewEnd.transform.position = TilemapView.GetWorldPositionForCoordinates(_visualEndCoordinates) + (Vector3)_endTileView.InteractionCircleOffset;
					_endInteractionCirclePositionTween.Stop();
				}
				if (!flag2)
				{
					_shadowMaterialPropertyBlock.SetVectorArray(ShaderConstants.SplineSegments, _spline.AddShadowOffsetToSplineSegments(array, _shadowOffset));
				}
			}
			_shadowMeshRenderer.SetPropertyBlock(_shadowMaterialPropertyBlock);
			_rebuildGeometry = false;
		}

		private void RebuildHazardStripes()
		{
			Vector4[] values = _spline.GenerateHazardTapeStripeSamples(_visualParameters.splineDistanceBetweenStripes, _visualParameters.splineStripeRotationDegrees, _visualParameters.roadWidth, _visualParameters.maxHazardStripeWidth, 200);
			_materialPropertyBlock.SetVectorArray(ShaderConstants.HazardStripeSamples, values);
			_rebuildHazardStripes = false;
		}

		public int GetSortOrderIndexForMotorwayComponent(MotorwayComponentSortOrder componentSortOrder)
		{
			return (int)componentSortOrder;
		}

		private Vector3[] RasterizeSplines(MotorwaySplineType splineGenerationType)
		{
			float num = (float)TilemapModel.HalfTileWidth;
			Vector2 vectorForDirection = TileUtilities.GetVectorForDirection(StartDirection);
			Vector2 vector = (Vector2)TilemapView.GetWorldPositionForCoordinates(StartCoordinates) + vectorForDirection * num;
			Vector2 vector2 = vector + vectorForDirection * RampExtrusion;
			float num2 = (vector - _splineMidpoint).magnitude / (vector - _naturalMidpoint).magnitude;
			Vector2 inH = vector2 + vectorForDirection * (_naturalStartHandleLength * 0.5f * num2);
			Vector2 vectorForDirection2 = TileUtilities.GetVectorForDirection(EndDirection);
			Vector2 vector3 = (Vector2)TilemapView.GetWorldPositionForCoordinates(EndCoordinates) + vectorForDirection2 * num;
			Vector2 vector4 = vector3 + vectorForDirection2 * RampExtrusion;
			float num3 = (vector3 - _splineMidpoint).magnitude / (vector3 - _naturalMidpoint).magnitude;
			Vector2 outH = vector4 + vectorForDirection2 * (_naturalEndHandleLength * 0.5f * num3);
			Vector2 vector5 = -_naturalTangent * ((_naturalStartHandleLength + _naturalEndHandleLength) * 0.25f);
			Vector2 vector6 = -vector5;
			Vector2 vector7 = ((splineGenerationType == MotorwaySplineType.Shadow) ? new Vector2(_shadowOffset, 0f - _shadowOffset) : Vector2.zero);
			List<Vector3> list = new List<Vector3>(new Vector3[SplineResolution * 2 + 3])
			{
				[0] = vector,
				[list.Count - 1] = vector3
			};
			Spline.BezierSpline bezierSpline = new Spline.BezierSpline(vector2, inH, vector5 + _splineMidpoint + vector7, _splineMidpoint + vector7);
			for (int i = 0; i <= SplineResolution; i++)
			{
				float time = 1f / (float)SplineResolution * (float)i;
				list[i + 1] = bezierSpline.Evaluate(time);
			}
			bezierSpline = new Spline.BezierSpline(_splineMidpoint + vector7, _splineMidpoint + vector6 + vector7, outH, vector4);
			for (int j = 1; j <= SplineResolution; j++)
			{
				float time2 = 1f / (float)SplineResolution * (float)j;
				list[SplineResolution + 1 + j] = bezierSpline.Evaluate(time2);
			}
			return list.ToArray();
		}

		private static void ConstructMotorwayMesh(int segmentCount)
		{
			int num = 2 * (segmentCount + 1);
			int num2 = 6 * segmentCount;
			Vector3[] vertices = new Vector3[num];
			Vector2[] array = new Vector2[num];
			int[] array2 = new int[num2];
			float num3 = 1f / (float)segmentCount;
			int num4 = segmentCount + 1;
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < num4; i++)
			{
				float x = (float)i * num3;
				array[num5] = new Vector2(x, 0f);
				array[num5 + 1] = new Vector2(x, 1f);
				if (i < num4 - 1)
				{
					array2[num6] = num5;
					array2[num6 + 1] = num5 + 2;
					array2[num6 + 2] = num5 + 1;
					array2[num6 + 3] = num5 + 1;
					array2[num6 + 4] = num5 + 2;
					array2[num6 + 5] = num5 + 3;
					num6 += 6;
				}
				num5 += 2;
			}
			if (motorwayMesh == null)
			{
				motorwayMesh = new Mesh();
			}
			motorwayMesh.vertices = vertices;
			motorwayMesh.uv = array;
			motorwayMesh.SetTriangles(array2, 0);
			motorwayMesh.bounds = new Bounds(Vector3.zero, new Vector3(1000f, 1000f));
		}

		private void RebuildLanePaths()
		{
			if (_clientMotorway == null)
			{
				return;
			}
			Vector2 startCoordinatesWorldSpace = TilemapView.GetWorldPositionForCoordinates(_clientMotorway.StartCoordinates);
			Vector2 endCoordinatesWorldSpace = TilemapView.GetWorldPositionForCoordinates(_clientMotorway.EndCoordinates);
			_spline.RebuildSegments(_clientMotorway.StartDirection, _clientMotorway.EndDirection, startCoordinatesWorldSpace, endCoordinatesWorldSpace, _splineMidpoint, _naturalMidpoint, _naturalTangent, _naturalStartHandleLength, _naturalEndHandleLength);
			Spline.RasterizedSpline rasterizedSpline = _spline.spline.RasterizeWithTangents(20);
			Spline.RasterizedSpline rasterizedSpline2 = rasterizedSpline.Offset((float)RoadTileAtlas.LaneOffsetScale);
			Spline.RasterizedSpline rasterizedSpline3 = rasterizedSpline.Offset((float)(-RoadTileAtlas.LaneOffsetScale));
			_startToEndPath = rasterizedSpline2.Positions;
			_endToStartPath = rasterizedSpline3.Positions;
			_endToStartPath.Reverse();
			if (!skipModelPoints && Model != null && Model.startToEndLane != null && Model.endToStartLane != null)
			{
				LaneModel startToEndLane = _model.startToEndLane;
				LaneModel endToStartLane = _model.endToStartLane;
				if (TileUtilities.IsDirectionDiagonal(StartDirection))
				{
					if (startToEndLane.InboundLanes.Count >= 1)
					{
						LaneModel laneModel = startToEndLane.InboundLanes[0];
						if (laneModel.lanePoints.Count >= 1)
						{
							Vector2Fixed vector2Fixed = laneModel.lanePoints[laneModel.lanePoints.Count - 1];
							_startToEndPath.Insert(0, new Vector2((float)vector2Fixed.x, (float)vector2Fixed.y));
						}
					}
					if (endToStartLane.OutboundLanes.Count >= 1)
					{
						LaneModel laneModel2 = endToStartLane.OutboundLanes[0];
						if (laneModel2.lanePoints.Count >= 1)
						{
							Vector2Fixed vector2Fixed2 = laneModel2.lanePoints[0];
							_endToStartPath.Add(new Vector2((float)vector2Fixed2.x, (float)vector2Fixed2.y));
						}
					}
				}
				if (TileUtilities.IsDirectionDiagonal(EndDirection))
				{
					if (startToEndLane.OutboundLanes.Count >= 1)
					{
						LaneModel laneModel3 = startToEndLane.OutboundLanes[0];
						if (laneModel3.lanePoints.Count >= 1)
						{
							Vector2Fixed vector2Fixed3 = laneModel3.lanePoints[0];
							_startToEndPath.Add(new Vector2((float)vector2Fixed3.x, (float)vector2Fixed3.y));
						}
					}
					if (endToStartLane.InboundLanes.Count >= 1)
					{
						LaneModel laneModel4 = endToStartLane.InboundLanes[0];
						if (laneModel4.lanePoints.Count >= 1)
						{
							Vector2Fixed vector2Fixed4 = laneModel4.lanePoints[laneModel4.lanePoints.Count - 1];
							_endToStartPath.Insert(0, new Vector2((float)vector2Fixed4.x, (float)vector2Fixed4.y));
						}
					}
				}
			}
			_startToEndPathLength = 0f;
			for (int i = 0; i < _startToEndPath.Count - 1; i++)
			{
				_startToEndPathLength += (_startToEndPath[i + 1] - _startToEndPath[i]).magnitude;
			}
			_endToStartPathLength = 0f;
			for (int j = 0; j < _endToStartPath.Count - 1; j++)
			{
				_endToStartPathLength += (_endToStartPath[j + 1] - _endToStartPath[j]).magnitude;
			}
		}

		public float GetLaneLength(LaneModel motorwayLane)
		{
			if (_rebuildMotorway)
			{
				RebuildMotorway();
			}
			RebuildMotorwayView();
			if (motorwayLane == _model.startToEndLane)
			{
				return _startToEndPathLength;
			}
			if (motorwayLane == _model.endToStartLane)
			{
				return _endToStartPathLength;
			}
			Diagnostics.FailAssert("Called MotorwayView.GetLaneLength with invalid lane {0}.", motorwayLane);
			return -1f;
		}

		public List<Vector2> GetLanePoints(LaneModel motorwayLane)
		{
			if (_rebuildMotorway)
			{
				RebuildMotorway();
			}
			RebuildMotorwayView();
			if (motorwayLane == _model.startToEndLane)
			{
				return _startToEndPath;
			}
			if (motorwayLane == _model.endToStartLane)
			{
				return _endToStartPath;
			}
			Diagnostics.FailAssert("Called MotorwayView.GetLanePoints with invalid lane {0}.", motorwayLane);
			return null;
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			_interactionCircleViewStart.InitializeTheme(themeDatabase);
			_interactionCircleViewEnd.InitializeTheme(themeDatabase);
		}

		public void ApplyTheme(ITheme theme)
		{
			Theme theme2 = (Theme)theme;
			_motorwayViewColors.mothballedRoad = theme2.GetColor(ThemedMaterialType.RoadMothballed);
			_motorwayViewColors.roadInner = theme2.GetColor(ThemedMaterialType.RoadInner);
			_motorwayViewColors.roadInnerNonPermanent = theme2.GetColor(ThemedMaterialType.RoadInner, "_DryingColor");
			_motorwayViewColors.roadOutline = theme2.GetColor(ThemedMaterialType.RoadOutline);
			_motorwayViewColors.motorwayInner = theme2.GetColor(ThemedMaterialType.MotorwayInner);
			_motorwayViewColors.motorwayOuter = theme2.GetColor(ThemedMaterialType.MotorwayOutline);
			_motorwayViewColors.shadow = theme2.GetColor(ThemedMaterialType.Shadow);
			handleView.ApplyTheme(theme);
			_rebuildGeometry = true;
			_reapplyPermanence = true;
			RebuildMotorwayView();
			_interactionCircleViewStart.ApplyTheme(theme);
			_interactionCircleViewEnd.ApplyTheme(theme);
		}

		private Color GetBlendedColor(ThemedMaterialType themedMaterialType, Theme oldTheme, Theme newTheme, float progress, string property = "_Color")
		{
			return Color.LerpUnclamped(oldTheme.GetColor(themedMaterialType, property), newTheme.GetColor(themedMaterialType, property), progress);
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			Theme oldTheme2 = (Theme)oldTheme;
			Theme newTheme2 = (Theme)newTheme;
			_motorwayViewColors.mothballedRoad = GetBlendedColor(ThemedMaterialType.RoadMothballed, oldTheme2, newTheme2, progress);
			_motorwayViewColors.roadInner = GetBlendedColor(ThemedMaterialType.RoadInner, oldTheme2, newTheme2, progress);
			_motorwayViewColors.roadInnerNonPermanent = GetBlendedColor(ThemedMaterialType.RoadInner, oldTheme2, newTheme2, progress, "_DryingColor");
			_motorwayViewColors.roadOutline = GetBlendedColor(ThemedMaterialType.RoadOutline, oldTheme2, newTheme2, progress);
			_motorwayViewColors.motorwayInner = GetBlendedColor(ThemedMaterialType.MotorwayInner, oldTheme2, newTheme2, progress);
			_motorwayViewColors.motorwayOuter = GetBlendedColor(ThemedMaterialType.MotorwayOutline, oldTheme2, newTheme2, progress);
			_motorwayViewColors.shadow = GetBlendedColor(ThemedMaterialType.Shadow, oldTheme2, newTheme2, progress);
			handleView.ApplyTheme(newTheme2);
			_rebuildGeometry = true;
			_reapplyPermanence = true;
			RebuildMotorwayView();
			_motorwayMeshRenderer.SetPropertyBlock(_materialPropertyBlock);
			_interactionCircleViewStart.ApplyBlendedTheme(oldTheme, newTheme, progress);
			_interactionCircleViewEnd.ApplyBlendedTheme(oldTheme, newTheme, progress);
			return ThemeBlendingResult.ContinueBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
			_interactionCircleViewStart.ReleaseTheme(themeDatabase);
			_interactionCircleViewEnd.ReleaseTheme(themeDatabase);
		}
	}
}
