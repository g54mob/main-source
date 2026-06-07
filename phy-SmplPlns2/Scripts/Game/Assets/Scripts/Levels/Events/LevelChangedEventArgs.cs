using System;

namespace Assets.Scripts.Levels.Events
{
	public class LevelChangedEventArgs : EventArgs
	{
		public string LevelName { get; private set; }

		public string MapName { get; private set; }

		public LevelChangedEventArgs(string levelName, string mapName)
		{
			LevelName = levelName;
			MapName = mapName;
		}
	}
}
