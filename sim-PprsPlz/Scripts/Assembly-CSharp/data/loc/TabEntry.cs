using haxe.lang;

namespace data.loc
{
	public class TabEntry : HxObject, Entry, IHxObject
	{
		public Display display;

		public Node node;

		public int posParam;

		public int endParam;

		public bool quoted;

		public TabEntry(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TabEntry(Node node_, int posParam_, object endParam_, object quoted_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_loc_TabEntry(TabEntry __hx_this, Node node_, int posParam_, object endParam_, object quoted_)
		{
		}

		public TabEntry setDisplay(Display d)
		{
			return null;
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
