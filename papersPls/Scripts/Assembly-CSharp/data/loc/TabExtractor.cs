using haxe.lang;

namespace data.loc
{
	public class TabExtractor : HxObject
	{
		public string filename;

		public string contextPrefix;

		public Function matchFunc;

		public TabExtractor(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TabExtractor(string filename_, string contextPrefix_, Function matchFunc_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_loc_TabExtractor(TabExtractor __hx_this, string filename_, string contextPrefix_, Function matchFunc_)
		{
		}

		public static TabExtractor make(string filename_, string contextPrefix_, Function matchFunc_)
		{
			return null;
		}

		public virtual void run(Node root, Function extractedFunc)
		{
		}

		public virtual void runSubs(TabContext tabContext, Node node, string context, Function extractedFunc)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
