using haxe.lang;

namespace haxe.xml
{
	public class Printer : HxObject
	{
		public StringBuf output;

		public bool pretty;

		public Printer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Printer(bool pretty)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_xml_Printer(Printer __hx_this, bool pretty)
		{
		}

		public static string print(Xml xml, object pretty)
		{
			return null;
		}

		public virtual void writeNode(Xml value, string tabs)
		{
		}

		public void write(string input)
		{
		}

		public void newline()
		{
		}

		public virtual bool hasChildren(Xml value)
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
