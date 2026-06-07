using haxe.lang;

namespace app
{
	public class Tween : HxObject
	{
		public bool running;

		public double t;

		public double duration;

		public Function tweenHandler;

		public Function completeHandler;

		public Tween(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Tween(double duration_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_Tween(Tween __hx_this, double duration_)
		{
		}

		public virtual void step(Clock clock)
		{
		}

		public virtual void stop()
		{
		}

		public virtual Tween onTween(Function tweenHandler_)
		{
			return null;
		}

		public virtual Tween onComplete(Function completeHandler_)
		{
			return null;
		}

		public bool hasHandler(object handler)
		{
			return false;
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
