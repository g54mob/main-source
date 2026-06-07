using haxe.lang;

namespace haxe.io
{
	public class ArrayBufferViewImpl : HxObject
	{
		public Bytes bytes;

		public int byteOffset;

		public int byteLength;

		public ArrayBufferViewImpl(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ArrayBufferViewImpl(Bytes bytes, int pos, int length)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_io_ArrayBufferViewImpl(ArrayBufferViewImpl __hx_this, Bytes bytes, int pos, int length)
		{
		}

		public virtual ArrayBufferViewImpl sub(int begin, object length)
		{
			return null;
		}

		public virtual ArrayBufferViewImpl subarray(object begin, object end)
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
