using app;
using app.vis;
using haxe.lang;

namespace play.day.border
{
	public class Grenade : CustomTile
	{
		public Function whenHit;

		public Function whenDescend;

		public double startY;

		public double velX;

		public double velY;

		public Clock clock;

		public Grenade(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Grenade(Atlas atlas, Clock clock_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_border_Grenade(Grenade __hx_this, Atlas atlas, Clock clock_)
		{
		}

		public virtual void throwFrom(PointData pos_, PointData vel_)
		{
		}

		public virtual void step()
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
