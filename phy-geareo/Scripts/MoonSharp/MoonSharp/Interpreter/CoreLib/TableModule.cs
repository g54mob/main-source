namespace MoonSharp.Interpreter.CoreLib
{
	[MoonSharpModule(Namespace = "table")]
	public class TableModule
	{
		[MoonSharpModuleMethod]
		public static DynValue unpack(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue pack(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue sort(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static int SortComparer(ScriptExecutionContext executionContext, DynValue a, DynValue b, DynValue lt)
		{
			return 0;
		}

		private static int LuaComparerToClrComparer(DynValue dynValue1, DynValue dynValue2)
		{
			return 0;
		}

		[MoonSharpModuleMethod]
		public static DynValue insert(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue remove(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue concat(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static int GetTableLength(ScriptExecutionContext executionContext, DynValue vlist)
		{
			return 0;
		}
	}
}
