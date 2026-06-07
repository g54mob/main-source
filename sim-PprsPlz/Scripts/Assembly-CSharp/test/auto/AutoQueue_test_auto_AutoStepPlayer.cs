using haxe.lang;

namespace test.auto
{
	public class AutoQueue_test_auto_AutoStepPlayer : HxObject
	{
		public bool aborted;

		public AutoEnv env;

		public AutoInput autoInput;

		public AutoStepPlayer cur;

		public Array steps;

		public Array queueing;

		public AutoQueue_test_auto_AutoStepPlayer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoQueue_test_auto_AutoStepPlayer(AutoEnv env_, AutoInput autoInput_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoQueue_test_auto_AutoStepPlayer(AutoQueue_test_auto_AutoStepPlayer __hx_this, AutoEnv env_, AutoInput autoInput_)
		{
		}

		public virtual void queue(AutoStepPlayer step)
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

		public virtual void runStep(AutoStepPlayer step)
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
