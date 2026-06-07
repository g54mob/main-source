using Assets.Scripts.Levels;

namespace Assets.Scripts.Flight.Maps
{
	public abstract class MapBase
	{
		public abstract string MapId { get; }

		public abstract string Name { get; }

		public abstract MapLoadResult LoadMap(LevelInfo level);
	}
}
