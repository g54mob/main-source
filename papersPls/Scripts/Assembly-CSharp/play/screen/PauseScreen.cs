using app.ent;
using haxe.lang;

namespace play.screen
{
	public class PauseScreen : GameScreen
	{
		public Menu menu;

		public SettingsMenu settingsMenu;

		public Confirm confirm;

		public PauseScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PauseScreen(Ent parent)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_PauseScreen(PauseScreen __hx_this, Ent parent)
		{
		}

		public virtual void showConfirm(string id, string text)
		{
		}

		public virtual void menu_onClick(string id)
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
