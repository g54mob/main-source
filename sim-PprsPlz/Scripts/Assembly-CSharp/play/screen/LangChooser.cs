using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class LangChooser : Ent
	{
		public static int kSelectionLineW;

		public static int kBoxPadding;

		public static int kScreenPadding;

		public static int kButtonPaddingY;

		public static int kFooterSpacingY;

		public Menu menu;

		public Frame boxFrame;

		public Fill backFill;

		public Array langCodes;

		public int applyFrameCountdown;

		public string applyLangCode;

		public Sprite waitSprite;

		public Fill waitFill;

		public Image langsImage;

		public int langItemW;

		public int langItemH;

		public Image normalImage;

		public Image selectedImage;

		public Image pressedImage;

		public int numButtonsPerPage;

		public int numPages;

		public int page;

		public Button nextButton;

		public Button cancelButton;

		public Array langButtons;

		public Rect buttonListRect;

		static LangChooser()
		{
		}

		public LangChooser(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public LangChooser(Ent parent)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_LangChooser(LangChooser __hx_this, Ent parent)
		{
		}

		public static bool hasUserAddedLanguages(Res res, Array availableLanguageCodes)
		{
			return false;
		}

		public virtual void setPage(int page_)
		{
		}

		public virtual void button_whenClick(Button button)
		{
		}

		public virtual void menu_whenClick(string id)
		{
		}

		public virtual void deactivateAllButtons()
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public override void react(Input input)
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
