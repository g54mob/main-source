using Assets.Scripts.Flight.Combat.Teams.Attributes;

namespace Assets.Scripts.Flight.Combat.Teams
{
	public enum TeamId : ushort
	{
		Unknown = 0,
		[DefaultAggressionLevel(TeamId.PlayerTeams, AggressionLevel.Hostile, true)]
		[DefaultAggressionLevel(TeamId.FriendlyNpcDefault, AggressionLevel.Hostile, true)]
		HostileNpcDefault = 1,
		[DefaultAggressionLevel(TeamId.PlayerTeams, AggressionLevel.Neutral, true)]
		NeutralNpcDefault = 2,
		[DefaultAggressionLevel(TeamId.PlayerTeams, AggressionLevel.Friendly, true)]
		[DefaultAggressionLevel(TeamId.HostileNpcDefault, AggressionLevel.Hostile, true)]
		FriendlyNpcDefault = 3,
		Information = 4,
		[TeamRange(TeamId.PlayerTeamsStart, TeamId.PlayerTeamsEnd)]
		PlayerTeams = 10,
		PlayerTeamsStart = 11,
		PlayerTeamsEnd = 99,
		[DefaultAggressionLevel(TeamId.PlayerTeams, AggressionLevel.Neutral, false)]
		CochranTestShips = 901
	}
}
