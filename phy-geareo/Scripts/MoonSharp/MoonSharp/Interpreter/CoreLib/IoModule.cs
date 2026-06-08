using System;
using System.IO;
using System.Text;
using MoonSharp.Interpreter.CoreLib.IO;
using MoonSharp.Interpreter.Platforms;

namespace MoonSharp.Interpreter.CoreLib
{
	[MoonSharpModule(Namespace = "io")]
	public class IoModule
	{
		public static void MoonSharpInit(Table globalTable, Table ioTable)
		{
		}

		private static DynValue __index_callback(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static DynValue GetStandardFile(Script S, StandardFileType file)
		{
			return null;
		}

		private static void SetStandardFile(Script S, StandardFileType file, Stream optionsStream)
		{
		}

		private static FileUserDataBase GetDefaultFile(ScriptExecutionContext executionContext, StandardFileType file)
		{
			return null;
		}

		private static void SetDefaultFile(ScriptExecutionContext executionContext, StandardFileType file, FileUserDataBase fileHandle)
		{
		}

		internal static void SetDefaultFile(Script script, StandardFileType file, FileUserDataBase fileHandle)
		{
		}

		public static void SetDefaultFile(Script script, StandardFileType file, Stream stream)
		{
		}

		[MoonSharpModuleMethod]
		public static DynValue close(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue flush(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue input(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue output(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static DynValue HandleDefaultStreamSetter(ScriptExecutionContext executionContext, CallbackArguments args, StandardFileType defaultFiles)
		{
			return null;
		}

		private static Encoding GetUTF8Encoding()
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue lines(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue open(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		public static string IoExceptionToLuaMessage(Exception ex, string filename)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue type(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue read(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue write(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		[MoonSharpModuleMethod]
		public static DynValue tmpfile(ScriptExecutionContext executionContext, CallbackArguments args)
		{
			return null;
		}

		private static FileUserDataBase Open(ScriptExecutionContext executionContext, string filename, Encoding encoding, string mode)
		{
			return null;
		}
	}
}
