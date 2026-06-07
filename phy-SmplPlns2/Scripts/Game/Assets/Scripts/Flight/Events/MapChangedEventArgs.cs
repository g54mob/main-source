using System;

namespace Assets.Scripts.Flight.Events
{
	public class MapChangedEventArgs : EventArgs
	{
		public string LevelName { get; private set; }

		public string MapName { get; private set; }

		public MapChangedEventArgs(string levelName, string mapName)
		{
			LevelName = levelName;
			MapName = mapName;
		}
	}
}
