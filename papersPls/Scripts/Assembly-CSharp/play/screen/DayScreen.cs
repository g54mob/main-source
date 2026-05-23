using app.ent;
using haxe.lang;
using play.day;
using play.day.booth;
using play.day.border;
using play.stash;

namespace play.screen
{
	public class DayScreen : GameScreen
	{
		public Day day;

		public Border border;

		public Booth booth;

		public Tutor tutor;

		public DayScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DayScreen(Ent parent, BoothEnvRun boothEnvRun, Day day_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_DayScreen(DayScreen __hx_this, Ent parent, BoothEnvRun boothEnvRun, Day day_)
		{
		}

		public virtual StashedDayScreen makeStash()
		{
			return null;
		}

		public override bool restoreFromStash(StashedGame stashedGame)
		{
			return false;
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
