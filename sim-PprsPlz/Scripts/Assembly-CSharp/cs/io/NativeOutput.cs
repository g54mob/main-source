using System.IO;
using haxe.io;
using haxe.lang;
using sys.io;

namespace cs.io
{
	public class NativeOutput : Output
	{
		public Stream stream;

		public NativeOutput(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NativeOutput(Stream stream)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_cs_io_NativeOutput(NativeOutput __hx_this, Stream stream)
		{
		}

		public override void writeByte(int c)
		{
		}

		public override void close()
		{
		}

		public override void flush()
		{
		}

		public override void prepare(int nbytes)
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
