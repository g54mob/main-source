using app;
using haxe.lang;
using play;

namespace data
{
	public class NameCycler : HxObject
	{
		public NameLib nameLib;

		public ShuffledSequence namesM;

		public ShuffledSequence namesF;

		public EncryptedStore encryptedStore;

		public NameCycler(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public NameCycler(Res res, int seed, EncryptedStore encryptedStore_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_NameCycler(NameCycler __hx_this, Res res, int seed, EncryptedStore encryptedStore_)
		{
		}

		public virtual object get(bool male)
		{
			return null;
		}

		public virtual bool load()
		{
			return false;
		}

		public virtual void save()
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
