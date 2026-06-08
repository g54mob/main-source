namespace MoonSharp.Interpreter.CoreLib
{
	[MoonSharpModule(Namespace = "dynamic")]
	public class DynamicModule
	{
		private class DynamicExprWrapper
		{
			public DynamicExpression Expr;
		}

		public static void MoonSharpInit(Table globalTable, Table stringTable)
		{
		}

		[MoonSharpModuleMethod]
		public static DynValue eval(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue prepare(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}
	}
}
