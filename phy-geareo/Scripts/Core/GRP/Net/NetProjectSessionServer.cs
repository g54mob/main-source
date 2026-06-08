using System.Collections.Generic;

namespace GRP.Net
{
	public class NetProjectSessionServer : NetModuleServer
	{
		public ProjectContainer projectContainer;

		public Dictionary<ulong, ulong[]> allSelections;

		public NetIdGeneratorServer idGenerator;

		public NetSessionServer<ProjectSessionStart, ProjectSessionJoin, ProjectSessionLeave> session;

		public override void Setup()
		{
		}

		public override void Build()
		{
		}
	}
}
