using haxe.lang;

namespace haxe.io
{
	public class BytesOutput : Output
	{
		public BytesBuffer b;

		public BytesOutput(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BytesOutput()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_io_BytesOutput(BytesOutput __hx_this)
		{
		}

		public int get_length()
		{
			return 0;
		}

		public override void writeByte(int c)
		{
		}

		public override int writeBytes(Bytes buf, int pos, int len)
		{
			return 0;
		}

		public virtual Bytes getBytes()
		{
			return null;
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
