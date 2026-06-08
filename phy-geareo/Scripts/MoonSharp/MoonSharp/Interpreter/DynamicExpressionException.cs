using System;

namespace MoonSharp.Interpreter
{
	[Serializable]
	public class DynamicExpressionException : ScriptRuntimeException
	{
		public DynamicExpressionException(string format, params object[] args)
			: base((Exception)null)
		{
		}

		public DynamicExpressionException(string message)
			: base((Exception)null)
		{
		}
	}
}
