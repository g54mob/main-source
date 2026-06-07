using haxe.lang;
using sys.thread._EventLoop;

namespace sys.thread
{
	public class EventLoop : HxObject
	{
		public Mutex mutex;

		public Array oneTimeEvents;

		public int oneTimeEventsIdx;

		public Lock waitLock;

		public int promisedEventsCount;

		public RegularEvent regularEvents;

		public EventLoop(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EventLoop()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_thread_EventLoop(EventLoop __hx_this)
		{
		}

		public virtual RegularEvent repeat(Function @event, int intervalMs)
		{
			return null;
		}

		public virtual void cancel(RegularEvent eventHandler)
		{
		}

		public virtual void promise()
		{
		}

		public virtual void run(Function @event)
		{
		}

		public virtual void runPromised(Function @event)
		{
		}

		public virtual NextEventTime progress()
		{
			return null;
		}

		public virtual bool wait(object timeout)
		{
			return false;
		}

		public virtual void loop()
		{
		}

		public object __progress(double now, Array recycle)
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
