using System;

namespace Assets.Scripts.Flight.Combat.Teams.Events
{
	public class AggressionLevelChangedEventArgs : EventArgs
	{
		public AggressionLevel NewAggressionLevel { get; }

		public AggressionLevel PreviousAggressionLevel { get; }

		public ushort TeamId1 { get; }

		public ushort TeamId2 { get; }

		public AggressionLevelChangedEventArgs(AggressionLevel newAggressionLevel, AggressionLevel previousAggressionLevel, ushort teamId1, ushort teamId2)
		{
			NewAggressionLevel = newAggressionLevel;
			PreviousAggressionLevel = previousAggressionLevel;
			TeamId1 = teamId1;
			TeamId2 = teamId2;
		}
	}
}
