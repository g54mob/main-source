using app.vis;
using haxe.lang;

namespace play.ui
{
	public class DiagramLine : Visual
	{
		public double visibleT;

		public double cornerRadius;

		public ColorData color;

		public double length;

		public bool needsRebuild;

		public Array points;

		public DiagramLine(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DiagramLine(uint color_, object cornerRadius_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_DiagramLine(DiagramLine __hx_this, uint color_, object cornerRadius_)
		{
		}

		public static Array makeTestLines(double boundsWidth)
		{
			return null;
		}

		public int get_numPoints()
		{
			return 0;
		}

		public double set_cornerRadius(double v)
		{
			return 0.0;
		}

		public ColorData set_color(ColorData v)
		{
			return null;
		}

		public virtual void clearPoints()
		{
		}

		public virtual void addPoint(PointData p)
		{
		}

		public PointData getPointAt(int i)
		{
			return null;
		}

		public override void buildTiles()
		{
		}

		public virtual Array buildDots()
		{
			return null;
		}

		public void addDotted(Array dots, PointData p)
		{
		}

		public virtual void addDottedTo(Array dots, PointData p)
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
