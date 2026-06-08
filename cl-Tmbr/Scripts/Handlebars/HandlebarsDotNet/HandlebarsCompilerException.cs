using System;

namespace HandlebarsDotNet
{
	public class HandlebarsCompilerException : HandlebarsException
	{
		public HandlebarsCompilerException(string message)
			: this(message, null, null)
		{
		}

		internal HandlebarsCompilerException(string message, IReaderContext context = null)
			: this(message, null, context)
		{
		}

		public HandlebarsCompilerException(string message, Exception innerException)
			: base(message, innerException, null)
		{
		}

		internal HandlebarsCompilerException(string message, Exception innerException, IReaderContext context = null)
			: base(message, innerException, context)
		{
		}
	}
}
