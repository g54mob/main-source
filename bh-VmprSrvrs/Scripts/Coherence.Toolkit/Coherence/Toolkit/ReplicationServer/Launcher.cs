namespace Coherence.Toolkit.ReplicationServer
{
	public static class Launcher
	{
		internal static IConfigProvider ConfigProvider;

		internal static IReplicationServer Start(ReplicationServerConfig serverConfig, bool startInTerminal, string additionalArguments = null)
		{
			return null;
		}

		public static IReplicationServer Create(ReplicationServerConfig serverConfig, string additionalArguments = null)
		{
			return null;
		}

		private static string GenerateArguments(ReplicationServerConfig serverConfig, string additionalArguments = null)
		{
			return null;
		}

		internal static string GenerateLogTargetArguments(LogTargetConfig[] logTargets)
		{
			return null;
		}

		internal static string ToCommand(ReplicationServerConfig serverConfig, string additionalArguments = null)
		{
			return null;
		}
	}
}
