using haxe.lang;

namespace play.night
{
	public class LineKind : Enum
	{
		public static readonly LineKind SAVINGS;

		public static readonly LineKind SALARY;

		public static readonly LineKind PENALTIES;

		public static readonly LineKind BRIBES;

		public static readonly LineKind RENT;

		public static readonly LineKind FOOD;

		public static readonly LineKind HEAT;

		protected static readonly string[] __hx_constructs;

		protected LineKind(int index)
			: base(0)
		{
		}

		public static LineKind MEDICINE(string memberId)
		{
			return null;
		}

		public static LineKind CUSTOM(string localizedName)
		{
			return null;
		}
	}
}
