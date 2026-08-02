namespace MoonSharp.Interpreter.CoreLib
{
	[MoonSharpModule]
	public class ErrorHandlingModule
	{
		[MoonSharpModuleMethod]
		public static DynValue pcall(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static DynValue SetErrorHandlerStrategy(string funcName, ScriptExecutionContext executionContext, CallbackArguments args, DynValue handlerBeforeUnwind)
		{
			return null;
		}

		private static DynValue MakeReturnTuple(bool retstatus, CallbackArguments args)
		{
			return null;
		}

		public static DynValue pcall_continuation(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		public static DynValue pcall_onerror(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue xpcall(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}
	}
}
