using haxe.io;
using haxe.lang;

namespace haxe.zip
{
	public class ExtraField : Enum
	{
		public static readonly ExtraField FUtf8;

		protected static readonly string[] __hx_constructs;

		protected ExtraField(int index)
			: base(0)
		{
		}

		public static ExtraField FUnknown(int tag, Bytes bytes)
		{
			return null;
		}

		public static ExtraField FInfoZipUnicodePath(string name, int crc)
		{
			return null;
		}
	}
}
