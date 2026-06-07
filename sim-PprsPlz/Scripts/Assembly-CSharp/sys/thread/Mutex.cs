using System.Threading;
using haxe.lang;

namespace sys.thread
{
	public class Mutex : HxObject
	{
		public System.Threading.Mutex native;

		public Mutex(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Mutex()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_thread_Mutex(Mutex __hx_this)
		{
		}

		public virtual void acquire()
		{
		}

		public virtual bool tryAcquire()
		{
			return false;
		}

		public virtual void release()
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
