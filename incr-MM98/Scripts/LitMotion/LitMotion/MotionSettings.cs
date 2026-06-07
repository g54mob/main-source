using UnityEngine;

namespace LitMotion
{
	public record MotionSettings<TValue, TOptions> where TValue : unmanaged where TOptions : unmanaged, IMotionOptions
	{
		public TValue StartValue
		{
			get
			{
				return startValue;
			}
			init
			{
				startValue = value;
			}
		}

		public TValue EndValue
		{
			get
			{
				return endValue;
			}
			init
			{
				endValue = value;
			}
		}

		public float Duration
		{
			get
			{
				return duration;
			}
			init
			{
				duration = value;
			}
		}

		public TOptions Options
		{
			get
			{
				return options;
			}
			init
			{
				options = value;
			}
		}

		public Ease Ease
		{
			get
			{
				return ease;
			}
			init
			{
				ease = value;
			}
		}

		public AnimationCurve CustomEaseCurve
		{
			get
			{
				return customEaseCurve;
			}
			init
			{
				customEaseCurve = value;
			}
		}

		public float Delay
		{
			get
			{
				return delay;
			}
			init
			{
				delay = value;
			}
		}

		public DelayType DelayType
		{
			get
			{
				return delayType;
			}
			init
			{
				delayType = value;
			}
		}

		public int Loops
		{
			get
			{
				return loops;
			}
			init
			{
				loops = value;
			}
		}

		public LoopType LoopType
		{
			get
			{
				return loopType;
			}
			init
			{
				loopType = value;
			}
		}

		public bool CancelOnError
		{
			get
			{
				return cancelOnError;
			}
			init
			{
				cancelOnError = value;
			}
		}

		public bool SkipValuesDuringDelay
		{
			get
			{
				return skipValuesDuringDelay;
			}
			init
			{
				skipValuesDuringDelay = value;
			}
		}

		public bool ImmediateBind
		{
			get
			{
				return immediateBind;
			}
			init
			{
				immediateBind = value;
			}
		}

		public IMotionScheduler Scheduler
		{
			get
			{
				return scheduler;
			}
			init
			{
				scheduler = value;
			}
		}

		[SerializeField]
		private TValue startValue;

		[SerializeField]
		private TValue endValue;

		[SerializeField]
		private float duration;

		[SerializeField]
		private TOptions options;

		[SerializeField]
		private Ease ease;

		[SerializeField]
		private AnimationCurve customEaseCurve;

		[SerializeField]
		private float delay;

		[SerializeField]
		private DelayType delayType;

		[SerializeField]
		private int loops;

		[SerializeField]
		private LoopType loopType;

		[SerializeField]
		private bool cancelOnError;

		[SerializeField]
		private bool skipValuesDuringDelay;

		[SerializeField]
		private bool immediateBind;

		internal IMotionScheduler scheduler;
	}
}
