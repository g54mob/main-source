using System;
using Assets.Scripts.Input;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ReactionControlNozzleScript : PartModifierScript
	{
		private Func<bool> _activateFunc;

		private bool _active;

		private AircraftScript _aircraft;

		private Transform _centerOfThrust;

		private AircraftControls _controls;

		private AudioSource _audio;

		private float _functionalHealth = 1f;

		private Func<float> _inputAxis;

		private string _inputId;

		private Transform _myTransform;

		private PartScript _part;

		private ParticleSystem _particleSystem;

		private ParticleSystem.EmissionModule _particleSystemEmission;

		private ParticleSystem.MainModule _particleSystemMain;

		private float _particleSystemStartLifetime;

		private float _particleSystemStartSpeed;

		private bool _rcnApplyForces;

		private float _rcnThrottle;

		private ReactionControlNozzleData _reactionControlNozzle;

		private Rigidbody _rigidBodyToActOn;

		private float _thrustInputReverse = 1f;

		private VtolManagerScript _vtolScript;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Initialize(ReactionControlNozzleData engineExaust)
		{
			_reactionControlNozzle = engineExaust;
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				_functionalHealth = Mathf.Max(0f, _functionalHealth - UnityEngine.Random.value * (float)level);
			}
		}

		protected virtual void OnDestroy()
		{
			_aircraft.OnAircraftStructureChanged -= OnAircraftStructureChanged;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterFirstFrameLateUpdate(OnFirstFrameLateUpdate, CraftUpdateFlags.FlightDefault);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocal);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightDefault);
		}

		private void ConfigureRcnBasedOnLocationAndOrientation()
		{
			Vector3 lhs;
			Vector3 vector;
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				lhs = _centerOfThrust.position - _part.Aircraft.CenterOfMass.CenterOfMass;
				vector = _part.Aircraft.transform.InverseTransformPoint(_part.Aircraft.OrientedCenterOfMassRigidBodies.position) - _part.Aircraft.transform.InverseTransformPoint(_centerOfThrust.position);
			}
			else
			{
				lhs = _centerOfThrust.position - _part.Aircraft.OrientedCenterOfMassRigidBodies.position;
				vector = _part.Aircraft.transform.InverseTransformPoint(_part.Aircraft.OrientedCenterOfMassRigidBodies.position) - _part.Aircraft.transform.InverseTransformPoint(_centerOfThrust.position);
			}
			Vector3 vector2 = Vector3.Cross(lhs, base.transform.TransformDirection(Vector3.up));
			Vector3 vector3 = Utilities.Abs(vector2);
			bool flag = vector.z < 0f;
			_thrustInputReverse = 1f;
			if (Utilities.CompareFloats(Mathf.Max(vector3.x, Mathf.Max(vector3.y, vector3.z)), vector3.x))
			{
				_inputId = GameInputs.Instance.Pitch.Id;
				_inputAxis = _controls.GetAxisGetter(_inputId);
				if ((vector2.x > 0f && !flag) || (vector2.x > 0f && flag))
				{
					_thrustInputReverse = -1f;
				}
			}
			else if (Utilities.CompareFloats(Mathf.Max(vector3.y, Mathf.Max(vector3.x, vector3.z)), vector3.y))
			{
				_inputId = GameInputs.Instance.Yaw.Id;
				_inputAxis = _controls.GetAxisGetter(_inputId);
				if ((vector2.y > 0f && !flag) || (vector2.y > 0f && flag))
				{
					_thrustInputReverse = -1f;
				}
			}
			else if (Utilities.CompareFloats(Mathf.Max(vector3.z, Mathf.Max(vector3.x, vector3.y)), vector3.z))
			{
				_inputId = GameInputs.Instance.Roll.Id;
				_inputAxis = _controls.GetAxisGetter(_inputId);
				if (vector2.z < 0f)
				{
					_thrustInputReverse = -1f;
				}
			}
			if (base.LoadContext == CraftLoadContext.Designer)
			{
				if (_inputId == GameInputs.Instance.Roll.Id)
				{
					_reactionControlNozzle.Type = ReactionControlNozzleData.ReactionControlNozzleType.Roll;
				}
				else if (_inputId == GameInputs.Instance.Pitch.Id)
				{
					_reactionControlNozzle.Type = ReactionControlNozzleData.ReactionControlNozzleType.Pitch;
				}
				else if (_inputId == GameInputs.Instance.Yaw.Id)
				{
					_reactionControlNozzle.Type = ReactionControlNozzleData.ReactionControlNozzleType.Yaw;
				}
				_reactionControlNozzle.Reverse = _thrustInputReverse == -1f;
			}
			else
			{
				Debug.LogWarning("Why the HELL is ConfigureRcnBasedOnLocationAndOrientation being called in game mode???  You debuggin' or some shit? ");
			}
		}

		private void OnAircraftStructureChanged()
		{
			if (base.LoadContext == CraftLoadContext.Designer && _reactionControlNozzle.AutoAssignType)
			{
				ConfigureRcnBasedOnLocationAndOrientation();
			}
		}

		private void OnFirstFrameLateUpdate(in CraftUpdateFrameData frame)
		{
			if (_vtolScript.ReactionControlNozzleCount > 30)
			{
				_particleSystemEmission.rateOverTime = new ParticleSystem.MinMaxCurve(_particleSystemEmission.rateOverTime.constantMax * Mathf.Clamp(1f / (float)_vtolScript.ReactionControlNozzleCount, 0.1f, 1f));
			}
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			_active = _activateFunc();
			if (_rcnApplyForces)
			{
				Vector3 position = _centerOfThrust.position;
				Vector3 force = -_myTransform.TransformDirection(Vector3.up) * (Mathf.Abs(_rcnThrottle) * _reactionControlNozzle.Power);
				_rigidBodyToActOn.AddForceAtPosition(force, position);
				float amount = _rcnThrottle * _reactionControlNozzle.FuelConsumptionRate * Time.fixedDeltaTime;
				_aircraft.UseFuel(amount);
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_part = base.transform.GetComponent<PartScript>();
			_aircraft = _part.Aircraft;
			_activateFunc = base.PartScript.Aircraft.Controls.GetActivatorGetter(_reactionControlNozzle.ActivationGroup, base.PartScript, valueIfZero: true);
			_aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
			_myTransform = base.transform;
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_rigidBodyToActOn = _part.Body.GetComponent<Rigidbody>();
			}
			_controls = _part.Aircraft.Controls;
			_centerOfThrust = Utilities.FindFirstGameObjectMyselfOrChildren("CenterOfThrust", _part.gameObject).transform;
			_particleSystem = _centerOfThrust.Find("Particle System").GetComponent<ParticleSystem>();
			_particleSystemMain = _particleSystem.main;
			_particleSystemEmission = _particleSystem.emission;
			_particleSystemEmission.enabled = false;
			_particleSystemStartLifetime = _particleSystemMain.startLifetime.constantMax;
			_particleSystemStartSpeed = _particleSystemMain.startSpeed.constantMax;
			if (_reactionControlNozzle.AutoAssignType && base.LoadContext == CraftLoadContext.Designer)
			{
				ConfigureRcnBasedOnLocationAndOrientation();
			}
			else
			{
				switch (_reactionControlNozzle.Type)
				{
				case ReactionControlNozzleData.ReactionControlNozzleType.Roll:
					_inputId = GameInputs.Instance.Roll.Id;
					break;
				case ReactionControlNozzleData.ReactionControlNozzleType.Pitch:
					_inputId = GameInputs.Instance.Pitch.Id;
					break;
				case ReactionControlNozzleData.ReactionControlNozzleType.Yaw:
					_inputId = GameInputs.Instance.Yaw.Id;
					break;
				}
				_inputAxis = _controls.GetAxisGetter(_inputId, -1f, base.PartScript);
				_thrustInputReverse = ((!_reactionControlNozzle.Reverse) ? 1 : (-1));
			}
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_audio = GetComponent<AudioSource>();
			}
			return UniTask.CompletedTask;
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			_vtolScript = _part.Aircraft.VtolManagerScript;
			_vtolScript.RegisterRcn(this);
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			_rcnApplyForces = false;
			if (_active && _aircraft.Fuel > 0f && _vtolScript.VtolEngineCount > 0)
			{
				if (!frame.Paused)
				{
					float num = ((_inputAxis == null) ? 0f : _inputAxis());
					num *= _functionalHealth;
					if ((num < 0f && _thrustInputReverse < 0f) || (num > 0f && _thrustInputReverse > 0f))
					{
						_rcnApplyForces = true;
						_particleSystemEmission.enabled = true;
						_particleSystemMain.startSpeed = _particleSystemStartSpeed * Mathf.Abs(num);
						_particleSystemMain.startLifetime = _particleSystemStartLifetime * Mathf.Abs(num);
						_rcnThrottle = Mathf.Abs(num);
					}
					else
					{
						_rcnThrottle = 0f;
						_particleSystemEmission.enabled = false;
					}
				}
			}
			else
			{
				_particleSystemEmission.enabled = false;
			}
			if (!(_audio != null))
			{
				return;
			}
			if (_rcnThrottle > 0.01f && _active)
			{
				if (!_audio.isPlaying)
				{
					_audio.Play();
					_audio.timeSamples = (int)(UnityEngine.Random.value * (float)_audio.timeSamples);
				}
				_audio.volume = 0.75f * _rcnThrottle;
				_audio.pitch = Mathf.Lerp(0.75f, 1.25f, _rcnThrottle);
			}
			else if (_audio.isPlaying)
			{
				_audio.Stop();
				_audio.volume = 0f;
			}
		}
	}
}
