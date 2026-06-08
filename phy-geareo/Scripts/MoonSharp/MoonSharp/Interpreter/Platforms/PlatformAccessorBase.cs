using System;
using System.IO;
using System.Text;

namespace MoonSharp.Interpreter.Platforms
{
	public abstract class PlatformAccessorBase : IPlatformAccessor
	{
		public abstract string GetPlatformNamePrefix();

		public string GetPlatformName()
		{
			return null;
		}

		private string GetUnityRuntimeName()
		{
			return null;
		}

		private string GetUnityPlatformName()
		{
			return null;
		}

		public abstract void DefaultPrint(string content);

		[Obsolete("Replace with DefaultInput(string)")]
		public virtual string DefaultInput()
		{
			return null;
		}

		public virtual string DefaultInput(string prompt)
		{
			return null;
		}

		public abstract Stream IO_OpenFile(Script script, string filename, Encoding encoding, string mode);

		public abstract Stream IO_GetStandardStream(StandardFileType type);

		public abstract string IO_OS_GetTempFilename();

		public abstract void OS_ExitFast(int exitCode);

		public abstract bool OS_FileExists(string file);

		public abstract void OS_FileDelete(string file);

		public abstract void OS_FileMove(string src, string dst);

		public abstract int OS_Execute(string cmdline);

		public abstract CoreModules FilterSupportedCoreModules(CoreModules module);

		public abstract string GetEnvironmentVariable(string envvarname);

		public virtual bool IsRunningOnAOT()
		{
			return false;
		}
	}
}
