using System;

namespace ModApi.Levels.Events
{
	public class LevelEventArgs : EventArgs
	{
		public ILevel Level { get; }

		public LevelEventArgs(ILevel level)
		{
			Level = level;
		}
	}
}
