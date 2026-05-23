using app;
using app.vis;
using haxe.lang;

namespace play.ui
{
	public class KineticScroll : HxObject
	{
		public PointData vel;

		public bool touching;

		public bool horizontal;

		public PointData touch;

		public double decay;

		public Clock clock;

		public int lastTouchFrame;

		public KineticScroll(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public KineticScroll(Clock clock_, bool horizontal_, object decay_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_ui_KineticScroll(KineticScroll __hx_this, Clock clock_, bool horizontal_, object decay_)
		{
		}

		public bool get_touching()
		{
			return false;
		}

		public virtual double drag(PointData touch_, double scroll, double min, double max)
		{
			return 0.0;
		}

		public virtual double get_decayPowFactor()
		{
			return 0.0;
		}

		public virtual double update(double scroll, double min, double max)
		{
			return 0.0;
		}

		public virtual void clearVel()
		{
		}

		public virtual double updateMouseDown(double scroll, double delta, bool mouseJustDown, double min, double max)
		{
			return 0.0;
		}

		public virtual object updateMouseUp(double scroll, double vel, double min, double max)
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
