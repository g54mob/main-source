using app;
using app.ent;
using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class TakeBurst : HxObject
	{
		public static double kDuration;

		public double age;

		public Rect workRect;

		public Rand rand;

		public Array lines;

		static TakeBurst()
		{
		}

		public TakeBurst(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TakeBurst(Rand rand_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_TakeBurst(TakeBurst __hx_this, Rand rand_)
		{
		}

		public bool get_isAlive()
		{
			return false;
		}

		public virtual void spawn(PointData center)
		{
		}

		public virtual void update(double dt)
		{
		}

		public virtual void draw(PointData hostPos, Drawer drawer)
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
