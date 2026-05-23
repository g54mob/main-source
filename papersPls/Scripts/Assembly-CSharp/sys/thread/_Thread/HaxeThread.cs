using System.Threading;
using haxe.ds;
using haxe.lang;

namespace sys.thread._Thread
{
	public class HaxeThread : HxObject
	{
		public static Thread mainNativeThread;

		public static HaxeThread mainHaxeThread;

		public static IntMap threads;

		public static System.Threading.Mutex threadsMutex;

		public static int allocateCount;

		public Thread native;

		public EventLoop events;

		public Deque messages;

		static HaxeThread()
		{
		}

		public HaxeThread(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public HaxeThread(Thread native)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_thread__Thread_HaxeThread(HaxeThread __hx_this, Thread native)
		{
		}

		public static HaxeThread get(Thread native)
		{
			return null;
		}

		public static HaxeThread allocate(Thread native, bool withEventLoop)
		{
			return null;
		}

		public static void runWithEventLoop(Function job)
		{
		}

		public object readMessage(bool block)
		{
			return null;
		}

		public virtual void sendMessage(object msg)
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
