using app.ent;
using app.vis;
using haxe.lang;
using play.stash;
using play.ui;

namespace play.screen
{
	public class GameScreen : Ent
	{
		public static int kPushButtonWidth;

		public string songId;

		public Button pauseButton;

		public bool haveAddedPauseButton;

		public bool canPause_;

		public ScreenShake screenShake;

		public Array visuals;

		static GameScreen()
		{
		}

		public GameScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public GameScreen(Ent parent_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_GameScreen(GameScreen __hx_this, Ent parent_)
		{
		}

		public static Button makePushButton(Ent parent, string text, app.vis.Align align, object red)
		{
			return null;
		}

		public static void shake(Ent ent, double duration, double magnitude)
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual double addHeader(string title)
		{
			return 0.0;
		}

		public virtual void addMediaButtons(Menu menu)
		{
		}

		public virtual bool restoreFromStash(StashedGame stashedGame)
		{
			return false;
		}

		public virtual bool get_canPause()
		{
			return false;
		}

		public virtual void enablePause(object blackColor)
		{
		}

		public virtual void pauseButton_onClick(Button button)
		{
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
