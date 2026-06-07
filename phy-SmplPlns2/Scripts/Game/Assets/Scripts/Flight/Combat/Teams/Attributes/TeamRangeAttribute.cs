using System;

namespace Assets.Scripts.Flight.Combat.Teams.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class TeamRangeAttribute : Attribute
	{
		public TeamId EndRange { get; }

		public TeamId StartRange { get; }

		public TeamRangeAttribute(TeamId startRange, TeamId endRange)
		{
			StartRange = startRange;
			EndRange = endRange;
		}
	}
}
