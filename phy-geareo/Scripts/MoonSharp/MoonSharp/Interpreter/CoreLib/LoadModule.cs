namespace MoonSharp.Interpreter.CoreLib
{
	[MoonSharpModule]
	public class LoadModule
	{
		[MoonSharpModuleMethod]
		public const string require = "\r\nfunction(modulename)\r\n\tif (package == nil) then package = { }; end\r\n\tif (package.loaded == nil) then package.loaded = { }; end\r\n\r\n\tlocal m = package.loaded[modulename];\r\n\r\n\tif (m ~= nil) then\r\n\t\treturn m;\r\n\tend\r\n\r\n\tlocal func = __require_clr_impl(modulename);\r\n\r\n\tlocal res = func(modulename);\r\n\r\n\tif (res == nil) then\r\n\t\tres = true;\r\n\tend\r\n\r\n\tpackage.loaded[modulename] = res;\r\n\r\n\treturn res;\r\nend";

		public static void MoonSharpInit(Table globalTable, Table ioTable)
		{
		}

		[MoonSharpModuleMethod]
		public static DynValue load(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue loadsafe(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		public static DynValue load_impl(ScriptExecutionContext executionContext, CallbackArguments args, Table defaultEnv)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue loadfile(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue loadfilesafe(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static DynValue loadfile_impl(ScriptExecutionContext executionContext, CallbackArguments args, Table defaultEnv)
		{
			return null;
		}

		private static Table GetSafeDefaultEnv(ScriptExecutionContext executionContext)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue dofile(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue __require_clr_impl(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}
	}
}
