namespace Gh.Tk
{
	public class MinRoomSizeRequirement : ZoneRoomRequirement
	{
		private readonly int _sizeInTiles;

		protected MinRoomSizeRequirement()
		{
		}

		public MinRoomSizeRequirement(string titleKey, int sizeInTiles, Room room)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}
	}
}
