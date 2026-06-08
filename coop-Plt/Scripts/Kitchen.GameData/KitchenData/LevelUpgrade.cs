namespace KitchenData
{
	public class LevelUpgrade
	{
		public int Level;

		public IUpgrade Upgrade;

		public int PlayerDisplayedLevel => Level + 1;
	}
}
