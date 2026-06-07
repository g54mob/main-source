using System;

namespace Gh.Tk
{
	public class SlotsGameEventArgs : EventArgs
	{
		public float WinRate { get; private set; }

		public Actor Actor { get; private set; }

		public bool DidWin { get; private set; }

		public SlotsGameEventArgs(Actor actor, float winRate, bool didWin)
		{
		}
	}
}
