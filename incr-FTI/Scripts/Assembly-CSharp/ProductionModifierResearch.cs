public class ProductionModifierResearch : ProductionModifier
{
	public readonly ResearchState researchState;

	public ProductionModifierResearch(ResearchState t)
	{
		researchState = t;
		multiplier = 1f;
	}

	public override void CalcMultiplier()
	{
		multiplier = GameManager.MultiplierForResearch(researchState.type, researchState.numCompleted);
	}

	public override string DisplayLabel()
	{
		string text = "Research".Localized();
		return "(" + text + ") " + TextDisplay.LabelForResearchLevel(researchState.type, researchState.numCompleted);
	}
}
