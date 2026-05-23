using haxe.lang;

namespace app
{
	public class ThreadMessage : Enum
	{
		public static readonly ThreadMessage FrameReady;

		public static readonly ThreadMessage Quit;

		protected static readonly string[] __hx_constructs;

		protected ThreadMessage(int index)
			: base(0)
		{
		}
	}
}
