using haxe.lang;

namespace data.loc
{
	public class CsvEntry : HxObject, Entry, IHxObject
	{
		public Display display;

		public CsvTable csv;

		public string colId;

		public string rowId;

		public CsvEntry(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CsvEntry(CsvTable csv_, string colId_, string rowId_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_loc_CsvEntry(CsvEntry __hx_this, CsvTable csv_, string colId_, string rowId_)
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
