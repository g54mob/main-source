using System;
using Client;
using Factory;
using Factory.Pools;
using FixMath;
using Motorways.Models;
using Server;
using UnityEngine;

namespace Motorways.Views.Boats
{
	public class BoatView : MonoBehaviour, IView, BoatModel.IObserver, IReusable
	{
		public class Builder : IViewBuilder
		{
			public void CreateView(ViewClient client, ISimulation simulation, IModel model, Fix64 timestamp)
			{
				BoatView boatView = client.Scope.Get<BoatView>();
				boatView.Initialize(model as BoatModel);
				client.AddView(boatView);
			}
		}

		private BoatModel _model;

		private Vector3 _lastPosition;

		private static Fix64 RESUME_DOCKING_DISTANCE = (Fix64)4L;

		[SerializeField]
		private Transform _boatTransform;

		[SerializeField]
		private ParticleSystem LeftRipple;

		[SerializeField]
		private ParticleSystem RightRipple;

		[SerializeField]
		public MeshRenderer BoatLight;

		[SerializeField]
		private Transform _shadowTransform;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private MotorwaysGame _motorwaysGame;

		[Dependency]
		private MotorwaysThemeDatabase _theme;

		[Dependency]
		private ViewIndex _viewIndex;

		[Dependency]
		private ViewClient _viewClient;

		[Dependency]
		private IScope _scope;

		[Dependency]
		private VisualConstantsData _visualConstantsData;

		[Dependency]
		private SimulationConstantsData _constants;

		[Dependency]
		private ActivePlayer _activePlayer;

		private LaneCursor _laneCursor;

		private bool _isDocking;

		private Quaternion _dockingRotation;

		private Vector3 _dockingPosition;

		private Vector3 _currentDirection;

		private float _bobbingTimer;

		[SerializeField]
		private BoatTrail _boatTrail;

		private float _boatLightTimer;

		private ParticleSystem.EmissionModule _leftRippleEmission;

		private ParticleSystem.EmissionModule _rightRippleEmission;

		private ParticleSystem.MainModule _leftRippleMainModule;

		private ParticleSystem.MainModule _rightRippleMainModule;

		public BoatModel Model => _model;

		public float Attenuation => _gameCamera.GetAttenuationFromWorld(_boatTransform.position);

		public Vector2 Pan => _gameCamera.GetPanFromWorld(_boatTransform.position);

		private void Initialize(BoatModel boatModel)
		{
			_model = boatModel;
			_model.Subscribe(this);
			_viewIndex.AddBoatView(this);
			_laneCursor = _scope.Get<LaneCursor>();
			UpdatePositionFromModel(0f);
			_boatTrail.SetVisualConstantsData(_visualConstantsData);
			_leftRippleEmission = LeftRipple.emission;
			_rightRippleEmission = RightRipple.emission;
			_leftRippleMainModule = LeftRipple.main;
			_rightRippleMainModule = RightRipple.main;
			Fix64 distanceToTerminal;
			CarparkModel firstTerminal = _model.CurrentFrame.tile.GetFirstTerminal(boatModel.CurrentFrame.DistanceAlongPathSegment, _constants.boatCenterToBowDistance, boatModel.CurrentFrame.direction, out distanceToTerminal);
			UpdateDockingGeometry(firstTerminal);
			if (_motorwaysGame.StartReason == GameStartReason.Resumed && distanceToTerminal < RESUME_DOCKING_DISTANCE)
			{
				BoatModel.BehaviorState state = _model.state;
				_isDocking = state == BoatModel.BehaviorState.ApproachingTerminal || state == BoatModel.BehaviorState.Undocking || state == BoatModel.BehaviorState.Stopped || state == BoatModel.BehaviorState.Stopping;
			}
			else
			{
				_isDocking = false;
			}
		}

