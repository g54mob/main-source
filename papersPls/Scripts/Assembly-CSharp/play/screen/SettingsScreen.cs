using app.ent;
using app.vis;
using haxe.lang;

namespace play.screen
{
	public class SettingsScreen : GameScreen
	{
		public Menu menu;

		public SettingsMenu settingsMenu;

		public Text versionTextField;

		public SettingsScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SettingsScreen(Ent parent, string decoratedVersion, Array availableLanguageCodes, bool allowPhoneTabletPlatformChange)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_SettingsScreen(SettingsScreen __hx_this, Ent parent, string decoratedVersion, Array availableLanguageCodes, bool allowPhoneTabletPlatformChange)
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
