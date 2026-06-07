namespace MoonSharp.Interpreter
{
	public class DynamicExpressionException : ScriptRuntimeException
	{
		public DynamicExpressionException(string format, params object[] args)
			: base("<dynamic>: " + format, args)
		{
		}

		public DynamicExpressionException(string message)
			: base("<dynamic>: " + message)
		{
		}
	}
}
