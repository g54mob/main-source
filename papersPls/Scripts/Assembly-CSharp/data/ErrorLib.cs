using haxe.ds;
using haxe.lang;

namespace data
{
	public class ErrorLib : HxObject
	{
		public List randomErrors;

		public List alwaysErrors;

		public ErrorLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ErrorLib(Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_ErrorLib(ErrorLib __hx_this, Res res)
		{
		}

		public virtual void validateAll(Db db)
		{
		}

		public virtual Array getErrorsForContext(string errorIdPatterns, ErrorContext context)
		{
			return null;
		}

		public virtual Array getAlwaysErrorsForContext(ErrorContext context)
		{
			return null;
		}

		public virtual Error findError(string errorId)
		{
			return null;
		}

		public virtual List debugGetErrrors()
		{
			return null;
		}

		public virtual List getMatchingErrors(string errorIdPatterns)
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
