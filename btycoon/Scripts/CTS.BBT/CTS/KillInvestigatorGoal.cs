using CTS.BBT.AI;

namespace CTS
{
	public class KillInvestigatorGoal : KillAgentWithTagGoal
	{
		public KillInvestigatorGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName, EAgentTag.Investigator)
		{
		}
	}
}
