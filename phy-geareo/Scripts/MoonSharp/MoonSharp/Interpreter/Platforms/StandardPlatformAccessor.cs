using System.IO;
using System.Text;

namespace MoonSharp.Interpreter.Platforms
{
	public class StandardPlatformAccessor : PlatformAccessorBase
	{
		public static FileAccess ParseFileAccess(string mode)
		{
			return default(FileAccess);
		}

		public static FileMode ParseFileMode(string mode)
		{
			return default(FileMode);
		}

		public override Stream IO_OpenFile(Script script, string filename, Encoding encoding, string mode)
		{
			return null;
		}

		public override string GetEnvironmentVariable(string envvarname)
		{
			return null;
		}

		public override Stream IO_GetStandardStream(StandardFileType type)
		{
			return null;
		}

		public override void DefaultPrint(string content)
		{
		}

		public override string IO_OS_GetTempFilename()
		{
			return null;
		}

		public override void OS_ExitFast(int exitCode)
		{
		}

		public override bool OS_FileExists(string file)
		{
			return false;
		}

		public override void OS_FileDelete(string file)
		{
		}

		public override void OS_FileMove(string src, string dst)
		{
		}

		public override int OS_Execute(string cmdline)
		{
			return 0;
		}

		public override CoreModules FilterSupportedCoreModules(CoreModules module)
		{
			return default(CoreModules);
		}

		public override string GetPlatformNamePrefix()
		{
			return null;
		}
	}
}
