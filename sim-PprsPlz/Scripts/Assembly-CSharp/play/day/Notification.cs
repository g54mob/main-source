using haxe.lang;

namespace play.day
{
	public class Notification : Enum
	{
		public static readonly Notification END_GAME;

		protected static readonly string[] __hx_constructs;

		protected Notification(int index)
			: base(0)
		{
		}

		public static Notification ADD_SCORE(int amount)
		{
			return null;
		}

		public static Notification LOSE_TIME(int amount)
		{
			return null;
		}
	}
}
