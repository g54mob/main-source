using CTS.BBT.AI;

namespace CTS
{
	public class ActionLeaveBarConstructor : ActionConstructor<AgentActionLeave>
	{
		protected override AgentActionLeave ConstructAction()
		{
			return new AgentActionLeave();
		}
	}
}
