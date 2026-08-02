using System;

namespace GRP.Net
{
	public class NetIdGeneratorServer
	{
		public Func<IdGenerator> idGenerator;

		public NetSessionServer session;

		public int tag;

		public NetIdGeneratorServer(NetSessionServer session, Func<IdGenerator> idGenerator, int tag)
		{
		}

		public void Build()
		{
		}
	}
}
