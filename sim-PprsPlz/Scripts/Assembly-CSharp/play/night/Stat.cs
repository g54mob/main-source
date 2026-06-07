using haxe.lang;

namespace play.night
{
	public class Stat : HxObject
	{
		public int val;

		public int max;

		public Stat(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Stat(int max_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_night_Stat(Stat __hx_this, int max_)
		{
		}

		public virtual void inc()
		{
		}

		public virtual void dec()
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
