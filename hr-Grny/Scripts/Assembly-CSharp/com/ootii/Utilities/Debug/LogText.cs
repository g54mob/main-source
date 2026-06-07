using com.ootii.Collections;

namespace com.ootii.Utilities.Debug
{
	public class LogText
	{
		public string Text;

		public int X;

		public int Y;

		private static ObjectPool<LogText> sPool;

		public static int Length => 0;

		public static LogText Allocate()
		{
			return null;
		}

		public static LogText Allocate(string rText, int rX, int rY)
		{
			return null;
		}

		public static void Release(LogText rInstance)
		{
		}
	}
}
