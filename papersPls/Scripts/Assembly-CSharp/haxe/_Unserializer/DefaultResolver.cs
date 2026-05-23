using System;
using haxe.lang;

namespace haxe._Unserializer
{
	public class DefaultResolver : HxObject
	{
		public DefaultResolver(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DefaultResolver()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe__Unserializer_DefaultResolver(DefaultResolver __hx_this)
		{
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
