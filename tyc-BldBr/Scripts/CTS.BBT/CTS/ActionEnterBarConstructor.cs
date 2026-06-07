using CTS.BBT.AI;

namespace CTS
{
	public class ActionEnterBarConstructor : ActionConstructor<AgentActionEnterBar>
	{
		protected override AgentActionEnterBar ConstructAction()
		{
			return new AgentActionEnterBar();
		}
	}
}
