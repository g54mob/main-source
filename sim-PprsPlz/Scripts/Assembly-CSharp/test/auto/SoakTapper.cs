using haxe.lang;

namespace test.auto
{
	public class SoakTapper : HxObject
	{
		public Array taps;

		public double tapTime;

		public int tapIndex;

		public SoakTapper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SoakTapper(Array markers)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_SoakTapper(SoakTapper __hx_this, Array markers)
		{
		}

		public virtual bool tap()
		{
			return false;
		}

		public virtual void reset()
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
