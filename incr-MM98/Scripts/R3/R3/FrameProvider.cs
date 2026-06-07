namespace R3
{
	public abstract class FrameProvider
	{
		public abstract long GetFrameCount();

		public abstract void Register(IFrameRunnerWorkItem callback);
	}
}
