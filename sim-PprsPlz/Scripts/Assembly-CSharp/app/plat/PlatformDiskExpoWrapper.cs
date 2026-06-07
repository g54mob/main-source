using haxe.lang;

namespace app.plat
{
	public class PlatformDiskExpoWrapper : PlatformDiskMemWrapper
	{
		public PlatformDiskExpoWrapper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformDiskExpoWrapper(PlatformDisk innerDisk_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformDiskExpoWrapper(PlatformDiskExpoWrapper __hx_this, PlatformDisk innerDisk_)
		{
		}

		public override string getPersistentString(string name)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}
	}
}
