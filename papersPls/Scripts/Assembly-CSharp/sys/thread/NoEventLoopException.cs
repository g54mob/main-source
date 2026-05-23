using haxe;
using haxe.lang;

namespace sys.thread
{
	public class NoEventLoopException : Exception
	{
		public NoEventLoopException(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NoEventLoopException(string msg, Exception previous)
			: base(default(EmptyObject))
		{
		}
	}
}
