using System;
using VampireSurvivors.Builds.Game;

namespace VampireSurvivors.Builds;

[Serializable]
public class BuildMeta
{
	public BuildPlatform BuildPlatform = BuildPlatform.UNKNOWN;

	public string BuildNumber;

	public string BuildAgent;

	public string VcsHash;

	public string VcsBranch;
}
