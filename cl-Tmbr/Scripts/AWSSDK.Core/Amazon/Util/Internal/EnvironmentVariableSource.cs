namespace Amazon.Util.Internal
{
	public sealed class EnvironmentVariableSource
	{
		private static readonly EnvironmentVariableSource instance;

		public IEnvironmentVariableRetriever EnvironmentVariableRetriever { get; set; } = new EnvironmentVariableRetriever();

		public static EnvironmentVariableSource Instance => instance;

		private EnvironmentVariableSource()
		{
		}

		static EnvironmentVariableSource()
		{
			instance = new EnvironmentVariableSource();
		}
	}
}