		public void UpdatePositionFromModel(float stepAlpha)
		{
			_laneCursor.MoveToBoat(this, _viewIndex, stepAlpha);
			float num = _visualConstantsData.boatMovementBobbingPeriod * _bobbingTimer;
			if ((double)num >= Math.PI * 2.0)
			{
				_bobbingTimer = 0f;
			}
			Vector3 position = _laneCursor.Position;
			_laneCursor.Move(_visualConstantsData.boatMovementLookAheadDistance);
			if (_model.state != BoatModel.BehaviorState.Stopped && !Mathf.Approximately(0f, (position - _laneCursor.Position).sqrMagnitude))
			{
				Vector2 vector = (position - _laneCursor.Position).normalized;
				_currentDirection = vector;
			}
			position += _visualConstantsData.boatMovementBobbingAmplitude * (float)Math.Sin(num) * _currentDirection.RotateCW2D();
			position += _visualConstantsData.boatMovementBobbingForwardsAmplitude * (float)Math.Sin((double)num + Math.PI) * _currentDirection;
			_boatTransform.position = position - (float)_constants.boatCenterToPivotDistance * _currentDirection;
			_boatTransform.rotation = Quaternion.FromToRotation(Vector3.down, _currentDirection);
			_lastPosition = position;
			BoatModel.BehaviorState state = _model.state;
			if (state == BoatModel.BehaviorState.Stopping || state == BoatModel.BehaviorState.Stopped || state == BoatModel.BehaviorState.Undocking)
			{
				if (_isDocking)
				{
					float num2 = Mathf.Lerp((float)_model.CurrentFrame.speed, (float)_model.NextFrame.speed, stepAlpha);
					float num3 = (float)((_model.state == BoatModel.BehaviorState.Undocking) ? _constants.boatUndockingSpeedThreshold : _constants.boatDockingSpeedThreshold);
					float num4 = Mathf.Clamp01((num3 - num2) / num3);
					float num5 = 0.5f * (1f - Mathf.Cos((float)Math.PI * num4));
					_boatTransform.rotation = Quaternion.Lerp(_boatTransform.rotation, _dockingRotation, num5);
					_boatTransform.position = Vector3.Lerp(_boatTransform.position, _dockingPosition, num5);
					if (_model.state == BoatModel.BehaviorState.Undocking)
					{
						float t = Mathf.Sin((float)Math.PI * num5);
						_boatTransform.position += Vector3.Lerp(Vector3.zero, _constants.boatUndockingMidpointOffset, t);
					}
				}
			}
			else if (_model.state != BoatModel.BehaviorState.ApproachingTerminal)
			{
				_isDocking = false;
			}
			if (_model.state == BoatModel.BehaviorState.Stopped && _model.GetTargetTerminal() == null)
			{
				Vector3 vector2 = -_currentDirection;
				Quaternion a = Quaternion.FromToRotation(Vector3.down, _currentDirection);
				Quaternion b = Quaternion.FromToRotation(Vector3.down, vector2);
				Vector3 a2 = _lastPosition - (float)_constants.boatCenterToPivotDistance * _currentDirection;
				Vector3 b2 = _lastPosition - (float)_constants.boatCenterToPivotDistance * vector2;
				float t2 = (float)((_constants.boatTerminalWaitTime - _model.DelayBeforeStarting) / _constants.boatTerminalWaitTime);
				_boatTransform.position = Vector3.Lerp(a2, b2, t2);
				_boatTransform.rotation = Quaternion.Lerp(a, b, t2);
			}
		}

		public void UpdateRippleEmission(float stepAlpha, float timeDelta)
		{
			float num = (float)(Fix64.Lerp(_model.CurrentFrame.speed, _model.NextFrame.speed, (Fix64)stepAlpha) / _constants.boatSpeed);
			_leftRippleEmission.rateOverTime = num * _visualConstantsData.boatMaximumRippleEmission - _visualConstantsData.boatRippleEmissionStopFactor;
			_rightRippleEmission.rateOverTime = num * _visualConstantsData.boatMaximumRippleEmission - _visualConstantsData.boatRippleEmissionStopFactor;
			float simulationSpeed = timeDelta * _visualConstantsData.boatRippleSpeed;
			_leftRippleMainModule.simulationSpeed = simulationSpeed;
			_rightRippleMainModule.simulationSpeed = simulationSpeed;
			if (_scope.Get<Simulation>().IsPaused)
			{
				LeftRipple.Pause();
				RightRipple.Pause();
			}
			else
			{
				LeftRipple.Play();
				RightRipple.Play();
			}
		}

		private void UpdateBoatLight(float deltaTime)
		{
			if (_scope.Get<ActivePlayer>().IsNightModeEnabled)
			{
				if (_boatLightTimer > _visualConstantsData.boatLightBlinkTime)
				{
					_boatLightTimer = 0f;
					BoatLight.enabled = !BoatLight.enabled;
				}
				_boatLightTimer += deltaTime;
			}
			else
			{
				BoatLight.enabled = true;
			}
		}

		public TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			_bobbingTimer += tickTime.ScaledDelta;
			UpdatePositionFromModel(stepAlpha);
			UpdateRippleEmission(stepAlpha, tickTime.ScaledDelta);
			float distanceToTarget = (((float)_model.DistanceToTarget > 0f) ? ((float)_model.DistanceToTarget) : ((float)_model.distanceTraveledSinceLastTarget));
			_boatTrail.UpdateBoatTrail(tickTime.ScaledDelta, distanceToTarget);
			UpdateBoatLight(tickTime.ScaledDelta);
			_shadowTransform.localPosition = Quaternion.Inverse(_boatTransform.localRotation) * ((Vector3.right + Vector3.down) * _visualConstantsData.boatShadowPivotDistance);
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		public void OnTargetTerminalSet(CarparkModel terminal)
		{
			if (terminal != null)
			{
				_isDocking = true;
				UpdateDockingGeometry(terminal);
			}
		}

		private void UpdateDockingGeometry(CarparkModel terminal)
		{
			CarparkView carparkViewFromModel = _viewClient.GetCarparkViewFromModel(terminal);
			if (!(carparkViewFromModel == null))
			{
				_dockingPosition = carparkViewFromModel.BoatDockingTransform.position;
				_dockingRotation = carparkViewFromModel.BoatDockingTransform.rotation;
			}
		}

		public void Reset()
		{
			_model = null;
			_lastPosition = default(Vector3);
			_boatTransform.position = Vector3.zero;
			_boatTransform.localRotation = Quaternion.identity;
			_currentDirection = default(Vector3);
			_boatLightTimer = 0f;
			_leftRippleEmission = default(ParticleSystem.EmissionModule);
			_rightRippleEmission = default(ParticleSystem.EmissionModule);
			_leftRippleMainModule = default(ParticleSystem.MainModule);
			_rightRippleMainModule = default(ParticleSystem.MainModule);
			_bobbingTimer = 0f;
			_isDocking = false;
			_dockingPosition = Vector3.zero;
			_dockingRotation = Quaternion.identity;
		}
	}
}
