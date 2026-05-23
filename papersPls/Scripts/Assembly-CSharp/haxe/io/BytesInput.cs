using haxe.lang;

namespace haxe.io
{
	public class BytesInput : Input
	{
		public byte[] b;

		public int pos;

		public int len;

		public int totlen;

		public BytesInput(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BytesInput(Bytes b, object pos, object len)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_io_BytesInput(BytesInput __hx_this, Bytes b, object pos, object len)
		{
		}

		public int get_position()
		{
			return 0;
		}

		public int get_length()
		{
			return 0;
		}

		public virtual int set_position(int p)
		{
			return 0;
		}

		public override int readByte()
		{
			return 0;
		}

		public override int readBytes(Bytes buf, int pos, int len)
		{
			return 0;
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
