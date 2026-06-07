using app.plat;
using haxe.lang;

namespace play
{
	public class EncryptedStore : HxObject
	{
		public static string kKey;

		public static string kPrefix;

		public PlatformDisk platformDisk;

		static EncryptedStore()
		{
		}

		public EncryptedStore(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public EncryptedStore(PlatformDisk platformDisk_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_EncryptedStore(EncryptedStore __hx_this, PlatformDisk platformDisk_)
		{
		}

		public virtual string get(string name)
		{
			return null;
		}

		public virtual void set(string name, string value)
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
