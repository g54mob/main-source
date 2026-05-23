using app.ent;
using app.plat;
using app.vis;
using haxe.lang;

namespace play.screen
{
	public class SettingsMenu : Ent
	{
		public SettingRow fullscreenRow;

		public SettingRow nudityRow;

		public SettingRow musicRow;

		public SettingRow soundRow;

		public SettingRow easyModeRow;

		public SettingRow dateFormatRow;

		public SettingRow vibrationRow;

		public SettingRow ratingRow;

		public Text easyModeTipTextField;

		public Text dateFormatTextField;

		public SettingRow langRow;

		public Text langTextField;

		public SettingRow platformRow;

		public Confirm confirm;

		public double totalWidth;

		public double totalHeight;

		public double easyModeTipHideTime;

		public Array availableLanguageCodes;

		public PlatformChangeConfirm platformChangeConfirm;

		public SettingDim dim;

		public uint settingsGeneration;

		public SettingsMenu(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SettingsMenu(Ent parent, SettingsMenuPurpose purpose)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_SettingsMenu(SettingsMenu __hx_this, Ent parent, SettingsMenuPurpose purpose)
		{
		}

		public virtual void musicButton_whenClick(string name)
		{
		}

		public virtual void soundButton_whenClick(string name)
		{
		}

		public virtual void musicButton_whenClickVolumeBar(double v)
		{
		}

		public virtual void soundButton_whenClickVolumeBar(double v)
		{
		}

		public virtual void dateButton_whenClick(string name)
		{
		}

		public virtual void langButton_whenClickPlusMinus(string name)
		{
		}

		public virtual void langButton_whenClickChooser(string name)
		{
		}

		public virtual void fullscreenButton_onClick(string name)
		{
		}

		public virtual void nudityButton_onClick(string name)
		{
		}

		public virtual void easyModeButton_onClick(string name)
		{
		}

		public virtual void vibrationButton_whenClick(string name)
		{
		}

		public virtual void platformButton_whenClick(string name)
		{
		}

		public virtual void platformChangeConfirm_onDone(PlatformKind result)
		{
		}

		public virtual void ratingButton_whenClick(string name)
		{
		}

		public override void update()
		{
		}

		public virtual void updateDateFormatText()
		{
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
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
