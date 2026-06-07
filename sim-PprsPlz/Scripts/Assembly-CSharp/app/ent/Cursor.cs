using app.vis;
using haxe.lang;

namespace app.ent
{
	public class Cursor : Enum
	{
		public static readonly Cursor ARROW;

		public static readonly Cursor HAND;

		protected static readonly string[] __hx_constructs;

		protected Cursor(int index)
			: base(0)
		{
		}

		public static Cursor CUSTOM(Image image)
		{
			return null;
		}
	}
}
