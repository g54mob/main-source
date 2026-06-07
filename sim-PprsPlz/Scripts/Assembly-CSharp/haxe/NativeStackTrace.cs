using System;
using System.Diagnostics;
using haxe.lang;

namespace haxe
{
	public class NativeStackTrace : HxObject
	{
		[ThreadStatic]
		public static System.Exception exception;

		public NativeStackTrace(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NativeStackTrace()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_NativeStackTrace(NativeStackTrace __hx_this)
		{
		}

		public static void saveStack(object e)
		{
		}

		public static StackTrace callStack()
		{
			return null;
		}

		public static StackTrace exceptionStack()
		{
			return null;
		}

		public static Array toHaxe(StackTrace native, object skip)
		{
			return null;
		}
	}
}
