using app.ent;
using haxe.lang;

namespace play.day.booth
{
	public class CriminalPoster : Ent
	{
		public static int kForeColor;

		public static int kBackColor;

		public static int kSpacingX;

		public static double kDropPerc;

		public static int kShutterSwitchBodyWidth;

		public Array inspectables;

		public double showTime;

		public Array sprites;

		public Array spriteDelays;

		public Shutter shutter;

		static CriminalPoster()
		{
		}

		public CriminalPoster(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public CriminalPoster(Ent parent, Day day)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_booth_CriminalPoster(CriminalPoster __hx_this, Ent parent, Day day)
		{
		}

		public virtual void setShutter(Shutter shutter_)
		{
		}

		public virtual void show(object instant)
		{
		}

		public override void update()
		{
		}

		public override void draw(Drawer drawer)
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
