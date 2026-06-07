using System;

namespace Gh.Tk
{
	public class UsageEventArgs : EventArgs
	{
		public string Key { get; private set; }

		public Actor Actor { get; private set; }

		public UsageEventArgs(string key, Actor actor)
		{
		}
	}
}
