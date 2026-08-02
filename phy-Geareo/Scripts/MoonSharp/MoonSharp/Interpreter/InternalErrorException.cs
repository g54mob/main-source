using System;

namespace MoonSharp.Interpreter
{
	[Serializable]
	public class InternalErrorException : InterpreterException
	{
		internal InternalErrorException(string message)
			: base((Exception)null, (string)null)
		{
		}

		internal InternalErrorException(string format, params object[] args)
			: base((Exception)null, (string)null)
		{
		}
	}
}
