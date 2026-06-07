using System;

namespace VampireSurvivors.Framework.Platforms.Saves
{
	[Flags]
	public enum CommitOptions
	{
		Default = 0,
		TrySynchronously = 1
	}
}
