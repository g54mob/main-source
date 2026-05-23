using haxe.lang;

namespace haxe.iterators
{
	public class ArrayKeyValueIterator : HxObject
	{
		public int current;

		public Array array;

		public ArrayKeyValueIterator(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ArrayKeyValueIterator(Array array)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_iterators_ArrayKeyValueIterator(ArrayKeyValueIterator __hx_this, Array array)
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
