using haxe.io;
using haxe.lang;

namespace format.png
{
	public class Chunk : Enum
	{
		public static readonly Chunk CEnd;

		protected static readonly string[] __hx_constructs;

		protected Chunk(int index)
			: base(0)
		{
		}

		public static Chunk CHeader(object h)
		{
			return null;
		}

		public static Chunk CData(Bytes b)
		{
			return null;
		}

		public static Chunk CPalette(Bytes b)
		{
			return null;
		}

		public static Chunk CUnknown(string id, Bytes data)
		{
			return null;
		}
	}
}
