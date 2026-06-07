using CTS.BBT.AI;

namespace CTS
{
	public class KillHostilesGoal : KillAgentWithTagGoal
	{
		public KillHostilesGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName, EAgentTag.Hunter, EAgentTag.Investigator)
		{
		}
	}
}
