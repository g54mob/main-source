using haxe.lang;

namespace data
{
	public class FactValue : HxObject
	{
		public string text;

		public TravelerName name;

		public double date;

		public string localizedText;

		public FactValue(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FactValue(string text_, TravelerName name_, object date_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FactValue(FactValue __hx_this, string text_, TravelerName name_, object date_)
		{
		}

		public static FactValue makeText(string text_, string localizedText_)
		{
			return null;
		}

		public static FactValue makeInt(int val)
		{
			return null;
		}

		public static FactValue makeFloat(double val)
		{
			return null;
		}

		public static FactValue makeName(string text_, TravelerName name_)
		{
			return null;
		}

		public static FactValue makeDate(string text_, double date_)
		{
			return null;
		}

		public static FactValue makeStringArray(Array array, string separator)
		{
			return null;
		}

		public bool isSet()
		{
			return false;
		}

		public FactValue setLocalizedText(string localizedText_)
		{
			return null;
		}

		public virtual string toString()
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

		public override string ToString()
		{
			return null;
		}
	}
}
