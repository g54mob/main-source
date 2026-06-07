namespace Motorways
{
	public static class TileDirectionExtensions
	{
		public static string ToShortString(this TileDirection direction)
		{
			return direction switch
			{
				TileDirection.North => "N", 
				TileDirection.NorthEast => "NE", 
				TileDirection.East => "E", 
				TileDirection.SouthEast => "SE", 
				TileDirection.South => "S", 
				TileDirection.SouthWest => "SW", 
				TileDirection.West => "W", 
				TileDirection.NorthWest => "NW", 
				_ => direction.ToString(), 
			};
		}
	}
}
