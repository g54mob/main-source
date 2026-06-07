namespace haxe.lang
{
	public class HxObject : IHxObject
	{
		public HxObject(EmptyObject empty)
		{
		}

		public HxObject()
		{
		}

		protected static void __hx_ctor_haxe_lang_HxObject(HxObject __hx_this)
		{
		}

		public virtual bool __hx_deleteField(string field, int hash)
		{
			return false;
		}

		public virtual object __hx_lookupField(string field, int hash, bool throwErrors, bool isCheck)
		{
			return null;
		}

		public virtual double __hx_lookupField_f(string field, int hash, bool throwErrors)
		{
			return 0.0;
		}

		public virtual object __hx_lookupSetField(string field, int hash, object value)
		{
			return null;
		}

		public virtual double __hx_lookupSetField_f(string field, int hash, double value)
		{
			return 0.0;
		}

		public virtual double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public virtual object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public virtual object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public virtual double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public virtual object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public virtual void __hx_getFields(Array baseArr)
		{
		}
	}
}
