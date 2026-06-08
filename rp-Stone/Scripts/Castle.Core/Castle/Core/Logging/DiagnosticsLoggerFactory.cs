using System;

namespace Castle.Core.Logging
{
	[Serializable]
	public class DiagnosticsLoggerFactory : AbstractLoggerFactory
	{
		private const string DefaultLogName = "CastleDefaultLogger";

		public override ILogger Create(string name)
		{
			return new DiagnosticsLogger("CastleDefaultLogger", name);
		}

		public override ILogger Create(string name, LoggerLevel level)
		{
			return new DiagnosticsLogger("CastleDefaultLogger", name)
			{
				Level = level
			};
		}
	}
}
