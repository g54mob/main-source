using haxe.lang;
using sys.thread._EventLoop;
using sys.thread._Thread;

namespace haxe
{
	public class Timer : HxObject
	{
		public HaxeThread thread;

		public RegularEvent eventHandler;

		public Function run;

		public Timer(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Timer(int time_ms)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_Timer(Timer __hx_this, int time_ms)
		{
		}

		public static Timer delay(Function f, int time_ms)
		{
			return null;
		}

		public static object measure(Function f, object pos)
		{
			return null;
		}

		public static double stamp()
		{
			return 0.0;
		}

		public virtual void stop()
		{
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
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
