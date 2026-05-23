using app;
using data;
using haxe.ds;
using haxe.lang;

namespace play.day
{
	public class DayNews : HxObject
	{
		public int dayId;

		public double date;

		public Array articles;

		public StringMap factIdRemap;

		public Rand rand;

		public DayNews(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DayNews(Db db, Rand rand, FactSet facts, int dayId_, double date_)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_DayNews(DayNews __hx_this, Db db, Rand rand, FactSet facts, int dayId_, double date_)
		{
		}

		public static string getStorageFactPath(int dayId)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
