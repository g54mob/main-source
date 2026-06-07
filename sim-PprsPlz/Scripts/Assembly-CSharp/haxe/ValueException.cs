using haxe.lang;

namespace haxe
{
	public class ValueException : Exception
	{
		public object value;

		public ValueException(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ValueException(object value, Exception previous, object native)
			: base(default(EmptyObject))
		{
		}

		public override object unwrap()
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
