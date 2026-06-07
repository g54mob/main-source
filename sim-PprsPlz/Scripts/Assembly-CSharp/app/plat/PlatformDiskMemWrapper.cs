using haxe.ds;
using haxe.io;
using haxe.lang;

namespace app.plat
{
	public class PlatformDiskMemWrapper : PlatformDisk
	{
		public PlatformDisk innerDisk;

		public StringMap persistentStrings;

		public PlatformDiskMemWrapper(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformDiskMemWrapper(PlatformDisk innerDisk_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformDiskMemWrapper(PlatformDiskMemWrapper __hx_this, PlatformDisk innerDisk_)
		{
		}

		public virtual void clear()
		{
		}

		public override Bytes getAssetBytes(string name)
		{
			return null;
		}

		public override Array getAvailableLanguageCodes()
		{
			return null;
		}

		public override void setPersistentString(string name, string value)
		{
		}

		public override string getPersistentString(string name)
		{
			return null;
		}

		public override string getDocumentsDirectory()
		{
			return null;
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
