using app;
using haxe.lang;

namespace data
{
	public class TravelerName : HxObject
	{
		public string first;

		public string last;

		public bool male;

		public NameCycler nameCycler;

		public TravelerName(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TravelerName(NameCycler nameCycler_, bool male_, string first_, string last_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_TravelerName(TravelerName __hx_this, NameCycler nameCycler_, bool male_, string first_, string last_)
		{
		}

		public virtual string getFormatted(string format)
		{
			return null;
		}

		public virtual TravelerName randomize()
		{
			return null;
		}

		public virtual bool isEqual(TravelerName other)
		{
			return false;
		}

		public virtual TravelerName getRandomInvalidatedImp(Rand rand)
		{
			return null;
		}

		public virtual TravelerName getRandomInvalidated(Rand rand)
		{
			return null;
		}

		public virtual TravelerName getRandomAlias(Lang lang, Rand rand)
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
