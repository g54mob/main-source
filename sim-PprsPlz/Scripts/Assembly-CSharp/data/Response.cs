using haxe.ds;
using haxe.lang;

namespace data
{
	public class Response : HxObject
	{
		public string id;

		public string factPath;

		public List says;

		public Response(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Response(Node node)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_Response(Response __hx_this, Node node)
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
