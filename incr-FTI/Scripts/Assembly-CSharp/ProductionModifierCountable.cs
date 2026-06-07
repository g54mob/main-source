public class ProductionModifierCountable : ProductionModifier
{
	public readonly CountableState modifyingState;

	private readonly float countMultiplier;

	public ProductionModifierCountable(CountableState state, float countMultiplier)
	{
		modifyingState = state;
		this.countMultiplier = countMultiplier;
	}

	public override void CalcMultiplier()
	{
		multiplier = 1f + GameUtility.AsFloat(modifyingState.maxCount * (double)countMultiplier);
	}

	public override string DisplayLabel()
	{
		string text = TextDisplay.LabelForEntity(modifyingState.AsEntity());
		return text + " (" + TextDisplay.LocalizedNumber(modifyingState.maxCount) + ") x" + TextDisplay.LocalizedNumber(countMultiplier);
	}
}
