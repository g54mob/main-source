using haxe.lang;

namespace app
{
	public class ExpressionTester : HxObject
	{
		public ExpressionTester(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ExpressionTester()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_ExpressionTester(ExpressionTester __hx_this)
		{
		}

		public static bool test(string lhs, string op, string rhs, Function leftExpander)
		{
			return false;
		}

		public static bool testWithGlue(Array tokens, object start, Function leftExpander)
		{
			return false;
		}

		public static Array getSolutions(Array tokens, object start)
		{
			return null;
		}
	}
}
