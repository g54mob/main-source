using haxe.lang;

namespace cs._NativeArray
{
	public class NativeArrayIterator : HxObject
	{
		public object[] arr;

		public uint idx;

		public NativeArrayIterator(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NativeArrayIterator(object[] arr)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_cs__NativeArray_NativeArrayIterator(NativeArrayIterator __hx_this, object[] arr)
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
