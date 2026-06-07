using app;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class TouchDrag : HxObject
	{
		public PointData vel;

		public bool touching;

		public PointData touch;

		public PointData startTouch;

		public PointData startPos;

		public double decay;

		public Clock clock;

		public TouchDrag(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TouchDrag(object decay_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_TouchDrag(TouchDrag __hx_this, object decay_)
		{
		}

		public bool get_hasVel()
		{
			return false;
		}

		public virtual void start(PointData touch_, PointData pos_)
		{
		}

		public virtual InPlace update(PointData touch_)
		{
			return null;
		}

		public virtual void stop()
		{
		}

		public virtual double get_decayPowFactor()
		{
			return 0.0;
		}

		public virtual InPlace applyDecay(PointData pos)
		{
			return null;
		}

		public virtual void clearVel()
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
