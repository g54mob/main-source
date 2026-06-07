using haxe.lang;

namespace sys
{
	public class FileSystem : HxObject
	{
		public FileSystem(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FileSystem()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_FileSystem(FileSystem __hx_this)
		{
		}

		public static bool exists(string path)
		{
			return false;
		}

		public static void rename(string path, string newPath)
		{
		}

		public static object stat(string path)
		{
			return null;
		}

		public static string fullPath(string relPath)
		{
			return null;
		}

		public static string absolutePath(string relPath)
		{
			return null;
		}

		public static bool isDirectory(string path)
		{
			return false;
		}

		public static void createDirectory(string path)
		{
		}

		public static void deleteFile(string path)
		{
		}

		public static void deleteDirectory(string path)
		{
		}

		public static Array readDirectory(string path)
		{
			return null;
		}
	}
}
