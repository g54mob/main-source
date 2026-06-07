using System;

namespace Assets.Scripts.Multiplayer.ActivityFramework
{
	[Flags]
	public enum NetworkedActivityDebugLogFlags
	{
		None = 0,
		StateChanged = 1,
		SettingChanged = 2,
		PlayersChanged = 4,
		PlayerTeamChanged = 8,
		PlayerStateChanged = 0x10,
		All = 0x1F
	}
}
