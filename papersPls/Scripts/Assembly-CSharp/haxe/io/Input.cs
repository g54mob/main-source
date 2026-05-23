using haxe.lang;

namespace haxe.io
{
	public class Input : HxObject
	{
		public bool bigEndian;

		public byte[] helper;

		public Input(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Input()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_io_Input(Input __hx_this)
		{
		}

		public virtual int readByte()
		{
			return 0;
		}

		public virtual int readBytes(Bytes s, int pos, int len)
		{
			return 0;
		}

		public virtual void close()
		{
		}

		public virtual bool set_bigEndian(bool b)
		{
			return false;
		}

		public virtual Bytes readAll(object bufsize)
		{
			return null;
		}

		public virtual void readFullBytes(Bytes s, int pos, int len)
		{
		}

		public virtual Bytes read(int nbytes)
		{
			return null;
		}

		public virtual string readUntil(int end)
		{
			return null;
		}

		public virtual string readLine()
		{
			return null;
		}

		public virtual double readFloat()
		{
			return 0.0;
		}

		public virtual double readDouble()
		{
			return 0.0;
		}

		public virtual int readInt8()
		{
			return 0;
		}

		public virtual int readInt16()
		{
			return 0;
		}

		public virtual int readUInt16()
		{
			return 0;
		}

		public virtual int readInt24()
		{
			return 0;
		}

		public virtual int readUInt24()
		{
			return 0;
		}

		public virtual int readInt32()
		{
			return 0;
		}

		public virtual string readString(int len, Encoding encoding)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
