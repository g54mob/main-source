using haxe.lang;

namespace app.vis
{
	public class Sprite : Visual
	{
		public PartData imagePart;

		public double scaleX;

		public double scaleY;

		public Tile tile;

		public Image affineBakedImage;

		public Sprite(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Sprite(PartData imagePart_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Sprite(Sprite __hx_this, PartData imagePart_)
		{
		}

		public PartData set_imagePart(PartData v)
		{
			return null;
		}

		public Image get_image()
		{
			return null;
		}

		public Image set_image(Image v)
		{
			return null;
		}

		public ColorData get_color()
		{
			return null;
		}

		public ColorData set_color(ColorData v)
		{
			return null;
		}

		public bool get_hasImage()
		{
			return false;
		}

		public double set_scaleX(double v)
		{
			return 0.0;
		}

		public double set_scaleY(double v)
		{
			return 0.0;
		}

		public double set_scale(double v)
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

		public override void buildTiles()
		{
		}

		public override bool willDraw()
		{
			return false;
		}

		public virtual void rebuild()
		{
		}

		public virtual void bakeAffine(Image image, AffineData affine)
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
