using System;

namespace Gh.Tk
{
	public class GameItemTemplateEventArgs : EventArgs
	{
		public GameItemTemplate Template { get; }

		public GameItemTemplateEventArgs(GameItemTemplate template)
		{
		}
	}
}
