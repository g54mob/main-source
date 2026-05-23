using System;
using haxe.lang;

namespace haxe._Unserializer
{
	public class NullResolver : HxObject
	{
		public static NullResolver instance;

		public NullResolver(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NullResolver()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe__Unserializer_NullResolver(NullResolver __hx_this)
		{
		}

		public static NullResolver get_instance()
		{
			return null;
		}

		public System.Type resolveClass(string name)
		{
			return null;
		}

		public System.Type resolveEnum(string name)
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
	}
}
