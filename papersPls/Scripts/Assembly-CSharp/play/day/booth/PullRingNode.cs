using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class PullRingNode : HxObject
	{
		public PointData pos;

		public PointData vel;

		public PointData accel;

		public double distToParent;

		public double distAlongChain;

		public PullRingNode parent;

		public PointData work;

		public PullRingNode(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PullRingNode(PullRingNode parent_, double distToParent_, double distAlongChain_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_PullRingNode(PullRingNode __hx_this, PullRingNode parent_, double distToParent_, double distAlongChain_)
		{
		}

		public virtual void updateHanging(double dt, bool clampHeight)
		{
		}

		public virtual void pullStart()
		{
		}

		public virtual void pullStop()
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
