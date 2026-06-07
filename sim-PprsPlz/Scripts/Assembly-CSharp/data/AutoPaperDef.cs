using haxe.lang;

namespace data
{
	public class AutoPaperDef : HxObject
	{
		public string id;

		public string rule;

		public Array purposeIds;

		public AutoPaperDef(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoPaperDef(Xml node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_AutoPaperDef(AutoPaperDef __hx_this, Xml node)
		{
		}

		public virtual bool getMatches(string purpose, string rules)
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
