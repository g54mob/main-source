using haxe.ds;
using haxe.io;
using haxe.lang;

namespace haxe.zip
{
	public class Reader : HxObject
	{
		public Input i;

		public Reader(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Reader(Input i)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_zip_Reader(Reader __hx_this, Input i)
		{
		}

		public static List readZip(Input i)
		{
			return null;
		}

		public static Bytes unzip(object f)
		{
			return null;
		}

		public virtual Date readZipDate()
		{
			return null;
		}

		public virtual List readExtraFields(int length)
		{
			return null;
		}

		public virtual object readEntryHeader()
		{
			return null;
		}

		public virtual List read()
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
