using app.aud;
using app.ent;
using app.plat;
using app.vis;
using data;
using haxe.lang;
using play.ui;
using test.auto;

namespace play.screen
{
	public class TitleScreen : GameScreen
	{
		public static int numInstancesCreated;

		public bool rising;

		public Ent container;

		public Menu menu;

		public Button quitButton;

		public Sprite titleSprite;

		public bool skipped;

		public Music music;

		public UnlockConfirm unlockConfirm;

		public Platform platform;

		public SoakTapper soakTapper;

		static TitleScreen()
		{
		}

		public TitleScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TitleScreen(Ent parent, Music music_, Platform platform_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_TitleScreen(TitleScreen __hx_this, Ent parent, Music music_, Platform platform_)
		{
		}

		public static string downloadUrl(Lang lang, Platform platform)
		{
			return null;
		}

		public override void update()
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void confirm_onClick(string id)
		{
		}

		public virtual void menu_onClick(string id)
		{
		}

		public virtual void unlockConfirm_onDone(bool unlocked)
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
