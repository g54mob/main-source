using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class PlatformChangeConfirm : Ent
	{
		public static double kPadding;

		public static int kSelectionSpacingY;

		public static int kButtonWL;

		public static int kButtonWR;

		public static int kButtonSpacingX;

		public static int kBoxHeight;

		public Fill backFill;

		public Frame boxFrame;

		public Button phoneButton;

		public Button tabletButton;

		public Fill selectedFill;

		public Function whenDone;

		public string builtCode;

		public Array buttons;

		public Array visuals;

		static PlatformChangeConfirm()
		{
		}

		public PlatformChangeConfirm(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformChangeConfirm(Ent parent, Function whenDone_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_PlatformChangeConfirm(PlatformChangeConfirm __hx_this, Ent parent, Function whenDone_)
		{
		}

		public virtual void show()
		{
		}

		public override void react(Input input)
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void button_onClick(Button b)
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
