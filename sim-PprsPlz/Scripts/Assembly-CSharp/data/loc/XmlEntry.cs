using haxe.lang;

namespace data.loc
{
	public class XmlEntry : HxObject, Entry, IHxObject
	{
		public Display display;

		public Xml xml;

		public string attr;

		public XmlEntry(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public XmlEntry(Xml xml_, string attr_, Display display_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_loc_XmlEntry(XmlEntry __hx_this, Xml xml_, string attr_, Display display_)
		{
		}

		public Display get_display()
		{
			return null;
		}

		public string get_text()
		{
			return null;
		}

		public string set_text(string text)
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
