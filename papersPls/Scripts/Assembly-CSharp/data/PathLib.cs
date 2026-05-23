using app;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class PathLib : HxObject
	{
		public Rand rand;

		public StringMap pathHash;

		public StringMap animHash;

		public PathLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PathLib(Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_PathLib(PathLib __hx_this, Res res)
		{
		}

		public virtual Path createPath(Rand rand, string id)
		{
			return null;
		}

		public virtual bool hasPath(string id)
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
