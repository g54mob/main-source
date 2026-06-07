namespace Gh.Tk
{
	public class IndestructibleGameItemTrait : GameItemTrait
	{
		protected IndestructibleGameItemTrait()
		{
		}

		public IndestructibleGameItemTrait(GameObjectX owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
