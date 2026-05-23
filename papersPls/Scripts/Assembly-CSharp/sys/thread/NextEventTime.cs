using haxe.lang;

namespace sys.thread
{
	public class NextEventTime : Enum
	{
		public static readonly NextEventTime Now;

		public static readonly NextEventTime Never;

		protected static readonly string[] __hx_constructs;

		protected NextEventTime(int index)
			: base(0)
		{
		}

		public static NextEventTime AnyTime(object time)
		{
			return null;
		}

		public static NextEventTime At(double time)
		{
			return null;
		}
	}
}
