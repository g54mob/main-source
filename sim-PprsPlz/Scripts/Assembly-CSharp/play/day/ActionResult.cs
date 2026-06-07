using haxe.lang;

namespace play.day
{
	public class ActionResult : Enum
	{
		public static readonly ActionResult NONE;

		protected static readonly string[] __hx_constructs;

		protected ActionResult(int index)
			: base(0)
		{
		}

		public static ActionResult ADDEDPAPER(string paperId)
		{
			return null;
		}

		public static ActionResult REMOVEDPAPER(string paperId)
		{
			return null;
		}

		public static ActionResult UPDATEDFACTS(string paperId)
		{
			return null;
		}

		public static ActionResult SPEAK(string text, bool fromTraveler, bool pauseAfter)
		{
			return null;
		}
	}
}
