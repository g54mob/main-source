using haxe.lang;

namespace haxe.ds
{
	public class EnumValueMap : BalancedTree, IMap, IHxObject
	{
		public EnumValueMap(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EnumValueMap()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_ds_EnumValueMap(EnumValueMap __hx_this)
		{
		}

		IMap IMap.copy()
		{
			return null;
		}

		public override int compare(object k1, object k2)
		{
			return 0;
		}

		public virtual int compareArgs(Array a1, Array a2)
		{
			return 0;
		}

		public virtual int compareArg(object v1, object v2)
		{
			return 0;
		}

		public override BalancedTree copy()
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
	}
}
