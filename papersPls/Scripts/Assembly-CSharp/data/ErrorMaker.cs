using app;
using haxe.ds;
using haxe.lang;

namespace data
{
	public class ErrorMaker : HxObject
	{
		public Rand rand;

		public ErrorLib errorLib;

		public List recentErrorGroupIds;

		public ErrorMaker(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ErrorMaker(Rand rand_, ErrorLib errorLib_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_ErrorMaker(ErrorMaker __hx_this, Rand rand_, ErrorLib errorLib_)
		{
		}

		public virtual Error makeError(string errorIdPatterns, ErrorContext context)
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
