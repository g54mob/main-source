using haxe.lang;

namespace haxe.io
{
	public class Bytes : HxObject
	{
		public int length;

		public byte[] b;

		public Bytes(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Bytes(int length, byte[] b)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_io_Bytes(Bytes __hx_this, int length, byte[] b)
		{
		}

		public static Bytes alloc(int length)
		{
			return null;
		}

		public static Bytes ofString(string s, Encoding encoding)
		{
			return null;
		}

		public static Bytes ofData(byte[] b)
		{
			return null;
		}

		public static Bytes ofHex(string s)
		{
			return null;
		}

		public static int fastGet(byte[] b, int pos)
		{
			return 0;
		}

		public int get(int pos)
		{
			return 0;
		}

		public void set(int pos, int v)
		{
		}

		public virtual void blit(int pos, Bytes src, int srcpos, int len)
		{
		}

		public virtual void fill(int pos, int len, int value)
		{
		}

		public virtual Bytes sub(int pos, int len)
		{
			return null;
		}

		public virtual int compare(Bytes other)
		{
			return 0;
		}

		public virtual double getDouble(int pos)
		{
			return 0.0;
		}

		public virtual double getFloat(int pos)
		{
			return 0.0;
		}

		public virtual void setDouble(int pos, double v)
		{
		}

		public virtual void setFloat(int pos, double v)
		{
		}

		public int getUInt16(int pos)
		{
			return 0;
		}

		public void setUInt16(int pos, int v)
		{
		}

		public int getInt32(int pos)
		{
			return 0;
		}

		public long getInt64(int pos)
		{
			return 0L;
		}

		public void setInt32(int pos, int v)
		{
		}

		public void setInt64(int pos, long v)
		{
		}

		public virtual string getString(int pos, int len, Encoding encoding)
		{
			return null;
		}

		public string readString(int pos, int len)
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual string toHex()
		{
			return null;
		}

		public byte[] getData()
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

		public override string ToString()
		{
			return null;
		}
	}
}
