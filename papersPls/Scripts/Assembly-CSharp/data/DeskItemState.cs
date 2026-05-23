using haxe.lang;

namespace data
{
	public class DeskItemState : Enum
	{
		public static readonly DeskItemState NONE;

		public static readonly DeskItemState REVEALING;

		public static readonly DeskItemState NORMAL;

		public static readonly DeskItemState RETURNINGTODOCK;

		public static readonly DeskItemState HIDING;

		public static readonly DeskItemState HIDDEN;

		public static readonly DeskItemState GIVING;

		public static readonly DeskItemState GIVEN;

		protected static readonly string[] __hx_constructs;

		protected DeskItemState(int index)
			: base(0)
		{
		}
	}
}
