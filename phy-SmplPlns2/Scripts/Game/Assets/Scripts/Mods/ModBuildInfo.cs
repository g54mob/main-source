using System;

namespace Assets.Scripts.Mods
{
	public class ModBuildInfo
	{
		public Version BuildGameVersion { get; }

		public Guid BuildId { get; }

		public string BuildOperatingSystem { get; }

		public string BuildUnityVersion { get; }

		public ModBuildInfo(Guid buildId, Version buildGameVersion, string buildUnityVersion, string buildOperatingSystem)
		{
			BuildId = buildId;
			BuildGameVersion = buildGameVersion;
			BuildUnityVersion = buildUnityVersion;
			BuildOperatingSystem = buildOperatingSystem;
		}
	}
}
