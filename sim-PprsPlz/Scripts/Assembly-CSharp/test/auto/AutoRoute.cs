using data;
using haxe.lang;

namespace test.auto
{
	public class AutoRoute : HxObject
	{
		public int num;

		public string id;

		public string endlessStyleId;

		public string endlessCourseId;

		public TabParser tabParser;

		public Node defaultRoot;

		public Node customRoot;

		public AutoRoute(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoRoute(TabParser tabParser_, int num_, string id_, string endlessStyleId_, string endlessCourseId_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoRoute(AutoRoute __hx_this, TabParser tabParser_, int num_, string id_, string endlessStyleId_, string endlessCourseId_)
		{
		}

		public bool get_isEndless()
		{
			return false;
		}

		public int get_expectedEndNum()
		{
			return 0;
		}

		public virtual Node getTabNode(string subnodeId)
		{
			return null;
		}

		public virtual string description()
		{
			return null;
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
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
