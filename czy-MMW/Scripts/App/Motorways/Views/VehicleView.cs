using System;
using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Audio;
using Motorways.Constants;
using Motorways.Models;
using Motorways.Processes;
using Motorways.Themes;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	[SelectionBase]
	public class VehicleView : MonoBehaviour, IView, IAudioView, VehicleModel.IObserver, IReusable, IReleasedFromScopeHandler, IThemeComponent
	{
		private enum MotorwayState
		{
			NotOnMotorway = 0,
			OnMotorway = 1,
			EnteringMotorway = 2,
			LeavingMotorway = 3
		}

		private enum HeadlightState
		{
			Off = 0,
			TurningOff = 1,
			TurningOn = 2,
			On = 3
		}

		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				VehicleView vehicleView = client.Scope.Get<VehicleView>();
				vehicleView.Initialize(model as VehicleModel);
				client.AddView(vehicleView);
			}
		}

		public const float VehicleZHeight = -6.1f;

		private int _id = -1;

		private static int _nextId = 1;

		private TribandVehicleEffects _tribandVehicleEffects;

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private ViewIndex _viewIndex;

		[Dependency]
		private TilemapView _tilemapView;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private MotorwaysThemeDatabase _theme;

		[Dependency]
		private ActivePlayer _activePlayer;

		[Dependency]
		private ClockModel _clockModel;

		private LaneCursor _laneCursor;

		private Vector3 _lastMidpoint;

		private Transform _shadowTransform;

		private VehicleModel _vehicleModel;

		private float _speed;

		private List<LineSegment> _previousLaneSegments = new List<LineSegment>();

		private float _distanceToGoal;

		public int groupIndex = int.MinValue;

		private bool _isInTunnel;

		private int _onMotorwayId = -1;

		private Vehicle _audioVehicle;

		private Vector2 _pan;

		private float _attenuation;

		public Material vehicleMaterial;

		[SerializeField]
		[HideInInspector]
		private Renderer _combinedMeshVehicleRenderer;

		[SerializeField]
		private Renderer _vehicleFrontLightLeft;

		[SerializeField]
		private Renderer _vehicleFrontLightRight;

		[SerializeField]
		private Renderer _vehicleHeadlightBeams;

		[SerializeField]
		private Renderer _vehicleShadowRenderer;

		[SerializeField]
		private VehicleTrailRenderer _trail;

		private int _boundSortingLayerId = int.MinValue;

		private int _boundMotorwayId = -1;

		private bool _isPendingDeletion;

		public float shadowOffsetScale = 1f;

		private const string CarSortingLayerName = "Car";

		private static int _carSortingLayerId;

		private const string HeadlightSortingLayerName = "Headlight";

		private static int _carHeadlightSortingLayerId;

		private const string MotorwayCarSortingLayerName = "MotorwayCar";

		private static int _motorwayCarSortingLayerId;

		private HeadlightState _headlightState;

		private Bounds _bodyAndHeadlightBounds;

		private const float InvalidTime = -1f;

		private float _headlightResponseTime = -1f;

		private float _nightModeEnabledChangedTime = -1f;

		private bool _previousIsNightModeEnabled;

		[Dependency]
		private VisualConstantsData _visualConstants;

		public int Id => _id;

		[Dependency]
		public City City { get; private set; }

		public Renderer CombinedMeshVehicleRenderer
		{
			set
			{
				_combinedMeshVehicleRenderer = value;
			}
		}

		public bool IsTrailActive
		{
			get
			{
				return _trail.gameObject.activeInHierarchy;
			}
			set
			{
				_trail.gameObject.SetActive(value);
			}
		}

		public bool IsPendingDeletion => _isPendingDeletion;

		public float CenterToWheelDistance => (float)VehicleMovementProcess.VehicleLength * 0.3f;

		public VehicleModel Model => _vehicleModel;

		public List<LineSegment> PreviousLaneSegments => _previousLaneSegments;

		public HouseView House => _viewIndex.GetHouseView(_vehicleModel.house);

		public DestinationView Destination
		{
			get
			{
				if (_vehicleModel.destination == null)
				{
					if (_vehicleModel.lastVisitedDestination == null)
					{
						return null;
					}
					return _viewIndex.GetDestinationView(_vehicleModel.lastVisitedDestination);
				}
				return _viewIndex.GetDestinationView(_vehicleModel.destination);
			}
		}

		public float Speed => _speed;

		public Vehicle AudioVehicle
		{
			get
			{
				return _audioVehicle;
			}
			set
			{
				if (_audioVehicle != value)
				{
					_audioVehicle?.Motor?.FadeOutAndStop();
					_audioVehicle = value;
				}
			}
		}

		public bool IsInTunnel => _isInTunnel;

		public bool SkipHeadlightResponseTime { get; set; }

		public Bounds VehicleBounds
		{
			get
			{
				if (_vehicleHeadlightBeams.gameObject.activeInHierarchy)
				{
					Bounds bounds = _combinedMeshVehicleRenderer.bounds;
					_bodyAndHeadlightBounds = new Bounds(bounds.center, bounds.size);
					_bodyAndHeadlightBounds.Encapsulate(_vehicleHeadlightBeams.bounds);
					return _bodyAndHeadlightBounds;
				}
				return _combinedMeshVehicleRenderer.bounds;
			}
		}

		public float DistanceToGoal => Mathf.Max(0f, _distanceToGoal);

		public Vector2 Pan => _pan;

		public float Attenuation => _attenuation;

		Transform IAudioView.transform => base.transform;

		private void Awake()
		{
			_carSortingLayerId = SortingLayer.NameToID("Car");
			_carHeadlightSortingLayerId = SortingLayer.NameToID("Headlight");
			_motorwayCarSortingLayerId = SortingLayer.NameToID("MotorwayCar");
			_shadowTransform = _vehicleShadowRenderer.transform;
		}

		private void Initialize(VehicleModel model)
		{
			_id = _nextId;
			_nextId++;
			_vehicleModel = model;
			_vehicleModel.Subscribe(this);
			_viewIndex.AddVehicleView(this);
			_laneCursor = _scope.Get<LaneCursor>();
			_lastMidpoint = new Vector3(-9999f, -9999f, 0f);
			groupIndex = _vehicleModel.house.GroupIndex;
			_theme.RegisterGameObjectToThemeByGroupIndex(base.gameObject, groupIndex);
			_previousIsNightModeEnabled = _activePlayer.IsNightModeEnabled;
			_headlightState = (_activePlayer.IsNightModeEnabled ? HeadlightState.On : HeadlightState.Off);
			SetHeadlightsOn(_activePlayer.IsNightModeEnabled && !_vehicleModel.IsWaitingAtHouse);
			Bounds bounds = _combinedMeshVehicleRenderer.bounds;
			_bodyAndHeadlightBounds = new Bounds(bounds.center, bounds.size);
			_bodyAndHeadlightBounds.Encapsulate(_vehicleHeadlightBeams.bounds);
			MaterialPropertyBlock materialPropertyBlock = _theme.MaterialPropertyBlock;
			_combinedMeshVehicleRenderer.GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetInt(ShaderConstants.GroupId, groupIndex);
			_combinedMeshVehicleRenderer.SetPropertyBlock(materialPropertyBlock);
			if (FeatureToggle.IsFeatureDisabled(Feature.VehicleTrails))
			{
				IsTrailActive = false;
			}
			RoadTileConnection connection = model.CurrentFrame.lane.connection;
			bool flag = connection.input.type == RoadType.Motorway && connection.output.type != RoadType.Motorway;
			_onMotorwayId = (flag ? connection.input.motorwayId : connection.output.motorwayId);
			_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleSpawned, this, House, Destination));
			if (FeatureToggle.IsFeatureEnabled(Feature.WhatTheCarEasterEgg) && _scope.Get<EasterEggModel>().ShouldBeEasterEggVehicle(_vehicleModel))
			{
				_tribandVehicleEffects = _scope.Get<TribandVehicleEffects>();
				_tribandVehicleEffects.transform.SetParent(base.transform, worldPositionStays: false);
			}
		}

		public void SetNewGroupIndex(int newGroupIndex)
		{
			_theme.UnregisterGameObjectFromThemeByGroupIndex(base.gameObject, groupIndex);
			groupIndex = newGroupIndex;
			MaterialPropertyBlock materialPropertyBlock = _theme.MaterialPropertyBlock;
			_combinedMeshVehicleRenderer.GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetInt(ShaderConstants.GroupId, groupIndex);
			_combinedMeshVehicleRenderer.SetPropertyBlock(materialPropertyBlock);
			_theme.RegisterGameObjectToThemeByGroupIndex(base.gameObject, groupIndex);
		}

		public void Reset()
		{
			groupIndex = int.MinValue;
			_id = -1;
			_lastMidpoint = Vector3.zero;
			_speed = 0f;
			_previousLaneSegments.Clear();
			_distanceToGoal = 0f;
			_isInTunnel = false;
			_onMotorwayId = -1;
			_boundSortingLayerId = int.MinValue;
			_boundMotorwayId = -1;
			_audioVehicle = null;
			_pan = Vector2.zero;
			_attenuation = 0f;
			_isPendingDeletion = false;
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.identity;
			_bodyAndHeadlightBounds = default(Bounds);
			_headlightResponseTime = -1f;
			_nightModeEnabledChangedTime = -1f;
			_previousIsNightModeEnabled = false;
			_headlightState = HeadlightState.Off;
			SkipHeadlightResponseTime = false;
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_theme.UnregisterGameObjectFromThemeByGroupIndex(base.gameObject, groupIndex);
			_viewIndex.RemoveVehicleView(this);
			if (_vehicleModel != null)
			{
				_vehicleModel.Unsubscribe(this);
				_vehicleModel = null;
			}
			if (_laneCursor != null)
			{
				scope.Release(_laneCursor);
				_laneCursor = null;
			}
			if (_tribandVehicleEffects != null)
			{
				scope.Release(_tribandVehicleEffects);
			}
		}

		private void SetSortingInfo(int carSortingLayerId, int headlightSortingLayerId, int motorwayId)
		{
			if (_boundSortingLayerId != carSortingLayerId)
			{
				SetVehicleComponentRenderSorting(_vehicleFrontLightRight, headlightSortingLayerId, 9);
				SetVehicleComponentRenderSorting(_vehicleFrontLightLeft, headlightSortingLayerId, 9);
				SetVehicleComponentRenderSorting(_vehicleHeadlightBeams, headlightSortingLayerId, 8);
				SetVehicleComponentRenderSorting(_trail.Renderer, carSortingLayerId, 6);
				SetVehicleComponentRenderSorting(_combinedMeshVehicleRenderer, carSortingLayerId, 6);
				SetVehicleComponentRenderSorting(_vehicleShadowRenderer, carSortingLayerId, 5);
				_boundSortingLayerId = carSortingLayerId;
			}
			if (_boundMotorwayId != motorwayId)
			{
				MaterialPropertyBlock materialPropertyBlock = _theme.MaterialPropertyBlock;
				_combinedMeshVehicleRenderer.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetFloat(ShaderConstants.MotorwayIdShaderId, motorwayId);
				materialPropertyBlock.SetFloat(ShaderConstants.HeadlightOcclusionTypeId, _vehicleModel.id);
				_combinedMeshVehicleRenderer.SetPropertyBlock(materialPropertyBlock);
				_vehicleHeadlightBeams.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetFloat(ShaderConstants.MotorwayIdShaderId, motorwayId);
				materialPropertyBlock.SetFloat(ShaderConstants.HeadlightOcclusionTypeId, _vehicleModel.id);
				_vehicleHeadlightBeams.SetPropertyBlock(materialPropertyBlock);
				_vehicleFrontLightLeft.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetFloat(ShaderConstants.MotorwayIdShaderId, motorwayId);
				materialPropertyBlock.SetFloat(ShaderConstants.HeadlightOcclusionTypeId, _vehicleModel.id);
				_vehicleFrontLightLeft.SetPropertyBlock(materialPropertyBlock);
				_vehicleFrontLightRight.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetFloat(ShaderConstants.MotorwayIdShaderId, motorwayId);
				materialPropertyBlock.SetFloat(ShaderConstants.HeadlightOcclusionTypeId, _vehicleModel.id);
				_vehicleFrontLightRight.SetPropertyBlock(materialPropertyBlock);
				_vehicleShadowRenderer.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetFloat(ShaderConstants.MotorwayIdShaderId, motorwayId);
				_vehicleShadowRenderer.SetPropertyBlock(materialPropertyBlock);
				_trail.Renderer.GetPropertyBlock(materialPropertyBlock);
				materialPropertyBlock.SetFloat(ShaderConstants.MotorwayIdShaderId, motorwayId);
				_trail.Renderer.SetPropertyBlock(materialPropertyBlock);
				_boundMotorwayId = motorwayId;
			}
		}

		private void SetVehicleComponentRenderSorting(Renderer vehiclePart, int layerId, int sortingOrder)
		{
			vehiclePart.sortingLayerID = layerId;
			vehiclePart.sortingOrder = sortingOrder;
		}

		private float CalculateHeadlightResponseTime()
		{
			float f = 1f - UnityEngine.Random.Range(0f, 1f);
			float num = 1f - UnityEngine.Random.Range(0f, 1f);
			float num2 = Mathf.Sqrt(-2f * Mathf.Log(f)) * Mathf.Sin((float)Math.PI * 2f * num);
			float b = _visualConstants.MeanVehicleHeadlightResponseTime + _visualConstants.StandardDeviationVehicleHeadlightResponseTime * num2;
			return Mathf.Max(0f, b);
		}

		private void SetHeadlightsOn(bool isOn)
		{
			_vehicleHeadlightBeams.gameObject.SetActive(isOn);
			_vehicleFrontLightLeft.gameObject.SetActive(isOn);
			_vehicleFrontLightRight.gameObject.SetActive(isOn);
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			if (_tribandVehicleEffects != null)
			{
				_tribandVehicleEffects.Tick(timeInterval, stepAlpha);
			}
			UpdateHeadlightState();
			if (_isPendingDeletion)
			{
				return TickResult.Destroy;
			}
			_laneCursor.MoveToVehicle(this, stepAlpha);
			Vector3 position = _laneCursor.Position;
			if (!Mathf.Approximately(0f, (position - _lastMidpoint).sqrMagnitude))
			{
				_lastMidpoint = position;
				_laneCursor.Move(CenterToWheelDistance);
				Vector3 position2 = _laneCursor.Position;
				if (!_laneCursor.MoveAlongRadius(CenterToWheelDistance * -2f, out var position3))
				{
					position3 = position2 + (position - position2).normalized * (CenterToWheelDistance * 2f);
				}
				Vector3 vector = Vector3.Lerp(position3, position2, 0.5f);
				base.transform.localPosition = new Vector3(vector.x, vector.y, -6.1f);
				Vector2 vector2 = (position2 - position3).normalized;
				Vector2 vector3 = new Vector2(vector2.y, 0f - vector2.x);
				float num = Mathf.Sqrt(1f + vector3.x + vector2.y + 1f) * 0.5f;
				float num2;
				if (!Mathf.Approximately(num, 0f))
				{
					num2 = (vector3.y - vector2.x) / (4f * num);
					float num3 = Mathf.Sqrt(num2 * num2 + num * num);
					num2 /= num3;
					num /= num3;
				}
				else
				{
					num2 = -1f;
					num = 0f;
				}
				Quaternion quaternion = new Quaternion(0f, 0f, num2, num);
				base.transform.localRotation = quaternion;
				_shadowTransform.localPosition = Quaternion.Inverse(quaternion) * ((Vector3.right + Vector3.down) * shadowOffsetScale);
			}
			int onMotorwayId = _onMotorwayId;
			int newMotorwayId;
			MotorwayState motorwayState = UpdateMotorwayInformation(out newMotorwayId);
			if (newMotorwayId != -1)
			{
				_onMotorwayId = newMotorwayId;
				SetSortingInfo(_motorwayCarSortingLayerId, _motorwayCarSortingLayerId, _onMotorwayId);
			}
			else
			{
				_onMotorwayId = -1;
				SetSortingInfo(_carSortingLayerId, _carHeadlightSortingLayerId, 0);
			}
			if (_onMotorwayId == -1)
			{
				Vector2Int tileCoordinatesFromWorldPosition = _tilemapView.GetTileCoordinatesFromWorldPosition(position);
				_isInTunnel = City.Definition.TileIsUnderAMountain(tileCoordinatesFromWorldPosition);
			}
			if (motorwayState == MotorwayState.EnteringMotorway && _onMotorwayId >= 0)
			{
				Diagnostics.Log.Info("VehicleView", "VehicleEnteredMotorway");
				_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleEnteredMotorway, this, null, null, _tilemapView.GetMotorwayView(_onMotorwayId)));
			}
			else if (motorwayState == MotorwayState.LeavingMotorway && onMotorwayId >= 0)
			{
				Diagnostics.Log.Info("VehicleView", "VehicleLeftMotorway");
				_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleLeftMotorway, this, null, null, _tilemapView.GetMotorwayView(onMotorwayId)));
			}
			_distanceToGoal = CalculateDistanceToGoal(stepAlpha);
			Vector2 screenFromWorld = _gameCamera.GetScreenFromWorld(base.transform.position);
			_pan = _gameCamera.GetPanFromScreen(screenFromWorld);
			_attenuation = _gameCamera.GetAttenuationFromScreen(screenFromWorld);
			_speed = (float)_vehicleModel.CurrentFrame.speed + (float)(_vehicleModel.NextFrame.speed - _vehicleModel.CurrentFrame.speed) * stepAlpha;
			if (IsTrailActive)
			{
				_trail.Tick(timeInterval.UnpausedScaledDelta);
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private void UpdateHeadlightState()
		{
			if (_previousIsNightModeEnabled != _activePlayer.IsNightModeEnabled)
			{
				_nightModeEnabledChangedTime = (float)_clockModel.Time;
				_headlightResponseTime = CalculateHeadlightResponseTime();
				HeadlightState headlightState = ((!_activePlayer.IsNightModeEnabled) ? HeadlightState.TurningOff : HeadlightState.TurningOn);
				if (headlightState == HeadlightState.TurningOn && (_headlightState == HeadlightState.On || _headlightState == HeadlightState.TurningOff))
				{
					headlightState = HeadlightState.On;
				}
				else if (headlightState == HeadlightState.TurningOff && (_headlightState == HeadlightState.Off || _headlightState == HeadlightState.TurningOn))
				{
					headlightState = HeadlightState.Off;
				}
				_headlightState = headlightState;
				_previousIsNightModeEnabled = _activePlayer.IsNightModeEnabled;
			}
			if (!_scope.Get<ISimulation>().IsPaused && _nightModeEnabledChangedTime > 0f && (float)_clockModel.Time - _nightModeEnabledChangedTime > _headlightResponseTime)
			{
				_headlightState = _headlightState switch
				{
					HeadlightState.TurningOn => HeadlightState.On, 
					HeadlightState.TurningOff => HeadlightState.Off, 
					_ => _headlightState, 
				};
				_headlightResponseTime = -1f;
				_nightModeEnabledChangedTime = -1f;
			}
			switch (_headlightState)
			{
			case HeadlightState.Off:
			case HeadlightState.TurningOn:
				SetHeadlightsOn(isOn: false);
				break;
			case HeadlightState.TurningOff:
			case HeadlightState.On:
				SetHeadlightsOn(!_vehicleModel.IsWaitingAtHouse && !_vehicleModel.IsParkedAtDestination);
				break;
			}
			if (SkipHeadlightResponseTime)
			{
				if (_headlightState == HeadlightState.TurningOff)
				{
					SetHeadlightsOn(isOn: false);
				}
				else if (_headlightState == HeadlightState.TurningOn)
				{
					SetHeadlightsOn(!_vehicleModel.IsWaitingAtHouse && !_vehicleModel.IsParkedAtDestination);
				}
			}
		}

		private MotorwayState UpdateMotorwayInformation(out int newMotorwayId)
		{
			RoadTileConnection connection = _vehicleModel.CurrentFrame.lane.connection;
			MotorwayState result;
			if (_onMotorwayId != -1)
			{
				result = MotorwayState.OnMotorway;
				newMotorwayId = _onMotorwayId;
				bool num = connection.input.type != RoadType.Motorway && connection.output.type != RoadType.Motorway;
				bool flag = connection.input.motorwayId == _onMotorwayId && connection.output.motorwayId != _onMotorwayId;
				if (num)
				{
					result = MotorwayState.LeavingMotorway;
					newMotorwayId = -1;
				}
				else if (flag)
				{
					if (_tilemapView.MotorwayGeometryInfo.EndEdges.TryGetValue(_onMotorwayId, out var value))
					{
						if (!MotorwayIntersectionUtil.EitherEndEdgeIntersectsBoundingBox(value, VehicleBounds) && !MotorwayIntersectionUtil.EitherEndEdgeIntersectsBoundingBox(value, _vehicleShadowRenderer.bounds))
						{
							result = MotorwayState.LeavingMotorway;
							newMotorwayId = -1;
						}
					}
					else
					{
						result = MotorwayState.NotOnMotorway;
						newMotorwayId = -1;
					}
				}
			}
			else
			{
				result = MotorwayState.NotOnMotorway;
				newMotorwayId = -1;
				if (connection.input.type == RoadType.Motorway && connection.output.type == RoadType.Motorway)
				{
					newMotorwayId = connection.input.motorwayId;
					result = MotorwayState.EnteringMotorway;
				}
				else if (_vehicleModel.path.Count >= 1)
				{
					result = MotorwayState.NotOnMotorway;
					RoadTileConnection connection2 = _vehicleModel.path[0].connection;
					if (connection2.input.type == RoadType.Motorway)
					{
						int motorwayId = connection2.input.motorwayId;
						if (_tilemapView.MotorwayGeometryInfo.EndEdges.TryGetValue(motorwayId, out var value2) && (MotorwayIntersectionUtil.EitherEndEdgeIntersectsBoundingBox(value2, VehicleBounds) || MotorwayIntersectionUtil.EitherEndEdgeIntersectsBoundingBox(value2, _vehicleShadowRenderer.bounds)))
						{
							result = MotorwayState.EnteringMotorway;
							newMotorwayId = motorwayId;
						}
					}
				}
			}
			return result;
		}

		public void OnVehicleMovedToNewLane(LaneModel newLane, LaneModel oldLane)
		{
			_previousLaneSegments.Clear();
			if (oldLane == null)
			{
				return;
			}
			MotorwayView motorwayView = _tilemapView.TryGetMotorwayViewForLane(oldLane);
			if (motorwayView != null)
			{
				List<Vector2> lanePoints = motorwayView.GetLanePoints(oldLane);
				if (lanePoints != null)
				{
					for (int i = 0; i < lanePoints.Count - 1; i++)
					{
						_previousLaneSegments.Add(new LineSegment(lanePoints[i], lanePoints[i + 1]));
					}
					return;
				}
			}
			List<Vector2Fixed> lanePoints2 = oldLane.lanePoints;
			for (int j = 0; j < lanePoints2.Count - 1; j++)
			{
				_previousLaneSegments.Add(new LineSegment((Vector2)lanePoints2[j], (Vector2)lanePoints2[j + 1]));
			}
		}

		public void OnVehicleArrivedAtHouse(VehicleModel vehicleModel)
		{
			_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleArrivedAtHouse, this, _viewIndex.GetHouseView(_vehicleModel.house)));
		}

		public void OnVehicleDepartedHouse(VehicleModel vehicle, DestinationModel toDestination)
		{
			_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleDepartedHouse, this, _viewIndex.GetHouseView(_vehicleModel.house), _viewIndex.GetDestinationView(_vehicleModel.destination)));
		}

		public void OnVehicleEnteredCarpark(VehicleModel vehicleModel, DestinationModel destinationModel)
		{
			if (destinationModel != null)
			{
				_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleEnteredCarpark, this, null, _viewIndex.GetDestinationView(destinationModel)));
			}
		}

		public void OnVehicleArrivedAtDestination(VehicleModel vehicleModel, DestinationModel destinationModel)
		{
			if (destinationModel != null)
			{
				_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleArrivedAtDestination, this, null, _viewIndex.GetDestinationView(destinationModel)));
			}
		}

		public void OnVehicleDepartedDestination(VehicleModel vehicleModel, DestinationModel fromDestination)
		{
			_audioSystem.ScheduleEvent(AudioEvent.CreateVehicleEvent(AudioEventType.VehicleDepartedDestination, this, _viewIndex.GetHouseView(_vehicleModel.house), _viewIndex.GetDestinationView(_vehicleModel.lastVisitedDestination)));
		}

		private float CalculateDistanceToGoal(float stepAlpha)
		{
			float num = (float)_vehicleModel.pathLength;
			float laneLength = GetLaneLength(_vehicleModel.NextFrame.lane);
			float laneLength2 = GetLaneLength(_vehicleModel.CurrentFrame.lane);
			float num2 = laneLength - (float)_vehicleModel.NextFrame.distanceAlongLane;
			float num3 = laneLength2 - (float)_vehicleModel.CurrentFrame.distanceAlongLane;
			if (_vehicleModel.CurrentFrame.lane != _vehicleModel.NextFrame.lane)
			{
				num3 += laneLength;
			}
			return num + num2 * stepAlpha + num3 * (1f - stepAlpha);
		}

		private static float GetLaneLength(LaneModel lane)
		{
			float result = 0f;
			if (Diagnostics.Verify(lane != null))
			{
				result = (float)lane.Length;
			}
			return result;
		}

		public float GetAttenuation(bool zoom, float falloffFactor = 5f)
		{
			return _gameCamera.GetAttenuationFromWorld(base.transform.position, zoom: true, falloffFactor);
		}

		public void OnRemoved()
		{
			_isPendingDeletion = true;
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			Theme theme = (Theme)themeDatabase.GetTheme();
			_trail.Color = theme.GetBuildingColor(groupIndex, ThemeComponentGroupTarget.CarBase);
		}

		public void ApplyTheme(ITheme theme)
		{
			Theme theme2 = (Theme)theme;
			_trail.Color = theme2.GetBuildingColor(groupIndex, ThemeComponentGroupTarget.CarBase);
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			Theme obj = (Theme)oldTheme;
			Theme theme = (Theme)newTheme;
			Color buildingColor = obj.GetBuildingColor(groupIndex, ThemeComponentGroupTarget.CarBase);
			Color buildingColor2 = theme.GetBuildingColor(groupIndex, ThemeComponentGroupTarget.CarBase);
			Color color = Color.Lerp(buildingColor, buildingColor2, progress);
			_trail.Color = color;
			return ThemeBlendingResult.ContinueBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}
	}
}
