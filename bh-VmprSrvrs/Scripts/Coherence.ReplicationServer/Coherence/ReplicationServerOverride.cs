using System;
using Coherence.Toolkit.ReplicationServer;

namespace Coherence
{
	public static class ReplicationServerOverride
	{
		public static Func<ReplicationServerConfig, IReplicationServer> LaunchRSLite;
	}
}
