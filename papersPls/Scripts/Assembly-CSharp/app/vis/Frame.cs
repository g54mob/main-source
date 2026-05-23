using haxe.lang;

namespace app.vis
{
	public class Frame : Visual
	{
		public Image image;

		public Rect scale9Rect;

		public ColorData color;

		public PointData outerSize;

		public Frame(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Frame(Image image_, Rect scale9Rect_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Frame(Frame __hx_this, Image image_, Rect scale9Rect_)
		{
		}

		public static Frame makeBasic(ColorData color)
		{
			return null;
		}

		public double get_borderL()
		{
			return 0.0;
		}

		public double get_borderR()
		{
			return 0.0;
		}

		public double get_borderT()
		{
			return 0.0;
		}

		public double get_borderB()
		{
			return 0.0;
		}

		public double get_borderLR()
		{
			return 0.0;
		}

		public double get_borderTB()
		{
			return 0.0;
		}

		public virtual void setInnerRect(Rect innerRect)
		{
		}

		public virtual void setOuterRect(Rect outerRect)
		{
		}

		public virtual InPlace applyBorder(Rect rect)
		{
			return null;
		}

		public override void buildTiles()
		{
		}

		public override bool willDraw()
		{
			return false;
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
