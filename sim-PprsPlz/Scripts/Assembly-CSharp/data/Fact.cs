using haxe.lang;

namespace data
{
	public class Fact : HxObject
	{
		public string path;

		public FactValue value;

		public Fact(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Fact(string path_, FactValue value_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Fact(Fact __hx_this, string path_, FactValue value_)
		{
		}

		public static string getPaperId(string path)
		{
			return null;
		}

		public static string getFactId(string path)
		{
			return null;
		}

		public static string join(string paperId, string factId)
		{
			return null;
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual Fact clone()
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

		public override string ToString()
		{
			return null;
		}
	}
}
