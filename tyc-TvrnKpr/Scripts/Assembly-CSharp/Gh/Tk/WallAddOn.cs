namespace Gh.Tk
{
	public class WallAddOn : Buildable
	{
		public int amountOfWallTilesNeeded;

		public bool isOnValidPosition { get; set; }

		public override bool IsBuildValid(bool ignoreCost = false)
		{
			return false;
		}
	}
}
