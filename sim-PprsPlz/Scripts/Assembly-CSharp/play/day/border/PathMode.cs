using haxe.lang;

namespace play.day.border
{
	public class PathMode : Enum
	{
		public static readonly PathMode NONE;

		public static readonly PathMode IDLE;

		public static readonly PathMode ANIMATEINPLACE;

		public static readonly PathMode MOVEONPATH;

		public static readonly PathMode MOVINGTOPATH;

		protected static readonly string[] __hx_constructs;

		protected PathMode(int index)
			: base(0)
		{
		}
	}
}
