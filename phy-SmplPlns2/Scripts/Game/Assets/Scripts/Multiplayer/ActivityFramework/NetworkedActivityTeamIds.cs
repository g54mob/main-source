using System;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	[Flags]
	public enum NetworkedActivityTeamIds : byte
	{
		None = 0,
		Team1 = 1,
		Team2 = 2,
		Spectator = 4
	}
}
