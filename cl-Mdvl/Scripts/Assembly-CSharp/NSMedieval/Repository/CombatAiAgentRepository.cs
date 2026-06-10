using NSEipix.Repository;
using NSMedieval.Model;

namespace NSMedieval.Repository
{
	public class CombatAiAgentRepository : DynamicJsonRepository<CombatAiAgentRepository, CombatAiAgentBlueprint>
	{
		protected override string JsonFile()
		{
			return "Combat/CombatAiAgents.json";
		}
	}
}
