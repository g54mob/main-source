using haxe.lang;

namespace app
{
	public class Clock : HxObject
	{
		public static double fixedFrameDelta;

		public static double globalSpeed;

		public double time;

		public double prevTime;

		public double dt;

		public int frameCount;

		public double maxDeltaTime;

		public double sysPreTime;

		public double sysCurTime;

		public double sysStartTime;

		public double sysMinCompensation;

		static Clock()
		{
		}

		public Clock(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Clock()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Clock(Clock __hx_this)
		{
		}

		public static double getSystemTime()
		{
			return 0.0;
		}

		public virtual void start()
		{
		}

		public virtual void update(object forceDeltaTime)
		{
		}

		public virtual void setTime(double time_)
		{
		}

		public virtual void pauseForOneFrame()
		{
		}

		public virtual double get_time()
		{
			return 0.0;
		}

		public virtual double get_prevTime()
		{
			return 0.0;
		}

		public virtual double get_dt()
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
