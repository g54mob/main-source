using data;
using haxe.lang;

namespace play.save
{
	public class SaveHeader : HxObject
	{
		public string id;

		public string parentId;

		public Date date;

		public int day;

		public int money;

		public int family;

		public SaveHeader(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public SaveHeader()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_save_SaveHeader(SaveHeader __hx_this)
		{
		}

		public static SaveHeader fromString(string str)
		{
			return null;
		}

		public static SaveHeader fromFacts(FactSet facts)
		{
			return null;
		}

		public static string makeGuid()
		{
			return null;
		}

		public virtual bool isNew()
		{
			return false;
		}

		public virtual string toString()
		{
			return null;
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

		public override string ToString()
		{
			return null;
		}
	}
}
