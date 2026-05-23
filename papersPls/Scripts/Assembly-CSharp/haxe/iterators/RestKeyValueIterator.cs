using haxe.lang;

namespace haxe.iterators
{
	public class RestKeyValueIterator : HxObject
	{
		public object[] args;

		public int current;

		public RestKeyValueIterator(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public RestKeyValueIterator(object args)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_iterators_RestKeyValueIterator(RestKeyValueIterator __hx_this, object args)
		{
		}

		public bool hasNext()
		{
			return false;
		}

		public object next()
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
