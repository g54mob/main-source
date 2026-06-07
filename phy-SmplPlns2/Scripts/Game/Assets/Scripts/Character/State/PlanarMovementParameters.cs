using System;
using UnityEngine;

namespace Assets.Scripts.Character.State
{
	[Serializable]
	public class PlanarMovementParameters
	{
		[Serializable]
		public struct PlanarMovementProperties
		{
			[Tooltip("How fast the character increases velocity.")]
			public float Acceleration;

			[Tooltip("How fast the character changes angular velocity.")]
			public float AngleAccelerationMultiplier;

			[Tooltip("How fast the character reduces velocity.")]
			public float Deceleration;

			public PlanarMovementProperties(float acceleration, float deceleration, float angleAccelerationBoost)
			{
				Acceleration = acceleration;
				Deceleration = deceleration;
				AngleAccelerationMultiplier = angleAccelerationBoost;
			}
		}

		[Min(0f)]
		[SerializeField]
		private float _baseSpeedLimit = 6f;

		[Min(0f)]
		[SerializeField]
		private float _boostSpeedLimit = 10f;

		[SerializeField]
		private bool _canRun = true;

		[SerializeField]
		private float _notGroundedAcceleration = 20f;

		[SerializeField]
		private AnimationCurve _notGroundedAngleAccelerationBoost = AnimationCurve.EaseInOut(0f, 1f, 180f, 1f);

		[SerializeField]
		private float _notGroundedDeceleration = 5f;

		[Tooltip("\"Toggle\" will activate/deactivate the action when the input is \"pressed\". \n \"Hold\" will activate the action when the input is pressed, and deactivate it when the input is \"released\".")]
		[SerializeField]
		private InputMode _runInputMode = InputMode.Hold;

		[SerializeField]
		private float _stableGroundedAcceleration = 50f;

		[SerializeField]
		private AnimationCurve _stableGroundedAngleAccelerationBoost = AnimationCurve.EaseInOut(0f, 1f, 180f, 2f);

		[SerializeField]
		private float _stableGroundedDeceleration = 40f;

		[SerializeField]
		private float _unstableGroundedAcceleration = 10f;

		[SerializeField]
		private AnimationCurve _unstableGroundedAngleAccelerationBoost = AnimationCurve.EaseInOut(0f, 1f, 180f, 1f);

		[SerializeField]
		private float _unstableGroundedDeceleration = 2f;

		public float BaseSpeedLimit
		{
			get
			{
				return _baseSpeedLimit;
			}
			set
			{
				_baseSpeedLimit = value;
			}
		}

		public float BoostSpeedLimit
		{
			get
			{
				return _boostSpeedLimit;
			}
			set
			{
				_boostSpeedLimit = value;
			}
		}

		public bool CanRun
		{
			get
			{
				return _canRun;
			}
			set
			{
				_canRun = value;
			}
		}

		public float NotGroundedAcceleration
		{
			get
			{
				return _notGroundedAcceleration;
			}
			set
			{
				_notGroundedAcceleration = value;
			}
		}

		public AnimationCurve NotGroundedAngleAccelerationBoost
		{
			get
			{
				return _notGroundedAngleAccelerationBoost;
			}
			set
			{
				_notGroundedAngleAccelerationBoost = value;
			}
		}

		public float NotGroundedDeceleration
		{
			get
			{
				return _notGroundedDeceleration;
			}
			set
			{
				_notGroundedDeceleration = value;
			}
		}

		public InputMode RunInputMode
		{
			get
			{
				return _runInputMode;
			}
			set
			{
				_runInputMode = value;
			}
		}

		public float StableGroundedAcceleration
		{
			get
			{
				return _stableGroundedAcceleration;
			}
			set
			{
				_stableGroundedAcceleration = value;
			}
		}

		public AnimationCurve StableGroundedAngleAccelerationBoost
		{
			get
			{
				return _stableGroundedAngleAccelerationBoost;
			}
			set
			{
				_stableGroundedAngleAccelerationBoost = value;
			}
		}

		public float StableGroundedDeceleration
		{
			get
			{
				return _stableGroundedDeceleration;
			}
			set
			{
				_stableGroundedDeceleration = value;
			}
		}

		public float UnstableGroundedAcceleration
		{
			get
			{
				return _unstableGroundedAcceleration;
			}
			set
			{
				_unstableGroundedAcceleration = value;
			}
		}

		public AnimationCurve UnstableGroundedAngleAccelerationBoost
		{
			get
			{
				return _unstableGroundedAngleAccelerationBoost;
			}
			set
			{
				_unstableGroundedAngleAccelerationBoost = value;
			}
		}

		public float UnstableGroundedDeceleration
		{
			get
			{
				return _unstableGroundedDeceleration;
			}
			set
			{
				_unstableGroundedDeceleration = value;
			}
		}
	}
}
