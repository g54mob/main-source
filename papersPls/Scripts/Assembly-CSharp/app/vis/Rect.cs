using haxe.lang;

namespace app.vis
{
	public class Rect : HxObject
	{
		public double x;

		public double y;

		public double w;

		public double h;

		public Rect(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Rect(object x_, object y_, object w_, object h_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_vis_Rect(Rect __hx_this, object x_, object y_, object w_, object h_)
		{
		}

		public static Rect parse(string str, Rect defaultVal)
		{
			return null;
		}

		public static Rect bounds(double left, double top, double right, double bottom)
		{
			return null;
		}

		public bool get_valid()
		{
			return false;
		}

		public double get_r()
		{
			return 0.0;
		}

		public double set_r(double v)
		{
			return 0.0;
		}

		public double get_b()
		{
			return 0.0;
		}

		public double set_b(double v)
		{
			return 0.0;
		}

		public PointData get_xy()
		{
			return null;
		}

		public PointData get_tr()
		{
			return null;
		}

		public PointData get_br()
		{
			return null;
		}

		public PointData get_bl()
		{
			return null;
		}

		public int get_cx()
		{
			return 0;
		}

		public int get_cy()
		{
			return 0;
		}

		public PointData get_center()
		{
			return null;
		}

		public int get_ix()
		{
			return 0;
		}

		public int get_iy()
		{
			return 0;
		}

		public int get_iw()
		{
			return 0;
		}

		public int get_ih()
		{
			return 0;
		}

		public Rect set(Rect r)
		{
			return null;
		}

		public Rect setXYWH(double x_, double y_, double w_, double h_)
		{
			return null;
		}

		public Rect clone()
		{
			return null;
		}

		public string toString()
		{
			return null;
		}

		public bool containsWithExpansionXY(double px, double py, double expand)
		{
			return false;
		}

		public bool containsXY(double px, double py)
		{
			return false;
		}

		public bool contains(PointData p)
		{
			return false;
		}

		public bool containsRect(Rect other)
		{
			return false;
		}

		public bool intersects(Rect other)
		{
			return false;
		}

		public Rect expandXY(double amountX, double amountY)
		{
			return null;
		}

		public Rect expand(PointData amount)
		{
			return null;
		}

		public Rect encloseXY(double px, double py)
		{
			return null;
		}

		public void enclose(PointData p)
		{
		}

		public Rect offsetXY(double x_, double y_)
		{
			return null;
		}

		public Rect offset(PointData p)
		{
			return null;
		}

		public Rect scale1(double s)
		{
			return null;
		}

		public Rect merge(Rect other)
		{
			return null;
		}

		public Rect intersect(Rect other)
		{
			return null;
		}

		public Rect apply(Function f)
		{
			return null;
		}

		public double distSqrTo(PointData p)
		{
			return 0.0;
		}

		public bool isEqual(Rect other)
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

		public override string ToString()
		{
			return null;
		}
	}
}
