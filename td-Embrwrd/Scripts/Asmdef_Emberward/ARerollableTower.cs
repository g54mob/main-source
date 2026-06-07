public abstract class ARerollableTower : ABaseTower
{
	public abstract void Reroll();

	public abstract bool CanReroll();

	public abstract bool IsBestRollValue();
}
