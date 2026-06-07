using haxe.io;
using haxe.lang;

namespace app.plat
{
	public class PlatformDisk : HxObject
	{
		public PlatformDisk(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public PlatformDisk()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_app_plat_PlatformDisk(PlatformDisk __hx_this)
		{
		}

		public virtual Bytes getAssetBytes(string name)
		{
			return null;
		}

		public virtual Array getAvailableLanguageCodes()
		{
			return null;
		}

		public virtual void setPersistentString(string name, string value)
		{
		}

		public virtual string getPersistentString(string name)
		{
			return null;
		}

		public virtual string getDocumentsDirectory()
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
