using app.vis;
using haxe.lang;

namespace play.day.booth
{
	public class ConsoleClock : Sprite
	{
		public static uint kHandColor;

		public double hour;

		public Image handImage;

		public Image pinImage;

		public PointData size;

		public PointData center;

		public AffineData affine;

		static ConsoleClock()
		{
		}

		public ConsoleClock(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public ConsoleClock(Res res)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_ConsoleClock(ConsoleClock __hx_this, Res res)
		{
		}

		public virtual double set_hour(double h)
		{
			return 0.0;
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
