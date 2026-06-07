using haxe.lang;

namespace haxe.io
{
	public class Error : Enum
	{
		public static readonly Error Blocked;

		public static readonly Error Overflow;

		public static readonly Error OutsideBounds;

		protected static readonly string[] __hx_constructs;

		protected Error(int index)
			: base(0)
		{
		}

		public static Error Custom(object e)
		{
			return null;
		}
	}
}
