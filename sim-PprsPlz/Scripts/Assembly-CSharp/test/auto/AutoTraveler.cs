using haxe.ds;
using haxe.lang;
using play.day;

namespace test.auto
{
	public class AutoTraveler : AutoQueue_test_auto_AutoStepTraveler
	{
		public StringMap pageExploreHistory;

		public bool wantCaptureThisFrame;

		public Traveler traveler;

		public int travelerNum;

		public bool busyWithBorder;

		public Array manualSteps;

		public Array interrogatedFactPathPairs;

		public string dontGiveDeskItemId;

		public AutoAudit audit;

		public List pendingAuditKinds;

		public Array auditSavedPaperInnerImageIds;

		public AutoTraveler(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoTraveler(AutoEnv env_, AutoInput autoInput_, StringMap pageExploreHistory_, AutoAudit audit_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoTraveler(AutoTraveler __hx_this, AutoEnv env_, AutoInput autoInput_, StringMap pageExploreHistory_, AutoAudit audit_)
		{
		}

		public virtual string toString()
		{
			return null;
		}

		public override void runStep(AutoStepTraveler step)
		{
		}

		public virtual void auditSavePaperInnerImages()
		{
		}

		public override Array status()
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
