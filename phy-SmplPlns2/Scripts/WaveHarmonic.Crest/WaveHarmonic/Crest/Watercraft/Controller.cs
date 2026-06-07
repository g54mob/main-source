using System;
using UnityEngine;
using WaveHarmonic.Crest.Internal;

namespace WaveHarmonic.Crest.Watercraft
{
	[AddComponentMenu("Crest/Physics/Crest Watercraft Controller")]
	public sealed class Controller : ManagedBehaviour<WaterRenderer>
	{
		[Tooltip("The accompanied buoyancy script.")]
		[SerializeField]
		private FloatingObject _FloatingObject;

		[Tooltip("The accompanied control script to take input from.")]
		[SerializeField]
		private Control _Control;

		[Tooltip("Vertical offset from the center of mass for where move force should be applied.")]
		[SerializeField]
		private float _ForceHeightOffset;

		[Tooltip("How quickly the watercraft moves from thrust.")]
		[SerializeField]
		private float _ThrustPower = 10f;

		[Tooltip("How quickly the watercraft turns from steering.")]
		[SerializeField]
		private float _SteerPower = 1f;

		[Tooltip("Rolls the watercraft when turning.")]
		[SerializeField]
		private float _TurningHeel = 0.35f;

		[Tooltip("Applies a curve to buoyancy changes.")]
		[SerializeField]
		private AnimationCurve _BuoyancyCurveFactor = new AnimationCurve(new Keyframe(0f, 0f, 0.01267637f, 0.01267637f), new Keyframe(0.6626424f, 0.1791001f, 0.8680198f, 0.8680198f), new Keyframe(1f, 1f, 3.38758f, 3.38758f));

		private float _BuoyancyFactor = 1f;

		public AnimationCurve BuoyancyCurveFactor
		{
			get
			{
				return _BuoyancyCurveFactor;
			}
			set
			{
				_BuoyancyCurveFactor = value;
			}
		}

		public Control Control
		{
			get
			{
				return _Control;
			}
			set
			{
				_Control = value;
			}
		}

		public FloatingObject FloatingObject
		{
			get
			{
				return _FloatingObject;
			}
			set
			{
				_FloatingObject = value;
			}
		}

		public float ForceHeightOffset
		{
			get
			{
				return _ForceHeightOffset;
			}
			set
			{
				_ForceHeightOffset = value;
			}
		}

		public float SteerPower
		{
			get
			{
				return _SteerPower;
			}
			set
			{
				_SteerPower = value;
			}
		}

		public float ThrustPower
		{
			get
			{
				return _ThrustPower;
			}
			set
			{
				_ThrustPower = value;
			}
		}

		public float TurningHeel
		{
			get
			{
				return _TurningHeel;
			}
			set
			{
				_TurningHeel = value;
			}
		}

		private protected override Action<WaterRenderer> OnFixedUpdateMethod => OnFixedUpdate;

		private protected override void OnStart()
		{
			base.OnStart();
			if (_Control == null)
			{
				_Control = GetComponent<Control>();
			}
			if (_FloatingObject == null)
			{
				_FloatingObject = GetComponent<FloatingObject>();
			}
		}

		private void OnFixedUpdate(WaterRenderer water)
		{
			if (!_FloatingObject.InWater)
			{
				return;
			}
			Vector3 input = _Control.Input;
			Rigidbody rigidBody = _FloatingObject.RigidBody;
			rigidBody.AddForceAtPosition(position: rigidBody.worldCenterOfMass + _ForceHeightOffset * Vector3.up, force: _ThrustPower * input.z * base.transform.forward, mode: ForceMode.Acceleration);
			Vector3 vector = base.transform.up + _TurningHeel * base.transform.forward;
			rigidBody.AddTorque(_SteerPower * input.x * vector, ForceMode.Acceleration);
			if (input.y > 0f)
			{
				if (_BuoyancyFactor < 1f)
				{
					_BuoyancyFactor += Time.deltaTime * 0.1f;
					_BuoyancyFactor = Mathf.Clamp(_BuoyancyFactor, 0f, 1f);
					_FloatingObject.BuoyancyForceStrength = _BuoyancyCurveFactor.Evaluate(_BuoyancyFactor);
				}
			}
			else if (input.y < 0f && _BuoyancyFactor > 0f)
			{
				_BuoyancyFactor -= Time.deltaTime * 0.1f;
				_BuoyancyFactor = Mathf.Clamp(_BuoyancyFactor, 0f, 1f);
				_FloatingObject.BuoyancyForceStrength = _BuoyancyCurveFactor.Evaluate(_BuoyancyFactor);
			}
		}
	}
}
