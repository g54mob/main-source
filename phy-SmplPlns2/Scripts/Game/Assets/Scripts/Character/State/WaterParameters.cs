using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Assets.Scripts.Character.State
{
	[Serializable]
	public class WaterParameters
	{
		[Min(0f)]
		[SerializeField]
		private float _baseSpeedLimit = 3f;

		[Min(0f)]
		[SerializeField]
		private float _boostSpeedLimit = 5f;

		[SerializeField]
		private float _buoyancyMultiplier = 0.25f;

		[SerializeField]
		private int _jumpsAvailableNearSurface = 1;

		[SerializeField]
		private float _minDepthThreshold = 0.05f;

		[SerializeField]
		private float _preferredSurfaceSwimDepth = 0.75f;

		[SerializeField]
		private float _swimAcceleration = 15f;

		[SerializeField]
		private float _swimDeceleration = 10f;

		[SerializeField]
		private float _swimDepthThreshold = 0.6f;

		[SerializeField]
		private float _swimTransitionTime = 0.5f;

		[SerializeField]
		private float _underwaterDrag = 3f;

		[SerializeField]
		[FormerlySerializedAs("_depthSpeedCurve")]
		private AnimationCurve _walkSpeedDepthModifier = AnimationCurve.Linear(0f, 1f, 1f, 0.1f);

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

		public float BuoyancyMultiplier => _buoyancyMultiplier;

		public int JumpsAvailableNearSurface => _jumpsAvailableNearSurface;

		public float MinDepthThreshold => _minDepthThreshold;

		public float PreferredSurfaceSwimDepth => _preferredSurfaceSwimDepth;

		public float SwimAcceleration => _swimAcceleration;

		public float SwimDeceleration => _swimDeceleration;

		public float SwimDepthThreshold => _swimDepthThreshold;

		public float SwimTransitionTime => _swimTransitionTime;

		public float UnderwaterDrag => _underwaterDrag;

		public AnimationCurve WalkSpeedDepthMuliplier => _walkSpeedDepthModifier;
	}
}
