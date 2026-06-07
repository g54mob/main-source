using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Audio;
using Motorways.Constants;
using Motorways.Models;
using Motorways.Themes;
using Server;
using UnityEngine;

namespace Motorways.Views.Trains
{
	public class TrainView : MonoBehaviour, IView, TrainModel.IObserver, IReusable, ICreatedInScopeHandler, IReleasedFromScopeHandler, IThemeComponent
	{
		private enum HeadlightDirectionState
		{
			FrontOn = 0,
			BackOn = 1,
			FrontToBackTransition = 2,
			BackToFrontTransition = 3
		}

		private enum HeadlightPowerState
		{
			On = 0,
			TurningOn = 1,
			Off = 2,
			TurningOff = 3
		}

		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				TrainView trainView = client.Scope.Get<TrainView>();
				trainView.Initialize(model as TrainModel);
				client.AddView(trainView);
			}
		}

		private TrainModel _model;

		[SerializeField]
		private Transform _trainTransform;

		[SerializeField]
		private Transform _firstCarriageTransform;

		[SerializeField]
		private Transform _secondCarriageTransform;

		[SerializeField]
		private VehicleTrailRenderer[] _trails;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private MotorwaysThemeDatabase _theme;

		[Dependency]
		private ViewIndex _viewIndex;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private VisualConstantsData _visualConstantsData;

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private ActivePlayer _activePlayer;

		[Dependency]
		private IAudioSystem _audioSystem;

		private LaneCursor _laneCursor;

		private Vector3 _lastMidpoint;

		[SerializeField]
		private Renderer _frontHeadlightBeam;

		[SerializeField]
		private Renderer _backHeadlightBeam;

		public TrainShadowView[] trainShadowViews;

		private HeadlightDirectionState _headlightDirectionState;

		private HeadlightPowerState _headlightPowerState = HeadlightPowerState.Off;

		private readonly TweenFloat _frontHeadlightIntensity = new TweenFloat();

		private readonly TweenFloat _backHeadlightIntensity = new TweenFloat();

		private readonly TweenFloat _globalHeadlightIntensity = new TweenFloat();

		private const float MaxHeadlightIntensity = 1f;

		private const float MinHeadlightIntensity = 0f;

		public TrainModel.BehaviorState _state = TrainModel.BehaviorState.Stopped;

		public float _speed;

		public TrainModel Model => _model;

		public Transform CenterTransform => _firstCarriageTransform;

		public bool IsTrailActive
		{
			get
			{
				bool flag = false;
				VehicleTrailRenderer[] trails = _trails;
				foreach (VehicleTrailRenderer vehicleTrailRenderer in trails)
				{
					flag |= vehicleTrailRenderer.gameObject.activeInHierarchy;
				}
				return flag;
			}
			set
			{
				VehicleTrailRenderer[] trails = _trails;
				for (int i = 0; i < trails.Length; i++)
				{
					trails[i].gameObject.SetActive(value);
				}
			}
		}

		public float Attenuation => _gameCamera.GetAttenuationFromWorld(_trainTransform.position);

		public Vector2 Pan => _gameCamera.GetPanFromWorld(_trainTransform.position);

		public void OnCreatedInScope(IScope scope)
		{
			TrainShadowView[] array = trainShadowViews;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].OnCreatedInScope(_visualConstantsData);
			}
		}

		private void Initialize(TrainModel trainModel)
		{
			_model = trainModel;
			_model.Subscribe(this);
			_model.Subscribe(this);
			_laneCursor = _scope.Get<LaneCursor>();
			_viewIndex.AddTrainView(this);
			UpdatePositionFromModel(0f);
			_headlightDirectionState = HeadlightDirectionState.FrontOn;
			_frontHeadlightIntensity.Set(1f);
			_frontHeadlightBeam.gameObject.SetActive(value: true);
			_backHeadlightIntensity.Set(0f);
			_backHeadlightBeam.gameObject.SetActive(value: false);
			SetHeadlightPowerState((!_activePlayer.IsNightModeEnabled) ? HeadlightPowerState.Off : HeadlightPowerState.On);
			UpdateHeadlights(0f);
			if (FeatureToggle.IsFeatureDisabled(Feature.VehicleTrails))
			{
				IsTrailActive = false;
			}
		}

		private void UpdatePositionFromModel(float stepAlpha)
		{
			float num = (float)_constants.trainCenterToWheelDistance;
			float num2 = (float)_constants.trainCarriageSeparationDistance;
			float additionalPrefixLength = 3f * num * 2f + 2f * num2;
			_speed = (float)_model.CurrentFrame.speed;
			if (_model.state != _state)
			{
				switch (_model.state)
				{
				case TrainModel.BehaviorState.Stopped:
					_audioSystem.ScheduleEvent(AudioEvent.CreateTrainEvent(-1.0, AudioEventType.TrainArrives, this));
					break;
				case TrainModel.BehaviorState.Driving:
					_audioSystem.ScheduleEvent(AudioEvent.CreateTrainEvent(-1.0, AudioEventType.TrainDeparts, this));
					break;
				}
				_state = _model.state;
			}
			_laneCursor.MoveToTrain(this, stepAlpha, _viewIndex, additionalPrefixLength);
			Vector3 position = _laneCursor.Position;
			if (!Mathf.Approximately(0f, (position - _lastMidpoint).sqrMagnitude))
			{
				_lastMidpoint = position;
				_laneCursor.Move(num);
				Vector3 position2 = _laneCursor.Position;
				if (!_laneCursor.MoveAlongRadius(num * -2f, out var position3))
				{
					position3 = position2 + (position - position2).normalized * (num * 2f);
				}
				PositionTransform(_trainTransform, position2, position3);
				_laneCursor.Move(0f - num2);
				position2 = _laneCursor.Position;
				if (Diagnostics.Verify(_laneCursor.MoveAlongRadius(num * -2f, out position3)))
				{
					PositionTransform(_firstCarriageTransform, position2, position3);
				}
				_laneCursor.Move(0f - num2);
				position2 = _laneCursor.Position;
				if (Diagnostics.Verify(_laneCursor.MoveAlongRadius(num * -2f, out position3)))
				{
					PositionTransform(_secondCarriageTransform, position2, position3);
				}
			}
		}

		private static void PositionTransform(Transform body, Vector3 frontWheelPosition, Vector3 backWheelPosition)
		{
			Vector3 vector = Vector3.Lerp(backWheelPosition, frontWheelPosition, 0.5f);
			body.localPosition = new Vector3(vector.x, vector.y, 0f);
			Vector2 vector2 = (frontWheelPosition - backWheelPosition).normalized;
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
			Quaternion localRotation = new Quaternion(0f, 0f, num2, num);
			body.localRotation = localRotation;
		}

		private void UpdateHeadlights(float deltaTime)
		{
			UpdateHeadlightPowerState();
			UpdateHeadlightDirectionState();
			if (_globalHeadlightIntensity.IsActive)
			{
				_globalHeadlightIntensity.Tick(deltaTime);
			}
			if (_frontHeadlightIntensity.IsActive)
			{
				_frontHeadlightIntensity.Tick(deltaTime);
			}
			if (_backHeadlightIntensity.IsActive)
			{
				_backHeadlightIntensity.Tick(deltaTime);
			}
			MaterialPropertyBlock materialPropertyBlock = _theme.MaterialPropertyBlock;
			_frontHeadlightBeam.GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetFloat(ShaderConstants.Intensity, _frontHeadlightIntensity.Value * _globalHeadlightIntensity.Value);
			_frontHeadlightBeam.SetPropertyBlock(materialPropertyBlock);
			_backHeadlightBeam.GetPropertyBlock(materialPropertyBlock);
			materialPropertyBlock.SetFloat(ShaderConstants.Intensity, _backHeadlightIntensity.Value * _globalHeadlightIntensity.Value);
			_backHeadlightBeam.SetPropertyBlock(materialPropertyBlock);
		}

		private void SetHeadlightPowerState(HeadlightPowerState newHeadlightPowerState)
		{
			_headlightPowerState = newHeadlightPowerState;
			_globalHeadlightIntensity.Set((newHeadlightPowerState == HeadlightPowerState.On) ? 1f : 0f);
		}

		private void UpdateHeadlightPowerState()
		{
			HeadlightPowerState headlightPowerState = _headlightPowerState;
			if (_activePlayer.IsNightModeEnabled)
			{
				switch (_headlightPowerState)
				{
				case HeadlightPowerState.Off:
				case HeadlightPowerState.TurningOff:
					headlightPowerState = HeadlightPowerState.TurningOn;
					break;
				case HeadlightPowerState.TurningOn:
					if (!_globalHeadlightIntensity.IsActive)
					{
						headlightPowerState = HeadlightPowerState.On;
					}
					break;
				}
			}
			else
			{
				switch (_headlightPowerState)
				{
				case HeadlightPowerState.On:
				case HeadlightPowerState.TurningOn:
					headlightPowerState = HeadlightPowerState.TurningOff;
					break;
				case HeadlightPowerState.TurningOff:
					if (!_globalHeadlightIntensity.IsActive)
					{
						headlightPowerState = HeadlightPowerState.Off;
					}
					break;
				}
			}
			if (headlightPowerState != _headlightPowerState)
			{
				switch (headlightPowerState)
				{
				case HeadlightPowerState.TurningOn:
					_globalHeadlightIntensity.Start(_globalHeadlightIntensity.Value, 1f, _visualConstantsData.TrainHeadlightDayNightTransitionTime, _visualConstantsData.TrainHeadlightDayNightTransitionEasingFunction);
					break;
				case HeadlightPowerState.TurningOff:
					_globalHeadlightIntensity.Start(_globalHeadlightIntensity.Value, 0f, _visualConstantsData.TrainHeadlightDayNightTransitionTime, _visualConstantsData.TrainHeadlightDayNightTransitionEasingFunction);
					break;
				}
				_headlightPowerState = headlightPowerState;
			}
		}

		private void UpdateHeadlightDirectionState()
		{
			HeadlightDirectionState headlightDirectionState = _headlightDirectionState;
			if (_activePlayer.IsNightModeEnabled)
			{
				switch (_model.CurrentFrame.direction)
				{
				case RailDirection.Forwards:
					if (_headlightDirectionState == HeadlightDirectionState.BackOn)
					{
						headlightDirectionState = HeadlightDirectionState.BackToFrontTransition;
					}
					if (_headlightDirectionState == HeadlightDirectionState.BackToFrontTransition && !_frontHeadlightIntensity.IsActive)
					{
						headlightDirectionState = HeadlightDirectionState.FrontOn;
					}
					break;
				case RailDirection.Backwards:
					if (_headlightDirectionState == HeadlightDirectionState.FrontOn)
					{
						headlightDirectionState = HeadlightDirectionState.FrontToBackTransition;
					}
					if (_headlightDirectionState == HeadlightDirectionState.FrontToBackTransition && !_backHeadlightIntensity.IsActive)
					{
						headlightDirectionState = HeadlightDirectionState.BackOn;
					}
					break;
				}
			}
			if (headlightDirectionState != _headlightDirectionState)
			{
				if (headlightDirectionState == HeadlightDirectionState.FrontToBackTransition || headlightDirectionState == HeadlightDirectionState.BackToFrontTransition)
				{
					float num = ((headlightDirectionState == HeadlightDirectionState.FrontToBackTransition) ? 1f : 0f);
					_frontHeadlightIntensity.Start(num, 1f - num, _visualConstantsData.TrainHeadlightSwitchTransitionTime, _visualConstantsData.TrainHeadlightSwitchTransitionEasingFunction);
					_backHeadlightIntensity.Start(1f - num, num, _visualConstantsData.TrainHeadlightSwitchTransitionTime, _visualConstantsData.TrainHeadlightSwitchTransitionEasingFunction);
					_frontHeadlightBeam.gameObject.SetActive(value: true);
					_backHeadlightBeam.gameObject.SetActive(value: true);
				}
				switch (headlightDirectionState)
				{
				case HeadlightDirectionState.FrontOn:
					_frontHeadlightIntensity.Set(1f);
					_backHeadlightIntensity.Set(0f);
					_frontHeadlightBeam.gameObject.SetActive(value: true);
					_backHeadlightBeam.gameObject.SetActive(value: false);
					break;
				case HeadlightDirectionState.BackOn:
					_frontHeadlightIntensity.Set(0f);
					_backHeadlightIntensity.Set(1f);
					_frontHeadlightBeam.gameObject.SetActive(value: false);
					_backHeadlightBeam.gameObject.SetActive(value: true);
					break;
				}
				_headlightDirectionState = headlightDirectionState;
			}
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			UpdatePositionFromModel(stepAlpha);
			UpdateHeadlights(tickTime.ScaledDelta);
			if (IsTrailActive)
			{
				VehicleTrailRenderer[] trails = _trails;
				for (int i = 0; i < trails.Length; i++)
				{
					trails[i].Tick(tickTime.UnpausedScaledDelta);
				}
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void Reset()
		{
			_model = null;
			_trainTransform.position = Vector3.zero;
			_trainTransform.localRotation = Quaternion.identity;
			_firstCarriageTransform.position = Vector3.zero;
			_firstCarriageTransform.localRotation = Quaternion.identity;
			_secondCarriageTransform.position = Vector3.zero;
			_secondCarriageTransform.localRotation = Quaternion.identity;
			_lastMidpoint = default(Vector3);
			_state = TrainModel.BehaviorState.Stopped;
			_speed = 0f;
			_headlightDirectionState = HeadlightDirectionState.FrontOn;
			_headlightPowerState = HeadlightPowerState.Off;
			_frontHeadlightIntensity.Reset();
			_backHeadlightIntensity.Reset();
			_globalHeadlightIntensity.Reset();
		}

		public void OnReleasedFromScope(IScope scope)
		{
			if (_laneCursor != null)
			{
				scope.Release(_laneCursor);
				_laneCursor = null;
			}
		}

		public void InitializeTheme(IThemeDatabase themeDatabase)
		{
			if (themeDatabase.GetTheme() is Theme theme)
			{
				Color color = theme.GetColor(ThemedMaterialType.Train);
				VehicleTrailRenderer[] trails = _trails;
				for (int i = 0; i < trails.Length; i++)
				{
					trails[i].Color = color;
				}
			}
		}

		public void ApplyTheme(ITheme theme)
		{
			if (theme is Theme theme2)
			{
				Color color = theme2.GetColor(ThemedMaterialType.Train);
				VehicleTrailRenderer[] trails = _trails;
				for (int i = 0; i < trails.Length; i++)
				{
					trails[i].Color = color;
				}
			}
		}

		public ThemeBlendingResult ApplyBlendedTheme(ITheme oldTheme, ITheme newTheme, float progress)
		{
			if (oldTheme is Theme theme && newTheme is Theme theme2)
			{
				Color color = theme.GetColor(ThemedMaterialType.Train);
				Color color2 = theme2.GetColor(ThemedMaterialType.Train);
				Color color3 = Color.Lerp(color, color2, progress);
				VehicleTrailRenderer[] trails = _trails;
				for (int i = 0; i < trails.Length; i++)
				{
					trails[i].Color = color3;
				}
			}
			return ThemeBlendingResult.ContinueBlending;
		}

		public void ReleaseTheme(IThemeDatabase themeDatabase)
		{
		}
	}
}
