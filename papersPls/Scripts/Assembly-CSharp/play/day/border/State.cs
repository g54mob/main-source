using haxe.lang;

namespace play.day.border
{
	public class State : Enum
	{
		public static readonly State OFF;

		public static readonly State LOCKED;

		public static readonly State UNLOCKING;

		public static readonly State UNLOCKED;

		public static readonly State DOCKED;

		protected static readonly string[] __hx_constructs;

		protected State(int index)
			: base(0)
		{
		}
	}
}
