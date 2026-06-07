using haxe.io;
using haxe.lang;

namespace app.vis
{
	public class Alloc : Enum
	{
		public static readonly Alloc NEW;

		protected static readonly string[] __hx_constructs;

		protected Alloc(int index)
			: base(0)
		{
		}

		public static Alloc EXISTING(Bytes bytes)
		{
			return null;
		}
	}
}
