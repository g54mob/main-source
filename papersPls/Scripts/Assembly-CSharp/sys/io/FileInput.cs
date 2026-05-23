using System.IO;
using cs.io;
using haxe.lang;

namespace sys.io
{
	public class FileInput : NativeInput
	{
		public FileInput(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FileInput(FileStream stream)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_io_FileInput(FileInput __hx_this, FileStream stream)
		{
		}
	}
}
