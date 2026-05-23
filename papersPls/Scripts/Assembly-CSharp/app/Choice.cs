using haxe.lang;

namespace app
{
	public class Choice : HxObject
	{
		public string val;

		public double prob;

		public Choice(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Choice(string val_, double prob_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Choice(Choice __hx_this, string val_, double prob_)
		{
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
