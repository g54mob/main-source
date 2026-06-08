namespace GRP.Net
{
	public class NetProjectSession : NetModule<NetProjectSessionConfig, NetProjectSessionServer, NetProjectSessionClient>
	{
		public static void ApplyChange(Project prj, ProjectSessionChange msg)
		{
		}
	}
}
