using app.ent;
using haxe.ds;
using haxe.lang;
using play;
using play.screen;

namespace test.auto
{
	public class AutoPlayer : AutoQueue_test_auto_AutoStepPlayer
	{
		public static Array kEndButtonIds;

		public EndReport endReport;

		public bool paused;

		public AutoAudit audit;

		public StringMap initialPageExploreHistory;

		public object fastForwardStop;

		public Bootstrap bootstrap;

		public ScreenFlash screenFlash;

		public bool wantCaptureThisFrame;

		public CaptureWorker captureWorker;

		public int stashGeneration;

		public bool monitorStashGeneration;

		public StringMap startingFacts;

		public bool wantApplyStartingFacts;

		static AutoPlayer()
		{
		}

		public AutoPlayer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoPlayer(Bootstrap bootstrap_, ScreenFlash screenFlash_, AutoRoute autoRoute, AutoPlan autoPlan)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoPlayer(AutoPlayer __hx_this, Bootstrap bootstrap_, ScreenFlash screenFlash_, AutoRoute autoRoute, AutoPlan autoPlan)
		{
		}

		public override void abort()
		{
		}

		public virtual Input stepAndGetInput(Input inputFromHost)
		{
			return null;
		}

		public virtual bool wantFastForward()
		{
			return false;
		}

		public virtual void draw(Drawer drawer)
		{
		}

		public virtual void checkCapture()
		{
		}

		public override void runStep(AutoStepPlayer step)
		{
		}

		public virtual void applyStartingFacts()
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
	}
}
