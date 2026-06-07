using haxe.lang;

namespace app
{
	public class Solo : HxObject
	{
		public object val;

		public bool locked;

		public Solo(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Solo(object val_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Solo(Solo __hx_this, object val_)
		{
		}

		public virtual void reportError(string message)
		{
		}

		public object @lock()
		{
			return null;
		}

		public void unlock()
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
