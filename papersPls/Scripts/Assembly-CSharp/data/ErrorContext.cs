using haxe.ds;
using haxe.lang;

namespace data
{
	public class ErrorContext : HxObject
	{
		public List paperIds;

		public StringMap data;

		public List ignoreGroupIds;

		public ErrorContext(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ErrorContext(List paperIds_, StringMap data_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_ErrorContext(ErrorContext __hx_this, List paperIds_, StringMap data_)
		{
		}

		public virtual string expandExpressionLhs(string lhs)
		{
			return null;
		}

		public virtual void addToFilter(string str)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
