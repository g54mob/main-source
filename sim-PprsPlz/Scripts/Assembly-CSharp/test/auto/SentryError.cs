using haxe.lang;

namespace test.auto
{
	public class SentryError : HxObject
	{
		public string routeId;

		public int dayId;

		public int travelerNum;

		public string travelerId;

		public string message;

		public SentryError(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SentryError(string routeId, int dayId, int travelerNum, string travelerId, string message)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_SentryError(SentryError __hx_this, string routeId, int dayId, int travelerNum, string travelerId, string message)
		{
		}

		public virtual string toString()
		{
			return null;
		}

		public virtual bool equals(SentryError other)
		{
			return false;
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
