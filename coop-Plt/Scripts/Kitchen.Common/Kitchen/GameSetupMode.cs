using System;

namespace Kitchen
{
	[Flags]
	public enum GameSetupMode
	{
		Server = 1,
		Client = 2,
		All = 3
	}
}
