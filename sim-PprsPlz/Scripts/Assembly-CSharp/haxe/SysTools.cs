using haxe.lang;

namespace haxe
{
	public class SysTools : HxObject
	{
		public static Array winMetaCharacters;

		static SysTools()
		{
		}

		public SysTools(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SysTools()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_haxe_SysTools(SysTools __hx_this)
		{
		}

		public static string quoteUnixArg(string argument)
		{
			return null;
		}

		public static string quoteWinArg(string argument, bool escapeMetaCharacters)
		{
			return null;
		}
	}
}
