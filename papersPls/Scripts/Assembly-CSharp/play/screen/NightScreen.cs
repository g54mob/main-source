using app.ent;
using haxe.lang;
using play.day;
using play.night;
using play.night.ent;
using play.stash;

namespace play.screen
{
	public class NightScreen : GameScreen
	{
		public Day day;

		public BudgetEnt budgetEnt;

		public bool haveClickedSleep;

		public StoryState storyState;

		public NightScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NightScreen(Ent parent, AlltimeStats alltimeStats, StoryState storyState_, Day day_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_NightScreen(NightScreen __hx_this, Ent parent, AlltimeStats alltimeStats, StoryState storyState_, Day day_)
		{
		}

		public override void update()
		{
		}

		public virtual void onClickSleep(Family family)
		{
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
