using System.Diagnostics;
using haxe.io;
using haxe.lang;

namespace sys.io
{
	public class Process : HxObject
	{
		public Input stdout;

		public Input stderr;

		public Output stdin;

		public System.Diagnostics.Process native;

		public Process(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Process(string cmd, Array args, object detached)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_sys_io_Process(Process __hx_this, string cmd, Array args, object detached)
		{
		}

		public static System.Diagnostics.Process createNativeProcess(string cmd, Array args)
		{
			return null;
		}

		public static string buildArgumentsString(Array args)
		{
			return null;
		}

		public virtual int getPid()
		{
			return 0;
		}

		public virtual object exitCode(object block)
		{
			return null;
		}

		public virtual void close()
		{
		}

		public virtual void kill()
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
