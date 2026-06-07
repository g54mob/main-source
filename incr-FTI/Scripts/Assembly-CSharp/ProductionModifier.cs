public class ProductionModifier
{
	public EntityId id;

	public int level;

	public float multiplier;

	protected GameManager gm => GameManager.Instance;

	public ProductionModifier()
	{
		multiplier = 1f;
	}

	public virtual void CalcMultiplier()
	{
	}

	public virtual string DisplayLabel()
	{
		return "modifier";
	}

	public override string ToString()
	{
		return DisplayLabel();
	}
}
