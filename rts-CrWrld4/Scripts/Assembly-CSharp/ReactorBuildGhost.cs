public class ReactorBuildGhost : UnitBuildGhost
{
	public ReactorCoverage reactorCoverage;

	protected override void SetPosition(int cellX, int cellY, bool force)
	{
	}

	public int GetResourceCount(int cellX, int cellY)
	{
		return 0;
	}
}
