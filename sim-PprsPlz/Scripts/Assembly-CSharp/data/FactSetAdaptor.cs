using haxe.lang;

namespace data
{
	public class FactSetAdaptor : HxObject
	{
		public FactSet facts;

		public string prefix;

		public FactSetAdaptor(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FactSetAdaptor(FactSet facts_, string prefix_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FactSetAdaptor(FactSetAdaptor __hx_this, FactSet facts_, string prefix_)
		{
		}

		public string getStr(string pathWithoutPrefix, string def)
		{
			return null;
		}

		public Fact setStr(string pathWithoutPrefix, string value)
		{
			return null;
		}

		public int getInt(string pathWithoutPrefix, object def)
		{
			return 0;
		}

		public Fact setInt(string pathWithoutPrefix, int value)
		{
			return null;
		}

		public double getFloat(string pathWithoutPrefix, object def)
		{
			return 0.0;
		}

		public Fact setFloat(string pathWithoutPrefix, double value)
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
