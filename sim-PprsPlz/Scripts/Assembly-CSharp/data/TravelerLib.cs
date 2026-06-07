using haxe.lang;

namespace data
{
	public class TravelerLib : HxObject
	{
		public Node rootNode;

		public Node defaultNode;

		public TravelerLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TravelerLib(Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_TravelerLib(TravelerLib __hx_this, Res res)
		{
		}

		public virtual Node findTravelerNode(string travelerId)
		{
			return null;
		}

		public virtual Node getRootNode()
		{
			return null;
		}

		public virtual Node getDefaultNode()
		{
			return null;
		}

		public virtual Array getAllTravelerIds()
		{
			return null;
		}

		public virtual Array getAllConditionalSolutions()
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
