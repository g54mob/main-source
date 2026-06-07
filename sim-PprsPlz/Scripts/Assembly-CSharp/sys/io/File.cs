using haxe.io;
using haxe.lang;

namespace sys.io
{
	public class File : HxObject
	{
		public File(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public File()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_io_File(File __hx_this)
		{
		}

		public static string getContent(string path)
		{
			return null;
		}

		public static void saveContent(string path, string content)
		{
		}

		public static Bytes getBytes(string path)
		{
			return null;
		}

		public static void saveBytes(string path, Bytes bytes)
		{
		}

		public static FileInput read(string path, object binary)
		{
			return null;
		}

		public static FileOutput write(string path, object binary)
		{
			return null;
		}

		public static FileOutput append(string path, object binary)
		{
			return null;
		}

		public static FileOutput update(string path, object binary)
		{
			return null;
		}

		public static void copy(string srcPath, string dstPath)
		{
		}
	}
}
