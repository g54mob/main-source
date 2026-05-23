using app;
using app.ent;
using app.vis;
using haxe.lang;
using play.ui;

namespace play.day.border
{
	public class BorderPan : HxObject
	{
		public PointData pan;

		public Layout layout;

		public Border border;

		public Clock clock;

		public Person followPerson;

		public PointData windowSize;

		public BorderPanSide wantSide;

		public double wantSideStartTime;

		public double wantSideVel;

		public double wantSideDir;

		public PointData panMax;

		public KineticScroll kineticScroll;

		public int followPersonCountdown;

		public double followPersonOffsetX;

		public BorderPan(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public BorderPan(Layout layout_, Border border_, Clock clock_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_BorderPan(BorderPan __hx_this, Layout layout_, Border border_, Clock clock_)
		{
		}

		public virtual void followPersonForOneFrame(Person followPerson_, double followPersonOffsetX_)
		{
		}

		public virtual double makeStash()
		{
			return 0.0;
		}

		public virtual void restoreFromStash(double p)
		{
		}

		public virtual void panToSide(bool left)
		{
		}

		public virtual void update()
		{
		}

		public virtual void react(Input input)
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
