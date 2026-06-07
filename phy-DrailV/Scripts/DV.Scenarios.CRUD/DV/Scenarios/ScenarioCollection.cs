using System.Collections.Generic;
using DV.Scenarios.Common;

namespace DV.Scenarios
{
	public class ScenarioCollection : ThingCollection<IScenario>
	{
		public override IScenario Create()
		{
			Scenario scenario = new Scenario();
			scenario.Train = base.Manager.GetCollection<ITrain>().GetOrCreate();
			_AfterCreate(scenario);
			return scenario;
		}

		protected override void _FixData<T2>(T2 thing)
		{
			if (thing is Scenario scenario && scenario.Train == null)
			{
				scenario.Train = base.Manager.GetCollection<ITrain>().GetOrCreate();
			}
			base._FixData(thing);
		}

		public ScenarioCollection(string newThingName, CollectionManager manager, Dictionary<string, string> localizationDictionary)
			: base(newThingName, manager, true, localizationDictionary)
		{
		}
	}
}
