using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.screen
{
	public class Confirm : Ent
	{
		public static double kButtonSpacingY;

		public static double kButtonHeight;

		public Fill backFill;

		public Frame boxFrame;

		public Text messageTextField;

		public Array buttons;

		public Array options;

		public Function whenClick;

		public PointData defaultSize;

		static Confirm()
		{
		}

		public Confirm(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Confirm(Ent parent)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_Confirm(Confirm __hx_this, Ent parent)
		{
		}

		public virtual void show(Function whenClick_, string message, Array options_)
		{
		}

		public virtual void button_onClick(Button b)
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
