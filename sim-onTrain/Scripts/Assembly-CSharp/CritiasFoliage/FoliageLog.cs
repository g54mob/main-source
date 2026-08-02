using System.Diagnostics;

namespace CritiasFoliage
{
	public class FoliageLog
	{
		[Conditional("DEBUG_MODE_FOLIAGE")]
		public static void i(string info)
		{
		}

		[Conditional("DEBUG_MODE_FOLIAGE")]
		public static void d(string debug)
		{
		}

		[Conditional("DEBUG_MODE_FOLIAGE")]
		public static void w(string warning)
		{
		}

		[Conditional("DEBUG_MODE_FOLIAGE")]
		public static void e(string error)
		{
		}

		[Conditional("DEBUG_MODE_FOLIAGE")]
		public static void SecureLog(string secure)
		{
		}

		[Conditional("DEBUG_MODE_FOLIAGE")]
		public static void Assert(bool value, string message = null)
		{
		}
	}
}
