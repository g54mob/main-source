using haxe.lang;

namespace haxe.io
{
	public class Output : HxObject
	{
		public bool bigEndian;

		public Output(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Output()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_io_Output(Output __hx_this)
		{
		}

		public virtual void writeByte(int c)
		{
		}

		public virtual int writeBytes(Bytes s, int pos, int len)
		{
			return 0;
		}

		public virtual void flush()
		{
		}

		public virtual void close()
		{
		}

		public virtual bool set_bigEndian(bool b)
		{
			return false;
		}

		public virtual void write(Bytes s)
		{
		}

		public virtual void writeFullBytes(Bytes s, int pos, int len)
		{
		}

		public virtual void writeFloat(double x)
		{
		}

		public virtual void writeDouble(double x)
		{
		}

		public virtual void writeInt8(int x)
		{
		}

		public virtual void writeInt16(int x)
		{
		}

		public virtual void writeUInt16(int x)
		{
		}

		public virtual void writeInt24(int x)
		{
		}

		public virtual void writeUInt24(int x)
		{
		}

		public virtual void writeInt32(int x)
		{
		}

		public virtual void prepare(int nbytes)
		{
		}

		public virtual void writeInput(Input i, object bufsize)
		{
		}

		public virtual void writeString(string s, Encoding encoding)
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
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
