using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class UnlockConfirm : Ent
	{
		public static double kPadding;

		public static double kButtonSpacingY;

		public static double kButtonHeight;

		public static double kNumpadSpacing;

		public static int kNumPadTop;

		public Fill backFill;

		public Sprite boxSprite;

		public Text messageTextField;

		public Text codeTextField;

		public Array buttons;

		public Function whenDone;

		public string code;

		public string builtCode;

		public Array visuals;

		static UnlockConfirm()
		{
		}

		public UnlockConfirm(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public UnlockConfirm(Ent parent, string message, string code_, Function whenDone_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_UnlockConfirm(UnlockConfirm __hx_this, Ent parent, string message, string code_, Function whenDone_)
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

		public virtual void tween_flash(double t)
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
