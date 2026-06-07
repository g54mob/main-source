using haxe.ds;
using haxe.lang;

namespace data
{
	public class NightLib : HxObject
	{
		public StringMap events;

		public NightLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NightLib(Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_NightLib(NightLib __hx_this, Res res)
		{
		}

		public virtual NightEvent findEvent(string id)
		{
			return null;
		}

		public virtual bool hasEvent(string id)
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
