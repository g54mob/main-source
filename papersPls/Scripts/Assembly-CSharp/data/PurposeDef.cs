using haxe.lang;

namespace data
{
	public class PurposeDef : HxObject
	{
		public string id;

		public string rule;

		public double chance;

		public Array nations;

		public bool chooseForInvalid;

		public PurposeDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PurposeDef(Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_PurposeDef(PurposeDef __hx_this, Xml node)
		{
		}

		public virtual bool getMatches(string nation, string rules)
		{
			return false;
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
