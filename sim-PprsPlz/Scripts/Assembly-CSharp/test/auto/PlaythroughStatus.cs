using haxe.lang;

namespace test.auto
{
	public class PlaythroughStatus : Enum
	{
		public static readonly PlaythroughStatus NONE;

		public static readonly PlaythroughStatus RUNNING;

		public static readonly PlaythroughStatus COMPLETEDOK;

		public static readonly PlaythroughStatus ERROR;

		protected static readonly string[] __hx_constructs;

		protected PlaythroughStatus(int index)
			: base(0)
		{
		}
	}
}
