using haxe.lang;

namespace haxe.io
{
	public class Path : HxObject
	{
		public string dir;

		public string file;

		public string ext;

		public bool backslash;

		public Path(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Path(string path)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_io_Path(Path __hx_this, string path)
		{
		}

		public static string withoutExtension(string path)
		{
			return null;
		}

		public static string withoutDirectory(string path)
		{
			return null;
		}

		public static string directory(string path)
		{
			return null;
		}

		public static string extension(string path)
		{
			return null;
		}

		public static string withExtension(string path, string ext)
		{
			return null;
		}

		public static string join(Array paths)
		{
			return null;
		}

		public static string normalize(string path)
		{
			return null;
		}

		public static string addTrailingSlash(string path)
		{
			return null;
		}

		public static string removeTrailingSlashes(string path)
		{
			return null;
		}

		public static bool isAbsolute(string path)
		{
			return false;
		}

		public static string unescape(string path)
		{
			return null;
		}

		public static string escape(string path, object allowSlashes)
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
