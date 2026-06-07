using haxe.lang;

namespace app.vis
{
	public class Fill : Visual
	{
		public Tile tile;

		public Fill(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Fill(ColorData color_, object width_, object height_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Fill(Fill __hx_this, ColorData color_, object width_, object height_)
		{
		}

		public ColorData get_color()
		{
			return null;
		}

		public ColorData set_color(ColorData v)
		{
			return null;
		}

		public float get_alpha()
		{
			return 0f;
		}

		public double set_alpha(double v)
		{
			return 0.0;
		}

		public virtual void setPosAndSizeFrom(Fill src)
		{
		}

		public virtual void setSize(double width, double height)
		{
		}

		public virtual Fill setRect(Rect r)
		{
			return null;
		}

		public override double width()
		{
			return 0.0;
		}

		public override double height()
		{
			return 0.0;
		}

		public override void buildTiles()
		{
		}

		public override bool willDraw()
		{
			return false;
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
