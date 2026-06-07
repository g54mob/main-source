using haxe.lang;

namespace haxe.exceptions
{
	public class PosException : Exception
	{
		public object posInfos;

		public PosException(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PosException(string message, Exception previous, object pos)
			: base(default(EmptyObject))
		{
		}

		public override string toString()
		{
			return null;
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
