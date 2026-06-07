using haxe.lang;

namespace data
{
	public class EndLib : HxObject
	{
		public Xml xmlRoot;

		public Array introPages;

		public EndLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndLib(Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_EndLib(EndLib __hx_this, Res res)
		{
		}

		public virtual Xml getEndNode(string id)
		{
			return null;
		}

		public virtual int getEndNum(string id)
		{
			return 0;
		}

		public virtual Array getEndIds()
		{
			return null;
		}

		public virtual Array getIntroPages()
		{
			return null;
		}

		public virtual Array getEndPages(string endId)
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
