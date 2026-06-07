using haxe.lang;

namespace data
{
	public class TestScenario : HxObject
	{
		public string id;

		public bool clearStoryFacts;

		public FactSet initialStoryFacts;

		public int dayId;

		public int nightId;

		public string travelerId;

		public TestScenario(EmptyObject empty)
			: base(default(EmptyObject))
		{
		}

		public TestScenario(string id, bool clearStoryFacts, FactSet initialStoryFacts, int dayId, int nightId, string travelerId)
			: base(default(EmptyObject))
		{
		}

		protected static void __hx_ctor_data_TestScenario(TestScenario __hx_this, string id, bool clearStoryFacts, FactSet initialStoryFacts, int dayId, int nightId, string travelerId)
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
