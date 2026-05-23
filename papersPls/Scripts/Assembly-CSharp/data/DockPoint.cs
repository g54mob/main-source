using app.vis;
using haxe.lang;

namespace data
{
	public class DockPoint : HxObject
	{
		public DockPointEntry entry;

		public Rect home;

		public Rect clip;

		public Rect clamp;

		public Array boundarySegLens;

		public double boundaryLen;

		public DockPointReturnHomeResult returnHomeResult;

		public DockPoint(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DockPoint(DockPointEntry entry_, Rect home_, Rect clamp_, Rect clip_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_DockPoint(DockPoint __hx_this, DockPointEntry entry_, Rect home_, Rect clamp_, Rect clip_)
		{
		}

		public PointData get_toasterPos()
		{
			return null;
		}

		public virtual DockPointReturnHomeResult returnHome(double x, double y, double dt, double dropVel, double dropAccel)
		{
			return null;
		}

		public virtual PointData clampDrag(PointData center)
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
