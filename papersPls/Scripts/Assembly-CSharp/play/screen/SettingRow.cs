using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class SettingRow : Ent
	{
		public double volumePerc;

		public Array visuals;

		public Function whenClick;

		public Function whenClickVolumeBar;

		public SettingDim dim;

		public Fill volumePercFill;

		public double volumePercMaxWidth;

		public Button checkboxButton;

		public Button platformButton;

		public Button ratingButton;

		public Text titleText;

		public double _height;

		public SettingRow(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SettingRow(Ent parent, SettingDim dim_, string title, Function whenClick_, Function whenClickVolumeBar_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_SettingRow(SettingRow __hx_this, Ent parent, SettingDim dim_, string title, Function whenClick_, Function whenClickVolumeBar_)
		{
		}

		public virtual void buttonWhenClick(Button b)
		{
		}

		public virtual bool set_checkboxOn(bool v)
		{
			return false;
		}

		public virtual string set_layoutModeName(string v)
		{
			return null;
		}

		public virtual void addCheckboxButton()
		{
		}

		public virtual void addPlusMinusButtons()
		{
		}

		public virtual Array makeModeImages(Image iconImage, object widthInColumns, object internalPadding)
		{
			return null;
		}

		public virtual void addPlatformButton()
		{
		}

		public virtual void addLanguageButton()
		{
		}

		public virtual void addVolumeBar()
		{
		}

		public virtual void addRatingButton(Image image)
		{
		}

		public virtual void addVisual(Visual visual, object affectHeight)
		{
		}

		public virtual void splitOntoTwoLinesIfNecessary()
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
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
