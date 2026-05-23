using haxe.lang;

namespace sys.thread._EventLoop
{
	public class RegularEvent : HxObject
	{
		public double nextRunTime;

		public double interval;

		public Function run;

		public RegularEvent next;

		public RegularEvent previous;

		public RegularEvent(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public RegularEvent(Function run, double nextRunTime, double interval)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_thread__EventLoop_RegularEvent(RegularEvent __hx_this, Function run, double nextRunTime, double interval)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
