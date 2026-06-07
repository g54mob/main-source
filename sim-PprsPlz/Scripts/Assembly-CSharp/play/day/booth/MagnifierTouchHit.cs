using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class MagnifierTouchHit : HxObject
	{
		public double time;

		public PointData stageMouse;

		public Inspectable inspectable;

		public MagnifierTouchHit(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public MagnifierTouchHit(double time_, PointData stageMouse_, Inspectable inspectable_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_MagnifierTouchHit(MagnifierTouchHit __hx_this, double time_, PointData stageMouse_, Inspectable inspectable_)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
