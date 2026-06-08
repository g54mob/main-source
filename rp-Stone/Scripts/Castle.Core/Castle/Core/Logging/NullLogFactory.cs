using System;

namespace Castle.Core.Logging
{
	[Serializable]
	public class NullLogFactory : AbstractLoggerFactory
	{
		public override ILogger Create(string name)
		{
			return NullLogger.Instance;
		}

		public override ILogger Create(string name, LoggerLevel level)
		{
			return NullLogger.Instance;
		}
	}
}
