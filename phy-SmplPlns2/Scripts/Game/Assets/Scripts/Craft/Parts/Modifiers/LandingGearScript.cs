using System.Collections.Generic;
using Assets.Scripts.Audio;
using Assets.Scripts.Flight.Simulation.CustomWheelCollider;
using Assets.Scripts.Levels;
using Jundroo.Common.Pool;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public abstract class LandingGearScript : PartModifierScript, IWheelPart
	{
		private bool _aircraftStructureChanged;

		private float _dynamicSensitivity;

		private float _functionalHealth = 1f;

		private InputControllerScript _inputController;

		private float _prevTurningInputValue;

		private SingleSoundManager _soundManager;

		private ParticleSystem _tireSmoke;

		private float _touchdownSquealDuration;

		private WheelColliderSource _wc;

		public bool Grounded
		{
			get
			{
				if (_wc != null)
				{
					return _wc.IsGrounded;
				}
				return false;
			}
		}

		bool IWheelPart.IsGrounded => WheelCollider.IsGrounded;

		public LandingGearData LandingGear { get; set; }

		public bool LandingGearEnabled { get; set; }

		public float LandingGearTurnTime => 0.25f;

		public bool TurningEnabled
		{
			get
			{
				return LandingGear.TurningEnabled;
			}
			set
			{
				LandingGear.TurningEnabled = value;
			}
		}

		public float TurningSensitivity
		{
			get
			{
				return LandingGear.Sensitivity;
			}
			set
			{
				LandingGear.Sensitivity = value;
			}
		}

		Vector3 IWheelPart.WheelPosition => _wc?.transform.position ?? base.transform.position;

		float IWheelPart.WheelRadius => WheelCollider.WheelRadius;

		float IWheelPart.WheelSpeed => WheelCollider.SpeedOverGround;

		protected WheelColliderSource WheelCollider => _wc;

		private float LandingGearTurnStep => _inputController.InputController.MaxValue * Time.deltaTime / LandingGearTurnTime;

		public void Initialize(LandingGearData landingGear)
		{
			LandingGear = landingGear;
		}

		public override void OnBeginReposition()
		{
			base.OnBeginReposition();
			if (_wc != null)
			{
				_wc.BrakeInput = 0f;
				_wc.DisableParkingBrake();
			}
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				float value = Random.value;
				if (value < 0.3f && TurningEnabled)
				{
					TurningEnabled = false;
					_functionalHealth = Mathf.Max(0f, _functionalHealth - Random.value);
				}
				else if (value < 0.6f)
				{
					_functionalHealth = Mathf.Max(0f, _functionalHealth - Random.value);
				}
			}
		}

		protected virtual void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			if (_aircraftStructureChanged)
			{
				ProcessAircraftStructureChanged();
			}
			if (TurningEnabled)
			{
				float num = 20f * TurningSensitivity;
				float num2 = num * num;
				float num3 = 0.02f * TurningSensitivity;
				float num4 = 1f - num3;
				float speedOverGround = WheelCollider.SpeedOverGround;
				float dynamicSensitivity = ((!(speedOverGround > num)) ? (1f - num4 * (speedOverGround * speedOverGround / num2)) : num3);
				_dynamicSensitivity = dynamicSensitivity;
			}
		}

		protected virtual void OnStart(in CraftUpdateFrameData frame)
		{
			if (base.PartModifier.UsedInPropMode != base.PartScript.Aircraft.IsNonFlyableAircraft)
			{
				return;
			}
			LandingGearEnabled = true;
			_inputController = base.PartScript.GetModifier<InputControllerScript>();
			Vector3 vector = base.PartScript.Aircraft.transform.InverseTransformPoint(base.PartScript.transform.position);
			bool flag = base.PartScript.Aircraft.CenterOfMass.CenterOfMass.z < vector.z;
			if (base.LoadContext != CraftLoadContext.Flight)
			{
				return;
			}
			if (!flag && _inputController != null)
			{
				_inputController.InputController.Invert = !_inputController.InputController.Invert;
			}
			_soundManager = LevelBase.CurrentLevel.GetSingleSoundManager(AudioStore.SkidAudio, AudioStore.Rumble);
			_tireSmoke = Utilities.GetFirstChild<ParticleSystem>("TireSmokeParticles", base.PartScript.gameObject);
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("Physics", base.PartScript.gameObject);
			if (gameObject != null)
			{
				gameObject.SetActive(value: true);
				_wc = gameObject.GetComponent<WheelColliderSource>();
				_wc.Rigidbody = base.PartScript.Body.RigidBody;
				_wc.SuspensionDistance = LandingGear.SuspensionDistance;
				_wc.BrakeTorque = LandingGear.BrakeTorque;
				_wc.OnFastTouchdown += OnFastTouchdown;
				if (base.PartScript.Part.PartScale.HasValue)
				{
					float y = base.PartScript.Part.PartScale.Value.y;
					_wc.Scale = y;
					_wc.WheelRadius *= y;
					_wc.SuspensionDistance = LandingGear.SuspensionDistance * y;
				}
				UpdateWheelColliderSettings();
				if (!base.PartScript.PhysicsEnabled)
				{
					_wc.enabled = false;
				}
			}
			base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
		}

		protected virtual void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_aircraftStructureChanged)
			{
				ProcessAircraftStructureChanged();
			}
			_wc.Rigidbody = base.PartScript.Body.RigidBody;
			UpdateLandingGear();
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightUnpaused);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private void OnAircraftStructureChanged()
		{
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				_aircraftStructureChanged = true;
			}
		}

		private void OnFastTouchdown(float overStress)
		{
			if (base.PartScript.ConnectedToMainCockpit)
			{
				base.PartScript.Aircraft.OnFastTouchdown(overStress);
			}
			_tireSmoke?.Play();
			_touchdownSquealDuration = 0.3f;
		}

		private void ProcessAircraftStructureChanged()
		{
			_aircraftStructureChanged = false;
			_wc.Rigidbody = base.PartScript.Body.RigidBody;
			UpdateWheelColliderSettings();
		}

		private void UpdateLandingGear()
		{
			if (!LandingGearEnabled)
			{
				return;
			}
			float num = 0f;
			if (base.PartScript.Body != null && base.PartScript.Body.GetComponent<Rigidbody>() != null)
			{
				AircraftScript aircraft = base.PartScript.Aircraft;
				float num2 = 0.5f;
				if (aircraft.Controls.Brake > 0f)
				{
					_wc.BrakeInput = aircraft.Controls.Brake * _functionalHealth;
					num2 = 1f;
				}
				else if (_wc != null)
				{
					_wc.BrakeInput = 0f;
				}
				if (_wc.IsGrounded)
				{
					num = Mathf.Max(Mathf.Abs(_wc.ForwardSlip) * num2, Mathf.Abs(_wc.SidewaysSlip)) * _wc.SurfaceFriction / 100f;
					num = Mathf.Clamp(num, 0f, 1f);
					num *= num;
				}
				if (_inputController != null)
				{
					float value = _inputController.Value;
					float num3 = _prevTurningInputValue + ((value > _prevTurningInputValue) ? LandingGearTurnStep : (0f - LandingGearTurnStep));
					if (Utilities.CompareFloats(num3, value, LandingGearTurnStep + 0.0001f))
					{
						num3 = value;
					}
					_prevTurningInputValue = num3;
					if (_wc != null && TurningEnabled && _inputController != null)
					{
						_wc.SteerAngle = num3 * _dynamicSensitivity;
					}
				}
			}
			if (_touchdownSquealDuration > 0f)
			{
				_touchdownSquealDuration -= Time.deltaTime;
				num = 1f;
			}
			if (_soundManager != null && num > 0f)
			{
				_soundManager.AddSound(base.transform.position, num);
			}
		}

		private void UpdateWheelColliderSettings()
		{
			List<PartData> value;
			using (CollectionPool<List<PartData>, PartData>.Get(out value))
			{
				PartGraph.GetConnectedParts(base.PartScript.Part, breakOnRigidBodyBoundary: false, value);
				GroupCenterOfMass groupCenterOfMass = new GroupCenterOfMass(value);
				Vector3 vector = WheelCollider.transform.InverseTransformPoint(groupCenterOfMass.CenterOfMass);
				vector.y = 0f;
				float magnitude = vector.magnitude;
				JointSpringSource suspensionSpring = default(JointSpringSource);
				float num = LandingGear.SuspensionDistance * (1f - LandingGear.SuspensionStiffness);
				suspensionSpring.Spring = groupCenterOfMass.LoadedMass * 9.81f / num;
				suspensionSpring.Damper = suspensionSpring.Spring / 7f;
				if (magnitude > 1f)
				{
					suspensionSpring.Spring /= magnitude;
					suspensionSpring.Damper /= magnitude;
				}
				suspensionSpring.Spring *= LandingGear.Spring;
				suspensionSpring.Damper *= LandingGear.Damper;
				suspensionSpring.TargetPosition = 0f;
				_wc.SuspensionSpring = suspensionSpring;
				float num2 = 1f;
				float num3 = num2 * 0.75f;
				_wc.CreateFrictionCurves(3f, num2, 5f, num3, 3f, num2 * 1.5f, 5f, num3 * 1.5f);
			}
		}
	}
}
