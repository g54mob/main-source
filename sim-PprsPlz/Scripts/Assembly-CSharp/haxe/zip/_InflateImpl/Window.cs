using haxe.crypto;
using haxe.io;
using haxe.lang;

namespace haxe.zip._InflateImpl
{
	public class Window : HxObject
	{
		public static int SIZE;

		public static int BUFSIZE;

		public Bytes buffer;

		public int pos;

		public Adler32 crc;

		static Window()
		{
		}

		public Window(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Window(bool hasCrc)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_zip__InflateImpl_Window(Window __hx_this, bool hasCrc)
		{
		}

		public virtual void slide()
		{
		}

		public virtual void addBytes(Bytes b, int p, int len)
		{
		}

		public virtual void addByte(int c)
		{
		}

		public virtual int getLastChar()
		{
			return 0;
		}

		public virtual int available()
		{
			return 0;
		}

		public virtual Adler32 checksum()
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
