using System;

namespace Gh.Tk
{
	[AttributeUsage(AttributeTargets.Class)]
	internal sealed class TraitStaffTierRestrictionAttribute : Attribute
	{
		public int MinTier { get; }

		public int MaxTier { get; }

		public TraitStaffTierRestrictionAttribute(int minTier, int maxTier)
		{
		}
	}
}
