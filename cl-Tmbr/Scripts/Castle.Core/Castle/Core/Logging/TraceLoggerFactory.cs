namespace Castle.Core.Logging
{
	public class TraceLoggerFactory : AbstractLoggerFactory
	{
		private readonly LoggerLevel? level;

		public TraceLoggerFactory()
		{
		}

		public TraceLoggerFactory(LoggerLevel level)
		{
			this.level = level;
		}

		public override ILogger Create(string name)
		{
			if (level.HasValue)
			{
				return Create(name, level.Value);
			}
			return InternalCreate(name);
		}

		private ILogger InternalCreate(string name)
		{
			return new TraceLogger(name);
		}

		public override ILogger Create(string name, LoggerLevel level)
		{
			return InternalCreate(name, level);
		}

		private ILogger InternalCreate(string name, LoggerLevel level)
		{
			return new TraceLogger(name, level);
		}
	}
}
