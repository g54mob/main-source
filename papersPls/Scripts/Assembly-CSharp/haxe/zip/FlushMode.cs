using haxe.lang;

namespace haxe.zip
{
	public class FlushMode : Enum
	{
		public static readonly FlushMode NO;

		public static readonly FlushMode SYNC;

		public static readonly FlushMode FULL;

		public static readonly FlushMode FINISH;

		public static readonly FlushMode BLOCK;

		protected static readonly string[] __hx_constructs;

		protected FlushMode(int index)
			: base(0)
		{
		}
	}
}
