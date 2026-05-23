using haxe.lang;

namespace test.auto
{
	public class EndReport : HxObject
	{
		public int endNum;

		public string routeId;

		public Date startDate;

		public double totalSeconds;

		public int randomSeed;

		public double memUsage;

		public Array factLines;

		public string statsText;

		public Array sentryErrors;

		public EndReport(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndReport(int endNum, string routeId, Date startDate, double totalSeconds, int randomSeed, double memUsage, Array factLines, string statsText, Array sentryErrors)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_EndReport(EndReport __hx_this, int endNum, string routeId, Date startDate, double totalSeconds, int randomSeed, double memUsage, Array factLines, string statsText, Array sentryErrors)
		{
		}

		public virtual string toString()
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
