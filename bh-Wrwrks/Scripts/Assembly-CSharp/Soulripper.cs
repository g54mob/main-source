public class Soulripper : Weapon
{
	public override void KillTrigger(Monster monster)
	{
		foreach (Module adjacent in owner.GetAdjacents())
		{
			if (adjacent.WAND)
			{
				adjacent.mana += (base.UPGRADED ? 4 : 2);
			}
		}
	}
}
