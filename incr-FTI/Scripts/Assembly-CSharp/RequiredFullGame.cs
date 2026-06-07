public class RequiredFullGame : Requirement
{
	public override bool IsMet()
	{
		return false;
	}

	public override bool IsVisible()
	{
		return true;
	}
}
