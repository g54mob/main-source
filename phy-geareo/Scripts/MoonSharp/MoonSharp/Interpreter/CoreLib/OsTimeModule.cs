using System;

namespace MoonSharp.Interpreter.CoreLib
{
	[MoonSharpModule(Namespace = "os")]
	public class OsTimeModule
	{
		private static DateTime Time0;

		private static DateTime Epoch;

		private static DynValue GetUnixTime(DateTime dateTime, DateTime? epoch = null)
		{
			return null;
		}

		private static DateTime FromUnixTime(double unixtime)
		{
			return default(DateTime);
		}

		[MoonSharpModuleMethod]
		public static DynValue clock(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue difftime(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue time(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static DateTime ParseTimeTable(Table t)
		{
			return default(DateTime);
		}

		private static int? GetTimeTableField(Table t, string key)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue date(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static string StrFTime(string format, DateTime d)
		{
			return null;
		}
	}
}
