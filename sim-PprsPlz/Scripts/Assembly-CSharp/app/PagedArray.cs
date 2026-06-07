using haxe.lang;

namespace app
{
	public class PagedArray : HxObject
	{
		public int length;

		public int pageLength;

		public Array pages;

		public PagedArray(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PagedArray(object pageLength_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_PagedArray(PagedArray __hx_this, object pageLength_)
		{
		}

		public virtual void reset()
		{
		}

		public virtual void push(object t)
		{
		}

		public virtual Iter iterator()
		{
			return null;
		}

		public virtual object get(int i)
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
