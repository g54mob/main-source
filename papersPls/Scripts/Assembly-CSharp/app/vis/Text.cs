using haxe.lang;

namespace app.vis
{
	public class Text : Visual
	{
		public string text;

		public Font font;

		public int paddingX;

		public int paddingY;

		public int lineSpacing;

		public bool wordWrap;

		public int fixedWidth;

		public bool multiLine;

		public uint color;

		public uint backgroundColor;

		public bool backgroundRounded;

		public Align align;

		public bool hyphenated;

		public bool wantBuiltLetters;

		public int generation;

		public int builtGeneration;

		public int builtWidth;

		public int builtHeight;

		public int backgroundTileCount;

		public Array builtLetters;

		public Text(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Text(Font font_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Text(Text __hx_this, Font font_)
		{
		}

		public virtual string set_text(string v)
		{
			return null;
		}

		public virtual Font set_font(Font v)
		{
			return null;
		}

		public virtual int set_paddingX(int v)
		{
			return 0;
		}

		public virtual int set_paddingY(int v)
		{
			return 0;
		}

		public virtual int set_lineSpacing(int v)
		{
			return 0;
		}

		public virtual bool set_wordWrap(bool v)
		{
			return false;
		}

		public virtual int set_fixedWidth(int v)
		{
			return 0;
		}

		public virtual bool set_multiLine(bool v)
		{
			return false;
		}

		public virtual uint set_color(uint v)
		{
			return 0u;
		}

		public virtual uint set_backgroundColor(uint v)
		{
			return 0u;
		}

		public virtual bool set_backgroundRounded(bool v)
		{
			return false;
		}

		public virtual Align set_align(Align v)
		{
			return null;
		}

		public bool get_hasText()
		{
			return false;
		}

		public bool get_hyphenated()
		{
			return false;
		}

		public double set_capY(double c)
		{
			return 0.0;
		}

		public double get_capY()
		{
			return 0.0;
		}

		public double set_baselineY(double b)
		{
			return 0.0;
		}

		public double get_baselineY()
		{
			return 0.0;
		}

		public double set_bottomY(double b)
		{
			return 0.0;
		}

		public double get_bottomY()
		{
			return 0.0;
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public override bool willDraw()
		{
			return false;
		}

		public override void buildTiles()
		{
		}

		public virtual Array getBuiltLetters()
		{
			return null;
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
