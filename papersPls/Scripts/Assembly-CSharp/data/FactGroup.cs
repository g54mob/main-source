using haxe.lang;

namespace data
{
	public class FactGroup : HxObject
	{
		public string id;

		public Array paths;

		public FactGroup(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public FactGroup(string id_, Array paths_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_FactGroup(FactGroup __hx_this, string id_, Array paths_)
		{
		}

		public virtual bool hasPath(string path)
		{
			return false;
		}

		public virtual string getProxiedPath(string path)
		{
			return null;
		}

		public virtual Array autoGetCorrelationPairs(string path)
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
