using System;
using System.Threading;
using UnityEngine;

namespace R3
{
	public class UnityTimeProvider : TimeProvider
	{
		public static readonly TimeProvider Initialization = new UnityTimeProvider(UnityFrameProvider.Initialization, TimeKind.Time);

		public static readonly TimeProvider EarlyUpdate = new UnityTimeProvider(UnityFrameProvider.EarlyUpdate, TimeKind.Time);

		public static readonly TimeProvider FixedUpdate = new UnityTimeProvider(UnityFrameProvider.FixedUpdate, TimeKind.Time);

		public static readonly TimeProvider PreUpdate = new UnityTimeProvider(UnityFrameProvider.PreUpdate, TimeKind.Time);

		public static readonly TimeProvider Update = new UnityTimeProvider(UnityFrameProvider.Update, TimeKind.Time);

		public static readonly TimeProvider PreLateUpdate = new UnityTimeProvider(UnityFrameProvider.PreLateUpdate, TimeKind.Time);

		public static readonly TimeProvider PostLateUpdate = new UnityTimeProvider(UnityFrameProvider.PostLateUpdate, TimeKind.Time);

		public static readonly TimeProvider TimeUpdate = new UnityTimeProvider(UnityFrameProvider.TimeUpdate, TimeKind.Time);

		public static readonly TimeProvider InitializationIgnoreTimeScale = new UnityTimeProvider(UnityFrameProvider.Initialization, TimeKind.UnscaledTime);

		public static readonly TimeProvider EarlyUpdateIgnoreTimeScale = new UnityTimeProvider(UnityFrameProvider.EarlyUpdate, TimeKind.UnscaledTime);

		public static readonly TimeProvider FixedUpdateIgnoreTimeScale = new UnityTimeProvider(UnityFrameProvider.FixedUpdate, TimeKind.UnscaledTime);

		public static readonly TimeProvider PreUpdateIgnoreTimeScale = new UnityTimeProvider(UnityFrameProvider.PreUpdate, TimeKind.UnscaledTime);

		public static readonly TimeProvider UpdateIgnoreTimeScale = new UnityTimeProvider(UnityFrameProvider.Update, TimeKind.UnscaledTime);

		public static readonly TimeProvider PreLateUpdateIgnoreTimeScale = new UnityTimeProvider(UnityFrameProvider.PreLateUpdate, TimeKind.UnscaledTime);

		public static readonly TimeProvider PostLateUpdateIgnoreTimeScale = new UnityTimeProvider(UnityFrameProvider.PostLateUpdate, TimeKind.UnscaledTime);

		public static readonly TimeProvider TimeUpdateIgnoreTimeScale = new UnityTimeProvider(UnityFrameProvider.TimeUpdate, TimeKind.UnscaledTime);

		public static readonly TimeProvider InitializationRealtime = new UnityTimeProvider(UnityFrameProvider.Initialization, TimeKind.Realtime);

		public static readonly TimeProvider EarlyUpdateRealtime = new UnityTimeProvider(UnityFrameProvider.EarlyUpdate, TimeKind.Realtime);

		public static readonly TimeProvider FixedUpdateRealtime = new UnityTimeProvider(UnityFrameProvider.FixedUpdate, TimeKind.Realtime);

		public static readonly TimeProvider PreUpdateRealtime = new UnityTimeProvider(UnityFrameProvider.PreUpdate, TimeKind.Realtime);

		public static readonly TimeProvider UpdateRealtime = new UnityTimeProvider(UnityFrameProvider.Update, TimeKind.Realtime);

		public static readonly TimeProvider PreLateUpdateRealtime = new UnityTimeProvider(UnityFrameProvider.PreLateUpdate, TimeKind.Realtime);

		public static readonly TimeProvider PostLateUpdateRealtime = new UnityTimeProvider(UnityFrameProvider.PostLateUpdate, TimeKind.Realtime);

		public static readonly TimeProvider TimeUpdateRealtime = new UnityTimeProvider(UnityFrameProvider.TimeUpdate, TimeKind.Realtime);

		private readonly UnityFrameProvider frameProvider;

		private readonly TimeKind timeKind;

		private UnityTimeProvider(FrameProvider frameProvider, TimeKind timeKind)
		{
			this.frameProvider = (UnityFrameProvider)frameProvider;
			this.timeKind = timeKind;
		}

		public override long GetTimestamp()
		{
			if (frameProvider.PlayerLoopTiming == PlayerLoopTiming.FixedUpdate)
			{
				switch (timeKind)
				{
				case TimeKind.Time:
					return TimeSpan.FromSeconds(Time.fixedTimeAsDouble).Ticks;
				case TimeKind.UnscaledTime:
					return TimeSpan.FromSeconds(Time.fixedUnscaledTimeAsDouble).Ticks;
				}
			}
			else
			{
				switch (timeKind)
				{
				case TimeKind.Time:
					return TimeSpan.FromSeconds(Time.timeAsDouble).Ticks;
				case TimeKind.UnscaledTime:
					return TimeSpan.FromSeconds(Time.unscaledTimeAsDouble).Ticks;
				}
			}
			return TimeSpan.FromSeconds(Time.realtimeSinceStartupAsDouble).Ticks;
		}

		public override ITimer CreateTimer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
		{
			return new FrameTimer(callback, state, dueTime, period, frameProvider, timeKind);
		}
	}
}
