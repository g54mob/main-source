public class AgentActionRecipeEvent : AgentActionEvent
{
	public ProductionRecipeProperties Recipe { get; private set; }

	public AgentActionRecipeEvent(GameEventType gameEventType, Agent agent, ProductionRecipeProperties productionRecipe, DrifterAttributes.AttributeType type)
		: base(gameEventType, agent, type)
	{
		Recipe = productionRecipe;
	}
}
