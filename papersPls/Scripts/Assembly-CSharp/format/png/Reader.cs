using haxe.ds;
using haxe.io;
using haxe.lang;

namespace format.png
{
	public class Reader : HxObject
	{
		public Input i;

		public bool checkCRC;

		public Reader(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Reader(Input i)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_format_png_Reader(Reader __hx_this, Input i)
		{
		}

		public virtual List read()
		{
			return null;
		}

		public virtual object readHeader(Input i)
		{
			return null;
		}

		public virtual Chunk readChunk()
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
