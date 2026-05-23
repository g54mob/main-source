using haxe.lang;

namespace app
{
	public class Rand : HxObject
	{
		public int a;

		public int b;

		public int c;

		public int d;

		public Rand(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Rand(int seed)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Rand(Rand __hx_this, int seed)
		{
		}

		public static Rand fromState(RandState randState)
		{
			return null;
		}

		public virtual int nextInt()
		{
			return 0;
		}

		public virtual double nextFloat()
		{
			return 0.0;
		}

		public virtual double random()
		{
			return 0.0;
		}

		public virtual RandState getState()
		{
			return null;
		}

		public virtual Rand setState(RandState randState)
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
