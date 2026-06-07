using haxe.lang;

namespace haxe.exceptions
{
	public class NotImplementedException : PosException
	{
		public NotImplementedException(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NotImplementedException(string message, Exception previous, object pos)
			: base(default(EmptyObject))
		{
		}
	}
}
