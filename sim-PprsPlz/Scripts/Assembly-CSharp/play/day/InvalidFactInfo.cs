using data;
using haxe.lang;

namespace play.day
{
	public class InvalidFactInfo : HxObject
	{
		public string path;

		public Op op;

		public int order;

		public InvalidFactInfo(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public InvalidFactInfo(string path_, Op op_, int order_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_InvalidFactInfo(InvalidFactInfo __hx_this, string path_, Op op_, int order_)
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
