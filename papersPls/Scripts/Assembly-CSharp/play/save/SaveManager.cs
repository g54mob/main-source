using data;
using haxe.lang;
using play.stash;

namespace play.save
{
	public class SaveManager : HxObject
	{
		public int stashGeneration;

		public EncryptedStore encryptedStore;

		public SaveManager(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SaveManager(EncryptedStore encryptedStore_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_save_SaveManager(SaveManager __hx_this, EncryptedStore encryptedStore_)
		{
		}

		public virtual string save(FactSet facts)
		{
			return null;
		}

		public virtual FactSet load(string id)
		{
			return null;
		}

		public virtual void delete(string id)
		{
		}

		public virtual void clearSaveFilesRecursive(SaveNode node)
		{
		}

		public virtual SaveNode getRoot()
		{
			return null;
		}

		public virtual void setStashedGame(StashedGame stashedGame)
		{
		}

		public virtual StashedGame getStashedGame()
		{
			return null;
		}

		public virtual bool hasStashedGame()
		{
			return false;
		}

		public virtual void deleteStashedGame()
		{
		}

		public virtual void makeBackup()
		{
		}

		public override double __hx_setField_f(string field, int hash, double value, bool handleProperties)
		{
			return 0.0;
		}

		public override object __hx_setField(string field, int hash, object value, bool handleProperties)
		{
			return null;
		}

		public override object __hx_getField(string field, int hash, bool throwErrors, bool isCheck, bool handleProperties)
		{
			return null;
		}

		public override double __hx_getField_f(string field, int hash, bool throwErrors, bool handleProperties)
		{
			return 0.0;
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
