using System.Runtime.CompilerServices;

namespace Spine
{
	public class TrackEntry : Pool<TrackEntry>.IPoolable
	{
		internal Animation animation;

		internal TrackEntry previous;

		internal TrackEntry next;

		internal TrackEntry mixingFrom;

		internal TrackEntry mixingTo;

		internal int trackIndex;

		internal bool loop;

		internal bool holdPrevious;

		internal bool reverse;

		internal bool shortestRotation;

		internal float eventThreshold;

		internal float mixAttachmentThreshold;

		internal float alphaAttachmentThreshold;

		internal float mixDrawOrderThreshold;

		internal float animationStart;

		internal float animationEnd;

		internal float animationLast;

		internal float nextAnimationLast;

		internal float delay;

		internal float trackTime;

		internal float trackLast;

		internal float nextTrackLast;

		internal float trackEnd;

		internal float timeScale;

		internal float alpha;

		internal float mixTime;

		internal float mixDuration;

		internal float interruptAlpha;

		internal float totalAlpha;

		internal MixBlend mixBlend;

		internal readonly ExposedList<int> timelineMode;

		internal readonly ExposedList<TrackEntry> timelineHoldMix;

		internal readonly ExposedList<float> timelinesRotation;

		public int TrackIndex => 0;

		public Animation Animation => null;

		public bool Loop
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float Delay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TrackTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TrackEnd
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float TrackComplete => 0f;

		public float AnimationStart
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AnimationEnd
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AnimationLast
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AnimationTime => 0f;

		public float TimeScale
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Alpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float InterruptAlpha => 0f;

		public float EventThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float AlphaAttachmentThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MixAttachmentThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MixDrawOrderThreshold
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public TrackEntry Next => null;

		public TrackEntry Previous => null;

		public bool WasApplied => false;

		public bool IsNextReady => false;

		public bool IsComplete => false;

		public float MixTime
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float MixDuration
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public MixBlend MixBlend
		{
			get
			{
				return default(MixBlend);
			}
			set
			{
			}
		}

		public TrackEntry MixingFrom => null;

		public TrackEntry MixingTo => null;

		public bool HoldPrevious
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool Reverse
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool ShortestRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsEmptyAnimation => false;

		public event AnimationState.TrackEntryDelegate Start
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

		public event AnimationState.TrackEntryDelegate Interrupt
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

		public event AnimationState.TrackEntryDelegate End
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

		public event AnimationState.TrackEntryDelegate Dispose
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

		public event AnimationState.TrackEntryDelegate Complete
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

		public event AnimationState.TrackEntryEventDelegate Event
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

		internal void OnStart()
		{
		}

		internal void OnInterrupt()
		{
		}

		internal void OnEnd()
		{
		}

		internal void OnDispose()
		{
		}

		internal void OnComplete()
		{
		}

		internal void OnEvent(Event e)
		{
		}

		public void Reset()
		{
		}

		public void SetMixDuration(float mixDuration, float delay)
		{
		}

		public void ResetRotationDirections()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void AllowImmediateQueue()
		{
		}
	}
}
