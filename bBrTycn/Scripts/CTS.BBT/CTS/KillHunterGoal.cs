using CTS.BBT.AI;

namespace CTS
{
	public class KillHunterGoal : KillAgentWithTagGoal
	{
		public KillHunterGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName, EAgentTag.Hunter)
		{
		}
	}
}
