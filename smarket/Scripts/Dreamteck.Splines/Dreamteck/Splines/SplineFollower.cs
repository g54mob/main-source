using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Dreamteck.Splines
{
	[AddComponentMenu("Dreamteck/Splines/Users/Spline Follower")]
	public class SplineFollower : SplineTracer
	{
		public enum FollowMode
		{
			Uniform = 0,
			Time = 1
		}

		public enum Wrap
		{
			Default = 0,
			Loop = 1,
			PingPong = 2
		}

		[Serializable]
		public class FloatEvent : UnityEvent<float>
		{
		}

		[HideInInspector]
		public Wrap wrapMode;

		[HideInInspector]
		public FollowMode followMode;

		[HideInInspector]
		public bool autoStartPosition;

		[SerializeField]
		[HideInInspector]
		[FormerlySerializedAs("follow")]
		private bool _follow;

		[SerializeField]
		[HideInInspector]
		[Range(0f, 1f)]
		private double _startPosition;

		[HideInInspector]
		public bool preserveUniformSpeedWithOffset;

		[SerializeField]
		[HideInInspector]
		private float _followSpeed;

		[SerializeField]
		[HideInInspector]
		private float _followDuration;

		[SerializeField]
		[HideInInspector]
		private FollowerSpeedModifier _speedModifier;

		[SerializeField]
		[HideInInspector]
		private FloatEvent _unityOnEndReached;

		[SerializeField]
		[HideInInspector]
		private FloatEvent _unityOnBeginningReached;

		private double lastClippedPercent;

		public float followSpeed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override Spline.Direction direction
		{
			get
			{
				return default(Spline.Direction);
			}
			set
			{
			}
		}

		public float followDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool follow
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public FollowerSpeedModifier speedModifier => null;

		public event Action<double> onEndReached
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<double> onBeginningReached
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Start()
		{
		}

		protected override void LateRun()
		{
		}

		protected override void PostBuild()
		{
		}

		private void Follow()
		{
		}

		public void Restart(double startPosition = 0.0)
		{
		}

		public override void SetPercent(double percent, bool checkTriggers = false, bool handleJunctions = false)
		{
		}

		public override void SetDistance(float distance, bool checkTriggers = false, bool handleJunctions = false)
		{
		}

		public void Move(double percent)
		{
		}

		public void Move(float distance)
		{
		}

		protected virtual double DoTravel(double start, float distance, out float moved)
		{
			moved = default(float);
			return 0.0;
		}
	}
}
