using haxe.lang;

namespace app
{
	public class Iter : HxObject
	{
		public PagedArray pagedArray;

		public int i;

		public Iter(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Iter(PagedArray pagedArray_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Iter(Iter __hx_this, PagedArray pagedArray_)
		{
		}

		public void init(PagedArray pagedArray_)
		{
		}

		public virtual bool hasNext()
		{
			return false;
		}

		public virtual object next()
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
