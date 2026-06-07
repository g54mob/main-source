namespace LitMotion
{
	internal sealed class ManualMotionDispatcherScheduler : IMotionScheduler
	{
		private readonly ManualMotionDispatcher dispatcher;

		public ManualMotionDispatcherScheduler(ManualMotionDispatcher dispatcher)
		{
			this.dispatcher = dispatcher;
		}

		public MotionHandle Schedule<TValue, TOptions, TAdapter>(ref MotionBuilder<TValue, TOptions, TAdapter> builder) where TValue : unmanaged where TOptions : unmanaged, IMotionOptions where TAdapter : unmanaged, IMotionAdapter<TValue, TOptions>
		{
			return dispatcher.GetOrCreateRunner<TValue, TOptions, TAdapter>().Storage.Create(ref builder);
		}
	}
}
