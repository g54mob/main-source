using IO.Swagger.Model;

namespace Edgegap
{
	public static class ServerStatusExtensions
	{
		private static string GetServerStatusLabel(this Status serverStatusResponse)
		{
			return null;
		}

		public static ServerStatus GetServerStatus(this Status serverStatusResponse)
		{
			return default(ServerStatus);
		}

		public static string GetStatusBgClass(this ServerStatus serverStatus)
		{
			return null;
		}

		public static string GetLabelText(this ServerStatus serverStatus)
		{
			return null;
		}

		public static bool IsOneOf(this ServerStatus serverStatus, params ServerStatus[] serverStatusOptions)
		{
			return false;
		}
	}
}
