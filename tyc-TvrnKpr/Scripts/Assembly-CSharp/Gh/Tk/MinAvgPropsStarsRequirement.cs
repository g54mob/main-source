namespace Gh.Tk
{
	public class MinAvgPropsStarsRequirement : PropZoneRoomRequirement
	{
		private readonly int _minStars;

		private readonly int _maxStars;

		protected MinAvgPropsStarsRequirement()
		{
		}

		public MinAvgPropsStarsRequirement(string titleKey, int minStars, int maxStars = -1, string zone = null, Room room = null)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}
	}
}
