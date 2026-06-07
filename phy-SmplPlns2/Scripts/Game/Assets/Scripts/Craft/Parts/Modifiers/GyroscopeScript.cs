using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class GyroscopeScript : PartModifierScript
	{
		public GyroscopeData Gyroscope;

		private bool _active;

		private Func<bool> _activeFunc;

		private Vector3 _currentEuler;

		private float _functionalHealth = 1f;

		private InputControllerScript _pitchInput;

		private Transform _pitchTransform;

		private IRigidBody _rigidbody;

		private InputControllerScript _rollInput;

		private Transform _rollTransform;

		private Transform _spinTransform;

		private Vector3 _targetVector = Vector3.up;

		private Vector3 _transformUp = new Vector3(0f, 1f, 0f);

		private InputControllerScript _yawInput;

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void Initialize(GyroscopeData modifier)
		{
			Gyroscope = modifier;
			if (base.PartScript.LoadContext == CraftLoadContext.Flight)
			{
				_rigidbody = base.PartScript.Body.RigidBody;
				base.PartScript.Aircraft.OnAircraftStructureChanged += OnAircraftStructureChanged;
			}
		}

		public override void OnDamageLevelIncreased(PartDamageLevel level, float lastDamage, Vector3 lastDamagePosition, Vector3 lastDamageDirection)
		{
			if (level > PartDamageLevel.Light)
			{
				_functionalHealth = Mathf.Max(0f, _functionalHealth - UnityEngine.Random.value);
				_transformUp = (_transformUp + UnityEngine.Random.insideUnitSphere * UnityEngine.Random.value).normalized;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterFixedUpdate(OnFixedUpdate, CraftUpdateFlags.FlightLocal);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.FlightUnpaused);
		}

		private static float LimitAngle180(float angle)
		{
			if (angle > 180f)
			{
				angle -= 360f;
			}
			else if (angle < -180f)
			{
				angle += 360f;
			}
			return angle;
		}

		private void OnAircraftStructureChanged()
		{
			if (!GameState.Instance.IsInDesigner && base.PartScript.gameObject.activeInHierarchy)
			{
				_rigidbody = base.PartScript.Body.RigidBody;
			}
		}

		private void OnFixedUpdate(in CraftUpdateFrameData frame)
		{
			_active = _activeFunc();
			if (_active)
			{
				float num = _rollInput.Value * Gyroscope.RollRange;
				float num2 = _pitchInput.Value * Gyroscope.PitchRange;
				float num3 = _yawInput.Value * Gyroscope.YawPower * _functionalHealth;
				num = (float.IsNaN(num) ? 0f : num);
				num2 = (float.IsNaN(num2) ? 0f : num2);
				num3 = (float.IsNaN(num3) ? 0f : num3);
				_rigidbody.AddRelativeTorque(0f, num3, 0f);
				if (!(Gyroscope.Speed <= 0f) && !(Gyroscope.Stability <= 0f))
				{
					Quaternion quaternion = Quaternion.Euler(num2, base.transform.eulerAngles.y, 0f - num);
					Vector3 vector = Vector3.Cross(Quaternion.AngleAxis(_rigidbody.angularVelocity.magnitude * 57.29578f * Gyroscope.Stability / Gyroscope.Speed, _rigidbody.angularVelocity) * base.transform.TransformDirection(_transformUp), quaternion * _targetVector);
					_rigidbody.AddTorque(vector * (Gyroscope.Speed * Gyroscope.Speed * _functionalHealth));
				}
			}
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			List<InputControllerScript> modifiers = base.PartScript.GetModifiers<InputControllerScript>();
			_activeFunc = base.PartScript.Aircraft.Controls.GetActivatorGetter(Gyroscope.ActivationGroup, base.PartScript, valueIfZero: true);
			if (loadContext == CraftLoadContext.Flight)
			{
				SetupInputs(modifiers);
			}
			_rollTransform = Utilities.GetFirstChild<Transform>("GyroOuterFrame", base.gameObject);
			_pitchTransform = Utilities.GetFirstChild<Transform>("GyroInnerFrame", base.gameObject);
			_spinTransform = Utilities.GetFirstChild<Transform>("GyroFlywheel", base.gameObject);
			if (Gyroscope.AutoOrient)
			{
				_targetVector = Quaternion.Euler(base.PartScript.Part.Rotation) * Vector3.up;
			}
			return UniTask.CompletedTask;
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_active)
			{
				Vector3 vector = -base.PartScript.transform.eulerAngles;
				vector.y = 0f;
				Vector3 vector2 = vector - _currentEuler;
				vector2.x = LimitAngle180(vector2.x);
				vector2.z = LimitAngle180(vector2.z);
				_currentEuler += vector2 * (frame.DeltaTime * 5f);
				_rollTransform.localEulerAngles = new Vector3(0f, 0f, _currentEuler.z);
				_pitchTransform.localEulerAngles = new Vector3(_currentEuler.x, 0f, 0f);
				_spinTransform.Rotate(new Vector3(0f, 720f * frame.DeltaTime, 0f), Space.Self);
			}
		}

		private void SetupInputs(List<InputControllerScript> inputControllers)
		{
			foreach (InputControllerScript inputController in inputControllers)
			{
				if (inputController.InputController.Name == "roll")
				{
					_rollInput = inputController;
					if (!Gyroscope.RollEnabled)
					{
						_rollInput.Disabled = true;
					}
				}
				else if (inputController.InputController.Name == "pitch")
				{
					_pitchInput = inputController;
					if (!Gyroscope.PitchEnabled)
					{
						_pitchInput.Disabled = true;
					}
				}
				else if (inputController.InputController.Name == "yaw")
				{
					_yawInput = inputController;
				}
			}
		}
	}
}
