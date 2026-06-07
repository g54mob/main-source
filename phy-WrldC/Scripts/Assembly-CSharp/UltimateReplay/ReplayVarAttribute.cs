using System;

namespace UltimateReplay
{
	[AttributeUsage(AttributeTargets.Field)]
	public sealed class ReplayVarAttribute : Attribute
	{
		public bool interpolate = true;

		public ReplayVarAttribute(bool interpolated = true)
		{
			interpolate = interpolated;
		}
	}
}
