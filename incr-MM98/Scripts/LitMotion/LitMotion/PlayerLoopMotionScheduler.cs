namespace LitMotion
{
	internal sealed class PlayerLoopMotionScheduler : IMotionScheduler
	{
		public readonly PlayerLoopTiming playerLoopTiming;

		public readonly MotionTimeKind timeKind;

		internal PlayerLoopMotionScheduler(PlayerLoopTiming playerLoopTiming, MotionTimeKind timeKind)
		{
			this.playerLoopTiming = playerLoopTiming;
			this.timeKind = timeKind;
		}

		public MotionHandle Schedule<TValue, TOptions, TAdapter>(ref MotionBuilder<TValue, TOptions, TAdapter> builder) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			builder.buffer.TimeKind = timeKind;
			return MotionDispatcher.Schedule(ref builder, playerLoopTiming);
		}
	}
}
