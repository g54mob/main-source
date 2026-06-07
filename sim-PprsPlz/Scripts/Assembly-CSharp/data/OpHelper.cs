using haxe.lang;

namespace data
{
	public class OpHelper : HxObject
	{
		public OpHelper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public OpHelper()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_OpHelper(OpHelper __hx_this)
		{
		}

		public static void validate(Op op, Db db)
		{
		}

		public static Array getRunOps(Op op, string opId)
		{
			return null;
		}

		public static Array getEnableButtonIds(Array ops)
		{
			return null;
		}

		public static bool isSay(Op op)
		{
			return false;
		}

		public static Array getInvalidateFactPaths(Op op)
		{
			return null;
		}

		public static void dumpToTrace(Op op, string indent, object posInfos)
		{
		}

		public static string toString(Op op)
		{
			return null;
		}

		public static Op makeOp(Node node, Node root)
		{
			return null;
		}
	}
}
