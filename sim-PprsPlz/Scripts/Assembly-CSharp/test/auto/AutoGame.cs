using app.ent;
using app.plat;
using app.vis;
using haxe.lang;

namespace test.auto
{
	public class AutoGame : HxObject, IGame, IHxObject
	{
		public Game game;

		public Platform platform;

		public AutoPlayer autoPlayer;

		public PlatformDiskMemWrapper memDisk;

		public Array playthroughs;

		public int playthroughIndex;

		public ProgressVisuals progressVisuals;

		public string auditDir;

		public string logFilepath;

		public AutoPlan autoPlan;

		public int slowCountup;

		public double startStamp;

		public string finalStatus;

		public AutoGame(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public AutoGame(GameParams gameParams, AutoPlan autoPlan_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_test_auto_AutoGame(AutoGame __hx_this, GameParams gameParams, AutoPlan autoPlan_)
		{
		}

		public virtual void advanceToNextPlaythrough()
		{
		}

		public virtual void log(string str)
		{
		}

		public virtual void logPlaythroughStarting(int index)
		{
		}

		public virtual void logPlaythroughFinished(Playthrough playthrough)
		{
		}

		public virtual void update(Input input)
		{
		}

		public virtual bool checkCapture()
		{
			return false;
		}

		public virtual QuadIter draw()
		{
			return null;
		}

		public virtual int width()
		{
			return 0;
		}

		public virtual int height()
		{
			return 0;
		}

		public virtual int subpixelCount()
		{
			return 0;
		}

		public virtual Image phantomCursorImage()
		{
			return null;
		}

		public virtual Image deviceTestMaskImage()
		{
			return null;
		}

		public virtual bool wantSoak()
		{
			return false;
		}

		public virtual PlatformKind wantPlatformKind()
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
