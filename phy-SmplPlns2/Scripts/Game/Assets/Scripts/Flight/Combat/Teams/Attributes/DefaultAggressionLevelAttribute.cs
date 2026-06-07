using System;

namespace Assets.Scripts.Flight.Combat.Teams.Attributes
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
	public class DefaultAggressionLevelAttribute : Attribute
	{
		public AggressionLevel AggressionLevel { get; }

		public bool Locked { get; }

		public TeamId TeamId { get; }

		public DefaultAggressionLevelAttribute(TeamId teamId, AggressionLevel aggressionLevel, bool locked = false)
		{
			TeamId = teamId;
			AggressionLevel = aggressionLevel;
			Locked = locked;
		}
	}
}
