using haxe.lang;

namespace haxe
{
	public class StackItem : Enum
	{
		public static readonly StackItem CFunction;

		protected static readonly string[] __hx_constructs;

		protected StackItem(int index)
			: base(0)
		{
		}

		public static StackItem Module(string m)
		{
			return null;
		}

		public static StackItem FilePos(StackItem s, string file, int line, object column)
		{
			return null;
		}

		public static StackItem Method(string classname, string method)
		{
			return null;
		}

		public static StackItem LocalFunction(object v)
		{
			return null;
		}
	}
}
