using haxe.ds;
using haxe.io;
using haxe.lang;

namespace format.png
{
	public class Tools : HxObject
	{
		public Tools(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Tools()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_format_png_Tools(Tools __hx_this)
		{
		}

		public static object getHeader(List d)
		{
			return null;
		}

		public static Bytes getPalette(List d)
		{
			return null;
		}

		public static int filter(Bytes data, int x, int y, int stride, int prev, int p, object numChannels)
		{
			return 0;
		}

		public static void reverseBytes(Bytes b)
		{
		}

		public static Bytes extractGrey(List d)
		{
			return null;
		}

		public static Bytes extract32(List d, Bytes bytes, object flipY)
		{
			return null;
		}

		public static List buildGrey(int width, int height, Bytes data, object level)
		{
			return null;
		}

		public static List buildIndexed(int width, int height, Bytes data, Bytes palette, object level)
		{
			return null;
		}

		public static List buildRGB(int width, int height, Bytes data, object level)
		{
			return null;
		}

		public static List build32ARGB(int width, int height, Bytes data, object level)
		{
			return null;
		}

		public static List build32BGRA(int width, int height, Bytes data, object level)
		{
			return null;
		}
	}
}
