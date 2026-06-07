public class RequiredMinHappiness : Requirement
{
	public int requiredValue;

	public RequiredMinHappiness(int minRequiredHappiness)
	{
		requiredValue = minRequiredHappiness;
	}

	public override Requirement GetCopy()
	{
		return new RequiredMinHappiness(requiredValue);
	}

	public float CurrentCount()
	{
		return 0f;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= (float)requiredValue;
	}
}
