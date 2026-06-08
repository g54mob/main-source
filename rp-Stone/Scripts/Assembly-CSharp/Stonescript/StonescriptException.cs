using System;

namespace Stonescript
{
	public class StonescriptException : Exception
	{
		public enum Level
		{
			Warning = 1,
			Error = 2
		}

		public Level level = Level.Error;

		public StonescriptException(string message, Level level = Level.Error)
			: base(message)
		{
			this.level = level;
		}

		public StonescriptException(Exception innerException, Level level = Level.Error)
			: base(null, innerException)
		{
			this.level = level;
		}

		public StonescriptException(string message, Exception innerException, Level level = Level.Error)
			: base(message, innerException)
		{
			this.level = level;
		}
	}
}
