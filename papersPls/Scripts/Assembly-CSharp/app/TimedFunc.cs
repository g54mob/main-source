using haxe.lang;

namespace app
{
	public class TimedFunc : Enum
	{
		public static readonly TimedFunc ENTER;

		public static readonly TimedFunc INTERP;

		public static readonly TimedFunc STEP;

		public static readonly TimedFunc EXIT;

		protected static readonly string[] __hx_constructs;

		protected TimedFunc(int index)
			: base(0)
		{
		}

		public static TimedFunc AT_STEP(double time)
		{
			return null;
		}

		public static TimedFunc AT_INTERP(double t)
		{
			return null;
		}
	}
}
