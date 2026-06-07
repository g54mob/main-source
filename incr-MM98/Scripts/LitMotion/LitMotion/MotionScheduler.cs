namespace LitMotion
{
	public static class MotionScheduler
	{
		public static readonly IMotionScheduler Initialization;

		public static readonly IMotionScheduler InitializationIgnoreTimeScale;

		public static readonly IMotionScheduler InitializationRealtime;

		public static readonly IMotionScheduler EarlyUpdate;

		public static readonly IMotionScheduler EarlyUpdateIgnoreTimeScale;

		public static readonly IMotionScheduler EarlyUpdateRealtime;

		public static readonly IMotionScheduler FixedUpdate;

		public static readonly IMotionScheduler PreUpdate;

		public static readonly IMotionScheduler PreUpdateIgnoreTimeScale;

		public static readonly IMotionScheduler PreUpdateRealtime;

		public static readonly IMotionScheduler Update;

		public static readonly IMotionScheduler UpdateIgnoreTimeScale;

		public static readonly IMotionScheduler UpdateRealtime;

		public static readonly IMotionScheduler PreLateUpdate;

		public static readonly IMotionScheduler PreLateUpdateIgnoreTimeScale;

		public static readonly IMotionScheduler PreLateUpdateRealtime;

		public static readonly IMotionScheduler PostLateUpdate;

		public static readonly IMotionScheduler PostLateUpdateIgnoreTimeScale;

		public static readonly IMotionScheduler PostLateUpdateRealtime;

		public static readonly IMotionScheduler TimeUpdate;

		public static readonly IMotionScheduler TimeUpdateIgnoreTimeScale;

		public static readonly IMotionScheduler TimeUpdateRealtime;

		public static IMotionScheduler DefaultScheduler { get; set; }

		public static IMotionScheduler Manual => ManualMotionDispatcher.Default.Scheduler;

		static MotionScheduler()
		{
			Initialization = new PlayerLoopMotionScheduler(PlayerLoopTiming.Initialization, MotionTimeKind.Time);
			InitializationIgnoreTimeScale = new PlayerLoopMotionScheduler(PlayerLoopTiming.Initialization, MotionTimeKind.UnscaledTime);
			InitializationRealtime = new PlayerLoopMotionScheduler(PlayerLoopTiming.Initialization, MotionTimeKind.Realtime);
			EarlyUpdate = new PlayerLoopMotionScheduler(PlayerLoopTiming.EarlyUpdate, MotionTimeKind.Time);
			EarlyUpdateIgnoreTimeScale = new PlayerLoopMotionScheduler(PlayerLoopTiming.EarlyUpdate, MotionTimeKind.UnscaledTime);
			EarlyUpdateRealtime = new PlayerLoopMotionScheduler(PlayerLoopTiming.EarlyUpdate, MotionTimeKind.Realtime);
			FixedUpdate = new PlayerLoopMotionScheduler(PlayerLoopTiming.FixedUpdate, MotionTimeKind.Time);
			PreUpdate = new PlayerLoopMotionScheduler(PlayerLoopTiming.PreUpdate, MotionTimeKind.Time);
			PreUpdateIgnoreTimeScale = new PlayerLoopMotionScheduler(PlayerLoopTiming.PreUpdate, MotionTimeKind.UnscaledTime);
			PreUpdateRealtime = new PlayerLoopMotionScheduler(PlayerLoopTiming.PreUpdate, MotionTimeKind.Realtime);
			Update = new PlayerLoopMotionScheduler(PlayerLoopTiming.Update, MotionTimeKind.Time);
			UpdateIgnoreTimeScale = new PlayerLoopMotionScheduler(PlayerLoopTiming.Update, MotionTimeKind.UnscaledTime);
			UpdateRealtime = new PlayerLoopMotionScheduler(PlayerLoopTiming.Update, MotionTimeKind.Realtime);
			PreLateUpdate = new PlayerLoopMotionScheduler(PlayerLoopTiming.PreLateUpdate, MotionTimeKind.Time);
			PreLateUpdateIgnoreTimeScale = new PlayerLoopMotionScheduler(PlayerLoopTiming.PreLateUpdate, MotionTimeKind.UnscaledTime);
			PreLateUpdateRealtime = new PlayerLoopMotionScheduler(PlayerLoopTiming.PreLateUpdate, MotionTimeKind.Realtime);
			PostLateUpdate = new PlayerLoopMotionScheduler(PlayerLoopTiming.PostLateUpdate, MotionTimeKind.Time);
			PostLateUpdateIgnoreTimeScale = new PlayerLoopMotionScheduler(PlayerLoopTiming.PostLateUpdate, MotionTimeKind.UnscaledTime);
			PostLateUpdateRealtime = new PlayerLoopMotionScheduler(PlayerLoopTiming.PostLateUpdate, MotionTimeKind.Realtime);
			TimeUpdate = new PlayerLoopMotionScheduler(PlayerLoopTiming.TimeUpdate, MotionTimeKind.Time);
			TimeUpdateIgnoreTimeScale = new PlayerLoopMotionScheduler(PlayerLoopTiming.TimeUpdate, MotionTimeKind.UnscaledTime);
			TimeUpdateRealtime = new PlayerLoopMotionScheduler(PlayerLoopTiming.TimeUpdate, MotionTimeKind.Realtime);
			DefaultScheduler = Update;
		}
	}
}
