using data;
using haxe.lang;
using play.day;

namespace play.stash
{
	public class StashedDay : HxObject
	{
		public int id;

		public FactSet facts;

		public int numDetains;

		public int numProcessedTravelersPaid;

		public int numProcessedTravelersUnpaid;

		public AttackResult attackResult;

		public int numMadeTravelers;

		public bool hadBomber;

		public bool hadPoisoning;

		public int bribeMoney;

		public Array tokenIds;

		public Array nightEventIds;

		public Array citations;

		public Array confiscatedPapers;

		public StashedDay(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public StashedDay()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_stash_StashedDay(StashedDay __hx_this)
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

		public override void __hx_getFields(Array baseArr)
		{
		}
	}
}
