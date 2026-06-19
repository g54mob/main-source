public class LargeShell : Chest
{
	protected override bool ShouldPlayAnimTrigger(int animID)
	{
		if (base.ShouldPlayAnimTrigger(animID))
		{
			return animID != -1533413595;
		}
		return false;
	}
}
