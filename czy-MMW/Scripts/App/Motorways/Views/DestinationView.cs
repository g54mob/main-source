using System;
using System.Collections.Generic;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Audio;
using Motorways.Models;
using Motorways.Themes;
using Motorways.Views.MeshGeneration;
using Server;
using UnityEngine;

namespace Motorways.Views
{
	[SelectionBase]
	public class DestinationView : MonoBehaviour, IView, DestinationModel.IObserver, IAudioView, ICreatedInScopeHandler, IReleasedFromScopeHandler, IReusable, IThemeComponent
	{
		public enum DestinationVisibility
		{
			NotShown = 0,
			Square = 1,
			Circle = 2
		}

		public interface IObserver
		{
			void OnDemandLevelChanged(DestinationView owner);

			void OnImminentFailAlert(DestinationView owner, bool isInitialAlert);

			void OnBigPinAppeared(DestinationView owner);
		}

		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				DestinationView destinationView = client.Scope.Get<DestinationView>();
				destinationView.Initialize(model as DestinationModel);
				client.AddView(destinationView);
			}
		}

		[Dependency]
		private IScope _gameScope;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private ViewIndex _viewIndex;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private MotorwaysThemeDatabase _theme;

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private DestinationMeshCombiner _meshCombiner;

		[Dependency]
		private GameplayEventHandler _gameplayEventHandler;

		private DestinationModel _destinationModel;

		public int groupIndex = -1;

		[SerializeField]
		private DestinationVisualVariant _defaultVisualVariant;

		private DestinationVisualVariant _visualVariant;

		private DestinationVisualVariant[] _destinationVisualVariants;

		private bool _isPendingDeletion;

		private DestinationLevel _level0;

		private DestinationVisibility _visibility;

		private DestinationPinAnimatorView _pinAnimatorToUse;

		private NetworkConnectivity _connectivity;

		private NetworkConnectivity _lastNotifiedConnectivity;

		private float _spawnTime;

		private bool _isShowingPins = true;

		private readonly List<VehicleView> _vehiclesWaitingForPin = new List<VehicleView>();

		private readonly ObserverList<IObserver> _observers = new ObserverList<IObserver>();

		private static readonly float StationOffset = 0.75f * (float)TilemapModel.TileWidth;

		[Dependency]
		public City City { get; private set; }

		public bool IsShowingPins => _isShowingPins;

		public int PinCount => _pinAnimatorToUse.VisiblePinCount;

		public float MaxOvercrowdingTime => (float)_constants.MaxOvercrowdTime;

		public DestinationModel Model => _destinationModel;

		public Vector2 Pan => _gameCamera.GetPanFromWorld(base.transform.position);

		public float Attenuation => _gameCamera.GetAttenuationFromWorld(base.transform.position);

		public DestinationView NeighboringDestination
		{
			get
			{
				DestinationModel neighboringDestination = _destinationModel.Carpark.GetNeighboringDestination(_destinationModel);
				if (neighboringDestination != null)
				{
					return _viewIndex.GetDestinationView(neighboringDestination);
				}
				return null;
			}
		}

		public NetworkConnectivity NetworkConnectivity
		{
			get
			{
				return _connectivity;
			}
			set
			{
				_connectivity = value;
				if (_connectivity != NetworkConnectivity.Unknown && _lastNotifiedConnectivity != _connectivity)
				{
					_lastNotifiedConnectivity = _connectivity;
					_audioSystem.ScheduleEvent(AudioEvent.CreateDestinationEvent(AudioEventType.DestinationConnectedToNetwork, this, _connectivity == NetworkConnectivity.Connected));
				}
			}
		}

		public float SpawnTime => _spawnTime;

		private bool ShouldShowDemandCounters
		{
			get
			{
				if (FeatureToggle.IsFeatureEnabled(Feature.DemandCounters))
				{
					return true;
				}
				return false;
			}
		}

		private bool ShouldShowHouseRequirements => false;

		public Vector2 BigPinAlertPosition => _pinAnimatorToUse.BigPinAlertPosition;

		Transform IAudioView.transform => base.transform;

		public void Subscribe(IObserver observer)
		{
			_observers.Subscribe(observer);
		}

		public bool Unsubscribe(IObserver observer)
		{
			return _observers.Unsubscribe(observer);
		}

		public void Initialize(DestinationModel model)
		{
			SetVisualVariantActive();
			_visualVariant.StationPinAnimator.gameObject.SetActive(value: false);
			_visualVariant.StationPinAnimatorVertical.gameObject.SetActive(value: false);
			_visualVariant.PinAnimator.gameObject.SetActive(value: false);
			bool flag = !_viewClient.OnFirstFrame;
			_connectivity = NetworkConnectivity.Disconnected;
			_lastNotifiedConnectivity = NetworkConnectivity.Disconnected;
			_destinationModel = model;
			_destinationModel.Subscribe(this);
			_destinationModel.Subscribe(_gameplayEventHandler);
			_viewIndex.AddDestinationView(this);
			UpdateDestinationMeshes();
			if (_destinationModel.isActive)
			{
				_visibility = ((!model.IsUpgraded) ? DestinationVisibility.Square : DestinationVisibility.Circle);
				if (_visibility == DestinationVisibility.Square)
				{
					_level0.Show((!flag) ? TransitionStyle.Snap : TransitionStyle.Tween);
					_visualVariant.Level1.Hide(TransitionStyle.Snap);
				}
				else
				{
					_level0.Hide(TransitionStyle.Snap);
					_visualVariant.Level1.Show((!flag) ? TransitionStyle.Snap : TransitionStyle.Tween);
					_pinAnimatorToUse.Upgrade();
				}
			}
			else
			{
				_visibility = DestinationVisibility.NotShown;
				_level0.Hide(TransitionStyle.Snap);
				_visualVariant.Level1.Hide(TransitionStyle.Snap);
			}
			groupIndex = _destinationModel.GroupIndex;
			_theme.RegisterGameObjectToThemeByGroupIndex(_level0.gameObject, groupIndex);
			_theme.RegisterGameObjectToThemeByGroupIndex(_visualVariant.Level1.gameObject, groupIndex);
			Vector2 vector = new Vector2(0f, 0f);
			foreach (TileModel tileModel in _destinationModel.TileModels)
			{
				vector += (Vector2)tileModel.Coordinates;
			}
			vector /= (float)_destinationModel.TileModels.Count;
			Vector3 position = new Vector3(vector.x * (float)TilemapModel.TileWidth, vector.y * (float)TilemapModel.TileWidth, 0f);
			if (model.IsTrainStation)
			{
				if (model.Carpark.carparkSide == TileDirection.North)
				{
					position.y += StationOffset;
				}
				if (model.Carpark.carparkSide == TileDirection.West)
				{
					position.x -= StationOffset;
				}
			}
			base.transform.position = position;
			_pinAnimatorToUse.Initialize(this, _scope);
			GetComponent<CreativeModeEditableDestination>().Initialize(_scope, _destinationModel.Carpark.SupportsTwoDestinations);
			AudioEventType type = (AudioEventType)(_destinationModel.isActive ? 131072 : 65536);
			_audioSystem.ScheduleEvent(AudioEvent.CreateDestinationEvent(type, this));
			_spawnTime = Time.time;
		}

		private void UpdateDestinationMeshes()
		{
			DestinationMesh.Type type = DestinationMesh.Type.Square;
			_level0 = _visualVariant.Level0Square;
			_pinAnimatorToUse = _visualVariant.PinAnimator;
			if (_destinationModel.IsTrainStation)
			{
				bool flag = _destinationModel.Carpark.Alignment == TileAlignment.Vertical;
				type = (flag ? DestinationMesh.Type.StationVertical : DestinationMesh.Type.StationHorizontal);
				_level0 = (flag ? _visualVariant.Level0StationVertical : _visualVariant.Level0StationHorizontal);
				_pinAnimatorToUse = (flag ? _visualVariant.StationPinAnimatorVertical : _visualVariant.StationPinAnimator);
				ParticleSystem.MainModule main = _visualVariant.DisconnectedParticles_TrainStation.main;
				main.startRotationZ = (flag ? ((float)Math.PI / 2f) : 0f);
			}
			TileDirection carparkSide = _destinationModel.Carpark.carparkSide;
			_level0.SetDestinationMesh(_meshCombiner.GetCombinedMesh(type, carparkSide, _destinationModel.GroupIndex, VisualVariantIndex()));
			if (!_destinationModel.IsTrainStation)
			{
				_visualVariant.Level1.SetDestinationMesh(_meshCombiner.GetCombinedMesh(DestinationMesh.Type.Circle, carparkSide, _destinationModel.GroupIndex, VisualVariantIndex()));
			}
			_pinAnimatorToUse.gameObject.SetActive(value: true);
			if (_destinationModel.IsTrainStation)
			{
				Bounds bounds = _level0.GetComponent<Renderer>().bounds;
				Transform obj = _visualVariant.DisconnectedParticles_TrainStation.transform;
				Vector3 position = obj.position;
				position = new Vector3(bounds.center.x, bounds.center.y, position.z);
				obj.position = position;
			}
		}

		public void OnReleasedFromScope(IScope scope)
		{
			_theme.UnregisterGameObjectFromThemeByGroupIndex(_level0.gameObject, groupIndex);
			_theme.UnregisterGameObjectFromThemeByGroupIndex(_visualVariant.Level1.gameObject, groupIndex);
			if (_destinationModel != null)
			{
				_viewIndex.RemoveDestinationView(this);
				_destinationModel.Unsubscribe(this);
				_destinationModel.Unsubscribe(_gameplayEventHandler);
				_destinationModel = null;
			}
		}

		public void SetPinViewVisible(bool isVisible)
		{
			Renderer[] componentsInChildren = _pinAnimatorToUse.GetComponentsInChildren<Renderer>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = isVisible;
			}
			_isShowingPins = isVisible;
			if (isVisible)
			{
				_pinAnimatorToUse.SetPinColors((_theme.GetTheme() as Theme).GetBuildingColor(groupIndex, ThemeComponentGroupTarget.BuildingTop));
			}
		}

		public Vector3 GetPositionOfPin(int pinIndex)
		{
			if (Diagnostics.Verify(pinIndex < _destinationModel.MaximumDemandBeforeTimerStarts, "Can't get a pin greater than the count we have!"))
			{
				return _pinAnimatorToUse.pins[pinIndex].PinCenterPosition;
			}
			return Vector3.zero;
		}

		public void Reset()
		{
			_destinationVisualVariants = GetComponentsInChildren<DestinationVisualVariant>(includeInactive: true);
			SetPinViewVisible(isVisible: true);
			_isPendingDeletion = false;
			groupIndex = -1;
			_visibility = DestinationVisibility.NotShown;
			_connectivity = NetworkConnectivity.Unknown;
			_lastNotifiedConnectivity = NetworkConnectivity.Unknown;
			_spawnTime = 0f;
			_observers.UnsubscribeAll();
			_visualVariant.PinAnimator.Reset();
			_visualVariant.StationPinAnimator.Reset();
			_visualVariant.StationPinAnimatorVertical.Reset();
			_visualVariant.PinAnimator.gameObject.SetActive(value: false);
			_visualVariant.StationPinAnimator.gameObject.SetActive(value: false);
			_visualVariant.StationPinAnimatorVertical.gameObject.SetActive(value: false);
			_isShowingPins = true;
			_vehiclesWaitingForPin.Clear();
			base.transform.localPosition = Vector3.zero;
			_level0 = null;
			_visualVariant.Level0Square.Hide(TransitionStyle.Snap);
			_visualVariant.Level0StationHorizontal.Hide(TransitionStyle.Snap);
			_visualVariant.Level0StationVertical.Hide(TransitionStyle.Snap);
			_visualVariant.Level1.Hide(TransitionStyle.Snap);
			ParticleSystem.MainModule main = _visualVariant.DisconnectedParticles_TrainStation.main;
			main.startRotationZ = 0f;
			_visualVariant.DisconnectedParticles_TrainStation.transform.localPosition = Vector3.zero;
			_visualVariant = _defaultVisualVariant;
		}

		public TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			_level0.Tick(timeInterval.Delta);
			_visualVariant.Level1.Tick(timeInterval.Delta);
			_pinAnimatorToUse.Tick(timeInterval, stepAlpha, (float)_constants.GracePeriodTime);
			if (_isPendingDeletion)
			{
				return TickResult.Destroy;
			}
			if (_destinationModel.isActive)
			{
				DestinationVisibility destinationVisibility = ((!_destinationModel.IsUpgraded) ? DestinationVisibility.Square : DestinationVisibility.Circle);
				if (destinationVisibility != _visibility)
				{
					AudioEventType audioEventType = AudioEventType.None;
					if (_visibility == DestinationVisibility.NotShown)
					{
						if (destinationVisibility == DestinationVisibility.Square)
						{
							_level0.Show(TransitionStyle.Tween);
						}
						else
						{
							_visualVariant.Level1.Show(TransitionStyle.Tween);
							_pinAnimatorToUse.Upgrade();
							audioEventType = AudioEventType.DestinationMutated;
						}
					}
					else
					{
						_level0.Hide(TransitionStyle.Tween);
						_visualVariant.Level1.Show(TransitionStyle.Tween);
						_pinAnimatorToUse.Upgrade();
						audioEventType = AudioEventType.DestinationMutated;
					}
					if (audioEventType != AudioEventType.None)
					{
						_audioSystem.ScheduleEvent(AudioEvent.CreateDestinationEvent(audioEventType, this));
					}
					_visibility = destinationVisibility;
					ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
					while (enumerator.MoveNext())
					{
						enumerator.Current.OnDemandLevelChanged(this);
					}
				}
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		private int VisualVariantIndex()
		{
			int destinationVisualVariantType = (int)City.Definition.destinationVisualVariantType;
			if (destinationVisualVariantType < _destinationVisualVariants.Length)
			{
				return destinationVisualVariantType;
			}
			Debug.LogWarning("Visual variant type index for City " + City.Definition.name + " is out of bounds.Please set the visual variant type index in the CityDefinition to a valid index, or add a new visual variant in the Destination prefab to match your variant type.");
			return 0;
		}

		private void SetVisualVariantActive()
		{
			_visualVariant = _destinationVisualVariants[VisualVariantIndex()];
			for (int i = 0; i < _destinationVisualVariants.Length; i++)
			{
				_destinationVisualVariants[i].gameObject.SetActive(i == VisualVariantIndex());
			}
		}

		public float GetAttenuation(bool zoom, float falloffFactor = 5f)
		{
			return _gameCamera.GetAttenuationFromWorld(base.transform.position, zoom, falloffFactor);
		}

		public Color GetBuildingColor(ThemeComponentGroupTarget groupTarget)
		{
			return (_theme.GetTheme() as Theme).GetBuildingColor(groupIndex, groupTarget);
		}

		public void OnDestinationReceivedVehicle(DestinationModel destination, VehicleModel vehicle)
		{
			bool flag = _pinAnimatorToUse.RemovePinForVehicleArrival();
			VehicleView vehicleView = _viewIndex.GetVehicleView(vehicle);
			if (vehicleView != null)
			{
				if (flag)
				{
					_vehiclesWaitingForPin.Add(vehicleView);
				}
				else
				{
					ShowPinOnVehicle(vehicleView);
				}
			}
		}

		private void ShowPinOnVehicle(VehicleView vehicleView)
		{
			if (_isShowingPins && !vehicleView.IsPendingDeletion)
			{
				PinView pinView = _scope.Get<PinView>();
				_viewClient.AddView(pinView);
				pinView.AppearAtVehicle(vehicleView, this);
			}
		}

		public void OnDestinationOvercrowded(DestinationModel destination)
		{
		}

		public void OnPinHidden()
		{
			while (_vehiclesWaitingForPin.Count > 0)
			{
				VehicleView vehicleView = _vehiclesWaitingForPin[0];
				_vehiclesWaitingForPin.RemoveAt(0);
				if (vehicleView.Model != null)
				{
					RoadType type = vehicleView.Model.CurrentFrame.lane.connection.output.type;
					if (type == RoadType.Carpark || type == RoadType.ParkingSpace)
					{
						ShowPinOnVehicle(vehicleView);
						break;
					}
				}
			}
		}

		public Bounds GetBounds()
		{
			float num = (float)TilemapModel.TileWidth;
			Vector3 vector = new Vector3(num, num, 0f) * 0.5f;
			Vector2Int coordinates = Model.TileModels[0].Coordinates;
			Vector3 center = new Vector3((float)coordinates.x * num, (float)coordinates.y * num, base.transform.position.z);
			Bounds result = new Bounds(center, Vector3.zero);
			foreach (TileModel tileModel in Model.TileModels)
			{
				Vector2Int coordinates2 = tileModel.Coordinates;
				Vector3 vector2 = new Vector3((float)coordinates2.x * num, (float)coordinates2.y * num, center.z);
				Vector3 point = vector2 - vector;
				result.Encapsulate(point);
				Vector3 point2 = vector2 + vector;
				result.Encapsulate(point2);
			}
			return result;
		}

		public void DoDisconnectedPulse()
		{
			ParticleSystem particleSystem = _visualVariant.DisconnectedParticles_Square;
			if (_destinationModel.IsTrainStation)
			{
				particleSystem = _visualVariant.DisconnectedParticles_TrainStation;
			}
			else if (_visibility == DestinationVisibility.Circle)
			{
				particleSystem = _visualVariant.DisconnectedParticles_Circle;
			}
			particleSystem.Play(withChildren: false);
		}

		public void CreateImminentFailAlert(bool isInitialAlert)
		{
			if (_isShowingPins)
			{
				ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnImminentFailAlert(this, isInitialAlert);
				}
			}
		}

		public void CreateBigPinAlert()
		{
			if (_isShowingPins)
			{
				ObserverList<IObserver>.Enumerator enumerator = _observers.GetEnumerator();
				while (enumerator.MoveNext())
				{
					enumerator.Current.OnBigPinAppeared(this);
				}
			}
		}

		public void OnDestinationChangedGroup(DestinationModel destinationModel, int oldGroupIndex, int newGroupIndex)
		{
			_theme.UnregisterGameObjectFromThemeByGroupIndex(_level0.gameObject, groupIndex);
			_theme.UnregisterGameObjectFromThemeByGroupIndex(_visualVariant.Level1.gameObject, groupIndex);
			groupIndex = newGroupIndex;
			_theme.RegisterGameObjectToThemeByGroupIndex(_level0.gameObject, groupIndex);
			_theme.RegisterGameObjectToThemeByGroupIndex(_visualVariant.Level1.gameObject, groupIndex);
			Color buildingColor = (_theme.GetTheme() as Theme).GetBuildingColor(newGroupIndex, ThemeComponentGroupTarget.BuildingTop);
			_pinAnimatorToUse.SetPinColors(buildingColor);
			SetDisconnectedParticleColour(buildingColor);
			UpdateDestinationMeshes();
		}

		private void SetDisconnectedParticleColour(Color color)
		{
			ParticleSystem.MainModule main = _visualVariant.DisconnectedParticles_Circle.main;
			main.startColor = color;
			main = _visualVariant.DisconnectedParticles_Square.main;
			main.startColor = color;
			main = _visualVariant.DisconnectedParticles_TrainStation.main;
			main.startColor = color;
		}

		public void OnDestinationRemoved(DestinationModel destinationModel)
		{
			_isPendingDeletion = true;
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
		}

		public void ApplyTheme(ITheme theme)
		{
			Color buildingColor = (theme as Theme).GetBuildingColor(groupIndex, ThemeComponentGroupTarget.BuildingTop);
			_pinAnimatorToUse.SetPinColors(buildingColor);
			SetDisconnectedParticleColour(buildingColor);
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			Color buildingColor = (oldTheme as Theme).GetBuildingColor(groupIndex, ThemeComponentGroupTarget.BuildingTop);
			Color buildingColor2 = (newTheme as Theme).GetBuildingColor(groupIndex, ThemeComponentGroupTarget.BuildingTop);
			Color color = Color.Lerp(buildingColor, buildingColor2, progress);
			_pinAnimatorToUse.SetPinColors(color);
			SetDisconnectedParticleColour(color);
			if (!(buildingColor == buildingColor2))
			{
				return ThemeBlendingResult.ContinueBlending;
			}
			return ThemeBlendingResult.StopBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}

		public void OnCreatedInScope(IScope scope)
		{
			_visualVariant = _defaultVisualVariant;
			_pinAnimatorToUse = _visualVariant.PinAnimator;
			_destinationVisualVariants = GetComponentsInChildren<DestinationVisualVariant>(includeInactive: true);
		}
	}
}
