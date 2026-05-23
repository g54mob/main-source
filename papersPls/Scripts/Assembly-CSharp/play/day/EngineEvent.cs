using haxe.lang;

namespace play.day
{
	public class EngineEvent : Enum
	{
		public static readonly EngineEvent EMPTY_START;

		public static readonly EngineEvent ENTERING_FINISH;

		public static readonly EngineEvent WELCOMING_START;

		public static readonly EngineEvent WORKING_START;

		public static readonly EngineEvent WORKING_INTRO;

		public static readonly EngineEvent WORKING_FINISH;

		public static readonly EngineEvent WAITINGTOLEAVE_START;

		public static readonly EngineEvent PROCESSING_FINISH;

		protected static readonly string[] __hx_constructs;

		protected EngineEvent(int index)
			: base(0)
		{
		}

		public static EngineEvent ENTERING_START(bool before6PM)
		{
			return null;
		}
	}
}
