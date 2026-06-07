using System;

namespace Assets.Scripts.Flight.Combat.Teams.Events
{
	public class TeamChangedEventArgs : EventArgs
	{
		public ushort NewTeamId { get; }

		public ushort PreviousTeamId { get; }

		public TeamChangedEventArgs(ushort previousTeamId, ushort newTeamId)
		{
			PreviousTeamId = previousTeamId;
			NewTeamId = newTeamId;
		}
	}
}
