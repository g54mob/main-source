using haxe.lang;

namespace app
{
	public class InterpType : Enum
	{
		public static readonly InterpType _LINEAR;

		protected static readonly string[] __hx_constructs;

		protected InterpType(int index)
			: base(0)
		{
		}

		public static InterpType _STEP(double t)
		{
			return null;
		}

		public static InterpType _POW(double p)
		{
			return null;
		}

		public static InterpType _INVPOW(double p)
		{
			return null;
		}

		public static InterpType _SMOOTHSTEP(double e0, double e1)
		{
			return null;
		}

		public static InterpType _SMOOTHERSTEP(double e0, double e1)
		{
			return null;
		}

		public static InterpType _BOUNCEBACK(double perc, int count)
		{
			return null;
		}

		public static InterpType _FLASH(double count)
		{
			return null;
		}

		public static InterpType _RISEFALL(double mid)
		{
			return null;
		}
	}
}
