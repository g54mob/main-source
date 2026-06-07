using app;
using app.aud;
using data;
using haxe.ds;
using haxe.lang;

namespace play.day
{
	public class Endless : HxObject
	{
		public EndlessId id;

		public Clock clock;

		public EndlessCourse course;

		public EndlessStyle style;

		public Function whenNotifyScoreboard;

		public int score;

		public int scoreMax;

		public int randomSeed;

		public bool running;

		public double endCountdown;

		public StringMap actionCounts;

		public Speaker speaker;

		public AlltimeStats alltimeStats;

		public GameTransition gameTransition;

		public Endless(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Endless(Speaker speaker_, AlltimeStats alltimeStats_, GameTransition gameTransition_, EndlessLib endlessLib, EndlessId id_, int randomSeed_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_Endless(Endless __hx_this, Speaker speaker_, AlltimeStats alltimeStats_, GameTransition gameTransition_, EndlessLib endlessLib, EndlessId id_, int randomSeed_)
		{
		}

		public bool get_isEnding()
		{
			return false;
		}

		public virtual void start()
		{
		}

		public virtual void update()
		{
		}

		public virtual void handleAction(string actionId)
		{
		}

		public virtual void queEnd()
		{
		}

		public virtual void end(object fromMenu)
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

		public override object __hx_invokeField(string field, int hash, object[] dynargs)
		{
			return null;
		}

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
