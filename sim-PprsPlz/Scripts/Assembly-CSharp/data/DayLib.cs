using haxe.lang;

namespace data
{
	public class DayLib : HxObject
	{
		public CsvTable table;

		public DayLib(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public DayLib(Res res, bool forEndless)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_DayLib(DayLib __hx_this, Res res, bool forEndless)
		{
		}

		public virtual Col getColForDay(int id)
		{
			return null;
		}

		public virtual Array getAccumulatedRow(int throughDayId, string rowId)
		{
			return null;
		}

		public virtual bool hasDay(int id)
		{
			return false;
		}

		public virtual int getNumDays()
		{
			return 0;
		}

		public virtual bool debugGetRulesAppearTogether(string ruleA, string ruleB)
		{
			return false;
		}

		public virtual int debugGetDayIdForTravelerId(TravelerLib travelerLib, string travelerId)
		{
			return 0;
		}

		public virtual Array getNightMessages(int dayId)
		{
			return null;
		}

		public virtual Array getNewsIds(int dayId)
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
