using haxe.lang;

namespace data.loc
{
	public class CsvExtractor : HxObject
	{
		public string filename;

		public string contextPrefix;

		public bool twoPages;

		public CsvExtractor(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CsvExtractor(string filename_, string contextPrefix_, bool twoPages_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_loc_CsvExtractor(CsvExtractor __hx_this, string filename_, string contextPrefix_, bool twoPages_)
		{
		}

		public virtual void run(CsvTable csv, Function extractedFunc)
		{
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
