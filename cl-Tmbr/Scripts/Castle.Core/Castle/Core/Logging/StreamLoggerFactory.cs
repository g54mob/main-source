using System.IO;

namespace Castle.Core.Logging
{
	public class StreamLoggerFactory : AbstractLoggerFactory
	{
		public override ILogger Create(string name)
		{
			return new StreamLogger(name, new FileStream(name + ".log", FileMode.Append, FileAccess.Write));
		}

		public override ILogger Create(string name, LoggerLevel level)
		{
			return new StreamLogger(name, new FileStream(name + ".log", FileMode.Append, FileAccess.Write))
			{
				Level = level
			};
		}
	}
}
