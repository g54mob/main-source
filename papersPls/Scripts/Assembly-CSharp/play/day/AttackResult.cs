using haxe.lang;

namespace play.day
{
	public class AttackResult : Enum
	{
		public static readonly AttackResult NONE;

		public static readonly AttackResult FAILED_DIDNOTHING;

		public static readonly AttackResult FAILED_FIREDGUN;

		public static readonly AttackResult SOLVED;

		protected static readonly string[] __hx_constructs;

		protected AttackResult(int index)
			: base(0)
		{
		}

		public static AttackResult HIT_INNOCENT(bool tranq)
		{
			return null;
		}

		public static AttackResult HIT_GUARD(bool tranq)
		{
			return null;
		}

		public static AttackResult HIT_TARGET(bool tranq)
		{
			return null;
		}
	}
}
