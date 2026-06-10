using System.Collections.Generic;
using System.Linq;
using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class ScenarioRepository : DynamicJsonRepository<ScenarioRepository, Scenario>
	{
		private const string BlueprintScenarioId = "blueprint_scenario";

		public SerializableIdValuePair[] GetDefaultGameParameters()
		{
			return GetBlueprintScenario().GameParameters.ToArray();
		}

		public Scenario GetBlueprintScenario()
		{
			return GetByID("blueprint_scenario");
		}

		public List<Scenario> GetDefaultScenarios()
		{
			return (from scenario in GetAllItems()
				where scenario.IsDefault && scenario.GetID() != "blueprint_scenario"
				select scenario).ToList();
		}

		public List<Scenario> GetUserScenarios()
		{
			return (from scenario in GetAllItems()
				where !scenario.IsDefault
				select scenario).ToList();
		}

		protected override string JsonFile()
		{
			return "Scenario/Scenarios.json";
		}
	}
}
