using System.IO;
using cs.io;
using haxe.lang;

namespace sys.io
{
	public class FileOutput : NativeOutput
	{
		public FileOutput(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FileOutput(FileStream stream)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_io_FileOutput(FileOutput __hx_this, FileStream stream)
		{
		}
	}
}
