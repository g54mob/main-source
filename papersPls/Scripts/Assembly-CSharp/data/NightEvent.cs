using haxe.lang;

namespace data
{
	public class NightEvent : HxObject
	{
		public string id;

		public Array ops;

		public NightEvent(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NightEvent(string id_, Op rootOp)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_NightEvent(NightEvent __hx_this, string id_, Op rootOp)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
