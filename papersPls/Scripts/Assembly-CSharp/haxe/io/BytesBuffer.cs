using System.IO;
using haxe.lang;

namespace haxe.io
{
	public class BytesBuffer : HxObject
	{
		public MemoryStream b;

		public BytesBuffer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BytesBuffer()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_io_BytesBuffer(BytesBuffer __hx_this)
		{
		}

		public int get_length()
		{
			return 0;
		}

		public void addByte(int @byte)
		{
		}

		public void add(Bytes src)
		{
		}

		public void addString(string v, Encoding encoding)
		{
		}

		public virtual void addInt32(int v)
		{
		}

		public virtual void addInt64(long v)
		{
		}

		public void addFloat(double v)
		{
		}

		public void addDouble(double v)
		{
		}

		public void addBytes(Bytes src, int pos, int len)
		{
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
