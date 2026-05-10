using CTS.BBT.AI;

namespace CTS
{
	public class ActionDrinkConstructor : ActionConstructor<AgentActionDrink>
	{
		protected override AgentActionDrink ConstructAction()
		{
			return new AgentActionDrink();
		}
	}
}
