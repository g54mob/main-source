namespace Edgegap
{
	public static class PluginStateExtensions
	{
		public static bool CanConnect(this ToolState currentState)
		{
			return false;
		}

		public static bool CanDisconnect(this ToolState currentState)
		{
			return false;
		}

		public static bool CanStartDeployment(this ToolState currentState)
		{
			return false;
		}

		public static bool CanStopDeployment(this ToolState currentState)
		{
			return false;
		}

		public static bool CanEditConnectionInfo(this ToolState currentState)
		{
			return false;
		}

		public static bool HasActiveDeployment(this ToolState currentState)
		{
			return false;
		}
	}
}
