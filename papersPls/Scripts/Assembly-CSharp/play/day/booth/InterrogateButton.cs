using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class InterrogateButton : Ent
	{
		public static int kCornerRadius;

		public static uint kLineColor;

		public string id;

		public double revealT;

		public bool visible;

		public bool enabled;

		public Function whenClick;

		public Array lines;

		public Text textField;

		public Sprite fillSprite;

		public double textWidth;

		public bool centerText;

		public double _width;

		public double _height;

		public double clickedTime;

		static InterrogateButton()
		{
		}

		public InterrogateButton(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public InterrogateButton(Ent parent_, Rect rect, string text, string id_, bool centerText_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_InterrogateButton(InterrogateButton __hx_this, Ent parent_, Rect rect, string text, string id_, bool centerText_)
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

		public virtual double set_revealT(double t)
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
