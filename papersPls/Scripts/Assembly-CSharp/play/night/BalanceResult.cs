using haxe.lang;

namespace play.night
{
	public class BalanceResult : Enum
	{
		public static readonly BalanceResult AllGood;

		protected static readonly string[] __hx_constructs;

		protected BalanceResult(int index)
			: base(0)
		{
		}

		public static BalanceResult Rejected(int lineIndex)
		{
			return null;
		}
	}
}
