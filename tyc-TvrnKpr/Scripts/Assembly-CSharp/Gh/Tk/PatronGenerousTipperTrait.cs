namespace Gh.Tk
{
	public class PatronGenerousTipperTrait : PatronTrait
	{
		protected PatronGenerousTipperTrait()
		{
		}

		public PatronGenerousTipperTrait(Patron owner)
		{
		}

		public void Tip(int originalCost, string category, string reason)
		{
		}

		public override bool ShouldAutoAddTo(GameObjectX gox)
		{
			return false;
		}
	}
}
