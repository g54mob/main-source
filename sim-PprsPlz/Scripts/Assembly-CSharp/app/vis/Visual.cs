using haxe.lang;

namespace app.vis
{
	public class Visual : HxObject
	{
		public string name;

		public bool visible;

		public PointData pos;

		public Rect clip;

		public int layer;

		public Array tiles;

		public int tileCount;

		public Rect _hitRect;

		public Quad _renderQuad;

		public PointData hostPos;

		public Visual(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Visual()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Visual(Visual __hx_this)
		{
		}

		public double get_x()
		{
			return 0.0;
		}

		public double set_x(double v)
		{
			return 0.0;
		}

		public double get_y()
		{
			return 0.0;
		}

		public double set_y(double v)
		{
			return 0.0;
		}

		public virtual double width()
		{
			return 0.0;
		}

		public virtual double height()
		{
			return 0.0;
		}

		public virtual void buildTiles()
		{
		}

		public virtual bool willDraw()
		{
			return false;
		}

		public virtual Rect hitRect(object applyClip)
		{
			return null;
		}

		public virtual void renderToImage(Image image, PointData hostPos, PasteMode pasteMode)
		{
		}

		public virtual void allocateTiles(int tileCount_)
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
