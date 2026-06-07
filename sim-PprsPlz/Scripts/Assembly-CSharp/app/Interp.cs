using haxe.lang;

namespace app
{
	public class Interp : HxObject
	{
		public object b;

		public InterpType type;

		public double segmentT0;

		public double segmentT1;

		public Interp(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Interp(object b_, InterpType type_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Interp(Interp __hx_this, object b_, InterpType type_)
		{
		}

		public static object lerp(object a, object b, double t)
		{
			return null;
		}

		public static Interp STEP(object b, double t)
		{
			return null;
		}

		public static Interp LINEAR(object b)
		{
			return null;
		}

		public static Interp POW(object b, double p)
		{
			return null;
		}

		public static Interp INVPOW(object b, double p)
		{
			return null;
		}

		public static Interp SMOOTHSTEP(object b, double e0, double e1)
		{
			return null;
		}

		public static Interp SMOOTHERSTEP(object b, double e0, double e1)
		{
			return null;
		}

		public static Interp BOUNCEBACK(object b, double perc, int count)
		{
			return null;
		}

		public static Interp FLASH(object b, int count)
		{
			return null;
		}

		public static Interp RISEFALL(object b, double mid)
		{
			return null;
		}

		public virtual object get(object a, double interp)
		{
			return null;
		}

		public virtual Interp seg(double segmentT0_, double segmentT1_)
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
