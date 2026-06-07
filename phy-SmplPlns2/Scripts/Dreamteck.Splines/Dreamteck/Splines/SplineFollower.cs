using System;
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
		private bool _follow = true;

		[SerializeField]
		[HideInInspector]
		[Range(0f, 1f)]
		private double _startPosition;

		[HideInInspector]
		public bool preserveUniformSpeedWithOffset;

		[SerializeField]
		[HideInInspector]
		private float _followSpeed = 1f;

		[SerializeField]
		[HideInInspector]
		private float _followDuration = 1f;

		[SerializeField]
		[HideInInspector]
		private FollowerSpeedModifier _speedModifier = new FollowerSpeedModifier();

		[SerializeField]
		[HideInInspector]
		private FloatEvent _unityOnEndReached;

		[SerializeField]
		[HideInInspector]
		private FloatEvent _unityOnBeginningReached;

		private double lastClippedPercent = -1.0;

		public float followSpeed
		{
			get
			{
				return _followSpeed;
			}
			set
			{
				if (_followSpeed == value)
				{
					return;
				}
				_followSpeed = value;
				_ = _direction;
				if (!Mathf.Approximately(_followSpeed, 0f))
				{
					if (_followSpeed < 0f)
					{
						direction = Spline.Direction.Backward;
					}
					if (_followSpeed > 0f)
					{
						direction = Spline.Direction.Forward;
					}
				}
			}
		}

		public override Spline.Direction direction
		{
			get
			{
				return base.direction;
			}
			set
			{
				base.direction = value;
				if (_direction == Spline.Direction.Forward)
				{
					if (_followSpeed < 0f)
					{
						_followSpeed = 0f - _followSpeed;
					}
				}
				else if (_followSpeed > 0f)
				{
					_followSpeed = 0f - _followSpeed;
				}
			}
		}

		public float followDuration
		{
			get
			{
				return _followDuration;
			}
			set
			{
				if (_followDuration != value)
				{
					if (value < 0f)
					{
						value = 0f;
					}
					_followDuration = value;
				}
			}
		}

		public bool follow
		{
			get
			{
				return _follow;
			}
			set
			{
				if (_follow != value)
				{
					if (autoStartPosition)
					{
						Project(GetTransform().position, ref evalResult);
						SetPercent(evalResult.percent);
					}
					_follow = value;
				}
			}
		}

		public FollowerSpeedModifier speedModifier => _speedModifier;

		public event Action<double> onEndReached;

		public event Action<double> onBeginningReached;

		protected override void Start()
		{
			base.Start();
			if (_follow && autoStartPosition)
			{
				SetPercent(base.spline.Project(GetTransform().position).percent);
			}
		}

		protected override void LateRun()
		{
			base.LateRun();
			if (_follow)
			{
				Follow();
			}
		}

		protected override void PostBuild()
		{
			base.PostBuild();
			Evaluate(_result.percent, ref _result);
			if (base.sampleCount > 0 && _follow && !autoStartPosition)
			{
				ApplyMotion();
			}
		}

		private void Follow()
		{
			switch (followMode)
			{
			case FollowMode.Uniform:
			{
				double percent = base.result.percent;
				if (!_speedModifier.useClippedPercent)
				{
					UnclipPercent(ref percent);
				}
				float speed = _speedModifier.GetSpeed(Mathf.Abs(_followSpeed), percent);
				Move(Time.deltaTime * speed);
				break;
			}
			case FollowMode.Time:
				if ((double)_followDuration == 0.0)
				{
					Move(0.0);
				}
				else
				{
					Move((double)Time.deltaTime / (double)_followDuration);
				}
				break;
			}
		}

		public void Restart(double startPosition = 0.0)
		{
			SetPercent(startPosition);
		}

		public override void SetPercent(double percent, bool checkTriggers = false, bool handleJunctions = false)
		{
			base.SetPercent(percent, checkTriggers, handleJunctions);
			lastClippedPercent = percent;
			if (handleJunctions)
			{
				InvokeNodes();
			}
		}

		public override void SetDistance(float distance, bool checkTriggers = false, bool handleJunctions = false)
		{
			base.SetDistance(distance, checkTriggers, handleJunctions);
			lastClippedPercent = ClipPercent(_result.percent);
			if (base.samplesAreLooped && base.clipFrom == base.clipTo && distance > 0f && lastClippedPercent == 0.0)
			{
				lastClippedPercent = 1.0;
			}
			if (handleJunctions)
			{
				InvokeNodes();
			}
		}

		public void Move(double percent)
		{
			if (percent == 0.0)
			{
				return;
			}
			if (base.sampleCount <= 1)
			{
				if (base.sampleCount == 1)
				{
					GetSampleRaw(0, ref _result);
					ApplyMotion();
				}
				return;
			}
			Evaluate(_result.percent, ref _result);
			double num = _result.percent;
			if (wrapMode == Wrap.Default && lastClippedPercent >= 1.0 && num == 0.0)
			{
				num = 1.0;
			}
			double num2 = num + ((_direction == Spline.Direction.Forward) ? percent : (0.0 - percent));
			bool flag = false;
			bool flag2 = false;
			lastClippedPercent = num2;
			if (_direction == Spline.Direction.Forward && num2 >= 1.0)
			{
				if (num < 1.0)
				{
					flag = true;
				}
				switch (wrapMode)
				{
				case Wrap.Default:
					num2 = 1.0;
					break;
				case Wrap.Loop:
					CheckTriggers(num, 1.0);
					CheckNodes(num, 1.0);
					while (num2 > 1.0)
					{
						num2 -= 1.0;
					}
					num = 0.0;
					break;
				case Wrap.PingPong:
					num2 = DMath.Clamp01(1.0 - (num2 - 1.0));
					num = 1.0;
					direction = Spline.Direction.Backward;
					break;
				}
			}
			else if (_direction == Spline.Direction.Backward && num2 <= 0.0)
			{
				if (num > 0.0)
				{
					flag2 = true;
				}
				switch (wrapMode)
				{
				case Wrap.Default:
					num2 = 0.0;
					break;
				case Wrap.Loop:
					CheckTriggers(num, 0.0);
					CheckNodes(num, 0.0);
					for (; num2 < 0.0; num2 += 1.0)
					{
					}
					num = 1.0;
					break;
				case Wrap.PingPong:
					num2 = DMath.Clamp01(0.0 - num2);
					num = 0.0;
					direction = Spline.Direction.Forward;
					break;
				}
			}
			CheckTriggers(num, num2);
			CheckNodes(num, num2);
			Evaluate(num2, ref _result);
			ApplyMotion();
			if (flag)
			{
				if (this.onEndReached != null)
				{
					this.onEndReached(num);
				}
				if (_unityOnEndReached != null)
				{
					_unityOnEndReached.Invoke((float)num);
				}
			}
			else if (flag2)
			{
				if (this.onBeginningReached != null)
				{
					this.onBeginningReached(num);
				}
				if (_unityOnBeginningReached != null)
				{
					_unityOnBeginningReached.Invoke((float)num);
				}
			}
			InvokeTriggers();
			InvokeNodes();
		}

		public void Move(float distance)
		{
			bool flag = false;
			bool flag2 = false;
			float moved = 0f;
			double percent = _result.percent;
			double num = DoTravel(_result.percent, distance, out moved);
			if (percent != num)
			{
				CheckTriggers(percent, num);
				CheckNodes(percent, num);
			}
			if (direction == Spline.Direction.Forward)
			{
				if (num >= 1.0)
				{
					if (percent < 1.0)
					{
						flag = true;
					}
					switch (wrapMode)
					{
					case Wrap.Loop:
						num = DoTravel(0.0, Mathf.Abs(distance - moved), out moved);
						CheckTriggers(0.0, num);
						CheckNodes(0.0, num);
						break;
					case Wrap.PingPong:
						direction = Spline.Direction.Backward;
						num = DoTravel(1.0, distance - moved, out moved);
						CheckTriggers(1.0, num);
						CheckNodes(1.0, num);
						break;
					}
				}
			}
			else if (num <= 0.0)
			{
				if (percent > 0.0)
				{
					flag2 = true;
				}
				switch (wrapMode)
				{
				case Wrap.Loop:
					num = DoTravel(1.0, distance - moved, out moved);
					CheckTriggers(1.0, num);
					CheckNodes(1.0, num);
					break;
				case Wrap.PingPong:
					direction = Spline.Direction.Forward;
					num = DoTravel(0.0, Mathf.Abs(distance - moved), out moved);
					CheckTriggers(0.0, num);
					CheckNodes(0.0, num);
					break;
				}
			}
			Evaluate(num, ref _result);
			ApplyMotion();
			if (flag)
			{
				if (this.onEndReached != null)
				{
					this.onEndReached(percent);
				}
				if (_unityOnEndReached != null)
				{
					_unityOnEndReached.Invoke((float)percent);
				}
			}
			else if (flag2)
			{
				if (this.onBeginningReached != null)
				{
					this.onBeginningReached(percent);
				}
				if (_unityOnBeginningReached != null)
				{
					_unityOnBeginningReached.Invoke((float)percent);
				}
			}
			InvokeTriggers();
			InvokeNodes();
		}

		protected virtual double DoTravel(double start, float distance, out float moved)
		{
			moved = 0f;
			double num = 0.0;
			if (preserveUniformSpeedWithOffset && _motion.hasOffset)
			{
				return TravelWithOffset(start, distance, _direction, _motion.offset, out moved);
			}
			return Travel(start, distance, _direction, out moved);
		}
	}
}
