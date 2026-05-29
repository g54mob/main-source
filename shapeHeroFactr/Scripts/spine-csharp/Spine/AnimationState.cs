using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Spine
{
	public class AnimationState
	{
		public delegate void TrackEntryDelegate(TrackEntry trackEntry);

		public delegate void TrackEntryEventDelegate(TrackEntry trackEntry, Event e);

		internal static readonly Animation EmptyAnimation;

		internal const int Subsequent = 0;

		internal const int First = 1;

		internal const int HoldSubsequent = 2;

		internal const int HoldFirst = 3;

		internal const int HoldMix = 4;

		internal const int Setup = 1;

		internal const int Current = 2;

		protected AnimationStateData data;

		private readonly ExposedList<TrackEntry> tracks;

		private readonly ExposedList<Event> events;

		private readonly EventQueue queue;

		private readonly HashSet<string> propertyIds;

		private bool animationsChanged;

		private float timeScale;

		private int unkeyedState;

		private readonly Pool<TrackEntry> trackEntryPool;

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

		public AnimationStateData Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ExposedList<TrackEntry> Tracks => null;

		public event TrackEntryDelegate Start
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

		public event TrackEntryDelegate Interrupt
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

		public event TrackEntryDelegate End
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

		public event TrackEntryDelegate Dispose
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

		public event TrackEntryDelegate Complete
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

		public event TrackEntryEventDelegate Event
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

		internal void OnStart(TrackEntry entry)
		{
		}

		internal void OnInterrupt(TrackEntry entry)
		{
		}

		internal void OnEnd(TrackEntry entry)
		{
		}

		internal void OnDispose(TrackEntry entry)
		{
		}

		internal void OnComplete(TrackEntry entry)
		{
		}

		internal void OnEvent(TrackEntry entry, Event e)
		{
		}

		public void AssignEventSubscribersFrom(AnimationState src)
		{
		}

		public void AddEventSubscribersFrom(AnimationState src)
		{
		}

		public AnimationState(AnimationStateData data)
		{
		}

		public void Update(float delta)
		{
		}

		private bool UpdateMixingFrom(TrackEntry to, float delta)
		{
			return false;
		}

		public bool Apply(Skeleton skeleton)
		{
			return false;
		}

		public bool ApplyEventTimelinesOnly(Skeleton skeleton, bool issueEvents = true)
		{
			return false;
		}

		private float ApplyMixingFrom(TrackEntry to, Skeleton skeleton, MixBlend blend)
		{
			return 0f;
		}

		private float ApplyMixingFromEventTimelinesOnly(TrackEntry to, Skeleton skeleton, bool issueEvents)
		{
			return 0f;
		}

		private void ApplyAttachmentTimeline(AttachmentTimeline timeline, Skeleton skeleton, float time, MixBlend blend, bool attachments)
		{
		}

		private void SetAttachment(Skeleton skeleton, Slot slot, string attachmentName, bool attachments)
		{
		}

		private static void ApplyRotateTimeline(RotateTimeline timeline, Skeleton skeleton, float time, float alpha, MixBlend blend, float[] timelinesRotation, int i, bool firstFrame)
		{
		}

		private void QueueEvents(TrackEntry entry, float animationTime)
		{
		}

		public void ClearTracks()
		{
		}

		public void ClearTrack(int trackIndex)
		{
		}

		private void SetCurrent(int index, TrackEntry current, bool interrupt)
		{
		}

		public TrackEntry SetAnimation(int trackIndex, string animationName, bool loop)
		{
			return null;
		}

		public TrackEntry SetAnimation(int trackIndex, Animation animation, bool loop)
		{
			return null;
		}

		public TrackEntry AddAnimation(int trackIndex, string animationName, bool loop, float delay)
		{
			return null;
		}

		public TrackEntry AddAnimation(int trackIndex, Animation animation, bool loop, float delay)
		{
			return null;
		}

		public TrackEntry SetEmptyAnimation(int trackIndex, float mixDuration)
		{
			return null;
		}

		public TrackEntry AddEmptyAnimation(int trackIndex, float mixDuration, float delay)
		{
			return null;
		}

		public void SetEmptyAnimations(float mixDuration)
		{
		}

		private TrackEntry ExpandToIndex(int index)
		{
			return null;
		}

		private TrackEntry NewTrackEntry(int trackIndex, Animation animation, bool loop, TrackEntry last)
		{
			return null;
		}

		public void ClearNext(TrackEntry entry)
		{
		}

		private void AnimationsChanged()
		{
		}

		private void ComputeHold(TrackEntry entry)
		{
		}

		public TrackEntry GetCurrent(int trackIndex)
		{
			return null;
		}

		public void ClearListenerNotifications()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
