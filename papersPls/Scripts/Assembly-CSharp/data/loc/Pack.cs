using haxe.ds;
using haxe.io;
using haxe.lang;

namespace data.loc
{
	public class Pack : HxObject
	{
		public static EReg enKeyRegex0;

		public static EReg enKeyRegex1;

		public static StringMap htmlEnts;

		public StringMap files;

		public StringMap strings;

		public Array loadFuncs;

		public string curLanguageCode;

		public int curLocVersion;

		static Pack()
		{
		}

		public Pack(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Pack()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_loc_Pack(Pack __hx_this)
		{
		}

		public static Pack load(Bytes zipfileBytes)
		{
			return null;
		}

		public static void log(string str)
		{
		}

		public static string cleanHtml(string str)
		{
			return null;
		}

		public virtual void loadInternal(Bytes zipfileBytes)
		{
		}

		public virtual void localizeCsv(CsvTable csvTable, string filename)
		{
		}

		public virtual void localizeXml(Xml xml, string filename)
		{
		}

		public virtual void localizeTab(TabParser tabParser, string filename)
		{
		}

		public virtual string localizeFromAnyContext(string str)
		{
			return null;
		}

		public virtual void localize(string context, Entry entry)
		{
		}

		public virtual int makeEnKey(string str)
		{
			return 0;
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
