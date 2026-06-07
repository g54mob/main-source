using app.ent;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class RevealTextEnt : Ent
	{
		public static Array kLongDelayCharCodes;

		public static Array kShortDelayCharCodes;

		public bool visible;

		public Text label;

		public int revealIndex;

		public int revealCount;

		public double revealCountdown;

		static RevealTextEnt()
		{
		}

		public RevealTextEnt(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public RevealTextEnt(Ent parent_, string fontName)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_RevealTextEnt(RevealTextEnt __hx_this, Ent parent_, string fontName)
		{
		}

		public string get_text()
		{
			return null;
		}

		public uint get_color()
		{
			return 0u;
		}

		public uint set_color(uint v)
		{
			return 0u;
		}

		public bool get_multiLine()
		{
			return false;
		}

		public bool set_multiLine(bool v)
		{
			return false;
		}

		public bool get_wordWrap()
		{
			return false;
		}

		public bool set_wordWrap(bool v)
		{
			return false;
		}

		public int get_fixedWidth()
		{
			return 0;
		}

		public int set_fixedWidth(int v)
		{
			return 0;
		}

		public double set_capY(double c)
		{
			return 0.0;
		}

		public double get_capY()
		{
			return 0.0;
		}

		public app.vis.Align get_align()
		{
			return null;
		}

		public app.vis.Align set_align(app.vis.Align v)
		{
			return null;
		}

		public double get_bottomY()
		{
			return 0.0;
		}

		public double set_bottomY(double v)
		{
			return 0.0;
		}

		public virtual string set_text(string text_)
		{
			return null;
		}

		public virtual void revealAll()
		{
		}

		public virtual bool stepReveal()
		{
			return false;
		}

		public virtual bool isFullyRevealed()
		{
			return false;
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
