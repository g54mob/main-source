using haxe.lang;

namespace test.auto
{
	public class AutoQueue : HxObject
	{
		public bool aborted;

		public AutoEnv env;

		public AutoInput autoInput;

		public object cur;

		public Array steps;

		public Array queueing;

		public AutoQueue(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoQueue(AutoEnv env_, AutoInput autoInput_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoQueue(AutoQueue __hx_this, AutoEnv env_, AutoInput autoInput_)
		{
		}

		public virtual void queue(object step)
		{
		}

		public virtual void abort()
		{
		}

		public virtual void clearSteps()
		{
		}

		public virtual void runStepBasic(AutoStepBasic step)
		{
		}

		public virtual void runStep(object step)
		{
		}

		public virtual bool runNextStep()
		{
			return false;
		}

		public virtual bool isDone()
		{
			return false;
		}

		public virtual Array status()
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
