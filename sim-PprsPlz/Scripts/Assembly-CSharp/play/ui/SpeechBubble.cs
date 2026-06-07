using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class SpeechBubble : Ent
	{
		public static int kPadding;

		public static double kLineHeight;

		public bool visible;

		public Align align;

		public Text label;

		public Stater stater;

		public Frame frame;

		public DottedLine dottedLine;

		public bool stayOpen;

		public double boxL;

		public double boxR;

		public double revealT;

		static SpeechBubble()
		{
		}

		public SpeechBubble(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SpeechBubble(Ent parent_, object stayOpen_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_SpeechBubble(SpeechBubble __hx_this, Ent parent_, object stayOpen_)
		{
		}

		public double get_originOffsetY()
		{
			return 0.0;
		}

		public virtual double get_totalHeight()
		{
			return 0.0;
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
		{
		}

		public virtual void cancelAndHide()
		{
		}

		public virtual Align set_align(Align a)
		{
			return null;
		}

		public virtual double showText(string text, object delay)
		{
			return 0.0;
		}

		public virtual void setDottedLineVisibleT(double t)
		{
		}

		public virtual void setBoxReveal(double widthT, double bounceT)
		{
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
