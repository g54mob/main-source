using System.IO;
using haxe.io;
using haxe.lang;
using sys.io;

namespace cs.io
{
	public class NativeInput : Input
	{
		public Stream stream;

		public bool _eof;

		public NativeInput(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NativeInput(Stream stream)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_cs_io_NativeInput(NativeInput __hx_this, Stream stream)
		{
		}

		public override int readByte()
		{
			return 0;
		}

		public override int readBytes(Bytes s, int pos, int len)
		{
			return 0;
		}

		public override void close()
		{
		}

		public bool get_canSeek()
		{
			return false;
		}

		public virtual void seek(int p, FileSeek pos)
		{
		}

		public virtual int tell()
		{
			return 0;
		}

		public bool eof()
		{
			return false;
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
