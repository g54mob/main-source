using app;
using app.ent;
using app.vis;
using data;
using haxe.lang;
using play.stash;
using play.ui;

namespace play.screen
{
	public class EndScreen : GameScreen
	{
		public static int kTextWidth;

		public Menu menu;

		public Intro intro;

		public Button mainMenuButton;

		public Text statsTextField;

		public Stater stater;

		public Fill fadeFill;

		public string endId;

		static EndScreen()
		{
		}

		public EndScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EndScreen(Ent parent, AlltimeStats alltimeStats, FactSet storyFacts, string endId_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_EndScreen(EndScreen __hx_this, Ent parent, AlltimeStats alltimeStats, FactSet storyFacts, string endId_)
		{
		}

		public virtual string get_statsText()
		{
			return null;
		}

		public override void update()
		{
		}

		public virtual void intro_onDone()
		{
		}

		public virtual void menu_onClick(string id)
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
