using haxe.lang;

namespace app
{
	public class Func : HxObject
	{
		public TimedFunc time;

		public object func;

		public bool called;

		public Func(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Func(TimedFunc time, object func, bool called)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Func(Func __hx_this, TimedFunc time, object func, bool called)
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
