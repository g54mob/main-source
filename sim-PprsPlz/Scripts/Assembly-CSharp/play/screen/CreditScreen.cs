using app.ent;
using app.vis;
using haxe.lang;

namespace play.screen
{
	public class CreditScreen : GameScreen
	{
		public Menu menu;

		public double stopCountdown;

		public double scrollerY;

		public double kStopY;

		public bool fast;

		public Rect centerRect;

		public CreditList creditList;

		public double kStopWait;

		public CreditScreen(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CreditScreen(Ent parent, Array availableLanguageCodes)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_screen_CreditScreen(CreditScreen __hx_this, Ent parent, Array availableLanguageCodes)
		{
		}

		public virtual void menu_onClick(string id)
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
