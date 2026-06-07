using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class CarouselNudge : HxObject
	{
		public PointData offset;

		public bool hasMovement;

		public double inMin;

		public double inMaxH;

		public double outMaxH;

		public double inMaxV;

		public double outMaxV;

		public double decayH;

		public double decayV;

		public double decayVCountdown;

		public int dragging;

		public PointData draggingCurPos;

		public PointData draggingStartPos;

		public bool latched;

		public PointData maintainedOffset;

		public CarouselNudge(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CarouselNudge(object inMaxH_, object outMaxH_, object decayH_, object inMaxV_, object outMaxV_, object decayV_, object inMin_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_CarouselNudge(CarouselNudge __hx_this, object inMaxH_, object outMaxH_, object decayH_, object inMaxV_, object outMaxV_, object decayV_, object inMin_)
		{
		}

		public static double clampOffset(double offset, double in0, double in1, double out1)
		{
			return 0.0;
		}

		public bool get_active()
		{
			return false;
		}

		public virtual void drag(Pointer pointer, object applyVert)
		{
		}

		public virtual void update(double dt)
		{
		}

		public virtual void clearX()
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
