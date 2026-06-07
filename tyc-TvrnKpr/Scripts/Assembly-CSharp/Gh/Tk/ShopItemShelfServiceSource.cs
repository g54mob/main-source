namespace Gh.Tk
{
	public class ShopItemShelfServiceSource : ItemServiceSource
	{
		public override bool CanProvideTo(GameItemTemplate template, long amount, bool restrictToContainer, Actor actor)
		{
			return false;
		}
	}
}
