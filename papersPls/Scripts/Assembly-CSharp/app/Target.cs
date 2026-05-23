using haxe.lang;

namespace app
{
	public class Target : HxObject
	{
		public object targetObj;

		public Array propNames;

		public Array propValues;

		public Target(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Target(Target src)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Target(Target __hx_this, Target src)
		{
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
