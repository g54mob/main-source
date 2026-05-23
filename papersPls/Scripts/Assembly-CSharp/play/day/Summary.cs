using haxe.lang;

namespace play.day
{
	public class Summary : HxObject
	{
		public int id;

		public int numProcessedTravelersPaid;

		public int numProcessedTravelersUnpaid;

		public int numMadeTravelers;

		public int numPenalties;

		public int penaltyCost;

		public AttackResult attackResult;

		public Attack attack;

		public bool hadBomber;

		public bool hadPoisoning;

		public int bribeMoney;

		public Array tokenIds;

		public Array nightEventIds;

		public bool keepEscapePassports;

		public int numEscapePassports;

		public Summary(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public Summary()
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_play_day_Summary(Summary __hx_this)
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
