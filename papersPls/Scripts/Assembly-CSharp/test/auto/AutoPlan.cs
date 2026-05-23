using app;
using app.plat;
using haxe.ds;
using haxe.lang;

namespace test.auto
{
	public class AutoPlan : HxObject
	{
		public bool valid;

		public Array routeNums;

		public Array auditKinds;

		public int skipToDay;

		public int randomSeed;

		public object fastForwardStop;

		public StringMap facts;

		public bool traceEnabled;

		public bool testStash;

		public bool slow;

		public int captureEveryFrameCount;

		public AutoPlan(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoPlan()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoPlan(AutoPlan __hx_this)
		{
		}

		public static AutoPlan make(PlatformDisk platformDisk, CommandLine commandLine)
		{
			return null;
		}

		public static AutoPlan makeDefault()
		{
			return null;
		}

		public static int makeSeedForDay()
		{
			return 0;
		}

		public virtual AutoPlan setDefault()
		{
			return null;
		}

		public virtual AutoPlan setFromFile(string content)
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
	}
}
