using System;

namespace Gh.Tk
{
	public class GameItemEventArgs : EventArgs
	{
		public GameItem Item { get; }

		public GameItemEventArgs(GameItem item)
		{
		}
	}
}
