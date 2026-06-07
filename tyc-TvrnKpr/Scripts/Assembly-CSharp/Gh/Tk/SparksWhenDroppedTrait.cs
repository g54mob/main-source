namespace Gh.Tk
{
	public class SparksWhenDroppedTrait : GameItemTrait
	{
		protected SparksWhenDroppedTrait()
		{
		}

		public SparksWhenDroppedTrait(GameObjectX owner)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
